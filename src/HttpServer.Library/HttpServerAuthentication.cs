using System.Net;

namespace Http.Server
{
    public class HttpServerAuthentication
    {
        private HttpServerAuthentication() { }

        public static HttpServerAuthentication None() => new HttpServerAuthentication();

        public static HttpServerAuthentication Protected(string userName, string password)
        {
            var authentification = new HttpServerAuthentication
            {
                Scheme = AuthenticationSchemes.Basic,
                UserName = userName,
                Password = password
            };
            return authentification;
        }

        public AuthenticationSchemes Scheme { get; private set; } = AuthenticationSchemes.None;

        public string UserName { get; private set; }
        public string Password { get; private set; }
    }
}
