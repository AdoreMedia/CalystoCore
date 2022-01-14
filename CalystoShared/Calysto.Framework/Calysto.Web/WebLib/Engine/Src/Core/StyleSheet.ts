namespace Calysto
{
	interface CalystoCSSStyleRule extends CSSStyleRule
	{
		selectorArray: string[];
		selectorDic: Calysto.Dictionary<string, boolean>;
	}

	export class CalystoStyleSheet
	{
		constructor()
		{
			this.sheets = [];
		}

		private sheets: CSSStyleSheet[];

		private disabledPrefix = "-calysto-disabled-rule-";

		public Sheets()
		{
			if (!this.sheets)
			{
				var s = Calysto.ScriptLoader.LoadCSS("");
				s["disabled"] = true;
				this.sheets = [<CSSStyleSheet>s.sheet];// s must be in DOM, else s.sheet is null
			}
			return this.sheets;
		}

		/**
		 * Select rules by cssSelector. Will select disabled rules too.
		 * @param cssSelector
		 */
		public SelectRules(cssSelector?: string): CalystoEnumerable<CalystoCSSStyleRule>
		{
			/// <summary>
			/// Select rules by cssSelector. Will select disabled rules too.
			/// </summary>
			/// <param name="cssSelector" optional="true" type="string">If not set, will select all rules.</param>

			var dicProp = this.disabledPrefix + (cssSelector == "*" ? "" : cssSelector);

			type DicType = Calysto.Dictionary<string, boolean>;

			return this.Sheets().AsEnumerable()
				.SelectMany(sheet => <CalystoCSSStyleRule[]><any>sheet.cssRules)
				.Where(o => !!o.selectorText)
				.Select(rule =>
				{
					if (!rule.selectorArray)
					{
						rule.selectorArray = rule.selectorText.split(",").AsEnumerable().Select(o => o.Trim()).ToArray();
						rule.selectorDic = rule.selectorArray.AsEnumerable().ToDictionary(o => o, o => <boolean> true);
					}
					return rule;
				})
				.Where(rule =>
				{
					if (cssSelector)
					{
						return rule.selectorDic.ContainsKey(cssSelector) || rule.selectorDic.ContainsKey(dicProp);
					}
					else
					{
						return true;
					}
				});
		}

		private GetIndex(cssRules: CSSStyleRule[], rule: CSSStyleRule)
		{
			for (var n = 0; n < cssRules.length; n++)
			{
				if (cssRules[n] == rule)
				{
					return n;
				}
			}
			return -1;
		}

		private DeleteRule(rule: CSSStyleRule)
		{
			if (rule.parentStyleSheet)
				rule.parentStyleSheet.deleteRule(this.GetIndex(<CSSStyleRule[]><any>rule.parentStyleSheet.cssRules, rule));
		}

		/**
		 * new rule will not have .selectorArray, so new selectorDic will be created to on next .Rules() invocation
		 * @param rule
		 */
		private RecreateRule(rule: CalystoCSSStyleRule)
		{
			/// <summary>
			/// new rule will not have .selectorArray, so new selectorDic will be created to on next .Rules() invocation
			/// </summary>
			/// <param name="rule" type="CSSStyleRule"></param>

			// since selectorText can't be modified on firefox, we have to delete current rule and create new at the same index position
			var sheet = rule.parentStyleSheet;
			if ( sheet )
			{
				var style = rule.style.cssText;
				var index = this.GetIndex( <CSSStyleRule[]><any>sheet.cssRules, rule );
				var newSelector = rule.selectorArray.join( ", " );
				if ( newSelector )
				{
					sheet.insertRule( newSelector + "{" + style + "}", index );
				}
			}
		}

		/**
		 * Split multiple selectors. Create  new rule for each single selector
		 * @param cssSelector
		 */
		public SplitSelectors(cssSelector: string)
		{
			/// <summary>
			/// Split multiple selectors. Create  new rule for each single selector.
			/// </summary>
			/// <param name="cssSelector" type="string" optional="true">If not set, will select all rules.</param>

			this.SelectRules(cssSelector).ForEach(rule =>
			{
				(<string[]>(<any>rule).selectorArray).AsEnumerable().ForEach(selector=>
				{
					(<any>rule).selectorDic = null;
					(<any>rule).selectorArray = [selector];
					this.RecreateRule(rule);
				});
				this.DeleteRule(rule);
			});
			return this;
		}

		/**
		 * Add new selector to existing rule.
		 * @param cssSelector
		 * @param newSelector
		 */
		public AddSelector(cssSelector: string, newSelector: string)
		{
			/// <summary>
			/// Add new selector to existing rule.
			/// </summary>
			/// <param name="cssSelector">rule with existing selector</param>
			/// <param name="newSelector">new selector to be added to rule</param>

			if (newSelector)
			{
				this.SelectRules()
					.Where(rule => rule.selectorDic.ContainsKey(cssSelector) && !rule.selectorDic.ContainsKey(newSelector))
					.ForEach(rule =>
					{
						rule.selectorArray.push(newSelector);
						// since selectorText can't be modified on FF, we have to replace current rule with new one with different selector
						this.RecreateRule(rule);
						this.DeleteRule(rule);
					});
			}
			return this;
		}

		/**
		 * Remove cssSelector from rule, but leave rule with other selectors. If there is not more selectors left, will delete rule too.
		 * @param cssSelector
		 */
		public RemoveSelector(cssSelector: string)
		{
			/// <summary>
			/// Remove cssSelector from rule, but leave rule with other selectors. If there is not more selectors left, will delete rule too.
			/// </summary>
			/// <param name="cssSelector"></param>

			this.SelectRules(cssSelector)
				.ForEach(rule =>
				{
					rule.selectorArray = rule.selectorArray.AsEnumerable().Where(k => k != cssSelector).ToArray();
					// since selectorText can't be modified on FF, we have to replace current rule with new one with different selector
					this.RecreateRule(rule);
					this.DeleteRule(rule);
				});
			return this;
		}

		public AddRule(cssSelector: string, style: string)
		{
			/// <summary>
			/// Create new rule and add to rules.
			/// </summary>
			/// <param name="cssSelector"></param>
			/// <param name="style"></param>

			var sheets = this.Sheets();
			var current = sheets[sheets.length - 1];
			if (current.addRule)
			{
				current.addRule(cssSelector, style);
			}
			else if (current.insertRule)
			{
				// firefox specific
				// myStyle.insertRule(css, index);
				// myStyle.insertRule("#blanc { color: white }", 0);
				current.insertRule(cssSelector + "{" + style + "}", current.cssRules.length); // add to the end
			}
			return this;
		}

		public RemoveRules(cssSelector: string)
		{
			/// <summary>
			/// Remove complete rule from sheet where cssSelector exists.
			/// </summary>
			/// <param name="cssSelector"></param>

			this.SelectRules(cssSelector).ForEach(rule =>
			{
				if ( rule.parentStyleSheet )
					rule.parentStyleSheet.deleteRule(this.GetIndex(<CalystoCSSStyleRule[]><any>rule.parentStyleSheet.cssRules, rule));
			});
			return this;
		}

		public DisableRules(cssSelector: string)
		{
			/// <summary>
			/// Disable rules by cssSelector.
			/// </summary>
			/// <param name="cssSelector" optional="true" type="string">If not set, will disable all rules.</param>

			this.SelectRules(cssSelector).ForEach(rule =>
			{
				rule.selectorArray = rule.selectorArray.AsEnumerable().Select(k =>
				{
					if (!cssSelector || k == cssSelector)
					{
						if (k.indexOf(this.disabledPrefix) == 0)
						{
							return k;
						}
						else
						{
							// * at the end is not acceptable for .selectorText, use prefix only
							return this.disabledPrefix + (k == "*" ? "" : k);
						}
					}
					else
					{
						return k;
					}
				}).ToArray();

				this.RecreateRule(rule);
				this.DeleteRule(rule);
			});
			return this;
		};

		public EnableRules(cssSelector: string)
		{
			var dicProp = this.disabledPrefix + (cssSelector == "*" ? "" : cssSelector);

			this.SelectRules(cssSelector).ForEach(rule =>
			{
				rule.selectorArray = rule.selectorArray.AsEnumerable().Select(k =>
				{
					if (!cssSelector)
					{
						return k.replace(this.disabledPrefix, "") || "*";
					}
					else if (k == dicProp)
					{
						return cssSelector;
					}
					else
					{
						return k;
					}
				}).ToArray();

				this.RecreateRule(rule);
				this.DeleteRule(rule);
			});
			return this;
		}

		public ToCssText(separator)
		{
			/// <summary>
			/// 
			/// </summary>
			/// <param name="separator" type="string"></param>
			return this.SelectRules().Select(o => o.cssText).ToStringJoined(separator || "");
		}

		/**
		 * Get all sheets from current document
		 */
		public static GetCurrent()
		{
			if (document.styleSheets.length == 0)
			{
				Calysto.ScriptLoader.LoadCSS("");
			}
			var ss = new CalystoStyleSheet();
			ss.sheets = [];
			for (let n = 0; n < document.styleSheets.length; n++)
			{
				ss.sheets.push(<CSSStyleSheet><any>document.styleSheets[n]);
			}
			return ss;
		}
	}
}

