using System.Threading;

namespace Calysto.Threading
{
	public static class ThreadExtensions
	{
		/// <summary>
		/// Set IsBackground = true and invoke Start().
		/// </summary>
		/// <param name="thread"></param>
		/// <returns></returns>
		public static Thread StartBackground(this Thread thread)
		{
			thread.IsBackground = true;
			thread.Start();
			return thread;
		}

		/// <summary>
		/// Set IsBackground = false and invoke Start().
		/// </summary>
		/// <param name="thread"></param>
		/// <returns></returns>
		public static Thread StartNormal(this Thread thread)
		{
			thread.IsBackground = false;
			thread.Start();
			return thread;
		}

		/// <summary>
		/// Null or not yet started.
		/// </summary>
		/// <param name="thread"></param>
		/// <returns></returns>
		public static bool IsUnstarted(this Thread thread)
		{
			return thread == null || ((thread.ThreadState & ThreadState.Unstarted) == ThreadState.Unstarted);
		}

		/// <summary>
		/// Not null, started and not ended.
		/// </summary>
		/// <param name="thread"></param>
		/// <returns></returns>
		public static bool IsRunning(this Thread thread)
		{
			return thread != null && thread.IsAlive;
		}

		/// <summary>
		/// Not null, started and ended.
		/// </summary>
		/// <param name="thread"></param>
		/// <returns></returns>
		public static bool IsEnded(this Thread thread)
		{
			return thread != null && !thread.IsUnstarted() && !thread.IsRunning();
		}
	}
}
