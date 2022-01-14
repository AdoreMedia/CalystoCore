using Calysto.CCFServices.Transport.Tcp.TcpNode;
using Calysto.Common;
using Calysto.Threading;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Calysto.Net.Sockets.Messaging
{
	public abstract class SocketMessagingProvider<TInstance> : Calysto.Net.Sockets.ClientSocketBase<TInstance>
		where TInstance : SocketMessagingProvider<TInstance>
	{
		public SocketMessagingProvider(Socket socket) : base(socket)
		{
		}

		public override void Dispose()
		{
			try
			{
				base.Dispose();
				_msgReader?.Dispose();
			}
			catch { }

			this.OnMessageReceived = null;
		}

		public event Func<TInstance, SocketMessage, Task> OnMessageReceived;

		protected virtual Task NotifyMessageReceived(SocketMessage msg) => this.OnMessageReceived?.Invoke((TInstance)this, msg) ?? Task.CompletedTask;

		SocketMessagesReader _msgReader = new SocketMessagesReader();

		protected override async Task NotifyDataReceived(byte[] buffer)
		{
			_msgReader.AddData(buffer);
			
			//Trace.WriteLine($"NotifyDataReceived: {buffer.Length} bytes");

			await this.DecodeMessages(_msgReader);
		}

		protected virtual async Task DecodeMessages(SocketMessagesReader msgReader)
		{
			while (!this.IsDisposed && msgReader.HasCommand())
			{
				if (msgReader.TryReadCompleteMessage(out SocketMessage msg))
				{
					//Trace.WriteLine($"NotifyMessageReceived: {(TcpTransportCommandEnum)msg.Command}");

					await this.NotifyMessageReceived(msg);
				}
				else
				{
					return;
				}
			}
		}

		protected virtual async Task SendMessageAsync(SocketMessage message)
		{
			//Trace.WriteLine($"SendMessageAsync start: {(TcpTransportCommandEnum)message.Command}");
			// poslati sve zajedno
			await base.SendAsync(message.SerializeWithHeader());
			//Trace.WriteLine($"SendMessageAsync end: {(TcpTransportCommandEnum)message.Command}");
		}

	}
}
