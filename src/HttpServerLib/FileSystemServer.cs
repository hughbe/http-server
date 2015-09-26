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
            RootDirectory = rootDirectory;
        }

        public string RootDirectory { get; set; }

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
            
            SendError(404, "File or Folder Not Found", response);
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

            var document = new HtmlDocument();
            document.Head.Add(Tags.Title.WithContent(title));

            var body = document.Body;
            
            body.Add(Tags.H1.WithContent(title).WithClass("title directory-title"));
            body.Add(Tags.Hr);

            var pathsList = body.Add(Tags.Ul.WithClass("directory-list"));

            if (!requestedPath.Equals(RootDirectory))
            {
                var backupAnchor = Tags.Anchor.WithAttribute("href", "../").WithContent("Backup").WithClass("directory-link backup");
                pathsList.Add(Tags.Li.WithChildren(backupAnchor).WithClass("directory-list-item"));
            }
            try
            {
                var paths = GetFilesAndFolders(requestedPath);

                foreach (var path in paths)
                {
                    var anchor = Tags.Anchor.WithAttribute("href", path).WithContent(path).WithClass("directory-link");
                    pathsList.Add(Tags.Li.WithChildren(anchor).WithClass("directory-list-item"));
                }
                
                SendHtml(document, response);
            }
            catch (Exception exception)
            {
                var errorCode = 500;
                var errorMessage = "Unknown Error";
                if (exception is SecurityException || exception is UnauthorizedAccessException)
                {
                    errorCode = 403;
                    errorMessage = "Access Denied";
                }
                SendError(errorCode, errorMessage, response);
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
    }
}
