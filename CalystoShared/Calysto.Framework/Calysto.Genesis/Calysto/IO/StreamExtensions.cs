using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Calysto.IO
{
	public static class StreamExtensions
	{
		public static MemoryStream ToMemoryStream(this Stream stream)
		{
			MemoryStream ms = new MemoryStream();
			
			if (stream.CanSeek && stream.Position != 0)
			{
				stream.Position = 0;
			}

			stream.CopyTo(ms);
			return ms;
		}

		/// <summary>
		/// Read chunks starting from current stream.Position. Last chunk may be shorted than chunkSize.
		/// </summary>
		/// <param name="stream"></param>
		/// <param name="chunkSize"></param>
		/// <returns></returns>
		public static IEnumerable<byte[]> SplitToParts(this Stream stream, int chunkSize)
		{
			BinaryReader reader = new BinaryReader(stream);
			byte[] data1 = null;
			while ((data1 = reader.ReadBytes(chunkSize)).Length > 0)
				yield return data1;
		}

		/// <summary>
		/// Read chunks starting from current stream.Position in each source stream.
		/// Concatenate chunks from each stream to create all chunks length equal to chunkSize.
		/// Last chunk may be shorted than chunkSize.
		/// </summary>
		/// <param name="source"></param>
		/// <param name="chunkSize"></param>
		/// <returns></returns>
		public static IEnumerable<byte[]> SplitToParts(this IEnumerable<Stream> source, int chunkSize)
		{
			int pos1 = 0;
			byte[] data1 = null;

			foreach (Stream input1 in source)
			{
				int left1 = chunkSize - pos1;
				BinaryReader reader1 = new BinaryReader(input1);
				byte[] data2 = null;
				while((data2 = reader1.ReadBytes(Math.Min(chunkSize - pos1, chunkSize))).Length > 0)
				{
					if (data1 == null && data2.Length == chunkSize)
					{
						yield return data2;
					}
					else
					{
						if (data1 == null)
							data1 = new byte[chunkSize];

						Array.Copy(data2, 0, data1, pos1, data2.Length);
						pos1 += data2.Length;
						if(chunkSize == pos1)
						{
							yield return data1;
							pos1 = 0;
							data1 = null;
						}
					}
				}
			}

			if (pos1 > 0)
			{
				byte[] data2 = new byte[pos1];
				Array.Copy(data1, 0, data2, 0, pos1);
				yield return data2;
			}
		}

	}
}
