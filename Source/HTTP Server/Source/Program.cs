using System;
using System.Windows.Forms;
using System.Net;
using HttpServer.Properties;

namespace HttpServer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            StartVersionChecking();

            StartUI();
            StartServer();

            Application.Run();
        }

        /// <summary>
        /// Initializes the version checker to see if the current version of HTTP Server is the latest
        /// </summary>
        private static void StartVersionChecking()
        {
            if (!Settings.Default.CheckForUpdates)
            {
                return;
            }
            bool upToDate = VersionChecker.CurrentVersionIsUpToDate();
            if (upToDate)
            {
                UserInterface.SharedUI.ShowBalloonToolTip("An update is available", "A new version of HTTP Server is available. Open Settings to download the new version.", 1000, true);
            }
        }

        /// <summary>
        /// Initializes the user interface and adapts the interface in the case of a first launch situation
        /// </summary>
        private static void StartUI()
        {
            UserInterface.SharedUI.SetupNotifications();

            if (!Settings.Default.UsedBefore)
            {
                Settings.Default.UsedBefore = true;
                Settings.Default.Save();
                UserInterface.SharedUI.ShowSelectRootFolderDialog(false);
            }

        }

        /// <summary>
        /// Initializes the server with the port and root directory specified by the user
        /// </summary>
        private static void StartServer()
        {
            try
            {
                HttpListenerServer.SharedServer.Start(Settings.Default.Port, Settings.Default.Root);
            }
            catch (HttpListenerException)
            {
                Settings.Default.Port = 8000;
                Settings.Default.Save();
                StartServer();
                return;
            }

            UserInterface.SharedUI.ShowBalloonToolTip("Server Started", "Server started on " + HttpListenerServer.SharedServer.Prefix, 2000, false);
        }
    }
}
