using Calysto.AspNetCore.Mvc.Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Calysto.AspNetCore.Authentication.Cookie
{
    public class CalystoCookieAuthenticationOptions : AuthenticationSchemeOptions
    {
        public string CookieName { get; set; }

        public string EcryptionKey { get; set; }

		public Func<HttpContext, string> GetLoginPath { get; set; }

        public Func<HttpContext, string> GetFirstAllowedPath { get; set; }
	}
}