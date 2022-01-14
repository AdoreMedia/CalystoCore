using Calysto.AspNetCore.Mvc.Razor;
using Calysto.IO;
using Calysto.Linq;
using Calysto.Utility;
using Calysto.Web;
using Calysto.Web.Script.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace Calysto.AspNetCore.Middlewares
{
	public static class CalystoStaticFilesMiddlewareExtensions
	{
		public static void UseCalystoStaticFiles(this IApplicationBuilder app, Action<CalystoStaticFilesMiddleware.Settings> setup = null)
		{
			var obj1 = new CalystoStaticFilesMiddleware.Settings();
			setup.Invoke(obj1);
			app.UseMiddleware<CalystoStaticFilesMiddleware>(obj1);
		}
	}

	public class CalystoStaticFilesMiddleware
	{
		public class Settings
		{
			public HashSet<string> Extensions { get; } = new HashSet<string>(new string[] {
				".js", ".css", ".scss", ".less", ".map", ".ts", ".png", ".gif", ".jpg", ".ico", ".woff2", ".otf", ".eot", ".svg", ".woff", ".ttf"
			});

			public Action<HttpContext> PrepareHeaders;

			public Func<CalystoFileInfo, bool> DisallowCaching;

		}

		private readonly RequestDelegate _next;
		private readonly Settings _setting;

		public CalystoStaticFilesMiddleware(RequestDelegate next, Settings settings = null)
		{
			_next = next;
			_setting = settings ?? new Settings();
		}

		public async Task Invoke(HttpContext context)
		{
			string vpath1 = context.Request.GetVirtualPath();
			// there may be more than one ~/, use the last part or url
			int index1 = vpath1.LastIndexOf(CalystoAjaxHandlerConstants.StaticFileRequest);
			if(index1 > 0)
			{
				vpath1 = vpath1.Substring(index1);
			}

			if (!StaticFileCache.Cache.TryGetValue(vpath1, out CalystoFileInfo fileInfo))
			{
				string extension = Path.GetExtension(vpath1).ToLower();
				if (!_setting.Extensions.Contains(extension))
				{
					// not static file, move to next middleware
					await _next(context);
					return;
				}
				else
				{
					var helper1 = new CalystoPhysicalPathHelper(vpath1);

					fileInfo = helper1.FindFile(silentIfFileNotFound: true);

					if (fileInfo != null && _setting?.DisallowCaching?.Invoke(fileInfo) != true)
					{
						// add to cache
						// if file not found (fileInfo == null), add to cache too, but with short cache time duration
						fileInfo = StaticFileCache.Cache.GetOrCreate(vpath1, entry =>
						{
							entry.AbsoluteExpiration = fileInfo == null ? DateTime.Now.AddMinutes(1) : DateTime.Now.AddMinutes(60);
							return fileInfo;
						});
					}
				}
			}

			if(fileInfo != null)
			{
				string receiveETag = context.Request.Headers[HeaderNames.IfNoneMatch];
				receiveETag = CalystoTools.DequoteString(receiveETag);

				string fileHash = fileInfo.GetFileLastWriteTimeHash();

				if (!string.IsNullOrWhiteSpace(receiveETag) && receiveETag == fileHash)
				{
					context.Response.StatusCode = (int)System.Net.HttpStatusCode.NotModified;
				}
				else
				{
					var headers = context.Response.GetTypedHeaders();
					headers.Expires = DateTime.Now.AddDays(90);
					headers.CacheControl = new Microsoft.Net.Http.Headers.CacheControlHeaderValue() { Private = true, Public = true };
					// headers.Set(HeaderNames.Vary, "*"); // svaki put ide na server
					headers.LastModified = DateTime.Now;
					headers.ETag = new Microsoft.Net.Http.Headers.EntityTagHeaderValue(CalystoTools.QuoteString(fileHash));
					// send static content
					context.Response.ContentLength = fileInfo.FileBytes.Length;
					context.Response.ContentType = MimeContentType.GetMime(fileInfo.Extension);

					_setting?.PrepareHeaders?.Invoke(context);

					await context.Response.Body.WriteAsync(fileInfo.FileBytes, 0, fileInfo.FileBytes.Length);
					await context.Response.Body.FlushAsync();
				}
			}
			else
			{
				var headers = context.Response.GetTypedHeaders();
				headers.Expires = DateTime.Now;
				headers.CacheControl = new Microsoft.Net.Http.Headers.CacheControlHeaderValue() { Private = true, Public = true };

				context.Response.StatusCode = (int)System.Net.HttpStatusCode.NotFound;

				await context.Response.Body.FlushAsync();
			}
		}
	}
}
