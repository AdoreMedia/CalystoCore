using Calysto.CCFServices.Transport;
using Calysto.CCFServices.Transport.Tcp;
using Calysto.Common.Extensions;
using Calysto.Security.Cryptography;
using Calysto.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calysto.CCFServices.Client
{
	public class CalystoServiceClient : IDisposable
	{
		private object _targetInstance;
		private ICCFTransportClient _transportClient;
		private string _sessionId;
		public int RequestTimeoutSeconds { get; set; } = 60 * 5;

		private bool _useSession = true;
		
		/// <summary>
		/// Default: true. Setting value always removes previous sessionId information.
		/// </summary>
		public bool UseSessionState
		{
			get => _useSession;
			set { _useSession = value; _sessionId = null; }
		}

		public Action<ProgressEventArgs> OnRequestProgress;

		public Action<CalystoServiceClient, Exception> OnException;

		public CalystoServiceClient(object targetInstance, ICCFTransportClient transportClient)
		{
			_targetInstance = targetInstance;
			_transportClient = transportClient;
			_transportClient.OnProgress += _transport_OnProgress;
			_transportClient.OnDataReceived += _transport_OnResponseWorker;
		}

		private void _transport_OnProgress(ProgressEventArgs obj)
		{
			this.OnRequestProgress?.Invoke(obj);
		}

		~CalystoServiceClient()
		{
			this.Dispose();
		}

		AESCryptoHelper _crypto;

		public void UseEncryptionKey(string key)
		{
			if (key == null)
				_crypto = null;
			else
				_crypto = new AESCryptoHelper(key);
		}

		#region disposing

		public bool IsDisposed { get; private set; }

		public void Dispose()
		{
			if (this.IsDisposed) return;
			this.IsDisposed = true;

			try
			{
				_transportClient.Dispose();
			}
			catch { }

			_requestsList?.ForEach(o =>{ try { o.CompletionSource.SetCanceled(); } catch { } });

			_requestsList?.Clear();

			this.OnException = null;
			this.OnRequestProgress = null;
		}

		#endregion

		#region request sender

		class StateObject
		{
			public RequestInfo Request;
			public ResponseInfo Response;
			public Exception Exception;
			public TaskCompletionSource<bool> CompletionSource;

			public Delegate Delegate;
			public string EventName;
		}

		List<StateObject> _requestsList = new List<StateObject>();

		private void SetExceptionAndRemoveList(Exception ex)
		{
			_requestsList.UsingLock(a =>
			{
				a.ForEach(o => o.Exception = ex);
				var list = a.ToList();
				a.Clear();
				return list;
			}).ForEach(o => o.CompletionSource.SetException(ex));
		}

		private void _transport_OnResponseWorker(byte[] respData1)
		{ 
			ResponseInfo respInfo1 = null;
			Exception exception1 = null;

			if (respData1 != null)
			{
				try
				{
					byte[] decrypted = _crypto?.Decrypt(respData1) ?? respData1;
					respInfo1 = BinaryFrame.Deserialize<ResponseInfo>(decrypted);
				}
				catch (Exception ex)
				{
					exception1 = ex;
				}
			}

			if(exception1 != null)
			{
				this.OnException?.Invoke(this, exception1);
				SetExceptionAndRemoveList(exception1);
			}
			else if (respInfo1?.Action == ActionEnum.EventTriggered)
			{
				if (_eventSubscriptions.TryGetValue(respInfo1.MethodName, out Delegate delegate1))
				{
					try
					{
						object[] args1 = Calysto.Serialization.Json.JsonSerializer.ConvertToType<object[]>(respInfo1.ReturnValue);

						object[] final1 = delegate1.Method.GetParameters().Select((par, index) =>
						{
							// convert every arg into correct type
							return Calysto.Serialization.Json.JsonSerializer.ConvertToType(args1[index], par.ParameterType);
						}).ToArray();

						delegate1.DynamicInvoke(final1); // DynamicInvoke will invoke all methods inside and in correct instance
					}
					catch (Exception ex)
					{
						this.OnException?.Invoke(this, ex);
						SetExceptionAndRemoveList(ex);
					}
				}
			}
			else if(respInfo1 != null)
			{
				StateObject state1 = _requestsList.UsingLock(a =>
				{
					StateObject state2 = a.Where(o => o.Request.RequestId == respInfo1.RequestId).FirstOrDefault();
					if (state2 != null)
					{
						state2.Response = respInfo1;
						state2.Exception = exception1;
					}
					return state2;
				});

				state1?.CompletionSource.SetResult(true);
			}
		}

		private async Task<object> SendRequestWorkerAsync(StateObject state1)
		{
			BinaryFrame frame = BinaryFrame.Serialize(state1.Request);
			byte[] data = frame.ToBinaryData();
			byte[] encrypted = _crypto?.Encrypt(data) ?? data;

			_requestsList.UsingLock(a => a.Add(state1));

			state1.CompletionSource = new TaskCompletionSource<bool>();

			try
			{
				await _transportClient.SendRequestAsync(encrypted);
			}
			catch
			{
				_requestsList.UsingLock(a => a.Remove(state1));
				throw;
			}

			try
			{
				var resultTask = await Task.WhenAny(state1.CompletionSource.Task, Task.Delay(this.RequestTimeoutSeconds * 1000));

				if (resultTask is Task<bool> res1)
				{
					if (state1.Request.Action == ActionEnum.InvokeOnce)
						_requestsList.UsingLock(a => a.Remove(state1));

					if (state1?.Exception != null)
					{
						throw state1.Exception;
					}
					else if (state1?.Response?.Error != null)
					{
						throw state1.Response.Error.ToSystemException();
					}
					else if (state1?.Response != null)
					{
						if (this.UseSessionState && string.IsNullOrWhiteSpace(state1.Response.SessionId))
							throw new InvalidOperationException("SessionId is null or empty.");

						this._sessionId = state1.Response.SessionId;

						return state1.Response.ReturnValue;
					}
					else
					{
						throw new InvalidOperationException();
					}
				}
				else
				{
					// timeout
					throw new TimeoutException();
				}
			}
			catch
			{
				_requestsList.UsingLock(a => a.Remove(state1));
				throw;
			}
		}

		Dictionary<string, Delegate> _eventSubscriptions = new Dictionary<string, Delegate>();

		public void EventSubscription(string eventName, bool subscribe, Delegate eventCallback)
		{
			if (!(this.UseSessionState == true && _transportClient is TcpTransportClient))
			{
				throw new Exception("Event subscription requires TcpTransport and UseSessionState=true");
			}

			bool sendRequest = false;

			lock (_eventSubscriptions)
			{
				int previousCnt = 0;
				if (_eventSubscriptions.TryGetValue(eventName, out Delegate previous1))
					previousCnt = previous1.GetInvocationList().Length;

				int newCnt = eventCallback?.GetInvocationList().Length ?? 0;

				// replace delagates list with new one
				if (eventCallback == null)
					_eventSubscriptions.Remove(eventName);
				else
					_eventSubscriptions[eventName] = eventCallback;

				sendRequest = (subscribe && previousCnt == 0 && newCnt > 0)
					|| (!subscribe && previousCnt > 0 && newCnt == 0);
			}

			if (sendRequest)
			{
				StateObject state1 = new StateObject()
				{
					Delegate = eventCallback,
					EventName = eventName,

					Request = new RequestInfo()
					{
						UseSession = this.UseSessionState,
						SessionId = this._sessionId,
						RequestId = Guid.NewGuid().ToString(),
						MethodName = eventName,
						Action = subscribe ? ActionEnum.SubscribeEvent : ActionEnum.UnsubscribeEvent
					}
				};

				SendRequestWorkerAsync(state1).Wait();
			}
		}

		private async Task<TResult> CreateStateObjectAsync<TResult>(string methodName, object[] args)
		{
			StateObject state1 = new StateObject()
			{
				Request = new RequestInfo()
				{
					UseSession = this.UseSessionState,
					SessionId = this._sessionId,
					RequestId = Guid.NewGuid().ToString(),
					MethodName = methodName,
					Arguments = args,
					Action = ActionEnum.InvokeOnce
				}
			};

			object returnValue = await this.SendRequestWorkerAsync(state1);

			return Calysto.Serialization.Json.JsonSerializer.ConvertToType<TResult>(returnValue);
		}

		public async Task<TResult> SendRequestAsync<TResult>(string methodName, object[] args)
		{
			return await this.CreateStateObjectAsync<TResult>(methodName, args);
		}

		public TResult SendRequest<TResult>(string methodName, object[] args)
		{
			return this.CreateStateObjectAsync<TResult>(methodName, args).Result;
		}

		public Task SendRequestAsync(string methodName, object[] args)
		{
			return this.SendRequestAsync<object>(methodName, args);
		}

		public void SendRequest(string methodName, object[] args)
		{
			this.SendRequest<object>(methodName, args);
		}

		#endregion


	}
}
