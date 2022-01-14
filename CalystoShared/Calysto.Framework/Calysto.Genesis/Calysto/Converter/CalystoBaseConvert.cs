using Calysto.Genesis.EnvDTE;
using Calysto.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Calysto.Converter
{
	public class BaseXCharsTable
	{
		/// <summary>
		/// RFC base64 standard table
		/// </summary>
		public const string StandardBase64RFC = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/="; // RFC standard table

		/// <summary>
		/// RFC JavaScript table 36 Calysto extended to 64 by Calysto to work in URLs
		/// </summary>
		public const string JavaScriptRFCTable64 = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ_!-"; // acceptable for url: ~ ! - _ ( ) ;

		/// <summary>
		/// RFC JavaScript table 36, up to radix 36, extracted from Chrome and Firefox, used with number.toString(radix) or parseInt(num, radix)
		/// </summary>
		public const string Table36JavaScriptRFC = "0123456789abcdefghijklmnopqrstuvwxyz";

		public static readonly string RandomRFCTable64 = CreateRandomTable(false);

		private static string CreateRandomTable(bool useRandom)
		{
			if (useRandom)
			{
				Assembly asm = Assembly.GetExecutingAssembly();
				// .net Core ModuleVersionId is changed when content of dll is changed, will not change on recompile if there was no change in content
				Guid guid = asm.ManifestModule.ModuleVersionId;
				byte[] bytes = guid.ToByteArray();

				var en1 = JavaScriptRFCTable64.Select((ch, n) => new
				{
					ch,
					position = bytes[n % bytes.Length]
				}).OrderBy(o => o.position).Select(o => o.ch);

				return string.Join(null, en1);
			}
			else
			{
				// we can not use random table since we're using Blazor HttpClient which can not be reloaded every time when assembly is recompiled
				return JavaScriptRFCTable64;
			}
		}
	}

	public class CalystoBaseConvert
	{
		public enum RadixEnum
		{
			/// <summary>
			/// Radix 2, binary
			/// </summary>
			Base2 = 1,
			/// <summary>
			/// Radix 2, binary
			/// </summary>
			Binary = 1,
			/// <summary>
			/// Radix 4
			/// </summary>
			Base4 = 2,
			/// <summary>
			/// Radix 8, octal
			/// </summary>
			Base8 = 3,
			/// <summary>
			/// Radix 8, octal
			/// </summary>
			Octal = 3,
			/// <summary>
			/// Radix 16, hex
			/// </summary>
			Base16 = 4,
			/// <summary>
			/// Radix 16, hex
			/// </summary>
			Hex = 4,
			/// <summary>
			/// Radix 32
			/// </summary>
			Base32 = 5,
			/// <summary>
			/// Radix 64
			/// </summary>
			Base64 = 6,
		}

		#region helper methods

		private IEnumerable<bool> GetBitsEnumerable(IEnumerable<byte> data, int fromBits)
		{
			int bytesCount = 0;

			foreach (byte bb in data)
			{
				bytesCount++;

				for (int n = fromBits - 1; n >= 0; n--)
				{
					yield return (bb & (((byte)1) << n)) > 0;
				}
			}
		}

		/// <summary>
		/// Bits converter using bits enumerator
		/// </summary>
		/// <param name="bytes"></param>
		/// <param name="fromBits"></param>
		/// <param name="toBits"></param>
		/// <returns></returns>
		private IEnumerable<byte> ConvertBytes2(IEnumerable<byte> bytes, int fromBits, int toBits)
		{
			IEnumerable<bool> bitsEnumerable = GetBitsEnumerable(bytes, fromBits);

			byte bb = 0;
			int bitsCount = 0;
			
			foreach (bool b in bitsEnumerable)
			{
				// take bits, reverse them, create byte from bits
				bitsCount++;
				
				bb = (byte)(bb | ((b ? 1 : 0) << (toBits - bitsCount)));

				if (bitsCount == toBits)
				{
					yield return bb;
					bitsCount = 0;
					bb = 0;
				}
			}

			// if conferting to greater number of bits, then the rest of bits should be ignored
			if (bitsCount > 0 && fromBits > toBits)
			{
				// if bits == 8, ignore the rest because it was creted in previous pading to complete number
				// e.g. when reducing from 8 to 6 bits, last byte has to be filled up to 6 bits
				// when converting from 6 to 8 bits, ignore bits for padding to 6
				yield return bb;
			}
		}

		/// <summary>
		/// Bits converter using bits shifting
		/// </summary>
		/// <param name="bytes"></param>
		/// <param name="fromBits"></param>
		/// <param name="toBits"></param>
		/// <returns></returns>
		private IEnumerable<byte> ConvertBytes(IEnumerable<byte> bytes, int fromBits, int toBits)
		{
			int buffer = 0;
			int buffLen = 0;
			byte mask = (byte)(Math.Pow(2, toBits) - 1);
			bool doShift = false;
			foreach (byte bb in bytes)
			{
				// push into buffer
				if(doShift)
				{
					buffer = buffer << fromBits;
				}
				else
				{
					doShift = true;
				}
				buffer = buffer | bb;
				buffLen += fromBits;
				
				// pop from buffer
				while(buffLen >= toBits)
				{
					yield return (byte)((buffer >> (buffLen - toBits)) & mask);
					buffLen -= toBits;
				}
			}

			while (buffLen >= toBits)
			{
				yield return (byte)((buffer >> (buffLen - toBits)) & mask);
				buffLen -= toBits;
			}

			// used when converting to smaller amount of bits
			// if converting to greater number of bits, the rest of bits should be ignored
			while (buffLen > 0 && fromBits > toBits)
			{
				yield return (byte)((buffer << (toBits - buffLen)) & mask);
				buffLen -= toBits;
			}
		}

		#endregion

		public string CharsTable { get; set; }

		public CalystoBaseConvert(string charsTable = BaseXCharsTable.JavaScriptRFCTable64)
		{
			this.CharsTable = charsTable;
		}

		private IEnumerable<byte> Convert(byte[] data, int fromBits, int toBits)
		{
			if (fromBits != 8 && (fromBits < 1 || fromBits > 6))
			{
				throw new ArgumentOutOfRangeException(fromBits + " is invalid value. fromBits can be in range [1-6] or 8");
			}
			if (toBits != 8 && (toBits < 1 || toBits > 6))
			{
				throw new ArgumentOutOfRangeException(toBits + " is invalid value. toBits can be in range [1-6] or 8");
			}

			var convertedEnumerable = ConvertBytes(data, fromBits, toBits);
			
			// custom Calysto table doesn't have alignment
			if(this.CharsTable != BaseXCharsTable.StandardBase64RFC)
			{
				return convertedEnumerable;
			}
			else
			{ 
				// standard base64 RFC uses padding at the end
				if (fromBits == 8 && toBits == 6)
				{
					// encoding

					if (data.Length % 3 > 0)
					{
						// if using Base64 RFC table, use padding
						int pad = 3 - data.Length % 3;
						byte alignmentCharIndex = (byte)(this.CharsTable.Length - 1);
						while (pad > 0)
						{
							pad--;
							convertedEnumerable = convertedEnumerable.Concat(new byte[] { alignmentCharIndex });
						}
					}
				}
				else if(fromBits == 6 && toBits == 8)
				{
					// decoding
					// count alignment chars
					byte alignmentCharIndex = (byte)(this.CharsTable.Length - 1);
					int cnt = 0;
					int len = data.Length;
					while(cnt < len && (data[len - 1 - cnt] == alignmentCharIndex))
					{
						cnt++;
					}

					int take = convertedEnumerable.Count() - cnt;

					convertedEnumerable = convertedEnumerable.Take(take);
				}

				return convertedEnumerable;
			}
		}

		public string EncodeToBaseString(byte[] data, RadixEnum toRadix)
		{
			StringBuilder sb = new StringBuilder();
			foreach (char ch in Convert(data, 8, (int)toRadix).Select(o => this.CharsTable[o]))
			{
				sb.Append(ch);
			}
			return sb.ToString();
		}

		public string EncodeToBaseString(string rawString, RadixEnum toRadix)
		{
			return EncodeToBaseString(Encoding.UTF8.GetBytes(rawString), toRadix);
		}

		public byte[] DecodeBaseStringToArray(string baseString, RadixEnum fromRadix)
		{
			byte[] bytes = baseString.Select(o => (byte)this.CharsTable.IndexOf(o)).ToArray();
			return Convert(bytes, (int)fromRadix, 8).ToArray();
		}

		public string DecodeBaseStringToString(string baseString, RadixEnum fromRadix)
		{
			byte[] data = DecodeBaseStringToArray(baseString, fromRadix);
			return Encoding.UTF8.GetString(data, 0, data.Length);
		}

		public string EncodeToHexString(byte[] data)
		{
			return EncodeToBaseString(data, RadixEnum.Hex);
		}

		public byte[] DecodeHexStringToArray(string hexString)
		{
			return DecodeBaseStringToArray(hexString, RadixEnum.Hex);
		}

	}

}
