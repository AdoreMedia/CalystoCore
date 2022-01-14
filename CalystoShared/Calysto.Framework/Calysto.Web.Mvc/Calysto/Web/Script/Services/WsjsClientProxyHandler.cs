using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Calysto.Converter;
using Microsoft.AspNetCore.Http;
using Calysto.Utility;
using Calysto.Web.Script.Services.Compiler;
using Calysto.IO;
using System.Threading.Tasks;
using Calysto.Web.Hosting;
using static Calysto.Web.Script.Services.Compiler.FileCompilerResult;
using Calysto.Extensions;
using System.Text;

namespace Calysto.Web.Script.Services
{
	class WsjsClientProxyHandler : IHttpHandler
	{
		public class ResourceData
		{
			public string FileName;
			public byte[] Data;
			public string ETag;
			public DateTime LastModified;
		}

		private async Task SendResourceDataAsync(HttpContext context, ResourceData resource)
		{
			string receiveETag = context.Request.Headers[Microsoft.Net.Http.Headers.HeaderNames.IfNoneMatch];
			receiveETag = CalystoTools.DequoteString(receiveETag);

			if (!string.IsNullOrWhiteSpace(receiveETag) && receiveETag == resource.ETag)
			{
				context.Response.StatusCode = (int)System.Net.HttpStatusCode.NotModified;
				await Task.CompletedTask;
				return;
			}

			string mime = MimeContentType.GetMime(Path.GetExtension(resource.FileName));
			if (string.IsNullOrWhiteSpace(mime))
			{
				throw new Exception("Unknown mime type for resource: " + resource.FileName);
			}

			var headers = context.Response.GetTypedHeaders();
			headers.Expires = DateTime.Now.AddDays(90);
			headers.LastModified = resource.LastModified;
			headers.CacheControl = new Microsoft.Net.Http.Headers.CacheControlHeaderValue() { Private = true };
			headers.ETag = new Microsoft.Net.Http.Headers.EntityTagHeaderValue(CalystoTools.QuoteString(resource.ETag));

			context.Response.ContentType = mime;

			await context.Response.Body.WriteAsync(resource.Data, 0, resource.Data.Length);
			await context.Response.Body.FlushAsync();
		}

		private CompressedContent GetcompressedContent(FileCompilerResult script)
		{
			var encs = CalystoMvcHostingEnvironment.Current.BrowserCompression;
			var dic1 = script.GetCompressedContents();
			// get the first one which is supported by the browser
			foreach (var kv in dic1)
			{
				if (encs.IsSupported(kv.Key))
				{
					return kv.Value;
				}
			}
			return dic1[BrowserCompression.KindName.None];
		}

		private async Task WriteCachedScriptContentAsync(HttpContext context, FileCompilerResult script)
		{
			CalystoContextMvc.Current.ResponseFilter.DisableAll().Lock();

			var cc = this.GetcompressedContent(script);

			context.Response.ContentType = (script.IsCSS ? "text/css" : "application/x-javascript") + ";charset=utf-8;";

			if (cc.ContentEncoding != BrowserCompression.KindName.None)
			{
				context.Response.Headers["Content-Encoding"] = cc.ContentEncoding.GetStringValue();
			}
			context.Response.ContentLength = cc.SciptDataLength;

			await context.Response.Body.WriteAsync(cc.ScriptData, 0, cc.SciptDataLength);
			await context.Response.Body.FlushAsync();
		}

		public async Task ProcessRequestAsync(HttpContext context)
		{
			//context.Response.Clear();
			//context.Response.Headers.Clear();

			string receivedETag = context.Request.Query[CalystoAjaxHandlerConstants.QueryStringEtagKey];

			// do not use compression here, script is already compressed, resources should not be compressed
			CalystoContextMvc.Current.ResponseFilter.DisableAll().Lock();

			//context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] = new string[] { "Accept-Encoding" };
			var headers = context.Response.GetTypedHeaders();

			FileCompilerResult script;

			if (string.IsNullOrWhiteSpace(receivedETag) || (script = ScriptsBundleCache.GetCompilerResultByETag(receivedETag)) == null)
			{
				headers.Expires = DateTime.Now.AddYears(-1);
				//poslati js za reloadiranje stranice, ali ne cesce od x sekundi
				byte[] data1 = Encoding.UTF8.GetBytes(ServiceResponseJavaScripts.ResponseJsIfContentScriptNotFound(30));
				await context.Response.Body.WriteAsync(data1, 0, data1.Length);
				await context.Response.Body.FlushAsync();
				return;
			}
			else // script != null
			{
				string receiveETag = context.Request.Headers[Microsoft.Net.Http.Headers.HeaderNames.IfNoneMatch];
				receiveETag = CalystoTools.DequoteString(receiveETag);

				if (!string.IsNullOrWhiteSpace(receiveETag) && receiveETag == script.ETag)
				{
					context.Response.StatusCode = (int)System.Net.HttpStatusCode.NotModified;
					return;
				}

				//if (key.ETag != script.ETag)
				//{
				//	// iako ovo nema smisla ako se ukljucuje ApplicationTimestampString u ControlPathKey
				//	// ako browser ima stari file u cacheu (stari ETag u query stringu)
				//	headers.Location = new Uri(script.Url);
				//	context.Response.StatusCode = (int)System.Net.HttpStatusCode.Redirect; // 302
				//	headers.Expires = DateTime.UtcNow.AddDays(-10);
				//	headers.CacheControl = new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
				//	{
				//		Public = true,
				//		NoStore = true,
				//		NoCache = true
				//	};
				//	////return; // don't return here, send new content for browsers which doesn't read 301 redirect
				//}

				headers.Expires = DateTime.Now.AddDays(90);
				headers.LastModified = script.LastModified;
				headers.CacheControl = new Microsoft.Net.Http.Headers.CacheControlHeaderValue() { Private = true };
				//headers.CacheControl.MustRevalidate = true;
				//context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] = new string[] { "Accept-Encoding" };
				headers.ETag = new Microsoft.Net.Http.Headers.EntityTagHeaderValue(CalystoTools.QuoteString(script.ETag));

				if (script.IsCSS)
				{
					context.Response.ContentType = "text/css; charset=utf-8;";
				}
				else
				{
					context.Response.ContentType = "application/x-javascript; charset=utf-8;";
				}

				// script items are ordered by length asc, so use first available
				await this.WriteCachedScriptContentAsync(context, script);

			}
		}


	}
}
