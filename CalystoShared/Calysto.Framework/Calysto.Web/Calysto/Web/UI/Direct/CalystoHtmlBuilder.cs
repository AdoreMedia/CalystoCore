using Calysto.Extensions;
using Calysto.Web.Script.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Calysto.Web.UI.Direct
{
	public class CalystoHtmlBuilder
	{
		public enum Kind
		{
			/// <summary>
			/// black text
			/// </summary>
			[StringValue("black")]
			Message,
			/// <summary>
			/// red text
			/// </summary>
			[StringValue("red")]
			Error,
			/// <summary>
			/// orange text
			/// </summary>
			[StringValue("orange")]
			Warning,
			/// <summary>
			/// green text
			/// </summary>
			[StringValue("green")]
			Success,
			/// <summary>
			/// blue tekst
			/// </summary>
			[StringValue("blue")]
			Info
		}

		private CalystoHtmlElement CreateMessageElement(Kind kind, string text)
		{
			string color = kind.GetStringValue();
			return new CalystoHtmlElement("div").AddClass("calysto-html-builder-message-" + color).ApplyStyle("color", color).SetInnerHtml(text);
		}

		private CalystoHtmlElement CreateScriptElement(string jsContent)
		{
			return new CalystoHtmlElement("script").SetAttribute("type", "text/javascript").SetInnerHtml(jsContent);
		}

		private CalystoHtmlElement CreateStyleElement(string styleSheetContent)
		{
			return new CalystoHtmlElement("style").ApplyStyle("type", "text/css").SetInnerHtml(styleSheetContent);
		}

		List<Func<CalystoHtmlElement>> _functions = new List<Func<CalystoHtmlElement>>();

		public CalystoHtmlBuilder AddMessage(Kind kind, string text)
		{
			_functions.Add(() => this.CreateMessageElement(kind, text));
			return this;
		}

		/// <summary>
		/// Will create 'script' node inside of html.
		/// </summary>
		/// <param name="jsContent"></param>
		/// <returns></returns>
		public CalystoHtmlBuilder AddJavaScript(string jsContent)
		{
			_functions.Add(() => this.CreateScriptElement(jsContent));
			return this;
		}

		public CalystoHtmlBuilder AddStyleSheet(string styleSheetContent)
		{
			_functions.Add(() => this.CreateStyleElement(styleSheetContent));
			return this;
		}

		private IEnumerable<CalystoHtmlElement> GetHtmlElements()
		{
			foreach (var fn in _functions)
			{
				yield return fn.Invoke();
			}
		}

		public bool HasElements() => this.GetHtmlElements().Any();

		/// <summary>
		/// Create parentTag element and add items as children.
		/// Will create 'script' html node if there is any script.
		/// </summary>
		/// <param name="parentTag"></param>
		/// <param name="parentClass"></param>
		/// <returns></returns>
		public string ToHtml(string parentTag = null, string parentClass = null)
		{
			CalystoHtmlElement element = new CalystoHtmlElement(parentTag);
			if (parentClass != null)
				element.AddClass(parentClass);

			element.AddChildren(this.GetHtmlElements().ToArray());
			return element.ToHtml();
		}
	}
}
