namespace Calysto.Converter
{
	public class CalystoHexEncoder
	{
		private CalystoBaseConvert _converter;

		/// <summary>
		/// New instance using JavaScriptRFCTable64 table
		/// </summary>
		public CalystoHexEncoder()
		{
			_converter = new CalystoBaseConvert();
		}

		public string EncodeToHexString(byte[] rawData)
		{
			return _converter.EncodeToBaseString(rawData, Calysto.Converter.CalystoBaseConvert.RadixEnum.Base4);
		}

		public string EncodeToHexString(string rawString)
		{
			return _converter.EncodeToBaseString(rawString, CalystoBaseConvert.RadixEnum.Base4);
		}

		public byte[] DecodeHexStringToArray(string baseEncodedString)
		{
			return _converter.DecodeBaseStringToArray(baseEncodedString, CalystoBaseConvert.RadixEnum.Base4);
		}

		public string DecodeBase64StringToString(string baseEndodedString)
		{
			return _converter.DecodeBaseStringToString(baseEndodedString, Calysto.Converter.CalystoBaseConvert.RadixEnum.Base4);
		}


	}
}
