using System.Globalization;

namespace Calysto.Globalization
{
	public class CalystoRegionInfo
	{
		private RegionInfo _region;

		public string CurrencyEnglishName { get { return _region.CurrencyEnglishName; } } //	"Croatian Kuna"	string
		public string CurrencyNativeName { get { return _region.CurrencyNativeName; } } //	"hrvatska kuna"	string
		public string CurrencySymbol { get { return _region.CurrencySymbol; } } //	"kn"	string
		public string DisplayName { get { return _region.DisplayName; } } //	"Croatia"	string
		public string EnglishName { get { return _region.EnglishName; } } //	"Croatia"	string
		////public int GeoId { get { return _region.GeoId; } } //	int 108
		public bool IsMetric { get { return _region.IsMetric; } } //true	bool
		public string ISOCurrencySymbol { get { return _region.ISOCurrencySymbol; } } //	"HRK"	string
		public string Name { get { return _region.Name; } } //	"HR"	string
		public string NativeName { get { return _region.NativeName; } } //	"Hrvatska"	string
		public string ThreeLetterISORegionName { get { return _region.ThreeLetterISORegionName; } } //	"HRV"	string
		public string ThreeLetterWindowsRegionName { get { return _region.ThreeLetterWindowsRegionName; } } //	"HRV"	string
		public string TwoLetterISORegionName { get { return _region.TwoLetterISORegionName; } } //	"HR"	string

		public CalystoRegionInfo(System.Globalization.CultureInfo culture)
		{
			_region = new RegionInfo(culture.Name);
		}
	}
}
