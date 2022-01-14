#if !SILVERLIGHT

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Calysto.IO.Tests
{
	[TestClass()]
	public class GZipTest
	{
		private const int buffer_size = 100;

		private static int ReadAllBytesFromStream(Stream stream, byte[] buffer)
		{
			// Use this method is used to read all bytes from a stream.
			int offset = 0;
			int totalCount = 0;
			while (true)
			{
				int bytesRead = stream.Read(buffer, offset, buffer_size);
				if (bytesRead == 0)
				{
					break;
				}
				offset += bytesRead;
				totalCount += bytesRead;
			}
			return totalCount;
		}

		private static bool CompareData(byte[] buf1, int len1, byte[] buf2, int len2)
		{
			// Use this method to compare data from two different buffers.
			if (len1 != len2)
			{
				Console.WriteLine("Number of bytes in two buffer are different {0}:{1}", len1, len2);
				return false;
			}

			for (int i = 0; i < len1; i++)
			{
				if (buf1[i] != buf2[i])
				{
					Console.WriteLine("byte {0} is different {1}|{2}", i, buf1[i], buf2[i]);
					return false;
				}
			}
			Console.WriteLine("All bytes compare.");
			return true;
		}

		[TestMethod]
		public void GZipCompressDecompress()
		{
			string str1 = "sto se to desava ovdje";
			Trace.WriteLine("input: " + str1 + ", length: " + str1.Length);

			byte[] buffer = Encoding.UTF8.GetBytes(str1);

			MemoryStream ms = new MemoryStream();
			// Use the newly created memory stream for the compressed data.
			GZipStream compressedzipStream = new GZipStream(ms, CompressionMode.Compress, true);

			compressedzipStream.Write(buffer, 0, buffer.Length);
			// Close the stream.
			compressedzipStream.Close();

			Trace.WriteLine(string.Format("Original size: {0}, Compressed size: {1}", buffer.Length, ms.Length));

			// Reset the memory stream position to begin decompression.
			ms.Position = 0;

			byte[] ccomp = new byte[ms.Length];

			ms.Read(ccomp, 0, (int)ms.Length);
			ms.Position = 0;

			GZipStream zipStream = new GZipStream(ms, CompressionMode.Decompress);

			byte[] decompressedBuffer = new byte[buffer.Length + 100];

			// Use the ReadAllBytesFromStream to read the stream.

			int totalCount = GZipTest.ReadAllBytesFromStream(zipStream, decompressedBuffer);


			if (!GZipTest.CompareData(buffer, buffer.Length, decompressedBuffer, totalCount))
			{
				Assert.Fail("Error. The two buffers did not compare.");
			}
			else
			{
				Trace.WriteLine("input string and decompressed string are equal");
			}

			zipStream.Close();

		}
	}
}

#endif

