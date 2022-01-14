using Calysto.Caching;
using Calysto.Security.Cryptography;
using Calysto.Web;
using Calysto.Web.Hosting;
using Microsoft.AspNetCore.Http;
using System;

namespace Calysto.AspNetCore.Http
{
	public class CalystoSessionProvider
	{
		CalystoMemoryCache<string, CalystoSession> _sessionsCache = new CalystoMemoryCache<string, CalystoSession>();
		string _cookieName;
		TimeSpan _sessionDuration;
		int _cnt = 0;
		string _signerSecret;

		private CalystoCertification GetSigner()
		{
			string headers = CalystoContextMvc.Current.BrowserDistinctHeaderString;
			return new CalystoCertification(headers + _signerSecret);
		}

		public CalystoSessionProvider(string cookieName, TimeSpan sessionDuration, string signerSecret)
		{
			_cookieName = cookieName;
			_sessionDuration = sessionDuration;
			_signerSecret = signerSecret;
		}

		public void RemoveSession(string sessionId)
		{
			_sessionsCache.Remove(sessionId);
		}

		/// <summary>
		/// Get current calysto session.
		/// </summary>
		/// <returns></returns>
		public CalystoSession GetCurrentSession()
		{
			lock (this)
			{
				// try get sessionId from context
				if (CalystoMvcHostingEnvironment.Current.HttpContext.Items.TryGetValue(_cookieName, out object objssid))
				{
					if (_sessionsCache.TryGetValue((string)objssid, out CalystoSession session1))
						return session1;
				}

				string ssid;

				// try get sessionId from cookie
				if (CookieHelper.TryGetCookieValue(_cookieName, out string signedSsid))
				{
					if (this.GetSigner().TryDecode(signedSsid, out ssid) && _sessionsCache.TryGetValue(ssid, out CalystoSession session1))
					{
						// add to context for faster access
						CalystoMvcHostingEnvironment.Current.HttpContext.Items[_cookieName] = ssid;
						return session1;
					}
					else
					{
						CookieHelper.DeleteCookie(_cookieName);
					}
				}

				// create new sessionId
				ssid = Guid.NewGuid().ToString() + "-" + Math.Abs(++_cnt);
				// add to context for faster access and to prevent double sessionId creation
				CalystoMvcHostingEnvironment.Current.HttpContext.Items[_cookieName] = ssid;
				
				// cookie will be saved when value is set to session
				Action fnSaveCookie = () => CookieHelper.SetCookie(_cookieName, this.GetSigner().Sign(ssid), new CookieOptions() { Expires = DateTime.Now.AddDays(30) });

				CalystoSession session = new CalystoSession(this, ssid, fnSaveCookie);

				_sessionsCache.SetValue(ssid, session, _sessionDuration, true);

				return session;
			}
		}

	}
}
