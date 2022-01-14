using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Calysto.Linq
{
	public static class SelectParallelExtensions2
	{
		private static bool TryGetItemSafe<T>(List<T> items, out T result)
		{
			lock (items)
			{
				if (items.Any())
				{
					result = items[0];
					items.RemoveAt(0);
					return true;
				}
				else
				{
					result = default;
					return false;
				}
			}
		}

		private static int CountSafe<T>(List<T> items)
		{
			lock (items)
				return items.Count;
		}

		class ResultItem<TResult>
		{
			public TResult Result;
			public Exception Ex;
		}

		private static async IAsyncEnumerable<TResult> SelectParallelWorkerAsync<TSource, TResult>(
			this IEnumerable<TSource> items,
			Func<TSource, TResult> fnResultExecutor,
			Func<TSource, Task<TResult>> fnTaskExecutor,
			int? parallelThreads = default,
			int? prefetchCount = default)
		{
			parallelThreads = parallelThreads ?? Environment.ProcessorCount;
			prefetchCount = prefetchCount ?? 0;

			int waitMs = 200000;
			bool isEnumerableCompleted = false;
			List<ResultItem<TResult>> resultsList = new List<ResultItem<TResult>>();
			SemaphoreSlim semaphore1 = new SemaphoreSlim(0);
			SemaphoreSlim semaphore2 = new SemaphoreSlim(0);
			IEnumerator<TSource> enumerator1 = items.GetEnumerator();

			List<Task> threadsList = Enumerable.Range(0, parallelThreads.Value).Select(async num =>
			{
				// taskovi reusaju threadove pa se ne moze vise puta setirati Thread.Name!
				//Thread.CurrentThread.Name = $"pt[{num}]";
				while (!isEnumerableCompleted)
				{
					bool hasItem = false;
					TSource srcItem = default;
					ResultItem<TResult> res1 = new ResultItem<TResult>();

					try
					{
						lock (resultsList)
						{
							hasItem = enumerator1.MoveNext();
							if (hasItem)
								srcItem = enumerator1.Current;
						}

						if (hasItem)
						{
							if (fnResultExecutor != null)
								res1.Result = fnResultExecutor.Invoke(srcItem);
							else if (fnTaskExecutor != null)
								res1.Result = await fnTaskExecutor.Invoke(srcItem);
							else
								throw new InvalidOperationException($"{nameof(fnResultExecutor)} or {nameof(fnTaskExecutor)} has to be defined");
						}
						else
						{
							// no more data
							return;
						}
					}
					catch (Exception ex)
					{
						res1.Ex = ex;
					}

					lock (resultsList)
					{
						resultsList.Add(res1);
					}

					// samo da se ubrza yield, nek odmah odradi svoje kad se pojavi novi rezultat
					semaphore1.Release();

					while (CountSafe(resultsList) >= (parallelThreads.Value + prefetchCount.Value))
					{
						// sleep
						await semaphore2.WaitAsync(waitMs);
					}

				}
			}).ToList();

			bool isThreadsListEnded = false;

			Task thr2 = Task.Run(async () =>
			{
				await Task.WhenAll(threadsList);
				isThreadsListEnded = true;
				semaphore1.Release();
			});

			while (!isEnumerableCompleted)
			{
				if (TryGetItemSafe(resultsList, out var res))
				{
					semaphore2.Release();
					if (res.Ex != null)
					{
						isEnumerableCompleted = true;
						throw res.Ex;
					}
					else
						yield return res.Result;
				}
				else if (isThreadsListEnded && CountSafe(resultsList) == 0)
				{
					break;
				}
				else
					await semaphore1.WaitAsync(waitMs);
			}

			isEnumerableCompleted = true;
			semaphore1.Dispose();
			semaphore2.Dispose();
		}

		public static IAsyncEnumerable<TResult> SelectParallelAsync<TSource, TResult>(
			this IEnumerable<TSource> items,
			Func<TSource, TResult> fnResultExecutor,
			int? parallelThreads = default,
			int? prefetchCount = default)
		{
			return items.SelectParallelWorkerAsync(fnResultExecutor, null, parallelThreads, prefetchCount);
		}

		public static IAsyncEnumerable<TResult> SelectParallelAsync<TSource, TResult>(
			this IEnumerable<TSource> items,
			Func<TSource, Task<TResult>> fnTaskExecutor,
			int? parallelThreads = default,
			int? prefetchCount = default)
		{
			return items.SelectParallelWorkerAsync(null, fnTaskExecutor, parallelThreads, prefetchCount);
		}
	}
}


