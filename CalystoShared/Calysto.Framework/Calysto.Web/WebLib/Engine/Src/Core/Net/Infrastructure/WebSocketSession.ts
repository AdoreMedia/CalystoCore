namespace Calysto.Net.WebService
{
	export class WebSocketSession<TBroadcastMessage>
	{
		constructor(
			/**settings is unique per method*/
			private settings: IWebServiceSettings,
			/** socket instance may be shared among methods*/
			public Socket: CalystoWebSocket
		)
		{
			// implement message receiver for socket instance:
			this.Socket.OnMessage(async responseContainer => await this.HandleSocketMessageAsync(responseContainer));
		}

		private async HandleSocketMessageAsync(responseContainer: IWebServiceResponseContainerWithReturn<TBroadcastMessage>)
		{
			let isBroadcast = responseContainer.Method == Calysto.Constants.AppConstants.BroadcastMethodName;

			let context: AjaxServiceClientWithReturn<any> = <any>null;

			if (!isBroadcast && responseContainer.ReferenceGuid)
			{
				let refOut = new BoxValue<AjaxServiceClientWithReturn<any>>();
				if (this._pendingCallbacks.TryGetValue(responseContainer.ReferenceGuid, refOut))
				{
					this._pendingCallbacks.RemoveKey(responseContainer.ReferenceGuid);
					context = refOut.GetValue();
				}
			}

			let isHandled = await this.ProcessResponseAsync(context, responseContainer);

			if (!isHandled)
			{
				if (responseContainer.JavaScriptLO && !responseContainer.IsJavaScriptLODone)
				{
					responseContainer.IsJavaScriptLODone = true;
					let nodeLo = Calysto.ScriptLoader.LoadJS(responseContainer.JavaScriptLO);
					setTimeout(() => (<any>nodeLo).parentNode.removeChild(nodeLo), 200); // remove from dom immediately
				}

				if (isBroadcast)
				{
					this.OnBroadcastMessage.Invoke(fn => fn(responseContainer.ReturnedValue));
				}

				if (context)
				{
					context.OnResponse.Invoke(f => f(responseContainer));
					context.OnSuccess.Invoke(f => f(responseContainer.ReturnedValue));
				}
			}
		}

		private async ProcessResponseAsync(
			context: AjaxServiceClientWithReturn<any>,
			responseContainer: IWebServiceResponseContainerWithReturn<TBroadcastMessage>)
		{
			if (responseContainer.IsEngineExpired)
			{
				this.Socket.Close(); // socket has to be closed from client
				EngineExpired();
				return true;
			}

			if (Calysto.Page.IsPageReloading)
			{
				// do not execute the rest of the code because it would throw exception only
				return true;
			}

			if (responseContainer.EchoMsg == Calysto.Constants.AppConstants.EchoServerRequest)
			{
				//return response
				await this.Socket.SendAsync(<ISocketServiceRequestContainer>{
					ReferenceGuid: responseContainer.ReferenceGuid,
					EchoMsg: Calysto.Constants.AppConstants.EchoClientResponse
				});
				return true;
			}

			// exception can not be handled in OnSolicitedMessage if there is not method name or guid, so handle it here
			if (responseContainer.ExceptionMessage && !responseContainer.IsExceptionMessageDone)
			{
				responseContainer.IsExceptionMessageDone = true;

				if (Calysto.Core.IsDebugDefined)
				{
					console?.error(responseContainer.ExceptionMessage + "\r\n" + responseContainer.ExceptionDetails);
				}
				else if (context?.OnError.Any())
				{
					context.OnError.Invoke(f => f(<string>responseContainer.ExceptionMessage));
				}
				else if (this.OnError.Any())
				{
					this.OnError.Invoke(f => f(<string>responseContainer.ExceptionMessage));
				}
				else
				{
					console?.error(responseContainer.ExceptionMessage);
				}

				return true;
			}

			// not handled
			return false;
		}

		public readonly OnBroadcastMessage = new Calysto.MulticastDelegate<(resp: TBroadcastMessage) => void>().AsFunc(this);

		public readonly OnError = new Calysto.MulticastDelegate<(errMsg: string) => void>().AsFunc(this);

		private _pendingCallbacks: Dictionary<string, AjaxServiceClientWithReturn<any>> = new Dictionary();

		public OnMethodReturn(requestGuid: string, context: AjaxServiceClientWithReturn<any>)
		{
			this._pendingCallbacks.Add(requestGuid, context);
		}
	}
}
