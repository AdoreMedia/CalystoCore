using Brotli;
using System;
using System.IO;
using System.IO.Compression;

namespace Calysto.IO.Compression
{
	public abstract class CompressionHelper<T> where T:Stream
	{
		public static byte[] Compress(byte[] data)
		{
			using (MemoryStream msInput = new MemoryStream(data))
			using (MemoryStream msOutput = new MemoryStream())
			using (T comprStream = (T)Activator.CreateInstance(typeof(T), msOutput, CompressionMode.Compress))
			{
				////if (comprStream is BrotliStream)
				////{
				////	((BrotliStream)(object)comprStream).SetQuality(11);
				////	((BrotliStream)(object)comprStream).SetWindow(22);
				////}

				msInput.CopyTo(comprStream);
				comprStream.Close();
				return msOutput.ToArray();
			}
		}

		public static byte[] Decompress(byte[] data)
		{
			using (MemoryStream msInput = new MemoryStream(data))
			using (T comprStream = (T)Activator.CreateInstance(typeof(T), msInput, CompressionMode.Decompress))
			using (MemoryStream msOutput = new MemoryStream())
			{
				comprStream.CopyTo(msOutput);
				msOutput.Position = 0;
				return msOutput.ToArray();
			}
		}

	}

	public class DeflateHelper : CompressionHelper<DeflateStream>
	{

	}

	public class GZipHelper : CompressionHelper<GZipStream>
	{

	}

	public class BrotliHelper : CompressionHelper<BrotliStream>
	{

	}

}
