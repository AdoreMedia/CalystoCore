using Calysto.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Calysto.Timers
{
	public class StopWatch
	{
		#region cached instances

		private static ConcurrentDictionary<string, StopWatch> _dicStopWatches = new ConcurrentDictionary<string, StopWatch>();

		/// <summary>
		/// Get cached instance by name.
		/// </summary>
		/// <param name="swName"></param>
		/// <returns></returns>
		public static StopWatch Instance(string swName = "#sw0")
		{
			return _dicStopWatches.GetOrAdd(swName, (key2) => new Calysto.Timers.StopWatch(swName));
		}

		#endregion

		private string SwName;
		static int _cnt = -1;
		private static IFormatProvider _format = System.Globalization.CultureInfo.GetCultureInfo("en-US");

		public StopWatch(string swName = null)
		{
			SwName = swName ?? Interlocked.Increment(ref _cnt).ToString();
		}

		public class MarkItem
		{
			public StopWatch Owner;
			public DateTime StartTime;
			public DateTime CurrentTime;
			public string Name;
			public DateTime PreviousTime;

			public TimeSpan FromStart => this.CurrentTime - this.StartTime;
			public TimeSpan FromPreivous => this.CurrentTime - this.PreviousTime;
			public string Statistics => $"from_start: {this.FromStart.TotalMilliseconds.ToString("n4", _format).PadLeft(14)}[ms]" 
				+ $" from_previous: {this.FromPreivous.TotalMilliseconds.ToString("n4", _format).PadLeft(14)}[ms]"
				+ $" @ {this.Name} - {this.Owner.SwName}";
		}

		DateTime _start = DateTime.Now;
		DateTime _lastMark = DateTime.Now;

		public readonly List<MarkItem> Items = new List<MarkItem>();

		public event Action<MarkItem> OnMark;

		private void Mark(string markName, DateTime markDateTime)
		{
			DateTime dt = DateTime.Now;
			MarkItem m = new MarkItem()
			{
				Owner = this,
				PreviousTime = _lastMark,
				StartTime = _start,
				CurrentTime = markDateTime,
				Name = markName
			};
			_lastMark = markDateTime;
			lock (this)
			{
				Items.Add(m);
				this.OnMark?.Invoke(m);
			}
		}

		public void Mark(string name) => this.Mark(name, DateTime.Now);

		public void Start()
		{
			_start = _lastMark = DateTime.Now;
			this.Mark("Start()", _start);
		}

		public void Stop() => this.Mark("Stop()");

		public void Reset()
		{
			this.Items.Clear();
		}


	}
}