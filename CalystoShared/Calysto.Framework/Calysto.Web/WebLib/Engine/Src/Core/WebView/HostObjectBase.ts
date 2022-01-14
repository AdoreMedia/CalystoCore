/// <reference path="../Json/Json.ts" />
namespace Calysto.WebView
{
	class CallbackHandler
	{
		private _pendingTasks = new Map<string, ((resp) => void)>();

		public Add(key: string, fn: (resp) => void)
		{
			this._pendingTasks.set(key, fn);
		}

		public HostServiceResolveCallback(key: string, result: any)
		{
			let item1 = this._pendingTasks.get(key);
			this._pendingTasks.delete(key);
			if (item1)
				item1(result);
		}
	}

	let _callbackHandler: CallbackHandler;

	class ResponseObject
	{
		Result: any;
		Error: string;
	}

	export abstract class HostObjectBase
	{
		protected _hostObjectName: string;

		protected async InvokeMethodAsync(methodName: string, args?: any[])
		{
			// ensure handler exists
			window["$$$calystoHostCallbackHandler"] = _callbackHandler = window["$$$calystoHostCallbackHandler"] || new CallbackHandler();

			let jsonArgsArr: Json.Infrastructure.AsyncCompleteType;
			try
			{
				jsonArgsArr = await Calysto.Json.SerializeAsync(args);
			}
			catch (err2)
			{
				alert(err2);
				console.error(err2);
				return;
			}

			return new Promise<any>((resolve, reject) =>
			{
				let key1 = Calysto.Utility.Generators.GenerateLabel(20);
				_callbackHandler.Add(key1, json1 =>
				{
					let resp1: ResponseObject;
					try
					{
						resp1 = Calysto.Json.Deserialize<ResponseObject>(json1);
					}
					catch (err1)
					{
						alert(err1);
						console.error(json1);
						reject(err1);
						return;
					}

					if (resp1.Error)
					{
						alert(resp1.Error);
						console.error(resp1.Error);
						reject(resp1.Error);
					}
					else
					{
						resolve(resp1.Result);
					}
				});

				(<any>window).chrome.webview.hostObjects[this._hostObjectName].InvokeHostServiceMethodAsync(key1, methodName, jsonArgsArr.json);

			});
		}

		///**
		// * Works on WebView UI thread and blocks thread until host returns.
		// * @param methodName
		// * @param args
		// */
		//protected async InvokeMethodPartialAsync(methodName: string, args?: any[])
		//{
		//	let jsonArgsArr = await Calysto.Json.SerializeAsync(args);
		//	let json1 = await (<any>window).chrome.webview.hostObjects[this._hostObjectName].InvokeHostServiceMethod(methodName, jsonArgsArr.json);
		//	let resp1 = Calysto.Json.Deserialize<ResponseObject>(json1);
		//	if (resp1.Error)
		//		alert(resp1.Error);
		//	else
		//		return resp1.Result;
		//}
	}
}
