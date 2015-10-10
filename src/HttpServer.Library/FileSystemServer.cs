using HtmlGenerator;
using System.IO;
using System.Net;
using System;
using System.Collections.Generic;
using System.Security;

namespace Http.Server
{
    public class FileSystemServer : HttpServer
    {
        public FileSystemServer(string rootDirectory, int port, string prefix, HttpServerAuthentication authentication) : base(port, prefix, authentication)
        {
            RootDirectory = rootDirectory;
        }

        public string RootDirectory { get; set; }

        protected override void HandleReceive(HttpListenerRequest request, HttpListenerResponse response, string requestPath)
        {
            string requestedPath = RootDirectory + requestPath;

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

        private static bool TrySendFile(string requestedPath, HttpListenerResponse response)
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
            document.Head.Add(Tag.Title.WithContent(title));

            var body = document.Body;
            
            body.Add(Tag.H1.WithContent(title).WithClass("title directory-title"));
            body.Add(Tag.Hr);

            var pathsList = body.Add(Tag.Ul.WithClass("directory-list"));

            if (!requestedPath.Equals(RootDirectory))
            {
                var backupAnchor = Tag.A.WithAttribute("href", "../").WithContent("Backup").WithClass("directory-link backup");
                pathsList.Add(Tag.Li.WithChildren(backupAnchor).WithClass("directory-list-item"));
            }
            try
            {
                var paths = GetFilesAndFolders(requestedPath);

                foreach (var path in paths)
                {
                    var anchor = Tag.A.WithAttribute("href", path).WithContent(path).WithClass("directory-link");
                    pathsList.Add(Tag.Li.WithChildren(anchor).WithClass("directory-list-item"));
                }
                
                SendHtml(document, response);
            }
            catch (SecurityException)
            {
                SendError(403, "Access Denied", response);
            }
            catch (UnauthorizedAccessException)
            {
                SendError(403, "Access Denied", response);
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
