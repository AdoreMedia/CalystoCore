using System.Web;

namespace Calysto.Web
{
	public class CalystoUriForms : CalystoUri
	{
		public CalystoUriForms(HttpContext context) : base(context.Request.Url.AbsoluteUri)
		{
			this.PathBase = System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath;
		}

	}
}
