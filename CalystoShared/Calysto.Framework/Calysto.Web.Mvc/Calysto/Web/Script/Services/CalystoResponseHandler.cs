using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading;
using Calysto.Serialization.Json;
using Calysto.Converter;
using Calysto.Serialization.Json.Core.Serialization;
using Microsoft.AspNetCore.Http;
using Calysto.Utility;
using Microsoft.Net.Http.Headers;
using Calysto.AspNetCore.Authorization.Utility;
using Calysto.Resources;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Calysto.Web.Script.Services.WebSockets;
using Calysto.Web.UI.Direct;
using Calysto.Common.Extensions;
using Calysto.Web.Hosting;

namespace Calysto.Web.Script.Services
{
	public class CalystoResponseHandler
	{
		private HttpContext _httpContext;

		public CalystoResponseHandler(HttpContext context)
		{
			_httpContext = context;
		}

		public async Task FlushResponseAsync(CalystoResponse resp)
		{
			// remove all filters
			CalystoContextMvc.Current.ResponseFilter.RemoveAll();

			// do not clear response, we may have headers or cookies set, 
			// when logged in in controller there is cookie already written to response
			// and we want to send calysto response, just append headers
			// _httpContext.Response.Clear();

			var headers = _httpContext.Response.GetTypedHeaders();
			headers.CacheControl = new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
			{
				Public = true,
				NoStore = true,
				NoCache = true
			};
			headers.Expires = DateTime.Now.AddDays(-100);

			string crossdomainOrigin = _httpContext.Request.Headers[HeaderNames.Origin];

			if (!string.IsNullOrEmpty(crossdomainOrigin))
			{
				_httpContext.Response.Headers[HeaderNames.AccessControlAllowOrigin] = crossdomainOrigin;
			}

			_httpContext.Response.Headers[WsjsHeaderConstants.XCalystoResponseContainerKey] = WsjsHeaderConstants.XCalystoResponseContainerValue;

			BinaryFrame bf = BinaryFrame.Serialize(resp.ToDictionaryCompiled());
			if (bf.Blobs?.Any() == true)
			{
				byte[] binaryData = bf.ToBinaryData();
				_httpContext.Response.ContentType = "application/octet-stream";
				_httpContext.Response.Headers[WsjsHeaderConstants.XTypeHeaderKey] = WsjsHeaderConstants.XTypeHeaderBinaryFrameValue;

				int length1 = binaryData.Length;
				_httpContext.Response.Headers[HeaderNames.ContentLength] = length1.ToString();

				await _httpContext.Response.Body.WriteAsync(binaryData, 0, length1);
				await _httpContext.Response.Body.FlushAsync();
			}
			else
			{
				// if BinaryWrite is used, add charset=utf-8, if .Write(string) is used, utf-8 is added by default
				_httpContext.Response.ContentType = "application/json; charset=utf-8"; 

				if (bf.Json.Length > 5000)
				{
					// enable compression only if json.Length > 5000
					// if length is too small, eg, < 450 bytes, compressed size is greater than uncompressed!!!!
					//Calysto.Web.CalystoHttpCompressionFilter.AddCompressionFilter(context);
					CalystoContextMvc.Current.ResponseFilter.Apply(o => o.Compress = true);
				}

				// send json
				byte[] data = Encoding.UTF8.GetBytes(bf.Json);
				int length2 = data?.Length ?? 0;
				_httpContext.Response.Headers[HeaderNames.ContentLength] = length2.ToString();
				if (length2 > 0)
				{
					await _httpContext.Response.Body.WriteAsync(data, 0, length2);
				}
				await _httpContext.Response.Body.FlushAsync();
			}

		}


	}
}

