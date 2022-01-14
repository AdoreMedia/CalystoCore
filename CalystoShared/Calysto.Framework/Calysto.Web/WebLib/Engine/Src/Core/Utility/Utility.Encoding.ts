namespace Calysto.Utility.Encoding
{
	/*
	// RFC JavaScript table 36 Calysto extended to 64
	// this data are create in FileCompiler.s to be 100% the same with C# data
	export var Base64CharsTable = {
		
		// 0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ_!~
		JavaScriptRFCTable64: "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ_!-", // acceptable for url: ~ ! - _ ( )
		
		// ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=
		StandardBase64RFC: "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=",
		
		RandomRFCTable64: ""
	};
	Base64CharsTable.RandomRFCTable64 = Base64CharsTable.JavaScriptRFCTable64;
	*/

	let Base64CharsTable = Calysto.Constants.BaseXCharsTable;

	export namespace Utf8CharsEncoder
	{
		/**
		 * Encode chars in string into utf chars string
		 * @param str
		 */
		export function EncodeUTF8(str: string)
		{
			/// <summary>
			/// Encode chars in string into utf chars string.
			/// </summary>
			/// <param name="string"></param>

			str = str.replace(new RegExp("\r\n", "g"), "\n");
			var utftext = "";

			for (var n = 0; n < str.length; n++)
			{

				var c = str.charCodeAt(n);

				if (c < 128)
				{
					utftext += String.fromCharCode(c);
				}
				else if ((c > 127) && (c < 2048))
				{
					utftext += String.fromCharCode((c >> 6) | 192);
					utftext += String.fromCharCode((c & 63) | 128);
				}
				else
				{
					utftext += String.fromCharCode((c >> 12) | 224);
					utftext += String.fromCharCode(((c >> 6) & 63) | 128);
					utftext += String.fromCharCode((c & 63) | 128);
				}

			}
			return utftext;
		}

		/**
		 * Decore utf chars string into string
		 * @param utftext
		 */
		export function DecodeUTF8(utftext: string)
		{
			/// <summary>
			/// Decore utf chars string into string.
			/// </summary>
			/// <param name="utftext"></param>

			var string = "";
			var i = 0, c = 0, c1 = 0, c2 = 0, c3 = 0;

			while (i < utftext.length)
			{
				c = utftext.charCodeAt(i);

				if (c < 128)
				{
					string += String.fromCharCode(c);
					i++;
				}
				else if ((c > 191) && (c < 224))
				{
					c2 = utftext.charCodeAt(i + 1);
					string += String.fromCharCode(((c & 31) << 6) | (c2 & 63));
					i += 2;
				}
				else
				{
					c2 = utftext.charCodeAt(i + 1);
					c3 = utftext.charCodeAt(i + 2);
					string += String.fromCharCode(((c & 15) << 12) | ((c2 & 63) << 6) | (c3 & 63));
					i += 3;
				}

			}

			return string;
		}
	}

	export namespace UTF8
	{
		export function GetBytes(str: string)
		{
			var input = Utf8CharsEncoder.EncodeUTF8(str);
			var arr: number[] = [];
			for (var n = 0; n < input.length; n++)
			{
				arr.push(input.charCodeAt(n));
			}
			return arr;
		};

		export function GetString(arr: number[] | Uint8Array)
		{
			var chars:string[] = [];
			for (var n = 0; n < arr.length; n++)
			{
				chars.push(String.fromCharCode(arr[n]));
			}
			return Utf8CharsEncoder.DecodeUTF8(chars.join(""));
		};
	}

	export class CalystoBaseConverter
	{
		constructor(private charsTable: string = Base64CharsTable.JavaScriptRFCTable64)
		{
		}

		private ConvertBytes(bytes: number[], fromBits: number, toBits: number)
		{
			var result: number[] = [];
			var buffer = 0;
			var buffLen = 0;
			var mask = (Math.pow(2, toBits) - 1);
			var doShift = false;
			for (var n = 0; n < bytes.length; n++)
			{
				var bb = bytes[n];
				// push into buffer
				if (doShift)
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
				while (buffLen >= toBits)
				{
					result.push(((buffer >> (buffLen - toBits)) & mask));
					buffLen -= toBits;
				}
			}

			while (buffLen >= toBits)
			{
				result.push(((buffer >> (buffLen - toBits)) & mask));
				buffLen -= toBits;
			}

			// used when converting to smaller amount of bits
			// when converting to greater amount of bits, then reminder bytes should be ignored
			while (buffLen > 0 && fromBits > toBits)
			{
				result.push(((buffer << (toBits - buffLen)) & mask));
				buffLen -= toBits;
			}

			return result;
		}

		private Convert(bytes: number[], fromBits: number, toBits: number)
		{
			if (!fromBits || (fromBits != 8 && (fromBits < 1 || fromBits > 6)))
			{
				throw Error(fromBits + " is invalid value. fromBits can be in range [1-6] or 8");
			}
			if (!toBits || (toBits != 8 && (toBits < 1 || toBits > 6)))
			{
				throw Error(toBits + " is invalid value. toBits can be in range [1-6] or 8");
			}

			var convertedEnumerable = this.ConvertBytes(bytes, fromBits, toBits);

			if (this.charsTable != Base64CharsTable.StandardBase64RFC)
			{
				return convertedEnumerable;
			}
			else
			{
				// standard base64 RFC uses padding at the end

				if (fromBits == 8 && toBits == 6)
				{
					// encoding
					if (bytes.length % 3 > 0)
					{
						// if using standard Base64 RFC table, use padding
						var pad = 3 - bytes.length % 3;
						var alignmentCharIndex = (this.charsTable.length - 1);
						while (pad > 0)
						{
							pad--;
							convertedEnumerable.push(alignmentCharIndex);
						}
					}
				}
				else if (fromBits == 6 && toBits == 8)
				{
					// decoding
					// count alignment chars
					var alignmentCharIndex = (this.charsTable.length - 1);
					var cnt = 0;
					var len = bytes.length;
					while (cnt < len && (bytes[len - 1 - cnt] == alignmentCharIndex))
					{
						cnt++;
					}

					var take = convertedEnumerable.length - cnt;

					convertedEnumerable = convertedEnumerable.slice(0, take);
				}
			}

			return convertedEnumerable;
		}

		public EncodeToBaseString(data: string | number[], toBits: number)
		{
			/// <summary>
			/// <para>Convert string or array of chars or 8-bits based items to base(toBits) string using.</para>
			/// <para>Use Calysto.Utility.UTF8.GetBytes() and Calysto.Utility.UTF8.GetString() to converto from or to arrayOrString</para>
			/// </summary>
			/// <param name="data">byte[] or string</param>
			/// <param name="toBits">1-6</param>
			/// <returns type="">baseString</returns>

			if (typeof (data) == "string")
			{
				// convert to array
				data = UTF8.GetBytes(data);
			}

			var arr = this.Convert(data, 8, toBits);
			var sb:string[] = [];
			for (var n = 0; n < arr.length; n++)
			{
				sb.push(this.charsTable.charAt(arr[n]));
			}
			return sb.join("");
		};

		public DecodeBaseStringToArray(baseString: string, fromBits: number)
		{
			/// <summary>
			/// <para>Convert base(fromBits) encoded string to aray of 8-bits based items using.</para>
			/// <para>Use Calysto.Utility.UTF8.GetBytes() and Calysto.Utility.UTF8.GetString() to converto from or to array</para>
			/// </summary>
			/// <param name="baseString">string</param>
			/// <param name="fromBits">1-6</param>
			/// <returns type="">byte[]</returns>

			var arr:number[] = [];
			for (var n = 0; n < baseString.length; n++)
			{
				arr.push(this.charsTable.indexOf(baseString.charAt(n)));
			}
			return this.Convert(arr, fromBits, 8);
		};

		public DecodeBaseStringToString(baseString: string, fromBits: number)
		{
			return UTF8.GetString(this.DecodeBaseStringToArray(baseString, fromBits));
		};
	}

	class CalystoHexConverter
	{
		private readonly converter = new CalystoBaseConverter(); // use JavaScriptRFCTable64

		public EncodeToHexString(data: string | number[])
		{
			return this.converter.EncodeToBaseString(data, 4);
		}

		public DecodeHexStringToArray(hexString: string)
		{
			/// <summary>
			/// Convert base(fromBits) encoded string to aray of 8-bits based items. Returns array of bytes.
			/// </summary>
			/// <param name="hexString"></param>

			return this.converter.DecodeBaseStringToArray(hexString, 4);
		}

		public DecodeHexStringToString(hexString)
		{
			/// <summary>
			/// Decode str from base64 using current chars table. Returns raw string.
			/// </summary>
			/// <param name="hexString">base64 encoded string</param>
			return this.converter.DecodeBaseStringToString(hexString, 4);
		}
	}

	export var HEX = new CalystoHexConverter();

	class CalystoBase64EncoderImpl
	{
		private converter: CalystoBaseConverter;

		constructor(charsTable: string)
		{
			this.converter = new CalystoBaseConverter(charsTable);
		}

		public EncodeToBase64String(data: string | number[])
		{
			/// <summary>
			/// Encode str to base64 using table or RFC base64 table. Returns base64 encoded string.
			/// </summary>
			/// <param name="rawStr" type="type"></param>
			return this.converter.EncodeToBaseString(data, 6);
		}

		public DecodeBase64StringToArray(base64str: string)
		{
			/// <summary>
			/// Decode str from base64 using current chars table. Returns raw string.
			/// </summary>
			/// <param name="str">base64 encoded string</param>
			return this.converter.DecodeBaseStringToArray(base64str, 6);
		}

		public DecodeBase64StringToString(base64str: string)
		{
			/// <summary>
			/// Decode str from base64 using current chars table. Returns raw string.
			/// </summary>
			/// <param name="str">base64 encoded string</param>
			return this.converter.DecodeBaseStringToString(base64str, 6);
		}
	}

	/** Standard base64 encoder*/
	export var RfcBase64 = new CalystoBase64EncoderImpl(Base64CharsTable.StandardBase64RFC);

	/** Calysto base64 encoder for urls */
	export var CalystoBase64 = new CalystoBase64EncoderImpl(Base64CharsTable.JavaScriptRFCTable64);

	export var Base64RndEncoder = new CalystoBase64EncoderImpl(Calysto.Core?.Constants?.RandomRFCTable64 || Base64CharsTable.StandardBase64RFC)
}

