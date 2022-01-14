using Calysto.AspNetCore.Mvc.Razor;
using Calysto.Linq;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Calysto.Web
{
	public class CalystoUriMvc : CalystoUri
	{
		public CalystoUriMvc(HttpContext context)
		{
			this.Scheme = context.Request.Scheme;
			this.Host = context.Request.Host.Host;
			this.Port = context.Request.Host.Port;
			this.PathBase = context.Request.PathBase;
			this.Path = context.Request.Path;
			this.Query = context.Request.QueryString.Value;

			if (!string.IsNullOrWhiteSpace(this.Query) && !this.Query.StartsWith("?"))
				this.Query = "?" + this.Query;
		}

	}
}
