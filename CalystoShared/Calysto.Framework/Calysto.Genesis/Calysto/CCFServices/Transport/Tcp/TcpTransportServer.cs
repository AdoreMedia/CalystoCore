using Calysto.CCFServices.Transport.Tcp.TcpNode;
using Calysto.Common.Extensions;
using Calysto.Net.Sockets.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Calysto.CCFServices.Transport.Tcp
{
	public class TcpTransportServer : TcpTransport, ICCFTransportServer
	{
		public event Action<TransportRequest> OnRequestDataReceived;

		public TcpTransportServer(string host, int port) : base(host, port)
		{
		}

		#region tcp server side

		HashSet<TcpServerClient> _serverClients = new HashSet<TcpServerClient>();

		private TcpServer _server;

		private void CreateNewNodeServer()
		{
			if (!this.IsDisposed)
			{
				_server = new TcpServer();
				_server.OnClientConnected += Server_OnClientConnected;
				_server.StartListening(this.Port);
			}
		}

		////private async Task Server_OnShouldDisconnect(TcpServer obj)
		////{
		////	Thread.Sleep(200); // da se ne zaloopa
		////	obj.Dispose();
		////	this.CreateNewNodeServer();
		////	await Task.CompletedTask;
		////}

		private async Task Server_OnClientConnected(TcpServer arg1, Socket arg2)
		{
			TcpServerClient tcpServerNode = new TcpServerClient(arg2);

			this.NotifyLog(() => $"server received client {arg2.RemoteEndPoint} -> {arg2.LocalEndPoint}");

			lock (_serverClients)
				_serverClients.Add(tcpServerNode);

			tcpServerNode.OnDisposed += TcpServerNode_OnDisposed;
			tcpServerNode.OnMessageReceived += TcpServerNode_OnMessageReceived;

			await tcpServerNode.BeginReceiveAsync();
		}

		private async Task TcpServerNode_OnMessageReceived(TcpServerClient arg1, SocketMessage arg2)
		{
			await Task.CompletedTask;
			// koristimo uvijek isti socket, pa bi RemoteEP trebao biti, isti, ali nek uzima samo adresu
			try
			{
				this.OnRequestDataReceived?.Invoke(new TransportRequest()
				{
					TcpNode = arg1,
					Data = arg2.Data,
					RemoteAddress = (arg1.Socket?.RemoteEndPoint as IPEndPoint)?.Address + "",
					FnSendResponse = async (byte[] responseData) =>
					{
						await arg1.SendMessageAsync(TcpTransportCommandEnum.Message, responseData);
					}
				});
			}
			catch (Exception ex1)
			{
				Calysto.Diagnostics.CalystoLogger.Current.Exception(this, () => ex1);
			}
		}

		private void TcpServerNode_OnDisposed(TcpServerClient obj)
		{
			lock (_serverClients)
				_serverClients.Remove(obj);
		}

		public void StartListening()
		{
			this.CreateNewNodeServer();
		}

		public void StopListening()
		{
			this.Dispose();
		}

		#endregion

		public override void Dispose()
		{
			if (this.IsDisposed) return;
			base.Dispose();

			_server?.Dispose();

			_serverClients.UsingLock(a =>
			{
				var list = _serverClients.ToList();
				_serverClients.Clear();
				return list;
			}).ForEach(o => o.Dispose());

			this.OnRequestDataReceived = null;
		}

	}
}