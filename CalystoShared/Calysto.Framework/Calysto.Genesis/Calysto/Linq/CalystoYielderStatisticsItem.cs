using System;
using System.Collections.Generic;

namespace Calysto.Linq
{
	public class CalystoYielderStatisticsItem
	{
		public double ProgressPercent { get; }
		public TimeSpan? TimeSpent { get; }
		public TimeSpan? TimeLeft { get; }
		public int CountTotal { get; }
		public int CountTaken { get; }
		public int CountLeft { get; }

		public static string GetTimeFormatedString(TimeSpan? ts)
		{
			if (!ts.HasValue) return "?";

			string s1 = ts?.ToString("dd\\d\\ hh\\:mm\\:ss");
			while (s1.Length > 4)
			{
				char ch1 = s1[0];
				if (!char.IsDigit(ch1) || ch1 == '0')
				{
					s1 = s1.Substring(1);
				}
				else
				{
					break;
				}
			}
			return s1;
		}

		public CalystoYielderStatisticsItem(CalystoStatisticsProvider provider)
		{
			this.ProgressPercent = (100.0 * provider.CountTaken / provider.CountTotal);
			this.TimeSpent = provider.TimeSpent;
			this.TimeLeft = provider.TimeLeft;
			this.CountTotal = provider.CountTotal;
			this.CountTaken = provider.CountTaken;
			this.CountLeft = provider.CountLeft;
		}

		public IEnumerable<string> GetRows()
		{
			yield return "progress: " + this.ProgressPercent.ToString("n3") + "%";
			yield return "TSpent: " + GetTimeFormatedString(this.TimeSpent);
			yield return "TLeft: " + GetTimeFormatedString(this.TimeLeft);
			yield return "total: " + this.CountTotal;
			yield return "taken: " + this.CountTaken;
			yield return "left: " + this.CountLeft;
		}

		public string ToStringFormated() => string.Join(", ", this.GetRows());
	}
}

