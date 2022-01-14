using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;
using Calysto.Web.Script.Services.WebSockets;
using Calysto.Linq;
using Calysto.Converter;
using System.Collections.Concurrent;
using Calysto.Utility;

namespace Calysto.Web.Script.Services
{
	public class WebServiceSettings
	{
		/// <summary>
		/// C# method name
		/// </summary>
		public string method { get; set; }

		/// <summary>
		/// if true, method may be invoked only on user event on client 
		/// </summary>
		public bool? reque { get; set; }

		/// <summary>
		/// if true, will always use POST to send data to server
		/// </summary>
		public bool? post { get; set; }

		/////// <summary>
		/////// use socket, default false
		/////// </summary>
		////public bool? useSocket { get; set; }

		/////// <summary>
		/////// create shared socket and make ajax requests via shared socket
		/////// </summary>
		////public bool? ajaxSocket { get; set; }

		/// <summary>
		/// ms, default 90000
		/// </summary>
		public int? timeoutMs { get; set; }

		/// <summary>
		/// use asp.net session state
		/// </summary>
		public bool? sstate { get; set; }

		/// <summary>
		/// If true, will not count ajax request and none of events connected with count will not be invoked (Calysto.Page.OnLoading, Calysto.Page.OnBeginRequest, Calysto.Page.OnEndRequest).
		/// </summary>
		public bool? silent { get; set; }

		/// <summary>
		/// method arguments names: ["arg1", "arg2", etc]
		/// </summary>
		public string[] argNames { get; set; }

		private static PropertyInfo[] _props;
		private static PropertyInfo[] GetPropertiesCached() => _props ?? (_props = typeof(WebServiceSettings).GetProperties());

		public Dictionary<string, object> ToDictionary()
		{
			return GetPropertiesCached().ToDictionary(o => o.Name, o => o.GetValue(this)).Where(o => o.Value != null).ToDictionary(o => o.Key, o => o.Value);
		}
	}

	public class WebServiceInfo
	{
		public Type ServiceType;
		public string ServiceVirtualPath;
	}

	public class WebServiceDef
	{
		public bool IsWebSocketService { get; internal set; }
		public string TypeScriptNamespace { get; internal set; }
		public string VirtualServerUlrEncoded { get; internal set; }
		public string AbsoluteServerUrl { get; internal set; }
		internal List<WebServiceMethodData> Methods { get; set; }
	}

	internal abstract class WebServiceHelper
	{
		protected static ConcurrentDictionary<string, WebServiceInfo> mCompiledTypes = new ConcurrentDictionary<string, WebServiceInfo>();

		protected virtual WebServiceInfo CreateCompiledType(string serviceVirtualPath)
		{
			if (serviceVirtualPath.StartsWith("~/") || serviceVirtualPath.StartsWith("/"))
			{
				throw new NotSupportedException();
				//mCompiledTypes[serviceVirtualPath] = cc = new WebServiceInfo()
				//{
				//	ServiceType = System.Web.Compilation.BuildManager.GetCompiledType(serviceVirtualPath),
				//	ServiceVirtualPath = serviceVirtualPath
				//};
			}
			else
			{
				return new WebServiceInfo()
				{
					ServiceType = Type.GetType(serviceVirtualPath),
					ServiceVirtualPath = serviceVirtualPath
				};
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="serviceVirtualPath">type.AssemblyQualifiedName or TemplateControl.AppRelativeVirtualPath</param>
		/// <returns></returns>
		public WebServiceInfo GetCompiledTypeByVirtualPath(string serviceVirtualPath)
		{
			/// serviceVirtualPath may be type.FullName if created from WebServiceType
			if (CalystoTools.IsDebugDefined)
			{
				return this.CreateCompiledType(serviceVirtualPath);
			}
			else
			{
				return mCompiledTypes.GetOrAdd(serviceVirtualPath, key2 => this.CreateCompiledType(key2));
			}
		}

		#region Web Service definition builder

		public WebServiceDef GetWebServiceDef(WebServiceInfo ws)
		{
			// use AssemblyQualifiedName: if app restarts and there is no cached type in mCompiledTypes,
			// it will be able to load type from CalystoAjaxHandler: WebServiceHelper.GetCompiledTypeByVirtualPath(astr.serviceVirtualPath))

			bool isWebSocketService = typeof(IWebSocketSession).IsAssignableFrom(ws.ServiceType);

			// get all web methods in CompiledType at once
			var items = WebServiceMethodData.GetWebMethods(ws.ServiceType).Select(mi =>
			{
				WebServiceMethodData methodData = new WebServiceMethodData(null, mi);

				////if (!mi.ReturnType.FullName.StartsWith("System.") && !mi.ReturnType.FullName.Contains('['))
				////{
				////	// do not add System.Collections....List which is generic type, it is impossible to create JS valid namespace from List<>
				////	fileLoc.FileCompiler.RegisterType(mi.ReturnType, fileLoc.AppRelativeVirtualPath, null);
				////}

				if (isWebSocketService)
				{
					////if(mi.ReturnType.FullName != "System.Void")
					////{
					////	throw new Exception("Socket method " + methodData.MethodInfo.Name + " must return void, but returns " + mi.ReturnType.FullName);
					////}

					if (methodData.MethodAttribute.Timeout > 0)
					{
						throw new Exception("Socket method " + methodData.MethodInfo.Name + " can not have timeout set");
					}

					if (methodData.MethodAttribute.UsePost == true)
					{
						throw new Exception("Socket method " + methodData.MethodInfo.Name + " can not have UsePost set");
					}

					if (methodData.MethodAttribute.SessionState)
					{
						// when request is upgraded to socket, it sets Session = null
						throw new Exception("Socket method " + methodData.MethodInfo.Name + " can not have session state");
					}

					if (!typeof(IWebSocketSession).IsAssignableFrom(mi.DeclaringType))
					{
						throw new Exception("Socket method must be of " + typeof(IWebSocketSession).Name + " type. Current type: " + mi.DeclaringType.FullName);
					}
				}

				return methodData;

			}).ToList();


			if (!items.Any())
			{
				throw new Exception("CalystoScriptManager no methods found in " + ws.ServiceVirtualPath);
			}

			// warning: CompiledType may be an aspx page, while method namespace is class where method is declared
			
			string path1 = CalystoAjaxHandlerConstants.TypeServiceRequest;
			
			string absoluteBaseUrl = new CalystoVirtualPathHelper(path1).ToAbsoluteUrl();

			string virtualBaseUrl = new CalystoVirtualPathHelper(path1).ToVirtualUrlPath();
			string virtualServerUrl = AjaxQueryStringHelper.CreateQstr(virtualBaseUrl, ws.ServiceVirtualPath);

			string tsNamespace = items.First().MethodInfo.DeclaringType.FullName; // namespace and class nam
			
			return new WebServiceDef()
			{
				IsWebSocketService = isWebSocketService,
				TypeScriptNamespace = tsNamespace,
				VirtualServerUlrEncoded = CalystoBase64Encoder.Base64RndEncoder.EncodeToBase64String(virtualServerUrl),
				AbsoluteServerUrl = AjaxQueryStringHelper.CreateQstr(absoluteBaseUrl, ws.ServiceVirtualPath),
				Methods = items
			};
		}

		public WebServiceDef GetWebServiceDef(Type serviceType)
		{
			WebServiceInfo ws = GetCompiledTypeByVirtualPath(serviceType.AssemblyQualifiedName);
			return GetWebServiceDef(ws);
		}

		#endregion

		#region Web Service JS methods definition builder

		public string GetWebServiceJS(Type serviceType)
		{
			WebServiceDef def1 = GetWebServiceDef(serviceType);
			return GetWebServiceJsWorker(def1);
		}

		/// <summary>
		/// Returns JS string representing web service methods
		/// </summary>
		/// <param name="webServiceType"></param>
		/// <param name="appRelativeUrl"></param>
		/// <returns></returns>
		public string GetWebServiceJS(WebServiceInfo ws)
		{
			WebServiceDef def1 = GetWebServiceDef(ws);
			return GetWebServiceJsWorker(def1);
		}

		private string GetWebServiceJsWorker(WebServiceDef def1)
		{
			// warning: CompiledType may be an aspx page, while method namespace is class where method is declared
			StringBuilder sb = new StringBuilder();
			
			// JS namespace probably already has type defined, so we have to create service as tmp variable and then copy methods using Extend
			sb.AppendLine("Calysto.Net.WebService.Create" + (def1.IsWebSocketService ? "Socket" : "Ajax") + "(\"" + def1.TypeScriptNamespace + "\", \"" + def1.VirtualServerUlrEncoded + "\")");

			def1.Methods.ForEach((WebServiceMethodData methodData) =>
			{
				//.RegisterAjaxMethod({ method: "HelloWorld", type: "netTypeName", argNames: ["a", "b", "c"] })
				//.RegisterSocketMethod({method:'HelloWorld', useSocket:true, argNames:['name', 'lastname', 'age', 'blob']})

				var parametersNames = methodData.ParameterDataDictionary.Keys;

				WebServiceSettings sett = new WebServiceSettings();
				sett.method = methodData.MethodInfo.Name;
				if (methodData.MethodAttribute.UserEvent) sett.reque = true;
				if (methodData.MethodAttribute.UsePost) sett.post = true;
				if (methodData.MethodAttribute.Timeout > 0) sett.timeoutMs = methodData.MethodAttribute.Timeout;
				if (methodData.MethodAttribute.SessionState) sett.sstate = true;
				if (methodData.MethodAttribute.Silent) sett.silent = true;
				sett.argNames = parametersNames.ToArray();

				var settObj = global::Calysto.Serialization.Json.JsonSerializer.Serialize(sett.ToDictionary());

				string registerMethod = def1.IsWebSocketService ? ".RegisterSocketMethod" : ".RegisterAjaxMethod";

				sb.AppendLine(registerMethod + "(" + settObj + ")");
			});

			sb.AppendLine(";");

			return sb.ToString();
		
		}

		#endregion


	}
}
