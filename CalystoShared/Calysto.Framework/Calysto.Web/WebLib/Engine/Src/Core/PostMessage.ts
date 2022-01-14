/*
 * example of usage:

	// create instance with UID:
	var ppp = new Calysto.PostMessage("win1");

	// register method inside of iframe or main window:
	ppp.RegisterMethod("GetWindowTime", function(val1, ev){
		// acctual handler function
	});

	// invoke method from any other iframe or main window, val1 is passed as parameter
	p1.InvokeMethod("destinationUID", "GetWindowTime", val1, function(val3, ev){
		// optional response handler, val3 is return value from function GetWindowTime(val1);
	});
*/

namespace Calysto
{
	type TDataObject = {
		// (string) sender unique id
		senderUID: string,
		// (string) destination unique id, use * to send to all, callback is always sent to exact destination UID, never all (*)
		destinationUID: string,
		// (string) function name to be invoked
		funcName: string,
		// (object) argument sent to destination
		argument: any,
		// (bool) true if it is callback
		isCallback?: boolean,
		// (string) callback function name
		callbackFuncName?: string
	};

	interface IPostMessageEvent extends MessageEvent
	{
		// (string), json received in event.data
		data: string;
		// (object) event.data deserialized
		dataObject: TDataObject
	}

	type TFuncBag = (data: any, ev: IPostMessageEvent) => void;

	function GenerateUID(prefix)
	{
		return (prefix || "uid") + (Math.random() + "").substr(2) + Date.now();
	}

	// MSIE 9,8,7 allows to send string only

	function EncodeDataObj(obj: TDataObject)
	{
		return Calysto.Json.Serialize(obj);
	}

	function DecodeDataObj(obj): TDataObject
	{
		try { return Calysto.Json.Deserialize<TDataObject>(obj); }
		catch (e) { return <any>null; }
	}

	const __EchoTestMethod = "__EchoTestMethod";

	// for compatibility with other code, everything has to be inside class which has to be instantinated

	export class PostMessage
	{
		/**
		 * PostMessage instance unique id
		 * @param {string} UID?
		 */
		private _uniqueUID: string;

		private _listenersArr: any[] = [];

		private _funcBag: { [key: string]: TFuncBag } = {};

		constructor(UID?: string)
		{
			// create PostMessage instance unique id
			this._uniqueUID = UID || GenerateUID("uid");

			// register echo method
			this._funcBag[__EchoTestMethod] = (msg) => "received: " + msg;

			// parent windows should be added as listeners
			// iframes should not be added, so communication has be initialized from iframe to parent
			this.AddDistinctListener(window.parent);
			this.AddDistinctListener(window.opener);

			Calysto.Event.Attach(<any>window, "message", ev => this.HandleMessageEvent(<IPostMessageEvent>ev));
		}

		private AddDistinctListener(obj)
		{
			// can not test obj._postMsgUID if domains are different

			if (!obj || obj == window) return; // if current window, it can not be listener for itself

			for (var n1 = 0; n1 < this._listenersArr.length; n1++)
			{
				if (this._listenersArr[n1] == obj) return;
			}
			// we don't have that obj in array yet
			this._listenersArr.push(obj);
		}

		private EncapsulateFunc(funcRef: TFuncBag) : string | null
		{
			/// <summary>
			/// If funcRef defined, add funcRef to _funcBag and return funcUID, else return null.
			/// </summary>
			/// <param name="funcRef" type="Function"></param>

			if (funcRef)
			{
				var cnt = 0;
				var funcUid;
				while (cnt++ < 50 && (!(funcUid = GenerateUID("fn")) || this._funcBag[funcUid]))
				{
					// if uid already exists, generate new UID, try up to 50 times
				}
				this._funcBag[funcUid] = funcRef;
				return funcUid;
			}
			return null;
		}

		/**
		 * Register function in postmessage instance.
		 * @param {string} funcName Name of the function.
		 * @param {(sentValue} funcRef Acctual function which will receive and process the sentValue. Function returns TReturn at the end.
		 * @param {function} ev
		 * @returns
		 */
		public RegisterMethod<TSend, TReturn>(funcName: string, funcRef: (sentValue: TSend, ev: IPostMessageEvent) => TReturn)
		{
			/// <summary>
			/// Register method inside of current window which may be invoked from any other iframe.
			/// </summary>
			/// <param name="funcName" type="String">Function name.</param>
			/// <param name="funcRef" type="Function">
			///		<para>function(sentValue, event, this){....}</para>
			///		<para>this inside of function is current PostMessage instance</para>
			///		<para>event is current event {sender:..., origin:..., data:...}</para>
			///		<para>sentValue is sent as argument parameter in method this.InvokeMethod(....)</para>
			/// </param>

			if (typeof (funcName) != "string")
			{
				throw Error("PostMessage.RegisterMethod argument funcName is not string");
			}

			if (typeof (funcRef) != "function")
			{
				throw Error("PostMessage.RegisterMethod argument funcRef is not function");
			}

			if (this._funcBag[funcName])
			{
				throw new Error("Method is already registerd in PostMessage.RegisterMethod: " + funcName);
			}

			this._funcBag[funcName] = funcRef;

			return this;
		}

		public InvokeMethod<TSend, TReturn>(destinationUID: string, funcName: string, sendValue: TSend, callbackFunc?: (returnedValue: TReturn, ev: IPostMessageEvent) => void)
		{
			/// <summary>
			/// 
			/// </summary>
			/// <param name="destinationUID" type="String">UID string or * for all</param>
			/// <param name="funcName" type="String">Function name to be executed on destinationUID and pass arg as parameter to the function.</param>
			/// <param name="arg" type="Object" optional="true">object to be passed to invoking method as argument</param>
			/// <param name="callbackFunc" type="Function" optional="true">
			///		<para>function(value, event, this){....}</para>
			///		<para>function to be invoked on response received, handles object returned from invoked method using return (value);</para>
			///		<para>this inside of function is current PostMessage instance</para>
			///		<para>event is current event {sender:..., origin:..., data:...}</para>
			///		<para>value is sent as argument parameter in method this.InvokeMethod(....)</para>
			/// </param>
			var tt = [destinationUID, funcName, sendValue];
			var _ttNames = ["destinationUID", "funcName", "arg"];

			for (var n = 0; n < tt.length; n++)
			{
				if (typeof (tt[n]) == "function")
				{
					throw Error("PostMessage.InvokeMethod argument " + _ttNames[n] + " can not be function");
				}
			}

			if (callbackFunc && typeof (callbackFunc) != "function")
			{
				throw Error("PostMessage.InvokeMethod argument callbackFunc is not function");
			}

			// send message to listeners
			for (var n = 0; n < this._listenersArr.length; n++)
			{
				var curr;
				if ((curr = this._listenersArr[n]) && curr != window) // do not send to itself
				{
					curr.postMessage(EncodeDataObj({
						senderUID: this._uniqueUID,
						destinationUID: destinationUID,
						funcName: funcName,
						argument: sendValue,
						callbackFuncName: <string>this.EncapsulateFunc(<any>callbackFunc) // every callbackFunc may be invoked once, than it has to be removed from _funcBag
					}), "*");
				}
			}
			return this;
		}

		public Echo(destinationUID: string, msg: string, callbackFunc: (returnedValue: string, ev: IPostMessageEvent) => void)
		{
			/// <summary>
			/// Echo method. It may be used to connect listener in iframe or child window.
			/// </summary>
			/// <param name="destinationUID" type="String">window or UID string</param>
			/// <param name="msg" type="Object" optional="true">object to be passed to invoking method as argument</param>
			/// <param name="callbackFunc" type="Function" optional="true">
			///		<para>function(returnedValue, event, this){....}</para>
			///		<para>function to be invoked on response received, handles object returned from invoked method using return (returnedValue);</para>
			///		<para>this inside of function is current PostMessage instance</para>
			///		<para>event is current event {sender:..., origin:..., data:...}</para>
			///		<para>returnedValue is sent as argument parameter in method this.InvokeMethod(....)</para>
			/// </param>

			return this.InvokeMethod(destinationUID, __EchoTestMethod, msg, callbackFunc);
		}

		private HandleMessageEvent(ev: IPostMessageEvent)
		{
			var dat1: TDataObject;

			// if any 3rd party code uses postMessage, make sure this message is from Calysto.PostMessage engine:
			// ev.data is readonly

			if (ev && ev.data && ev.type == "message" && typeof (ev.data) == "string"
				&& (dat1 = DecodeDataObj(ev.data))
				&& dat1.senderUID
				&& dat1.destinationUID)
			{
				//#if DEBUG
				if (Calysto.Core.IsDebugDefined)
				{
					//	console.log("PostMessage " + dat1.senderUID + " -> " + dat1.destinationUID + ": " + ev.data);
				}
				//#endif

				if (dat1.destinationUID == "*" || dat1.destinationUID == this._uniqueUID)
				{
					// register sender if not already registered
					this.AddDistinctListener(ev.source);

					////console.log("call to func: " + dat1.funcName);
					var func1;

					if (dat1.funcName && (func1 = this._funcBag[dat1.funcName]))
					{
						// execute funcName, and get result:
						var result = func1(dat1.argument, ev); //pass original event as 2nd parameter

						if (dat1.isCallback)
						{
							// this should be executed on sender after InvokeMethod is called than callback is received
							// console.log("delete func: " + dat1.funcName);
							// callback executed, remove it
							delete (this._funcBag[dat1.funcName]);
						}
						else if (ev && ev.source && dat1.callbackFuncName)
						{
							// console.log("callback response from " + _postMsgUID + ": " + Calysto.JSON.Serialize(result));
							// this part of the code is destination after InvokeMethod is invoked on sender
							// send response to sender only
							let data1 = EncodeDataObj({
								senderUID: this._uniqueUID,
								destinationUID: dat1.senderUID, // callback is always sent to initiator with specific UID, never to all (*)
								funcName: dat1.callbackFuncName,
								isCallback: true,
								argument: result
							});

							(<Window>ev.source).postMessage(data1, "*");
						}
						else
						{
							// InvokeMethod is invoked without callbackFunction
						}
					}
					else
					{
						throw new Error("Error in PostMessage, function not registered: " + dat1.funcName);
					}
				}
				else
				{
					// not PostMessage message or not for current listener
				}
			}
		}

		public static FindIframe(arg: MessageEvent | Window): HTMLIFrameElement | null
		{
			/// <summary>
			/// Find iframe element from arg
			/// </summary>
			/// <param name="ifrContentWin" type="MessageEvent|Window"></param>

			var iframes = document.getElementsByTagName("iframe");
			var ifr;
			for (var n = 0; n < iframes.length; n++)
			{
				if ((ifr = iframes[n]) && (ifr.contentWindow == (<any>arg).source || ifr.contentWindow == arg))
				{
					return <HTMLIFrameElement>ifr;
				}
			}
			return <any>null;
		}
	}
}
