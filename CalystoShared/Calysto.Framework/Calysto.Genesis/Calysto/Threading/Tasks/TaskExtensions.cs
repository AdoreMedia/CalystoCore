using System;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Calysto.Threading.Tasks
{
	public static class TaskExtensions
	{
		/// <summary>
		/// Throw TimeoutException() on timeout.
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="task"></param>
		/// <param name="timeoutMs"></param>
		/// <returns></returns>
		public static async Task<TResult> TimeoutAsync<TResult>(this Task<TResult> task, int timeoutMs)
		{
			CancellationTokenSource tokenSource = new CancellationTokenSource();
			var timeout1 = Task.Delay(timeoutMs, tokenSource.Token);
			Task finished1 = await Task.WhenAny(task, timeout1);
			if (finished1 == timeout1)
			{
				throw new TimeoutException($"Timeout after {timeoutMs} ms");
			}
			else if (finished1 == task)
			{
				tokenSource.Cancel();
				return task.Result;
			}
			else
				throw new InvalidOperationException();
		}

		/// <summary>
		/// Throw TimeoutException() on timeout.
		/// </summary>
		/// <param name="task"></param>
		/// <param name="timeoutMs"></param>
		/// <returns></returns>
		public static async Task TimeoutAsync(this Task task, int timeoutMs)
		{
			CancellationTokenSource tokenSource = new CancellationTokenSource();
			var timeout1 = Task.Delay(timeoutMs, tokenSource.Token);
			Task finished1 = await Task.WhenAny(task, timeout1);
			if (finished1 == timeout1)
			{
				throw new TimeoutException($"Timeout after {timeoutMs} ms");
			}
			else if (finished1 == task)
			{
				tokenSource.Cancel();
				return;
			}
			else
				throw new InvalidOperationException();
		}
	}
}

