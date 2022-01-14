/// <reference path="webtypes.ts" />

namespace Calysto.Net.WebService
{
	type cbTypes = "OnAbort" | "OnProgress" | "OnResponse" | "OnSuccess" | "OnEnd" | "OnError";
		

	export abstract class AjaxServiceClientBase
	{
		/**Abort request */
		public Abort()
		{
			this.OnAbort.Invoke(f => f("abort"));
			return this;
		}

		public readonly OnAbort = new MulticastDelegate<(msg: string) => void>()
			.OnInvoke(msg => { this.SetValue("OnAbort", msg)})
			.OnAdd(fn => this.TryInvokeValue("OnAbort", fn))
			.AsFunc(this);

		/**promisse, callback on upload or download progress changed*/
		public readonly OnProgress = new MulticastDelegate<(ev: ICalystoProgressEvent) => void>()
			.OnInvoke(ev => { this.SetValue("OnProgress", ev) })
			.OnAdd(fn => this.TryInvokeValue("OnProgress", fn))
			.AsFunc(this);

		/**promisse, callback on ajax request is complete, after OnSuccess, but before OnError*/
		public readonly OnEnd = new MulticastDelegate<() => void>()
			.OnInvoke(() => { this.SetValue("OnEnd", true) })
			.OnAdd(fn => this.TryInvokeValue("OnEnd", fn))
			.AsFunc(this);

		/**promisse, callback on error response received */
		public readonly OnError = new MulticastDelegate<(err: string) => void>()
			.OnInvoke(err => { this.SetValue("OnError", err) })
			.OnAdd(fn => this.TryInvokeValue("OnError", fn))
			.AsFunc(this);

		private _values = {};

		/**
		 * Add value to cache and invoke delegate.
		 * @param name
		 * @param value
		 */
		protected SetValue(name: cbTypes, value: any)
		{
			this._values[name] = value;
		}

		/**
		 *  If value already exists, invoke delegate.
		 * @param name
		 * @param fn
		 */
		protected TryInvokeValue(name: cbTypes, fn: Function)
		{
			if (name in this._values)
			{
				fn(this._values[name]);
			}
		}
	}

	export class AjaxServiceClientVoid extends AjaxServiceClientBase
	{
		/**invoke when response is received, before it is read*/
		public readonly OnResponse = new MulticastDelegate<(container: IWebServiceResponseContainer) => void>()
			.OnInvoke(container => { this.SetValue("OnResponse", container) })
			.OnAdd(fn => this.TryInvokeValue("OnResponse", fn))
			.AsFunc(this);

		/**promisse, callback on successful response received*/
		public readonly OnSuccess = new MulticastDelegate<() => void>()
			.OnInvoke(() => { this.SetValue("OnSuccess", true) })
			.OnAdd(fn => this.TryInvokeValue("OnSuccess", fn))
			.AsFunc(this);

		public ResultAsync()
		{
			return new Promise<void>((resolve, reject) =>
			{
				this.OnError(err => reject(err));
				this.OnSuccess(() => resolve());
			});
		}
	}

	export class AjaxServiceClientWithReturn<TResult> extends AjaxServiceClientBase
	{
		/**invoke when response is received, before it is read */
		public readonly OnResponse = new MulticastDelegate<FNResponseReceivedCallbackDelegate<TResult>>()
			.OnInvoke(container => { this.SetValue("OnResponse", container) })
			.OnAdd(fn => this.TryInvokeValue("OnResponse", fn))
			.AsFunc(this);

		/**promisse, callback on successful response received*/
		public readonly OnSuccess = new MulticastDelegate<(resp: TResult) => void>()
			.OnInvoke(resp => { this.SetValue("OnSuccess", resp) })
			.OnAdd(fn => this.TryInvokeValue("OnSuccess", fn))
			.AsFunc(this);

		public ResultAsync()
		{
			return new Promise<TResult>((resolve, reject) =>
			{
				this.OnError(err => reject(err));
				this.OnSuccess(result => resolve(result));
			});
		}
	}
}

