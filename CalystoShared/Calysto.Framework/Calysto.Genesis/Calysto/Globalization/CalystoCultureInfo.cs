namespace Calysto.Globalization
{
	public class CalystoCultureInfo
	{
		System.Globalization.CultureInfo _culture;

		public string Name { get { return _culture.Name; } } // "hr-HR"	string
		public string NativeName { get { return _culture.NativeName; } }// "hrvatski (Hrvatska)"	string
		public string DisplayName { get { return _culture.DisplayName; } }//"Croatian (Croatia)"	string
		public string EnglishName { get { return _culture.EnglishName; } }// "Croatian (Croatia)"	string
		public string ThreeLetterISOLanguageName { get { return _culture.ThreeLetterISOLanguageName; } } //	"hrv"	string
		public string ThreeLetterWindowsLanguageName { get { return _culture.ThreeLetterWindowsLanguageName; } } //	"HRV"	string
		public string TwoLetterISOLanguageName { get { return _culture.TwoLetterISOLanguageName; } }//	"hr"	string

		CalystoDateTimeFormat _dateTimeFormat;
		public CalystoDateTimeFormat DateTimeFormat { get { return _dateTimeFormat ?? (_dateTimeFormat = new CalystoDateTimeFormat(this._culture)); } }

		CalystoNumberFormat _numberFormat;
		public CalystoNumberFormat NumberFormat { get { return _numberFormat ?? (_numberFormat = new CalystoNumberFormat(this._culture));} }

		CalystoRegionInfo _region;
		public CalystoRegionInfo Region { get { return _region ?? (_region = new CalystoRegionInfo(this._culture));} }

		public CalystoCultureInfo(System.Globalization.CultureInfo culture)
		{
			this._culture = culture;
		}
	}
}
