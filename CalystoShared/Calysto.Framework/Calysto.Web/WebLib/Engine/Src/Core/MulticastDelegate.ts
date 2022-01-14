namespace Calysto
{
	export interface IFuncMulticastDelegate<TDelegate extends Function, TOwner>
	{
		/**Add callback delegate.*/
		(fn: TDelegate): TOwner;

		/** Underlaying MulticastDelegate<TDelegate> instance */
		readonly MCD: MulticastDelegate<TDelegate>;

		Invoke(action?: (delegate: TDelegate) => void): void;

		Any(): boolean;
	}

	class CallbackItem<TDelegate extends Function>
	{
		public delegate: TDelegate;
		public executedCount: number;
		public executionsMax: number;
		public doCountExecutions: boolean;
		public ForRemoval() { return this.doCountExecutions && this.executedCount >= this.executionsMax;}
	}

	/**
	 * TFunc example: (ime: string, age: number)=>void
	 */
	export class MulticastDelegate<TDelegate extends Function>
	{
		protected items: CallbackItem<TDelegate>[];
		protected onAddHandlers: ((delegate: TDelegate) => void)[];
		protected onInvokeHandlers: ((delegate: TDelegate) => void)[];

		constructor()
		{
			this.items = [];
			this.onAddHandlers = [];
			this.onInvokeHandlers = [];
		}

		/**
		 * Invode after every Add() invoked
		 * @param func
		 */
		public OnAdd(func: (delegate: TDelegate) => void)
		{
			this.onAddHandlers.push(func);
			return this;
		}

		/**
		 * Invoke after every Invoke() invocation
		 * @param func
		 */
		public OnInvoke(func: (delegate: TDelegate) => void)
		{
			this.onInvokeHandlers.push(func);
			return this;
		}

		/**
		 * 
		 * @param delegate
		 * @param executionsMax maximum times to be executed, than ignore it
		 */
		public Add(delegate: TDelegate, executionsMax?: number)
		{
			var item = new CallbackItem<TDelegate>();
			item.delegate = delegate;
			item.executedCount = 0;

			if (executionsMax && executionsMax > 0)
			{
				item.doCountExecutions = true;
				item.executionsMax = executionsMax;
			}

			this.items.push(item);

			// invoke callback on add
			this.onAddHandlers.ForEach(f => f(delegate));

			return this;
		}

		/**
		 * Remove items by delegate.
		 * @param delegate
		 */
		public Remove(delegate: TDelegate)
		{
			let remove = this.items.AsEnumerable().Where(o => o.delegate == delegate);
			remove.ForEach(o => this.items.Remove(o));
			return this;
		}

		/**
		 * Will invoke delegate only once.
		 * @param delegate
		 */
		public AddOnce(delegate: TDelegate)
		{
			return this.Add(delegate, 1);
		}

		/**
		 * Will invoke delegate executionsMax times.
		 * @param executionsMax
		 * @param delegate
		 */
		public AddCount(executionsMax: number, delegate: TDelegate)
		{
			return this.Add(delegate, executionsMax);
		}

		/**
		 * invoke every delegate with parameters, e.g. f=>f(1,2,3);
		 * @param action
		 */
		public Invoke(action?: (delegate: TDelegate) => void) : void
		{
			for (let fn of this.onInvokeHandlers)
			{
				if (!action)
					(<any>fn)();
				else
					action(<any>fn);
			}

			let doRemove = false;
			for(let item of this.items)
			{
				if (item.ForRemoval())
				{
					doRemove = true;
				}
				else
				{
					if (!action) // compatiblitiy if there is no argumets passed with .Add() or OnPageLoad(()=>{}), e.g. Calysto.Page.OnVersionExpired.Invoke()
						item.delegate();
					else
						action(item.delegate);

					item.executedCount++;
				}
			}

			if (doRemove)
			{
				this.items = this.items.AsEnumerable().Where(o => !o.ForRemoval()).ToArray();
			}
		}

		public Any()
		{
			return this.items.Any();
		}

		public Count()
		{
			return this.items.length;
		}

		public Clear()
		{
			this.items.Clear();
			return this;
		}

		private _asFuncCached = new Map<any, any>();

		/**
		 * encapsulate and return Add function, instead mc.Add(()=>{}), than we may left out .Add and use md(()=>{})
		 * shorthand method md(()=>{}) returns owner instance, instead of MulticastDelegate instance
		 * feature is used in ajax callbacks .OnSuccess().OnError()... () returns TOwner
		 * encapsulated () returns owner
		 * @returns owner
		 */
		public AsFunc<TOwner>(owner?: TOwner): IFuncMulticastDelegate<TDelegate, TOwner>
		{
			if (!this._asFuncCached.has(owner))
			{
				var _safeThis = this;

				var fnAdd = function (fnDelgate: TDelegate)
				{
					_safeThis.Add(fnDelgate);
					return owner;
				};

				let prop1: keyof IFuncMulticastDelegate<TDelegate, TOwner> & "MCD" = "MCD";

				Object.defineProperty(fnAdd, prop1 , {
					get: () => _safeThis,
				});

				this.CopyFunction(fnAdd, "Invoke");
				this.CopyFunction(fnAdd, "Any");

				this._asFuncCached.set(owner, fnAdd);
			}

			return <IFuncMulticastDelegate<TDelegate, TOwner>>this._asFuncCached.get(owner);
		}

		private CopyFunction(dest: object, name: (keyof IFuncMulticastDelegate<TDelegate, any> & ("Invoke" | "Any")))
		{
			dest[name] = (<Function>this[name]).BindContext(this);
		}

	}



}

