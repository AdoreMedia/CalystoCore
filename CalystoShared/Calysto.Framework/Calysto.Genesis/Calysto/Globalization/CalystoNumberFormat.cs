using System.Globalization;

namespace Calysto.Globalization
{
	public class CalystoNumberFormat
	{
		private NumberFormatInfo _num;

		private static string[] _currencyPattern = new string[]{
		"{CurrencySymbol}{Value}", // 0, en-US
		"{Value} {CurrencySymbol}", // 1 ???
		"{CurrencySymbol} {Value}", // 2 da-DK
		"{Value} {CurrencySymbol}" // 3, hr-HR
		};

		/// <summary>
		/// $
		/// </summary>
		public string CurrencySymbol { get { return _num.CurrencySymbol; } }
		
		/// <summary>
		/// .
		/// </summary>
		public string NumberDecimalSeparator { get { return _num.NumberDecimalSeparator; } }

		/// <summary>
		/// ,
		/// </summary>
		public string NumberGroupSeparator { get { return _num.NumberGroupSeparator; } }
	
		/// <summary>
		/// ‰
		/// </summary>
		public string PerMilleSymbol { get { return _num.PerMilleSymbol; } }

		/// <summary>
		/// %
		/// </summary>
		public string PercentSymbol { get { return _num.PercentSymbol; } }

		public int CurrencyPositivePattern { get { return _num.CurrencyPositivePattern; } }

		public string CurrencyPositivePatternString { get { return _currencyPattern[this.CurrencyPositivePattern]; } }

		public CalystoNumberFormat(CultureInfo culture)
		{
			this._num = culture.NumberFormat;
		}


	}
}
