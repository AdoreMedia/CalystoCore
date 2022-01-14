using Calysto.Linq;
using Calysto.Web.UI;
using Microsoft.AspNetCore.Html;
using System;

namespace Calysto.AspNetCore.Mvc.Razor
{
	public class CalystoRazorPage
	{
		private Microsoft.AspNetCore.Mvc.Razor.RazorPage Page { get; }

		public CalystoRazorPage(Microsoft.AspNetCore.Mvc.Razor.RazorPage page)
		{
			this.Page = page;
		}

		CalystoRazorHtmlHelper _html;
		public CalystoRazorHtmlHelper Html => _html ?? (_html = new CalystoRazorHtmlHelper(this.Page));

		CalystoUrlHelper _url;
		public CalystoUrlHelper Url => _url ?? (_url = new CalystoUrlHelper(this.Page));

		CalystoMvcHelper _mvc;
		public CalystoMvcHelper Mvc => _mvc ?? (_mvc = new CalystoMvcHelper(this.Page));

		public HtmlString Preloader(Func<CalystoAjaxPreloaders, string> func)
		{
			return new HtmlString(func.Invoke(new CalystoAjaxPreloaders()));
		}

		/// <summary>
		/// Renders script tags in place.
		/// </summary>
		/// <param name="calysto"></param>
		/// <param name="setting"></param>
		public string ScriptManager(Action<CalystoScriptManager> setup)
		{
			CalystoScriptManager s = new CalystoScriptManager();
			setup.Invoke(s);
			string str = s.GetScriptsTags().ToStringJoined("\r\n");
			this.Page.WriteLiteral(str);
			return "";
		}
	}
}
