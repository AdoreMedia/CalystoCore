using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Web;
using Calysto.Utility;
using Calysto.Data;

namespace Calysto.Common.Extensions
{
	public static class StringExtensions
	{
		/// <summary>
		/// Capitalize first char of the string, all other char's case is not changed.
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public static string Capitalize(this string s)
		{
			if (string.IsNullOrEmpty(s))
			{
				return s;
			}
			else
			{
				return s[0].ToString().ToUpper() + s.Substring(1);
			}
		}

		/// <summary>
		/// Convert to null if s is null or empty or white space.
		/// </summary>
		/// <param name="s"></param>
		/// <param name="trim"></param>
		/// <returns></returns>
		public static string ToNullIfEmpty(this string s, bool trim = false)
		{
			if(string.IsNullOrWhiteSpace(s))
			{
				return null;
			}
			else if(trim)
			{
				s = s.Trim();
				if(string.IsNullOrWhiteSpace(s))
				{
					return null;
				}
			}
			return s;
		}

		private static IEnumerable<Match> GetMatches(string str)
		{
			Match m = new Regex("([\\w]+)|([^\\w]+)").Match(str); // group 1: word, group 2: non-word
			while (m.Success)
			{
				yield return m;
				m = m.NextMatch();
			}
		}

		private static string TakeSplitByWords(string str, int maxLength, bool takeLast, string elipsis = null)
		{
			int maxTextLength = maxLength - (elipsis ?? "").Length;
			int currentLength = 0;
			List<string> list = new List<string>();
			string split = null;
			IEnumerable<Match> matches = GetMatches(str);
			if (takeLast)
			{
				matches = matches.Reverse();
			}
			foreach (Match m in matches)
			{
				currentLength += m.Length;

				if (m.Groups[2].Success)
				{
					// we never have 2 splitter toggether, defined in regex
					// splitters are kept together
					split += m.Value;
					continue;
				}
				else if (currentLength > maxTextLength)
				{
					break;
				}
				else
				{
					list.Add(split);
					split = null;
					list.Add(m.Value);
				}
			}
			
			if (elipsis != null)
			{
				list.Add(elipsis);
			}

			if (takeLast)
			{
				return string.Join(null, list.AsEnumerable().Reverse());
			}
			else
			{
				return string.Join(null, list);
			}
		}

		/// <summary>
		/// Take first n chars from string or the whole string if n is larger than length of the string. If string is shorten, add elipsis to the end of the new string.
		/// </summary>
		/// <param name="s"></param>
		/// <param name="n"></param>
		/// <returns></returns>
		public static string TakeFirst(this string s, int n, string elipsis = null, bool wordBoundrySplit = false)
		{
			if (string.IsNullOrEmpty(s) || n >= s.Length)
			{
				return s;
			}
			else if (wordBoundrySplit)
			{
				return TakeSplitByWords(s, n, false, elipsis);
			}
			else
			{
				int len = (elipsis ?? "").Length;
				return s.Substring(0, n - len) + elipsis;
			}
		}

		/// <summary>
		/// Take last n chars from string or the whole string if n is larger than length of the string. If string is shorten, add elipsis to the start of the new string.
		/// </summary>
		/// <param name="s"></param>
		/// <param name="n"></param>
		/// <returns></returns>
		public static string TakeLast(this string s, int n, string elipsis = null, bool wordSplit = false)
		{
			if (string.IsNullOrEmpty(s) || n >= s.Length)
			{
				return s;
			}
			else if (wordSplit)
			{
				return TakeSplitByWords(s, n, true, elipsis);
			}
			else
			{
				int len = (elipsis ?? "").Length;
				return elipsis + s.Substring(s.Length - n + len, n-len);
			}
		}

		/// <summary>
		/// Remove first n chars from string or the whole string if n is larger than length of the string. If string is shorten, add elipsis to the start of the new string.
		/// </summary>
		/// <param name="s"></param>
		/// <param name="n"></param>
		/// <param name="elipsis"></param>
		/// <returns></returns>
		public static string RemoveFirst(this string s, int n, string elipsis = null)
		{
			if (string.IsNullOrEmpty(s) || n >= s.Length)
			{
				return "";
			}
			else
			{
				int len = (elipsis ?? "").Length;
				return elipsis + s.Remove(n + len);
			}
		}

		/// <summary>
		/// Remove last n chars from string or the whole string if n is larger than length of the string. If string is shorten, add elipsis to the end of the new string.
		/// </summary>
		/// <param name="s"></param>
		/// <param name="n"></param>
		/// <param name="elipsis"></param>
		/// <returns></returns>
		public static string RemoveLast(this string s, int n, string elipsis = null)
		{
			if (string.IsNullOrEmpty(s) || n >= s.Length)
			{
				return "";
			}
			else
			{
				int index = s.Length - n - (elipsis ?? "").Length;
				if (index < 0) return "";
				return s.Remove(index) + elipsis;
			}
		}

#if !SILVERLIGHT && !XAMARIN
		/// <summary>
		/// Replace new line with br tags.
		/// </summary>
		/// <param name="str"></param>
		/// <param name="htmlEncode">if true, split to lines, than use HttpUtility.HtmlEncode to encode rows, than join rows with &lt;br&gt; tags</param>
		/// <returns></returns>
		public static string ToHtml(this string str, bool htmlEncode = false)
		{
			if (string.IsNullOrEmpty(str))
			{
				return str;
			}
			else
			{
				str = str.Replace("\r\n", "\n").Replace("\r", "");
				if(htmlEncode)
				{
					return string.Join("<br/>", str.Split('\n').Select(row => HttpUtility.HtmlEncode(row)));
				}
				return str.Replace("\n", "<br/>");
			}
		}
#endif

		public static string Repeat(this string str, int count)
		{
			StringBuilder sb = new StringBuilder();
			for (int n = 0; n < count; n++)
			{
				sb.Append(str);
			}
			return sb.ToString();
		}

		public static TResult ToNumber<TResult>(this string str, bool last = false)
		{
			if (string.IsNullOrEmpty(str))
			{
				return default(TResult);
			}

			string s;
			var query = Regex.Matches(str, "[\\- ]*[\\d]+[\\d\\.\\,]*").Cast<Match>().Select(o => o.Value); // including space too
			if (last)
			{
				s = query.LastOrDefault();
			}
			else
			{
				s = query.FirstOrDefault();
			}

			if (!string.IsNullOrEmpty(s))
			{
				// remove spaces, Decimal.TryParse(...) doesn't work with spaces 
				s = s.Replace(" ", "");
			}

			TResult res;
			Calysto.Utility.CalystoTypeConverter.TryChangeType<TResult>(s, out res);
			return res;
		}

		/// <summary>
		/// if ignoreCase == true: case non-sensitive String.Contains
		/// </summary>
		/// <param name="s"></param>
		/// <param name="str"></param>
		/// <returns></returns>
		public static bool Contains(this string s, string str, bool ignoreCase)
		{
			if (s == str) return true;

			if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(str)) return false;

			if (ignoreCase)
			{
				return s.IndexOf(str, StringComparison.OrdinalIgnoreCase) >= 0;
			}

			return s.Contains(str); // much faster than .IndexOf(..)
		}

		public static bool EqualsTo(this string s, string str, bool ignoreCase)
		{
			if (s == str) return true;

			if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(str)) return false;

			if(ignoreCase)
			{
				return s.Equals(str, StringComparison.OrdinalIgnoreCase);
			}

			return s.Equals(str);
		}

		////static Regex reEscape = new Regex("[\\-\\[\\]\\/\\{\\}\\(\\)\\*\\+\\?\\.\\\\^\\$\\|]");

		////private static string EscapeForRegex(string str)
		////{
		////	return reEscape.Replace(str, "[\\$&]");
		////}

		public class StringFormatResult
		{
			public string Text;
			public object[] Parameters;
		}

		/// <summary>
		/// String with placeholders as property names convert to indexed placeholders which may be used with string.Format(...) and System.Data.Linq query.
		/// </summary>
		/// <param name="str">input string with property names or array indexes: My name is {Name}, or My name is {0}</param>. Property names are case sensitive.
		/// <param name="obj">
		///		<para>object with properties {Name:Tom, Age:22, ...}</para>
		///		<para>or Enuerable or array["Tom", 22"...]</para>
		///		<para>IDictionary with Key-Values</para>
		/// </param>
		/// <param name="placeHolderStart"></param>
		/// <param name="placeHolderEnd"></param>
		/// <returns></returns>
		public static StringFormatResult CreateStringFormat(string str, object obj, string placeHolderStart = "{", string placeHolderEnd = "}")
		{
			StringFormatResult res = new StringFormatResult();

			if (string.IsNullOrWhiteSpace(str) || obj == null)
			{
				res.Text = str;
				return res;
			}

			List<object> list = new List<object>();
			int index = -1;
			// string with named properties has to be converted to string with indexed properties which may be used in System.Data.Linq or string.Format(...)
			res.Text = new Regex("(" + Regex.Escape(placeHolderStart) + "([\\w_\\-\\.]+)" + Regex.Escape(placeHolderEnd) + ")").Replace(str, delegate(Match m)
			{
				list.Add(CalystoDataBinder.Default.GetValue<object>(obj, m.Groups[2].Value)); // works in silverlight
				////return System.Web.UI.DataBinder.Eval(obj, key) + ""; // doesn't work in Silverlight
				index++;
				return "{" + index + "}";
			});

			res.Parameters = list.ToArray();
			return res;
		}

		public static StringFormatResult CreateStringFormat2(string str, object obj, string placeHolderStart = "{{", string placeHolderEnd = "}}")
		{
			return CreateStringFormat(str, obj, placeHolderStart, placeHolderEnd);
		}

		/// <summary>
		/// single brackets: replace {Name} with value from object with property {Name: "john"} or {User.Name} with value from {User:{Name:"john"}}
		/// </summary>
		/// <param name="str">input string with property names or array indexes: My name is {Name}, or My name is {0}</param>. Property names are case sensitive.
		/// <param name="obj">
		///		<para>object with properties {Name:Tom, Age:22, ...}</para>
		///		<para>or Enuerable or array["Tom", 22"...]</para>
		///		<para>IDictionary with Key-Values</para>
		/// </param>
		/// <param name="placeHolderStart"></param>
		/// <param name="placeHolderEnd"></param>
		/// <returns></returns>
		public static string FormatWith(this string str, object obj, string placeHolderStart = "{", string placeHolderEnd = "}")
		{
			if (string.IsNullOrEmpty(str) || obj == null)
			{
				return str;
			}

			if (string.IsNullOrEmpty(str) || obj == null)
			{
				return str;
			}

			return new Regex("(" + Regex.Escape(placeHolderStart) + "([\\w_\\-\\.]+)" + Regex.Escape(placeHolderEnd) + ")").Replace(str, delegate(Match m)
			{
				return (CalystoDataBinder.Default.GetValue<object>(obj, m.Groups[2].Value))+""; // works in silverlight
				////return System.Web.UI.DataBinder.Eval(obj, key) + ""; // doesn't work in Silverlight
			});
		}

		/// <summary>
		/// double brackets: replace {{Name}} with value from object with property {Name: "john"} or {{User.Name}} with value from {User:{Name:"john"}}
		/// </summary>
		/// <param name="str"></param>
		/// <param name="obj"></param>
		/// <param name="placeHolderStart"></param>
		/// <param name="placeHolderEnd"></param>
		/// <returns></returns>
		public static string FormatWith2(this string str, object obj, string placeHolderStart = "{{", string placeHolderEnd = "}}")
		{
			return FormatWith(str, obj, placeHolderStart, placeHolderEnd);
		}

		/// <summary>
		/// triple brackets: replace {{{Name}}} with value from object with property {Name: "john"} or {{{User.Name}}} with value from {User:{Name:"john"}}
		/// </summary>
		/// <param name="str"></param>
		/// <param name="obj"></param>
		/// <param name="placeHolderStart"></param>
		/// <param name="placeHolderEnd"></param>
		/// <returns></returns>
		public static string FormatWith3(this string str, object obj, string placeHolderStart = "{{{", string placeHolderEnd = "}}}")
		{
			return FormatWith(str, obj, placeHolderStart, placeHolderEnd);
		}

		public static string Replace(this string str, Regex selector, string replacement)
		{
			return selector.Replace(str, replacement);
		}

	}
}
