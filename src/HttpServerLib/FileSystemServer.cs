using HtmlGenerator;
using System.IO;
using System.Net;
using System;
using System.Collections.Generic;
using System.Security;

namespace HttpServer
{
    public class FileSystemServer : Server
    {
        public FileSystemServer(string rootDirectory, int port, string prefix, ServerAuthenticator authentificator) : base(port, prefix, authentificator)
        {
            UpdateRootDirectory(rootDirectory);
        }

        public string RootDirectory { get; private set; }
        public void UpdateRootDirectory(string rootDirectory) => RootDirectory = rootDirectory;

        protected override void HandleReceive(HttpListenerRequest request, HttpListenerResponse response, string requestUrl)
        {
            string requestedPath = RootDirectory + requestUrl;

            var sentFile = TrySendFile(requestedPath, response);
            if (sentFile)
            {
                return;
            }

            var sentFolder = TrySendFolder(requestedPath, response);
            if (sentFolder)
            {
                return;
            }

            SendError("File or Folder Not Found", response);
        }

        private bool TrySendFile(string requestedPath, HttpListenerResponse response)
        {
            if (!File.Exists(requestedPath))
            {
                return false;
            }
            SendData(File.ReadAllBytes(requestedPath), response);
            return true;
        }

        private bool TrySendFolder(string requestedPath, HttpListenerResponse response)
        {
            if (!Directory.Exists(requestedPath))
            {
                return false;
            }
            
            var title = "Directory Listing for " + requestedPath.Replace(RootDirectory, string.Empty);

            var document = new HtmlDocument(title);
            var body = document.Body;
            
            body.Add(Tags.H1.WithContent(title));

            var pathsList = body.Add(Tags.Ul);

            try
            {
                var paths = GetFilesAndFolders(requestedPath);

                foreach (var path in paths)
                {
                    var attributes = new Dictionary<string, string>
                    {
                        {"href", path }
                    };
                    var anchor = Tags.Anchor.WithAttributes(attributes).WithContent(path);
                    pathsList.Add(Tags.Li.WithChildren(anchor));
                }
                
                SendHtml(document, response);
            }
            catch (Exception exception)
            {
                var errorMessage = "Unknown Error";
                if (exception is SecurityException || exception is UnauthorizedAccessException)
                {
                    errorMessage = "Access Denied";
                }
                SendError(errorMessage, response);
            }

            return true;
        }

        private static List<string> GetFilesAndFolders(string requestedPath)
        {
            var paths = new List<string>();
            foreach (string path in Directory.GetDirectories(requestedPath))
            {
                var objectPath = path.Replace(requestedPath, "") + "/";
                paths.Add(objectPath);
            }

            foreach (string path in Directory.GetFiles(requestedPath))
            {
                var objectPath = path.Replace(requestedPath, "");
                paths.Add(objectPath);
            }
            return paths;
        }

        private void SendError(string errorMessage, HttpListenerResponse response)
        {
            var document = new HtmlDocument("Error");
            var body = document.Body;

            body.Add(Tags.H1.WithContent("Error"));
            body.Add(Tags.H2.WithContent(errorMessage));

            SendHtml(document, response);
        }
    }
}
