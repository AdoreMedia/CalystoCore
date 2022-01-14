using Calysto.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calysto.Web.UI.Direct
{
	public class CalystoHtmlElement
	{
		private static HashSet<string> _selfClosing = new HashSet<string>() { "area", "base", "br", "col", "embed", "hr", "img", "input", "link", "meta", "param", "source", "track", "wbr" };

		protected string TagName;
		protected string TextValue;
		protected CalystoHtmlElement ParentNode;
		protected bool IsXmlMode;

		protected Dictionary<string, string> Attributes = new Dictionary<string, string>();
		protected List<CalystoHtmlElement> Children = new List<CalystoHtmlElement>();
		protected Dictionary<string, string> Styles = new Dictionary<string, string>();
		protected HashSet<string> CssClasses = new HashSet<string>();

		protected bool IsTextNode()
		{
			if (this.TextValue != null)
			{
				if (this.Children.Any())
					throw new InvalidOperationException($"{nameof(CalystoHtmlElement)} may not have TextValue '{this.TextValue}' and Children '{this.Children.Count}' assigned at the same time. Children count: '{this.Children.Count}', TextValue: '{this.TextValue}'.");
				else
					return true;
			}
			return false;
		}

		public CalystoHtmlElement(string tagName, bool isXml = false)
		{
			this.IsXmlMode = isXml;
			this.TagName = tagName;
		}

		/// <summary>
		/// Returns outer html
		/// </summary>
		/// <returns></returns>
		public string ToHtml() => GetOuterHtmlParts().ToStringJoined();

		public string GetInnerHtml() => GetInnerHtmlParts().ToStringJoined();

		protected string NormalizeName(string name) => name.ToLower();

		protected IEnumerable<string> GetOuterHtmlParts()
		{
			if (this.IsTextNode())
			{
				yield return this.GetInnerHtml();
			}
			else if(string.IsNullOrWhiteSpace(this.TagName))
			{
				// render children only
				foreach (var part in GetInnerHtmlParts())
					yield return part;
			}
			else
			{
				yield return $"<{this.TagName}";

				if (this.CssClasses.Any())
					yield return $" class=\"{this.CssClasses.ToStringJoined(" ")}\"";

				if (this.Attributes.Any())
				{
					foreach (var item in this.Attributes)
						yield return $" {HttpUtility.HtmlAttributeEncode(item.Key)}=\"{HttpUtility.HtmlAttributeEncode(item.Value)}\"";
				}

				if (this.Styles.Any())
					yield return $" style=\"{(this.Styles.Select(kv => $"{HttpUtility.HtmlAttributeEncode(kv.Key)}:{HttpUtility.HtmlAttributeEncode(kv.Value)}").ToStringJoined("; "))}\"";

				bool hasChildren = this.GetInnerHtmlParts().Any();
				bool isSelfClosingTag = this.IsXmlMode || _selfClosing.Contains(this.TagName);

				if(isSelfClosingTag && hasChildren)
				{
					throw new InvalidOperationException($"{nameof(CalystoHtmlElement)} tag '{this.TagName}' may not have children.");
				}
				else if (isSelfClosingTag && !hasChildren)
				{
					yield return " />";
				}
				else
				{
					yield return ">";

					foreach (var part in GetInnerHtmlParts())
						yield return part;

					yield return $"</{this.TagName}>";
				}
			}
		}

		protected IEnumerable<string> GetInnerHtmlParts()
		{
			if (this.IsTextNode())
			{
				// do not encode content, it may be html
				yield return this.TextValue;
			}
			else
			{
				foreach (var item in this.Children.Where(o => o != null))
				{
					yield return item.ToHtml();
				}
			}
		}

		public CalystoHtmlElement SetVisible(bool isVisible)
		{
			return this.ApplyStyle("display", isVisible ? "unset" : "none");
		}

		public CalystoHtmlElement ApplyStyle(string style)
		{
			var items = CalystoWebTools.ParseCssStyleValues(style);
			items.ForEach(kv => this.ApplyStyle(kv.Key, kv.Value));
			return this;
		}

		public CalystoHtmlElement ApplyStyle(string name, string value)
		{
			name = NormalizeName(name);
			this.Styles.Remove(name);
			this.Styles.Add(name, value);
			return this;
		}

		public CalystoHtmlElement AddClass(string name, bool add = true)
		{
			this.CssClasses.Remove(name);
			if (add)
				this.CssClasses.Add(name);

			return this;
		}

		public CalystoHtmlElement RemoveClass(string name)
		{
			return this.AddClass(name, false);
		}

		public CalystoHtmlElement ToggleClass(string name)
		{
			if (this.CssClasses.Contains(name))
				return this.RemoveClass(name);
			else
				return this.AddClass(name);
		}

		/// <summary>
		/// Remove all previous values and set new one.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public CalystoHtmlElement SetClass(string name)
		{
			this.CssClasses.Clear();
			return this.AddClass(name);
		}

		public virtual CalystoHtmlElement SetAttribute(string name, string value)
		{
			name = NormalizeName(name);
			Attributes.Remove(name);
			Attributes[name] = value;
			return this;
		}

		public virtual CalystoHtmlElement RemoveAttribute(string name)
		{
			name = NormalizeName(name);
			Attributes.Remove(name);
			return this;
		}

		public virtual CalystoHtmlElement SetAttributes(Dictionary<string, string> attributes)
		{
			attributes.ForEach(kv => this.SetAttribute(kv.Key, kv.Value));
			return this;
		}

		public virtual CalystoHtmlElement SetInnerHtml(string innerHtml)
		{
			this.Children.Clear();
			this.AddChildren(new CalystoHtmlElement("#text") { TextValue = innerHtml }) ;
			return this;
		}

		public virtual CalystoHtmlElement AppendInnerHtml(string innerHtml)
		{
			this.AddChildren(new CalystoHtmlElement("#text") { TextValue = innerHtml });
			return this;
		}

		public virtual CalystoHtmlElement AddChildren(params CalystoHtmlElement[] elements)
		{
			foreach (var item in elements)
			{
				item.ParentNode= this;
				this.Children.Add(item);
			}
			return this;
		}

		/// <summary>
		/// add or remove 'disabled'='disabled' attribute
		/// </summary>
		/// <param name="isEnabled"></param>
		/// <returns></returns>
		public CalystoHtmlElement SetEnabled(bool isEnabled)
		{
			if (isEnabled)
				return this.RemoveAttribute("disabled");
			else
				return this.SetAttribute("disabled", "disabled");
		}

		/// <summary>
		/// set 'value' property
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public CalystoHtmlElement SetValue(string value)
		{
			return this.SetAttribute("value", value);
		}

		/// <summary>
		/// add or remove 'checked'='checked' attribute
		/// </summary>
		/// <param name="isChecked"></param>
		/// <returns></returns>
		public CalystoHtmlElement SetChecked(bool isChecked)
		{
			if (!isChecked)
				return this.RemoveAttribute("checked");
			else
				return this.SetAttribute("checked", "checked");
		}
	}
}
