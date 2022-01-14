using System;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Calysto.Net.Authorization
{
	/*
		https://en.wikipedia.org/wiki/Basic_access_authentication
		When the server wants the user agent to authenticate itself towards the server, it must respond appropriately to unauthenticated requests.
		Unauthenticated requests should return a response whose header contains a HTTP 401 Unauthorized status[4] and a WWW-Authenticate field.[5]
		The WWW-Authenticate field for basic authentication (used most often) is constructed as following:
		WWW-Authenticate: BASIC Realm="User Visible Realm"

		delete username & pass on client:
		<script>document.execCommand('ClearAuthenticationCache', 'false');</script>

		delete username & pass on serveru: send StatusCode = 401, but it works in Chrome only

		It doesn't use cookie. Browser keeps data cached and send to server on each request.

		send username & pass on first request:
		https://username:pass@www.Calysto.test/SmartCalystoBackup/WebForm1.aspx
	*/

	public class BasicAuthorization
	{
		public string Username { get; set; }
		public string Password { get; set; }

		public string EncodeToString()
		{
			string str1 = this.Username?.Trim() + ":" + this.Password?.Trim();
			return "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(str1));
		}

		public static bool TryDecode(string basicValue, out BasicAuthorization authorization)
		{
			try
			{
				Match m1 = Regex.Match(basicValue, "Basic[\\s]+(?<value>[\\S]+)$");
				if (m1.Success)
				{
					string s1 = Encoding.UTF8.GetString(Convert.FromBase64String(m1.Groups["value"].Value));
					string[] s2 = s1.Split(':');
					authorization = new BasicAuthorization()
					{
						Username = s2[0],
						Password = s2[1]
					};
					return true;
				}
			}
			catch { }

			authorization = null;
			return false;
		}

		public static string ReadAuthorization(NameValueCollection headers)
		{
			return headers["Authorization"];
		}

#if DOTNETFRAMEWORK
		public static void WritePromptToIISResponse(HttpResponse resp, string realmText)
		{
			// WWW-Authenticate: BASIC Realm="User Visible Realm"
			resp.Headers["WWW-Authenticate"] = $"BASIC Realm=\"{HttpUtility.UrlEncode(realmText)}\"";
			resp.StatusCode = 401;
		}
#endif

	}
}
