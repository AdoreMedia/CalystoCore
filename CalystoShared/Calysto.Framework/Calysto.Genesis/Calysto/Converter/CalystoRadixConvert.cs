using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Globalization;

namespace Calysto.Converter
{
	public class CalystoRadixConvert
	{
		private Dictionary<int, char> _dicIndexChar;
		private Dictionary<char, int> _dicCharIndex;

		/// <summary>
		/// New instance using JavaScriptRFCTable64
		/// </summary>
		public CalystoRadixConvert() : this(BaseXCharsTable.JavaScriptRFCTable64)
		{
		}

		/// <summary>
		/// New instance using custom chars table, up to 64 chars in length.
		/// </summary>
		/// <param name="charsTable"></param>
		public CalystoRadixConvert(string charsTable)
		{
			_dicIndexChar = new Dictionary<int, char>();
			_dicCharIndex = new Dictionary<char, int>();
			int index = 0;
			foreach(char ch in charsTable)
			{
				_dicIndexChar.Add(index, ch);
				_dicCharIndex.Add(ch, index);
				index++;
			}
		}


		#region helper methods

		/// <summary>
		/// convert from decimal number to any radix up to charsTable length, default is 64
		/// </summary>
		private string FromDecimal(long decimalValue, int toRadix)
		{
			bool isNegative = decimalValue < 0;
			decimalValue = Math.Abs(decimalValue);

			StringBuilder sb = new StringBuilder();
			long A = decimalValue;
			while (A >= toRadix)
			{
				long modulo = A % toRadix;
				A = A / toRadix;
				sb.Insert(0, _dicIndexChar[(int)modulo]+"");
			}
			sb.Insert(0, _dicIndexChar[(int)A]+"");
			return (isNegative ? "-" : null) + sb.ToString();
		}

		/// <summary>
		/// Convert to decimal number from any radix up to charsTable length, defaultis 64
		/// </summary>
		private long ToDecimal(string value, int fromRadix)
		{
			if (string.IsNullOrEmpty(value))
			{
				throw new ArgumentNullException("value");
			}
			bool isNegative = value.StartsWith("-");
			if (isNegative)
			{
				value = value.Substring(1);
			}

			value = Reverse(value);
			long decimalValue = 0;
			for (int n = 0; n < value.Length; n++)
			{
				int index = _dicCharIndex[value[n]];
				if (index < 0)
				{
					// invalid char, not found in table
					throw new Exception("Char not found in table, char: " + value[n]);
				}
				long factor = (long)Math.Pow(fromRadix, n);
				decimalValue += index * factor;
			}
			return (isNegative ? -1 : 1) * decimalValue;
		}

		private static string Reverse(string text)
		{
			StringBuilder sb = new StringBuilder();
			foreach (char ch in text)
			{
				sb.Insert(0, ch + "");
			}
			return sb.ToString();
		}

		#endregion

		public TResult Convert<TResult>(string value, int fromRadix, int toRadix, CultureInfo culture = null)
		{
			if (culture == null)
			{
				culture = System.Globalization.CultureInfo.CurrentCulture;
			}
			return Convert<TResult>(value, fromRadix, toRadix, culture.NumberFormat.NumberDecimalSeparator);
		}

		public TResult Convert<TResult>(string value, int fromRadix, int toRadix, string decimalSeparator)
		{
			if (string.IsNullOrEmpty(value))
			{
				throw new ArgumentNullException("value");
			}
			if (fromRadix < 2 || fromRadix > _dicCharIndex.Count)
			{
				throw new ArgumentOutOfRangeException("fromRadix");
			}
			if (toRadix < 2 || toRadix > _dicCharIndex.Count)
			{
				throw new ArgumentOutOfRangeException("toRadix");
			}

			string groupSeparator = decimalSeparator == "." ? "," : ".";

			string[] parts = value.Split(decimalSeparator[0]).Select(o =>
			{
				long dec = ToDecimal(o.Replace(" ", "").Replace(groupSeparator, ""), fromRadix);
				string val = FromDecimal(dec, toRadix);
				return val;
			}).ToArray();

			StringBuilder sb = new StringBuilder();
			for (int n = 0; n < parts.Length; n++)
			{
				if (n > 0)
				{
					sb.Append('.');
				}
				sb.Append(parts[n]);
			}
			string str = sb.ToString();

			// can't just cast values (e.g. double to decimal, string to int, etc., must use Convert)
			return (TResult)System.Convert.ChangeType(str, Nullable.GetUnderlyingType(typeof(TResult)) ?? typeof(TResult), null); 
		}

		public string Convert(string value, int fromRadix, int toRadix, CultureInfo culture = null)
		{
			return this.Convert<string>(value, fromRadix, toRadix, culture);
		}



	}
}