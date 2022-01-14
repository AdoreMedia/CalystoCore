using System;

namespace Calysto.Linq
{
	public partial class CalystoStatisticsProvider
	{
		/// <summary>
		/// Total unique items for processing.
		/// </summary>
		public virtual int CountTotal { get; protected set; }

		/// <summary>
		/// Number of processed items, including retryes. Final number may be much larger than CountTotal.
		/// </summary>
		public virtual int CountTaken { get; protected set; }

		/// <summary>
		/// Total items left for processing.
		/// </summary>
		public virtual int CountLeft => this.CountTotal - this.CountTaken;

		public DateTime? TimeStart { get; protected set; } = DateTime.Now;

		public TimeSpan? TimeSpent => DateTime.Now - this.TimeStart;

		protected double GetSecondsLeft()
		{
			lock (this)
			{
				double uniqueProcessed = (double)(this.CountTotal - this.CountLeft);
				if (uniqueProcessed == 0)
					return -1;

				double secPerItem = this.TimeSpent.GetValueOrDefault().TotalSeconds / uniqueProcessed;
				return secPerItem * (double)this.CountLeft;
			}
		}

		public TimeSpan TimeLeft => TimeSpan.FromSeconds(this.GetSecondsLeft());

		public CalystoYielderStatisticsItem GetStatisticsItem()
		{
			lock (this)
			{
				return new CalystoYielderStatisticsItem(this);
			}
		}
	}
}
