namespace Calysto.AspNetCore.Mvc.Razor
{
	public static class CalystoMvcExtensions
	{
		public static CalystoRazorPage Calysto(this Microsoft.AspNetCore.Mvc.Razor.RazorPage page)
		{
			// ne moze se cachirati page u Context.Items jer imamo vise raznih page instanci od Layout i Main view u istom requestu
			return new CalystoRazorPage(page);
		}
	}
}

