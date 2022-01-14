using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calysto.Net.Sockets.Messaging
{
	public class SocketMessageFactory
	{
		/// <summary>
		/// Concatenate data and split into chunks.
		/// </summary>
		/// <param name="chunkSize"></param>
		/// <param name="dataEnumerable"></param>
		/// <returns></returns>
		public static IEnumerable<byte[]> SplitDataToChunks(int chunkSize, IEnumerable<byte[]> dataEnumerable)
		{
			Calysto.Common.CalystoArrayBuffer<byte> buffer = new Common.CalystoArrayBuffer<byte>();
			foreach (var d1 in dataEnumerable)
				buffer.Add(d1);

			byte[] chunk;

			while ((chunk = buffer.Read(chunkSize)).Length > 0)
				yield return chunk;
		}

	}
}
