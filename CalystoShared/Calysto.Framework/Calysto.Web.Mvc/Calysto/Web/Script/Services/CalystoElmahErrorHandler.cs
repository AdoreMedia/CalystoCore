using System.IO;
using Calysto.Converter;
using Calysto.Serialization.Json;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Calysto.Web.Hosting;

namespace Calysto.Web.Script.Services
{
	class CalystoElmahErrorHandler : IHttpHandler
	{
		public async Task ProcessRequestAsync(HttpContext context)
		{
			try
			{
				if (context.Request.Method == "POST")
				{
					string str = await new StreamReader(context.Request.Body).ReadToEndAsync();
					string json = CalystoBase64Encoder.Base64RndEncoder.DecodeBase64StringToString(str);
					CalystoJavaScriptException obj = JsonSerializer.Deserialize<CalystoJavaScriptException>(json);
					CalystoMvcHostingEnvironment.Current.NotifyJavaScriptError(this, () => obj);
				}
			}
			catch
			{
				// elmah is not available
			}
		}

	}
}
