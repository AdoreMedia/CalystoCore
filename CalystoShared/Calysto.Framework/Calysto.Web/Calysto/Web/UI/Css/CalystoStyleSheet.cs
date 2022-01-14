using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Calysto.Linq;
using Microsoft.Ajax.Utilities.Css2;

namespace Calysto.Web.UI.Css
{
	public class CalystoStyleSheet : ICalystoCssItem
	{
		/* extension .ice.css
		 * define variables with 2 underscores, variables will be replaced in css:
		__transitionDuration = 400ms;
		__menuBlueDark = #0097CF;
		__menuBlueMiddle = #07A1D9;
		__menuBlueLight = #00ADEE;
		__menuGrayDark = #B0B0B0;
		 
		 * inheritance, use __apply(className or selector) inside other class body, it will add content from className or selector:
		 * .className{font-size:10px;}
		 * .class1{color:red;}
		 * input {
		 *			__apply(.className, .class1, class3);
		 *			margin:10px;
		 *			padding:10px;
		 *	}
		 * 
		 */

		// rx variables: __name = ...;
		static Regex _rxVariables = new Regex("(?<name>((__)|([\\$][\\$]))[\\w]+)[\\s]*\\=[\\s]*(?<value>[^\\r\\n\\;]*);");
		
		// rx functions: __apply(...);
		static Regex _rxFuncs = new Regex("(?<func>((__)|([\\$][\\$]))[\\w]+)[\\s]*[\\(][\\s]*(?<value>[^\\(\\)]*)[\\s]*[\\)][\\s]*;");

		//static Regex _rxClassStyle = new Regex("(?<selector>[^{};]+){(?<style>[^{}]*)}");
		static Regex _rxClassStyle = new Regex("(@media(?<mediaRule>[^{}]+){)|(?<selector>[^{};]+)({(?<style>[^{}]*)})|(?<ruleEnd>[\\s]*[}])");

		private static List<CalystoCssClass> ParseCssCode(string cssCode)
		{
			// pack it to remove all comments
			string minimizedCss = CssMinifier.Minify(cssCode, MinifyModeEnum.Minify);

			// extract template variables and replace in whole text
			var matches = _rxVariables.Matches(cssCode).Cast<Match>().ForEach(o=>
			{
				minimizedCss = minimizedCss.Replace(o.Groups["name"].Value, o.Groups["value"].Value);
			});

			List<CalystoCssClass> list = new List<CalystoCssClass>();

			Stack<string> ruleStack = new Stack<string>();

			// parse style values
			_rxClassStyle.Matches(minimizedCss).Cast<Match>().ForEach(m =>
			{
				string rule = m.Groups["mediaRule"].Value.Trim();
				if(!string.IsNullOrEmpty(rule))
				{
					ruleStack.Push(rule);
					return;
				}
				
				if(m.Groups["ruleEnd"].Success)
				{
					if (ruleStack.Any())
					{
						ruleStack.Pop();
					}
					return;
				}
				string mediaRule = ruleStack.Any() ? ruleStack.Peek() : null;

				string names = m.Groups["selector"].Value;
				string values = m.Groups["style"].Value;

				//System.IO.File.AppendAllText("d:\\css.css", names + "::: " + values + "\r\n");

				var matches1 = _rxFuncs.Matches(values).Cast<Match>().ToList();
				// extract __apply(...) and replace with classes styles which are aready defined
				matches1.ForEach(fn=>{
					//string funcName = fn.Groups["func"].Value;
					List<string> clsnames = fn.Groups["value"].Value.Split(',').Select(o => o.Trim()).Where(o => !string.IsNullOrEmpty(o)).ToList();
					// search already existing classes and make replacement
					var found = list.Where(o=>clsnames.Any() && o.MediaRule == mediaRule && o.ClassNames.Intersect(clsnames, a=>a, b=>b).Any()).ToList();
					if(!found.Any())
					{
						throw new Exception("No previous definition for any of class names: " + clsnames.ToStringJoined(", "));
					}
					else
					{
						found.ForEach(k=>
						{
							values = values.Replace(fn.Value, found.Select(h=>h.GetStyleString()).ToStringJoined());
						});
					}
				});

				// if one class has multiple names: .myone, div.tree, a:hover { ... }
				list.Add(new CalystoCssClass(names.Split(',').Select(o => o.Trim()).Where(o => !string.IsNullOrEmpty(o)).ToList(),
					new CalystoStyleCollection(CalystoWebTools.ParseCssStyleValues(values))) { MediaRule = mediaRule}
					);
			});

			return list;
		}

		private List<ICalystoCssItem> _items = new List<ICalystoCssItem>();

		public IEnumerable<ICalystoCssItem> AsEnumerable()
		{
			return _items.AsEnumerable();
		}

		public CalystoStyleSheet AddCss(string cssCode)
		{
			List<CalystoCssClass> parsedCss = ParseCssCode(cssCode);
			parsedCss.ForEach(o => _items.Add(o));
			return this;
		}

		public CalystoStyleSheet Add(params ICalystoCssItem[] items)
		{
			items.ForEach(o => _items.Add(o));
			return this;
		}

		public string ToCssString()
		{
			StringBuilder sb = new StringBuilder();
			string currentMediaRule = null;

			foreach(ICalystoCssItem item in this._items)
			{
				if(item is CalystoCssClass)
				{
					CalystoCssClass cc = (CalystoCssClass)item;

					if(currentMediaRule != cc.MediaRule)
					{
						if(currentMediaRule != null)
						{
							// end current media rule block
							sb.AppendLine("}");
							currentMediaRule = null;
						}

						if(cc.MediaRule != null)
						{
							// start new media rule block
							currentMediaRule = cc.MediaRule;
							sb.AppendLine("@media " + cc.MediaRule + "\r\n{");
						}
					}

					sb.AppendLine(cc.GetCssRuleString());
				}
				else
				{
					sb.AppendLine(item.ToCssString());
				}
			}

			if(currentMediaRule != null)
			{
				// end curret media rule block
				sb.AppendLine("}");
			}
			
			return sb.ToString();
		}

		public static CalystoStyleSheet Parse(string cssCode)
		{
			return new CalystoStyleSheet().AddCss(cssCode);
		}

		/// <summary>
		/// All items, including items inside MediaRules.
		/// </summary>
		/// <returns></returns>
		public IEnumerable<ICalystoCssItem> Items()
		{
			foreach (ICalystoCssItem o in _items)
			{
				yield return o;
			}
		}

		public CalystoStyleSheet Clone()
		{
			return new CalystoStyleSheet() { _items = this._items.Select(o => o.Clone()).ToList() };
		}


		ICalystoCssItem ICalystoCssItem.Clone()
		{
			return this.Clone();
		}

		/// <summary>
		/// May return multiple items
		/// </summary>
		/// <param name="className"></param>
		/// <returns></returns>
		public IEnumerable<CalystoCssClass> FindByClassName( string className)
		{
			return CalystoCssClass.SplitClassNames(className)
				.SelectMany(cls => this.Items().OfType<CalystoCssClass>().Where(o => o.ClassNames.Contains(cls)));
		}

		public CalystoStyleSheet NewCssClass(string className, string baseClass, Action<CalystoCssClass> c) 
		{
			CalystoCssClass cls = new CalystoCssClass(className);
			this.FindByClassName(baseClass).ForEach(o => cls.ApplyClass(o));
			this.Add(cls);
			if (c != null)
			{
				c(cls);
			}
			return this;
		}

		public CalystoStyleSheet NewCssClass(string className, Action<CalystoCssClass> c) 
		{
			CalystoCssClass cls = new CalystoCssClass(className);
			this.Add(cls);
			c(cls);
			return this;
		}

		public CalystoStyleSheet NewPlainText(string text) 
		{
			CalystoPlainCssText p = new CalystoPlainCssText(text);
			this.Add(p);
			return this;
		}

		////public CalystoStyleSheet NewMediaRule(string mediaDesc, Action<CalystoMediaRule> m) 
		////{
		////	CalystoMediaRule rule = new CalystoMediaRule(mediaDesc);
		////	this.Add(rule);
		////	m(rule);
		////	return this;
		////}

		////public CalystoStyleSheet NewMediaScreenRule(Expression<Func<CalystoMediaRule.MediaScreenSettings, bool>> predicate, Action<CalystoMediaScreenRule> m) 
		////{
		////	CalystoMediaScreenRule rule = new CalystoMediaScreenRule(predicate);
		////	this.Add(rule);
		////	m(rule);
		////	return this;
		////}
	}
}
