namespace Calysto.AspNetCore.Mvc.Razor
{
	public class CalystoMvcHelper
	{
		private Microsoft.AspNetCore.Mvc.Razor.RazorPage Page { get; }

		public CalystoMvcHelper(Microsoft.AspNetCore.Mvc.Razor.RazorPage page)
		{
			this.Page = page;
		}

	}
}
