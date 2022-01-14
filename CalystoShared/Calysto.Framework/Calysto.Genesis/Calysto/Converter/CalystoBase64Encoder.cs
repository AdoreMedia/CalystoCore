using System.Text;

namespace Calysto.Converter
{
	public class CalystoBase64Encoder
	{
		/// <summary>
		/// Base64 encoder
		/// </summary>
		public static CalystoBase64Encoder Base64RndEncoder = new CalystoBase64Encoder(Calysto.Converter.BaseXCharsTable.RandomRFCTable64);

		public static CalystoBase64Encoder JavaScriptRFCTable64Encoder = new CalystoBase64Encoder(Calysto.Converter.BaseXCharsTable.JavaScriptRFCTable64);

		public static CalystoBase64Encoder StandardBase64RFCEncoder = new CalystoBase64Encoder(Calysto.Converter.BaseXCharsTable.StandardBase64RFC);

		public static CalystoBase64Encoder Table36JavaScriptRFCEncoder = new CalystoBase64Encoder(Calysto.Converter.BaseXCharsTable.Table36JavaScriptRFC);


		private CalystoBaseConvert _converter;

		/// <summary>
		/// New instance using JavaScriptRFCTable64 table
		/// </summary>
		private CalystoBase64Encoder()
			: this(BaseXCharsTable.JavaScriptRFCTable64)
		{
		}

		private CalystoBase64Encoder(string charsTable)
		{
			_converter = new CalystoBaseConvert(charsTable);
		} 

		public string EncodeToBase64String(byte[] rawData)
		{
			return _converter.EncodeToBaseString(rawData, Calysto.Converter.CalystoBaseConvert.RadixEnum.Base64);
		}

		public string EncodeToBase64String(string rawString)
		{
			return this.EncodeToBase64String(Encoding.UTF8.GetBytes(rawString));
		}

		public byte[] DecodeBase64StringToArray(string baseEndodedString)
		{
			return _converter.DecodeBaseStringToArray(baseEndodedString, Calysto.Converter.CalystoBaseConvert.RadixEnum.Base64);
		}

		public string DecodeBase64StringToString(string baseEndodedString)
		{
			return _converter.DecodeBaseStringToString(baseEndodedString, Calysto.Converter.CalystoBaseConvert.RadixEnum.Base64);
		}


	}
}
