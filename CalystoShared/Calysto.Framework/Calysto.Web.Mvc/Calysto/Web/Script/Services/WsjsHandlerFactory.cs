using Calysto.Common;
using Calysto.Common.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using System.Web;

namespace Calysto.Web.Script.Services
{
	class WsjsHandlerFactory
	{
		public static IHttpHandler ResolveHandler(HttpContext context)
		{
			if (context == null)
			{
				throw new ArgumentNullException("context is null");
			}

			// warning:
			// - inside JSON there can be RX-SC, so check for query string variables frist
			// - google bot has to be able to read css or js, but don't allow page request to web service or exception report

			string ua = context.Request.Headers[Microsoft.Net.Http.Headers.HeaderNames.UserAgent];
			if(string.IsNullOrEmpty(ua))
				return new NotFoundHandler();

			bool isBot = ua.Contains("bot") || ua.Contains("crawl");
			string path = context.Request.Path;

			//Sec-WebSocket-Key
			//Sec-WebSocket-Extensions
			//Sec-WebSocket-Version

			if (!isBot 
				&& context.Request.Headers[WsjsHeaderConstants.XAjaxHeaderKey] == WsjsHeaderConstants.XExceptionHeaderValue 
				&& path.Contains(CalystoAjaxHandlerConstants.ElmahRequest, true))
			{
				// test for x-rx-ajax header to avoid request from spiders
				// POST, must contain header x-rx-ajax
				// contains RX-EX
				return new CalystoElmahErrorHandler();
				
			}
			else if (
				(!isBot 
					&& context.Request.Headers[WsjsHeaderConstants.XAjaxHeaderKey] == WsjsHeaderConstants.XAjaxHeaderValue 
					&& !string.IsNullOrEmpty(context.Request.Query[WsjsTypeHandlerConstants.WebMethod]) 
					&& path.Contains(CalystoAjaxHandlerConstants.TypeServiceRequest, true)
				)
				||
				(!isBot
					&& !string.IsNullOrEmpty(context.Request.Headers["Sec-WebSocket-Key"]) 
					&& context.WebSockets.IsWebSocketRequest)
				)
			{
				// test for x-rx-ajax header to avoid request from spiders
				// accepts cross-domain requests, but crossdomain request can't add custom headers
				// WebMethod request
				if (AjaxQueryStringHelperMvc.UseSessionState(context))
				{
					return new WsjsTypeHandlerWithSession();
				}
				else
				{
					return new WsjsTypeHandler();
				}
			}
			else if (path.Contains(CalystoAjaxHandlerConstants.ScriptResourceRequest, true))
			{
				// allow both bot and non-bot
				// warning: google bot must be able to get css or js code
				// contains RX-SC in url
				return new WsjsClientProxyHandler();
			}
			else if (isBot)
			{
				// eg. google bot
				return new BotHandler();
			}

			////string dump = Calysto.Web.RequestDumper.GetRequestDump(context);
			////CalystoTools.ErrorSignal(new Exception(dump));

			return new NotFoundHandler();

			// requires full trust security:
			//return new System.Web.Services.Protocols.WebServiceHandlerFactory().GetHandler(context, requestType, url, pathTranslated);
		}

		public virtual void ReleaseHandler(IHttpHandler handler)
		{
		}
	}

	class BotHandler : IHttpHandler
	{
		public async Task ProcessRequestAsync(HttpContext context)
		{
			var headers = context.Response.GetTypedHeaders();
			headers.Expires = DateTime.Now.AddDays(-100);
			headers.CacheControl = new Microsoft.Net.Http.Headers.CacheControlHeaderValue() { NoStore = true, NoCache = true, Public = true };
			await context.Response.WriteAsync("hello");
		}
	}

	class NotFoundHandler : IHttpHandler
	{
		public async Task ProcessRequestAsync(HttpContext context)
		{
			var headers = context.Response.GetTypedHeaders();
			headers.Expires = DateTime.Now.AddDays(-100);
			headers.CacheControl = new Microsoft.Net.Http.Headers.CacheControlHeaderValue() { NoStore = true, NoCache = true, Public = true };
			context.Response.StatusCode = (int)System.Net.HttpStatusCode.NotFound; // 404 not found
			await Task.CompletedTask;
		}
	}


}
