using System;

namespace Calysto.Web.Script.Services
{
	internal class WebServiceHelperForms : WebServiceHelper
	{
		protected override WebServiceInfo CreateCompiledType(string serviceVirtualPath)
		{
			if (serviceVirtualPath.StartsWith("~/") || serviceVirtualPath.StartsWith("/"))
			{
				return new WebServiceInfo()
				{
					ServiceType = System.Web.Compilation.BuildManager.GetCompiledType(serviceVirtualPath),
					ServiceVirtualPath = serviceVirtualPath
				};
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

		public string GetWebServiceJS(string serviceVirtualPath)
		{
			WebServiceInfo ws = GetCompiledTypeByVirtualPath(serviceVirtualPath);
			return GetWebServiceJS(ws);
		}
	}
}
