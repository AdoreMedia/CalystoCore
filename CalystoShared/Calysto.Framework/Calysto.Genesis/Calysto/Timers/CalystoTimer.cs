using System;
using System.Threading.Tasks;

namespace Calysto.Timers
{
	public class CalystoTimer : IDisposable
	{
		public bool IsDisposed { get; private set; }
		public void Dispose()
		{
			if (this.IsDisposed) return;
			this.IsDisposed = true;
			_isRunning = false;
			try { _timer?.Dispose(); } catch { }
			_timer = null;
		}

		~CalystoTimer() => this.Dispose();

		System.Threading.Timer _timer;

		public CalystoTimer(Action<CalystoTimer> onTimeout)
		{
			_timer = new System.Threading.Timer(state =>
			{
				_isRunning = false;
				onTimeout.Invoke(this);
			});
		}

		public CalystoTimer(Func<CalystoTimer, Task> onTimeout)
		{
			_timer = new System.Threading.Timer(async (state) =>
			{
				_isRunning = false;
				await onTimeout.Invoke(this);
			});
		}

		bool _isRunning;

		/// <summary>
		/// Restart timer with new timeoutMs.
		/// </summary>
		/// <param name="timeoutMs"></param>
		/// <returns></returns>
		public CalystoTimer Start(int timeoutMs)
		{
			if (!this.IsDisposed)
			{
				lock (this)
				{
					_isRunning = true;
					// let's try 3 times
					if (_timer?.Change(timeoutMs, -1) != true)
						if (_timer?.Change(timeoutMs, -1) != true)
							if (_timer?.Change(timeoutMs, -1) != true)
								throw new InvalidOperationException("Failed to start timer");
				
					return this;
				}
			}
			throw new ObjectDisposedException(nameof(CalystoTimer));
		}

		/// <summary>
		/// Abort timer.
		/// </summary>
		public CalystoTimer Abort()
		{
			lock (this)
			{
				// abort if timer is running
				// let's try 3 times
				if (_timer?.Change(-1, -1) != true) // -1 or Infinite will stop timer
					if (_timer?.Change(-1, -1) != true)
						_timer?.Change(-1, -1);

				_isRunning = false;
				return this;
			}
		}

		public bool IsRunning
		{
			get
			{
				lock (this)
				{
					return _isRunning;
				}
			}
		}

		/// <summary>
		/// Create and start new timer.
		/// </summary>
		/// <param name="timeoutMs"></param>
		/// <param name="onTimeout"></param>
		/// <returns></returns>
		public static CalystoTimer Start(int timeoutMs, Action<CalystoTimer> onTimeout)
		{
			return new CalystoTimer(onTimeout).Start(timeoutMs);
		}
	}
}

