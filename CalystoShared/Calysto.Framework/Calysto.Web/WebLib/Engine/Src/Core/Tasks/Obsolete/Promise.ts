//namespace Calysto
//{
//	export interface IPromiseState
//	{
//		IsComplete: boolean;
//	}

//	export class CalystoPromise<TResult> implements IPromiseState
//	{
//		private _result: TResult;
//		private _isSuccessful = new Calysto.BoxValue<boolean>();
//		private _exception: any;
//		private _isNextInvoked: boolean;
//		private _nextIfSuccessful: (result: TResult) => void;
//		private _nextIfFailed: (error: any) => void;

//		public get IsComplete() { return this._isSuccessful.HasValue();}

//		public Success(result: TResult)
//		{
//			if (this._watchdog) clearTimeout(this._watchdog);
//			if (this._isSuccessful.HasValue()) return;
//			this._isSuccessful.SetValue(true);

//			//#if DEBUG
//			if (Calysto.Core.IsDebugDefined) console.log({ "promise-success": result });
//			//#endif
//			this._result = result;
//			this.RunNextOnce();
//		}

//		public Failed(error: any)
//		{
//			if (this._watchdog) clearTimeout(this._watchdog);
//			if (this._isSuccessful.HasValue()) return;
//			this._isSuccessful.SetValue(false);
//			//#if DEBUG
//			if (Calysto.Core.IsDebugDefined) console.log({ "promise-failed": error });
//			//#endif
//			this._exception = error;
//			this.RunNextOnce();
//		}

//		private _watchdog: number;

//		/**
//		 * On timeout, will invoke Failed()
//		 * @param timeoutMs
//		 */
//		public Watchdog(timeoutMs: number)
//		{
//			if (this._watchdog) clearTimeout(this._watchdog);
//			this._watchdog = setTimeout(() =>
//			{
//				this.Failed("timeout: watchdog");
//			}, timeoutMs);
//		}

//		protected RunNextOnce()
//		{
//			if (this._isNextInvoked || this._nextIfSuccessful == null || this._nextIfFailed == null)
//				return;

//			let shouldRunSuccessful = false;
//			let shouldRunFailed = false;
//			//lock(this)
//			{
//				if (!this._isNextInvoked)
//				{
//					if (this._nextIfSuccessful && this._isSuccessful.GetValue() === true)
//					{
//						this._isNextInvoked = true;
//						shouldRunSuccessful = true;
//					}
//					else if (this._nextIfFailed && this._isSuccessful.GetValue() === false )
//					{
//						this._isNextInvoked = true;
//						shouldRunFailed = true;
//					}
//				}
//			}

//			//izvan locka
//			if (shouldRunSuccessful)
//				this._nextIfSuccessful(this._result);
//			else if (shouldRunFailed)
//				this._nextIfFailed(this._exception);

//		}

//		public Then<TNextResult>(
//			onPreviousSuccessful?: (state: CalystoPromise<TNextResult>, previousResult: TResult) => void,
//			onPreviousFailed?: (state: CalystoPromise<TNextResult>, error: any) => void)
//		{
//			return this.ThenWorker(
//				new CalystoPromise<TNextResult>(),
//				onPreviousSuccessful,
//				onPreviousFailed);
//		}

//		protected ThenWorker<TPromiseNext extends CalystoPromise<TNextResult>, TNextResult>(
//			nextPromise: TPromiseNext,
//			onPreviousSuccessful?: (state: CalystoPromise<TNextResult>, previousResult: TResult) => void,
//			onPreviousFailed?: (state: CalystoPromise<TNextResult>, error: any) => void)
//		{
//			if (onPreviousSuccessful)
//			{
//				this._nextIfSuccessful = (previous: TResult) =>
//				{
//					try
//					{
//						onPreviousSuccessful(nextPromise, previous);
//					}
//					catch (ex)
//					{
//						nextPromise.Failed(ex);
//					}
//				};
//			}

//			this._nextIfFailed = (ex: any) =>
//			{
//				try
//				{
//					if (onPreviousFailed)
//						onPreviousFailed(nextPromise, ex);
//					else
//						nextPromise.Failed(ex); // samo nek proslijedi na sljedecu instancu promise-a, na kraju ce throw exception ako je sync .Result()
//				}
//				catch (ex1)
//				{
//					nextPromise.Failed(ex1);
//				}
//			};

//			this.RunNextOnce();

//			return nextPromise;
//		}

//		public Run(action: (state: CalystoPromise<TResult>) => void)
//		{
//			this.Success(<any>null);
//			return this.Then<TResult>((state, result) => action(state));
//		}
//	}
//}

