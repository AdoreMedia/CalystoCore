using Calysto.Common;
using System.Web;

namespace Calysto.AspNetCore.Mvc.Razor
{
	public class CalystoRazorHtmlHelper
	{
		private Microsoft.AspNetCore.Mvc.Razor.RazorPage Page { get; }

		public CalystoRazorHtmlHelper(Microsoft.AspNetCore.Mvc.Razor.RazorPage page)
		{
			this.Page = page;
		}
	}
}
