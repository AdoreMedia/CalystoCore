using System;
using System.Collections.Generic;
using System.Linq;

namespace Calysto.Common
{
	/// <summary>
	/// Calculates time span in years, months, days, and time
	/// </summary>
	public class CalystoTimeSpan
	{
		public bool IsNegative { get; private set; }
		public int Years { get; private set; }
		public int Months { get; private set; }
		public int Days { get; private set; }
		public TimeSpan Time { get; private set; }

		public double TotalMonths => this.Years * 12 + this.Months + this.Days / 31.0;

		public string FormatedDays => this.Years + "y " + this.Months + "m " + this.Days + "d ";
		public string FormatedTime => this.FormatedDays + this.Time;

		public CalystoTimeSpan(DateTime start, DateTime end)
		{
			this.IsNegative = start > end;

			List<DateTime> list = new List<DateTime>() { start, end };
			start = list.Min();
			end = list.Max();

			DateTime tmp1 = start;
			while (tmp1.AddYears(1) < end)
			{
				this.Years++;
				tmp1 = tmp1.AddYears(1);
			}

			while (tmp1.AddMonths(1) < end)
			{
				this.Months++;
				tmp1 = tmp1.AddMonths(1);
			}

			while (tmp1.AddDays(1) < end)
			{
				this.Days++;
				tmp1 = tmp1.AddDays(1);
			}

			this.Time = end - tmp1;
		}
	}
}