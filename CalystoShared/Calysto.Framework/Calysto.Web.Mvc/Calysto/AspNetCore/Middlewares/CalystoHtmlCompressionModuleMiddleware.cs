using Calysto.AspNetCore.Middlewares.Filters;
using Calysto.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Calysto.AspNetCore.Middlewares
{
	public class CalystoHtmlCompressionModuleMiddleware
	{
		private readonly RequestDelegate _next;

		public CalystoHtmlCompressionModuleMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext context)
		{
			using (var filter = new CalystoHtmlCompressorStream(context, context.Response.Body))
			{
				context.Response.Body = filter;

				try
				{
					// since this is module, we have to invoke next action
					await _next.Invoke(context);
				}
				catch
				{
					context.Response.Body = filter.RestoreBaseStream();
					throw;
				}
			}
		}
	}
}
