using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calysto.Web.Script.Services
{
	public static class ServiceResponseJavaScripts
	{
		/// <summary>
		/// Posalje JS za reload stranice i reloadirat ce stranicu, ali samo ako je proslo najmanje intervalSeconds od zadnjeg slanja.
		/// </summary>
		/// <param name="intervalSeconds">Koliko sekundi izmedjeu 2 slanja mora proci.</param>
		/// <returns></returns>
		public static string ResponseJsIfContentScriptNotFound(int intervalSeconds)
		{
			// ne reloadirati cesce od 30 sekundi
			// setiramo _cRelExpires, potom provjerimo da li je setiran i onda moze reload, u protivnom ne
			return $@"
if (!(parseInt(sessionStorage[""_cRelExpires""]) > Date.now()))
{{
	sessionStorage[""_cRelExpires""] = Date.now() + {(intervalSeconds * 1000)};
	if (parseInt(sessionStorage[""_cRelExpires""]) > Date.now())
	{{
		location.reload(true);
	}}
}}
";
		}
	}
}
