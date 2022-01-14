using Calysto.Common;
using Calysto.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace Calysto.Net.Sockets
{
	public class ClientStatistics : IDisposable
	{
		~ClientStatistics() => this.Dispose();
		public void Dispose()
		{
			_socket = null;
		}

		public enum StatusEnum
		{
			Uninitialized,
			Connecting,
			Connected,
			Disposing,
			Disposed,
			WaitingHeaders,
			Authenticating,
			InvalidAuthentication,
			Authenticated,
			Ready,
		}

		Socket _socket;

		public ClientStatistics() { }

		/// <summary>
		/// Socket may be null. It will be instantinated later.
		/// </summary>
		/// <param name="socket"></param>
		public ClientStatistics(ref Socket socket)
		{
			_socket = socket;
		}

		public StatusEnum Status { get; private set; }
		public DateTime? StatusChangedDate { get; private set; }

		private readonly List<string> _notes = new List<string>();

		public string Notes { get { lock (_notes) return string.Join("\r\n", _notes); } }

		const int _maxNoteItems = 30;

		public void AddNote(Func<string> fnGetText)
		{
			lock (_notes)
			{
				if (_notes.Count > (_maxNoteItems + 1))
					return;
				else if (_notes.Count > _maxNoteItems)
					_notes.Add("....[has more items]...");
				else
					_notes.Add(fnGetText?.Invoke()?.TakeFirst(200, "...")?.Trim());
			}
		}

		readonly List<string> _conversation = new List<string>();

		public void AddConversationLine(Func<string> fnGetText)
		{
			lock(_conversation)
			{
				if (_conversation.Count > 30)
					return;
				else
					_conversation.Add(fnGetText?.Invoke()?.TakeFirst(100)?.Trim());
			}
		}

		public List<string> GetConversationLines()
		{
			lock (_conversation)
				return _conversation.ToList();
		}

		public void ClearConversionLines()
		{
			lock (_conversation)
				_conversation.Clear();
		}

		public DateTime? ConnectedDate { get; private set; }
		public DateTime? LastReceivedDate { get; private set; }
		public DateTime? LastSentDate { get; private set; }
		public long ReceivedBytes { get; private set; }
		public long SentBytes { get; private set; }

		public long RemoteAddr { get; private set; }
		public string RemoteIP { get; private set; }
		public int PublicPort { get; private set; }

		public string Hostname { get; set; }
		public string DnsAddress { get; set; }

		public void SetStatus(StatusEnum status)
		{
			this.AddNote(() => status.ToString());
			this.Status = status;
			this.StatusChangedDate = DateTime.Now;
		}

		public void MarkConnected()
		{
			if (_socket?.Connected == true)
			{
				this.ConnectedDate = DateTime.Now;
				////this.SetStatus(StatusEnum.Connected);

				this.ParseRemoteAddress();
			}
		}

		public void MarkReceived(int len)
		{
			if (len > 0)
			{
				this.LastReceivedDate = DateTime.Now;
				this.ReceivedBytes += len;
			}
		}

		public void MarkSent(int len)
		{
			if(len > 0)
			{
				this.LastSentDate = DateTime.Now;
				this.SentBytes += len;
			}
		}

		private void ParseRemoteAddress()
		{
			if (_socket?.Connected != true)
				return;

			// V6 endpoint: "[::ffff:127.0.0.1]:7255"

			if (CalystoNetTools.TryExtractIpV4AndPort(_socket?.RemoteEndPoint, out string remoteIP, out int remotePort, out long remoteAddress)
				&& CalystoNetTools.TryExtractIpV4AndPort(_socket?.LocalEndPoint, out string localIP, out int localPort, out long localAddress))
			{
				this.RemoteAddr = remoteAddress;
				this.RemoteIP = remoteIP;
				this.PublicPort = localPort;
			}
		}

	}
}
