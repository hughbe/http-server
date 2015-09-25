using System.Net;

namespace HttpServer
{
    public class ServerAuthenticator
    {
        private ServerAuthenticator() { }

        public static ServerAuthenticator None() => new ServerAuthenticator();

        public static ServerAuthenticator Protected(string username, string password)
        {
            var authentification = new ServerAuthenticator();
            authentification.Scheme = AuthenticationSchemes.Basic;
            authentification.Username = username;
            authentification.Password = password;
            return authentification;
        }

        public AuthenticationSchemes Scheme { get; private set; } = AuthenticationSchemes.None;

        public string Username { get; private set; }
        public string Password { get; private set; }
    }
}
