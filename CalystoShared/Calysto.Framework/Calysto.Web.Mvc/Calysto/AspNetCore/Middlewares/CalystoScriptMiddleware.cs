using Calysto.Common;
using Calysto.Web.Script.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calysto.AspNetCore.Middlewares
{
	public class CalystoScriptMiddleware
	{
		private readonly RequestDelegate _next;

		public CalystoScriptMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext context)
		{
			if (context.Request.Path.Value.Contains(CalystoAjaxHandlerConstants.HandlerBasePath))
			{
				var handler = WsjsHandlerFactory.ResolveHandler(context);
				await handler.ProcessRequestAsync(context);
			}
			else
			{
				await _next.Invoke(context);
			}
		}
	}
}
