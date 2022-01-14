using System.Web;

namespace Calysto.Web.Script.Services
{
	public class AjaxQueryStringHelperForms : AjaxQueryStringHelper
	{
		public static bool UseSessionState(HttpContext context)
		{
			return context.Request.QueryString[WsjsTypeHandlerConstants.UseSessionState] == "1";
		}

		public static AjaxQueryStringHelper Parse(HttpContext context)
		{
			var aa = Parse(context.Request.QueryString);
			return aa;
		}

	}

}
