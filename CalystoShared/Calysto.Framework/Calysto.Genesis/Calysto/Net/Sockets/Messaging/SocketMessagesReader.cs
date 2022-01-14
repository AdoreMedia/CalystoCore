using Calysto.Common;
using System;
using System.Collections.Generic;

namespace Calysto.Net.Sockets.Messaging
{
	public class SocketMessagesReader : IDisposable
	{
		private CalystoArrayBuffer<byte> _receiveBuffer = new CalystoArrayBuffer<byte>();

		public bool IsDiposed { get; private set; }
		public void Dispose()
		{
			if (this.IsDiposed) return;
			this.IsDiposed = true;
			_receiveBuffer?.Dispose();
			_receiveBuffer = null;
		}

		~SocketMessagesReader() => this.Dispose();

		public void AddData(byte[] data)
		{
			this._receiveBuffer.Add(data);
		}

		public void AddData(List<byte[]> data)
		{
			data.ForEach(arr => this.AddData(arr));
		}

		public int? CurrentCommand { get; private set; }

		private long WaitingForLength { get; set; }

		private void StartReadingNewMessage()
		{
			this.CurrentCommand = null;
			this.WaitingForLength = 0;
		}

		/// <summary>
		/// Try decode command and return true if successful. Throws exception if checksum is invalid.
		/// </summary>
		/// <returns></returns>
		private bool DecodeCommand()
		{
			if (this.CurrentCommand.HasValue)
				return true;

			long availableLen = this._receiveBuffer.Available;

			if (availableLen < 9) // header length is 9 bytes: 1 byte cmd + 4 bytes dataLength + 4 bytes checksum
				return false;

			int cmd = this._receiveBuffer.ReadByte();

			int dataLength = BitConverter.ToInt32(this._receiveBuffer.Read(4), 0);

			int checksum = BitConverter.ToInt32(this._receiveBuffer.Read(4), 0);

			availableLen -= 9;

			if (checksum != SocketMessage.CalculateChecksum(cmd, dataLength))
			{
				this.StartReadingNewMessage();
				throw new Exception("invalid frame header #3"); // exception will close socket
			}

			this.CurrentCommand = cmd;
			this.WaitingForLength = dataLength;

			return true;
		}

		public bool HasCommand() => this.DecodeCommand();

		public bool HasMoreData() => this.DecodeCommand() && this._receiveBuffer.Available > 0;

		/// <summary>
		/// Try read current message data.
		/// returns true: message is completed or allowPartialRead and has any data.
		/// </summary>
		/// <param name="allowPartialRead">If true, will return all available data, but no more than current message.</param>
		/// <param name="data"></param>
		/// <returns>
		/// </returns>
		private bool TryReadMessage(bool allowPartialRead, out SocketMessage msg)
		{
			if (!this.DecodeCommand())
			{
				msg = null;
				return false;
			}

			// message may contain command only with no data

			msg = new SocketMessage()
			{
				Command = this.CurrentCommand
			};

			if (this.WaitingForLength > 0)
			{
				long availableLen = this._receiveBuffer.Available;
				if (availableLen < 1)
					return false;

				bool hasCompleteMsg = availableLen >= this.WaitingForLength;
				if(!(hasCompleteMsg || allowPartialRead))
					return false;

				int readBytes = (int)Math.Min(this.WaitingForLength, availableLen);
				msg.Data = this._receiveBuffer.Read(readBytes);

				this.WaitingForLength -= readBytes;

				if(this.WaitingForLength == 0)
				{
					// message is complete
					this._receiveBuffer.TrimStart();
					this.StartReadingNewMessage();
					return true;
				}
				else if(this.WaitingForLength < 0)
				{
					throw new InvalidOperationException();
				}
				else
				{
					// not complete, return true only if allowPartialRead
					return allowPartialRead;
				}
			}
			else if(this.WaitingForLength == 0)
			{
				// message is complete
				this._receiveBuffer.TrimStart();
				this.StartReadingNewMessage();
				return true;
			}
			else
			{
				this.StartReadingNewMessage();
				throw new InvalidOperationException();
			}
		}

		/// <summary>
		/// Read only if message is complete, else return false.
		/// </summary>
		/// <param name="msg"></param>
		/// <returns></returns>
		public bool TryReadCompleteMessage(out SocketMessage msg) => TryReadMessage(false, out msg);

		/// <summary>
		/// Read available data, but not more than end of message.
		/// </summary>
		/// <param name="msg"></param>
		/// <returns></returns>
		public bool TryReadPartialMessage(out SocketMessage msg) => TryReadMessage(true, out msg);

	}
}
