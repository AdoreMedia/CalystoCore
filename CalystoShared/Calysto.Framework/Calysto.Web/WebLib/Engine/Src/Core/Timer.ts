namespace Calysto
{
	export class Timer
	{
		constructor(private onTimeout?: (sender: Timer) => void)
		{
			this.items = [];
			if (onTimeout) this.OnTimeout(onTimeout);
		}

		private items: ((sender: Timer) => void)[];

		private sleepMs = 0;

		private timeoutId: number;

		public IsRunning()
		{
			return !!this.timeoutId;
		};

		public Abort()
		{
			if (this.timeoutId)
			{
				clearTimeout(this.timeoutId);
				this.timeoutId = <any>null;
			}
			return this;
		}

		public Start(delayMs: number)
		{
			/// <summary>
			/// Start new timeout. Abort previous if exists.
			/// </summary>
			/// <param name="delayMs" optional="true"></param>
			this.Abort();
			// kad se koristi lambda, this se ispravno embeda
			this.timeoutId = setTimeout(()=>
			{
				clearTimeout(this.timeoutId);
				this.timeoutId = <any>null;
				// invoke callback
				for (var n = 0; n < this.items.length; n++)
				{
					this.items[n](this);
				}
			}, delayMs > 0 ? delayMs : 0);
			return this;
		}

		public OnTimeout(func: (sender: Timer) => void)
		{
			/// <summary>
			/// MulticastDelegate. Add callback function(s) to be executed on timeout.
			/// </summary>
			/// <param name="func">function(sender){...}, this inside of function is current Calysto.Timer instance</param>

			this.items.push(func);
			return this;
		};
	}

	////export class MouseTimer
	////{
	////	private _isBussy = false;
	////	private _timerId: number;

	////	constructor()
	////	{
	////	}

	////	/**
	////	 * Return true if there is another click in less than delayMs time.
	////	 * @param delayMs If not set, default is 300 ms
	////	 */
	////	public IsDoubleclicked(delayMs: number = 300)
	////	{
	////		if (this._isBussy)
	////			return true;

	////		this._isBussy = true;

	////		if (this._timerId)
	////			clearTimeout(this._timerId);

	////		this._timerId = setTimeout(() => this._isBussy = false, delayMs);

	////		return false;
	////	}
	////}

	export class BussyTimer
	{
		private _expires: number = 0;

		constructor(private timeoutMs: number)
		{
		}

		public Start()
		{
			this._expires = Date.now() + this.timeoutMs;
			return this;
		}

		public Abort()
		{
			this._expires = 0;
			return this;
		}

		public IsBussy()
		{
			return this._expires > Date.now();
		}

		/**
		 * If timer is already bussy, returns true,
		 * Else, set new timeout and return false.
		 */
		public IsBussyOrStart()
		{
			if (this.IsBussy())
			{
				return true;
			}
			else
			{
				this.Start();
				return false;
			}
		}
	}

	export class MouseTimer
	{
		private _timer: BussyTimer;

		/**
		 *  Default timeout 300ms.
		 * @param timeoutMs default value: 300
		 */
		public constructor(timeoutMs: number = 300)
		{
			this._timer = new BussyTimer(timeoutMs);
		}

		/**
		 * If timer is already bussy, returns true,
		 * Else, set new timeout and return false.
		 */
		public IsDoubleclicked()
		{
			return this._timer.IsBussyOrStart();
		}
	}
}


