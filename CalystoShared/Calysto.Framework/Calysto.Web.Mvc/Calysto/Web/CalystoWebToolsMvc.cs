using System.Linq;
using Calysto.Web.Hosting;

namespace Calysto.Web
{
	public class CalystoWebToolsMvc
	{
		#region GetDomainFromHost methods

		public static string GetDomainFromHost()
		{
			return GetHttpWwwDomainFromHost(false, false);
		}

		/// <summary>
		/// creates www.toolnix.com, or subdomain like sub1.toolnix.com
		/// </summary>
		/// <returns></returns>
		public static string GetWwwDomainFromHost()
		{
			return GetHttpWwwDomainFromHost(false, true);
		}

		/// <summary>
		/// creates http://www.toolnix.com, or subdomain http://sub1.toolnix.com
		/// </summary>
		/// <returns></returns>
		public static string GetHttpWwwDomainFromHost()
		{
			return GetHttpWwwDomainFromHost(true, true);
		}

		/// <summary>
		/// returns real domain (host) with http(s)://www. at start
		/// </summary>
		/// <returns></returns>
		public static string GetHttpWwwDomainFromHost(bool addHttp, bool addWww)
		{
			var request = CalystoMvcHostingEnvironment.Current.HttpContext.Request;
			string prefix = "http://";
			string port = "";
			int? portNum = request.Host.Port;
			if (portNum != 80 && portNum != 443)
			{
				port = ":" + portNum;
			}

			if (request.IsHttps)
			{
				prefix = "https://";
				port = null;
			}

			string host = request.Host.Host; // host without port, Host.Value contains host and port
			if (host.StartsWith("www."))
			{
				host = host.Substring(4);
			}
			int dots = host.Where(o => o == '.').Count();
			// www should be added if it is toolnix.com, but if it is subdomain, don't add www, e.g. sub1.toolnix.com
			// if it si localhost, don't add www
			return (addHttp ? prefix : null) + (addWww && dots == 1 ? "www." : null) + host + port;
		}

		#endregion

	}
}


