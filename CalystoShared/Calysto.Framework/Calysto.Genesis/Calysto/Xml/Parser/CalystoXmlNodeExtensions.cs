using Calysto.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calysto.Xml.Parser
{
	public static class CalystoXmlNodeExtensions
	{
		#region where methods

		/// <summary>
		/// search for nodes with attributeName in this nodes collection
		/// </summary>
		/// <param name="list"></param>
		/// <param name="attributeName"></param>
		/// <param name="containsValue"></param>
		/// <param name="caseSensitive"></param>
		/// <returns></returns>
		public static IEnumerable<CalystoXmlNode> WhereAttribute(this IEnumerable<CalystoXmlNode> list, string attributeName, string containsValue = null, bool caseSensitive = false)
		{
			if (string.IsNullOrEmpty(attributeName))
			{
				throw new ArgumentNullException("attributeName");
			}

			return list.Where(o => o.Attributes.Count > 0
				&& o.Attributes.Count(a => a.Name != null && a.Name.Equals(attributeName, caseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase)
				&& (containsValue == null || a.Value.IndexOf(containsValue, caseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase) >= 0)) > 0);
		}

		/// <summary>
		/// search for nodes with tagName in this nodes collection
		/// </summary>
		/// <param name="list"></param>
		/// <param name="tagName"></param>
		/// <param name="caseSensitive"></param>
		/// <returns></returns>
		public static IEnumerable<CalystoXmlNode> WhereTagName(this IEnumerable<CalystoXmlNode> list, string tagName, bool caseSensitive = false)
		{
			if (string.IsNullOrEmpty(tagName))
			{
				throw new ArgumentNullException("tagName");
			}

			return list.Where(o => o.TagName != null && o.TagName.Equals(tagName, caseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase));
		}

		/// <summary>
		/// search for textToSearch in this nodes collection
		/// </summary>
		/// <param name="list"></param>
		/// <param name="textToSearch"></param>
		/// <param name="caseSensitive"></param>
		/// <returns></returns>
		public static IEnumerable<CalystoXmlNode> WhereText(this IEnumerable<CalystoXmlNode> list, string textToSearch, bool caseSensitive = false)
		{
			if (string.IsNullOrEmpty(textToSearch))
			{
				throw new ArgumentNullException("textToSearch");
			}

			return list.Where(o => o.StartTagTextAndNodeValue.IndexOf(textToSearch, caseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase) >= 0);
		}

		#endregion

		#region descendants

		public static IEnumerable<CalystoXmlNode> DescendantNodes(this CalystoXmlNode node)
		{
			////return node.ChildNodes().Concat(node.ChildNodes().SelectMany(n => n.DescendantNodes()));

			// better way, dig children's children immediately
			foreach (CalystoXmlNode child in node.Children)
			{
				yield return child;

				foreach (CalystoXmlNode ch2 in child.DescendantNodes())
				{
					yield return ch2;
				}
			}


		}

		/// <summary>
		/// <para>descendants (children, grandchildren, etc.) of the current node</para>
		/// </summary>
		/// <param name="node"></param>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public static IEnumerable<CalystoXmlNode> DescendantNodes(this CalystoXmlNode node, Func<CalystoXmlNode, bool> predicate)
		{
			return node.DescendantNodes().Where(predicate);
		}

		public static IEnumerable<CalystoXmlNode> DescendantNodes(this IEnumerable<CalystoXmlNode> list)
		{
			return list.SelectMany(n => n.DescendantNodes());
		}

		/// <summary>
		/// <para>descendants (children, grandchildren, etc.) of the current nodes list</para>
		/// </summary>
		/// <param name="list"></param>
		/// <param name="predicate"></param>
		/// <param name="sublevels"></param>
		/// <returns></returns>
		public static IEnumerable<CalystoXmlNode> DescendantNodes(this IEnumerable<CalystoXmlNode> list, Func<CalystoXmlNode, bool> predicate)
		{
			return list.DescendantNodes().Where(predicate);
		}

		#endregion

		#region ancestors

		public static IEnumerable<CalystoXmlNode> AncestorNodes(this CalystoXmlNode node)
		{
			while ((node = node.Parent) != null)
			{
				yield return node;
			}
		}

		/// <summary>
		/// <para>ascendant (parent, grandparent, etc.) of the current node</para>
		/// </summary>
		public static IEnumerable<CalystoXmlNode> AncestorNodes(this CalystoXmlNode node, Func<CalystoXmlNode, bool> predicate)
		{
			return node.AncestorNodes().Where(predicate);
		}

		/// <summary>
		/// <para>ascendant (parent, grandparent, etc.) of the current nodes list</para>
		/// </summary>
		public static IEnumerable<CalystoXmlNode> AncestorNodes(this IEnumerable<CalystoXmlNode> list)
		{
			return list.SelectMany(o => o.AncestorNodes());
		}

		/// <summary>
		/// <para>ascendant (parent, grandparent, etc.) of the current nodes list</para>
		/// </summary>
		public static IEnumerable<CalystoXmlNode> AncestorNodes(this IEnumerable<CalystoXmlNode> list, Func<CalystoXmlNode, bool> predicate = null)
		{
			return list.AncestorNodes().Where(predicate);
		}

		#endregion

		#region parent nodes

		/// <summary>
		/// first level parent nodes
		/// </summary>
		/// <param name="list"></param>
		/// <returns></returns>
		public static IEnumerable<CalystoXmlNode> ParentNodes(this IEnumerable<CalystoXmlNode> list)
		{
			return list.Select(o => o.Parent);
		}

		/// <summary>
		/// first level parent nodes
		/// </summary>
		/// <param name="list"></param>
		/// <returns></returns>
		public static IEnumerable<CalystoXmlNode> ParentNodes(this IEnumerable<CalystoXmlNode> list, Func<CalystoXmlNode, bool> predicate)
		{
			return list.ParentNodes().Where(predicate);
		}

		#endregion

		#region child nodes

		/// <summary>
		/// first level children
		/// </summary>
		/// <returns></returns>
		public static IEnumerable<CalystoXmlNode> ChildNodes(this CalystoXmlNode node)
		{
			return node.Children;
		}

		/// <summary>
		/// first level children
		/// </summary>
		/// <returns></returns>
		public static IEnumerable<CalystoXmlNode> ChildNodes(this CalystoXmlNode node, Func<CalystoXmlNode, bool> predicate)
		{
			return node.Children.Where(predicate);
		}


		/// <summary>
		/// first level children
		/// </summary>
		/// <param name="list"></param>
		/// <returns></returns>
		public static IEnumerable<CalystoXmlNode> ChildNodes(this IEnumerable<CalystoXmlNode> list)
		{
			return list.SelectMany(o => o.Children);
		}

		/// <summary>
		/// first level children
		/// </summary>
		/// <param name="list"></param>
		/// <returns></returns>
		public static IEnumerable<CalystoXmlNode> ChildNodes(this IEnumerable<CalystoXmlNode> list, Func<CalystoXmlNode, bool> predicate)
		{
			return list.ChildNodes().Where(predicate);
		}

		#endregion

		#region next siblings

		public static IEnumerable<CalystoXmlNode> NextSiblings(this CalystoXmlNode node)
		{
			if (node.Parent != null)
			{
				foreach (CalystoXmlNode s in node.Parent.Children.SkipWhile(o => o != node).Skip(1))
				{
					yield return s;
				}
			}
		}

		public static IEnumerable<CalystoXmlNode> NextSiblings(this CalystoXmlNode node, Func<CalystoXmlNode, bool> predicate)
		{
			return node.NextSiblings().Where(predicate);
		}

		public static IEnumerable<CalystoXmlNode> NextSiblings(this IEnumerable<CalystoXmlNode> list)
		{
			return list.SelectMany(o => o.NextSiblings());
		}

		public static IEnumerable<CalystoXmlNode> NextSiblings(this IEnumerable<CalystoXmlNode> list, Func<CalystoXmlNode, bool> predicate)
		{
			return list.NextSiblings().Where(predicate);
		}

		#endregion

		#region previous siblings

		public static IEnumerable<CalystoXmlNode> PreviousSiblings(this CalystoXmlNode node)
		{
			if (node.Parent != null)
			{
				foreach (CalystoXmlNode s in node.Parent.Children.TakeWhile(o => o != node).Reverse())
				{
					// backward:
					// n0, n1, n2, n3, n4=current, n5, n5, will return nodes: n3, n2, n1, n0
					yield return s;
				}
			}
		}

		public static IEnumerable<CalystoXmlNode> PreviousSiblings(this CalystoXmlNode node, Func<CalystoXmlNode, bool> predicate)
		{
			return node.PreviousSiblings().Where(predicate);
		}

		public static IEnumerable<CalystoXmlNode> PreviousSiblings(this IEnumerable<CalystoXmlNode> list)
		{
			return list.SelectMany(o => o.PreviousSiblings());
		}

		public static IEnumerable<CalystoXmlNode> PreviousSiblings(this IEnumerable<CalystoXmlNode> list, Func<CalystoXmlNode, bool> predicate)
		{
			return list.PreviousSiblings().Where(predicate);
		}

		#endregion

		#region ice css selector

		class SelectorReader
		{
			int _currPosition = 0;
			string selector;

			public SelectorReader(string rxSelector)
			{
				this.selector = rxSelector;
			}

			/// <summary>
			/// Peek next char.
			/// </summary>
			/// <param name="forwardBy">default:0 (first available on stack)</param>
			/// <returns></returns>
			public char? Peek(int forwardBy = 0)
			{
				if (selector.Length > _currPosition + forwardBy)
				{
					return selector[_currPosition + forwardBy];
				}
				return null;
			}

			/// <summary>
			/// Pop first available value, than advance index + 1.
			/// </summary>
			/// <returns></returns>
			public char? Pop()
			{
				if (selector.Length > _currPosition)
				{
					return selector[_currPosition++];
				}
				return null;
			}

			/// <summary>
			/// Match from (first + origin) position, advance index by (match length + origin) and return match.
			/// </summary>
			/// <param name="regex"></param>
			/// <param name="origin"></param>
			/// <returns></returns>
			public Match PopMatch(Regex regex, int origin = 0)
			{
				Match mm = regex.Match(selector.Substring(_currPosition + origin));
				if (mm.Success)
				{
					_currPosition += mm.Value.Length + origin;
					return mm;
				}
				return null;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="source"></param>
		/// <param name="attrName">value from an element (current value)</param>
		/// <param name="attrSign"></param>
		/// <param name="attrVal">expected value</param>
		/// <returns></returns>
		private static IEnumerable<CalystoXmlNode> CreateAttributeQuery(IEnumerable<CalystoXmlNode> source, string attrName, string attrSign, string attrVal)
		{
			// should be used o.getAttribute(name) which is case non-senseitve for name parameter?

			var func = new Func<CalystoXmlNode, bool>(o =>
			{
				CalystoXmlAttribute attr = o.GetAttributeNode(attrName);

				string currValue = attr == null ? "" : attr.Value ?? ""; // current attribute value

				string m = attrSign;

				if (string.IsNullOrEmpty(m))
				{
					// the same as =*
					// no attr sign, statement [attrName] means has attribute value, doesn't matter which value is
					return !string.IsNullOrEmpty(currValue);
				}
				else if (m == "=" || m == "==")
				{
					return currValue == attrVal;
				}
				else if (m == "=*")
				{
					// has any value, but not empty
					return !string.IsNullOrEmpty(currValue);
				}
				else if (m == "~=") // E[foo~="warning"]	Matches any E element whose "foo" attribute value is a list of space-separated values, one of which is exactly equal to "warning"
				{
					return (" " + currValue + " ").Contains(" " + attrVal + " ");
				}
				else if (m == "*=") // contains value
				{
					return currValue.Contains(attrVal);
				}
				else if (m == "^=") // starts with
				{
					return currValue.StartsWith(attrVal);
				}
				else if (m == "$=") // ends with
				{
					return currValue.EndsWith(attrVal);
				}
				else // <, >, <=, >=, % etc
				{
					decimal curr1, val1;
					if (!(decimal.TryParse(currValue, out curr1) && decimal.TryParse(attrVal, out val1)))
					{
						return false;
					}

					switch (m)
					{
						case "==": return curr1 == val1;
						case "<": return curr1 < val1;
						case ">": return curr1 > val1;
						case ">=": return curr1 >= val1;
						case "<=": return curr1 <= val1;
					}

					throw new NotSupportedException(m);
				}
			});

			return source.Where(o => func(o));
		}

		static Regex reAspNetId = new Regex("[^_]+[_]([^_]+)$");

		private static bool IsAspNetId(string elementId, string searchForId)
		{
			// include asp.net id: page_sub_txtName
			// include asp.net name: page$sub$txtName

			if (!string.IsNullOrEmpty(elementId) && !string.IsNullOrEmpty(searchForId) && elementId.Length > searchForId.Length)
			{
				Match match = reAspNetId.Match(elementId);
				return match.Success && match.Groups[1].Value == searchForId;
			}
			return false;
		}

		private static IEnumerable<CalystoXmlNode> CreateIdQuery(IEnumerable<CalystoXmlNode> source, string id)
		{
			return source.Where(o => o.Id == id || IsAspNetId(o.Id, id));
		}

		private static IEnumerable<CalystoXmlNode> CreateClassQuery(IEnumerable<CalystoXmlNode> source, string className)
		{
			return source.Where(o => (" " + o.Class + " ").Contains(" " + className + " "));
		}

		private static IEnumerable<CalystoXmlNode> CreateTagQuery(IEnumerable<CalystoXmlNode> source, string tag)
		{
			return source.Where(o => string.Equals(o.TagName, tag, StringComparison.OrdinalIgnoreCase));
		}

		private static IEnumerable<CalystoXmlNode> CreateColonWordQuery(IEnumerable<CalystoXmlNode> source, string colonWord, string colonValue)
		{
			int count = 1;
			if (!int.TryParse(colonValue, out count))
			{
				count = 1;
			}

			switch (colonWord)
			{
				case "first":
				case "take":
					return source.Take(count);
				case "last":
					return source.Reverse().Take(count).Reverse();
				case "skip":
					return source.Skip(count);
				case "exact":
					return source.Exact(count);
				case "is":
				case "not":
					// select elements from source where subquery in :is(subquery) is true or :not(subquery) is false, input to subquery is each element from source query
					// $('div//*:not(span)'), select div's descendants, except span, '*' can be removed
					// $(".firstquery...").Query(":not(a>span, .cls1>>div)") or .Query(":not(a>span), :not(.cls1>>div)"), // select all items from first query where item is not "a" with child "span" and item with class 'cls' has no 2nd child 'div'
					// $(".firstquery...").Query(":is(a>span)"), // select all items from first query where item is "a" with child "span"
					// $(".firstquery...").Query(":is(*>span)"), // * is optional: .Query(":is(>span)") select all items from first query where item has child "span"
					return source.Where(o => o.Query(colonValue).Any() == (colonWord == "is"));
				////case "has":
				////case "hasnot":
				////	// OBSOLETE: use :is or :not instead since "is" or "not" is much more sophisticated version than this crappy jQuery.has(...)
				////	// The expression $('div:has(p)') matches a <div> if a <p> exists anywhere among its descendants, not just as a direct child.
				////	bool doesHave = colonWord == "has";
				////	return source.Where(o => o.DescendantNodes().Query(colonValue).Any() == doesHave);
				case "reverse":
					return source.Reverse();
				case "ancestor":
					return source.AncestorNodes();
				case "descendant":
					return source.DescendantNodes();
				case "child":
					return source.ChildNodes();
				case "parent":
					return source.ParentNodes();
				case "next-sibling":
					return source.NextSiblings();
				case "previous-sibling":
					return source.PreviousSiblings();
				default:
					throw new NotSupportedException(colonWord + "(" + colonValue + ")");
			}
		}

		public static IEnumerable<CalystoXmlNode> SelectFilteredSingle(this IEnumerable<CalystoXmlNode> source, string singleCssSelector)
		{
			var origsrc = source;
			var newsrc = source;

			string rxSelector = singleCssSelector.Replace("\"", "").Replace("'", "").Trim(); // remove " and '

			rxSelector = new Regex("([ ]*)([\\/\\<\\>\\!\\~\\^\\$\\*\\=]+)([ ]*)").Replace(rxSelector, "$2"); // remove spaces arround special chars
			rxSelector = new Regex("[ ]+").Replace(rxSelector, " "); // replace multiple spaces with single space

			char? ch;
			Match mm;

			SelectorReader reader = new SelectorReader(rxSelector);

			while ((ch = reader.Pop()) != null)
			{
				if (ch == '#' && (mm = reader.PopMatch(new Regex("^([\\w\\-_]+)"))) != null)
				{
					// #id
					newsrc = CreateIdQuery(newsrc, mm.Groups[1].Value);
				}
				else if (ch == '.' && (mm = reader.PopMatch(new Regex("^([\\w\\-_]+)"))) != null)
				{
					// .class
					newsrc = CreateClassQuery(newsrc, mm.Groups[1].Value);
				}
				else if (ch == ' ')
				{
					// descendant
					newsrc = newsrc.DescendantNodes();
				}
				else if (ch == '/' && reader.Peek() == '/' && reader.Peek(1) != '/') // descendants, space or double //
				{
					// descendant
					reader.Pop(); // pop next / too
					newsrc = newsrc.DescendantNodes();
				}
				else if (ch == '*')
				{
					newsrc = newsrc.Select(o => o); // must create select if the only statement is "*", this way we return all, not empty collection
				}
				else if (ch == '^') // ancestors, ice specific
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
				else if (ch == ':' && (mm = reader.PopMatch(new Regex("^([\\w\\-_]+)([\\(]([^\\)]*)[\\)])*"))) != null)
				{
					// special attribute, eg. :take(10), :first, :first(5)
					newsrc = CreateColonWordQuery(newsrc, mm.Groups[1].Value, mm.Groups[3].Value);
				}
				else if (ch == '[' && (mm = reader.PopMatch(new Regex("^[ ]*([\\w\\-_]+)[ ]*([<>\\!\\=\\~\\^\\$\\*]*)[ ]*([^\\]]*)[ ]*\\]"))) != null)
				{
					// '[attribute="value"]' // '[attribute == "value"]' // // '[attribute != "value"]' // '[attribute >= value]'
					newsrc = CreateAttributeQuery(newsrc, mm.Groups[1].Value, mm.Groups[2].Value, mm.Groups[3].Value);
				}
				else if ((mm = reader.PopMatch(new Regex("^([\\w\\-_]+)"), -1)) != null) // origin -1 to include current ch in match
				{
					// tag
					newsrc = CreateTagQuery(newsrc, mm.Groups[1].Value);
				}
				else
				{
					// unknown
					throw new Exception("Usupported rxSelector (" + (rxSelector) + ")");
				}
			}

			// if newsrc == origsrc, nothing was selected by rxSelector, return an empty eneumerable
			return newsrc == origsrc ? new List<CalystoXmlNode>().AsEnumerable() : newsrc;
		}



		/// <summary>
		/// filter current items by rxSelector
		/// </summary>
		/// <param name="rxSelector">
		/// lambda or css rxSelector:
		/// <para>TAG name: html, body...</para>
		/// <para>ID: #idvalue...</para>
		/// <para>CLASS: .mydiv, a.mydiv...;</para>
		/// <para>ATTRIBUTES: [name] (contains attribute), [name=value], [name &gt; value], ==, =, &lt;, &gt;, !=, &lt;&gt;, [name*=value] (contains value), [name^=value] (starts with value), [name$=value] (ends with value)...</para>
		/// <para>TRAVERSING: space or // (descendants), / (children), ^ (ancestors), &gt;&gt;&gt; (n-th level children), &lt;&lt; (n-th level parent) :first(n) :last(n) :skip(n) :take(n) :reverse(), with or without (n), if there is no (n), default n == 1</para>
		/// <para>from x-path: :ancestor :descendant :child :parent :next-siblings :previous-siblings</para>
		/// </param>
		public static IEnumerable<CalystoXmlNode> Query(this CalystoXmlNode node, string rxSelector)
		{
			return new[] { node }.Query(rxSelector);
		}

		/// <summary>
		/// filter current items by rxSelector
		/// </summary>
		/// <param name="rxSelector">
		/// lambda or css rxSelector:
		/// <para>TAG name: html, body...</para>
		/// <para>ID: #idvalue...</para>
		/// <para>CLASS: .mydiv, a.mydiv...;</para>
		/// <para>ATTRIBUTES: [name] (contains attribute), [name=value], [name &gt; value], ==, =, &lt;, &gt;, !=, &lt;&gt;, [name*=value] (contains value), [name^=value] (starts with value), [name$=value] (ends with value)...</para>
		/// <para>TRAVERSING: space or // (descendants), / (children), ^ (ancestors), &gt;&gt;&gt; (n-th level children), &lt;&lt; (n-th level parent) :first(n) :last(n) :skip(n) :take(n) :reverse(), with or without (n), if there is no (n), default n == 1</para>
		/// <para>from x-path: :ancestor :descendant :child :parent :next-siblings :previous-siblings</para>
		/// </param>
		public static IEnumerable<CalystoXmlNode> Query(this IEnumerable<CalystoXmlNode> source, string rxSelector)
		{
			// translate rxSelector, split rxSelector by (,), but not inside (...)

			var rxSelectorsArr = new List<string>();
			var currPart = "";
			var digCount = 0;
			for (var n = 0; n < rxSelector.Length; n++)
			{
				var ch = rxSelector[n];
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
					rxSelectorsArr.Add(currPart);
					currPart = "";
				}
				else
				{
					currPart += ch;
				}
			}

			if (currPart.Length > 0)
			{
				rxSelectorsArr.Add(currPart);
			}

			foreach (string sel in rxSelectorsArr.Select(o => o.Trim()).Where(o => !string.IsNullOrEmpty(o)))
			{
				foreach (CalystoXmlNode node in source.SelectFilteredSingle(sel))
				{
					yield return node;
				}
			}
		}




		#endregion

	}
}
