using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Calysto.Threading.Tasks
{
	public static class TaskUtility
	{
		public static Task SleepAsync(int durationMs, CancellationToken? cancellationToken = null)
		{
			return Task.Delay(durationMs, cancellationToken ?? CancellationToken.None);
		}

		/// <summary>
		/// The await is returned when resolve(result) is invoked inside executor method.
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="executor">executor: (resolveCallback(result)=>void)=>void</param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public static Task<TResult> CallbackAsync<TResult>(Action<Action<TResult>> executor, CancellationToken? cancellationToken = null)
		{
			CancellationToken token1 = cancellationToken ?? CancellationToken.None;
			TaskCompletionSource<TResult> taskCompletion = new TaskCompletionSource<TResult>();

			_=Task.Run(() =>
			{
				try
				{
					if (!token1.IsCancellationRequested)
					{
						executor.Invoke(result2 => taskCompletion.SetResult(result2));
					}
					else
					{
						taskCompletion.SetCanceled();
					}
				}
				catch(Exception ex)
				{
					taskCompletion.SetException(ex);
				}
			}, token1);

			return taskCompletion.Task;
		}

		public static Task RunPoolAsync(
			int threads,
			Func<Task> executor,
			CancellationToken? cancellationToken = null,
			Action<Task> taskCreated = null)
		{
			CancellationToken token1 = cancellationToken ?? CancellationToken.None;

			var list = Enumerable.Range(0, threads).Select(n =>
			{
				Task task1 = Task.Run(async () =>
				{
					await executor.Invoke();
				}, token1);

				taskCreated?.Invoke(task1);

				return task1;

			}).ToArray();

			return Task.WhenAll(list);
		}

		public static Task RunPoolAsync(
			int threads,
			Action executor,
			CancellationToken? cancellationToken = null,
			Action<Task> taskCreated = null)
		{
			return RunPoolAsync(threads, () => Task.Run(executor), cancellationToken, taskCreated);
		}
	}
}

