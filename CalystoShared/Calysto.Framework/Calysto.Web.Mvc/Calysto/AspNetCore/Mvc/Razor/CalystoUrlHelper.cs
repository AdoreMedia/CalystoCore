namespace Calysto.AspNetCore.Mvc.Razor
{
	public class CalystoUrlHelper
	{
		private Microsoft.AspNetCore.Mvc.Razor.RazorPage Page { get; }

		public CalystoUrlHelper(Microsoft.AspNetCore.Mvc.Razor.RazorPage page)
		{
			this.Page = page;
		}
	}
}
