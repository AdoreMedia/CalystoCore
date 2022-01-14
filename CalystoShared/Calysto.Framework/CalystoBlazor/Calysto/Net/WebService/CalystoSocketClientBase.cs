using Calysto.Web.Script.Services;
using Calysto.Blazor.Utility;
using System;
using System.Linq;
using System.Threading.Tasks;
using Calysto.Utility;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Threading;
using System.IO;
using Calysto.Web.Script.Services.WebSockets;
using System.Reflection;
using System.Web;

namespace Calysto.Net.WebService
{
	public class CalystoSocketClientBase<TBroadcastMessage> : IAsyncDisposable
	{
		public event Action<CalystoSocketClientBase<TBroadcastMessage>, TBroadcastMessage> OnBroadcastMessage;
		public event Action<CalystoSocketClientBase<TBroadcastMessage>, Exception> OnError;
		public event Action<CalystoSocketClientBase<TBroadcastMessage>> OnSocketClosed;

		private static bool _isPageReloading;

		/** socket instance may be shared among methods*/
		public ClientWebSocket _socket;

		BrowserContext _browser;
		
		string _urlBase;

		private async Task EngineExpiredAsync()
		{
			_isPageReloading = true;
			await _browser.LocationReloadAsync();
		}

		private async Task CloseSocketAsync()
		{
			if (_socket != null)
			{
				await _socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Close socket", CancellationToken.None);
				_socket = null;
			}
		}

		public bool IsDisposed { get; private set; }

		public async ValueTask DisposeAsync()
		{
			this.IsDisposed = true;

			_disposalToken.Cancel();
			await this.CloseSocketAsync();
		}

		private async Task<bool> HandleGeneralAsync(WebServiceResponseContainer responseContainer)
		{
			if (responseContainer.IsEngineExpired)
			{
				await this.CloseSocketAsync();
				await this.EngineExpiredAsync();
				return true;
			}

			if (_isPageReloading)
			{
				// do not execute the rest of the code because it would throw exception only
				return true;
			}

			if (responseContainer.EchoMsg == CalystoConstants.EchoServerRequest)
			{
				var container = new SocketServiceRequestContainer()
				{
					ReferenceGuid = responseContainer.ReferenceGuid,
					EchoMsg = CalystoConstants.EchoClientResponse
				};

				Serialization.Json.BinaryFrame bf1 = Calysto.Serialization.Json.BinaryFrame.Serialize(container);
				byte[] data1 = bf1.ToBinaryData();
				var arr1 = new ArraySegment<byte>(data1);

				await _socket.SendAsync(arr1, WebSocketMessageType.Binary, true, _disposalToken.Token);
				return true;
			}

			// exception can not be handled in OnSolicitedMessage if there is not method name or guid, so handle it here
			if (!string.IsNullOrEmpty(responseContainer.ExceptionMessage))
			{
				Console.WriteLine(responseContainer.ExceptionMessage + "\r\n" + responseContainer.ExceptionDetails);
				return true;
			}

			return false;
		}
		
		ConcurrentDictionary<string, Action<WebServiceResponseContainer>> _pendingCallbacks = new ConcurrentDictionary<string, Action<WebServiceResponseContainer>>();

		private async Task HandleSocketMessageAsync(WebServiceResponseContainer responseContainer)
		{
			bool isBroadcast = responseContainer.Method == CalystoConstants.BroadcastMethodName;
			Action<WebServiceResponseContainer> pendingAction = null;

			if (!isBroadcast
				&& !string.IsNullOrEmpty(responseContainer.ReferenceGuid)
				&& this._pendingCallbacks.TryRemove(responseContainer.ReferenceGuid, out pendingAction))
			{
				// we have pending task
			}

			if (await this.HandleGeneralAsync(responseContainer))
			{
				pendingAction?.Invoke(null);
				return;
			}

			if (!string.IsNullOrEmpty(responseContainer.JavaScriptLO))
			{
				await _browser.ExecuteScriptVoidAsync(responseContainer.JavaScriptLO);
			}

			if (isBroadcast)
			{
				var val1 = Calysto.Serialization.Json.JsonSerializer.ConvertToType<TBroadcastMessage>(responseContainer.ReturnedValue);
				this.OnBroadcastMessage?.Invoke(this, val1);
			}

			pendingAction?.Invoke(responseContainer);
		}

		private CancellationTokenSource _disposalToken = new CancellationTokenSource();

		private byte[] GetAvailableData(ArraySegment<byte> array1, int len1)
		{
			byte[] data1 = new byte[len1];
			Array.Copy(array1.Array, data1, len1);
			return data1;
		}

		int _receiveErrors = 0;

		private async Task ReceiveLoopAsync()
		{
			MemoryStream ms = null;
			var buffer = new ArraySegment<byte>(new byte[4 * 1024]);
			while (!this.IsDisposed
				&& _receiveErrors++ < 5
				&& _socket?.State == WebSocketState.Open 
				&& !_disposalToken.IsCancellationRequested)
			{
				if (ms == null)
					ms = new MemoryStream();

				try
				{
					WebSocketReceiveResult received = await _socket.ReceiveAsync(buffer, _disposalToken.Token);

					if (received.Count > 0)
					{
						_receiveErrors = 0;
						ms.Write(this.GetAvailableData(buffer, received.Count));
					}

					if (received.EndOfMessage && ms.Length > 0)
					{
						WebServiceResponseContainer resp1 = Calysto.Serialization.Json.BinaryFrame.Deserialize<WebServiceResponseContainer>(ms.ToArray());
						ms.Close();
						await ms.DisposeAsync();
						ms = null;
						await this.HandleSocketMessageAsync(resp1);
					}

					if (received.CloseStatus.HasValue)
					{
						break;
					}
				}
				catch(Exception ex)
				{
					Console.WriteLine(ex.ToString());
					this.OnError?.Invoke(this, ex);
				}
			}

			Console.WriteLine("ReceiveLoopAsync exit: " + _socket.CloseStatus);
			this.OnSocketClosed?.Invoke(this);
		}

		private string _serverVersion;
		private string _currentUrl;

		private async Task<string> CreateUrlAsync(string methodName, bool makeAbsoluteUrl)
		{
			if (_serverVersion == null)
				_serverVersion = await _browser.GetServerVersionFromHtmlAsync();
			
			if (_currentUrl == null)
				_currentUrl = (await _browser.GetLocationAsync()).href;

			string baseAddr = _browser.HostEnvironment.BaseAddress;

			return (makeAbsoluteUrl ? baseAddr?.TrimEnd('/').Replace("https://", "wss://").Replace("http://", "ws://") : null)
				+ _urlBase.Replace("__calysto_method_name__", methodName)
				.Replace("__calysto_culture__", System.Globalization.CultureInfo.CurrentCulture.Name)
				.Replace("__calysto_ss__", "0")
				.Replace("__calysto_current_url__", HttpUtility.UrlEncode(_currentUrl))
				.Replace("__calysto_json_arg__", "")
				+ _serverVersion;
		}

		private async Task EnsureConnectedAsync()
		{
			if (_socket == null || _socket.State != WebSocketState.Open)
			{
				string url = await this.CreateUrlAsync("$", true);
				_socket = new ClientWebSocket();
				await _socket.ConnectAsync(new Uri(url), _disposalToken.Token);
				_ = this.ReceiveLoopAsync();
			}
		}

		static ConcurrentDictionary<Type, PropertyInfo[]> _dicProperties = new ConcurrentDictionary<Type, PropertyInfo[]>();

		private Dictionary<string, object> ConvertObjectToDictionary(object obj)
		{
			if (obj == null)
				return null;

			return _dicProperties.GetOrAdd(obj.GetType(), type => type.GetProperties())
				.ToDictionary(pi => pi.Name, pi => pi.GetValue(obj));
		}

		private async Task<TReturn> SendObjectAsync<TReturn>(string methodName, object objToSend)
		{
			await this.EnsureConnectedAsync();

			// jsObject treba zapakirati da se zna url, method name, typename..., sve sto se salje ajaxom inace
			var container = new SocketServiceRequestContainer()
			{
				Method = methodName,
				ReferenceGuid = Guid.NewGuid().ToString(),
				RequestObj = new SocketWebRequestArguments()
				{
					IsSocketWebClient = true,
					AjaxQueryString = await this.CreateUrlAsync(methodName, false),
					AjaxArgs = this.ConvertObjectToDictionary(objToSend)
				}
			};

			Serialization.Json.BinaryFrame bf1 = Calysto.Serialization.Json.BinaryFrame.Serialize(container);
			byte[] data1 = bf1.ToBinaryData();
			var arr1 = new ArraySegment<byte>(data1);

			TaskCompletionSource<TReturn> completionSource = new TaskCompletionSource<TReturn>();
			_pendingCallbacks.TryAdd(container.ReferenceGuid, responseContainer =>
			{
				if (responseContainer == null)
				{
					completionSource.TrySetCanceled();
				}
				else
				{
					var val1 = Calysto.Serialization.Json.JsonSerializer.ConvertToType<TReturn>(responseContainer.ReturnedValue);
					completionSource.TrySetResult(val1);
				}
			});

			await _socket.SendAsync(arr1, WebSocketMessageType.Binary, true, _disposalToken.Token);

			return await completionSource.Task;
		}

		public CalystoSocketClientBase(BrowserContext browser, string urlPathAndQuery)
		{
			_browser = browser;
			_urlBase = urlPathAndQuery;
		}

		public async Task<TResult> MakeRequestAsync<TResult>(CalystoWebMethodAttribute attr, string methodName, object args)
		{
			return await this.SendObjectAsync<TResult>(methodName, args);
		}

		public Task MakeRequestAsync(CalystoWebMethodAttribute attr, string methodName, object args)
		{
			return this.MakeRequestAsync<object>(attr, methodName, args);
		}

		public TResult MakeRequest<TResult>(CalystoWebMethodAttribute attr, string methodName, object args)
		{
			return this.MakeRequestAsync<TResult>(attr, methodName, args).Result;
		}
	}
}
