using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Calysto.Serialization.Json;
using Calysto.Converter;
using Calysto.Serialization.Json.Core.Serialization;
using Calysto.Utility;
using Calysto.Resources;
using System.Threading.Tasks;
using Calysto.Web.UI.Direct;
using Calysto.Common.Extensions;
using Calysto.Web.Hosting;
using System.Web;
using System.Text;
using System.Reflection;
using Calysto.Web.Script.Services.WebSockets;
using Calysto.Web.Script.Services.Compiler;
using Calysto.Web.UI;

namespace Calysto.Web.Script.Services
{
	public class CalystoAjaxHandlerForms : CalystoAjaxHandlerBase
	{
		private static FieldInfo _rawUrlFieldInfo = typeof(HttpRequest).GetField("_rawUrl", BindingFlags.Instance | BindingFlags.NonPublic);

		private HttpContext _httpContext;

		public CalystoAjaxHandlerForms(HttpContext context)
		{
			_httpContext = context;
		}

		private CalystoResponse CreateVersionExpiredCommand()
		{
			return new CalystoResponse().SetEngineExpired();
		}

		internal async Task<CalystoResponse> ProcessRequestAsync(AjaxQueryStringHelper astr)
		{
			// string timestampRawString, HttpContext context, string serviceVirtualPath, string methodName, string currentVirtualPath)
			return await this.ProcessRequestAsync(null, astr, CalystoContextForms.Current.Request, CalystoContextForms.Current.Response);
		}

		/// <summary>
		/// vraca null, new CalystoResponse() ili CalystoContext.Current.Response
		/// </summary>
		/// <param name="astr"></param>
		/// <returns></returns>
		internal async Task<CalystoResponse> ProcessRequestAsync(object target, AjaxQueryStringHelper astr, CalystoRequest request, CalystoResponse response)
		{
			await Task.CompletedTask;

			if (string.IsNullOrEmpty(astr.methodName))
			{
				throw new InvalidOperationException("WebService_InvalidWebServiceCall");
			}

			// make sure we have correct culture applied since we're in new thread/task
			astr.ApplyCurrentCulture();

			request.Diagnostic.CALYSTO_SERVICE_VPATH = astr.serviceVirtualPath;
			request.Diagnostic.CALYSTO_SERVICE_METHOD = astr.methodName;

			WebServiceMethodData methodData = null;
			WebServiceInfo ws = null;

			bool isReloadRequired = false;

			try
			{
				// this is critical: if app was precompiled, aspx or ascx type name has changed, so this will throw exception
				// if method doesn't exist, it will throw exception and send js to reload client window

				try
				{
					// if type doesn't exists, exception is thrown

					if (string.IsNullOrEmpty(astr.timestampRawString)
						|| CalystoPhysicalPaths.Current.AssembliesSignature != astr.timestampRawString
						|| (ws = new WebServiceHelperForms().GetCompiledTypeByVirtualPath(astr.serviceVirtualPath)) == null)
					{
						isReloadRequired = true;
					}
				}
				catch
				{
					isReloadRequired = true;
				}

				if (astr.isSocketWebClient)
				{
					// ok
					// this won't work since it doesn't know how to translate ~/ into physical path
					HttpRequest req = new HttpRequest("dummy.file.aspx", "http://dummy.file.aspx", "");
					StringWriter sw = new StringWriter();
					HttpResponse resp = new HttpResponse(sw);
				}
				else if (_httpContext != null && _httpContext.IsWebSocketRequest)
				{
					// if isReloadRequired == true, ne moze vratiti HTTP response, nego treba pustiti da otvori socket, pa kroz socket vratit engine expired
					new WebSocketServiceForms(_httpContext, ws?.ServiceType, isReloadRequired).Start();
					return null;
				}
				else if (isReloadRequired)
				{
					return CreateVersionExpiredCommand();
				}

				methodData = WebServiceMethodData.GetMethodData(ws.ServiceType, astr.methodName);

				request.Diagnostic.CALYSTO_FULLMETHOD = methodData.FullMethodString;

				// restore page state before target instance is created
				if (_httpContext != null)
				{
					// if socket method is invoked, there is no httpContext
					string pageState = _httpContext.Request.Headers[WsjsHeaderConstants.XCalystoPageStateKey];
					if (!string.IsNullOrEmpty(pageState))
					{
						CalystoScriptManager.NotifyPageStateRestore(pageState);
					}
				}

				if (target == null && !methodData.MethodInfo.IsStatic)
				{
					if (typeof(System.Web.UI.Page).IsAssignableFrom(ws.ServiceType))
					{
						target = new CompiledPageHelper(_httpContext).LoadPage<System.Web.UI.Page>(ws.ServiceType);
					}
					else if (typeof(System.Web.UI.UserControl).IsAssignableFrom(ws.ServiceType))
					{
						// works with MasterPage too
						target = new CompiledPageHelper(_httpContext).LoadControl<System.Web.UI.UserControl>(ws.ServiceType);
					}
					else
					{
						target = CalystoActivator.CreateInstance(ws.ServiceType);
					}
				}
			}
			catch (Exception ex)
			{
				CalystoHostingEnvironment.Current.NotifyException(nameof(CalystoAjaxHandlerForms), () => ex);

				// let's client reload the page to download new versions of scripts
				return CreateVersionExpiredCommand();
			}

			try
			{
				IDictionary<string, object> rawParams = astr.methodArguments ?? GetRawParams(_httpContext, methodData, request);

				// socket nema context
				if (_httpContext != null)
				{
					if (!string.IsNullOrEmpty(astr.pageVirtualPathAndQuery))
					{
						_rawUrlFieldInfo.SetValue(_httpContext.Request, astr.pageVirtualPathAndQuery); // set RawUrl
																									   // if currentLocation doesn't have query string, RewritePath will keep previous query string
																									   // if currentLocation has query string, RewritePath will use new query string currentLocation vpath replacing old query string
																									   // so, we have to remove old query string for sure
						_httpContext.RewritePath("/", "", ""); // to remove query string from context.Request.Url, use empty string "", beause null will not remove query string
						_httpContext.RewritePath(astr.pageVirtualPathAndQuery); // so that Request.QueryString may be used in aspx pages
					}

					// when socketWebClient is used, HttpContext is reused, so reset context.Response.RedirectLocation before method invocation
					_httpContext.Response.RedirectLocation = null;
				}

				// INVOKE METHOD
				object resp = methodData.CallMethodFromRawParams(target, rawParams, arg =>
				{
					// now we have rawParam conveted to real object
					if (arg is ICalystoMvcModelState item1)
					{
						// add state to response here, we have to generate response js which will remove previous errors from DOM, always
						response.AddJavaScript(() => item1.ToJavaScript());
					}
				});

				return await base.FinalizeResultAsync(response, resp, methodData.MethodInfo.ReturnType, () => _httpContext?.Response.RedirectLocation);
			}
			catch (Exception ex)
			{
				if (ex is ThreadAbortException)
				{
					// request ended with CalystoResponse.Current.EndResponse() or Response.End()
					// .Current response may be empty, but still has to be used this way, do not throw exception
					return response;
				}
				else
				{
					// unhandled exception or CalystoWebServiceResponse exception which is not exception, but custom message or something
					return CreateExceptionResponse(ex, response);
				}
			}
		}

		/// <summary>
		/// decode  base64 and deserialize from json
		/// </summary>
		/// <param name="context"></param>
		/// <param name="serializer"></param>
		/// <returns></returns>
		private IDictionary<string, object> GetRawParams(HttpContext context, WebServiceMethodData methodData, CalystoRequest request)
		{
			string base64str = null;
			List<CalystoBlob> blobs = null;
			string jsonStr = null;

			if (context.Request.HttpMethod == "POST" && context.Request.Headers[WsjsHeaderConstants.XTypeHeaderKey] == WsjsHeaderConstants.XTypeHeaderBinaryFrameValue)
			{
				MemoryStream ms = new MemoryStream();
				context.Request.InputStream.CopyTo(ms);

				SerializerOptions opt1 = new SerializerOptions();
				var dic = BinaryFrame.Deserialize<IDictionary<string, object>>(ms.ToArray(), opt1);
				jsonStr = opt1.BFOutput.Json;
				blobs = opt1.BFOutput.Blobs;

				request.Diagnostic.CALYSTO_JSON_RECEIVED = jsonStr;
				request.Diagnostic.CALYSTO_BLOBS_COUNT = (blobs == null ? 0 : blobs.Count) + "";
				return dic;
			}
			else if (context.Request.HttpMethod == "GET")
			{
				// get request
				// post with single file upload, this is not used, functionality is disabled in Calysto.Net.WebService.js
				base64str = context.Request.QueryString[CalystoAjaxHandlerConstants.AjaxGetParamName];
			}
			else
			{
				throw new NotSupportedException();
			}

			if (string.IsNullOrEmpty(base64str))
			{
				return new Dictionary<string, object>();
			}

			try
			{
				jsonStr = CalystoBase64Encoder.Base64RndEncoder.DecodeBase64StringToString(base64str);

				// for debugging, this way it will be written to Elmah in case of exception
				request.Diagnostic.CALYSTO_JSON_RECEIVED = jsonStr;
				request.Diagnostic.CALYSTO_BLOBS_COUNT = (blobs == null ? 0 : blobs.Count) + "";

				IDictionary<string, object> dic = JsonSerializer.Deserialize<IDictionary<string, object>>(jsonStr);
				return dic;
			}
			catch (Exception ex)
			{
				CalystoHostingEnvironment.Current.NotifyException(nameof(CalystoAjaxHandlerForms), () => ex);

				throw ex;
			}
		}

		protected override CalystoResponse CreateExceptionResponse(Exception ex, CalystoResponse response)
		{
			if (_httpContext != null)
				_httpContext.Response.TrySkipIisCustomErrors = true;

			return base.CreateExceptionResponse(ex, response);
		}
	}
}
