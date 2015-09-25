using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;

namespace HttpServer
{
    public static class VersionChecker
    {
        private static string latestVersionURL = "http://hughbellamy.com/resources/versions/http-server/currentversion.txt";
        
        public static string CurrentVersion => StandardizedString(Assembly.GetExecutingAssembly().GetName().Version.ToString());

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

        private static string StandardizedString(string versionString)
        {
            var replaced = Regex.Replace(versionString, @"\r\n?|\n", "").Replace(" ", "");
            return replaced;
        }
        
        public static bool CurrentVersionIsUpToDate() => CurrentVersion.Equals(LatestVersion);
    }
}
