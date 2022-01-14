using Calysto.Serialization.Json;
using Calysto.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Calysto.AspNetCore.Authentication.Basic
{
	public class BasicAuthenticationHandler : AuthenticationHandler<BasicAuthenticationOptions>
    {
		private const string AUTH_SCHEME_NAME = "Basic";

        public BasicAuthenticationHandler(
			IOptionsMonitor<BasicAuthenticationOptions> options,
			ILoggerFactory logger,
			UrlEncoder encoder,
			ISystemClock clock) : base(options, logger, encoder, clock)
        {
		}

		protected override Task<AuthenticateResult> HandleAuthenticateAsync()
		{
            return Task.FromResult(this.AuthenticateWorker());
        }

		protected override Task HandleChallengeAsync(AuthenticationProperties properties)
		{
            Response.Headers["WWW-Authenticate"] = $"{AUTH_SCHEME_NAME} realm=\"{Options.Realm}\", charset=\"UTF-8\"";
            return base.HandleChallengeAsync(properties);
		}

        protected override Task HandleForbiddenAsync(AuthenticationProperties properties)
        {
            Response.Headers["WWW-Authenticate"] = $"{AUTH_SCHEME_NAME} realm=\"{Options.Realm}\", charset=\"UTF-8\"";
            //Response.StatusCode = 401;
            return base.HandleChallengeAsync(properties); // return 401, show dialog with user & pass again
        }

        private AuthenticateResult AuthenticateWorker()
        {
            if (!Request.Headers.ContainsKey(HeaderNames.Authorization))
            {
                //Authorization header not in request
                return AuthenticateResult.NoResult();
            }

            if (!AuthenticationHeaderValue.TryParse(Request.Headers[HeaderNames.Authorization], out AuthenticationHeaderValue headerValue))
            {
                //Invalid Authorization header
                return AuthenticateResult.NoResult();
            }

            if (!AUTH_SCHEME_NAME.Equals(headerValue.Scheme, StringComparison.OrdinalIgnoreCase))
            {
                //Not Basic authentication header
                return AuthenticateResult.NoResult();
            }

            byte[] headerValueBytes = Convert.FromBase64String(headerValue.Parameter);
            string userAndPassword = Encoding.UTF8.GetString(headerValueBytes);
            string[] parts = userAndPassword.Split(':');
            if (parts.Length != 2)
            {
                return AuthenticateResult.Fail("Invalid Basic authentication header");
            }

            string user = parts[0];
            string password = parts[1];

            var claims = this.Options.ValidateUser.Invoke(user, password)?.ToArray();

            if (claims?.Any() != true)
            {
                return AuthenticateResult.Fail("Invalid username or password");
            }

            return AuthenticateResult.Success(CreateTicket(claims));
        }

        private AuthenticationTicket CreateTicket(Claim[] claims)
        {
            //var claims = new[] { new Claim(ClaimTypes.Name, user), new Claim(ClaimTypes.Role, "role1") };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            return ticket;
        }
    }
}