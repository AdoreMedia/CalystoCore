using System;
using System.Globalization;

namespace Calysto.Globalization
{
	public class CalystoExcelFormatter
	{
		public const string ExcelDateFormat = "yyyy-MM-dd";
		public const string ExcelDateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fff";

		public CalystoExcelFormatter()
		{
		}

		/// <summary>
		/// Excel specific date format
		/// </summary>
		/// <param name="date"></param>
		/// <returns></returns>
		public string FormatDate(DateTime? date)
		{
			if (date != null)
			{
				return date.Value.ToString(ExcelDateFormat);
			}
			return null;
		}

		public string FormatDateTime(DateTime? dateTime)
		{
			if (dateTime != null)
			{
				return dateTime.Value.ToString(ExcelDateTimeFormat);
			}
			return null;
		}

		public string FormatNumber(int? num)
		{
			if (num == null) return null;
			return num.Value.ToString(CalystoCultureInfoHelper.USCulture); // has to be formated with decimal dot eg. 423523523.623424
		}

		public string FormatNumber(double? num)
		{
			if (num == null) return null;
			return num.Value.ToString(CalystoCultureInfoHelper.USCulture); // has to be formated with decimal dot eg. 423523523.623424
		}

		public string FormatNumber(decimal? num)
		{
			if (num == null) return null;
			return num.Value.ToString(CalystoCultureInfoHelper.USCulture); // has to be formated with decimal dot eg. 423523523.623424
		}

		public DateTime ParseDateTime(string str)
		{
			DateTime dt;

			if (DateTime.TryParseExact(str, ExcelDateTimeFormat, null, DateTimeStyles.None, out dt))
			{
				return dt;
			}
			else if (DateTime.TryParseExact(str, ExcelDateFormat, null, DateTimeStyles.None, out dt))
			{
				return dt;
			}

			throw new Exception("Can not parse DateTime from: " + str);
		}


	}
}