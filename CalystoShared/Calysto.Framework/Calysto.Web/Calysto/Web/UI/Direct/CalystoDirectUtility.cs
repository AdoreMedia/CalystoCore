using System;
using System.Collections.Generic;
using Calysto.Linq;
using System.Web;

namespace Calysto.Web.UI.Direct
{
	public class CalystoDirectUtility
	{
		private static string JSEncode(string str) => HttpUtility.JavaScriptStringEncode(str);

		List<string> _jsItems = new List<string>();

		public string ToJavaScript()
		{
			// statements has to be separated using ; (this is not fluent api statements like DirectQuery)
			return _jsItems.ToStringJoined(";") + ";";
		}

		private CalystoDirectUtility Append(string js)
		{
			_jsItems.Add(js);
			return this;
		}

		public CalystoDirectUtility()
		{
		}

		public CalystoDirectUtility ExecuteJavaScript(string js, int delayMs = 0)
		{
			// warning: js code may NOT be JSEncoded, it won't work on client
			if (delayMs > 0)
				return this.Append(@"setTimeout(function(){" + js + @"}, " + delayMs + ")");
			else
				return this.Append(js);
		}


		public CalystoDirectUtility SetWindowLocation(string url, int delayMs = 0)
		{
			return this.ExecuteJavaScript("window.location=\"" + JSEncode(url) + "\"", delayMs);
		}

		public CalystoDirectUtility ReloadWindowLocation(int delayMs = 0)
		{
			return this.ExecuteJavaScript("window.location.reload(true)", delayMs);
		}

		public CalystoDirectUtility SystemAlert(string message)
		{
			return this.Append("alert(\"" + JSEncode(message) + "\")");
		}

		public enum DialogIconEnum
		{
			none,
			info,
			warning,
			error,
			question,
			success
		}

		/// <summary>
		/// Create Calysto.Diagnostic.Alert
		/// </summary>
		/// <param name="message"></param>
		/// <param name="title"></param>
		/// <param name="icon"></param>
		/// <returns></returns>
		public CalystoDirectUtility Alert(
			string message,
			DialogIconEnum icon = DialogIconEnum.info,
			string title = null,
			int? autoCloseMs = null,
			bool showButtons = true)
		{
			string s1 = $@"new Calysto.Dialog()
.Title(""{JSEncode(title)}"")
.Content(""{JSEncode(message)}"")
.Icon(""{icon}"")
.CloseOnEscKey()
.ButtonXClose(){(showButtons ? $".Button(\"{(global::Calysto.Resources.CalystoLang.Close)}\")" : null)}
.OnButtonClick(function (dialog, buttonName){{dialog.Close()}})
.AutoClose({(autoCloseMs > 0 ? autoCloseMs.ToString() : "null")})
.Show()";

			return this.Append(s1);
		}

		public enum NotifyHPositionEnum
		{
			right,
			left,
			center
		}

		public enum NotifyVPositionEnum
		{
			top,
			bottom
		}

		public CalystoDirectUtility Notification(
			string message,
			DialogIconEnum icon = DialogIconEnum.info,
			int? autoCloseMs = 4000,
			NotifyVPositionEnum vPosition = NotifyVPositionEnum.top,
			NotifyHPositionEnum hPosition = NotifyHPositionEnum.center)
		{
			string s1 = $@"Calysto.Notification.Create(""{JSEncode(message)}"", ""{icon.ToString()}"", {autoCloseMs.GetValueOrDefault()}, ""{vPosition.ToString()}"", ""{hPosition.ToString()}"").Show()";

			return this.Append(s1);
		}

		public CalystoDirectUtility SetCookie(string cookieName, string cookieValue, DateTime? expires = null, string domain = null, string path = null, bool? secure = null)
		{
			int? expiresSeconds = null;
			if (expires > DateTime.MinValue)
			{
				expiresSeconds = (int) (expires.Value - DateTime.Now).TotalSeconds;
			}

			return this.Append($@"Calysto.CookieUtility.SetCookieValue(""{JSEncode(cookieName)}"", ""{JSEncode(cookieValue)}"", {(expiresSeconds.HasValue ? expiresSeconds + "" : "null")}, ""{JSEncode(domain)}"", ""{JSEncode(path)}"", {(secure==true ? "true" : "false")})");
		}

		//public CalystoDirectUtility SetCookie(string cookieName, string value, CookieOptions options = null)
		//{
		//	return this.SetCookie(cookie.Name, cookie.Value, cookie.Expires, cookie.Domain, cookie.Path, cookie.Secure);
		//}

		public CalystoDirectUtility DeleteCookie(string cookieName, string domain = null)
		{
			return this.SetCookie(cookieName, "", DateTime.Now.AddYears(-10), domain); // set expired 10 year ago
		}

	}
}
