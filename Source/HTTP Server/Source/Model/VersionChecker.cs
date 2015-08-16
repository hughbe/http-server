using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;

namespace HttpServer
{
    /// <summary>
    /// A class managing checking if the current version of the application is the latest
    /// </summary>
    public static class VersionChecker
    {
        /// <summary>
        /// The URL of a text file containing the value of the latest version of the application
        /// </summary>
        private static string latestVersionURL = "http://hughbellamy.com/Versions/httpserver.txt";

        /// <summary>
        /// Gets the current version of the application
        /// </summary>
        public static string CurrentVersion
        {
            get
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
                return StandardizedString(fileVersionInfo.FileVersion);
            }
        }

        /// <summary>
        /// Gets the latest version of the application
        /// </summary>
        public static string LatestVersion
        {
            get
            {
                try
                {
                    return StandardizedString(new WebClient().DownloadString(latestVersionURL));
                }
                catch
                {
                    return CurrentVersion;
                }
            }
        }

        /// <summary>
        /// Standardizes the latest and current version strings to a uniform comparable format
        /// </summary>
        /// <param name="version">The version to standardize</param>
        /// <returns>A standardized uniform format for versions</returns>
        private static string StandardizedString(string versionString)
        {
            return Regex.Replace(versionString, @"\r\n?|\n", "").Replace(" ", "");
        }

        /// <summary>
        /// Checks if the current version of the application is the latest
        /// </summary>
        /// <returns></returns>
        public static bool CurrentVersionIsUpToDate()
        {
            return CurrentVersion.Equals(LatestVersion);
        }
    }
}
