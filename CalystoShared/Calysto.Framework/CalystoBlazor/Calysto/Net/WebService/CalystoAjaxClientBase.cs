using Calysto.CCFServices.Transport.Http;
using Calysto.Converter;
using Calysto.Web.Script.Services;
using Calysto.Blazor.Utility;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Calysto.Net.WebService
{
	public class CalystoAjaxClientBase : HttpTransportClient
	{
		BrowserContext _browser;

		public CalystoAjaxClientBase(BrowserContext browser, string urlPathAndQuery) : base(urlPathAndQuery)
		{
			_browser = browser;
		}

		public override Task BeforeRequestSentAsync(HttpRequestMessage request)
		{
			request.Headers.Add(WsjsHeaderConstants.XAjaxHeaderKey, WsjsHeaderConstants.XAjaxHeaderValue);

			return base.BeforeRequestSentAsync(request);
		}

		public override Task HeadersReceivedAsync(HttpResponseMessage response)
		{
			return base.HeadersReceivedAsync(response);
		}

		private string _serverVersion;

		public async Task<TResult> MakeRequestAsync<TResult>(CalystoWebMethodAttribute attr, string methodName, object args)
		{
			var binaryFrame = Calysto.Serialization.Json.BinaryFrame.Serialize(args);
			string jsonArg = null;
			byte[] data = null;
			Action<HttpClient, HttpRequestMessage> fnBeforeRequest = null;

			if (binaryFrame.Blobs?.Any() == true || binaryFrame.Json?.Length > 1000)
			{
				data = binaryFrame.ToBinaryData();
				fnBeforeRequest = new Action<HttpClient, HttpRequestMessage>((client, request) =>
				{
					if(attr.Timeout > 0)
					{
						client.Timeout = TimeSpan.FromMilliseconds(attr.Timeout);
					}
					
					request.Headers.Add(WsjsHeaderConstants.XTypeHeaderKey, WsjsHeaderConstants.XTypeHeaderBinaryFrameValue);
				});
			}
			else
			{
				var enc = CalystoBase64Encoder.Base64RndEncoder.EncodeToBase64String(binaryFrame.Json);
				jsonArg = $"&" + CalystoAjaxHandlerConstants.AjaxGetParamName + "=" + enc;
			}

			if (_serverVersion == null)
			{
				_serverVersion = await _browser.GetServerVersionFromHtmlAsync();
			}

			string url = _browser.HostEnvironment.BaseAddress?.TrimEnd('/')
				+ this.Url.Replace("__calysto_method_name__", methodName)
				.Replace("__calysto_culture__", System.Globalization.CultureInfo.CurrentCulture.Name)
				.Replace("__calysto_ss__", attr.SessionState ? "1" : "0")
				.Replace("__calysto_current_url__", "")
				.Replace("__calysto_json_arg__", jsonArg)
				+ _serverVersion;

			var respTuple = await base.UploadDataAsync(data, url, fnBeforeRequest);
			var contentType = respTuple.Response.Content.Headers.ContentType?.MediaType ?? "unknown";
			if (contentType.Contains("application/octet-stream"))
			{
				var resp2 = Calysto.Serialization.Json.BinaryFrame.Deserialize<WebServiceResponseContainer>(respTuple.Data);
				return await ProcessResponseAsync<TResult>(resp2);
			}
			else if (contentType.Contains("application/json"))
			{
				string json = Encoding.UTF8.GetString(respTuple.Data);
				var resp2 = Calysto.Serialization.Json.JsonSerializer.Deserialize<WebServiceResponseContainer>(json);
				return await ProcessResponseAsync<TResult>(resp2);
			}
			else
			{
				throw new NotSupportedException("ContentType: " + contentType);
			}
		}

		private async Task<TResult> ProcessResponseAsync<TResult>(WebServiceResponseContainer container)
		{
			if(container.Type != nameof(IWebServiceResponseContainer))
			{
				throw new InvalidOperationException(container.Type);
			}

			if (container.IsEngineExpired)
			{
				await _browser.LocationReloadAsync();
				return default;
			}

			if (!string.IsNullOrEmpty(container.JavaScriptLO))
			{
				await _browser.ExecuteScriptVoidAsync(container.JavaScriptLO);
			}

			if (container.IsSuccessful)
			{
				return Calysto.Serialization.Json.JsonSerializer.ConvertToType<TResult>(container.ReturnedValue);
			}
			else if (!string.IsNullOrEmpty(container.ExceptionMessage))
			{
				await _browser.SystemAlertAsync(container.ExceptionMessage + "\r\n" + container.ExceptionDetails);
			}

			return default;
		}

		public Task MakeRequestAsync(CalystoWebMethodAttribute attr, string methodName, object args)
		{
			return this.MakeRequestAsync<object>(attr, methodName, args);
		}

		public TResult MakeRequest<TResult>(CalystoWebMethodAttribute attr, string methodName, object args)
		{
			return this.MakeRequestAsync<TResult>(attr, methodName, args).Result;
		}
	}
}
