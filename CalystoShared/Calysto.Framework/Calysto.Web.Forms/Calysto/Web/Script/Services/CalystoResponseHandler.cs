using System;
using System.Text;
using System.Linq;
using Calysto.Serialization.Json;
using System.Threading.Tasks;
using System.Web;

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
			await Task.CompletedTask;

			if (this._httpContext.Response.IsClientConnected)
			{
				// remove all filters
				Calysto.Web.Filter.ResponseFilterHelper.GetCurrent(_httpContext).RemoveAll();

				this._httpContext.Response.Clear();
				this._httpContext.Response.ClearContent();
				this._httpContext.Response.Cache.SetNoStore();
				this._httpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
				this._httpContext.Response.Cache.SetExpires(DateTime.Now.AddDays(-100));

				var crossdomainOrigin = _httpContext.Request.Headers.Get("Origin");

				if (!string.IsNullOrEmpty(crossdomainOrigin))
				{
					this._httpContext.Response.Headers.Set("Access-Control-Allow-Origin", crossdomainOrigin);
				}

				BinaryFrame bf = BinaryFrame.Serialize(resp.ToDictionaryCompiled());
				if (bf.Blobs?.Any() == true)
				{
					byte[] binaryData = bf.ToBinaryData();
					this._httpContext.Response.ContentType = "application/octet-stream";
					this._httpContext.Response.AddHeader(WsjsHeaderConstants.XTypeHeaderKey, WsjsHeaderConstants.XTypeHeaderBinaryFrameValue);
					this._httpContext.Response.AddHeader("Content-Length", binaryData.Length.ToString());
					this._httpContext.Response.BinaryWrite(binaryData);
					this._httpContext.Response.Flush();
					//context.Response.End(); // this throws exception
					return;
				}
				else
				{
					this._httpContext.Response.ContentType = "application/json; charset=utf-8"; // if BinaryWrite is used, add charset=utf-8, if .Write(string) is used, utf-8 is added by default

					if (bf.Json.Length > 5000)
					{
						// enable compression only if json.Length > 5000
						// if length is too small, eg, < 450 bytes, compressed size is greater than uncompressed!!!!
						//Calysto.Web.CalystoHttpCompressionFilter.AddCompressionFilter(this._httpContext);
						Calysto.Web.Filter.ResponseFilterHelper.GetCurrent(_httpContext).Apply(o => o.Compress = true);
					}

					// send json
					byte[] data = Encoding.UTF8.GetBytes(bf.Json);
					this._httpContext.Response.AddHeader("Content-Length", data != null ? data.Length.ToString() : "0");
					this._httpContext.Response.OutputStream.Write(data, 0, data.Length);
				}
			}
		}


	}
}

