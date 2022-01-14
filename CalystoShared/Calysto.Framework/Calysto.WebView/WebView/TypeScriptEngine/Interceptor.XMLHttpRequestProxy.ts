namespace HostProxy.XmlHttpInterceptor
{
	class XMLHttpRequestProxy
	{
		public readonly OnResponseIntercept = new Calysto.MulticastDelegate<(x: XMLHttpRequest) => void>();

		private _xhr: XMLHttpRequest;

		public constructor(originalXhr: XMLHttpRequest)
		{
			this._xhr = originalXhr;
			this._xhr.onreadystatechange = ev => this._onReadyStateChangeHandler(ev);
		}

		public send(body?: Document | BodyInit | null)
		{
			this._xhr.send(...arguments);
		}

		public open(method: string, url: string): void;
		public open(method: string, url: string, async: boolean, username?: string | null, password?: string | null): void;

		public open(method: string, url: string, async?: boolean, username?: string, password?: string)
		{
			//console.log(`XMLHttpRequest open ${method} ${url}`);
			this._xhr.open(method, url, !!async, username, password);
		}

		private _onReadyStateListeners: ((this: XMLHttpRequest, ev: Event) => any)[] = [];

		private _onReadyStateChangeHandler(ev: Event)
		{
			if (this.readyState == 4)
			{
				//console.log(`_onReadyStateChangeHandler ${this.responseURL} ${this.responseText}`);
				this.OnResponseIntercept.Invoke(f => f(this._xhr));
			}

			for (let fn1 of this._onReadyStateListeners)
			{
				fn1.call(this._xhr, ev);
			}
		}

		public get onreadystatechange() { return this._onReadyStateChangeHandler; }

		public set onreadystatechange(fn: ((this: XMLHttpRequest, ev: Event) => any) | null)
		{
			if (fn)
			{
				this._onReadyStateListeners.push(fn);
			}
		}

		public get readyState() { return this._xhr.readyState; }

		public get response() { return this._xhr.response; }

		public get responseText() { return this._xhr.responseText; }

		public get responseType() { return this._xhr.responseType; }

		public get responseURL() { return this._xhr.responseURL; }

		public get responseXML() { return this._xhr.responseXML; }

		public get status() { return this._xhr.status; }

		public get statusText() { return this._xhr.statusText; }

		public get timeout() { return this._xhr.timeout; }

		public set timeout(valueMs: number) { this._xhr.timeout = valueMs;}

		public get upload() { return this._xhr.upload; }

		public get withCredentials() { return this._xhr.withCredentials; }
		public set withCredentials(value: boolean) { this._xhr.withCredentials = value; }

		public abort() { this._xhr.abort(); }

		public getAllResponseHeaders() { return this._xhr.getAllResponseHeaders();}

		public getResponseHeader(name: string) { return this._xhr.getResponseHeader(name); }

		public overrideMimeType(mime: string) { this._xhr.overrideMimeType(mime); }

		public setRequestHeader(name: string, value: string) { this._xhr.setRequestHeader(name, value); }

		public readonly DONE = XMLHttpRequest.DONE;
		public readonly HEADERS_RECEIVED = XMLHttpRequest.HEADERS_RECEIVED;
		public readonly LOADING = XMLHttpRequest.LOADING;
		public readonly OPENED = XMLHttpRequest.OPENED;
		public readonly UNSENT = XMLHttpRequest.UNSENT;

		public addEventListener<K extends keyof XMLHttpRequestEventTargetEventMap>(type: K, listener: (this: XMLHttpRequestEventTarget, ev: XMLHttpRequestEventTargetEventMap[K]) => any, options?: boolean | AddEventListenerOptions): void;

		public addEventListener<K extends keyof XMLHttpRequestEventMap>(type: K, listener: (this: XMLHttpRequest, ev: XMLHttpRequestEventMap[K]) => any, options?: boolean | AddEventListenerOptions): void;

		public addEventListener(type: string, listener: EventListenerOrEventListenerObject, options?: boolean | AddEventListenerOptions): void;

		public addEventListener(
			type: string,
			listener: any,
			options?: any)
		{
			this._xhr.addEventListener(type, listener, options);
		}

		public removeEventListener<K extends keyof XMLHttpRequestEventMap>(type: K, listener: (this: XMLHttpRequest, ev: XMLHttpRequestEventMap[K]) => any, options?: boolean | EventListenerOptions): void;

		public removeEventListener(type: string, listener: EventListenerOrEventListenerObject, options?: boolean | EventListenerOptions): void;

		public removeEventListener(type: string, listener: any, options?: any)
		{
			this._xhr.removeEventListener(type, listener, options);
		}

		public get onabort() { return this._xhr.onabort; }
		public set onabort(fn: ((this: XMLHttpRequest, ev: ProgressEvent) => any) | null) { this._xhr.onabort = fn; }

		public get onerror() { return this._xhr.onerror;}
		public set onerror(fn: ((this: XMLHttpRequest, ev: ProgressEvent) => any) | null) { this._xhr.onerror = fn; }

		public get onload() { return this._xhr.onload;}
		public set onload(fn: ((this: XMLHttpRequest, ev: ProgressEvent) => any) | null) { this._xhr.onload = fn; }

		public get onloadend() { return this._xhr.onloadend;}
		public set onloadend(fn: ((this: XMLHttpRequest, ev: ProgressEvent) => any) | null) { this._xhr.onloadend = fn; }

		public get onloadstart() { return this._xhr.onloadstart;}
		public set onloadstart(fn: ((this: XMLHttpRequest, ev: ProgressEvent) => any) | null) { this._xhr.onloadstart = fn;}

		public get onprogress() { return this._xhr.onprogress;}
		public set onprogress(fn: ((this: XMLHttpRequest, ev: ProgressEvent) => any) | null) { this._xhr.onprogress = fn;}

		public get ontimeout() { return this._xhr.ontimeout;}
		public set ontimeout(fn: ((this: XMLHttpRequest, ev: ProgressEvent) => any) | null) { this._xhr.ontimeout = fn;}

	}

	export interface IXhrResponse
	{
		locationHref: string,
		responseURL: string,
		responseText: string
	}

	export class XhrInteceptorManager
	{
		public NotifyResponseReceived(xhr: XMLHttpRequest)
		{
			let item = {
				locationHref: location.href,
				responseURL: xhr.responseURL,
				responseText: xhr.responseText,
				xhr: xhr
			};

			this.OnResponseReceived.Invoke(f => f(item));
		}

		public OnResponseReceived = new Calysto.MulticastDelegate<(resp: IXhrResponse)=>void>();
	}

	export function CreateInteceptor(win?: Window)
	{
		win = win || window;
		let xhrOriginal = win["XMLHttpRequest"];
		let manager = new XhrInteceptorManager();

		win["XMLHttpRequest"] = <any> (function ()
		{
			let pp = new XMLHttpRequestProxy(new xhrOriginal());
			pp.OnResponseIntercept.Add(xhr =>
			{
				manager.NotifyResponseReceived(xhr);
			});
			return pp;
		});

		return manager;
	}

}