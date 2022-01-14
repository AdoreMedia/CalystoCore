using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calysto.Threading.Tasks
{
	public class TrackedTask
	{
		public Task Task { get; }
		public string Name { get; }

		public TrackedTask(Task task, string name)
		{
			this.Task = task;
			this.Name = name;
		}
	}

	public class CalystoTaskTracker : IDisposable
	{
		object _rwlock = new object();
		List<TrackedTask> _items = new List<TrackedTask>();

		public bool IsDisposed { get; private set; }

		public void Dispose()
		{
			this.IsDisposed = true;
			this._timer?.Stop();
		}

		~CalystoTaskTracker()
		{
			this.Dispose();
		}

		System.Timers.Timer _timer;

		public CalystoTaskTracker()
		{
			_timer = new System.Timers.Timer(5000);
			_timer.Elapsed += _timer_Elapsed;
			_timer.AutoReset = true;
			_timer.Start();
		}

		private void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			lock (_rwlock)
			{
				// brisi izvrsene threadove, zapravo, ostavi samo aktivne
				_items = this.GetAliveItems();
			}
		}

		/// <summary>
		/// Return collection copy of TrackedItems
		/// </summary>
		/// <returns></returns>
		public List<TrackedTask> GetAliveItems()
		{
			lock(_rwlock)
			{
				return _items.Where(o => !o.Task.IsEnded()).ToList();
			}
		}

		public void Track(Task task, string name = null)
		{
			lock(_rwlock)
			{
				_items.Add(new TrackedTask(task, name));
			}
		}

		private static CalystoTaskTracker _current;

		public static CalystoTaskTracker Current => _current ?? (_current = new CalystoTaskTracker());

	}
}
