namespace Calysto.Tasks
{
	class MonitorItem<TResult> implements IDisposable
	{
		public Resolve: (value?: TResult) => void;
		public Reject: (reason?) => void;
		public Promise: Promise<TResult>;
		public IsResolved: boolean;
		public IsPulsed: boolean;
		public Value: (TResult | undefined)[];
		private _timeoutId: number;
		public constructor(timeoutMs?: number)
		{
			if (timeoutMs && timeoutMs > 0)
			{
				this._timeoutId = setTimeout(() => this.Resolve(), timeoutMs);
			}
		}

		private _isDisposed: boolean;
		public get IsDisposed() { return this._isDisposed }
		public Dispose()
		{
			if (this._isDisposed) return;
			this._isDisposed = true;
			clearTimeout(this._timeoutId);
		}
	}

	export class CalystoMonitor<TResult>
	{
		private _items = new Set<MonitorItem<TResult>>();

		public constructor()
		{
		}

		public WaitAsync(timeoutMs?: number, cancellationToken?: CancellationToken)
		{
			let mi = new MonitorItem<TResult>(timeoutMs);

			let cbRegistration = cancellationToken?.Register(() =>
			{
				cbRegistration?.Unregister();
				mi.Dispose();
				this._items.delete(mi);
			});

			mi.Promise = TaskUtility.CallbackAsync<TResult>(resolve =>
			{
				mi.Resolve = (value?: TResult) =>
				{
					mi.Dispose();
					this._items.delete(mi);

					if (!mi.IsResolved)
					{
						mi.IsResolved = true;
						resolve(<any>value);
					}
				};

				if (mi.IsPulsed && !mi.IsResolved)
				{
					mi.Resolve(mi.Value?.pop());
				}

			}, cancellationToken);

			if (!mi.IsPulsed)
				this._items.add(mi);

			return mi.Promise;
		}

		/**
		 * Pulse first unpulsed and unresolved promise.
		 * @param value
		 */
		public Pulse(value?: TResult)
		{
			for (let mi of this._items)
			{
				if (!mi.IsPulsed && !mi.IsResolved)
				{
					mi.IsPulsed = true;
					if (mi.Resolve)
						mi.Resolve(value);
					else
						mi.Value = [value];
					return; // just this one, than return
				}
			}
		}

		/**
		 * Pulse all unpulsed and unresolved promises.
		 * @param value
		 */
		public PulseAll(value?: TResult)
		{
			// have to create new copy since items are removed form original _items set inside Resolve()
			let set1 = new Set<MonitorItem<TResult>>(this._items.values());

			for (let mi of set1)
			{
				if (!mi.IsPulsed && !mi.IsResolved)
				{
					mi.IsPulsed = true;
					if (mi.Resolve)
						mi.Resolve(value);
					else
						mi.Value = [value];
				}
			}
		}
	}
}
