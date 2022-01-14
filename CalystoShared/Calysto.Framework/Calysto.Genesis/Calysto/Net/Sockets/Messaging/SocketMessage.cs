using System;
using System.Collections.Generic;
using System.Text;

namespace Calysto.Net.Sockets.Messaging
{
	public class SocketMessage
	{
		const int NO_COMMAND = 255;

		public int? Command;
		public byte[] Data;

		public string Text
		{
			get => this.Data == null ? null : Encoding.UTF8.GetString(this.Data);
			set => this.Data = value == null ? null : Encoding.UTF8.GetBytes(value);
		}

		public IEnumerable<byte[]> SerializeWithHeader()
		{
			foreach (var item in CreateCompleteMessage(this.Command ?? NO_COMMAND, this.Data))
				yield return item;
		}

		public static int CalculateChecksum(int cmd, int dataLength)
		{
			return (cmd + dataLength) ^ 189273165;
		}

		/// <summary>
		/// Create blocks cmd:length:checksum:data
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="data"></param>
		/// <returns></returns>
		private IEnumerable<byte[]> CreateCompleteMessage(int cmd, byte[] data)
		{
			yield return new byte[] { (byte)cmd }; // 1 byte

			int dataLength = data?.Length ?? 0;
			yield return BitConverter.GetBytes(dataLength); // 4 bytes

			yield return BitConverter.GetBytes(CalculateChecksum((byte)cmd, dataLength)); // 4 bytes;

			if (dataLength > 0)
				yield return data;
		}
	}

}
