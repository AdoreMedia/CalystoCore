using System;
using System.Web;
using System.IO;
using Calysto.IO;
using System.Collections.Generic;
using Calysto.Utility;

namespace Calysto.Web.Script.Services
{
	class CalystoStaticFileHandler : IHttpHandler
	{
		static Dictionary<string, CalystoFileInfo> _dic = new Dictionary<string, CalystoFileInfo>();

		public void ProcessRequest(HttpContext context)
		{
			try
			{
				string url1 = context.Request.Path;
				// there may be more than one ~/, use the last part or url
				int index1 = context.Request.Path.LastIndexOf(CalystoAjaxHandlerConstants.StaticFileRequest);
				if (index1 > 0)
				{
					url1 = context.Request.Path.Substring(index1);
				}

				if (!_dic.TryGetValue(url1, out CalystoFileInfo fileInfo))
				{
					CalystoPhysicalPathHelper hh = new CalystoPhysicalPathHelper(url1);
					_dic[url1] = fileInfo = hh.FindFile();
				}
				SendResourceData(context, fileInfo);
			}
			catch
			{
				context.Response.Cache.VaryByParams["*"] = true;
				context.Response.Cache.SetExpires(DateTime.UtcNow.AddYears(-1));
				context.Response.StatusCode = (int) System.Net.HttpStatusCode.NotFound;
			}
			
		}

		private void SendResourceData(HttpContext context, CalystoFileInfo fileInfo)
		{
			string receiveETag = context.Request.Headers["If-None-Match"];
			receiveETag = CalystoTools.DequoteString(receiveETag);

			string etag = fileInfo.GetFileLastWriteTimeHash();

			if (!string.IsNullOrWhiteSpace(receiveETag) && receiveETag == etag)
			{
				context.Response.StatusCode = (int)System.Net.HttpStatusCode.NotModified;
				return;
			}

			string mime = MimeContentType.GetMime(Path.GetExtension(fileInfo.FilePath));
			if (string.IsNullOrWhiteSpace(mime))
			{
				throw new Exception("Unknown mime type for resource: " + fileInfo.FilePath);
			}

			context.Response.AppendHeader("content-type", mime);

			context.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(90)); // query string has timestamp, so don't worry about cache invalidation
			context.Response.Cache.VaryByParams["*"] = true; // required: * star says to the server to vary by both path and query string
			context.Response.Cache.SetOmitVaryStar(true); // * star says to browser to read from browser's cache first, without star, browser sends every request to the server
			context.Response.Cache.SetLastModified(DateTime.Now); // last modified is sent from browser as "If-Modified-Since" header key
			context.Response.Cache.SetCacheability(HttpCacheability.Private); // Public or ServerAndPrivate, otherwise it won't send eTag to the browser
			context.Response.Cache.SetETag(CalystoTools.QuoteString(etag)); // eTag is sent from browser as "If-None-Match", if user pushes F5, server returns 304 not modified if eTag matche
			context.Response.OutputStream.Write(fileInfo.FileBytes, 0, fileInfo.FileBytes.Length);
			context.Response.OutputStream.Flush();
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
