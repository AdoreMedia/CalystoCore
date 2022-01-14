using Calysto.CCFServices.Transport;
using Calysto.Common;
using Calysto.Common.Extensions;
using Calysto.Security.Cryptography;
using Calysto.Serialization.Json;
using Calysto.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Calysto.Serialization.Json.Core.Serialization;

namespace Calysto.CCFServices.Host
{
	public class CalystoServiceHost<TContract> : IDisposable
		where TContract : IDisposable
	{
		private ICCFTransportServer _transportServer;

		/// <summary>
		/// Enable or disable session state on server.
		/// Default is true.
		/// Client controls if server session is used or not.
		/// </summary>
		public bool UseSessionState { get; set; } = true;

		public int SessionExpirationSeconds { get; set; } = 15 * 60; // 15 minutes

		public CalystoServiceHost(ICCFTransportServer transportServer)
		{
			_transportServer = transportServer;
			_transportServer.OnRequestDataReceived += this.ProcessRequestData;
			Task.Run(async () =>
			{
				await Task.Delay(5000);
				this.ClearExpiredSessions();
			});
		}

		~CalystoServiceHost()
		{
			Calysto.Diagnostics.CalystoLogger.Current.Diagnostic(this, () => $"CalystoServiceHost destructor");

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

		public bool IsDisposed { get; private set; }

		public void Dispose()
		{
			if (this.IsDisposed) return;
			this.IsDisposed = true;

			Calysto.Diagnostics.CalystoLogger.Current.Diagnostic(this, () => $"CalystoServiceHost disposing");

			_transportServer.Dispose();

			_sessions.UsingLock(a =>
			{
				var list = _sessions.Values.ToList();
				_sessions.Clear();
				Monitor.PulseAll(_sessions);
				return list;
			}).ForEach(o => o.Dispose());
		}

		class StateInfo
		{
			public TContract ContractInstance;
			public MethodInfo MethodInfo;
			public EventInfo EventInfo;
			public RequestInfo Request;
			public string RemoteAddress;
			public ResponseInfo Response;
			public Action<ResponseInfo> FnSendResponse;
			public SessionInfo Session;
			public TransportRequest TransportRequest;
		}

		private byte[] SerializeResponseInfo(ResponseInfo respInfo)
		{
			BinaryFrame frame1 = BinaryFrame.Serialize(respInfo);
			byte[] raw1 = frame1.ToBinaryData();
			return _crypto?.Encrypt(raw1) ?? raw1;
		}

		private void ProcessRequestData(TransportRequest transReq)
		{
			StateInfo state = new StateInfo()
			{
				TransportRequest = transReq,
				Response = new ResponseInfo(),
				RemoteAddress = transReq.RemoteAddress,
				FnSendResponse = new Action<ResponseInfo>((ResponseInfo respInfo) =>
				{
					try
					{
						transReq.FnSendResponse.Invoke(SerializeResponseInfo(respInfo));
					}
					catch(Exception ex1)
					{
						Calysto.Diagnostics.CalystoLogger.Current.Exception(this, () => ex1);
						try
						{
							respInfo.ReturnValue = null;
							respInfo.Error = new CalystoExceptionNode(ex1);
							transReq.FnSendResponse.Invoke(SerializeResponseInfo(respInfo));
						}
						catch (Exception ex2)
						{
							Calysto.Diagnostics.CalystoLogger.Current.Exception(this, () => ex2);
						}
					}
				})
			};

			try
			{
				byte[] decrypted = _crypto?.Decrypt(transReq.Data) ?? transReq.Data;
				state.Request = Calysto.Serialization.Json.BinaryFrame.Deserialize<RequestInfo>(decrypted);
				state.Response.RequestId = state.Request.RequestId;

				InvokeMethodWorker(state);
			}
			catch (Exception ex)
			{
				Calysto.Diagnostics.CalystoLogger.Current.Exception(this, () => ex);

				state.Response.Error = new CalystoExceptionNode(ex);
			}

			state.FnSendResponse.Invoke(state.Response);
			return;
		}

		class SessionInfo : IDisposable
		{
			public TContract ContractInstance { get; set; }
			public DateTime LastUsed { get; set; }
			public string SessionId { get; set; }
			public string RemoteAddress { get; set; }
			public List<KeyValuePair<string, Delegate>> EventSubscriptions { get; set; }
			public bool IsTcpSession { get; set; }

			~SessionInfo() => this.Dispose();
			public bool IsDisposed { get; private set; }

			public void Dispose()
			{
				if (this.IsDisposed) return;
				this.IsDisposed = true;

				try
				{
					this.ContractInstance?.Dispose();
				}
				catch { }
			}
		}

		Dictionary<string, SessionInfo> _sessions = new Dictionary<string, SessionInfo>();

		private async void ClearExpiredSessions()
		{
			while (!this.IsDisposed)
			{
				lock (_sessions)
				{
					DateTime dt1 = DateTime.Now.AddSeconds(-1 * this.SessionExpirationSeconds);
					_sessions.Where(o => !o.Value.IsTcpSession && o.Value.LastUsed < dt1).ToList().ForEach(o => _sessions.Remove(o.Key));
				}

				await Task.Delay(5000);
			}
		}

		private void InvokeMethodWorker(StateInfo state)
		{
			if (this.IsDisposed) return;

			if (state.Request.Action == ActionEnum.InvokeOnce)
			{
				state.MethodInfo = typeof(TContract).GetMethod(state.Request.MethodName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
			}
			else if (state.Request.Action == ActionEnum.SubscribeEvent || state.Request.Action == ActionEnum.UnsubscribeEvent)
			{
				if (this.UseSessionState && _transportServer is ICCFTransportServer)
				{
					state.EventInfo = typeof(TContract).GetEvent(state.Request.MethodName, BindingFlags.Public | BindingFlags.Instance);
				}
				else
				{
					throw new Exception("Event subscription requires TcpTransport and UseSessionState=true");
				}
			}
			else
			{
				throw new InvalidOperationException();
			}

			SessionInfo session = default;

			if(state.MethodInfo != null && state.MethodInfo.IsStatic)
			{
				// instance is not required
			}
			else if(this.UseSessionState && state.Request.UseSession)
			{
				// serarch instance in sessions cache
				lock (_sessions)
				{
					if (state.Request.SessionId == null)
					{
						// create new session
						session = new SessionInfo()
						{
							RemoteAddress = state.RemoteAddress,
							SessionId = Calysto.Utility.CalystoGenerators.GenerateStrongPassword(50),
							ContractInstance = Activator.CreateInstance<TContract>(),
							LastUsed = DateTime.Now,
							IsTcpSession = state.TransportRequest.TcpNode != null, // tcp session vezemo uz socket, ako se socket disposa, i session se disposa
							EventSubscriptions = new List<KeyValuePair<string, Delegate>>()
						};

						_sessions.Add(session.SessionId, session);

						if (state.TransportRequest.TcpNode != null)
						{
							state.TransportRequest.TcpNode.OnDisposed += (Transport.Tcp.TcpServerClient obj) =>
							{
								Calysto.Diagnostics.CalystoLogger.Current.Info(obj, () => "Socket disposed.");

								// if socket connection is lost, should we dispose the session too, or allow reconnect to the same session by sessionid?

								////lock (_sessions)
								////	_sessions.Remove(session.SessionId);

								////session.Dispose();
							};
						}
					}
					else if (_sessions.TryGetValue(state.Request.SessionId, out session))
					{
						// we have sesion
					}
					else
					{
						// session not found, or expired, throw exception
						throw new Exception("Session expired.");
					}
				}
				state.ContractInstance = session.ContractInstance;
				state.Response.SessionId = session.SessionId;
			}
			else
			{
				state.ContractInstance = Activator.CreateInstance<TContract>();
			}

			state.Session = session;

			if (state.Session?.IsDisposed == true)
				return;

			if (state.Session != null)
				state.Session.LastUsed = DateTime.Now;

			if (this.UseSessionState && state.Request.UseSession)
			{
				// allow single request access to session state instance
				lock(state.ContractInstance)
				{
					InvokeActionWorker(state);
				}
			}
			else
			{
				InvokeActionWorker(state);
			}
		}

		private void InvokeActionWorker(StateInfo state)
		{
			if (state.MethodInfo != null)
			{
				object[] final1 = state.MethodInfo.GetParameters().Select((par, index) =>
				{
					// convert every arg into correct type
					return Calysto.Serialization.Json.JsonSerializer.ConvertToType(state.Request.Arguments[index], par.ParameterType);
				}).ToArray();

				state.Response.ReturnValue = state.MethodInfo.Invoke(state.ContractInstance, final1);
			}
			else if (state.EventInfo != null)
			{
				if (state.Request.Action == ActionEnum.UnsubscribeEvent)
				{
					var forRemoval = state.Session.EventSubscriptions.Where(o => o.Key == state.Request.MethodName).ToList();

					forRemoval.ForEach(kv => state.EventInfo.RemoveEventHandler(state.ContractInstance, kv.Value));

					state.Session.EventSubscriptions = state.Session.EventSubscriptions.Where(o => !forRemoval.Contains(o)).ToList();

				}
				else if (state.Request.Action == ActionEnum.SubscribeEvent)
				{
					int len1 = state.EventInfo.EventHandlerType.GenericTypeArguments.Length;

					ActionsProvider provider1 = new ActionsProvider(state);

					MethodInfo mi1 = provider1.GetType().GetMethod("HostHandler" + len1, BindingFlags.Instance | BindingFlags.NonPublic);
					MethodInfo mi2 = mi1;

					if (len1 > 0)
						mi2 = mi1.MakeGenericMethod(state.EventInfo.EventHandlerType.GenericTypeArguments);

					Delegate delegate1 = Delegate.CreateDelegate(state.EventInfo.EventHandlerType, provider1, mi2);
					state.EventInfo.AddEventHandler(state.ContractInstance, delegate1);

					state.Session.EventSubscriptions.Add(new KeyValuePair<string, Delegate>(state.Request.MethodName, delegate1));
				}
				else
				{
					throw new InvalidOperationException("Action: " + state.Request.Action);
				}
			}
			else
			{
				throw new InvalidOperationException("No MethodInfo and no EventInfo.");
			}
		}

		class ActionsProvider
		{
			StateInfo _state;
			public ActionsProvider(StateInfo state)
			{
				_state = state;
			}

			private void SendEventResponse(object[] args)
			{
				if (_state.Session == null || _state.Session?.IsDisposed == true)
					return;

				_state.Session.LastUsed = DateTime.Now;

				ResponseInfo response = new ResponseInfo()
				{
					RequestId = _state.Request.RequestId,
					ReturnValue = args,
					MethodName = _state.Request.MethodName,
					Action = ActionEnum.EventTriggered
				};
				_state.FnSendResponse.Invoke(response);
			}

			private void HostHandler0() => this.SendEventResponse(null);
			private void HostHandler1<T1>(T1 a) => this.SendEventResponse(new object[] { a });
			private void HostHandler2<T1, T2>(T1 a, T2 b) => this.SendEventResponse(new object[] { a, b });
			private void HostHandler3<T1, T2, T3>(T1 a, T2 b, T3 c) => this.SendEventResponse(new object[] { a, b, c });
			private void HostHandler4<T1, T2, T3, T4>(T1 a, T2 b, T3 c, T4 d) => this.SendEventResponse(new object[] { a, b, c, d });
			private void HostHandler5<T1, T2, T3, T4, T5>(T1 a, T2 b, T3 c, T4 d, T5 e) => this.SendEventResponse(new object[] { a, b, c, d, e });
			private void HostHandler6<T1, T2, T3, T4, T5, T6>(T1 a, T2 b, T3 c, T4 d, T5 e, T6 f) => this.SendEventResponse(new object[] { a, b, c, d, e, f });
		}
	
	}
}
