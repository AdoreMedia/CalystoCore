using System.Globalization;

namespace Calysto.Globalization
{
	public class CalystoDateTimeFormat
	{
		private DateTimeFormatInfo _df;

		/// <summary>
		/// "Su", "Mo", "Tu", "We", "Th", "Fr", "Sa"
		/// </summary>
		public string[] ShortestDayNames { get { return _df.ShortestDayNames; } }
		
		/// <summary>
		/// "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"
		/// </summary>
		public string[] AbbreviatedDayNames { get { return _df.AbbreviatedDayNames; } }

		/// <summary>
		///  "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"
		/// </summary>
		public string[] DayNames { get { return _df.DayNames; } }

		// "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"
		public string[] AbbreviatedMonthNames { get { return _df.AbbreviatedMonthNames; } }

		/// <summary>
		/// "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"
		/// </summary>
		public string[] MonthNames { get { return _df.MonthNames; } }
		
		/// <summary>
		/// (int) Sunday
		/// </summary>
		public int FirstDayOfWeek { get { return (int) _df.FirstDayOfWeek; } }
		
		/// <summary>
		/// "dddd, MMMM d, yyyy"
		/// </summary>
		public string LongDatePattern { get { return _df.LongDatePattern; } }
		
		/// <summary>
		/// "h:mm:ss tt"
		/// </summary>
		public string LongTimePattern { get { return _df.LongTimePattern; } }
		
		/// <summary>
		/// "MMMM d"
		/// </summary>
		public string MonthDayPattern { get { return _df.MonthDayPattern; } }
		
		/// <summary>
		/// "M/d/yyyy"
		/// </summary>
		public string ShortDatePattern { get { return _df.ShortDatePattern; } }
		
		/// <summary>
		/// "h:mm tt"
		/// </summary>
		public string ShortTimePattern { get { return _df.ShortTimePattern; } }
		
		/// <summary>
		/// "M/d/yyyy h:mm:ss tt", includes seconds
		/// </summary>
		public string GeneralLongTimePattern { get { return this.ShortDatePattern + " " + this.LongTimePattern; } }
		
		/// <summary>
		/// "M/d/yyyy h:mm tt", excludes seconds
		/// </summary>
		public string GeneralShortTimePattern { get { return this.ShortDatePattern + " " + this.ShortTimePattern; }}

		public CalystoDateTimeFormat(CultureInfo culture)
		{
			this._df = culture.DateTimeFormat;
		}
	}
}
