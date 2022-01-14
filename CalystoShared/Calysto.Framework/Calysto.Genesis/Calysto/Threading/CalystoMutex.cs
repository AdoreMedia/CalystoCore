using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;

namespace Calysto.Threading
{
	/// <summary>
	/// Thread safe mutex. Can be released from any thread.
	/// </summary>
	public class CalystoMutex : IDisposable
	{
		public CalystoMutex(int initialEntrances = 0)
		{
			this.Entrances = initialEntrances;
			_lockingObject = this;
		}

		public int Entrances { get; private set; }

		private bool _abortRequested;

		private object _lockingObject;

		#region Wait methods

		/// <summary>
		/// All threads will wait, including the first one, until the ReleaseOne() is invoked.
		/// When invoked ReleaseOne(), first thread will enter, other have to wait for next ReleaseOne()
		/// </summary>
		/// <returns>True if successful, false if timeouted.</returns>
		public bool Wait() => this.Wait(-1);

		/// <summary>
		/// All threads will wait, including the first one, until the ReleaseOne() is invoked.
		/// When invoked ReleaseOne(), first thread will enter, other have to wait for next ReleaseOne()
		/// </summary>
		/// <param name="millisecondsTimeout"></param>
		/// <returns>True if successful, false if timeouted.</returns>
		public bool Wait(int millisecondsTimeout) => this.Wait(TimeSpan.FromMilliseconds(millisecondsTimeout));

		/// <summary>
		/// All threads will wait, including the first one, until the ReleaseOne() is invoked.
		/// When invoked ReleaseOne(), first thread will enter, other have to wait for next ReleaseOne()
		/// </summary>
		/// <param name="millisecondsTimeout"></param>
		/// <returns>True if successful, false if timeouted.</returns>
		public bool Wait(TimeSpan timeSpan) => this.WaitingWorker(0, timeSpan);

		/// <summary>
		/// Allow first thread to enter, other will have to wait until ReleaseOne() is invoked.
		/// </summary>
		/// <param name="timeSpan"></param>
		/// <returns>True if successful, false if timeouted.</returns>
		public bool EnterOne() => this.EnterOne(TimeSpan.FromMilliseconds(-1));

		/// <summary>
		/// Allow first thread to enter, other will have to wait until ReleaseOne() is invoked.
		/// </summary>
		/// <param name="timeSpan"></param>
		/// <returns>True if successful, false if timeouted.</returns>
		public bool EnterOne(TimeSpan timeSpan) => this.WaitingWorker(1, timeSpan);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="allowedEntrances"></param>
		/// <param name="timeSpan"></param>
		/// <returns>True if successful, false if timeouted.</returns>
		private bool WaitingWorker(int allowedEntrances, TimeSpan timeSpan)
		{ 
			lock (_lockingObject)
			{
				if (++this.Entrances <= allowedEntrances)
				{
					// current thread doesn't have to wait
					return true;
				}

				bool result1 = false;

				try
				{
					result1 = Monitor.Wait(_lockingObject, timeSpan);
					if (result1)
					{
						// ReleaseOne() or ReleaseAll() or AbortAll(), invoked Monitor.Pulse()
					}
					else
					{
						// timeout
						--this.Entrances;
					}
				}
				catch
				{
					result1 = false;
				}

				if (_abortRequested)
					throw new OperationCanceledException();
				else
					return result1;
			}
		}

		#endregion

		/// <summary>
		/// Will release one initial entrace first, when initial entrances are 0, than will release one waiting thread. 
		/// May be invoked from any thread.
		/// May be invoked in advance, before Wait or WaitOne is invoked, this way we decrement Entrances counter allowing the next call to Wait not to wait at all.
		/// </summary>
		public void ReleaseOne()
		{
			lock (_lockingObject)
			{
				if(--this.Entrances <= 0)
					Monitor.Pulse(_lockingObject);
			}
		}

		/// <summary>
		/// Will release all waiting threads.
		/// </summary>
		public void ReleaseAll()
		{
			lock (_lockingObject)
			{
				this.Entrances = 0;
				Monitor.PulseAll(_lockingObject);
			}
		}

		/// <summary>
		/// Release all from Wait() and throw <see cref="OperationCanceledException"/>
		/// </summary>
		public void AbortAll()
		{
			_abortRequested = true;
			this.ReleaseAll();
		}

		public bool IsDisposed { get; private set; }

		public void Dispose()
		{
			if (this.IsDisposed)
				return;
			this.IsDisposed = true;

			this.AbortAll();
		}
	}
}
