/// <reference path="HttpStatusCode.ts" />
namespace Calysto.Net
{
	type DataItemType = {
		/** string|object|json|File */
		content: any,
		/** save as filename on server */
		fileName?: string,
		/** application/x-www-form-urlencoded or text/plain or application/json or multipart/form-data */
		uploadType?: string,
		/** GET or POST */
		httpMethod: string,
		/** if true, upload using FormData */
		formData: boolean,
		/** if true, upload using iframe for old browsers */
		formSubmit?: HTMLFormElement
	};

	type NameValueType = { name: string, value: string };

	type CallbackDelegate = (ev: Event) => void;

	export type EventDelegate = (sender: WebClient, ev: Event) => void;

	export type ProgressEventDelegate = (sender: WebClient, ev: ProgressEvent) => void;

	type CallbackStateItem = {
		isUpload: boolean;
		/** OnUploadAbort, OnUploadError, ...*/
		fullName: string;
		/** abort, error, load, timeout, progress, readystatechange */
		eventName: string;
		callbacks: EventDelegate[]
	};

	interface CallbackEventsMap
	{
		// upload
		"OnUploadAbort": CallbackStateItem;
		"OnUploadError": CallbackStateItem;
		"OnUploadLoad": CallbackStateItem;
		//"OnUploadLoadEnd: CallbackStateEvent;
		//"OnUploadLoadStart": CallbackStateEvent;
		"OnUploadProgress": CallbackStateItem;
		"OnUploadTimeout": CallbackStateItem;
		// download
		"OnReadyStateChange": CallbackStateItem;
		"OnAbort": CallbackStateItem;
		"OnError": CallbackStateItem;
		"OnLoad": CallbackStateItem;
		//"OnLoadEnd": DownloadEvent;
		//"OnLoadStart": DownloadEvent;
		"OnProgress": CallbackStateItem;
		"OnTimeout": CallbackStateItem;
	}

	type ListenersDictionay = {
		[P in keyof CallbackEventsMap]?: CallbackEventsMap[P];
	};

	export class WebClient
	{
		public static IsCrossdomain(url: string)
		{
			if (url)
			{
				if (url.indexOf("//") == 0)
				{
					url = location.protocol + url; // add http: in front
				}

				if (url.indexOf("http") == 0)
				{
					var origin = location.protocol + "//" + location.hostname; // hostname includes port (this is origin for crossdomain requests)
					return url.indexOf(origin) != 0; // url is absolute and don't starts with httpRoot (origin)
				}
			}
			return false;
		}

		public static GetXMLHttpRequest(url: string)
		{
			/// <summary>
			/// Static method to get XMLHTTP object
			/// </summary>
			/// <param name="url" optional="true">if url is provided, and host is different than current host, will use XDomainRequest on IE8 and IE9 </param>
			/// <returns type="XMLHttpRequest"></returns>

			if ((<any>window).XMLHttpRequest)
			{
				// Mozilla, Safari, ...
				// XMLHttpRequest can be used for crossdomain request too
				// server has to return headers:
				//Access-Control-Allow-Origin: *
				//Access-Control-Allow-Headers: X-MYRESPONSEHEADER
				//Access-Control-Allow-Methods: POST
				//Access-Control-Allow-Methods: GET
				return new XMLHttpRequest();
			}
			else if (WebClient.IsCrossdomain(url) && (<any>window).XDomainRequest)
			{
				// ie8, ie9 ? // custom headers can not be set in XDomainRequest
				return new (<any>window).XDomainRequest();
			}
			else if ((<any>window).ActiveXObject) // IE < version 8
			{
				var axO = ['Microsoft.XMLHTTP', 'Msxml2.XMLHTTP', 'Msxml2.XMLHTTP.6.0', 'Msxml2.XMLHTTP.4.0', 'Msxml2.XMLHTTP.3.0'];
				for (var i = 0; i < axO.length; i++)
				{
					try { return new (<any>window).ActiveXObject(axO[i]); } catch (e) { }
				}
			}

			////alert("Your browser doesn't support AJAX. Please use the latest version of Internet Explorer, Firefox, Chrome, Safari, Opera etc.");
			return null;
		}


		constructor(public url: string)
		{
			if (Calysto.Core.Constants.WebClientGlobalTimeout > 0) this.timeoutMs = Calysto.Core.Constants.WebClientGlobalTimeout;
		}

		public timeoutMs = 90000;
		public responseType = "text";
		public async = true;
		public xhr: XMLHttpRequest;

		private data: DataItemType;
		private headers: NameValueType[];
		private isAborted: boolean;
		private isStarted: boolean;
		private listeners: ListenersDictionay;

		public SetTimeout(timeoutMs: number)
		{
			this.timeoutMs = timeoutMs;
			return this;
		}

		public SetUrl(url: string)
		{
			this.url = url;
			return this;
		}

		public SetAsync(isAsync: boolean)
		{
			this.async = !!isAsync;
		}

		private CreateData(httpMethod: string, content: any, uploadType?: string, fileName?: string): DataItemType
		{
			/// <summary>
			/// 
			/// </summary>
			/// <param name="httpMethod" type="string">GET or POST</param>
			/// <param name="content" type="string|object|json|File"></param>
			/// <param name="uploadType" type="string">application/x-www-form-urlencoded or text/plain or application/json or multipart/form-data</param>
			/// <param name="fileName" type="string" optional="true">save as filename on server</param>

			return {
				content: content,
				fileName: fileName,
				uploadType: uploadType || "text/plain",
				httpMethod: httpMethod || "GET",
				formData: false
			};
		}

		private CreateNameValue(name: string, value: string): NameValueType
		{
			return {
				name: name + "",
				value: value + ""
			};
		}

		public UploadDictionary(dic: Object)
		{
			var arr: string[] = [];
			Calysto.Collections.ForEachOwnProperties(dic, (name, value, index) => arr.push(encodeURIComponent(name + "") + "=" + encodeURIComponent(value + "")));
			this.data = this.CreateData("POST", arr.join("&"), "application/x-www-form-urlencoded");
			return this;
		};

		public UploadString(str: string)
		{
			this.data = this.CreateData("POST", str, "text/plain");
			return this;
		};

		public UploadJson(json: string)
		{
			this.data = this.CreateData("POST", json, "application/json");
			return this;
		};

		public UploadData(data: object | Function)
		{
			this.data = this.CreateData("POST", data, "multipart/form-data");
			this.data.formData = true;
			return this;
		}

		public UploadHtmlForm(form: HTMLFormElement, appendKeys?: {Key: string, Value: string}[])
		{
			if (window.FormData)
			{
				let f1 = new FormData(form);
				if (appendKeys)
				{
					for (let kv of appendKeys)
					{
						f1.append(kv.Key, kv.Value);
					}
				}
				this.data = this.CreateData(form.method, f1, form.enctype);
				this.data.formData = true;
			}
			else
			{
				// IE<=9
				// works on asp.net core mvc
				let dic1 = <any>Forms.FormSerialize(form);
				if (appendKeys)
				{
					for (let kv of appendKeys)
					{
						dic1[kv.Key] = kv.Value;
					}
				}
				this.UploadDictionary(dic1);
			}
			return this;
		}

		public UploadFile(file: File, fileName?: string)
		{
			this.data = this.CreateData("POST", file, "multipart/form-data", fileName || file.name);
			return this;
		}

		/**
		 * Set response type
		 * @param typeString possible values:  "", "text", "arraybuffer", "blob", "document", "json", if not set, default is "text"
		 */
		public SetResponseType(typeString: "text" | "arraybuffer" | "blob" | "document" | "json" | "" = "text")
		{
			/// <summary>
			/// Set response type.
			/// </summary>
			/// <param name="typeString" type="String"> "", "text", "arraybuffer", "blob", "document", "json"</param>
			/// <returns type=""></returns>
			this.responseType = typeString || "";
			return this;
		}

		public AddRequestHeader(name: string, value: string)
		{
			if (!this.headers) this.headers = [];
			this.headers.push(this.CreateNameValue(name, value));
			return this;
		}

		public Abort()
		{
			this.isAborted = true;

			if (this.xhr)
			{
				this.xhr.abort();
				this.xhr = <any>null;
			}
			return this;
		}

		/** Start download if not already started. */
		public Start(): WebClient
		{
			if (this.isAborted) return this;
			if (this.isStarted) return this;
			this.isStarted = true;

			this.xhr = WebClient.GetXMLHttpRequest(this.url);
			var _safeThis = this;

			this.xhr.onabort = function (ev)
			{
				console.log({ abort: _safeThis.xhr.getAllResponseHeaders() });
			};

			var timeoutId: number = NaN;
			var isComplete = false;

			if (this.timeoutMs > 0)
			{
				timeoutId = setTimeout(()=>
				{
					if (!isComplete)
					{
						isComplete = true;
						// timeout occures before readyState == XMLHttpRequest.DONE
						_safeThis.xhr.abort();
						var ss = _safeThis.GetLiistenersItem("OnTimeout");
						if (ss) ss.callbacks.ForEach(fn => fn(_safeThis, <any>{ type: "timeout", bubles: false }));
					}
				}, this.timeoutMs);
			}

			// response is ok if: 	if(sender.config.xhr.status >= 200 && sender.config.xhr.status < 300)
			// status code has to be read onload
			// use "onload", because "onloadend" doesn't work on IE<=9 and some old browsers

			Calysto.Collections.ForEachOwnProperties<CallbackStateItem>(this.listeners, (name, obj, index) =>
			{
				var xhrOrUpload = obj.isUpload ? _safeThis.xhr.upload : _safeThis.xhr;
				if (xhrOrUpload)
				{
					//console.log("assign: " + obj.eventName);
					// da bi radilo na starom IE8, jer nema "onload" event
					if (obj.fullName == "OnLoad")
					{
						(<any>xhrOrUpload).onreadystatechange = (ev:Event) =>
						{
							if ((<any>xhrOrUpload).readyState == XMLHttpRequest.DONE && !isComplete)
							{
								ev = ev || <Event>{ type: "load" }; // required for IE where ev.type = ""
								isComplete = true;
								clearTimeout(timeoutId);
								var ss = _safeThis.GetLiistenersItem("OnLoad");
								if (ss) ss.callbacks.ForEach(fn => fn(_safeThis, ev));
							}
						};
					}
					else
					{
						xhrOrUpload["on" + obj.eventName] = (ev:Event) =>
						{
							if (!isComplete)
							{
								ev = ev || <Event>{ type: obj.eventName }; // required for IE where ev.type = ""

								if (ev.type == "abort" || ev.type == "error" || ev.type == "timeout")
								{
									isComplete = true;
								}
								var ss = _safeThis.GetLiistenersItem(<keyof CallbackEventsMap>obj.fullName);
								if (ss) ss.callbacks.ForEach(fn => fn(<any>_safeThis, <any>ev));
							}
						};
					}
				}
			});


			var data = this.data || <DataItemType>{};

			if (data.formSubmit)
			{
				data.formSubmit.action = this.url;
				data.formSubmit.submit();
				return this;
			}

			this.xhr.open(data.httpMethod || "GET", this.url, this.async);
			this.xhr.timeout = this.timeoutMs; // on IE, timeout may be set after .open() is invoked

			// IE8, IE9 XDomainRequest doesn't support setRequestHeader and it ads Origin header by itself

			if (data.uploadType)
			{
				this.xhr.setRequestHeader(Constants.WsjsHeaderConstants.XCalystoContentTypeKey, data.uploadType);

				try
				{
					if (window.FormData)
					{
						// IE10,11, Chrome and all other have to use property:
						// it won't send content-type header unless property is set
						this.xhr.contentType = data.uploadType;
					}
					else
					{
						// IE9 must use setRequestHeaer()
						// it won't send content-type header unless setRequestHeader() is used
						this.xhr.setRequestHeader('Content-Type', data.uploadType);
					}
				}
				catch { }
			}

			this.xhr.setRequestHeader(Constants.WsjsHeaderConstants.XCalystoRequestWithKey, Constants.WsjsHeaderConstants.XCalystoRequestWithValue);

			if (data.fileName)
			{
				this.xhr.setRequestHeader(Constants.WsjsHeaderConstants.XCalystoFileNameKey, data.fileName);
			}

			if (this.responseType)
			{
				this.xhr.responseType = <any>this.responseType;
			}

			if (this.headers)
			{
				this.headers.ForEach(item => this.xhr.setRequestHeader(item.name, item.value));
			}

			if ("content" in data)
			{
				let content = data.content;
				if (typeof content == "function")
					content = content();

				this.xhr.send(content);
			}
			else
			{
				this.xhr.send();
			}

			return this;
		}

		public DownloadDataAsync<TResult>()
		{
			return new Promise<TResult>((resolve, reject) =>
			{
				if (this.xhr?.readyState == XMLHttpRequest.DONE)
				{
					resolve(this.GetResponse());
				}
				else
				{
					this.OnLoad(resp =>
					{
						resolve(resp.GetResponse());
					});

					this.Start();
				}
			});
		}

		public async DownloadStringAsync()
		{
			return "" + await this.DownloadDataAsync<string>();
		}

		public GetResponseText()
		{
			if (this.xhr)
			{
				return this.xhr.responseText;
			}
			return "";
		}

		public GetResponse()
		{
			if (this.xhr)
			{
				return this.xhr.response;
			}
			return;
		}

		private GetLiistenersItem(fullName: keyof CallbackEventsMap)
		{
			return this.listeners[fullName];
		}

		private AddCallback(fullName: keyof CallbackEventsMap, func: EventDelegate)
		{
			if (this.isStarted) throw new Error("Request started, can't assign callback: " + fullName);

			if (!this.listeners) this.listeners = {};

			var item = this.GetLiistenersItem(fullName);
			// create new if doesn't exist
			if (!item)
			{
				var isUpload = fullName.StartsWith("OnUpload");
				var evName = isUpload ? fullName.substr(8).toLowerCase() : fullName.substr(2).toLowerCase();
				item = { isUpload: isUpload, eventName: evName, fullName: fullName, callbacks: [] };
				this.listeners[fullName] = <any>item;
			}
			// push func callback
			item.callbacks.push(func);
			return this;
		}

		//#region Upload events

		public OnUploadAbort(func: EventDelegate)
		{
			return this.AddCallback("OnUploadAbort", func);
		}

		public OnUploadError(func: EventDelegate)
		{
			return this.AddCallback("OnUploadError", func);
		}

		/**
		 * Upload complete.
		 * @param func
		 */
		public OnUploadLoad(func: EventDelegate)
		{
			return this.AddCallback("OnUploadLoad", func);
		};

		////this.OnUploadLoadEnd = function (func)
		////{
		////	/// <summary>
		////	/// implements all three events: abort, loadend, error
		////	/// </summary>
		////	/// <param name="func">function(sender, e){...}</param>
		////	return AddCallback.call(this, "OnUploadLoadEnd", func);
		////};

		////this.OnUploadLoadStart = function (func)
		////{
		////	/// <summary>
		////	/// Upload start.
		////	/// </summary>
		////	/// <param name="func">function(sender, e){...}</param>
		////	return AddCallback.call(this, "OnUploadLoadStart", func);
		////};

		/**
		 * 	Use e.loaded and e.total<br/>
			Property 'e.position' is deprecated. Please use 'e.loaded' instead.<br/>
			Property 'e.totalSize' is deprecated. Please use 'e.total' instead.
		 * @param func function(sender, e){...}
		 */
		public OnUploadProgress(func: ProgressEventDelegate)
		{
			return this.AddCallback("OnUploadProgress", <EventDelegate>func);
		}

		public OnUploadTimeout(func: EventDelegate)
		{
			return this.AddCallback("OnUploadTimeout", func);
		};

		//#endregion

		//#region Download events

		public OnReadyStateChange(func: EventDelegate)
		{
			return this.AddCallback("OnReadyStateChange", func);
		}

		public OnAbort(func: EventDelegate)
		{
			return this.AddCallback("OnAbort", func);
		}

		public OnError(func: EventDelegate)
		{
			return this.AddCallback("OnError", func);
		}

		/**
		 * Download complete, any status code, successful or error.
		 * @param func
		 */
		public OnLoad(func: EventDelegate)
		{
			return this.AddCallback("OnLoad", func);
		}

		////this.OnLoadEnd = function (func)
		////{
		////	/// <summary>
		////	/// Download, implements all three events: abort, load, error (doesn't work on IE 9 and older)
		////	/// </summary>
		////	/// <param name="func">function(sender, e){...}</param>
		////	return AddCallback.call(this, "OnLoadEnd", func);
		////};

		////this.OnLoadStart = function (func)
		////{
		////	/// <summary>
		////	/// Download load start.
		////	/// </summary>
		////	/// <param name="func">function(sender, e){...}</param>
		////	return AddCallback.call(this, "OnLoadStart", func);
		////};

		/** Download progress.
		 * 	Use e.loaded and e.total<br/>
			Property 'e.position' is deprecated. Please use 'e.loaded' instead.<br/>
			Property 'e.totalSize' is deprecated. Please use 'e.total' instead.
		 * @param func function(sender, e){...}
		 */
		public OnProgress(func: ProgressEventDelegate)
		{
			return this.AddCallback("OnProgress", <EventDelegate>func);
		}

		/**
		 * Download timeout.
		 * @param func
		 */
		public OnTimeout(func: EventDelegate)
		{
			return this.AddCallback("OnTimeout", func);
		}

		//#endregion

	}
}

