using Calysto.Web.UI;
using System.Collections.Specialized;
using System.Collections.Generic;
using Calysto.Linq;
using Calysto.Converter;
using Microsoft.AspNetCore.Http;

namespace Calysto.Web.Script.Services
{
	public class AjaxQueryStringHelperMvc : AjaxQueryStringHelper
	{
		public static bool UseSessionState(HttpContext context)
		{
			return context.Request.Query[WsjsTypeHandlerConstants.UseSessionState] == "1";
		}

		public static AjaxQueryStringHelper Parse(HttpContext context)
		{
			var aa = Parse(context.Request.QueryString.Value);
			//aa.context = context;
			return aa;
		}
	}

}
