using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Calysto.Utility
{
	public static class CalystoHttpTools
	{
		#region html conversion methods

		public static string ConvertTextToHtml(string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				return text;
			}

			//return text.TrimEnd('\r', '\n', ' ', '\t').Replace("\n", "<br/>").Replace("\r", "").Replace("  ", "&nbsp;&nbsp;");
			// must have <br/>\r\n because some e-mail clients remove html tags, so keep new lines anyway

			return text.Replace("\r\n", "<br/>").Replace("\n", "<br/>"); // some have \n only
		}

		public static string RemoveHtmlTags(string htmlText, string replacement = "")
		{
			if (string.IsNullOrEmpty(htmlText))
			{
				return htmlText;
			}

			Regex re = new Regex("\\<[^\\>]+\\>");
			return re.Replace(htmlText, replacement);
		}

		/// <summary>
		/// replace &gt; and &lt; with &amp;gt; and &amp;lt;
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static string HtmlEncodeSimple(string str)
		{
			if (string.IsNullOrEmpty(str))
			{
				return str;
			}

			return str.Replace("<", "&lt;").Replace(">", "&gt;");

		}

		/// <summary>
		/// replace &amp;gt; and &amp;lt; with &gt; and &lt;
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static string HtmlDecodeSimple(string str)
		{
			if (string.IsNullOrEmpty(str))
			{
				return str;
			}

			return str.Replace("&lt;", "<").Replace("&gt;", ">");

		}

		/// <summary>
		/// convert text to html with simple html encode
		/// </summary>
		/// <param name="txt"></param>
		/// <returns></returns>
		public static string ConvertToHtmlWithHtmlEncodeSimple(string txt)
		{
			if (string.IsNullOrEmpty(txt))
			{
				return txt;
			}

			return ConvertTextToHtml(HtmlEncodeSimple(txt));

		}

		#endregion

		#region HR chars replacer

		public static string ReplaceHRCharsForSMS(string inputText)
		{
			if (string.IsNullOrEmpty(inputText))
			{
				return inputText;
			}

			return inputText
						.Replace("č", "c")
						.Replace("Č", "C")
						.Replace("ć", "c")
						.Replace("Ć", "C")
						.Replace("ž", "z")
						.Replace("Ž", "Z")
						.Replace("š", "s")
						.Replace("Š", "S")
						.Replace("đ", "d")
						.Replace("Đ", "D")
						.Replace("ü", "u")
						.Replace("Ü", "U")
						.Replace("ä", "a")
						.Replace("Ä", "A")
						.Replace("ö", "o")
						.Replace("Ö", "O")
						.Replace("ß", "s")
						;
		}

		public static string ReplaceHRCharsForWeb(string inputText)
		{
			if (string.IsNullOrEmpty(inputText))
			{
				return inputText;
			}
			return inputText
				.Replace("č", "&#269;")
				.Replace("Č", "&#268;")
				.Replace("ć", "&#263;")
				.Replace("Ć", "&#262;")
				.Replace("ž", "&#382;")
				.Replace("Ž", "&#381;")
				.Replace("š", "&#353;")
				.Replace("Š", "&#352;")
				.Replace("đ", "&#273;")
				.Replace("Đ", "&#272;");
		}

		#endregion

		#region url encode and clean

		/// <summary>
		/// encode words in URL, between slashes: /word/word/
		/// </summary>
		private static readonly Dictionary<char, char> mUriComponentAcceptedCharsDic = new Func<Dictionary<char, char>>(() =>
		{
			string s = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			string s2 = s + s.ToLower() + "1234567890";
			return s2.ToDictionary(o => o, o => o);
		}).Invoke();

		private static readonly Dictionary<char, char> mFileNameAcceptedCharsDic = new Func<Dictionary<char, char>>(() =>
		{
			Dictionary<char, char> dic = mUriComponentAcceptedCharsDic.ToDictionary(o => o.Key, o => o.Value);
			dic.Add('_', '_');
			dic.Add('-', '-');
			dic.Add('.', '.');
			dic.Add(' ', ' ');
			return dic;
		}).Invoke();

		/// <summary>
		/// encode chars in complete URL: http://word/word/word.aspx?nfdsa=gews&gasd
		/// </summary>
		private static readonly Dictionary<char, char> mFullUrlAcceptedCharsDic = new Func<Dictionary<char, char>>(() =>
		{
			Dictionary<char, char> dic = mUriComponentAcceptedCharsDic.ToDictionary(o => o.Key, o => o.Value);
			dic.Add('/', '/');
			dic.Add('_', '_');
			dic.Add('-', '-');
			dic.Add('.', '.');
			dic.Add(':', ':');
			dic.Add('?', '?');
			dic.Add('&', '&');
			return dic;
		}).Invoke();

		private static string CleanUriComponent(string str)
		{
			string str1 = str;
			str1 = new Regex("[\\-][\\-]+").Replace(str1, "-"); // replace multiple --- with single -
			str1 = new Regex("(^[\\s\\- ]+)|([\\s\\- ]+$)").Replace(str1, ""); // trim space and - from start and end
			return str1;
		}

		/// <summary>
		/// Replace HR chars, all non URL acceptable replace with -
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static string GetUrlEncodedAndCleaned(string inputText)
		{
			if (string.IsNullOrEmpty(inputText))
			{
				return inputText;
			}

			StringBuilder sb = new StringBuilder();
			foreach (char c in ReplaceHRCharsForSMS(inputText).ToCharArray())
			{
				if (mUriComponentAcceptedCharsDic.ContainsKey(c))
				{
					sb.Append(c);
				}
				else
				{
					// replace with -
					sb.Append('-');
				}
			}
			return CleanUriComponent(sb.ToString());
		}

		/// <summary>
		/// Replace any non URL char, like german chars, ", ', etc
		/// </summary>
		/// <param name="inputText">http://domain.com/fads/dsf.aspx?gsad=ghsdf</param>
		/// <returns></returns>
		public static string FullUrlReplaceNonUrlChars(string inputText)
		{
			if (string.IsNullOrEmpty(inputText))
			{
				return inputText;
			}

			StringBuilder sb = new StringBuilder();
			foreach (char c in ReplaceHRCharsForSMS(inputText).ToCharArray())
			{
				if (mFullUrlAcceptedCharsDic.ContainsKey(c))
				{
					sb.Append(c);
				}
				else
				{
					// replace with -
					sb.Append('-');
				}
			}
			return CleanUriComponent(sb.ToString());
		}

		public static string GetValidFilename(string str)
		{
			if (string.IsNullOrEmpty(str))
			{
				throw new FileNotFoundException(str);
			}

			StringBuilder sb = new StringBuilder();
			foreach (char c in ReplaceHRCharsForSMS(str).ToCharArray())
			{
				if (mFileNameAcceptedCharsDic.ContainsKey(c))
				{
					sb.Append(c);
				}
				else
				{
					// replace with -
					sb.Append('-');
				}
			}
			return CleanUriComponent(sb.ToString());
		}

		#endregion
	}
}
