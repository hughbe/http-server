using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Security;
using System.Text;
using System.Threading;

namespace HttpServer
{
    /// <summary>
    /// The class managing listening for incoming HTTP requests and responding to these requests
    /// </summary>
    public class HttpListenerServer
    {
        #region Singleton

        private static HttpListenerServer instance;
        private HttpListenerServer() { }

        /// <summary>
        /// The server object is a singleton - only one server can be running at a time
        /// </summary>
        public static HttpListenerServer SharedServer
        {
            get
            {
                if (instance == null)
                {
                    instance = new HttpListenerServer();
                }
                return instance;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// The internal HttpListener object that listens for incoming HTTP requests
        /// </summary>
        private HttpListener _listener;
        public HttpListener Listener
        {
            get { return _listener; }
            set { _listener = value; }
        }

        /// <summary>
        /// The background thread on which the HttpListener listens for incoming HTTP requests
        /// </summary>
        private Thread _listenerThread;
        public Thread ListenerThread
        {
            get { return _listenerThread; }
            set { _listenerThread = value; }
        }

        /// <summary>
        /// The port for which the HttpListener listens for incoming HTTP requests
        /// </summary>
        private int _port = 8000;
        public int Port
        {
            get { return _port; }
            set { _port = value; }
        }

        /// <summary>
        /// The root directory of the HttpListener that the server outputs to the user
        /// </summary>
        private string _rootDirectory = "";
        public string RootDirectory
        {
            get { return _rootDirectory; }
            set { _rootDirectory = value; }
        }

        /// <summary>
        /// A value indicating whether the server is running or not
        /// </summary>
        private bool _isActive = false;
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        /// <summary>
        /// The maximum size of HTTP requests to receive
        /// </summary>
        private int _receivedDataBufferSize = 1024;
        public int ReceivedDataBufferSize
        {
            get { return _receivedDataBufferSize; }
            set { _receivedDataBufferSize = value; }
        }

        /// <summary>
        /// The host and port on which the HttpListener listens for incoming HTTP requests
        /// </summary>
        private string _prefix = "http://localhost/";
        public string Prefix
        {
            get { return _prefix; }
            set { _prefix = value; }
        }

        #endregion

        #region Starting

        /// <summary>
        /// Starts the server to listen and handle incoming HTTP requests
        /// </summary>
        /// <param name="port">The port for which to listen for incoming HTTP requests</param>
        /// <param name="rootDirectory">The root directory of the HttpListener that the server outputs to the user</param>
        public void Start(int port, string rootDirectory)
        {
            IsActive = true;
            Port = port;
            RootDirectory = rootDirectory;
            Setup();
        }

        /// <summary>
        /// Restarts the server
        /// </summary>
        /// <param name="port">The new port for which to listen for incoming HTTP requests</param>
        /// <param name="rootDirectory">The new root directory of the HttpListener that the server outputs to the user</param>
        public void Restart(int port, string rootDirectory)
        {
            Stop();
            Start(port, rootDirectory);
        }
        
        /// <summary>
        /// Initializes the server and the HttpListener and it's background thread
        /// </summary>
        private void Setup()
        {
            Prefix = "http://localhost:" + Port.ToString() + "/";
            Listener = new HttpListener();
            Listener.Prefixes.Add(Prefix);
            Listener.Start();
            ListenerThread = new Thread(new ThreadStart(Listen));
            ListenerThread.Start();
        }

        #endregion

        #region Listening

        /// <summary>
        /// Handles and responds to incoming HTTP requests
        /// </summary>
        public void Listen()
        {
            while (IsActive)
            {
                try
                {
                    HttpListenerContext context = Listener.GetContext();

                    HttpListenerRequest request = context.Request;
                    HttpListenerResponse response = context.Response;

                    Stream outputStream = response.OutputStream;

                    string rawURL = WebUtility.UrlDecode(request.RawUrl);
                    string homeDirectory = WebUtility.UrlDecode(RootDirectory);

                    string requestURL = homeDirectory + rawURL;

                    bool fileExists = File.Exists(requestURL);
                    bool directoryExists = Directory.Exists(requestURL);

                    byte[] dataToSend;

                    if (fileExists)
                    {
                        dataToSend = File.ReadAllBytes(requestURL);

                    }
                    else if (directoryExists)
                    {
                        string HTMLStart = "<html>";

                        string headerStart = "<head><title>";
                        string headerTitle = "Directory Listing for " + rawURL;
                        string headerEnd = "</title></head>";

                        string bodyStart = "<body>";
                        string bodyTitle = "<h1>" + headerTitle + "</h1>";

                        string bodySeperator = "<hr>";
                        string bodyListStart = "<ul>";

                        string bodyList = "";

                        string bodyListEnd = "</ul>";

                        string bodyEnd = "</body>";
                        string HTMLEnd = "</html>";

                        try
                        {
                            List<string> paths = new List<string>();
                            foreach (string path in Directory.GetDirectories(requestURL))
                            {
                                string objectPath = path.Replace(requestURL, "") + "/";
                                paths.Add(objectPath);
                            }

                            foreach (string path in Directory.GetFiles(requestURL))
                            {
                                string objectPath = path.Replace(requestURL, "");
                                paths.Add(objectPath);
                            }

                            foreach (string path in paths)
                            {
                                string listStart = "<li>";
                                string listLink = @"<a href = """ + path + @""">" + path + "</a>";
                                string listEnd = "</li>";

                                string listObject = listStart + listLink + listEnd;

                                bodyList += listObject;
                            }
                        }
                        catch (Exception exception)
                        {
                            if (exception is SecurityException || exception is UnauthorizedAccessException)
                            {
                                dataToSend = errorMessageBytes("Access Denied");
                            }
                            else
                            {
                                dataToSend = errorMessageBytes("Unknown Error");
                            }

                        }
                        string responseString = HTMLStart + headerStart + headerTitle + headerEnd + bodyStart + bodyTitle + bodySeperator + bodyListStart + bodyList + bodyListEnd + bodyEnd + HTMLEnd;

                        dataToSend = Encoding.UTF8.GetBytes(responseString);
                    }
                    else
                    {
                        dataToSend = errorMessageBytes("File or Folder Not Found");
                    }

                    response.ContentLength64 = dataToSend.Length;
                    outputStream.Write(dataToSend, 0, dataToSend.Length);

                    outputStream.Close();
                }
                catch { }
            }
        }

        /// <summary>
        /// The data representing an HTML page to send to the client with a specified error message
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        private static byte[] errorMessageBytes(string errorMessage)
        {
            string HTMLStart = "<html>";

            string headStart = "<head><title>";
            string headTitle = "Error";
            string headEnd = "</title></head>";

            string bodyStart = "<body>";
            string bodyTitle = "<h1>Error</h1>";
            string bodyErrorMessage = "<h2>" + errorMessage + "</h2>";
            string bodyEnd = "</body>";

            string HTMLEnd = "</html>";

            string responseString = HTMLStart + headStart + headTitle + headEnd + bodyStart + bodyTitle + bodyErrorMessage + bodyEnd + HTMLEnd;

            return Encoding.UTF8.GetBytes(responseString);
        }

        #endregion

        #region Ending

        /// <summary>
        /// Stops the server by stopping the HttpListener and the background thread on which it is listening
        /// </summary>
        public void Stop()
        {
            IsActive = false;
            if (Listener != null)
            {
                Listener.Abort();
                Listener = null;
            }
            if (ListenerThread != null)
            {
                ListenerThread.Abort();
                ListenerThread = null;
            }
        }

        #endregion

    }
}
