using System;
using System.Globalization;

namespace Calysto.Globalization
{
	public class CalystoFormatter
	{
		public static CalystoFormatter USFormatter { get; } = new CalystoFormatter(CalystoCultureInfoHelper.USCulture);

		public static CalystoFormatter HRFormatter { get; } = new CalystoFormatter(CalystoCultureInfoHelper.HRCulture);

		public static CalystoFormatter SRFormatter { get; } = new CalystoFormatter(CalystoCultureInfoHelper.SRCulture);

		public static CalystoExcelFormatter ExcelFormatter { get; } = new CalystoExcelFormatter();

		public static CalystoFormatter CurrentCultureFormatter { get { return new CalystoFormatter(System.Threading.Thread.CurrentThread.CurrentCulture); } }

		protected CultureInfo _culture;

		public CalystoFormatter(CultureInfo culture)
		{
			_culture = culture;
		}

		/// <summary>
		/// Format with thousands separator and optional decimal palces using current culture info.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="exactDecimalPlaces"></param>
		/// <returns></returns>
		public string FormatNumber(decimal? value, int exactDecimalPlaces)
		{
			if (value == null)
			{
				return null;
			}
			else
			{
				return value.GetValueOrDefault().ToString("N" + exactDecimalPlaces, _culture);
			}
		}

		/// <summary>
		/// Format with thousands separator. Format with auto decimal places, depending on number of decimals, keep or remove zeros from end.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="minDecimalPlaces"></param>
		/// <param name="maxDecimalPlaces"></param>
		/// <returns></returns>
		public string FormatNumber(decimal? value, int minDecimalPlaces, int maxDecimalPlaces)
		{
			if (value == null)
			{
				return null;
			}
			else
			{
				string strMin = value.Value.ToString("N" + minDecimalPlaces, _culture);
				string strMax = value.Value.ToString("N" + maxDecimalPlaces, _culture);
				while ((strMax.EndsWith("0") || strMax.EndsWith(".") || strMax.EndsWith(",")) && strMax.Length > strMin.Length)
				{
					strMax = strMax.Substring(0, strMax.Length - 1); // remove last one
				}
				return strMax;
			}
		}

		/// <summary>
		/// Format with thousands separator.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="minDecimalPlaces"></param>
		/// <param name="maxDecimalPlaces"></param>
		/// <returns></returns>
		public string FormatNumber(double? value, int minDecimalPlaces, int maxDecimalPlaces)
		{
			return FormatNumber((decimal?)value, minDecimalPlaces, maxDecimalPlaces);
		}

		/// <summary>
		/// Format with thousands separator.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="exactDecimalPlaces"></param>
		/// <returns></returns>
		public string FormatNumber(double? value, int exactDecimalPlaces)
		{
			return FormatNumber((decimal?)value, exactDecimalPlaces);
		}

		/// <summary>
		/// Format with thousands separator.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="exactDecimalPlaces"></param>
		/// <returns></returns>
		public string FormatNumber(float? value, int exactDecimalPlaces)
		{
			return FormatNumber((decimal?)value, exactDecimalPlaces);
		}

		/// <summary>
		/// Format with thousands separator.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public string FormatNumber(int? value)
		{
			return FormatNumber((decimal?)value, 0);
		}

		/// <summary>
		/// Format with 2 exact decimal places.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="addCurrencySymbol"></param>
		/// <returns></returns>
		public string FormatCurrency(decimal? value, bool addCurrencySymbol)
		{
			if (value == null)
			{
				return null;
			}
			else if (addCurrencySymbol)
			{
				return value.GetValueOrDefault().ToString("c");
			}
			else
			{
				return value.GetValueOrDefault().ToString("N2");
			}
		}

		/// <summary>
		/// Just date.
		/// </summary>
		/// <param name="date"></param>
		/// <returns></returns>
		public virtual string FormatDate(DateTime? date)
		{
			if (date != null)
			{
				return date.Value.ToString(_culture.DateTimeFormat.ShortDatePattern);
			}
			return null;
		}

		/// <summary>
		/// Date, hours, minutes, seconds
		/// </summary>
		/// <param name="dateTime"></param>
		/// <returns></returns>
		public virtual string FormatDateTime(DateTime? dateTime)
		{
			if (dateTime != null)
			{
				return dateTime.Value.ToString(_culture.DateTimeFormat.ShortDatePattern + " " + _culture.DateTimeFormat.LongTimePattern);
			}
			return null;
		}

		/// <summary>
		/// Date, hours, minutes
		/// </summary>
		/// <param name="dateTime"></param>
		/// <returns></returns>
		public virtual string FormatGeneralShortTime(DateTime? dateTime)
		{
			if (dateTime != null)
			{
				CalystoDateTimeFormat ff = new CalystoDateTimeFormat(_culture);
				return dateTime.Value.ToString(ff.GeneralShortTimePattern);
			}
			return null;
		}

		/// <summary>
		/// parse DateTime from string using fromat or globalization pattern, datetime first, than date only, or throw exception if can not be parsed
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public virtual DateTime ParseDateTime(string str, string format)
		{
			DateTime dt;

			if (format != null)
			{
				if (DateTime.TryParseExact(str, format, null, DateTimeStyles.None, out dt))
				{
					return dt;
				}
			}
			else if (DateTime.TryParseExact(str, _culture.DateTimeFormat.ShortDatePattern + " " + _culture.DateTimeFormat.LongTimePattern, null, DateTimeStyles.None, out dt))
			{
				return dt;
			}
			else if (DateTime.TryParseExact(str, _culture.DateTimeFormat.ShortDatePattern, null, DateTimeStyles.None, out dt))
			{
				return dt;
			}

			throw new Exception("Can not parse DateTime from: " + str);
		}

		/// <summary>
		/// parse DateTime from string using fromat or globalization pattern, datetime first, than date only, or throw exception if can not be parsed
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public virtual DateTime ParseDateTime(string str)
		{
			return ParseDateTime(str, null);
		}

		/// <summary>
		/// if str is null or empty, return null, else use decimal.Parse(str, currentCulture)
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public virtual decimal? ParseNumber(string str)
		{
			if (string.IsNullOrEmpty(str))
			{
				return null;
			}

			return decimal.Parse(str, _culture);
		}
	}
}
