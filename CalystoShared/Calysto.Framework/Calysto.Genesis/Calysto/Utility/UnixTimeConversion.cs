using System;

namespace Calysto.Utility
{
	/// <summary>
	/// 1 .NET Tick = 1ms/10000
	/// 10000 .NET Ticks = 1ms
	/// unixMilliseconds always represents UTC ticks, web browser will add time zone offset
	/// </summary>
	public class UnixTimeConversion
	{
		static readonly DateTime UnixZeroTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
		static readonly long DatetimeMinTimeTicks = UnixZeroTime.Ticks;

		/// <summary>
		/// Returns UTC datetime.
		/// </summary>
		/// <param name="unixMilliseconds">UTC ticks</param>
		/// <returns></returns>
		public static DateTime GetUTCDateTime(double unixMilliseconds)
		{
			return UnixZeroTime.AddMilliseconds(unixMilliseconds);
		}

		/// <summary>
		/// Convert dateTime to UTC and return unixMilliseconds as UTC ticks.
		/// </summary>
		/// <param name="dateTime"></param>
		/// <returns></returns>
		public static double GetUnixMilliseconds(DateTime dateTime)
		{
			DateTime dt1 = dateTime.Kind == DateTimeKind.Utc ? dateTime : dateTime.ToUniversalTime();
			return (new TimeSpan(dt1.Ticks - DatetimeMinTimeTicks)).TotalMilliseconds;
		}
	}
}
