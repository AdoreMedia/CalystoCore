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
using System.Reflection;
using Calysto.Web.UI;

namespace Calysto.Web.Script.Services
{
	public class CalystoAjaxHandlerMvc : CalystoAjaxHandlerBase
	{
		private HttpContext _httpContext;

		public CalystoAjaxHandlerMvc(HttpContext context)
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
			return await this.ProcessRequestAsync(null, astr, CalystoContextMvc.Current.Request, CalystoContextMvc.Current.Response);
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
						|| (ws = new WebServiceHelperMvc().GetCompiledTypeByVirtualPath(astr.serviceVirtualPath)) == null)
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
					// _httpContext = new DefaultHttpContext();
				}
				else if (_httpContext != null && _httpContext.WebSockets.IsWebSocketRequest)
				{
					// if isReloadRequired == true, ne moze vratiti HTTP response, nego treba pustiti da otvori socket, pa kroz socket vratit engine expired
					// otvoriti socket i ovaj thread mora ostati blokiran dok je socket otvoren, thread ce se osloboditi kad se socket zatvori
					// ako je isReloadRequired == true, ws moze biti null jer type mozda vise ne postoji
					new WebSocketServiceMvc(_httpContext, ws?.ServiceType, isReloadRequired).Start();
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
					// if web socket method is invoked, there is no httpContext
					string pageState = _httpContext.Request.Headers[WsjsHeaderConstants.XCalystoPageStateKey];
					if (!string.IsNullOrEmpty(pageState))
					{
						CalystoScriptManager.NotifyPageStateRestore(pageState);
					}
				}

				if (target == null && !methodData.MethodInfo.IsStatic)
				{
					target = CalystoActivator.CreateInstance(ws.ServiceType);
				}
			}
			catch (Exception ex)
			{
				CalystoHostingEnvironment.Current.NotifyException(nameof(CalystoAjaxHandlerMvc), () => ex);

				// let's client reload the page to download new versions of scripts
				return CreateVersionExpiredCommand();
			}

			try
			{
				// if webServicemethods return void, it actually returns null and null has to be sent to client to finish the request and to be able to use onSuccess(data) funcion.

				IDictionary<string, object> rawParams = astr.methodArguments ?? GetRawParams(_httpContext, methodData, request);

				// socket nema context
				if (_httpContext != null)
				{
					if (!string.IsNullOrEmpty(astr.pageVirtualPathAndQuery))
					{
						// now we have ajax request path and query in context, but we want to inject original page path and query:

						// split to path and query string
						string path1 = astr.pageVirtualPathAndQuery;
						string query1 = null;
						int index1 = astr.pageVirtualPathAndQuery.IndexOf("?");
						if (index1 > 0)
						{
							path1 = astr.pageVirtualPathAndQuery.Substring(0, index1);
							query1 = astr.pageVirtualPathAndQuery.Substring(index1);
						}

						if (_httpContext.Request.PathBase.HasValue)
						{
							if (path1.StartsWith(_httpContext.Request.PathBase.Value, StringComparison.OrdinalIgnoreCase))
							{
								path1 = path1.Substring(_httpContext.Request.PathBase.Value.Length);
							}
						}

						// setting QueryString will replace Request.Query values too
						_httpContext.Request.QueryString = new QueryString(query1);
						_httpContext.Request.Path = path1;
					}

					// when socketWebClient is used, HttpContext is reused, so reset context.Response.RedirectLocation before method invocation
					_httpContext.Response.Headers.Remove(HeaderNames.Location);

					if (target is Controller controller)
					{
						controller.ControllerContext.HttpContext = _httpContext;
					}
				}

				// test if user has permission to invoke method
				object resp;

				if (CalystoAuthorizationHelper.MayInvokeMethod(target, methodData.MethodInfo))
				{
					// invoke ajax method
					resp = methodData.CallMethodFromRawParams(target, rawParams, arg =>
					{
						// now we have rawParam conveted to real object
						if (arg is ICalystoMvcModelState item1)
						{
							// add state to response here, we have to generate response js which will remove previous errors from DOM, always
							response.AddJavaScript(() => item1.ToJavaScript());
						}
					});
				}
				else
				{
					CalystoHostingEnvironment.Current.NotifyException(nameof(CalystoAjaxHandlerMvc), () => new Exception($"Medhod {methodData.MethodInfo.Name} invocation forbidden."));
					// user has no permission to invoke method
					return response.ClearResponse().UseDirectUtility(a => a.SystemAlert(CalystoLang.MethodInvocationFobidden));
				}

				return await base.FinalizeResultAsync(response, resp, methodData.MethodInfo.ReturnType, () => _httpContext?.Response.Headers[HeaderNames.Location]);
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
					return base.CreateExceptionResponse(ex, response);
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

			if (context.Request.Method == "POST" && context.Request.Headers[WsjsHeaderConstants.XTypeHeaderKey] == WsjsHeaderConstants.XTypeHeaderBinaryFrameValue)
			{
				MemoryStream ms = new MemoryStream();
				context.Request.Body.CopyToAsync(ms).Wait();

				SerializerOptions opt1 = new SerializerOptions();
				var dic = BinaryFrame.Deserialize<IDictionary<string, object>>(ms.ToArray(), opt1);
				jsonStr = opt1.BFOutput.Json;
				blobs = opt1.BFOutput.Blobs;

				request.Diagnostic.CALYSTO_JSON_RECEIVED = jsonStr;
				request.Diagnostic.CALYSTO_BLOBS_COUNT = (blobs == null ? 0 : blobs.Count) + "";
				return dic;
			}
			else if (context.Request.Method == "GET")
			{
				// get request
				// post with single file upload, this is not used, functionality is disabled in Calysto.Net.WebService.js
				base64str = context.Request.Query[CalystoAjaxHandlerConstants.AjaxGetParamName];
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
				CalystoHostingEnvironment.Current.NotifyException(nameof(CalystoAjaxHandlerMvc), () => ex);

				throw ex;
			}
		}
	}
}

