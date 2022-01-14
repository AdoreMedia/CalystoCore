using System;
using System.Globalization;

namespace Calysto.Common.Extensions
{
	public static class DateTimeExtensions
	{
		////static TimeZoneInfo _cetZoneInfo = TimeZoneInfo.GetSystemTimeZones().Where(o => o.DisplayName.Contains("Zagreb")).First();

		/////// <summary>
		/////// Convert from Local time zone to Central european time zone
		/////// </summary>
		////public static DateTime ToCETZone(this DateTime dt)
		////{
		////	if (dt.Kind == DateTimeKind.Utc)
		////	{
		////		return TimeZoneInfo.ConvertTimeFromUtc(dt, _cetZoneInfo);
		////	}
		////	else
		////	{
		////		// Local or Unspecified
		////		return TimeZoneInfo.ConvertTime(dt, TimeZoneInfo.Local, _cetZoneInfo);
		////	}
		////}

		/// <summary>
		/// To date and time string in current culture (dd.MM.yyyy. HH:mm:ss)
		/// </summary>
		/// <param name="dt"></param>
		/// <returns></returns>
		public static string ToGeneralLongTimeString(this DateTime? dt)
		{
			if(dt == null)
			{
				return null;
			}
			else
			{
				return ToGeneralLongTimeString(dt.Value);
			}
		}

		/// <summary>
		/// To date and time string in current culture (dd.MM.yyyy. HH:mm:ss)
		/// </summary>
		/// <param name="dt"></param>
		/// <returns></returns>
		public static string ToGeneralLongTimeString(this DateTime dt)
		{
			return dt.ToShortDateString().Replace(" ", "") + " " + dt.ToLongTimeString();
		}

		/// <summary>
		/// To date and time string in HR culture (dd.MM.yyyy. HH:mm:ss)
		/// </summary>
		/// <param name="dt"></param>
		/// <returns></returns>
		public static string ToHRLongTimeString(this DateTime? dt)
		{
			if(dt == null)
			{
				return null;
			}
			return dt.Value.ToHRLongTimeString();
		}

		/// <summary>
		/// To date and time string in HR culture (dd.MM.yyyy. HH:mm:ss)
		/// </summary>
		/// <param name="dt"></param>
		/// <returns></returns>
		public static string ToHRLongTimeString(this DateTime dt)
		{
			return dt.ToString("dd.MM.yyyy. HH:mm:ss");
		}

		/// <summary>
		/// this format doesn't include time zone and may be parsed in browsers 
		/// even old IE like new Date("yyyy-MM-ddTHH:mm:ss.ffffff"), it will create exact time instance
		/// with correct hours, only browser's time zone will be used, but we don't need time zone as long as hours is correct
		/// </summary>
		public const string ISOTDateTimeFormat = "yyyy-MM-ddTHH:mm:ss.ffffff";

		/// <summary>
		/// To date and time string in ISO format (yyyy-MM-ddTHH:mm:ss.ffffff)
		/// </summary>
		/// <param name="dt"></param>
		/// <returns></returns>
		public static string ToISOTDateTimeString(this DateTime? dt)
		{
			if (dt == null)
			{
				return null;
			}
			return dt.Value.ToISOTDateTimeString();
		}

		/// <summary>
		/// To date and time string in ISO format (yyyy-MM-ddTHH:mm:ss.ffffff)
		/// </summary>
		/// <param name="dt"></param>
		/// <returns></returns>
		public static string ToISOTDateTimeString(this DateTime dt)
		{
			return dt.ToString(ISOTDateTimeFormat);
		}

		public static DateTime ParseISOTDateTimeString(string dt)
		{
			// we have standard format, so it may be parsed without specifying the format
			return DateTime.Parse(dt);
		}
	}

}
