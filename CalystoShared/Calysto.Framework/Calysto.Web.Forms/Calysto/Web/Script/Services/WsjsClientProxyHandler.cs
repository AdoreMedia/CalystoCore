using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Web;
using Calysto.Extensions;
using Calysto.Converter;
using Calysto.Utility;
using Calysto.IO;
using Calysto.Web.Script.Services.Compiler;
using System.Threading.Tasks;
using static Calysto.Web.Script.Services.Compiler.FileCompilerResult;
using Calysto.Web.Hosting;
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

		private void SendResourceData(HttpContext context, ResourceData resource)
		{
			string receiveETag = context.Request.Headers["If-None-Match"];
			receiveETag = CalystoTools.DequoteString(receiveETag);

			if (!string.IsNullOrWhiteSpace(receiveETag) && receiveETag == resource.ETag)
			{
				context.Response.StatusCode = (int)System.Net.HttpStatusCode.NotModified;
				return;
			}

			string mime = MimeContentType.GetMime(Path.GetExtension(resource.FileName));
			if (string.IsNullOrWhiteSpace(mime))
			{
				throw new Exception("Unknown mime type for resource: " + resource.FileName);
			}

			context.Response.AppendHeader("content-type", mime);

			context.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(90)); // query string has timestamp, so don't worry about cache invalidation
			context.Response.Cache.VaryByParams["*"] = true; // required: * star says to the server to vary by both path and query string
			context.Response.Cache.SetOmitVaryStar(true); // * star says to browser to read from browser's cache first, without star, browser sends every request to the server
			context.Response.Cache.SetLastModified(resource.LastModified); // last modified is sent from browser as "If-Modified-Since" header key
			context.Response.Cache.SetCacheability(HttpCacheability.Private); // Public or ServerAndPrivate, otherwise it won't send eTag to the browser
			context.Response.Cache.SetETag(CalystoTools.QuoteString(resource.ETag)); // eTag is sent from browser as "If-None-Match", if user pushes F5, server returns 304 not modified if eTag matche
			context.Response.OutputStream.Write(resource.Data, 0, resource.Data.Length);
			context.Response.OutputStream.Flush();
		}

		private CompressedContent GetcompressedContent(FileCompilerResult script)
		{
			var encs = CalystoFormsHostingEnvironment.Current.BrowserCompression;
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

		private void WriteCachedScriptContent(HttpContext context, FileCompilerResult script)
		{
			Calysto.Web.Filter.ResponseFilterHelper.GetCurrent(context).DisableAll().Lock();

			var cc = GetcompressedContent(script);

			context.Response.ContentType = (script.IsCSS ? "text/css" : "application/x-javascript") + ";charset=utf-8;";

			if (cc.ContentEncoding != BrowserCompression.KindName.None)
			{
				context.Response.AppendHeader("Content-Encoding", cc.ContentEncoding.GetStringValue());
			}

			context.Response.OutputStream.Write(cc.ScriptData, 0, cc.SciptDataLength);
		}

		public void ProcessRequest(HttpContext context)
		{
			context.Response.Clear();
			context.Response.ClearHeaders();

			string receivedETag = context.Request.QueryString[CalystoAjaxHandlerConstants.QueryStringEtagKey];

			FileCompilerResult script;

			// do not use compression here, script is already compressed, resources should not be compressed
			Calysto.Web.Filter.ResponseFilterHelper.GetCurrent(context).DisableAll().Lock();

			if (string.IsNullOrEmpty(receivedETag) || (script = ScriptsBundleCache.GetCompilerResultByETag(receivedETag)) == null)
			{
				context.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-10));
				context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
				context.Response.Cache.SetNoStore();
				//poslati js za reloadiranje stranice, ali ne cesce od x sekundi
				byte[] data1 = Encoding.UTF8.GetBytes(ServiceResponseJavaScripts.ResponseJsIfContentScriptNotFound(30));
				context.Response.OutputStream.Write(data1, 0, data1.Length);
				return;
			}
			else // script != null
			{
				////if (!CalystoScriptManager.IsDebugDefined)
				{
					string receiveETag = context.Request.Headers["If-None-Match"];
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
					//	context.Response.RedirectLocation = script.Url;
					//	context.Response.StatusCode = (int)System.Net.HttpStatusCode.Redirect; // 302
					//	context.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-10));
					//	context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
					//	context.Response.Cache.SetNoStore();
					//	////return; // don't return here, send new content for browsers which doesn't read 301 redirect
					//}
				}

				context.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(90)); // query string has timestamp, so don't worry about cache invalidation
				context.Response.Cache.VaryByParams["*"] = true; // required: * star says to the server to vary by both path and query string
				context.Response.Cache.SetOmitVaryStar(true); // * star says to browser to read from browser's cache first, without star, browser sends every request to the server
				context.Response.Cache.SetLastModified(script.LastModified); // last modified is sent from browser as "If-Modified-Since" header key
				context.Response.Cache.SetCacheability(HttpCacheability.Private); // Public or ServerAndPrivate, otherwise it won't send eTag to the browser
				context.Response.Cache.SetETag(CalystoTools.QuoteString(script.ETag)); // eTag is sent from browser as "If-None-Match", if user pushes F5, server returns 304 not modified if eTag matche

				if (script.IsCSS)
				{
					context.Response.ContentType = "text/css; charset=utf-8";
				}
				else
				{
					context.Response.ContentType = "application/x-javascript; charset=utf-8";
				}

				// script items are ordered by length asc, so use first available
				this.WriteCachedScriptContent(context, script);

			}
		}

		public bool IsReusable
		{
			get
			{
				return false;
			}
		}



	}
}
