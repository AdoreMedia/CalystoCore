using System.Collections.Specialized;
using System.Collections.Generic;
using Calysto.Linq;
using Calysto.Converter;
using Calysto.Web.Hosting;

namespace Calysto.Web.Script.Services
{
	public class AjaxQueryStringHelper
	{
		public static string CreateQstr(string baseUrl, string serviceVirtualPath)
		{
			return baseUrl + $"?{WsjsTypeHandlerConstants.WebMethod}=__calysto_method_name__"
				+ $"&{WsjsTypeHandlerConstants.CasingTest}={WsjsTypeHandlerConstants.CasingValue}"
				+ $"&{WsjsTypeHandlerConstants.ServiceVirtualPath}={CalystoBase64Encoder.Base64RndEncoder.EncodeToBase64String(serviceVirtualPath)}"
				+ $"&{WsjsTypeHandlerConstants.CultureName}=__calysto_culture__"
				+ $"&{WsjsTypeHandlerConstants.UseSessionState}=__calysto_ss__"
				+ $"&{WsjsTypeHandlerConstants.CurrentUrl}=__calysto_current_url__" + "__calysto_json_arg__"
				+ $"&{WsjsTypeHandlerConstants.Version}={CalystoPhysicalPaths.Current?.AssembliesSignature}"; // version changes when dll is recompiled
		}

		public bool isCasingOK;
		public bool isDataOK;
		public string serviceVirtualPath;
		public string pageVirtualPathAndQuery;
		public string methodName;
		public string timestampRawString;
		public string cultureName;
		public bool useSessionState;
		public bool isSocketWebClient;
		/// <summary>
		/// provided with socketWebClient
		/// </summary>
		public Dictionary<string, object> methodArguments;
		public bool IsSuccessful => this.isCasingOK && this.isDataOK;

		private static void ApplyCulture(string cultureName)
		{
			System.Threading.Thread.CurrentThread.CurrentCulture = 
				System.Threading.Thread.CurrentThread.CurrentUICulture = 
				System.Globalization.CultureInfo.GetCultureInfo(cultureName);
		}

		/// <summary>
		/// Apply culture from query string.
		/// </summary>
		public void ApplyCurrentCulture()
		{
			ApplyCulture(this.cultureName);
		}

		public static AjaxQueryStringHelper Parse(NameValueCollection qq)
		{
			AjaxQueryStringHelper astr = new AjaxQueryStringHelper();
			try
			{
				astr.isCasingOK = qq[WsjsTypeHandlerConstants.CasingTest] == WsjsTypeHandlerConstants.CasingValue;

				if (astr.isCasingOK)
				{
					astr.useSessionState = qq[WsjsTypeHandlerConstants.UseSessionState] == "1";
					astr.methodName = qq[WsjsTypeHandlerConstants.WebMethod];
					astr.serviceVirtualPath = CalystoBase64Encoder.Base64RndEncoder.DecodeBase64StringToString(qq[WsjsTypeHandlerConstants.ServiceVirtualPath]);
					astr.pageVirtualPathAndQuery = CalystoBase64Encoder.Base64RndEncoder.DecodeBase64StringToString(qq[WsjsTypeHandlerConstants.CurrentUrl]);
					astr.timestampRawString = qq[WsjsTypeHandlerConstants.Version];
					astr.cultureName = qq[WsjsTypeHandlerConstants.CultureName];
					astr.isDataOK = true;

					ApplyCulture(astr.cultureName);
				}
			}
			catch
			{
				astr.isDataOK = false;
			}
			return astr;
		}

		public static AjaxQueryStringHelper Parse(string str1)
		{
			if (string.IsNullOrWhiteSpace(str1))
				return null;

			NameValueCollection nv = new NameValueCollection();
			CalystoQueryString qstr = new CalystoQueryString();
			qstr.ParseUrl(str1);
			qstr.ToDictionary().ForEach(kv => nv.Add(kv.Key, kv.Value + ""));
			return Parse(nv);
		}

	}

}
