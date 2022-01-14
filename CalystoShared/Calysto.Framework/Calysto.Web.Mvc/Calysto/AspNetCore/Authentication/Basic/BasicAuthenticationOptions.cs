using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Calysto.AspNetCore.Authentication.Basic
{ 
    public class BasicAuthenticationOptions : AuthenticationSchemeOptions
    {
        public string Realm { get; set; }

        public Func<string, string, IEnumerable<Claim>> ValidateUser { get; set; }

    }
}