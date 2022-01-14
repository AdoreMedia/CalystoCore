using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Calysto.Linq
{
	public static class SelectParallelExtensionsThreads
	{
		class ResultItem<TResult>
		{
			public TResult Result;
			public Exception Ex;
		}

		private static IEnumerable<TResult> SelectParallelWorkerThreads<TSource, TResult>(
			this IEnumerable<TSource> items,
			Func<TSource, TResult> fnResultExecutor,
			Func<TSource, Task<TResult>> fnTaskExecutor,
			int? parallelThreads = default,
			int? prefetchCount = default)
		{
			parallelThreads = parallelThreads ?? Environment.ProcessorCount;
			prefetchCount = prefetchCount ?? 0;

			int waitMs = 20000;
			bool isEnumerableCompleted = false;
			List<ResultItem<TResult>> resultsList = new List<ResultItem<TResult>>();
			IEnumerator<TSource> enumerator1 = items.GetEnumerator();

			List<Thread> threadsList = Enumerable.Range(0, parallelThreads.Value).Select(num => new Thread(() =>
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
								res1.Result = fnTaskExecutor.Invoke(srcItem).Result;
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

						Monitor.PulseAll(resultsList);

						while (resultsList.Count >= (parallelThreads.Value + prefetchCount.Value))
						{
							// sleep
							Monitor.Wait(resultsList, waitMs);
						}
					}

				}
			})).ToList();

			bool isThreadsListEnded = false;

			Thread thr2 = new Thread(() =>
			{
				threadsList.ForEach(o => o.Start());
				threadsList.ForEach(o => o.Join());
				lock (resultsList)
				{
					isThreadsListEnded = true;
					Monitor.PulseAll(resultsList);
				}
			});
			thr2.Start();

			while (!isEnumerableCompleted)
			{
				ResultItem<TResult> res1 = null;

				lock (resultsList)
				{
					if (resultsList.Any())
					{
						res1 = resultsList[0];
						resultsList.RemoveAt(0);
						Monitor.PulseAll(resultsList);
					}
					else if (isThreadsListEnded)
					{
						break;
					}
					else
					{
						Monitor.Wait(resultsList, waitMs);
						continue;
					}
				}

				if (res1 != null)
				{
					if (res1?.Ex != null)
					{
						isEnumerableCompleted = true;
						throw res1.Ex;
					}
					else
					{
						yield return res1.Result;
					}
				}
			}

			isEnumerableCompleted = true;
		}

		public static IEnumerable<TResult> SelectParallel2<TSource, TResult>(
			this IEnumerable<TSource> items,
			Func<TSource, TResult> fnResultExecutor,
			int? parallelThreads = default,
			int? prefetchCount = default)
		{
			return items.SelectParallelWorkerThreads(fnResultExecutor, null, parallelThreads, prefetchCount);
		}

		public static IEnumerable<TResult> SelectParallel2<TSource, TResult>(
			this IEnumerable<TSource> items,
			Func<TSource, Task<TResult>> fnTaskExecutor,
			int? parallelThreads = default,
			int? prefetchCount = default)
		{
			return items.SelectParallelWorkerThreads(null, fnTaskExecutor, parallelThreads, prefetchCount);
		}
	}
}


