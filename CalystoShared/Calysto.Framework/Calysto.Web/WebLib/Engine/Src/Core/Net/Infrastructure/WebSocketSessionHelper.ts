/// <reference path="webinfrastructure.ts" />

namespace Calysto.Net.WebService
{
	export class WebSocketSessionHelper
	{
		private ns: Function;
		private vpath: string;
		private methods: IWebServiceSettings[] = [];
		constructor(
			/**complete service namespace including C# class name*/
			private namespace: string,
			/**service url*/
			url: string
		)
		{
			this.ns = Calysto.DataBinder.GetValue(window, namespace);
			if (this.ns)
				throw new Error("Socket session type is already registered: " + namespace);

			this.vpath = Calysto.Utility.Encoding.Base64RndEncoder.DecodeBase64StringToString(url);

			let _safeThis = this;

			// namespace has to be function
			// ns function is will be invoked as ctor when constructing new session instance
			this.ns = function ()
			{
				let socket1 = new Calysto.Net.CalystoWebSocket(CreateUrl(_safeThis.vpath, <IWebServiceSettings>{ method: "$" }).replace("__calysto_json_arg__", ""));

				let wss = new WebSocketSession(<IWebServiceSettings>{ method: "RequestReceived" }, socket1);

				// register socket methods which may be used to send & receive data, the same as ajax methods
				for (let sett of _safeThis.methods)
				{
					wss[sett.method] = CreateSocketMethod(_safeThis, sett, wss, _safeThis.vpath);
				}

				return wss;
			};

			// methods must be placed into global namespace to be invocable from anywhere
			Calysto.DataBinder.SetValue(window, namespace, this.ns);
		}

		public RegisterSocketMethod(settings: IWebServiceSettings): WebSocketSessionHelper
		{
			this.methods.push(settings);
			return this;
		}
	}

	function CreateSocketMethod(_safeThis: WebSocketSessionHelper, settings: IWebServiceSettings, wss: WebSocketSession<any>, vpath: string)
	{
		return function (...funcSendArgs:any[])
		{
			if (settings.reque && !IsTriggeredByUserAction())
			{
				// don't send message
				return <any>null;
			}
			else
			{
				// get service method parameters: [argVal0, argVal1, argVal2...] or strongParams: {arg0: argVal0, arg1: argVal1, ...}
				let jsObject = CreateArgsObj(settings.method, funcSendArgs, settings.argNames || []);

				let requestGuid = Calysto.Mathm.NewGuid();

				let url = CreateUrl(vpath, settings).replace("__calysto_json_arg__", "");

				let context = new AjaxServiceClientWithReturn<string>();
				wss.OnMethodReturn(requestGuid, context);

				// jsObject treba zapakirati da se zna url, method name, typename..., sve sto se salje ajaxom inace
				wss.Socket.SendAsync(<ISocketServiceRequestContainer>{
					Method: settings.method,
					ReferenceGuid: requestGuid,
					RequestObj: <ISocketWebRequestArguments>{
						IsSocketWebClient: true,
						AjaxQueryString: url,
						AjaxArgs: jsObject
					}
				});

				return context;
			}
		}

	}
}
