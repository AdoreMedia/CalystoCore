/// <reference path="webinfrastructure.ts" />

namespace Calysto.Net.WebService
{
	export class WebAjaxServiceHelper
	{
		private url: string;
		private vpath: string;
		private ns: object;

		constructor(
			/**complete service namespace including C# class name*/
			private namespace: string,
			/**service url*/
			url: string
		)
		{
			this.vpath = Calysto.Utility.Encoding.Base64RndEncoder.DecodeBase64StringToString(url);

			this.ns = Calysto.DataBinder.GetValue(window, namespace);

			// namespace has to be object {}
			if (!this.ns)
			{
				this.ns = {};
				Calysto.DataBinder.SetValue(window, namespace, this.ns);
			}
		}

		public RegisterAjaxMethod(settings: IWebServiceSettings): WebAjaxServiceHelper
		{
			if (this.ns[settings.method])
				throw new Error("Ajax method is already registered: " + settings.method);

			let _safeThis = this;

			let ajaxMethod = function (...funcSendArgs: any[])
			{
				let servclient = new AjaxServiceClientWithReturn<any>();

				if (settings.reque && !IsTriggeredByUserAction())
				{
					return servclient; // da ne baca exception na chain metode koje se invokaju kasnije
				}

				// *************************************************
				// if comes here, all verifications went well
				// *************************************************

				// get service method parameters: [argVal0, argVal1, argVal2...] or strongParams: {arg0: argVal0, arg1: argVal1, ...}
				let jsObject = CreateArgsObj(settings.method, funcSendArgs, settings.argNames || []);

				let isAbortRequested = false;

				servclient.OnAbort(msg => 
				{
					isAbortRequested = true;
				});

				////let useSocketWebClient = !!settings.ajaxSocket;
				////useSocketWebClient = true; // for debuging with web socket

				// *************************************************
				// common code
				// *************************************************

				// add OnEndResponse event last to be invoked at the end

				// IMPORTANT: OnEndResponse has to be invoked at the end, alfter ResponseReceivedHandler which manipulates html
				// OnEndResponse is used for hiding loading mask and for post processing
				// since blob response is decoded async, we have to call async OnEndResponse at the end:
				let isInvokedOnce = false;
				/** hide loading spinner */
				let fnResponseEndCallback = function ()
				{
					if (isInvokedOnce)
						return; // osigurac da se izvrsi samo jednom;

					isInvokedOnce = true;

					// hide loading mask at the end
					if (!settings.silent)
						Calysto.Page.OnEndResponse.Invoke(f => f());

					servclient.OnEnd.Invoke(f => f());
				};

				/** show loading spinner if not silent request */
				let fnRequestStart = function ()
				{
					// show loading progress or spinner
					if (!settings.silent)
						Calysto.Page.OnBeginRequest.Invoke(f => f());
				};

				let fnReturnValueCallback: FNReturnValueCallbackDelegate = (value: any) =>
				{
					servclient.OnSuccess.Invoke(f => f(value));
					fnResponseEndCallback();
				};

				let fnResponseContainerCallback: FNResponseReceivedCallbackDelegate<any> = (container) =>
				{
					servclient.OnResponse.Invoke(f => f(container));
				};

				let fnErrorCallback: FNErrorCallbackDelegate = (errMsg, errDetails, isServerError) =>
				{
					fnResponseEndCallback();

					if (Calysto.Core.IsDebugDefined)
					{
						console?.error(errMsg + "\r\n" + errDetails);
					}
					else if (servclient.OnError.Any())
					{
						servclient.OnError.Invoke(f => f(errMsg));
					}
					else
					{
						console?.error(errMsg);
					}
				};

				// *************************************************
				// specific code per web client
				// *************************************************

				// code branching depending if webclient or socketwebclient is required
				if (isAbortRequested)
				{
					// nothing
				}
				else
				{
					// we have to serialize async to serialize Blobs
					Calysto.Json.BinaryFrame.SerializeAsync(jsObject).then(binaryFrame =>
					{
						//#if DEBUG
						if (Calysto.Core.IsDebugDefined)
						{
							Log({
								AJAX_SEND: binaryFrame.Json,
								BLOBS: binaryFrame.Blobs,
								method: settings.method + "(" + (settings.argNames || []).join(", ") + ")",
								jsObject: jsObject
							});
						}
						//#endif

						if (isAbortRequested)
							return;

						let wclient = new Calysto.Net.WebClient("");

						servclient.OnAbort(msg =>
						{
							fnResponseEndCallback();
							wclient.Abort();
						});

						let url = CreateUrl(_safeThis.vpath, settings);

						if (settings.post || binaryFrame.Blobs.length > 0 || binaryFrame.Json.length > 1000)
						{
							url = url.replace("__calysto_json_arg__", "");

							wclient.AddRequestHeader(
								Calysto.Constants.WsjsHeaderConstants.XTypeHeaderKey,
								Calysto.Constants.WsjsHeaderConstants.XTypeHeaderBinaryFrameValue
							);

							let blob1 = binaryFrame.ToBinaryData();
							if (blob1 && blob1.size > 0)
							{
								wclient.UploadData(blob1);
							}
							else
							{
								throw Error("Invalid blob, can not continue.");
							}
						}
						else
						{
							// use base64 instead of escaping, this way we may send anything, including <>?%^&$# etc.
							let enc = Calysto.Utility.Encoding.Base64RndEncoder.EncodeToBase64String(binaryFrame.Json);
							url = url.replace("__calysto_json_arg__", "&" + Calysto.Constants.CalystoAjaxHandlerConstants.AjaxGetParamName + "=" + enc);
						}

						wclient.url = url;
						wclient.timeoutMs = settings.timeoutMs || wclient.timeoutMs; // timeout may be set in .cs using CalystoWebMethod(Timeout=...)

						wclient.AddRequestHeader(Calysto.Constants.WsjsHeaderConstants.XAjaxHeaderKey, Calysto.Constants.WsjsHeaderConstants.XAjaxHeaderValue);

						let pageState = (<any>window)[Calysto.Constants.WsjsHeaderConstants.XCalystoPageStateValue];
						if (pageState)
						{
							wclient.AddRequestHeader(Calysto.Constants.WsjsHeaderConstants.XCalystoPageStateKey, pageState);
						}

						// we're always expecting blob, so there is no need to set anything on the server 
						// arraybuffer is better because it may be sync converted into arra: new Uint8Array(arrayBuffer)
						// blob has to be read async using FileReader... readAsArrayBuffer(blob)
						wclient.responseType = typeof (ArrayBuffer) != "undefined" ? "arraybuffer" : "text"; // to work with IE <= 9


						let fnWebClientLoadEnd: EventDelegate = async (sender, ev) =>
						{
							if (ev.type == "timeout")
							{
								fnResponseEndCallback();
								fnErrorCallback("Ajax request timeout.");
								return;
							}

							// this function must not throw exception - all exceptions must be handled inside
							// we have to invoke Calysto.Page.OnEndResponse.Invoke(); later to hide loading mask
							// must send null if there is no listener, this way it will invoke throw new Exception(...) which will invoke Calysto.Page.OnUnhandledException(...)
							await AjaxResponseReceivedHandlerAsync(wclient, {
								fnResponseContainerCallback,
								fnReturnValueCallback,
								fnErrorCallback,
								fnResponseEndCallback
							});

						};

						let fnSendProgressEv = (sender: WebClient, ev: ProgressEvent, isUpload: boolean) =>
						{
							let pp = <ICalystoProgressEvent>{};
							pp.IsComputable = !!ev.lengthComputable;
							pp.IsUpload = !!isUpload;
							pp.Loaded = ev.loaded;
							pp.Total = ev.total;
							if (ev.total > 0)
							{
								pp.Percent = ev.loaded / ev.total * 100;
								if (pp.Percent > 100)
								{
									pp.Percent = 100;
								}
								// if there is no download length set, e.total = 0, so we have devide by zero
								servclient.OnProgress.Invoke(f => f(pp));
							}
						};

						let fnWebClientOnProgress: ProgressEventDelegate = (sender, ev) => fnSendProgressEv(sender, ev, false);

						let fnWebClientOnUploadProgress: ProgressEventDelegate = (sender, ev) => fnSendProgressEv(sender, ev, true);

						// on IE <= 8 doesn't work, it doesn't have events, it has readystate only
						////wclient.OnLoadEnd(fnWebClientLoadEnd); // doesn't work on IE <= 9
						wclient.OnLoad(fnWebClientLoadEnd); // works on IE <= 9
						wclient.OnError(fnWebClientLoadEnd);
						wclient.OnTimeout(fnWebClientLoadEnd);
						wclient.OnAbort(fnWebClientLoadEnd);
						wclient.OnProgress(fnWebClientOnProgress);
						wclient.OnUploadProgress(fnWebClientOnUploadProgress);

						if (isAbortRequested)
							return;

						fnRequestStart();

						if (!wclient.async)
							throw new Error("Sync ajax request is not supported for web service");

						// make delay for the rest of the code to finish assigning callbacks before invoking of the ajax request starts
						//setTimeout(() => wclient.Start(), 1);
						// since we have BoxValueObservable for OnError and OnSuccess, we don't need delay start any more
						wclient.Start();
					});
				}
				return servclient;
			};

			if (settings.method in _safeThis.ns)
			{
				throw new Error("WebService error, method " + settings.method + " already exists in destination object.");
			}
			else
			{
				_safeThis.ns[settings.method] = ajaxMethod;
			}

			return this;
		}

	}
}
