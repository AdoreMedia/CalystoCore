namespace Calysto.Net
{
	type FuncDelegate = () => void;

	type MessageDelegate = (socketMsg: any) => void;

	type ErrorDelegate = (errMsg: string) => void;

	function Log(msg)
	{
		console.log(Date.now(), msg);
	}

	export class CalystoWebSocket
	{
		constructor(
			/** eg. /files/path.aspx */
			private virtualPath: string
		)
		{
		}
		
		private ws: WebSocket; // null,// new WebSocket(""), // don't instantinate now because new instance will try to connect to server immediately
		private receiveBuffer: any[];
		private sendQueue: any[];

		/** Add new callback after socket opened. */
		public readonly OnOpen = new MulticastDelegate<FuncDelegate>().AsFunc(this);

		/** Callback after socket closed */
		public readonly OnClose = new MulticastDelegate<FuncDelegate>().AsFunc(this);

		public readonly OnError = new MulticastDelegate<ErrorDelegate>().AsFunc(this);

		/** Callback on message received*/
		public readonly OnMessage = new MulticastDelegate<MessageDelegate>().AsFunc(this);


		//WebSocket.CLOSED = 3;
		//WebSocket.CLOSING = 2;
		//WebSocket.CONNECTING = 0;
		//WebSocket.OPEN = 1

		public async OpenAsync()
		{
			//#if DEBUG
			if (Calysto.Core.IsDebugDefined) Log("#WebSocket: " + (this.ws ? this.ws.readyState : "not initialized"));
			//#endif

			if (this.ws && this.ws.readyState == WebSocket.OPEN)
			{
				return this;
			}
			//else if (this.ws && this.ws.readyState == WebSocket.CONNECTING)
			//{
			//	// do nothing, already in connecting state, callbackOpened will be invoked from this.ws.onopen()
			//}
			else
			{
				var url = this.virtualPath;
				if (!(url.indexOf("//") > 0))
				{
					url = (window.location.protocol == "https:" ? "wss:" : "ws:") + "//" + window.location.host + this.virtualPath;
				}

				try
				{
					// this invokes handshake with server and may throw internal error - in Chrome, error is written to console
					// the rest of JS continues to execute and cfg.ws.onerror is invoked after fn is assigned
					// tricky: error is created before, but onerror is defined later and invoked with error which is created before the onerror is defined
					// this can not be caught in try-catch, because it doesn't throw JS exception
					this.ws = new WebSocket(url); // instantinate and open socket
					this.ws.binaryType = "arraybuffer"; // if not specified, default is Blob
				}
				catch (ex1)
				{
				}

				// this.ws.on... event listerens are Promise like, so don't worry if data arrives before the event is assigned

				this.ws.onmessage = async (ev) =>
				{
					if (ev.data && this.OnMessage.Any())
					{
						// ev.data is defined in cfg.ws.binaryType
						let obj = await Calysto.Json.BinaryFrame.DeserializeAsync(ev.data);

						Calysto.Core.DebugRun(() =>
						{
							//#if DEBUG
							if (Calysto.Core.IsDebugDefined) Log({ "#SOCKET_RECEIVED": obj });
							//#endif
						});

						this.OnMessage.Invoke(item => item(obj));
					}
				};
				
				this.ws.onclose = () =>
				{
					//#if DEBUG
					if (Calysto.Core.IsDebugDefined) Log("#WebSocket closed");
					//#endif
					
					this.OnClose.Invoke(item => item());
				};

				this.ws.onerror = () =>
				{
					//#if DEBUG
					if (Calysto.Core.IsDebugDefined) Log("#WebSocket error");
					//#endif
					
					this.OnError.Invoke(item => item("#WebSocket error"));
				};

				let __this = this;

				return Tasks.TaskUtility.CallbackAsync<CalystoWebSocket>(resolve =>
				{
					this.ws.onopen = () =>
					{
						//#if DEBUG
						if (Calysto.Core.IsDebugDefined) Log("#WebSocket opened");
						//#endif
						
						this.OnOpen.Invoke(item => item());

						// invoke callback:
						resolve(__this);
					};
				});

			}
		};

		private isSending = false;

		public async SendAsync(item: any)
		{
			if (!this.sendQueue)
				this.sendQueue = [];

			this.sendQueue.push(item);

			if (this.isSending)
				return;

			this.isSending = true;

			try
			{
				await this.OpenAsync();

				let obj;
				while (this.sendQueue && (obj = this.sendQueue.shift()))
				{
					this.isSending = true;

					let binaryFrame = await Calysto.Json.BinaryFrame.SerializeAsync(obj);

					Calysto.Core.DebugRun(() =>
					{
						//#if DEBUG
						if (Calysto.Core.IsDebugDefined) Log({ "#SOCKET_SEND": obj });
						//#endif
					});

					var finalBlob = binaryFrame.ToBinaryData();
					this.ws.send(finalBlob);
				}
			}
			finally
			{
				this.isSending = false;
			}

			return this;
		}

		public IsOpened()
		{
			return !!(this.ws && this.ws.readyState == WebSocket.OPEN);
		};

		public Close()
		{
			if (this.ws)
			{
				this.ws.close();
			}
			return this;
		}
	}
}

