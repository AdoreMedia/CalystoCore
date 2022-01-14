using Calysto.Diagnostics;
using Calysto.Net;
using Calysto.Net.Sockets.Messaging;
using Calysto.Timers;
using System;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Calysto.CCFServices.Transport.Tcp.TcpNode
{
	public abstract class TcpTransportSocketBase<TInstance> : SocketMessagingProvider<TInstance>
		where TInstance: TcpTransportSocketBase<TInstance>
	{
		public override void Dispose()
		{
			base.Dispose();
			try { this._echoTimeout?.Dispose(); } catch { }
			_echoTimeout = null;

			this.OnEchoResponseReceived = null;
			this.OnLog = null;
		}

		public event Action<LogEntry> OnLog;

		protected virtual int EchoTimeoutMs { get; set; } = 10 * 1000;

		protected override int ReceiveTimeoutMs { get; set; } = 10 * 1000;

		public Action<TInstance, byte[]> OnEchoResponseReceived;

		CalystoTimer _echoTimeout;

		public TcpTransportSocketBase(Socket socket = null) : base(socket)
		{
			CalystoLogger.Current.Info(this, () => "TcpTransportSocketBase ctor invoked");
		}

		public Action<TInstance, SocketMessage> OnNextMessageReceived;
		
		protected virtual void NotifyEchoResponseReceived(byte[] data)
		{
			this.OnEchoResponseReceived?.Invoke((TInstance)this, data);
		}

		protected override async Task NotifyReceiveTimeout()
		{
			// hostname ima samo remote client koji se spaja na server preko hostname-a i porta
			// server's client nema hostname postavljen
			if (!string.IsNullOrWhiteSpace(this.Statistics.Hostname) || !string.IsNullOrWhiteSpace(this.Statistics.DnsAddress))
			{
				// provjeriti da se nije dns promijenio za zadani Hostname na koji se socket spojio prije
				if (!CalystoDnsHelper.Current.ResolveAddresses(this.Statistics.Hostname).Where(o => o.Address.ToString() == this.Statistics.DnsAddress).Any())
				{
					// dns se promijenio
					this.Dispose();
					return;
				}
			}

			if (this.EchoTimeoutMs > 0)
			{
				if (this._echoTimeout == null)
					this._echoTimeout = new CalystoTimer(timer =>
					{
						CalystoLogger.Current.Diagnostic(this, ()=>"echoTimeout");
						this.Dispose();
					}); // dispose socket if echo is not received

				this._echoTimeout.Abort();

				this._echoTimeout.Start(this.EchoTimeoutMs);

				string str1 = "echo#" + Interlocked.Increment(ref _echoId);
				
				await this.SendMessageAsync(TcpTransportCommandEnum.EchoRequest, str1);
			}
		}

		int _echoId = 0;

		protected override async Task NotifyMessageReceived(SocketMessage message)
		{
			// message has to be complete
			// echo request is sent from both sides of tunne, from tunnel server client socket and tunnel local client socket
			// echo has priority over other messages

			TcpTransportCommandEnum command = (TcpTransportCommandEnum)message.Command;

			this.OnLog?.Invoke(new LogEntry(command, message.Data));

			//CalystoLogger.Current.Verbose(this, () => $"Received {command} {this.Socket?.LocalEndPoint} <- {this.Socket?.RemoteEndPoint} len {message.Data?.Length}: {CalystoLogger.BytesToStringLimitedLength(message.Data)}");

			if (command == TcpTransportCommandEnum.EchoRequest)
			{
				await this.SendMessageAsync(TcpTransportCommandEnum.EchoResponse, message.Data);
			}
			else if (command == TcpTransportCommandEnum.EchoResponse)
			{
				// ne smije se pozivati NotifyMessageReceived da ne poremeti OnNextMessage... ako je zadano
				this._echoTimeout?.Abort();
				this.NotifyEchoResponseReceived(message.Data);
			}
			else
			{
				byte[] decrypted = this.DecryptData(message.Data);
				SocketMessage decryptedMessage = new SocketMessage() { Command = message.Command, Data = decrypted };
				// all other commands
				var next = this.OnNextMessageReceived;
				this.OnNextMessageReceived = null;

				if (next != null)
					next.Invoke((TInstance)this, decryptedMessage);
				else
					await base.NotifyMessageReceived(decryptedMessage);
			}
		}

		public async Task SendMessageAsync(TcpTransportCommandEnum cmd, byte[] data = null)
		{
			//CalystoLogger.Current.Verbose(this, () => $"Sending {cmd} {this.Socket?.LocalEndPoint} -> {this.Socket?.RemoteEndPoint} len {data?.Length}: {CalystoLogger.BytesToStringLimitedLength(data)}");

			byte[] encrypted = this.EncryptData(data);
			this.OnLog?.Invoke(new LogEntry(cmd, encrypted));
			SocketMessage msg = new SocketMessage() { Command = (int)cmd, Data = encrypted };
			await base.SendMessageAsync(msg);
		}

		public async Task SendMessageAsync(TcpTransportCommandEnum cmd, string str)
		{
			await this.SendMessageAsync(cmd, Encoding.UTF8.GetBytes(str));
		}

		#region encryption / decryption

		Calysto.Security.Cryptography.AESCryptoHelper _crypto;

		public virtual byte[] DecryptData(byte[] encryptedData)
		{
			if (encryptedData == null || _crypto == null)
				return encryptedData;
			else
				return _crypto.Decrypt(encryptedData);
		}

		public virtual byte[] EncryptData(byte[] rawData)
		{
			if (rawData == null || _crypto == null)
				return rawData;
			else
				return _crypto.Encrypt(rawData);
		}

		public void UseEncryptionKey(string key1)
		{
			if (string.IsNullOrWhiteSpace(key1))
				throw new ArgumentNullException(nameof(key1));

			if (!string.IsNullOrWhiteSpace(key1))
				_crypto = new Calysto.Security.Cryptography.AESCryptoHelper(key1);
			else
				_crypto = null;
		}

		#endregion

	}
}
