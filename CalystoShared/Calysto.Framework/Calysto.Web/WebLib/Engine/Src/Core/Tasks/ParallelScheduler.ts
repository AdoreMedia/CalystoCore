namespace Calysto.Tasks
{
	class Item1<TResult>
	{
		public Executor: (resolve: (TResult) => void) => void;
		public ResultTask: Promise<TResult>;
		private _resolve: (TResult) => void;
		public constructor()
		{
			this.ResultTask = new Promise<TResult>(resolve => { this._resolve = resolve });
		}
		public AssignResult(result: TResult)
		{
			this._resolve(result);
		}
	}

	/**
	 * Execute async tasks one by one or in parallel if paralelisim > 1
	 */
	export class ParallelScheduler<TResult>
	{
		private _queue: Item1<TResult>[] = [];
		private _runningCount = 0;

		private _paralelism = 1;
		public constructor(paralelisim: number)
		{
			this._paralelism = paralelisim;
		}

		private _logListeners: ((string) => void)[] = [];
		public OnLog(fn: (string) => void)
		{
			this._logListeners.push(fn);
		}

		private NotifyLog(msg: string)
		{
			for (let fn of this._logListeners)
				fn(msg);
		}

		private StartNextAction()
		{
			let item;
			//lock(this)
			{
				if (this._runningCount >= this._paralelism)
					return false;

				if (this._queue.length == 0)
					return false;

				item = this._queue.shift();

				this._runningCount++;
			}

			let dt1 = Date.now();
			this.NotifyLog("start, running: " + this._runningCount);

			let fnComplete = (result?) =>
			{
				//lock(this)
				{
					this._runningCount--;
					this.StartPool();
				}
				item.AssignResult(result);
			};

			setTimeout(() =>
			{
				try
				{
					item.Executor(result =>
					{
						fnComplete(result);
						this.NotifyLog("success in " + (Date.now() - dt1) + " ms, running: " + this._runningCount);
					});
				}
				catch (ex)
				{
					fnComplete();
					this.NotifyLog("error in " + (Date.now() - dt1) + " ms, running: " + this._runningCount + ", error: " + ex);
				}
			});

			return true;
		}

		private StartPool()
		{
			while (this.StartNextAction())
			{
			}
		}

		/**
		 * Add new executor method. Added methods will be executed one by one or in parallel if paralelisim > 0.
		 * @param executor
		 */
		public RunScheduledAsync(executor: (resolve: (TResult)=>void) => void)
		{
			let item = new Item1<TResult>();
			item.Executor = executor;

			this._queue.push(item);

			setTimeout(() => this.StartPool());

			return item.ResultTask;
		}
	}
}