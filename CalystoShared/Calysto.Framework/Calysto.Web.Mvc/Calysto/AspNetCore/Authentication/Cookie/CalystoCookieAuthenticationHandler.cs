using Calysto.AspNetCore.Mvc.Razor;
using Calysto.Security.Cryptography;
using Calysto.Serialization.Json;
using Calysto.Serialization.Json.Core.Serialization;
using Calysto.Web;
using ExcelDataReader.Log;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Web;

/*
 
 * Login code has to be invoked from user controller after username & pass is valid:
	var claims = new[] { new Claim(ClaimTypes.Name, username), new Claim(ClaimTypes.NameIdentifier, appMemberID+"") };
	var identity = new ClaimsIdentity(claims, ArizonaAuthentication.SchemeName);
	var principal = new ClaimsPrincipal(identity);
	CalystoHostingEnvironment.Current.HttpContext.SignInAsync(principal, new AuthenticationProperties() { IsPersistent = rememberMe }).Wait();
   
    * Logout code has to be invoked from user controller:
    * CalystoHostingEnvironment.Current.HttpContext.SignOutAsync().Wait();
*/

namespace Calysto.AspNetCore.Authentication.Cookie
{
	public class CalystoCookieAuthenticationHandler : AuthenticationHandler<CalystoCookieAuthenticationOptions>, 
        IAuthenticationSignOutHandler, 
        IAuthenticationSignInHandler
    {
        public CalystoCookieAuthenticationHandler(
			IOptionsMonitor<CalystoCookieAuthenticationOptions> options,
			ILoggerFactory logger,
			UrlEncoder encoder,
			ISystemClock clock) : base(options, logger, encoder, clock)
        {
		}

        public const string ReturnUrlQueryName = "b";

        private Calysto.Security.Cryptography.AESCryptoHelper GetCryptoService()
        {
            if (string.IsNullOrWhiteSpace(this.Options.EcryptionKey))
                throw new InvalidOperationException($"{nameof(CalystoCookieAuthenticationOptions.EcryptionKey)} property has to be assigned.");

            return new Security.Cryptography.AESCryptoHelper(this.Options.EcryptionKey);
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
		{
            var claims = this.AuthenticateWorker();

            if (claims != null)
                return Task.FromResult(AuthenticateResult.Success(CreateAuthenticationTicket(claims)));
            else
                return Task.FromResult(AuthenticateResult.NoResult());
        }

		protected override Task HandleChallengeAsync(AuthenticationProperties properties)
		{
            string loginPath = this.Options?.GetLoginPath?.Invoke(this.Context);

            if (loginPath != null)
            {
                string destination = $"{loginPath}?{ReturnUrlQueryName}={this.Context.Request.GetEncodedUrl()}";
                if (this.Context.Request.IsClaystoAjax())
                {
                    // prevent automatic redirecting with XMLHttpRequest, possible only if we send status 200 instead of 301 or 302
                    // and check if "location" header exists at client side
                    this.Context.Response.Headers[HeaderNames.Location] = destination;
                    this.Context.Response.StatusCode = 200;
                }
                else
                {
                    this.Context.Response.Redirect(destination, false);
                }
                return Task.CompletedTask;
            }
            else
            {
                return base.HandleChallengeAsync(properties); // returns status 401 Unauthorized
            }
        }

        protected override Task HandleForbiddenAsync(AuthenticationProperties properties)
        {
            string allowedPath = this.Options?.GetFirstAllowedPath?.Invoke(this.Context);
            if (allowedPath != null)
            {
                if (this.Context.Request.IsClaystoAjax())
                {
                    // prevent automatic redirecting with XMLHttpRequest, possible only if we send status 200 instead of 301 or 302
                    // and check if "location" header exists at client side
                    this.Context.Response.Headers[HeaderNames.Location] = allowedPath;
                    this.Context.Response.StatusCode = 200;
                }
                else
                {
                    this.Context.Response.Redirect(allowedPath, false);
                }
                return Task.CompletedTask;
            }
            else
            {
                return base.HandleForbiddenAsync(properties); // returns status 403 Forbidden
            }
        }
        
        public Task SignInAsync(ClaimsPrincipal user, AuthenticationProperties properties)
        {
            this.Context.User = user;
            this.WriteToCookie(user.Claims.ToArray(), properties);
            return Task.CompletedTask;
        }

        public Task SignOutAsync(AuthenticationProperties properties)
        {
            this.Context.User = null;
            CookieHelper.DeleteCookie(this.Options.CookieName);
            return Task.CompletedTask;
        }

        private AuthenticationTicket CreateAuthenticationTicket(Claim[] claims)
        {
            //var claims = new[] { new Claim(ClaimTypes.Name, user), new Claim(ClaimTypes.Role, "role1") };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            return ticket;
        }

        private class CookieTicket
        {
            public string Scheme { get; set; }
            public Claim[] Claims { get; set; }
        }

        private SerializerOptions GetOptions()
        {
            return new SerializerOptions() { DateFormat = DateTimeFormat.ISOTDateTime };
        }

        private CalystoCertification GetSigner()
        {
            string headers = CalystoContextMvc.Current.BrowserDistinctHeaderString;
            return new CalystoCertification(headers + this.Options.EcryptionKey);
        }

        private bool TryReadFromCookie(out CookieTicket ticket)
        {
            if(CookieHelper.TryGetCookieValue(this.Options.CookieName, out string encrypted))
            {
                try
                {
                    string jsonSigned = this.GetCryptoService().DecryptToString(Convert.FromBase64String(encrypted));
                    if (this.GetSigner().TryDecode(jsonSigned, out string json1))
                    {
                        ticket = JsonSerializer.Deserialize<CookieTicket>(json1, this.GetOptions());
                        if (!string.IsNullOrEmpty(ticket.Scheme) && ticket.Scheme == this.Scheme.Name)
                            return true;
                    }
                }
                catch
                {
                }
                // delete cookie
                CookieHelper.DeleteCookie(this.Options.CookieName);
            }
            ticket = null;
            return false;
        }

        private void WriteToCookie(Claim[] claims, AuthenticationProperties properties)
        {
            var ticket = new
            {
                Scheme = this.Scheme.Name,
                Claims = claims.Select(c => new {
                    Name = c.Type,
                    Value = c.Value
                }).ToArray()
            };

            string json1 = Calysto.Serialization.Json.JsonSerializer.Serialize(ticket, this.GetOptions());
            string signedJson = this.GetSigner().Sign(json1);
            string encrypted = Convert.ToBase64String(this.GetCryptoService().Encrypt(signedJson));

            CookieOptions cookieOptions = null;
            if(properties != null && properties.IsPersistent)
			{
                cookieOptions = new CookieOptions() { Expires = DateTime.Now.AddYears(10) };
			}
            CookieHelper.SetCookie(this.Options.CookieName, encrypted, cookieOptions);
        }

        private Claim[] AuthenticateWorker()
        {
            if (TryReadFromCookie(out CookieTicket ticket))
            {
                return ticket.Claims;
            }
            else
            {
                // returning Fail() or NoResult() will invoke HandleChallengeAsync()
                //return AuthenticateResult.Fail("nocookie");
                return null;
            }
        }

    }
}
