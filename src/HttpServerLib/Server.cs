using HtmlGenerator;
using System;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Threading;

namespace HttpServer
{
    public abstract class Server
    {
        protected Server(int port, string host, ServerAuthenticator authenticator)
        {
            Port = port;
            Host = host;
            Authenticator = authenticator;
            Listener = new HttpListener();
        }

        protected HttpListener Listener { get; }
        protected Thread ListenerThread { get; private set; }
        
        public int Port { get; set; }
        public string Host { get; set; }

        public ServerAuthenticator Authenticator { get; set; }

        public string Prefix => "http://" + Host + ":" + Port.ToString() + "/";

        public string PrefixRegistrationCommand
        {
            get
            {
                var username = Environment.GetEnvironmentVariable("USERNAME");
                var userdomain = Environment.GetEnvironmentVariable("USERDOMAIN");
                return string.Format("netsh http add urlacl url={0} user={1}\\{2} listen=yes", Prefix, userdomain, username);
            }
        }

        public event EventHandler<EventArgs> DidUpdateState;

        public HttpServerState State { get; private set; } = HttpServerState.NotStarted;
        public Exception Error { get; private set; }

        public string CssStyles { get; set; }

        private void UpdateState(HttpServerState state)
        {
            State = state;
            DidUpdateState?.Invoke(this, new EventArgs());
        }

        public void Start()
        {
            if (State == HttpServerState.Started)
            {
                return;
            }

            try
            {
                if (Authenticator.Scheme != AuthenticationSchemes.None)
                {
                    Listener.AuthenticationSchemes = Authenticator.Scheme;
                }
                Listener.Prefixes.Clear();
                Listener.Prefixes.Add(Prefix);
                Listener.Start();

                UpdateState(HttpServerState.Started);
                ListenerThread = new Thread(new ThreadStart(Listen)) { IsBackground = true };
                ListenerThread.Start();
            }
            catch (Exception exception)
            {
                var listenerException = exception as HttpListenerException;
                if (listenerException?.ErrorCode == 5 && listenerException?.ErrorCode == 5) //We need to register as an admin
                {
                    ProcessStartInfo psi = new ProcessStartInfo("netsh", PrefixRegistrationCommand.Replace("netsh ", string.Empty));
                    psi.Verb = "runas";
                    psi.CreateNoWindow = true;
                    psi.WindowStyle = ProcessWindowStyle.Hidden;
                    psi.UseShellExecute = true;
                    Process.Start(psi).WaitForExit();
                    
                    Debug.WriteLine("An error occured registering the server. Run this command in cmd as administrator to fix: ");
                    Debug.WriteLine(PrefixRegistrationCommand);
                    Restart();
                }
                else
                {
                    UpdateState(HttpServerState.Error);
                }
                Error = exception;
            }
        }

        public void Stop()
        {
            if (State != HttpServerState.Started)
            {
                return;
            }
            UpdateState(HttpServerState.Stopped);

            Listener.Abort();
            Listener.Close();

            ListenerThread?.Abort();
            ListenerThread = null;
        }

        public void Restart()
        {
            Stop();
            Start();
        }

        private void Listen()
        {
            while (State == HttpServerState.Started)
            {
                try
                {
                    HttpListenerContext context = Listener.GetContext();

                    HttpListenerRequest request = context.Request;
                    HttpListenerResponse response = context.Response;

                    if (Authenticator.Scheme == AuthenticationSchemes.Basic)
                    {
                        var userRequest = (HttpListenerBasicIdentity)context.User.Identity;
                        var username = userRequest.Name;
                        var password = userRequest.Password;
                        
                        if (username != Authenticator.Username || password != Authenticator.Password)
                        {
                            response.StatusCode = 401;
                            response.Close();
                        }
                    }

                    string rawURL = request.RawUrl;
                    Console.WriteLine(rawURL);

                    HandleReceive(request, response, rawURL);
                }
                catch
                {
                }
            }
        }

        public void SendError(int errorCode, string errorMessage, HttpListenerResponse response)
        {
            if (errorMessage == null || response == null)
            {
                return;
            }

            var title = "Error " + errorCode;

            var document = new HtmlDocument();
            document.Head.Add(Tags.Title.WithContent(title));

            var body = document.Body;

            body.Add(Tags.H1.WithContent(title).WithClass("title error-title"));
            body.Add(Tags.Hr);
            body.Add(Tags.H2.WithContent(errorMessage).WithClass("error-message"));

            SendHtml(document, response);
        }

        public void SendHtml(HtmlDocument document, HttpListenerResponse response)
        {
            if (document == null || response == null)
            {
                return;
            }
            if (!string.IsNullOrEmpty(CssStyles))
            {
                document.Head.Add(Tags.Style.WithContent(CssStyles));
            }
            SendData(Encoding.UTF8.GetBytes(document.Serialize()), response);
        }

        public void SendData(byte[] data, HttpListenerResponse response)
        {
            if (data == null || response == null)
            {
                return;
            }

            response.ContentLength64 = data.Length;
            response.OutputStream.Write(data, 0, data.Length);

            response.OutputStream.Close();
        }

        protected abstract void HandleReceive(HttpListenerRequest request, HttpListenerResponse response, string requestUrl);
    }
}
