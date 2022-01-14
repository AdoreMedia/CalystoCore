namespace Calysto
{
	export class BoxValue<T>
	{
		protected _value: T;
		protected _hasValue: boolean;

		public constructor()
		{
		}

		public SetValue(value: T)
		{
			this._value = <T>value;
			this._hasValue = true;
		}

		public GetValue()
		{
			return this._value;
		}

		public GetValueOrDefault(defaultValue: T)
		{
			return this.HasValue() ? this.GetValue() : defaultValue;
		}

		public HasValue()
		{
			return !!this._hasValue;
		}

		public RemoveValue()
		{
			this._value = <T><any>undefined;
			this._hasValue = false;
		}
	}

	export class BoxValueObservable<T> extends BoxValue<T>
	{
		public constructor()
		{
			super();
		}

		/**
		 * Promisle like. If value is already set, will invoke callback delegate immediately.
		*/
		public readonly OnSetValue = new MulticastDelegate<(value: T) => void>().OnAdd(f =>
		{
			if (this.HasValue()) f(this.GetValue()) // if value is already set, invoke callback now
		}).AsFunc(this);

		/**
		 * Set value, than invoke OnSetValue()
		 * @param value
		 */
		public SetValue(value: T)
		{
			this._value = <T>value;
			this._hasValue = true;
			this.OnSetValue.Invoke(f => f(value));
		}
	}
}