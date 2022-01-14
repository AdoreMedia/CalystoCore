using System;
using System.Linq;
using System.Text;

namespace Calysto.Utility
{
	public class FileEncodingHelper
	{
		private static EncodingInfo[] _bomEncodings = Encoding.GetEncodings()
			.Where(o => o.GetEncoding().GetPreamble().Length > 0)
			.OrderByDescending(o=>o.GetEncoding().GetPreamble().Length)
			.ToArray();

		/// <summary>
		/// Detect encoding and remove BOM
		/// </summary>
		/// <param name="data"></param>
		/// <param name="encoding"></param>
		/// <returns></returns>
		private static byte[] RemovePreamble(byte[] data, out Encoding encoding)
		{
			foreach (var info in _bomEncodings)
			{
				encoding = info.GetEncoding();
				byte[] preamble = encoding.GetPreamble();

				if (preamble.Length > 0
					&& data.Length >= preamble.Length
					&& preamble.SequenceEqual(data.Take(preamble.Length)))
				{
					byte[] data1 = new byte[data.Length - preamble.Length];
					Array.Copy(data, preamble.Length, data1, 0, data1.Length);
					return data1;
				}
			}
			encoding = Encoding.ASCII;
			return data;
		}

		/// <summary>
		/// Resolve encoding, remove BOM and convert data to string.
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public static string DecodeToString(byte[] data)
		{
			data = RemovePreamble(data, out Encoding encoding);
			return encoding.GetString(data);
		}

		/// <summary>
		/// Encode to string, add BOM
		/// </summary>
		/// <param name="str"></param>
		/// <param name="encoding"></param>
		/// <returns></returns>
		public static byte[] EncodeToBytes(string str, Encoding encoding)
		{
			byte[] data = encoding.GetBytes(str);
			byte[] pre1 = encoding.GetPreamble();
			if (pre1.Length > 0)
			{
				byte[] res1 = new byte[pre1.Length + data.Length];
				Array.Copy(pre1, 0, res1, 0, pre1.Length);
				Array.Copy(data, 0, res1, pre1.Length, data.Length);
				return res1;
			}
			else
			{
				return data;
			}
		}

		/// <summary>
		/// Encode to string using UTF8, add BOM
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static byte[] EncodeToBytes(string str)
		{
			return EncodeToBytes(str, Encoding.UTF8);
		}
	}
}