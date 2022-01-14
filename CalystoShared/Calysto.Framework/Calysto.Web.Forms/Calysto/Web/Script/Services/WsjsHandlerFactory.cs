using Calysto.Common;
using System;
using System.Web;
using Calysto.Common.Extensions;

namespace Calysto.Web.Script.Services
{
	class WsjsHandlerFactory : IHttpHandlerFactory
	{
		public virtual IHttpHandler GetHandler(HttpContext context, string requestType, string url, string pathTranslated)
		{
			if (context == null)
			{
				throw new ArgumentNullException("context is null");
			}

			// warning:
			// - inside JSON there can be RX-SC, so check for query string variables frist
			// - google bot has to be able to read css or js, but don't allow page request to web service or exception report

			string ua = context.Request.UserAgent ?? "";
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
					&& !string.IsNullOrEmpty(context.Request.QueryString[WsjsTypeHandlerConstants.WebMethod]) 
					&& path.Contains(CalystoAjaxHandlerConstants.TypeServiceRequest, true)
				)
				||
				(!isBot
					&& !string.IsNullOrEmpty(context.Request.Headers["Sec-WebSocket-Key"]) 
					&& context.IsWebSocketRequest)
				)
			{
				// test for x-rx-ajax header to avoid request from spiders
				// accepts cross-domain requests, but crossdomain request can't add custom headers
				// WebMethod request
				if (AjaxQueryStringHelperForms.UseSessionState(context))
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
		public void ProcessRequest(HttpContext context)
		{
			context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
			context.Response.Cache.SetExpires(DateTime.Now.AddDays(-100));

			context.Response.Write("[hello]");
		}

		public bool IsReusable { get { return true; } }
	}

	class NotFoundHandler : IHttpHandler
	{
		public void ProcessRequest(HttpContext context)
		{
			context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
			context.Response.Cache.SetExpires(DateTime.Now.AddDays(-100));

			context.Response.StatusCode = (int)System.Net.HttpStatusCode.NotFound; // 404 not found
		}

		public bool IsReusable { get { return true; } }
	}


}
