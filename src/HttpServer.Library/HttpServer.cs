﻿using HtmlGenerator;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Text;
using System.Threading;

namespace Http.Server
{
    public abstract class HttpServer: IDisposable
    {
        protected HttpServer(int port, string host, HttpServerAuthentication authentication)
        {
            Port = port;
            Host = host;
            Authentication = authentication;
            Listener = new HttpListener();
        }

        protected HttpListener Listener { get; private set; }
        protected Thread ListenerThread { get; private set; }
        
        public int Port { get; set; }
        public string Host { get; set; }

        public HttpServerAuthentication Authentication { get; set; }

        public string Prefix => "http://" + Host + ":" + Port.ToString(CultureInfo.InvariantCulture) + "/";

        public string PrefixRegistrationCommand
        {
            get
            {
                var username = Environment.GetEnvironmentVariable("USERNAME");
                var userdomain = Environment.GetEnvironmentVariable("USERDOMAIN");
                return string.Format(CultureInfo.InvariantCulture, "netsh http add urlacl url={0} user={1}\\{2} listen=yes", Prefix, userdomain, username);
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
                if (Authentication.Scheme != AuthenticationSchemes.None)
                {
                    Listener.AuthenticationSchemes = Authentication.Scheme;
                }
                Listener.Prefixes.Clear();
                Listener.Prefixes.Add(Prefix);
                Listener.Start();

                UpdateState(HttpServerState.Started);
                ListenerThread = new Thread(Listen) { IsBackground = true };
                ListenerThread.Start();
            }
            catch (HttpListenerException exception)
            {
                Error = exception;
                UpdateState(HttpServerState.Error);

                if (exception.ErrorCode == 5 && exception.ErrorCode == 5) //We need to register as an admin
                {
                    var psi = new ProcessStartInfo("netsh", PrefixRegistrationCommand.Replace("netsh ", string.Empty))
                    {
                        Verb = "runas",
                        CreateNoWindow = true,
                        WindowStyle = ProcessWindowStyle.Hidden,
                        UseShellExecute = true
                    };
                    Process.Start(psi)?.WaitForExit();

                    Debug.WriteLine("An error occured registering the server. Run this command in cmd as administrator to fix: ");
                    Debug.WriteLine(PrefixRegistrationCommand);
                    Restart();
                }
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
                    var context = Listener.GetContext();

                    var request = context.Request;
                    var response = context.Response;

                    if (Authentication.Scheme == AuthenticationSchemes.Basic)
                    {
                        var userRequest = (HttpListenerBasicIdentity)context.User.Identity;
                        var username = userRequest.Name;
                        var password = userRequest.Password;

                        if (username != Authentication.UserName || password != Authentication.Password)
                        {
                            response.StatusCode = 401;
                            response.Close();
                        }
                    }

                    var rawUrl = Uri.UnescapeDataString(request.RawUrl);
                    Console.WriteLine(rawUrl);

                    HandleReceive(request, response, rawUrl);
                }
                catch { }
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
            document.Head.AddChild(Tag.Title.WithInnerText(title));

            var body = document.Body;

            body.AddChild(Tag.H1.WithInnerText(title).WithClass("title error-title"));
            body.AddChild(Tag.Hr);
            body.AddChild(Tag.H2.WithInnerText(errorMessage).WithClass("error-message"));

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
                document.Head.AddChild(Tag.Style.WithInnerText(CssStyles));
            }

            SendData(Encoding.UTF8.GetBytes(document.Serialize()), response);
        }

        public static void SendData(byte[] data, HttpListenerResponse response)
        {
            if (data == null || response == null)
            {
                return;
            }

            response.ContentLength64 = data.Length;
            response.OutputStream.Write(data, 0, data.Length);

            response.OutputStream.Close();
        }

        protected abstract void HandleReceive(HttpListenerRequest request, HttpListenerResponse response, string requestPath);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Listener?.Close();
                Listener = null;
            }
        }
    }
}
