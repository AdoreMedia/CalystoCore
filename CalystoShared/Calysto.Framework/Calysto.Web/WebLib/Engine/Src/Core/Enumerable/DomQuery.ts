namespace Calysto
{
	type CallbackDelegate<TSender> = (sender: TSender, ev: Event) => void | boolean | undefined;

	type MouseCallbackDelegate<TSender> = (sender: TSender, ev: MouseEvent) => void | boolean | undefined;

	type KeyboardCallbackDelegate<TSender> = (sender: TSender, ev: KeyboardEvent) => void | boolean | undefined;

	//#region Helper functions

	function attrPredicateFunc(el, attrName, attrSign, attrValue)
	{
		// currentValue: current attribute value
		// attrValue: expected attribute value

		// attrSign is comparison operator: =, !=, ==, etc.

		if (!attrSign)
		{
			// eg. [calysto-id] meaning if has value, function el.getAttribute returns null if there is no attribute, but it should be used hasAttribute()
			return Calysto.Utility.Dom.HasAttribute(el, attrName);
		}

		var currValue = Calysto.Utility.Dom.GetAttribute(el, attrName) || ""; // if attribute doesn't exsits, GetAttribute returns null

		var m = attrSign;

		if (!m)
		{
			// the same as =*
			// no attr sign, statement [attrName] means has attribute value, doesn't matter which value is
			return !!(currValue);
		}
		else if (m == "=" || m == "==")
		{
			return (currValue == attrValue);
		}
		else if (m == "=*")
		{
			// has any value, but not empty
			return !!(currValue);
		}
		else if (m == "~=") // E[foo~="warning"]	Matches any E element whose "foo" attribute value is a list of space-separated values, one of which is exactly equal to "warning"
		{
			return ((" " + currValue + " ").indexOf(" " + attrValue + " ") >= 0);
		}
		else if (m == "*=") // contains value
		{
			return (currValue.indexOf(attrValue) >= 0);
		}
		else if (m == "^=") // starts with
		{
			return (currValue.indexOf(attrValue) == 0);
		}
		else if (m == "$=") // ends with
		{
			var index = currValue.lastIndexOf(attrValue);
			return ((index + attrValue.length) == currValue.length);
		}
		else if (m == "!=" || m == "<>")
		{
			return (currValue != attrValue);
		}
		else //// if (currValue && attrValue) // <, >, <=, >=, % etc
		{
			var num1 = Calysto.Type.NumberConverter.ToNumberOrDefault(currValue, NaN, "."); // current attribute value
			var num2 = Calysto.Type.NumberConverter.ToNumberOrDefault(attrValue, NaN, "."); // expected value

			if (!Calysto.Type.TypeInspector.IsNumber(num1) || !Calysto.Type.TypeInspector.IsNumber(num2))
			{
				return false;
			}

			switch (m)
			{
				case "<": return num1 < num2;
				case ">": return num1 > num2;
				case ">=": return num1 >= num2;
				case "<=": return num1 <= num2;
			}

			// unknown selector
			throw new Error("Unsupported calystoSelector (" + (attrName + ", " + attrSign + ", " + attrValue) + ") in Calysto.DomQuery.BuildLambdaExpression #2");
		}
	}

	function CreateAttributeQuery(source, attrName, attrSign, attrValue)
	{
		var func = (function (attrName, attrSign, attrValue)
		{
			return (function (el)
			{
				return attrPredicateFunc(el, attrName, attrSign, attrValue);
			});

		})(attrName, attrSign, attrValue);

		return source.Where(function (o) { return func(o); });
	}

	function CreateIdQuery(source, id)
	{
		return source.Where(function (o) { return !!o && !!id && (o.id == id || Calysto.Utility.Html.ExtractAspNameOrId(o.id) == id || (!!o.getAttribute && o.getAttribute("id") == id)) });
	}

	function CreateClassQuery(source, className)
	{
		return source.Where(function (o) { return Calysto.Utility.Dom.HasClass(o, className); });
	}

	function CreateTagQuery(source, tag)
	{
		return source.Where(function (o) { return Calysto.Utility.Dom.HasTagName(o, tag); });
	}

	function CreateColonWordQuery<TElement extends HTMLElement>(source: DomQuery<TElement>, colonWord: string, colonValue: string): DomQuery<TElement>
	{
		var count = parseInt(colonValue, 10) || 1;

		switch (colonWord)
		{
			case "visible":
				return source.WhereVisible(true); // specific for JS query only
			case "invisible":
			case "hidden":
				return source.WhereVisible(false); // specific for JS query only
			case "first":
			case "take":
				return source.Take(count);
			case "last":
				return source.Reverse().Take(count).Reverse();
			case "skip":
				return source.Skip(count);
			case "exact":
				return source.Exact(count).AsDomQuery();
			case "is":
			case "not":
				// select elements from source where subquery in :is(subquery) is true or :not(subquery) is false, input to subquery is each element from source query
				// $('div//*:not(span)'), select div's descendants, except span, '*' can be removed
				// $(".firstquery...").Query(":not(a>span, .cls1>>div)") or .Query(":not(a>span), :not(.cls1>>div)"), // select all items from first query where item is not "a" with child "span" and item with class 'cls' has no 2nd child 'div'
				// $(".firstquery...").Query(":is(a>span)"), // select all items from first query where item is "a" with child "span"
				// $(".firstquery...").Query(":is(*>span)"), // * is optional: .Query(":is(>span)") select all items from first query where item has child "span"
				return source.Where(o => DomQuery.FromArray([o]).Query(colonValue).Any() == (colonWord == "is"));
			////case "has":
			////case "hasnot":
			//// OBSOLETE: use :is or :not instead since "is" or "not" is much more sophisticated version than this crappy jQuery.has(...)
			////	// The expression $('div:has(p)') matches a <div> if a <p> exists anywhere among its descendants, not just as a direct child.
			////	var doesHave = colonWord == "has";
			////	return source.Where(function (o) { return new source._typeCtor([o]).DescendantNodes().Query(colonValue).Any() == doesHave; });
			case "reverse":
				return source.Reverse();
			case "ancestor":
				return source.AncestorNodes<TElement>();
			case "descendant":
				return source.DescendantNodes<TElement>();
			case "child":
				return source.ChildNodes<TElement>();
			case "parent":
				return source.ParentNodes<TElement>();
			case "next-sibling":
				return source.NextSiblings<TElement>();
			case "previous-sibling":
				return source.PreviousSiblings<TElement>();
			default:
				throw new Error("Unsupported calystoSelector: " + colonWord + "(" + colonValue + ")");
		}
	}

	function GetAncestors(node)
	{
		var items: HTMLElement[] = [];
		while (node.parentNode)
		{
			items.push(node.parentNode);
			node = node.parentNode;
		}
		return items;
	}

	var dimMap = {
		absoluteTop: NaN,
		absoluteLeft: NaN,
		position: "",
		top: NaN,
		right: NaN,
		bottom: NaN,
		left: NaN,
		width: NaN,
		height: NaN,
		minWidth: NaN,
		minHeight: NaN,
		maxWidth: NaN,
		maxHeight: NaN,
		clientLeft: NaN,
		clientTop: NaN,
		clientWidth: NaN,
		clientHeight: NaN,
		offsetLeft: NaN,
		offsetTop: NaN,
		offsetWidth: NaN,
		offsetHeight: NaN,
		scrollLeft: NaN,
		scrollTop: NaN,
		scrollWidth: NaN,
		scrollHeight: NaN,
		paddingTop: NaN,
		paddingRight: NaN,
		paddingBottom: NaN,
		paddingLeft: NaN,
		marginTop: NaN,
		marginRight: NaN,
		marginBottom: NaN,
		marginLeft: NaN,
		borderTop: NaN,
		borderRight: NaN,
		borderBottom: NaN,
		borderLeft: NaN
	};

	function SetOffsetDimensions(element: Node, offsetWidth: number | null, offsetHeight: number | null)
	{
		var el: any = element;

		if (!Calysto.Utility.Dom.IsElementVisible(el))
		{
			return;
		}

		if (typeof (offsetWidth) == "number" && Calysto.Type.TypeInspector.IsNumber(offsetWidth))
		{
			// IE fix: button is not mesured correctly with GetComputedStyle(), so set offsetHeigth as style, and test if values are equal
			el.style.width = offsetWidth + "px";

			if (el.offsetWidth != offsetWidth)
			{
				var currStyleWidth = Calysto.Utility.Dom.Style.GetComputedStyle(el, "width").NumericValue;
				var w1 = offsetWidth - (el.offsetWidth - (currStyleWidth || 0));
				el.style.width = w1 + "px";
			}
		}

		if (typeof (offsetHeight) == "number" && Calysto.Type.TypeInspector.IsNumber(offsetHeight))
		{
			// IE fix: button is not mesured correctly with GetComputedStyle(), so set offsetHeigth as style, and test if values are equal
			el.style.height = offsetHeight + "px";

			if (el.offsetHeight != offsetHeight)
			{
				var currStyleHeight = Calysto.Utility.Dom.Style.GetComputedStyle(el, "height").NumericValue;
				var h1 = offsetHeight - (el.offsetHeight - (currStyleHeight || 0));
				el.style.height = h1 + "px";
			}
		}
	}

	function GetTextValueOnly(node: Element, ignoreCase: boolean)
	{
		var txt = (<any>node).tagName || "";
		// get start tag text and node value if exists

		if (node.attributes && node.attributes.length > 0)
		{
			for (var n = 0; n < node.attributes.length; n++)
			{
				var attr = node.attributes[n];
				txt += " " + attr.name + "=\"" + attr.value + "\"";
			}
		}

		if (node.nodeValue)
		{
			if (txt && txt.length > 0)
			{
				txt += " ";
			}
			txt += node.nodeValue;
		}

		return ignoreCase ? txt.toLowerCase() : txt;
	}

	function CssClass<TElement>(source: DomQuery<TElement>, method: string, cssClass: string): DomQuery<TElement>
	{
		return source.ForEach(function (item, index)
		{
			Calysto.Utility.Dom[method](item, cssClass);
		});
	}

	var transforms = ["transform", "-ms-transform", "-webkit-transform"];

	function GetHoverCB(isHover, callbackFunc)
	{
		return (function (sender, ev)
		{
			if (Calysto.Event.IsHoverChanged(sender, ev, isHover))
			{
				// enter or exit
				return callbackFunc.call(sender, sender, ev); // this is element
			}
		});
	}

	function GetTriggCountCB(triggCountMax, callbackFunc)
	{
		var count = 0;
		return (function (sender, ev)
		{
			var ret;
			ev = ev || window.event; // old IE doesn't send event
			if (count < triggCountMax)
			{
				count++;
				ret = callbackFunc.call(sender, sender, ev); // this is element
			}
			// there is no state, so we can't remove event
			// it is not enough to use type and originalCallback
			return ret;
		});
	};

	function GetCBEncaps(callback)
	{
		return ((sender, ev) =>
		{
			ev = ev || window.event; // old IE doesn't send event
			var res = callback.call(sender, sender, ev); // this is element
			if (res === false)
			{
				Calysto.Event.StopPropagation(ev, true);
			}
			else if (res === true)
			{
				Calysto.Event.StopPropagation(ev, false);
			}
			return res;
		});
	}

	/**
	 * If node already has parentNode, node will be cloned
	 * @param funcName
	 * @param currItemsArray
	 * @param contentArgsArray
	 */
	function AddOrModify(funcName: string, currItemsArray: any[], contentArgsArray: any[] | IArguments)
	{
		var allCurr = currItemsArray;
		var elarr = Calysto.Utility.Dom.ConvertToElementsArray(contentArgsArray);

		var allNew: Node[] = [];

		for (var n1 = 0; n1 < allCurr.length; n1++)
		{
			var cloned: Node[] = [];
			// elarr may be null
			for (var k = 0; elarr && k < elarr.length; k++)
			{
				// clone nodes which already has parentNode
				var el = Calysto.Utility.Dom.CloneNodeIfHasParent(elarr[k]);
				cloned.push(el);
				allNew.push(el);
			}

			// even if elarr is null, we have to call func, eg. ReplaceChildren to remove children from dom
			Calysto.Utility.Dom[funcName](allCurr[n1], cloned);
		}

		return { ThisItems: <HTMLElement[]>allCurr, NewItems: <HTMLElement[]>allNew };
	}

	function ParseXmlString(xmlDocStr)
	{
		var xmlDoc: Document;
		if ((<any>window).DOMParser)
		{
			var parser = new DOMParser();
			xmlDoc = parser.parseFromString(xmlDocStr, "text/xml");
		}
		else
		{
			// IE :(
			if (xmlDocStr.indexOf("<?") == 0)
			{
				xmlDocStr = xmlDocStr.substr(xmlDocStr.indexOf("?>") + 2);
			}
			xmlDoc = new (<any>window).ActiveXObject("Microsoft.XMLDOM");
			(<any>xmlDoc).async = false;
			(<any>xmlDoc).loadXML(xmlDocStr);
		}
		return xmlDoc;
	}

	//#endregion

	//#region PoolingState

	export class PoolingState<TItem>
	{
		public constructor(private query: DomQuery<TItem>, private intervalID: number)
		{
		}

		/**Abort pooling state for changes */
		public Abort()
		{
			clearInterval(this.intervalID);
			return this;
		}

		public AsDomQuery()
		{
			return this.query;
		}
	}

	//#endregion

	export class DomQuery<TItem> extends CalystoEnumerable<TItem>
	{
		constructor(getEnumerator: () => CalystoEnumerator<TItem>)
		{
			super(getEnumerator);
		}

		public ForEach(action: (item: TItem, index: number) => void)
		{
			return super.ForEach(action).AsDomQuery();
		}

		public Skip(count: number)
		{
			return super.Skip(count).AsDomQuery();
		}

		public Take(count: number)
		{
			return super.Take(count).AsDomQuery();
		}

		public SkipWhile(predicate: (item: TItem, index: number) => boolean)
		{
			return super.SkipWhile(predicate).AsDomQuery();
		}

		public Reverse()
		{
			return super.Reverse().AsDomQuery();
		}

		public Where(predicate: (item: TItem, index: number) => boolean)
		{
			return super.Where(predicate).AsDomQuery();
		}

		public Select<TNew>(selector: (item: TItem, index: number) => TNew)
		{
			return super.Select(selector).AsDomQuery();
		}

		public Cast<TNew>()
		{
			return <DomQuery<TNew>>(<any>this);
		}

		public SelectMany<TNew>(selector?: (item: TItem) => TNew[] | CalystoEnumerable<TNew>)
		{
			return super.SelectMany(selector).AsDomQuery();
		}

		public Distinct<TKey>(keySelector?: (item: TItem) => TKey)
		{
			return super.Distinct(keySelector).AsDomQuery();
		}

		private selectFilteredSingle(source: DomQuery<any>, calystoSelector: string)
		{
			let origsrc = source;
			let newsrc = source;

			let selector1 = calystoSelector
				.replace(new RegExp("['\"]", "ig"), "") // remove ' and "
				.replace(new RegExp("(^[\\s]+)|([\\s]+$)", "ig"), "") // trim spaces from start and end of string
				.replace(new RegExp("([ ]*)([\\/\\<\\>\\!\\~\\^\\$\\*\\=]+)([ ]*)", "ig"), "$2") // remove spaces arround special chars
				.replace(new RegExp("[ ]+"), " "); // replace multiple spaces with single space

			let sett, ch, mm;

			let reader = new Calysto.SelectorReader(selector1);

			while (ch = reader.Pop())
			{
				if (ch == '#' && (mm = reader.PopMatch(new RegExp("^([\\w\\-_]+)"))))
				{
					// #id
					newsrc = CreateIdQuery(newsrc, mm[1]);
				}
				else if (ch == '.' && (mm = reader.PopMatch(new RegExp("^([\\w\\-_]+)"))))
				{
					// .class
					newsrc = CreateClassQuery(newsrc, mm[1]);
				}
				else if (ch == ' ')
				{
					// descendant
					newsrc = newsrc.DescendantNodes();
				}
				else if (ch == '/' && reader.Peek() == '/' && reader.Peek(1) != '/') // descendants, double //
				{
					// descendant
					reader.Pop(); // pop next / too
					newsrc = newsrc.DescendantNodes();
				}
				else if (ch == '*')
				{
					newsrc = newsrc.Select(o => o); // must create select if the only statement is "*", this way we return all, not empty collection
				}
				else if (ch == '^') // ancestors, Calysto specific
				{
					newsrc = newsrc.AncestorNodes();
				}
				else if (ch == '<') // parent, << will create 2 times: .ParentNodes().ParentNodes()
				{
					newsrc = newsrc.ParentNodes();
				}
				else if (ch == '>') // children, eg. >>> wil create 3 times .ChildNodes().ChildNodes().ChildNodes()
				{
					newsrc = newsrc.ChildNodes();
				}
				else if (ch == '/' && reader.Peek() != '/') // children, x-path first level children
				{
					newsrc = newsrc.ChildNodes();
				}
				else if (ch == ':' && (mm = reader.PopMatch(new RegExp("^([\\w\\-_]+)([\\(]([^\\)]*)[\\)])*"))))
				{
					// special attribute, eg. :take(10), :first, :first(5)
					newsrc = CreateColonWordQuery(newsrc, mm[1], mm[3]);
				}
				else if (ch == '[' && (mm = reader.PopMatch(new RegExp("^[ ]*([\\w\\-_]+)" + "[ ]*" + "([<>\\!\\=\\~\\^\\$\\*]*)" + "[ ]*" + "((([^\\[\\]])*(\\[\\d+\\])*)*)" + "[ ]*" + "\\]"))))
				{
					// attribute value may have indexed property: TransakcijskiRacuni[4].IBAN[1].dva[3].nesto
					//"name=TransakcijskiRacuni[4].IBAN[1].dva[3].nesto][color=blue]".match(new RegExp("^[ ]*([\\w\\-_]+)" + "[ ]*" + "([<>\\!\\=\\~\\^\\$\\*]*)" + "[ ]*" + "((([^\\[\\]])*(\\[\\d+\\])*)*)" + "[ ]*" + "\\]"))

					// '[attribute="value"]' // '[attribute == "value"]' // // '[attribute != "value"]' // '[attribute >= value]'
					newsrc = CreateAttributeQuery(newsrc, mm[1], mm[2], mm[3]);
				}
				else if ((mm = reader.PopMatch(new RegExp("^([\\w\\-_]+)"), -1))) // origin -1 to include current ch in match
				{
					// tag name
					newsrc = CreateTagQuery(newsrc, mm[1]);
				}
				else
				{
					// unknown
					throw new Error("Unsupported calystoSelector (" + (selector1) + ")");
				}
			}

			// if newsrc == origsrc, nothing was selected by calystoSelector, return an empty eneumerable
			if (newsrc == origsrc)
			{
				newsrc = DomQuery.FromArray<any>([]);
			}
			return newsrc;
		}

		/**
			Operates on current document.all and select elements by calystoSelector as document.all.Query(args).
		 * @param calystoSelector lambda or css calystoSelector:
TAG name: html, body, span, a, ...
ID: #idvalue...
CLASS: .mydiv, a.mydiv...
ATTRIBUTES: [name] (contains attribute), [name=value], [name &gt; value], ==, =, <, >, !=, <>, [name*=value] (contains value), [name^=value] (starts with value), [name$=value] (ends with value)...
TRAVERSING: * (all), space or // (descendants), / (children), ^ (ancestors), >>> (n-th level children), << (n-th level parent) :first(n) :last(n) :skip(n) :take(n) :reverse() :exact(n), with or without (n), if there is no (n), default n == 1
Element state: :hidden, :visible
X-path: :ancestor :descendant :child :parent :next-siblings :previous-siblings
		 */
		public Query<TElement extends HTMLElement>(calystoSelector?: string): DomQuery<TElement>
		{
			return this.QueryWorker(calystoSelector).Cast<TElement>().AsDomQuery();
		}

		/**
		 * Filter current items by calystoSelector.
		 * @param calystoSelector lambda or css calystoSelector:
TAG name: html, body, span, a, ...
ID: #idvalue...
CLASS: .mydiv, a.mydiv...
ATTRIBUTES: [name] (contains attribute), [name=value], [name &gt; value], ==, =, <, >, !=, <>, [name*=value] (contains value), [name^=value] (starts with value), [name$=value] (ends with value)...
TRAVERSING: * (all), space or // (descendants), / (children), ^ (ancestors), >>> (n-th level children), << (n-th level parent) :first(n) :last(n) :skip(n) :take(n) :reverse() :exact(n), with or without (n), if there is no (n), default n == 1
Element state: :hidden, :visible
X-path: :ancestor :descendant :child :parent :next-siblings :previous-siblings
		 */
		private QueryWorker(calystoSelector?: string): CalystoEnumerable<any>
		{
			if (!calystoSelector)
			{
				// we should create new instance maybe
				return this;
			}

			var source = this;

			if ((typeof (calystoSelector) == "string" && calystoSelector.indexOf("=>") > 0) || typeof (calystoSelector) == "function")
			{
				// already is lambda expression or function
				let fn1 = Calysto.Utility.Expressions.CompileLambdaExpression(calystoSelector);
				return source.Where(<any>fn1);
			}

			// *********************************************************
			// multiple calystoSelector processor
			// split by comma, but do not split by comma inside (...), eg. :not(div, a, body)
			var calystoSelectorsArr: string[] = [];
			var currPart = "";
			var digCount = 0;
			for (var n = 0; n < calystoSelector.length; n++)
			{
				var ch = calystoSelector.charAt(n); // IE8 and older requires charAt
				if (ch == ')')
				{
					digCount--;
					currPart += ch;
				}
				else if (ch == '(')
				{
					digCount++;
					currPart += ch;
				}
				else if (ch == ',' && digCount == 0)
				{
					// split
					calystoSelectorsArr.push(currPart);
					currPart = "";
				}
				else
				{
					currPart += ch;
				}
			}

			if (currPart.length > 0)
			{
				calystoSelectorsArr.push(currPart);
			}

			////var calystoSelectorsArr = calystoSelector.split(","); //  " body5 div.noa, form div[id='asdc'], body div#Div1.klasa, div.collapsed.expanded,  ";
			if (calystoSelectorsArr.length > 1)
			{
				var newSources: DomQuery<TItem> = <any>null;

				for (var n = 0; n < calystoSelectorsArr.length; n++)
				{
					var sel = calystoSelectorsArr[n].replace(new RegExp("((^[ ,]+)|([ ,]+$))", "ig"), ""); // tim chars
					if (sel != null && sel != "")
					{
						var tmpnewsrc: DomQuery<TItem> = this.selectFilteredSingle(source, sel);
						if (!newSources)
						{
							newSources = tmpnewsrc;
						}
						else
						{
							newSources = <DomQuery<TItem>>newSources.Concat(tmpnewsrc);
						}
					}
				}
				return newSources;
			}
			else
			{
				return <DomQuery<TItem>>this.selectFilteredSingle(source, calystoSelector);
			}
			// *********************************************************
		}

		/**
		 * Parent nodes only.
		 * @param calystoSelector lambda or css calystoSelector
		 */
		public ParentNodes<TElement extends HTMLElement>(calystoSelector?: string)
		{
			return this
				.Where(o => !!(<any>o).parentNode)
				.Select(o => (<any>o).parentNode)
				.Query<TElement>(calystoSelector);
		}

		/**
		 * All ancestors.
		 * @param calystoSelector lambda or css calystoSelector
		 */
		public AncestorNodes<TElement extends HTMLElement>(calystoSelector?: string)
		{
			return this
				.SelectMany(function (o) { return GetAncestors(o); })
				.Select(o => <TElement><any>o)
				.Query<TElement>(calystoSelector);
		}

		/**
		 * Child nodes only,
		 * @param calystoSelector lambda or css calystoSelector
		 */
		public ChildNodes<TElement extends HTMLElement>(calystoSelector?: string)
		{
			return this
				.Where(o => (<any>o).childNodes && (<any>o).childNodes.length > 0) // text nodes doesn't have childNodes property
				.SelectMany(o => (<any>o).childNodes)
				.Query<TElement>(calystoSelector);
		}

		private getDescendants(curr: HTMLElement)
		{
			if (curr && curr.childNodes && curr.childNodes.length > 0)
			{
				if (curr.nodeType && curr.getElementsByTagName) 
				{
					return <TItem[]><any>curr.getElementsByTagName("*"); // doesn't get text nodes, but doesn't matter, this is much faster way
				}
				else // text nodes can not be retrieved using getElementsByTagName
				{
					////throw new Error("curr.getElementsByTagName is not supported");
				}
			}
			return <TItem[]><any>null; // .SelectMany() can handle if null is returned
		}

		/**
		 * Descendant nodes.
		 * @param calystoSelector lambda or css calystoSelector
		 */
		public DescendantNodes<TElement extends HTMLElement>(calystoSelector?: string)
		{
			// return children than concat children's children

			return this
				.SelectMany(node => <any>this.getDescendants(<HTMLElement><any>node))
				.Query<TElement>(calystoSelector);
		}

		public NextSiblings<TElement extends HTMLElement>(calystoSelector?: string)
		{
			return this
				.Where(function (o) { return o && (<any>o).parentNode && (<any>o).parentNode.childNodes; })
				.SelectMany(function (o)
				{
					return DomQuery.FromArray((<any>o).parentNode.childNodes).Select(o => <TElement>o).SkipWhile(function (k) { return <any>k != o; }).Skip(1).ToArray();
				})
				.Query<TElement>(calystoSelector);
		}

		public PreviousSiblings<TElement extends HTMLElement>(calystoSelector?: string)
		{
			return this
				.Where(function (o) { return o && (<any>o).parentNode && (<any>o).parentNode.childNodes; })
				.SelectMany(function (o)
				{
					return DomQuery.FromArray((<any>o).parentNode.childNodes).Select(o => <TElement>o).TakeWhile(function (k) { return <any>k != o; }).ToArray();
				})
				.Reverse() // order nodes backward so first node in collection is first previous sibling
				.Query<TElement>(calystoSelector);
		}

		/**
		 * Case non-sensitive tagName.
		 * @param tagName
		 */
		public WhereTagName(tagName: string)
		{
			if (!tagName)
			{
				throw new Error("WhereTagName requires tagName parameter");
			}

			tagName = tagName.toLowerCase();

			return this
				.Where(function (o) { return (<any>o).tagName && (<any>o).tagName.toLowerCase() == tagName; });
		}

		/**
		 * Filter items by attribute value.
		 * @param name case non-sensitive
		 * @param predicate
		 */
		public WhereAttribute(name: string, predicate: (attrValue: string) => boolean)
		{
			if (!name)
			{
				throw new Error("WhereAttribute requires name parameter");
			}

			// o.getAttribute("name") will get attribute value
			// o.getAttributeNode("name") will get attribute node
			return this
				.Where(function (o) { return predicate(<any>Calysto.Utility.Dom.GetAttribute(<any>o, name)); });
		}

		/**
		 * Filter items by attribute.
		 * @param name attribute name
		 * @param hasIt OPTIONAL. If not set, default is true.
		 */
		public WhereHasAttribute(name: string, hasIt = true)
		{
			return this
				.Where(function (o) { return Calysto.Utility.Dom.HasAttribute(<any>o, name) == hasIt; });
		}

		/**
		 * Filter items by style value.
		 * @param name case sensitive, valid css style name, camel case or with
		 * @param predicate
		 */
		public WhereStyle(name: string, predicate: (styleValue: number) => boolean)
		{
			if (!name)
			{
				throw new Error("WhereAttribute requires name parameter");
			}

			return this
				.Where(function (o) { return predicate(Calysto.Utility.Dom.Style.GetComputedStyle(<any>o, name).NumericValue); });
		}

		/**
		 * Where attribute obj.id='id', always case-sensitive.
		 * @param idvalue Case sensitive dom element id.
		 */
		public WhereId(idvalue: string)
		{
			if (!idvalue)
			{
				throw new Error("WhereId requires id parameter");
			}

			return this
				.WhereAttribute("id", function (o) { return o == idvalue; });
		}

		/**
		 * Where contains cssClass, always case-sensitive.
		 * @param cssClass Case sensitive css class name.
		 * @param hasIt OPTIONAL. If not set, default is true.
		 */
		public WhereHasClass(cssClass: string, hasIt = true)
		{
			if (!cssClass)
			{
				throw new Error("WhereHasClass requires cssClass parameter");
			}

			return this
				.Where(function (item) { return Calysto.Utility.Dom.HasClass(<any>item, cssClass) == hasIt; });
		}

		/**
		 * Select NumericValue or StyleValue, which one is available first. Returns new Calysto.List with values.
		 * @param name style property name
		 */
		public SelectStyle(name: string)
		{
			if (!name)
			{
				throw new Error("StyleValue requires name parameter");
			}

			return this
				.Select((item) =>
				{
					var ss = Calysto.Utility.Dom.Style.GetComputedStyle(<any>item, name);
					return Calysto.Type.TypeInspector.IsNumber(ss.NumericValue) ? ss.NumericValue : ss.StyleValue;
				});
		}

		/**
		 * Select NumericValue or StyleValue, which one is available first. 
		 * Returns TMap[] with objects who's properties are array names: [{name1:value1, name2:value2}, {name1: value, name2: value}, ...].
		 * @param mapObj Object with names to be selected: {"width": null, "height": null}
		 */
		public SelectStyleMap<TMap>(mapObj: TMap)
		{
			return this
				.Select((element) =>
				{
					let obj: TMap = <any>{};

					Calysto.Collections.ForEachOwnProperties(mapObj, (name) =>
					{
						var ss = Calysto.Utility.Dom.Style.GetComputedStyle(<HTMLElement><any>element, name);
						var num = Calysto.Type.NumberConverter.ToNumberOrDefault(ss.NumericValue, NaN, ".");
						if (!Calysto.Type.TypeInspector.IsNumber(num)) num = ss.StyleValue;
						obj[name] = num;
					});
					return obj;
				});
		};

		public SelectDimensionsMap()
		{
			return this.SelectStyleMap(dimMap);
		}

		/**
		 * Set elements style.
		 * @param styleMap {marginTop: 10, "margin-left": "22%"}
		 */
		public ApplyStyleMap(styleMap: Object)
		{
			return this
				.ForEach(function (item, index)
				{
					for (var prop in styleMap)
					{
						Calysto.Utility.Dom.Style.SetStyleValue(<any>item, prop, styleMap[prop]);
					}
				});
		}

		/**
		 * Set style value. If value is eg. 20%, it will get current value first, than set 20% of current value.
		 * @param nameOrCssText cssText or style name or style map {height:10, width:20}, case sensitive style name or camelCase name
		 * @param value if cssText used, value is empty, else style value
		 */
		public ApplyStyle(nameOrCssText: string | Object, value?: string | number)
		{
			if (!nameOrCssText)
			{
				return this; // if value is "", to allow conditional eg.: doSet ? "display:none" : ""
			}

			if (arguments.length == 1)
			{
				if (typeof (nameOrCssText) == "string")
				{
					return this
						.ForEach((item: any, index) =>
						{
							if (item && item.style)
							{
								// setting cssText in style object acts as real css: uses last value and ignores previous definitions of the same style-name
								// works with all browsers
								item.style.cssText += ";" + nameOrCssText;
							}
						});
				}
				else if (typeof (nameOrCssText) == "object")
				{
					return this
						.ApplyStyleMap(<any>nameOrCssText);
				}
				else
				{
					throw new Error("Invalid argument in ApplyStyle: " + nameOrCssText);
				}
			}
			else
			{
				return this
					.ForEach(function (item, index) { Calysto.Utility.Dom.Style.SetStyleValue(<any>item, <any>nameOrCssText, value); });
			}
		};

		/**
		 * Set elements offset dimensions by recalculating and setting style values.
		 * Size may be set only if element is visible.
		 * @param offsetWidth if value not int, won't be set
		 * @param offsetHeight if value not int, won't be set
		 */
		public SetOffsetSize(offsetWidth: number | null, offsetHeight: number | null)
		{
			// table, select, button grows inside

			return this
				.ForEach(function (el)
				{
					SetOffsetDimensions(<any>el, offsetWidth, offsetHeight);
				});
		}

		/**
		 * Fit each element into it's parent. Useful for elements with padding set so style.width can not be set to 100% to fit into parent.
		 * @param fitWidth
		 * @param fitHeight
		 */
		public FitIntoParent(fitWidth: boolean, fitHeight: boolean)
		{
			return this
				.ForEach(function (o: any) { o._calystoPrevPosition = o.style.position })
				.ApplyStyle("position:absolute")
				.ForEach(function (o)
				{
					// we have to get dimensions for all elements while they have position:absolute
					var newW = Calysto.Utility.Dom.Style.GetComputedStyle((<any>o).parentNode, "width").NumericValue;
					var newH = Calysto.Utility.Dom.Style.GetComputedStyle((<any>o).parentNode, "height").NumericValue;
					SetOffsetDimensions(<any>o, newW, newH);
				})
				.ForEach(function (o)
				{
					(<any>o).style.position = (<any>o)._calystoPrevPosition || "";
					delete ((<any>o)._calystoPrevPosition);
				});
		}

		/**
		 * Select attribute value and return new Calysto.List with values.
		 * @param name
		 */
		public SelectAttribute(name: string)
		{
			// get value
			return this
				.Select(function (item)
				{
					return <string><any>Calysto.Utility.Dom.GetAttribute(<any>item, name);
				});
		};

		/**
		 * Return TMap[] (TMap for each element) with objects who's properties are names from array: 
		 * [{name1:value1, name2:value2}, {name1: value, name2: value}, ...]
		 * @param mapObj object with names to be selected: {"width": null, "height": null}
		 */
		public SelectAttributeMap<TMap>(mapObj: TMap)
		{
			return this
				.Select(function (item)
				{
					var obj: TMap = <any>{};

					Calysto.Collections.ForEachOwnProperties(mapObj, name =>
					{
						obj[name] = Calysto.Utility.Dom.GetAttribute(<any>item, name);
					});

					return obj;
				});
		}

		/**
		 * Return dictionary {[key:attrName]: attrValue} for each element.
		 * */
		public SelectAttributesAll()
		{
			return this
				.Select(function (item)
				{
					let dic: { [key: string]: string } = {};
					let attributes1: Attr[] = (<any>item)?.attributes;

					if (!attributes1)
						return dic;

					for (let attr of attributes1)
						dic[attr.name] = attr.value;

					return dic;
				});
		}

		/**
		 * Set attribute value.
		 * @param name name is case non-sensitive
		 * @param value
		 * @param add OPTIONAL. If not set, default is true.
		 */
		public SetAttribute(name: string, value: any, add = true)
		{
			if (!name)
			{
				throw new Error("AttributeValue requires name parameter");
			}

			// set value
			return this
				.ForEach((item, index) =>
				{
					if (add)
					{
						Calysto.Utility.Dom.SetAttribute(<any>item, name, value);
					}
					else
					{
						Calysto.Utility.Dom.RemoveAttribute(<any>item, name);
					}
				});
		}

		/**
		 * Remove attribute by name.
		 * @param name attribute name
		 */
		public RemoveAttribute(name: string)
		{
			return this
				.SetAttribute(name, null, false);
		}

		/**
		 * Convert value to string and set as innerHTML to every element in collection.
		 * @param html
		 */
		public SetInnerHtml(html?: string | null | undefined)
		{
			if (arguments.length == 0 || html == null || typeof (html) == "undefined")
			{
				html = "";
			}

			// use html + "" if html is not string
			return this
				.ForEach(function (el)
				{
					let h1 = html + "";
					(<any>el).innerHTML = h1;

				});
		}

		/**
		 * If target element supports "value", will add content as value, else, will invoke ReplaceChildren
		 * @param content
		 */
		public SetValueOrInnerHtml(content?: any)
		{
			return this
				.ForEach(function (el)
				{
					let el1 = <HTMLInputElement><any>el;
					let tagName = el1.tagName.toLowerCase();
					switch (tagName)
					{
						case "input":
						case "select":
						case "textarea":
							el1.value = content;
							break;
						default:
							el1.innerHTML = content;
							break;
					}
				});
		}

		public SetProperty(property: string, value: string | any)
		{
			return this
				.ForEach(function (el) { el[property] = value });
		}

		public SetChecked(value: boolean)
		{
			return this
				.SetProperty("checked", value);
		}

		/**
		 * Convert value to string and append to innerHTML of every element in collection.
		 * @param html
		 */
		public AppendInnerHtml(html: string)
		{
			if (arguments.length == 0 || html == null || typeof (html) == "undefined")
			{
				html = "";
			}

			// use html + "" if html is not string
			return this
				.ForEach(function (el)
				{
					(<any>el).innerHTML += html + "";
				});
		}

		/**
		 * Convert value to string and append to innerHTML of every element in collection.
		 * @param html
		 */
		public PrependInnerHtml(html: string)
		{
			if (arguments.length == 0 || html == null || typeof (html) == "undefined")
			{
				html = "";
			}

			// use html + "" if html is not string
			return this
				.ForEach(function (el)
				{
					(<any>el).innerHTML = html + "" + (<any>el).innerHTML;
				});
		}

		/**
		 * Search for 'script' elements and mark them as executed.
		 * So will not execute it again from ExecuteScriptNodes().
		*/
		public MarkScriptsExecuted()
		{
			return this.ForEach(el =>
			{
				$$calysto(<any>el).Query<HTMLScriptElement>("script, //script").ForEach(o => ScriptLoader.MarkScriptExecuted(o));
			});
		}

		/**
		 * Search for 'script' elements, execute it's content and mark them as executed.
		 * So will not execute them next time when ExecuteScriptNode() invoked.
		 * @param alwaysExecute
		 */
		public ExecuteScriptNodes(alwaysExecute: boolean = false)
		{
			return this.ForEach(el =>
			{
				$$calysto(<any>el).Query<HTMLScriptElement>("script, //script").ForEach(o => ScriptLoader.ExecuteScriptNode(o));
			});
		}

		/** Select innerHTML value from each element. */
		public SelectInnerHtml()
		{
			return this
				.Select(function (el) { return <string>(<any>el).innerHTML; });
		}

		/** Select innerHTML value from each element. */
		public SelectInnerText()
		{
			return this
				.Select(function (el) { return Calysto.Utility.Dom.GetInnerText(<any>el); });
		}

		public WhereText(textToSearch: string, ignoreCase: boolean)
		{
			if (!textToSearch)
			{
				throw new Error("WhereText requires textToSearch parameter");
			}

			textToSearch = ignoreCase ? textToSearch.toLowerCase() : textToSearch;

			return this
				.Where(function (item) { return item && GetTextValueOnly(<any>item, ignoreCase).indexOf(textToSearch) >= 0; });
		}

		/**
		 * Add css class to classes collection.
		 * @param cssClass
		 * @param add OPTIONAL. If not set, default is true.
		 */
		public AddClass(cssClass: string, add = true): DomQuery<TItem>
		{
			if (add)
			{
				return CssClass(this, "AddClass", cssClass);
			}
			else
			{
				return this.RemoveClass(cssClass);
			}
		}

		/**
		 * Remove css class from classes collection.
		 * @param cssClass
		 */
		public RemoveClass(cssClass: string): DomQuery<TItem>
		{
			return CssClass(this, "RemoveClass", cssClass);
		}

		/**
		 * Set css class value, removing previous values.
		 * @param cssClass
		 */
		public SetClass(cssClass: string): DomQuery<TItem>
		{
			return CssClass(this, "SetClass", cssClass);
		}

		/**
		 * If doesn't exist, add class, else remove it.
		 * @param cssClass
		 */
		public ToggleClass(cssClass: string): DomQuery<TItem>
		{
			return CssClass(this, "ToggleClass", cssClass);
		}

		/**
		 * Select class names.
		*/
		public SelectClassNames()
		{
			return this
				.SelectMany<string>(function (el)
				{
					return (<any>el).className.match(new RegExp("[\\S]+", "g")); // returns array of matches
				});
		}

		/**
		 * Test if current element is visible in DOM, using style.display and offsetHeight and offsetWidht and style.visibility.
		 * @param isVisible OPTIONAL, default is true
		 */
		public WhereVisible(isVisible = true)
		{
			isVisible = arguments.length == 0 || !!isVisible;

			return this
				.Where(function (o)
				{
					return (Calysto.Utility.Dom.IsElementVisible(<any>o)) == isVisible;
				});
		}

		/**
		 * Test if element and ancestors are visible in DOM, up to documentElement node, using style.display and offsetHeight and offsetWidht and style.visibility.
		 * @param isVisible OPTIONAL, default is true
		 */
		public WhereDomTreeVisible(isVisible = true)
		{
			isVisible = arguments.length == 0 || !!isVisible;

			return this
				.Where(function (o)
				{
					return Calysto.Utility.Dom.IsDomTreeVisible(<any>o) == isVisible;
				});
		}

		/**
		 * Test if element is visible in DOM and in viewport (on screen) only part
		 * @param isVisible
		 */
		public WhereInViewPort(isVisible = true, onlyPart = true)
		{
			isVisible = arguments.length == 0 || !!isVisible;

			return this
				.Where(function (o)
				{
					return Calysto.Utility.Dom.IsElementVisible(<any>o) == isVisible
						&& Calysto.Utility.Dom.IsElementInViewport(<any>o, onlyPart) == isVisible;
				});
		}

		/**
		 * Test if "disabled" attribute exists.
		 * @param isEnabled OPTIONAL. If not set, default is true.
		 */
		public WhereEnabled(isEnabled = true)
		{
			isEnabled = arguments.length == 0 || !!isEnabled;

			return this
				.Where(function (o)
				{
					return !Calysto.Utility.Dom.HasAttribute(<any>o, "disabled") == isEnabled;
				});
		}

		/**
		 * Bind event handler to current items.
		 * @param eventFullNameOrArr
		 *	- event name with class name, ex: click.one1.two2
		 *	- event name or array of event names without 'on' on start (click, mouserover, mousemove,...)
		 *	- may include namespace for simple removal as [eventType].[namespace]: click.my_one, click.mynode.divone
		 * @param callbackFunc
		 *	function(sender, event){ }, if not bound to different context, inside of function this == sender
		 * @param useCapture
		 *	if true, use capture, trigger event before all other
		 * @param triggCountMax
		 *	number of how many times to trigger, after that events are ignored
		 */
		public On(eventFullNameOrArr: string | string[], callbackFunc: CallbackDelegate<TItem>, useCapture?: boolean, triggCountMax?: number)
		{
			if (!callbackFunc)
			{
				// callback can't be null, throw exception or return this
				throw new Error("CallbackFunc can not be null");
				//return this;
			}

			if (Calysto.Type.TypeInspector.IsArray(eventFullNameOrArr))
			{
				// if eventName array length == 0, return this
				var src: DomQuery<TItem> = this;

				for (var n = 0; n < eventFullNameOrArr.length; n++)
				{
					src = this.On(eventFullNameOrArr[n], callbackFunc, useCapture, triggCountMax);
				}
				return src; // return the latest src, it is only new enumerable with current items
			}

			var eventFullName: string = <string>eventFullNameOrArr;

			if (eventFullName.indexOf("on") == 0)
			{
				eventFullName = eventFullName.substr(2);
			}

			// namespace
			var cb11 = callbackFunc;
			var parts = eventFullName.split(".");
			var evName = parts[0]; // leave event in array, later just add "mouseover" in front, if first value is "hover"

			if (evName == "enterKey")
			{
				parts.unshift("keydown");
				cb11 = <CallbackDelegate<TItem>>function (sender, ev: KeyboardEvent)
				{
					if (Calysto.Event.IsEnterKey(ev))
					{
						return callbackFunc.call(sender, sender, ev);
					}
				};
			}
			else if (evName == "escKey")
			{
				parts.unshift("keydown");
				cb11 = <CallbackDelegate<TItem>>function (sender, ev: KeyboardEvent)
				{
					if (Calysto.Event.IsEscKey(ev))
					{
						return callbackFunc.call(sender, sender, ev);
					}
				};
			}

			return this
				.ForEach((domElement, index) =>
				{
					if (domElement)
					{
						var cb = GetCBEncaps(cb11); // implement event.preventDefault() if callback func returns false value

						if (evName == "hover")
						{
							parts.unshift("mouseover");
							cb = GetHoverCB(true, cb);
						}
						else if (evName == "hout")
						{
							parts.unshift("mouseout");
							cb = GetHoverCB(false, cb);
						}

						if (triggCountMax && triggCountMax > 0)
						{
							cb = GetTriggCountCB(triggCountMax, cb);
						}

						var fnEncaps = (function (contextItem, cbFunc)
						{
							// proxy method: since inside Calysto.Event.Append cb is invoked by the browser as cb.call(this, event) where this is current element
							// Calysto event handlers always have 2 arguments: function(sender, event){...}
							return (function (ev)
							{
								//// contextItem === this
								cbFunc.call(contextItem, contextItem, ev);
							});
						})(domElement, cb);

						// attach event
						let def = Calysto.Event.Attach(<any>domElement, parts.join("."), fnEncaps, useCapture);

						// callback on event is attached
						this.OnEventAttached.Invoke(f => f(def));
					}
				});
		}

		/**
		 * Callback after event is attached. eventDef may be used to remove event at later time.
		 * @param fn
		 */
		public readonly OnEventAttached = new Calysto.MulticastDelegate<(eventDef: ICalystoEventDefinition) => void>().AsFunc(this);

		/**
		 * Remove event by eventFullName (event type.namespace). Can remove previously added with .On(...)
		 * @param eventFullName
		 * - full name including namespace, or namespace only, or name only
		 * - full event name to be removed, without on: (click, change,...)
		 * - may include namespace for simple removal as [eventType].[namespace]: click.my_one, click.mynode.divone
		 */
		public RemoveEvent(eventFullName)
		{
			// can not use callbackFunc because we attach encapsulated function, not the original one

			return this
				.ForEach(function (domElement, index)
				{
					if (domElement)
					{
						(<Node><any>domElement).$$calysto_EventsArr.AsEnumerable().Where(o => o.eventFullName == eventFullName).ForEach(o => o.removeEvent());
					}
				});
		}

		/**
		 * Dispatch event or event type on element el.
		 * @param event
		 */
		public DispatchEvent(event: Event)
		{
			return this.ForEach(function (el, index)
			{
				Calysto.Event.DispatchEvent(<any>el, event);
			});
		}

		/**
		 * Hover event on mouse enter or mouse leave an element.
		 * @param onOver function(sender, event){...}
		 * @param onOut function(sender, event){...}
		 */
		public OnHover(onOver: CallbackDelegate<TItem>, onOut?: CallbackDelegate<TItem>)
		{
			var tt: DomQuery<TItem> = this;
			if (onOver)
			{
				tt = tt.On("hover", onOver);
			}
			if (onOut)
			{
				tt = tt.On("hout", onOut);
			}
			return tt;
		}

		/**
		 * 
		 * @param callbackFunc function(sender, event){...}
		 */
		public OnChange(callbackFunc: CallbackDelegate<TItem>)
		{
			return this.On("change", callbackFunc);
		}

		/**
		 * Monitor for changes in value or checked property in regular intervals. 
		 * Default pooling interval = 100 ms.
		 * @param callbackFunc
		 * @param intervalMs default = 100 ms
		 */
		public OnChangePooling(callbackFunc: CallbackDelegate<TItem>, intervalMs: number = 100)
		{
			let key = Calysto.Utility.Generators.GeneratePassword(10);
			let valueKey = "__value_" + key;
			let checkedKey = "__checked_" + key;

			let items = this.ForEach(o =>
			{
				o[valueKey] = o["value"];
				o[checkedKey] = o["checked"];
			}).ToList();

			let id = setInterval(() =>
			{
				items.ForEach(o =>
				{
					if (o[valueKey] != o["value"] || o[checkedKey] != o["checked"])
					{
						o[valueKey] = o["value"]
						o[checkedKey] = o["checked"]

						callbackFunc(o, <Event><any>{
							type: "change",
							target: o,
							currentTarget: o
						});
					}
				})
			}, 100);

			return new PoolingState(items.AsDomQuery(), id);
		}

		/**
		 * 
		 * @param callbackFunc function(sender, event){...}
		 */
		public OnInput(callbackFunc: CallbackDelegate<TItem>)
		{
			return this.On("input", callbackFunc);
		}

		/**
		 * 
		 * @param callbackFunc function(sender, event){...}
		 */
		public OnClick(callbackFunc: MouseCallbackDelegate<TItem>)
		{
			return this.On("click", <CallbackDelegate<TItem>>callbackFunc);
		}

		/**
		 * 
		 * @param callbackFunc function(sender, event){...}
		 */
		public OnDblClick(callbackFunc: MouseCallbackDelegate<TItem>)
		{
			return this.On("dblclick", <CallbackDelegate<TItem>>callbackFunc);
		}

		/**
		 * 
		 * @param callbackFunc function(sender, event){...}
		 */
		public OnMouseUp(callbackFunc: MouseCallbackDelegate<TItem>)
		{
			return this.On("mouseup", <CallbackDelegate<TItem>>callbackFunc);
		}

		/**
		 * 
		 * @param callbackFunc function(sender, event){...}
		 */
		public OnMouseDown(callbackFunc: MouseCallbackDelegate<TItem>)
		{
			return this.On("mousedown", <CallbackDelegate<TItem>>callbackFunc);
		}

		/**
		 * 
		 * @param callbackFunc function(sender, event){...}
		 */
		public OnMouseOver(callbackFunc: MouseCallbackDelegate<TItem>)
		{
			return this.On("mouseover", <CallbackDelegate<TItem>>callbackFunc);
		}

		/**
		 * 
		 * @param callbackFunc function(sender, event){...}
		 */
		public OnMouseOut(callbackFunc: MouseCallbackDelegate<TItem>)
		{
			return this.On("mouseout", <CallbackDelegate<TItem>>callbackFunc);
		}

		/**
		 * 
		 * @param callbackFunc function(sender, event){...}
		 */
		public OnLeftMouseDown(callbackFunc: MouseCallbackDelegate<TItem>)
		{
			let tmp111 = this;
			function cb(sender, event)
			{
				if (Calysto.Event.IsLeftMouseButton(event))
				{
					callbackFunc.apply(tmp111, <any>arguments);
				}
			}

			return this.On("mousedown.leftmousedown", cb);
		}

		/**
		 * 
		 * @param callbackFunc function(sender, event){...}
		 */
		public OnRightMouseDown(callbackFunc: MouseCallbackDelegate<TItem>)
		{
			let tmp111 = this;

			function cb(sender, event)
			{
				if (Calysto.Event.IsRightMouseButton(event))
				{
					callbackFunc.apply(tmp111, <any>arguments);
				}
			}

			return this.On("mousedown.rightmousedown", cb);
		}

		/**
		 * 
		 * @param callbackFunc function(sender, event){...}
		 */
		public OnMouseMove(callbackFunc: MouseCallbackDelegate<TItem>)
		{
			return this.On("mousemove", <CallbackDelegate<TItem>>callbackFunc);
		}

		/**
		 * 
		 * @param callbackFunc function(sender, event){...}
		 */
		public OnFocus(callbackFunc: CallbackDelegate<TItem>)
		{
			return this.On("focus", callbackFunc);
		}

		/**
		 * 
		 * @param callbackFunc function(sender, event){...}
		 */
		public OnBlur(callbackFunc: CallbackDelegate<TItem>)
		{
			return this.On("blur", callbackFunc);
		}

		/**
		 * Has NO ev.charCode, only ev.keyCode, triggers on any key press (eg. shift, ctrl, F1...)
		 * @param callbackFunc function(sender, event){...}
		 */
		public OnKeyDown(callbackFunc: KeyboardCallbackDelegate<TItem>)
		{
			return this.On("keydown", <CallbackDelegate<TItem>>callbackFunc);
		}

		/**
		 * Has NO ev.charCode, only ev.keyCode, triggers on any key press (eg. shift, ctrl, F1...)
		 * @param callbackFunc function(sender, event){...}
		 */
		public OnKeyUp(callbackFunc: KeyboardCallbackDelegate<TItem>)
		{
			return this.On("keyup", <CallbackDelegate<TItem>>callbackFunc);
		}

		/**
		 * has ev.charCode and ev.keyCode, triggers on chars only, doesn't trigger with special keys eg. shift, ctrl, F1
		 * @param callbackFunc function(sender, event){...}
		 */
		public OnKeyPress(callbackFunc: KeyboardCallbackDelegate<TItem>)
		{
			return this.On("keypress", <CallbackDelegate<TItem>>callbackFunc);
		}

		/**
		 * 
		 * @param callbackFunc function(sender, event){...}
		 */
		public OnEnter(callbackFunc: KeyboardCallbackDelegate<TItem>)
		{
			return this.On("enterKey", <CallbackDelegate<TItem>>callbackFunc);
		}

		/**
		 * 
		 * @param callbackFunc function(sender, event){...}
		 */
		public OnEscKey(callbackFunc: KeyboardCallbackDelegate<TItem>)
		{
			return this.On("escKey", <CallbackDelegate<TItem>>callbackFunc);
		}

		/**
		 * Deep clone current nodes and return cloned nodes only.
		 * @returns
		 */
		public CloneNodes()
		{
			return this
				.Where(o => !!(<any>o).cloneNode)
				.Select(o => <TItem>(<any>o).cloneNode(true));
		}

		/**
		 * Disconnect nodes from DOM.
		 * @returns
		 */
		public RemoveFromDom()
		{
			return this
				.ForEach(function (item, index)
				{
					Calysto.Utility.Dom.RemoveNodeFromDom(<any>item);
				});
		}

		/**
		 * Replace each node with new html or element. if content is null, remove node from dom. Returnes new (replacement) nodes.
		 * @param {any[]} ...content
		 * @returns
		 */
		public ReplaceWith(...content: any[])
		{
			var res = AddOrModify("InsertBefore", this.ToArray(), arguments);
			// remove current items
			res.ThisItems?.ForEach((o, n) => Calysto.Utility.Dom.RemoveNodeFromDom(o));
			// return new items
			return res.NewItems.AsEnumerable().AsDomQuery();
		}

		/**
		 * Replace each current collection node's children with content. if content is null, remove children only. Returns current collection.
		 * @param {any[]} ...content
		 * @returns
		 */
		public ReplaceChildren(...content: any[])
		{
			var res = AddOrModify("ReplaceChildrenWith", this.ToArray(), arguments);

			return this;
		}

		public RemoveChildren()
		{
			return this.ReplaceChildren();
		}

		/**
		 * Add content as last child to each node in current collection. Returns current collection.
		 * @param {any[]} ...content html, single dom element, array of dom element, Calysto.DomQuery elements
		 * @returns
		 */
		public AddChildren(...content: any[])
		{
			var res = AddOrModify("AddChildren", this.ToArray(), arguments);

			return this;
		}

		/**
		 * Insert content as first child to each node in current collection. Returns current collection.
		 * @param {any[]} ...content html, single dom element, array of dom element, Calysto.DomQuery elements
		 * @returns
		 */
		public InsertChildren(...content: any[])
		{
			var res = AddOrModify("InsertChildren", this.ToArray(), [].AddRange(arguments).Reverse());

			return this;
		}

		/**
		 * Insert content before every node in current collection. Returns current collection.
		 * @param {any[]} ...content html, single dom element, array of dom element, Calysto.DomQuery elements
		 * @returns
		 */
		public InsertBefore(...content: any[])
		{
			var res = AddOrModify("InsertBefore", this.ToArray(), arguments);

			return this;
		}

		/**
		 * Insert content after every node in current collection. Returns current collection.
		 * @param {any[]} ...content html, single dom element, array of dom element, Calysto.DomQuery elements
		 * @returns
		 */
		public InsertAfter(...content: any[])
		{
			var res = AddOrModify("InsertAfter", this.ToArray(), [].AddRange(arguments).Reverse());

			return this;
		}

		/**
		 * Insert current collection nodes as first children into nodes specified by calystoSelector. Returns added nodes, including cloned ones if there were cloned or multiplied
		 * @param {string | HTMLElement} calystoSelector
		 * @returns
		 */
		public InsertAsChildrenTo(calystoSelector: string | HTMLElement)
		{
			var destinationArr = Calysto.DomQuery.FromSelector(calystoSelector).ToArray();
			var thisArr = this.Reverse().ToArray();

			var res = AddOrModify("InsertChildren", destinationArr, thisArr);
			return res.NewItems.AsEnumerable().AsDomQuery();
		}

		/**
		 * Add current collection as last children into nodes specified by calystoSelector. Returns added nodes, including cloned ones if there were cloned or multiplied
		 * @param {string | HTMLElement} calystoSelector
		 * @returns
		 */
		public AddAsChildrenTo(calystoSelector: string | HTMLElement)
		{
			var destinationArr = Calysto.DomQuery.FromSelector(calystoSelector).ToArray();
			var thisArr = this.ToArray();

			var res = AddOrModify("AddChildren", destinationArr, thisArr);
			return res.NewItems.AsEnumerable().AsDomQuery();
		}

		/**
		 * Insert current collection before nodes selected by calystoSelector. Returns added nodes, including cloned ones if there were cloned or multiplied
		 * @param {string | HTMLElement} calystoSelector
		 * @returns
		 */
		public InsertBeforeTo(calystoSelector: string | HTMLElement)
		{
			var destinationArr = Calysto.DomQuery.FromSelector(calystoSelector).ToArray();
			var thisArr = this.ToArray();
			var res = AddOrModify("InsertBefore", destinationArr, thisArr);
			return res.NewItems.AsEnumerable().AsDomQuery();
		}

		/**
		 * Insert current collection after nodes selected by calystoSelector. Returns added nodes, including cloned ones if there were cloned or multiplied
		 * @param {string | HTMLElement} calystoSelector
		 * @returns
		 */
		public InsertAfterTo(calystoSelector: string | HTMLElement)
		{
			var destinationArr = Calysto.DomQuery.FromSelector(calystoSelector).ToArray();
			var thisArr = this.ToArray();

			var res = AddOrModify("InsertAfter", destinationArr, thisArr);
			return res.NewItems.AsEnumerable().AsDomQuery();
		}

		/**
		 * Sleep execution with setTimeout. Can be used for branching. When expired, execute onExpired.call(this, this). "this" is sent both as parameter and as context.
		 * @param {number} sleepMs
		 * @param {(sender} onExpired function to execute onExpired.call(this, this)
		 * @returns
		 */
		public Sleep(sleepMs: number, onExpired: (sender: DomQuery<TItem>) => void)
		{
			var aa = this;
			setTimeout(function () { onExpired.call(aa, aa); }, sleepMs);

			return this;
		}

		/**
		 * Export current elements to animator. Animate from current style settings to finalMap settings.
		 * @param finalMap final values to animate to, eg. {height:40, opacity:25, marginTop: 54}
		 */
		public ToAnimator<TMap>(finalMap: TMap)
		{
			if (!finalMap) throw new Error("ToAnimator requires finalMap");

			var animator = new Calysto.Animator();
			this.ForEach((item, index) =>
			{
				for (var prop in finalMap)
				{
					animator.AddElement(<any>item, prop, <any>finalMap[prop]);
				}
			});
			return animator;
		}

		/**
		 * Add onselectstart handler which returns false.
		 * @param isSelectable OPTIONAL. If not set, default is true.
		 */
		public SetSelectable(isSelectable = true)
		{
			////.calystoNoUserSelect {
			////	-webkit-touch-callout: none;
			////	-webkit-user-select: none;
			////	-khtml-user-select: none;
			////	-moz-user-select: none;
			////	-ms-user-select: none;
			////	user-select: none;
			////}

			// Formal syntax: none | text | all | element

			if (isSelectable)
			{
				return this.RemoveClass("calystoNoUserSelect");
			}
			else
			{
				return this.AddClass("calystoNoUserSelect"); // class is defined in ThemeBase
			}
		}

		/**
		 * Set attribute disabled=disabled and disable onclick handler. LIMITATION: "disabled" has to be set on all descendants.
		 * @param isEnabled OPTIONAL. If not set, default is true.
		 */
		public SetEnabled(isEnabled = true)
		{
			return this
				.ForEach(function (item, index)
				{
					Calysto.Utility.Dom.SetEnabled(<any>item, isEnabled);
				});
		}

		/**
		 * If isVisible == true: set display="".
		 * If isVisible == false: set style display="none".
		 * @param isVisible
		 */
		public SetVisible(isVisible = true)
		{
			/// <summary>
			/// Set style display="none", else set display="".
			/// </summary>
			/// <param name="isVisible" type="Boolean">
			/// false: apply style.display = "none"<br/>
			/// true: or undefined: apply style.display = ""<br/>
			/// </param>

			return this
				.ForEach((item: any, index: number) =>
				{
					if (item && item.style)
					{
						if (isVisible)
						{
							if (item.style.display == "none")
							{
								item.style.display = ""; // first set "", then thest for visibility
							}
							var val = Calysto.Utility.Dom.Style.GetComputedStyle(<any>item, "display").StyleValue;
							if (val == "none")
							{
								// value is set in css, override it
								item.style.display = item.tagName.toLowerCase() == "div" ? "block" : "inherit";
							}

							if (item.style.visibility == "hidden")
							{
								item.style.visibility = ""; // first set "", then test for visibility
							}
							var val = Calysto.Utility.Dom.Style.GetComputedStyle(<any>item, "visibility").StyleValue;
							if (val == "hidden" || val == "collapse")
							{
								// value is set in css, override it
								item.style.visibility = "inherit";
							}
						}
						////else if(item.style && "visibility" in item.style)
						////{
						////	item.style.visibility = "hidden"; // hidden makes element inivisible, but still reserves width & height in DOM
						////}
						else
						{
							// old compatibility
							item.style.display = "none";
						}
					}
				});
		}

		/**
		 * 
		 * @param isReadonly default: true
		 */
		public SetReadOnly(isReadonly = true)
		{
			if (isReadonly)
			{
				return this.SetAttribute("readonly", "readonly");
			}
			else
			{
				return this.RemoveAttribute("readonly");
			}
		}

		/**
		 * Set opacity
		 * @param value 0.0 - 1.0 (full visibility = 1.0)
		 */
		public SetOpacity(value: number)
		{
			// ako je poslan postotak do 100%
			if (value > 1)
				value = value / 100;

			/*filter for For IE8 and earlier */
			return this
				.ApplyStyle("filter", "alpha(opacity=" + (value * 100.0) + ")")
				.ApplyStyle("opacity", value);
		}

		/**
		 * 
		 * @param clipValue already parsed into object, or string: "margins(100% 0 0 0)" or "rect:(10px 100px 50px 53px)
		 */
		public SetClip(clipValue: Object | string)
		{
			return this
				.ForEach(function (o) { Calysto.Utility.Dom.SetClip(<any>o, <any>clipValue); });
		}

		/**
		 * Single line transition.
		 * 
		 * @param propertyName
		 * "none" to remove transition (optional, default: all) Specifies the name of the CSS property the transition effect is for. Css default is all.
		 * 
		 * @param durationMs
		 * (optional, default: 400ms) Specifies how many seconds or milliseconds the transition effect takes to complete. Css default is 0
		 * 
		 * @param func (optional, default: linear)
		 * - linear	Specifies a transition effect with the same speed from start to end (equivalent to cubic-bezier(0,0,1,1))
		 * - ease	Specifies a transition effect with a slow start, then fast, then end slowly (equivalent to cubic-bezier(0.25,0.1,0.25,1))
		 * - ease-in	Specifies a transition effect with a slow start (equivalent to cubic-bezier(0.42,0,1,1))
		 * - ease-out	Specifies a transition effect with a slow end (equivalent to cubic-bezier(0,0,0.58,1))
		 * - ease-in-out	Specifies a transition effect with a slow start and end (equivalent to cubic-bezier(0.42,0,0.58,1))
		 * - cubic-bezier(n,n,n,n)	Define your own values in the cubic-bezier function. Possible values are numeric values from 0 to 1
		 * 
		 * @param delayMs
		 */
		public SetTransition(propertyName = "all", durationMs = 0, func = "linear", delayMs = 0)
		{
			if (arguments.length < 1) { propertyName = "all"; }
			if (arguments.length < 2) { durationMs = 400; }
			if (arguments.length < 3) { func = "linear"; }
			if (arguments.length < 4) { delayMs = 0; }

			var val = propertyName == "none" ? "" : (propertyName + " " + durationMs + "ms" + " " + func + " " + delayMs + "ms");
			this.ApplyStyle("transition", val);
			this.ApplyStyle("-webkit-transition", val);
			return this;
		}

		/**
		 * Remove any previous transform and apply new.
		 * - angle must have deg: eg. 45deg
		 * - x,y,z values must have px units
		 * - scale has no units
		 * 
		 * @param transformFunc
		 * - none
		 * - matrix(n,n,n,n,n,n) 2D transform
		 * - matrix3d(n,n,n,n,n,n,n,n,n,n,n,n,n,n,n,n) 3D transform
		 * - translate(x,y)
		 * - translate3d(x,y,z)
		 * - translateX(x)
		 * - translateY(y)
		 * - translateZ(z)
		 * - scale(x,y)
		 * - scale3d(x,y,z)
		 * - scaleX(x)
		 * - scaleY(y)
		 * - scaleZ(z)
		 * - rotate(angle)
		 * - rotate3d(x,y,z,angle)
		 * - rotateX(angle)
		 * - rotateY(angle)
		 * - rotateZ(angle)
		 * - skew(x-angle,y-angle)
		 * - skewX(angle)
		 * - skewY(angle)
		 * - perspective(n)
		 */
		public SetTransform(transformFunc: string)
		{
			if (arguments.length == 0 || transformFunc == "none")
			{
				transformFunc = "";
			}

			for (var n = 0; n < transforms.length; n++)
			{
				this.ApplyStyle(transforms[n], transformFunc);
			}
			return this;
		}

		/**
		 * Get current transform and apply modification to existing transform only.
		 * - angle must have deg: eg. 45deg
		 * - x,y,z values must have px units
		 * - scale has no units
		 * 
		 * @param transformFunc
		 * - none
		 * - matrix(n,n,n,n,n,n) 2D transform
		 * - matrix3d(n,n,n,n,n,n,n,n,n,n,n,n,n,n,n,n) 3D transform
		 * - translate(x,y)
		 * - translate3d(x,y,z)
		 * - translateX(x)
		 * - translateY(y)
		 * - translateZ(z)
		 * - scale(x,y)
		 * - scale3d(x,y,z)
		 * - scaleX(x)
		 * - scaleY(y)
		 * - scaleZ(z)
		 * - rotate(angle)
		 * - rotate3d(x,y,z,angle)
		 * - rotateX(angle)
		 * - rotateY(angle)
		 * - rotateZ(angle)
		 * - skew(x-angle,y-angle)
		 * - skewX(angle)
		 * - skewY(angle)
		 * - perspective(n)
		 */
		public ApplyTransform(transformFunc: string)
		{
			if (arguments.length == 0 || transformFunc == "none")
			{
				return this.SetTransform("none");
			}

			var fnames: any[] | null = transformFunc.match(new RegExp("[\\w]+", "ig"));

			return this.ForEach((o: any) =>
			{
				if (o && o.style && fnames && fnames.length > 0)
				{
					var newval = transformFunc;
					var curr = o.style.transform || o.style.msTransform || o.style.webkitTransform;
					if (curr)
					{
						// if new val is compund, eg.: translate(100px, -100px) rotate(170deg) scale(0.2)"
						// remove previous and add new
						newval = curr.replace(new RegExp("(" + fnames.join("|") + ")" + "[\\s]*\\([^\\)]*\\)", "ig"), "") + " " + transformFunc;
					}
					////console.log("set: " + newval);
					Calysto.DomQuery.FromSelector(<any>o).SetTransform(newval);
				}
			});
		};

		/**Select transform value of current elements and return new Calysto.List with string values. */
		public SelectTransform()
		{
			return this.Select(function (o)
			{
				return Calysto.Utility.Dom.SelectTransform(<any>o);
			});
		}

		public SetLinearGradient(degrees, color0, color1, color3, etc)
		{
			/// <summary>
			/// 
			/// </summary>
			/// <param name="degrees" type="Int|String">
			///		<para>none to remove gradient</para>
			///		<para>0 is from bottom to top, negative i CCV, pozitive CV</para>
			/// </param>
			/// <param name="color0" type="String">color value or color value and position in percent starting from start (0% is start, 100% is end) eg. red, blue, or red 10%, blue 20%, etc</param>

			/////* background-image: linear-gradient(0deg, color percent, color percent, etc)*/
			////background-color: #F07575; /* fallback color if gradients are not supported */
			////background-image: -webkit-linear-gradient(top, hsl(0, 80%, 70%), #bada55 50%, red 100%); /* For Chrome and Safari */
			////background-image: -moz-linear-gradient(top, hsl(0, 80%, 70%), #bada55); /* For old Fx (3.6 to 15) */
			////background-image: -ms-linear-gradient(top, hsl(0, 80%, 70%), #bada55); /* For pre-releases of IE 10*/
			////background-image: -o-linear-gradient(top, hsl(0, 80%, 70%), #bada55); /* For old Opera (11.1 to 12.0) */ 
			////background-image: linear-gradient(to bottom, hsl(0, 80%, 70%), #bada55); /* Standard syntax; must be last */

			if (arguments.length == 0 || degrees == "none")
			{
				return this.ApplyStyle("background-color", "").ApplyStyle("background-image", "");
			}

			degrees = parseFloat(degrees);
			// all browsers uses clock-wise orientataion and 0 is at bottom
			// safari uses CCW orientation and 0 is at left
			if (Calysto.Features.GetBrowser().Kind == Calysto.Features.BrowserKindEnum.Safari)
			{
				degrees = (degrees - 90) * (-1);
			}

			degrees += "deg";

			var arr = [degrees];
			for (var n = 1; n < arguments.length; n++)
			{
				arr.push(arguments[n]);
			}
			var str = arr.join(", ");

			var pp = ["-webkit-", "-moz-", "-ms-", "-o-", ""];

			var ss = ["background-color:" + (color0 || "").split(" ")[0]]; // background-color if gradient is not supported
			for (var n = 0; n < pp.length; n++)
			{
				ss.push("background-image:" + pp[n] + "linear-gradient(" + str + ")");
			}
			ss.push("");

			console.log(ss.join(";"));

			// create complete string first, than assign it as style.cssText += ..., if assigned one by one, it will override each other and the last one will be set as final, so it wont' work in all browsers
			this.ApplyStyle(ss.join(";"));
			return this;
		}

		/**
		 * Returns Animator instance. item.Start() has to be invoked to start animation.
		 * @param alignToTop default: false, will align to bottom
		 */
		public ToAnimatorScrollIntoView(alignToTop = false)
		{
			let animator = new Calysto.Animator();
			this.ForEach((item, index) =>
			{
				let el1 = <HTMLElement><any>item;

				let scrollableAncestor = Calysto.Utility.Dom.GetScrollableAncestors(el1)[0];
				if (!scrollableAncestor)
					return;

				let elPosition = Calysto.Utility.Dom.GetElementScreenPosition(el1);

				let elAncestorPosition = Calysto.Utility.Dom.GetElementScreenPosition(<HTMLElement><any>scrollableAncestor);

				// top align:
				let scrollTop = elPosition.top - elAncestorPosition.top;
				let scrollLeft = elPosition.left - elAncestorPosition.left;

				if (!alignToTop)
				{
					// bottom align
					scrollTop += scrollableAncestor.clientHeight - el1.clientHeight;
					scrollLeft += scrollableAncestor.clientHeight - el1.clientWidth;
				}

				////console.log(elPosition, elAncestorPosition, { scrollTop, scrollLeft });

				//// IE scrolls documentElement, other scrolls body
				//// always scroll body and documentElement, FF and IE works with documentElement, Chrome with body
				//animator.AddElement(document.body, "scrollTop", scrollTop);
				//animator.AddElement(document.body, "scrollLeft", scrollLeft);
				//animator.AddElement(document.documentElement, "scrollTop", scrollTop);
				//animator.AddElement(document.documentElement, "scrollLeft", scrollLeft);

				animator.AddElement(scrollableAncestor, "scrollTop", scrollTop);
				animator.AddElement(scrollableAncestor, "scrollLeft", scrollLeft);

			});

			return animator;
		}


		/*
		instance.SetCentered = function ()
		{
			/// <summary>
			/// Set current elements centered into their parents
			/// </summary>

			return this.Where("o=>o.parentNode").ForEach(function (el, index)
			{
				el.style.marginLeft = ((el.parentNode.clientWidth - el.offsetWidth) / 2) + "px";
				el.style.marginTop = ((el.parentNode.clientHeight - el.offsetHeight) / 2) + "px";
			});
		};
		*/

		public static FromArray<TElement>(arr: TElement[])
		{
			return new DomQuery(() => CalystoEnumerator.From(arr));
		}

		/**
			Operates on current document.all and select elements by calystoSelector as document.all.Query(args)
		 * @param calystoSelector lambda or css calystoSelector:
TAG name: html, body, div, span, a, ...
ID: #idvalue, ...
CLASS: .mydiv, a.mydiv...
ATTRIBUTES: [name] (contains attribute), [name=value], [name &gt; value], ==, =, <, >, !=, <>, [name*=value] (contains value), [name^=value] (starts with value), [name$=value] (ends with value)...
TRAVERSING: * (all), space or // (descendants), / (children), ^ (ancestors), >>> (n-th level children), << (n-th level parent) :first(n) :last(n) :skip(n) :take(n) :reverse() :exact(n), with or without (n), if there is no (n), default n == 1
Element state: :hidden, :visible
X-path: :ancestor :descendant :child :parent :next-siblings :previous-siblings
		 */
		public static FromSelector<TElement extends HTMLElement>(calystoSelector:
			TElement
			| string
			| Node
			| TElement[]
			| any[]
			| CalystoEnumerable<any>
		): DomQuery<TElement>
		{
			// flattern arguments and arguments which are arrays

			let argsAll = arguments;

			if (argsAll.length > 1)
			{
				let qq;
				for (var n = 0; n < argsAll.length; n++)
				{
					let innerSel = Calysto.DomQuery.FromSelector(argsAll[n]);

					if (!qq)
					{
						qq = innerSel;//.addPredicateInfo("FromSelector", argsAll);
					}
					else
					{
						qq = qq.addPredicateInfo("Concat", argsAll[n]).Concat(innerSel);
					}
				}
				return qq;
			}

			if (!calystoSelector)
			{
				return DomQuery.FromArray<TElement>([]);
			}

			// if starts with white space or / or //, remove it, it doesn't make sense since it already works on document.DescendantNodes()
			if (typeof (calystoSelector) == "string")
			{
				switch (calystoSelector.charAt(0))
				{
					case ' ':
					case '/':
						calystoSelector = calystoSelector.TrimStart([' ', '/']);
						break;
				}
			}

			if (<any>calystoSelector == window) // #text node has .cloneNode()
			{
				// window, document, any other dom element
				// warning: window on some portals may have window.length > 0 property, so test if it is window, html or body element first
				return DomQuery.FromArray([<TElement><any>calystoSelector]);
			}
			else if (<any>calystoSelector == document) // #text node has .cloneNode()
			{
				// window, document, any other dom element
				// warning: window on some portals may have window.length > 0 property, so test if it is window, html or body element first
				return DomQuery.FromArray([<TElement><any>calystoSelector]);
			}
			else if (((<any>calystoSelector).nodeType > 0 && (<any>calystoSelector).cloneNode)) // #text node has .cloneNode()
			{
				// window, document, any other dom element
				// warning: window on some portals may have window.length > 0 property, so test if it is window, html or body element first
				return DomQuery.FromArray([<TElement><any>calystoSelector]);
			}
			else if (calystoSelector == "html")
			{
				return DomQuery.FromArray([<TElement><any>document.documentElement]);
			}
			else if (calystoSelector == "body")
			{
				return DomQuery.FromArray([<TElement><any>document.body]);
			}
			else if (calystoSelector.constructor == Calysto.DomQuery)
			{
				return <DomQuery<TElement>><any>calystoSelector;
			}
			else if ((<any>calystoSelector).GetEnumerator)// || (calystoSelector._source && calystoSelector._source.GetEnumerator))
			{
				return new Calysto.DomQuery(() => (<CalystoEnumerable<any>>calystoSelector).GetEnumerator());
			}
			else if ((<any>calystoSelector).childNodes) // single dom element
			{
				return DomQuery.FromArray([<TElement><any>calystoSelector]);
			}
			else if (typeof (calystoSelector) == "string" && calystoSelector.length > 0) // custom string calystoSelector: "div .red #home"
			{
				return DomQuery.FromArray([<TElement><any>document])
					.DescendantNodes()
					.Query(calystoSelector);
			}
			else if ((<any>calystoSelector).push && (<any>calystoSelector).pop) // array, real
			{
				let qq1: DomQuery<TElement> = <any>null;

				for (var n = 0; n < (<any>calystoSelector).length; n++)
				{
					let tmp2: DomQuery<TElement> = <any>Calysto.DomQuery.FromSelector(calystoSelector[n]);
					if (!qq1)
					{
						qq1 = tmp2;//.addPredicateInfo("FromSelector", argsAll);
					}
					else
					{
						qq1 = qq1.Concat(tmp2).AsDomQuery();
					}
				}
				// if array has no elements, qq1 is null, so return new instance
				return qq1 || DomQuery.FromArray([]);
			}
			else if (calystoSelector && (<any>calystoSelector).length > 0 && calystoSelector[0] && calystoSelector[0].nodeType > 0) // dom array
			{
				let qq1: DomQuery<TElement> = <any>null;
				for (var n = 0; n < (<any>calystoSelector).length; n++)
				{
					let tmp2: DomQuery<TElement> = <any>Calysto.DomQuery.FromSelector(calystoSelector[n]);
					if (!qq1)
					{
						qq1 = tmp2;//.addPredicateInfo("FromSelector", argsAll);
					}
					else
					{
						qq1 = qq1.Concat(tmp2).AsDomQuery();
					}
				}
				// if array has no elements, qq1 is null, so return new instance
				return qq1 || DomQuery.FromArray([]);
			}
			else if (calystoSelector)
			{
				// if selector is window, document etc.
				return DomQuery.FromArray([<TElement><any>calystoSelector]);
			}
			else
			{
				throw new Error("Unknown calystoSelector in GetDomNodesEnumerable");
			}
		}

		/**
		 * Returns string [name=pathExpression]
		 * @param pathExpression
		 */
		public static FromPathExpression<TModel>(pathExpression: (m: TModel) => any)
		{
			return DomQuery.FromSelector(`[name=${Calysto.Utility.Expressions.ParsePath<TModel>(pathExpression)}]`);
		}

		/**
		 * Creates source from xmlString.
		 * @param xmlString
		 */
		public static FromXml(xmlString: string)
		{
			var xmlDocument = ParseXmlString(xmlString);
			var docEl = xmlDocument.documentElement; // remove #root node
			return DomQuery.FromArray([docEl]);
		}

		/**
		 * Creates source from html string.
		 * @param htmlString
		 */
		public static FromHtml(htmlString: string)
		{
			var arr = Calysto.Utility.Dom.ConvertToElementsArray(htmlString);
			return DomQuery.FromArray(arr);
		};

		////public static FromJsObject(jsObject)
		////{
		////	return Calysto.JsObjectReader.ReadObject(jsObject);
		////}

		public static CreateElement<TItem extends HTMLElement>(tagName: string)
		{
			return DomQuery.FromArray([<TItem>document.createElement(tagName)]);
		}
	}
}

// export global variable:
var $$calysto = Calysto.DomQuery.FromSelector;

