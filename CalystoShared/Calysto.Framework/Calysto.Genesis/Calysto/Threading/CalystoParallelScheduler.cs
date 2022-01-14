using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Calysto.Threading
{
	public class CalystoParallelScheduler<TResult>
	{
		class Item1 
		{
			public Action<Action<TResult>> Executor;
			public Task<TResult> ResultTask;
			private TResult _result;
			public Item1()
			{
				this.ResultTask = new Task<TResult>(() => _result);
			}
			public void AssignResult(TResult result)
			{
				_result = result;
				this.ResultTask.Start();
			}
		}

		public event Action<string> OnLog;

		Queue<Item1> _queue = new Queue<Item1>();

		private int _paralelism = 1;
		private int _runningCount = 0;
		
		private bool StartNextAction()
		{
			Item1 item;
			lock (this)
			{
				if (_runningCount >= _paralelism)
					return false;

				if(_queue.Count == 0)
					return false;

				item = _queue.Dequeue();

				_runningCount++;
			}

			DateTime dt1 = DateTime.Now;
			this.OnLog?.Invoke("start, running: " + _runningCount);

			Action<TResult> fnComplete = (result) =>
			{
				item.AssignResult(result);

				lock (this)
				{
					_runningCount--;
					this.StartPool();
				}
			};

			new Thread(() =>
			{
				try
				{
					item.Executor(result =>
					{
						fnComplete(result);
						this.OnLog?.Invoke("success in " + (DateTime.Now - dt1).TotalMilliseconds + " ms, running: " + _runningCount);
					});
				}
				catch (Exception ex)
				{
					fnComplete(default);
					this.OnLog?.Invoke("error in " + (DateTime.Now - dt1).TotalMilliseconds + " ms, running: " + _runningCount + ", error: " + ex.Message);
				}
			}).StartBackground();

			return true;
		}

		private void StartPool()
		{
			while (this.StartNextAction())
			{
			}
		}

		public CalystoParallelScheduler(int paralelism)
		{
			_paralelism = paralelism;
		}

		public Task<TResult> RunScheduledAsync(Action<Action<TResult>> executor)
		{
			Item1 item = new Item1()
			{
				Executor = executor
			};

			lock (this)
			{
				_queue.Enqueue(item);
			}

			new Thread(() => this.StartPool()).StartBackground();

			return item.ResultTask;
		}
	}
}
