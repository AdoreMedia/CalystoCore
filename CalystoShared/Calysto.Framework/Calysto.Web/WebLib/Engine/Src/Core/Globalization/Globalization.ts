namespace Calysto.Globalization
{
	class DateTimeFormat
	{
		public ShortestDayNames = ["Su", "Mo", "Tu", "We", "Th", "Fr", "Sa"];
		public AbbreviatedDayNames =  ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"];
		public DayNames = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];
		public AbbreviatedMonthNames = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec", ""];
		public MonthNames = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December", ""];
		public FirstDayOfWeek: 0;
		public LongDatePattern = "dddd, MMMM d, yyyy";
		public LongTimePattern = "h:mm:ss tt";
		public MonthDayPattern = "MMMM d";
		public ShortDatePattern = "M/d/yyyy";
		public ShortTimePattern = "h:mm tt";
		public GeneralLongTimePattern = "M/d/yyyy h:mm:ss tt";
		public GeneralShortTimePattern = "M/d/yyyy h:mm tt";
	}

	class NumberFormat
	{
		public CurrencySymbol = "$";
		public NumberDecimalSeparator = ".";
		public NumberGroupSeparator = ",";
		public PerMilleSymbol = "‰";
		public PercentSymbol = "%";
		public CurrencyPositivePattern = 0;
		public CurrencyPositivePatternString = "{CurrencySymbol}{Value}";
	}

	class Region
	{
		public CurrencyEnglishName = "US Dollar";
		public CurrencyNativeName = "US Dollar";
		public CurrencySymbol = "$";
		public DisplayName = "United States";
		public EnglishName = "United States";
		public IsMetric = false;
		public ISOCurrencySymbol = "USD";
		public Name = "en-US";
		public NativeName = "United States";
		public ThreeLetterISORegionName = "USA";
		public ThreeLetterWindowsRegionName = "USA";
		public TwoLetterISORegionName = "US";
	}

	let _currentCulture;

	function GetPredefinedCultures()
	{
		let dic1 = Calysto.Constants.PredefinedCultures as { [name: string]: CultureInfo };
		if (Calysto.Core.Constants.CurrentCulture && !(Calysto.Core.Constants.CurrentCulture.Name in dic1))
			dic1[Calysto.Core.Constants.CurrentCulture.Name] = Calysto.Core.Constants.CurrentCulture;
		return dic1;
	}

	export class CultureInfo
	{
		public Name = "en-US";
		public NativeName = "English (United States)";
		public DisplayName = "English (United States)";
		public EnglishName = "English (United States)";
		public ThreeLetterISOLanguageName = "eng";
		public ThreeLetterWindowsLanguageName = "ENU";
		public TwoLetterISOLanguageName = "en";
		public DateTimeFormat: DateTimeFormat;
		public NumberFormat: NumberFormat;
		public Region: Region;

		constructor()
		{
			this.DateTimeFormat = new DateTimeFormat();
			this.NumberFormat = new NumberFormat();
			this.Region = new Region();
		}

		public static get Cultures() { return GetPredefinedCultures() }

		public static get USCulture() { return GetPredefinedCultures()["en-US"] }
		public static get HRCulture() { return GetPredefinedCultures()["hr-HR"] }

		/** get current culture */
		public static get CurrentCulture()
		{
			return _currentCulture || Calysto.Core.Constants.CurrentCulture || CultureInfo.USCulture;
		}

		/** set new current culture */
		public static set CurrentCulture(culture: CultureInfo)
		{
			if (culture && culture.Name)
				_currentCulture = culture;
			else
				throw Error("Invalid culture provided.");
		}

	}

}



