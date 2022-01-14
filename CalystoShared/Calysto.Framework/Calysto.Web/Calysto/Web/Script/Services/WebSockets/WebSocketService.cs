using Calysto.Serialization.Json;
using Calysto.Serialization.Json.Core.Serialization;
using Calysto.Timers;
using Calysto.Utility;
using Calysto.Web.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace Calysto.Web.Script.Services.WebSockets
{
	public abstract class WebSocketService : IDisposable
	{
		private WebSocketListenersHelper Listeners => WebSocketListenersHelper.GetSessionsHelper(this.TargetType);

		protected WebSocket WebSocket { get; set; }
		protected Type TargetType { get; set; }
		protected bool IsReloadRequired { get; set; }

		/// <summary>
		/// Send echo messasge if idle for ms
		/// </summary>
		public int EchoIfIdle { get; set; } = 30 * 1000;

		/// <summary>
		/// Wait ms for echo response from client before trigering socket
		/// </summary>
		public int WaitForEchoResponse { get; set; } = 30 * 1000;

		protected IWebSocketSession webSocketSessionInstance;

		public bool IsDisposed { get; private set; }
		public void Dispose()
		{
			if (!this.IsDisposed)
			{
				this.IsDisposed = true;
				try { this.EndSocketSession(); } catch { }
				try { this.webSocketSessionInstance?.OnClose(); } catch { }
				try { this.webSocketSessionInstance?.Dispose(); } catch { }
				try { this.CloseSocket(); } catch { }
			}
		}

		~WebSocketService() => this.Dispose();

		protected void StartSocketSession()
		{
			this.Listeners.AddSession(this.webSocketSessionInstance);
			this.webSocketSessionInstance.OnOpen();
		}

		protected void EndSocketSession()
		{
			this.Listeners.RemoveSession(this.webSocketSessionInstance);
			this.webSocketSessionInstance?.OnClose();
		}

		public bool IsSocketOpen
		{
			get
			{
				try { return !this.IsDisposed && this.WebSocket?.State == WebSocketState.Open; } catch { return false; }
			}
		}

		public SessionsCollection GetListeners(ListenersKind kind)
		{
			switch (kind)
			{
				case ListenersKind.All: return this.Listeners.GetSessions();
				case ListenersKind.Other: return this.Listeners.GetSessions(o => o != this.webSocketSessionInstance);
				case ListenersKind.Current: return new SessionsCollection(this.TargetType, new HashSet<IWebSocketSession>(new[] { this.webSocketSessionInstance }));
				default: 	throw new NotSupportedException();
			}
		}

		protected abstract void MarkWebSocket();

		protected abstract void MarkDiagnostic(string jsonStr, List<CalystoBlob> blobs, string method);

		protected abstract Task<CalystoResponse> InvokeMethodAsync(IWebSocketSession webSocketSessionInstance, AjaxQueryStringHelper astr, CalystoRequest request1, CalystoResponse response1);

		protected async Task ProcessWebSocketRequestAsync()
		{
			try
			{
				if (typeof(IWebSocketSession).IsAssignableFrom(this.TargetType))
				{
					this.webSocketSessionInstance = (IWebSocketSession)Activator.CreateInstance(this.TargetType);
					this.webSocketSessionInstance.Service = this;
				}
				else
				{
					throw new NotSupportedException();
					// some other type, so socket is used for webclient requests
					//targetInstance = Activator.CreateInstance<IWebSocketSession>();
				}
			}
			catch
			{
				this.IsReloadRequired = true;
			}

			byte[] completeMsg = null;

			// if IIS app is restarted, socket will be closed, so version check has to be done on open command only
			if (this.WebSocket.State == WebSocketState.Open)
			{
				if (webSocketSessionInstance == null || this.IsReloadRequired)
				{
					// on first request, if reload is required, reload
					// return JS command to reload page
					await this.WebSocket.SendAsync(
						new CalystoResponse().SetEngineExpired().ToArraySegmentCompiled(),
						WebSocketMessageType.Binary,
						true,
						CancellationToken.None);

					// warning: we have to wait for the client to receive the message before we close the socket
					// how do we know when client received the message? 
					// client has to signal us, or initiate disconect from client.

					// do not disconnect from server, client has to receive the message first
					// await this.SocketContext.WebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "EngineVersionExpired", CancellationToken.None);

					// if we remore previous WaitForMessage, socket would be closed on client before the client received JS command for reload
					// there is message sent on request, so read it and wait for client to reload the page, it will close socket connection too
					while (this.WebSocket.State == WebSocketState.Open)
					{
						completeMsg = await WaitForMessageAsync();
						//string userMessage = Encoding.UTF8.GetString(completeMsg);
					}

					return;
				}

				// execute OnOpen callback
				this.StartSocketSession();
			}
			else
			{
				// not opened
				return;
			}

			// VAZNO: ako se izgubi internet konekcija, ne moze detektirati da je client discontectiran,
			// zato treba kontrolirati da li je klijent prisutan periodickim slanje echo-a

			CalystoTimer echoTimeout = new CalystoTimer(timer =>
			{
				// ako okine timeout, znaci nije primio echo response, socket nije spojen
				this.Dispose();
			});

			CalystoTimer receiveTimeout = new CalystoTimer(async (timer) =>
			{
				// ako okine receive timeout, treba poslati echo i cekati odgovor

				// poslati echo
				CalystoResponse respEcho1 = new CalystoResponse();
				respEcho1.SetReferenceGuid(Guid.NewGuid().ToString());
				respEcho1.SetEchoMsg(CalystoConstants.EchoServerRequest);
				await this.SendAsync(respEcho1.ToArraySegmentCompiled());

				// cekaj response 2 * jer mora poslati i primiti poruku
				echoTimeout.Abort().Start(this.WaitForEchoResponse);

			});

			if (this.EchoIfIdle > 0)
				receiveTimeout.Abort().Start(this.EchoIfIdle);

			bool nothingRead = false;

			// main loop:
			while (true)
			{
				bool isOpen = false;
				try
				{
					isOpen = this.IsSocketOpen;
				}
				catch { }

				if (nothingRead || !isOpen)
				{
					this.EndSocketSession();
					return;
				}

				this.MarkWebSocket();

				// await for user message
				completeMsg = await WaitForMessageAsync();

				if (completeMsg == null || !completeMsg.Any())
				{
					nothingRead = true; // client is disconnected or network connection doesn't work, we have to make sure to exit the while loop, otherwise the IIS service loops and has to be restarted (not just the application)
					continue;
				}

				// processed received message

				if (this.EchoIfIdle > 0)
					receiveTimeout.Start(this.EchoIfIdle);
				else
					receiveTimeout.Abort();

				// CalystoContext is cached into HttpContext.Current.Items, which is shared during the socket session
				CalystoRequest request1 = new CalystoRequest();
				CalystoResponse response1 = new CalystoResponse();
				SocketServiceRequestContainer req = null;

				try
				{
					List<CalystoBlob> blobs = null;
					string jsonStr = null;

					SerializerOptions opt1 = new SerializerOptions();
					req = BinaryFrame.Deserialize<SocketServiceRequestContainer>(completeMsg, opt1);
					jsonStr = opt1.BFOutput.Json;
					blobs = opt1.BFOutput.Blobs;

					response1.SetReferenceGuid(req.ReferenceGuid);
					if (req.EchoMsg == CalystoConstants.EchoClientRequest)
					{
						response1.SetEchoMsg(CalystoConstants.EchoServerResponse);
						await this.SendAsync(response1.ToArraySegmentCompiled());
						continue;
					}
					else if (req.EchoMsg == CalystoConstants.EchoClientResponse)
					{
						echoTimeout.Abort();
						continue;
					}
					else if (!string.IsNullOrWhiteSpace(req.EchoMsg))
					{
						throw new NotSupportedException("invalid echo msg: " + req.EchoMsg);
					}

					this.MarkDiagnostic(jsonStr, blobs, req.Method);

					SocketWebRequestArguments socketArgs = SocketWebRequestArguments.ConvertRequestObj(req.RequestObj);

					AjaxQueryStringHelper astr = AjaxQueryStringHelper.Parse(socketArgs.AjaxQueryString);

					if (astr?.IsSuccessful == true)
					{
						response1.SetMethodName(astr.methodName);

						astr.isSocketWebClient = true;
						astr.methodArguments = socketArgs.AjaxArgs;

						CalystoResponse resp2 = await this.InvokeMethodAsync(this.webSocketSessionInstance, astr, request1, response1);

						if (resp2 != null)
						{
							resp2.SetReferenceGuid(req.ReferenceGuid);
							resp2.SetMethodName(astr.methodName);
							response1 = resp2;
						}
					}
					else
					{
						throw new NotSupportedException("socket method not supported here");

						//response1.SetMethodName(req.Method);

						//WebServiceMethodData methodData = WebServiceMethodData.GetMethodData(this.TargetType, req.Method);

						//CalystoContext.Current.Request.Diagnostic.CALYSTO_FULLMETHOD = methodData.FullMethodString;

						//object returnedValue = methodData.CallMethodFromRawParams(this.webSocketSessionInstance, (IDictionary<string, object>)req.RequestObj);

						//// if there is no exception thrown invoking the method, it is successful
						//response1.SetInvocationSuccessful(true);

						//if (methodData.MethodInfo.ReturnType != typeof(void))
						//{
						//	response1.SetReturnValue(returnedValue);
						//}
					}
					// always send response, eg. if there is JavaScript only, resp != null always
				}
				catch (Exception ex)
				{
					try
					{
						// unhandled exception
						CalystoHostingEnvironment.Current.NotifyException(this, () => ex);
					}
					catch { }

					response1.SetMethodName(req?.Method).SetExceptionMessage(ex);
				}

				await this.SendAsync(response1.ToArraySegmentCompiled());
			}
		}


		protected async Task<byte[]> WaitForMessageAsync()
		{
			ArraySegment<byte> array1 = new ArraySegment<byte>(new byte[4096]);
			MemoryStream ms = new MemoryStream();
			// segments receiver loop:
			while (this.WebSocket.State == WebSocketState.Open)
			{
				// wait here for message from client
				WebSocketReceiveResult result = await this.WebSocket.ReceiveAsync(array1, CancellationToken.None);

				ms.Write(array1.Array, 0, result.Count);

				if (result.EndOfMessage)
					break;
			}

			byte[] data1 = ms.ToArray();
			ms.Dispose();
			return data1;
		}

		public Task SendAsync(ArraySegment<byte> data)
		{
			lock (this)
			{
				if (this.IsSocketOpen)
				{
					return this.WebSocket.SendAsync(data, WebSocketMessageType.Binary, true, CancellationToken.None);
				}
			}
			return Task.CompletedTask;
		}

		public Task CloseSocket()
		{
			lock (this)
			{
				if (this.IsSocketOpen)
				{
					return this.WebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "CloseSocket", CancellationToken.None);
				}
			}
			return Task.CompletedTask;
		}

		public Task BroadcastResponse(Action<CalystoResponse> action)
		{
			if (this.IsSocketOpen)
			{
				CalystoResponse response = new CalystoResponse().SetMethodName(CalystoConstants.BroadcastMethodName);
				action.Invoke(response);
				return this.SendAsync(response.ToArraySegmentCompiled());
			}
			return Task.CompletedTask;
		}

		public Task BroadcastMessage<TValue>(TValue value)
		{
			return this.BroadcastResponse(a => a.SetReturnValue(value));
		}


	}
}