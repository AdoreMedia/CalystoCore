/// <reference path="CPromise.ts" />
/// <reference path="TaskUtility.ts" />
/// <reference path="TaskExtensions.ts" />
/// <reference path="ParallelScheduler.ts" />

namespace Calysto.Tasks
{
	export class TaskCompletionSource<TResult>
	{
		private _hasResult: boolean;
		private _hasError: boolean;
		private _promise: Promise<TResult>;
		private _fnResolve: (value: TResult) => void;
		private _result: TResult;
		private _fnReject: (reason?: any) => void;
		private _error: any;

		public constructor()
		{
			this._promise = new Promise<TResult>((resolve, reject) =>
			{
				this._fnResolve = resolve;
				if (this._hasResult)
					this._fnResolve(this._result);

				this._fnReject = reject;
				if (this._hasError)
					this._fnReject(this._error);
			});
		}

		public TrySetResult(result: TResult)
		{
			if (!this._hasResult && !this._hasError)
			{
				this._hasResult = true;
				this._result = result;
				if(this._fnResolve)
					this._fnResolve(result);
				return true;
			}
			return false;
		}

		public TrySetException(reason: any)
		{
			if (!this._hasResult && !this._hasError)
			{
				this._hasError = true;
				this._error = reason;
				if (this._fnReject)
					this._fnReject(reason);
				return true;
			}
			return false;
		}

		public TrySetCanceled()
		{
			return this.TrySetException("Canceled");
		}

		public get Task() { return this._promise }
	}

	class CancellationTokenRegistration
	{
		public constructor(private fnUnregister: () => void) { }

		/** Remove callback registered using CancellationToken.Register() */
		public Unregister() 
		{
			this.fnUnregister();
        }
	}

	export abstract class CancellationToken 
	{
		public constructor() { }

		protected _isCancellationRequested = false;

		public get IsCancellationRequested() { return this._isCancellationRequested }

		protected _onCancelled: (()=>void)[] = [];

		/**
		 * Register callback to be invoked when token is cancelled.
		 * @param onCancelled
		 */
		public Register(onCancelled: () => void)
		{
			if (this._isCancellationRequested)
				onCancelled();
			else
				this._onCancelled.push(onCancelled);

			// removal func
			return new CancellationTokenRegistration(() =>
			{
				this._onCancelled.Remove(onCancelled);
			});
		}
	}

	export class CancellationTokenSource extends CancellationToken implements IDisposable
	{
		private _timeoutId: number;

		public constructor(millisecondsDelay?: number)
		{
			super();

			if (millisecondsDelay && millisecondsDelay > 0)
				this.CancelAfter(millisecondsDelay);
		}

		private _isDisposed: boolean;
		public get IsDisposed() { return this._isDisposed }

		public Dispose() 
		{
			if (this._isDisposed)
				return;

			this._isDisposed = true;
			clearTimeout(this._timeoutId);
			this._onCancelled.Clear();
		}

		public get Token() { return <CancellationToken> this;}

		private NotifyCanceled()
		{
			clearTimeout(this._timeoutId);
			if (!this._isCancellationRequested)
			{
				this._isCancellationRequested = true;
				this._onCancelled.ForEach(item => item());
			}
		}

		public Cancel()
		{
			this.NotifyCanceled();
		}

		/**
		 * Abort and than start new cancelation timer.
		 * @param millisecondsDelay
		 * if > 0, will re-start cancelation timer.
		 * if <= 0, will abort previous timer and will not start the new one.
		 */
		public CancelAfter(millisecondsDelay: number = -1)
		{
			clearTimeout(this._timeoutId);

			if (millisecondsDelay && millisecondsDelay > 0 && !this._isCancellationRequested)
				this._timeoutId = setTimeout(() => this.NotifyCanceled(), millisecondsDelay);
		}

		/**
		 * Creates a CancellationTokenSource that will be in the canceled state when any of the source tokens are in the canceled state.
		 * @param tokens
		 */
		public static CreateLinkedTokenSource(token1?: CancellationToken, token2?: CancellationToken, token3?: CancellationToken, token4?: CancellationToken)
		{
			let linked = new CancellationTokenSource();
			let tokens : CancellationToken[] = [];
			for (let item of arguments)
			{
				if (item)
				{
					tokens.push(item);
					item.Register(() => linked.Cancel());
				}
			}

			if (tokens.AsEnumerable().Where(o => o.IsCancellationRequested).Any())
				linked.Cancel();

			return linked;
		}
	}
}