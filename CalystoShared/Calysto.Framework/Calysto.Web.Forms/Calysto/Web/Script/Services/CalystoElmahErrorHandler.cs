using System;
using System.Web;
using System.IO;
using Calysto.Converter;
using Calysto.Serialization.Json;
using Calysto.Web.Hosting;

namespace Calysto.Web.Script.Services
{
	class CalystoJavascriptException : Exception
	{
		public CalystoJavascriptException(string msg)
			: base(msg)
		{ }

		public CalystoJavascriptException(string msg, Exception ex)
			: base(msg, ex)
		{ }
	}

	class CalystoElmahErrorHandler : IHttpHandler
	{
		public void ProcessRequest(HttpContext context)
		{
			try
			{
				if (context.Request.HttpMethod == "POST")
				{
					string str = new StreamReader(context.Request.InputStream).ReadToEnd();
					string json = CalystoBase64Encoder.Base64RndEncoder.DecodeBase64StringToString(str);
					CalystoJavaScriptException obj = JsonSerializer.Deserialize<CalystoJavaScriptException>(json);
					CalystoFormsHostingEnvironment.Current.NotifyJavaScriptError(this, () => obj);
				}
			}
			catch
			{
				// elmah is not available
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
