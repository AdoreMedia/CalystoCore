using System;
using System.Collections.Generic;
using System.Linq;
using Calysto.Linq;
using System.Web;

namespace Calysto.Web.UI.Direct
{
	public class CalystoDirectQuery
	{
		private static string JSEncode(string str) => HttpUtility.JavaScriptStringEncode(str);

		List<string> _jsItems = new List<string>();

		public string ToJavaScript()
		{
			// statements are fluent api so we must join them as is. Add ; at the end only.
			return _jsItems.ToStringJoined() + ";";
		}

		private CalystoDirectQuery Append(string js)
		{
			_jsItems.Add(js);
			return this;
		}

		private CalystoDirectQuery()
		{
		}

		public static CalystoDirectQuery FromSelector(string rxSelector)
		{
			return new CalystoDirectQuery().NewQuery(rxSelector);
		}

		private CalystoDirectQuery NewQuery(string rxSelector)
		{
			if (_jsItems.Any())
				_jsItems.Add(";");

			return this.Append(string.Format("$$calysto('{0}')", rxSelector));
		}

		/// <summary>
		/// Create subquery.
		/// </summary>
		/// <param name="querySelector"></param>
		/// <returns></returns>
		public CalystoDirectQuery Query(string rxSelector)
		{
			if (_jsItems.Any())
			{
				return Append(string.Format(".Query('{0}')", rxSelector));
			}
			else
			{
				return FromSelector(rxSelector);
			}
		}

		/// <summary>
		/// invoke setTimeout(onExpired, sleepMs)
		/// </summary>
		/// <param name="sleepMs"></param>
		/// <param name="onExpired"></param>
		/// <returns></returns>
		public CalystoDirectQuery Sleep(int sleepMs, Action<CalystoDirectQuery> onExpired)
		{
			CalystoDirectQuery callback = new CalystoDirectQuery().Append("a");
			onExpired(callback);
			string func = "function(a){" + callback.ToJavaScript() + ";}";
			return this.Append(string.Format(".Sleep({0}, {1})", sleepMs, func));
		}

		public CalystoDirectQuery SetAttribute(string name, string value)
		{
			return this.Append(string.Format(".SetAttribute('{0}', '{1}')", name, JSEncode(value)));
		}

		public CalystoDirectQuery RemoveAttribute(string name)
		{
			return this.Append(string.Format(".RemoveAttribute('{0}')", name));
		}

		/// <summary>
		/// set property with value
		/// </summary>
		/// <param name="name"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public CalystoDirectQuery SetProperty(string name, string value)
		{
			return this.Append(string.Format(".SetProperty('{0}', '{1}')", name, JSEncode(value)));
		}

		public CalystoDirectQuery SetInnerHtml(string innerHtml)
		{
			return this.Append(string.Format(".SetInnerHtml('{0}')", JSEncode(innerHtml)));
		}

		/// <summary>
		/// Mark script nodes as executed, so will not execute them on next ExecuteScriptNodes().
		/// </summary>
		/// <returns></returns>
		public CalystoDirectQuery MarkScriptsExecuted()
		{
			return this.Append(string.Format(".MarkScriptsExecuted()"));
		}

		/// <summary>
		/// Find and execute script nodes if not already marked as executed.
		/// </summary>
		/// <param name="alwaysExecute"></param>
		/// <returns></returns>
		public CalystoDirectQuery ExecuteScriptNodes(bool alwaysExecute = false)
		{
			return this.Append(string.Format(".ExecuteScriptNodes({0})", alwaysExecute ? "true" : "false"));
		}

		public CalystoDirectQuery AppendInnerHtml(string innerHtml)
		{
			return this.Append(string.Format(".AppendInnerHtml('{0}')", JSEncode(innerHtml)));
		}

		public CalystoDirectQuery SetValueOrInnerHtml(string content)
		{
			return this.Append(string.Format(".SetValueOrInnerHtml('{0}')", JSEncode(content)));
		}

		/// <summary>
		/// Will execute new inserted script elements.
		/// </summary>
		/// <param name="content"></param>
		/// <returns></returns>
		public CalystoDirectQuery ReplaceChildren(params string[] content)
		{
			return this.Append(".ReplaceChildren(" + content.Select(html => "'" + JSEncode(html) + "'").ToStringJoined(", ") + ")");
		}

		public CalystoDirectQuery AddChildren(params string[] content)
		{
			return this.Append(".AddChildren(" + content.Select(html => "'" + JSEncode(html) + "'").ToStringJoined(", ") + ")");
		}

		/// <summary>
		/// replace element with new element created from html
		/// </summary>
		/// <param name="outerHtml"></param>
		/// <returns></returns>
		public CalystoDirectQuery ReplaceWith(string outerHtml)
		{
			return this.Append(string.Format(".ReplaceWith('{0}')", JSEncode(outerHtml)));
		}

		public CalystoDirectQuery SetVisible(bool isVisible)
		{
			return this.Append(string.Format(".SetVisible({0})", isVisible ? "true" : "false"));
		}

		public CalystoDirectQuery ApplyStyle(string style)
		{
			return this.Append(string.Format(".ApplyStyle('{0}')", style));
		}

		public CalystoDirectQuery ApplyStyle(string name, string value)
		{
			return this.Append(string.Format(".ApplyStyle('{0}', '{1}')", name, value));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <param name="add">true to add, false to remove</param>
		/// <returns></returns>
		public CalystoDirectQuery AddClass(string name, bool add = true)
		{
			if (add)
			{
				return this.Append(string.Format(".AddClass('{0}')", name));
			}
			else
			{
				return this.RemoveClass(name);
			}
		}

		public CalystoDirectQuery RemoveClass(string name)
		{
			return this.Append(string.Format(".RemoveClass('{0}')", name));
		}

		public CalystoDirectQuery AddJavaScript(string js)
		{
			return this.Append(js);
		}

		/// <summary>
		/// toggle class name (add or remove)
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public CalystoDirectQuery ToggleClass(string name)
		{
			return this.Append(string.Format(".ToggleClass('{0}')", name));
		}

		/// <summary>
		/// replace previous class value with new one
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public CalystoDirectQuery SetClass(string name)
		{
			return this.Append(string.Format(".SetClass('{0}')", name));
		}

		/// <summary>
		/// add or remove 'disabled'='disabled' attribute
		/// </summary>
		/// <param name="isEnabled"></param>
		/// <returns></returns>
		public CalystoDirectQuery SetEnabled(bool isEnabled)
		{
			return this.Append(string.Format(".SetEnabled({0})", isEnabled ? "true" : "false"));
		}

		/// <summary>
		/// set 'value' property
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public CalystoDirectQuery SetValue(string value)
		{
			return this.SetProperty("value", value);
		}

		/// <summary>
		/// add or remove 'checked'='checked' attribute
		/// </summary>
		/// <param name="isChecked"></param>
		/// <returns></returns>
		public CalystoDirectQuery SetChecked(bool isChecked)
		{
			// use property, don't use attribute because once checked is set using property, it can't be removed using attribute
			return this.Append(string.Format(".SetChecked({0})", isChecked ? "true" : "false"));
		}

	}

}
