using Calysto.CCFServices.Transport.Tcp.TcpNode;
using Calysto.Net.Sockets.Messaging;
using System;
using System.Threading.Tasks;

namespace Calysto.CCFServices.Transport.Tcp
{
	public class TcpTransportClient : TcpTransport, ICCFTransportClient
	{
		public TcpTransportClient(string host, int port):base(host, port)
		{
		}

		#region tcp client side

		TcpLocalClient _tcpLocalNode;

		private async Task<TcpLocalClient> GetTcpNodeClientAsync()
		{
			if (_tcpLocalNode?.IsSocketConnected == true)
				return _tcpLocalNode;

			// kreirati novi socket i konektirati ga
			TcpLocalClient tcpLocalNode = new TcpLocalClient();

			tcpLocalNode.OnMessageReceived += TcpLocalNode_OnMessageReceived;
			tcpLocalNode.OnDisposed += TcpLocalNode_OnDisposed;

			await tcpLocalNode.ConnectAsync(this.Host, this.Port);
			await tcpLocalNode.BeginReceiveAsync();

			return (_tcpLocalNode = tcpLocalNode);
		}

		private async Task TcpLocalNode_OnMessageReceived(TcpLocalClient arg1, SocketMessage arg2)
		{
			this.OnDataReceived?.Invoke(arg2.Data);
			await Task.CompletedTask;
		}

		public event Action<TcpLocalClient> OnLocalTcpNodeDisposed;

		private void TcpLocalNode_OnDisposed(TcpLocalClient tcpNodeClient)
		{
			this.NotifyLog(() => $"node disconnected at local side");

			this.OnLocalTcpNodeDisposed?.Invoke(tcpNodeClient);
		}

		#endregion

		public event Action<ProgressEventArgs> OnProgress;
		public event Action<byte[]> OnDataReceived;

		public async Task SendRequestAsync(byte[] sendData)
		{
			TcpLocalClient tcpNode = await this.GetTcpNodeClientAsync();
			await tcpNode.SendMessageAsync(TcpTransportCommandEnum.Message, sendData);
		}

		public override void Dispose()
		{
			if (this.IsDisposed) return;
			base.Dispose();

			_tcpLocalNode?.Dispose();

			this.OnLocalTcpNodeDisposed = null;
			this.OnProgress = null;
		}
	}
}