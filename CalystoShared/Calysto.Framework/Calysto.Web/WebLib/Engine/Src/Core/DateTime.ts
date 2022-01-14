namespace Calysto
{
	/**
	* .NET DayOfWeek
	*/
	export enum DayOfWeek
	{
		Sunday = 0,
		Monday = 1,
		Tuesday = 2,
		Wednesday = 3,
		Thursday = 4,
		Friday = 5,
		Saturday = 6
	};

	export namespace DateFormat
	{
		////var token = /d{1,4}|M{1,4}|yy(?:yy)?|([HhmsTtFf])\1?|[LloKSZ]|"[^"]*"|'[^']*'/g,
		////timezone = /\b(?:[PMCEA][SDP]T|(?:Pacific|Mountain|Central|Eastern|Atlantic) (?:Standard|Daylight|Prevailing) Time|(?:GMT|UTC)(?:[-+]\d{4})?)\b/g,
		////timezoneClip = /[^-+\dA-Z]/g,

		// fixed regex for AjaxMin and Packer
		var _token = new RegExp("d{1,4}|M{1,4}|yy(?:yy)?|[H]{1,2}|[h]{1,2}|[m]{1,2}|[s]{1,2}|[f]{1,3}|[t]{1,2}|[LloKSZT]|\"[^\"]*\"|'[^']*", "g");
		var _timezone = new RegExp("\b(?:[PMCEA][SDP]T|(?:Pacific|Mountain|Central|Eastern|Atlantic) (?:Standard|Daylight|Prevailing) Time|(?:GMT|UTC)(?:[-+]\d{4})?)\b", "g");
		var _timezoneClip = new RegExp("[^-+\dA-Z]", "g");

		function pad(val: any, len?: number)
		{
			val = String(val);
			len = len || 2;
			while (val.length < len) val = "0" + val;
			return val;
		}

		// Regexes and supporting functions are cached through closure
		export function Format (date: Date, format?: string, utc?: boolean)
		{
			/// <summary>
			/// use mask or GeneralLongTimePattern
			/// </summary>
			/// <param name="date" type="Date"></param>
			/// <param name="mask" type="String"></param>
			/// <param name="utc" type="Boolean"></param>

			format = format || Calysto.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GeneralLongTimePattern;

			// Allow setting the utc argument via the mask
			if (format.slice(0, 4) == "UTC:")
			{
				format = format.slice(4);
				utc = true;
			}

			var tzone;
			var mtz1 = (date + "").match(_timezone);
			if (mtz1 && mtz1.length > 0)
			{
				tzone = (mtz1[0] || "").replace(_timezoneClip, "");
			}

			var get = utc ? "getUTC" : "get",
				datum = date[get + "Date"](), // day in month: 1...31
				dan = date[get + "Day"](), // day of week, 0:Sunday, 1: Monday...
				month = date[get + "Month"](), // 0...11
				year = date[get + "FullYear"](),
				hours = date[get + "Hours"](),
				min = date[get + "Minutes"](),
				s = date[get + "Seconds"](),
				L = date[get + "Milliseconds"](),
				L = pad(Math.floor(L) % 1000, 3), // create 3 chars, eg if L was 12 ticks, convert it  to "012"
				o = utc ? 0 : date.getTimezoneOffset(), // minutes, eg. if zone is -120 (minutes), it is GMT+0200 (hours) because sign is opposite
				flags = {
					dddd: i18n.DayNames[dan],
					ddd: i18n.AbbreviatedDayNames[dan],
					dd: pad(datum),
					d: datum,
					MMMM: i18n.MonthNames[month],
					MMM: i18n.AbbreviatedMonthNames[month],
					MM: pad(month + 1),
					M: month + 1,
					yy: String(year).slice(2),
					yyyy: year,
					h: hours % 12 || 12,
					hh: pad(hours % 12 || 12),
					H: hours,
					HH: pad(hours),
					m: min,
					mm: pad(min),
					s: s,
					ss: pad(s),
					f: String(L).substr(0, 1),
					ff: String(L).substr(0, 2),
					fff: L,
					t: hours < 12 ? "A" : "P",
					tt: hours < 12 ? "AM" : "PM",
					K: (o > 0 ? "-" : "+") + pad(Math.floor(Math.abs(o) / 60)) + ":" + pad(Math.abs(o) % 60),
					Z: utc ? "UTC" : tzone,
					//o: (o > 0 ? "-" : "+") + pad(Math.floor(Math.abs(o) / 60) * 100 + Math.abs(o) % 60, 4),
					S: ["th", "st", "nd", "rd"][(datum % 10 > 3) || (datum >= 10 && datum <= 20) ? 0 : (datum % 10)]
				};

			return format.replace(_token, function ($0)
			{
				var dd = $0 in flags ? flags[$0] : $0.slice(1, $0.length - 1);
				return dd;
			});
		}

		function GetInt(parseString: string, parseFormat: string, dic: { [format: string]: number }, possibleArr: string[])
		{
			/// <summary>
			/// 
			/// </summary>
			/// <param name="valueArr" type="Array"></param>
			/// <param name="formatArr" type="Array"></param>
			/// <param name="posibleArr" type="Array"></param>

			for (var k of possibleArr)
			{
				// dic contains properties which are set in format string
				if (k in dic)
				{
					if (Calysto.Type.TypeInspector.IsNumber(dic[k]))
					{
						return dic[k];
					}
					else
					{
						return NaN; // we have format, but there is no value, it is error
					}
				}
			}

			return 0;
		}

		// ISO with T or without and with or without ending time zone info
		var reg1 = new RegExp("([\\d]+)-([\\d]+)-([\\d]+)[T\\s]+([\\d]*)[:]*([\\d]*)[:]*([\\d]*)[\\.]*([\\d]*)([\\+ \\:\\d\\w]*)");
		// HR with T or without and with or without ending time zone info
		var reg2 = new RegExp("([\\d]+).([\\d]+).([\\d]+)[\\.]*[T\\s]+([\\d]*)[:]*([\\d]*)[:]*([\\d]*)[\\.]*([\\d]*)([\\+ \\:\\d\\w]*)");

		var fnPadRight = function (n, places)
		{
			n += "";
			while (n.length < places)
			{
				n = n + "0";
			}
			return n;
		};

		export function TryParseExact(arg: string | Date | DateTime, format: string, refOut: BoxValue<DateTime>, throwError?: boolean): boolean
		{
			if (Calysto.Type.TypeInspector.IsDate(arg))
			{
				refOut.SetValue(new DateTime(<Date>arg));
				return true;
			}
			else if (Calysto.Type.TypeInspector.IsDateTime(arg))
			{
				refOut.SetValue(<DateTime>arg);
				return true;
			}

			let str : string = <string> arg || "";
			if (format)
			{
				var f1 = format.split(new RegExp("[^\\w]+"));
				var v1 = str.split(new RegExp("[^\\d]+"));
				var dic = {};
				for (let n = 0; n < f1.length; n++)
				{
					let val = v1[n];
					if (f1[n]?.StartsWith("f"))
						val = fnPadRight(val, 3); // convert to full milliseconds

					dic[f1[n]] = parseInt(val);
				}

				var args = [
					GetInt(str, format, dic, ["yyyy", "yy"]),
					GetInt(str, format, dic, ["MM", "M"]),
					GetInt(str, format, dic, ["dd", "d"]),
					GetInt(str, format, dic, ["HH", "H"]),
					GetInt(str, format, dic, ["mm", "m"]),
					GetInt(str, format, dic, ["ss", "s"]),
					GetInt(str, format, dic, ["fff", "ff", "f"])
				];

				if (args.AsEnumerable().Where(o => o == NaN).Any())
				{
					if (throwError)
					{
						throw new Error("Error parsing date from: " + str + ", to format: " + format);
					}
					else
					{
						return false;
					}
				}

				try
				{
					refOut.SetValue(Calysto.DateTime.Create.apply(null, <any>args));
					return true;
				}
				catch (e)
				{
					if (throwError) throw e;
				}
				return false;
			}

			let m = str.match(reg1);
			if (m)
			{
				refOut.SetValue(Calysto.DateTime.Create(
					parseInt(m[1], 10), // day
					parseInt(m[2], 10), // month
					parseInt(m[3], 10), // year
					parseInt(m[4], 10), // hour
					parseInt(m[5], 10), // minutes
					parseInt(m[6], 10), // seconds
					parseInt(fnPadRight(m[7] || "", 3).substr(0,3), 10) // ms
				));
				return true;
			}

			m = str.match(reg2);
			if (m)
			{
				refOut.SetValue(Calysto.DateTime.Create(
					parseInt(m[3], 10), // year
					parseInt(m[2], 10), // month
					parseInt(m[1], 10), // day
					parseInt(m[4], 10), // hours
					parseInt(m[5], 10), // minutes
					parseInt(m[6], 10), // seconds
					parseInt(fnPadRight(m[7] || "", 3).substr(0,3), 10) // ms
				));
				return true;
			}

			let date;
			if ((date = new Date(Date.parse(str))) && !isNaN(date.getFullYear()))
			{
				refOut.SetValue(new Calysto.DateTime(date));
				return true;
			}

			if (throwError)
			{
				throw new Error("Can not parse DateTime from " + str);
			}

			return false;
		}

		// Some common format strings
		export var masks = {
			"default": "ddd MMM dd yyyy HH:mm:ss",
			shortDate: "M/d/yy",
			mediumDate: "MMM d, yyyy",
			longDate: "MMMM d, yyyy",
			fullDate: "dddd, MMMM d, yyyy",
			shortTime: "h:mm tt",
			mediumTime: "h:mm:ss tt",
			longTime: "h:mm:ss tt K",
			isoDate: "yyyy-MM-dd",
			isoTime: "HH:mm:ss",
			isoDateTime: "yyyy-MM-dd HH:mm:ss.fff",
			iso3DateTime: "yyyy-MM-ddTHH:mm:ss.fff",
			iso6DateTime: "yyyy-MM-ddTHH:mm:ss.ffffff",
			isoUtcDateTime: "UTC:yyyy-MM-dd HH:mm:ss.fff"
		};

		// Internationalization strings

		var i18n = Calysto.Globalization.CultureInfo.CurrentCulture.DateTimeFormat;

		////__df.i18n = {
		////	AbbreviatedDayNames: ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"],
		////	DayNames: ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"],
		////	AbbreviatedMonthNames: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"],
		////	MonthNames: ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"],
		////	FirstDayOfWeek: : 0
		////};
	}

	export class DateTime
	{
		protected _typeName = "DateTime";

		private _dateItem: Date;
		private get _isoDateStr() { return Date.ToLocalISOTString(this._dateItem);}
		private get _currCultureStr() { return this._dateItem.ToStringFormated(); }

		//#region constructor overloads

		/** new instance with current datetime */
		constructor();
		/**
		 * new instance FromLocalISOTString
		 * @param date
		 */
		constructor(date: string);
		/**
		 * new instance from sytem Date
		 * @param Date
		 */
		constructor(date: Date);
		/**
		 * new instance from DateTime
		 * @param DateTime
		 */
		constructor(dateTime: DateTime);
		/**
		 * new instance from absolute ticks
		 * @param ticks
		 */
		constructor(ticks: number);

		constructor(date?: string | Date | DateTime | number)
		{
			/// <summary>
			/// 
			/// </summary>
			/// <param name="date" type="Date|String">if not set, will use new Date(0) which is 1.1.1970.</param>

			if (!date)
			{
				this._dateItem = new Date(0);
			}
			else if (typeof (date) == "number" && Calysto.Type.TypeInspector.IsNumber(date))
			{
				this._dateItem = new Date(date);
			}
			else if (typeof (date) == "string")
			{
				// iso date time string
				this._dateItem = Date.FromLocalISOTString(date);
			}
			else if (date.constructor == DateTime)
			{
				this._dateItem = <Date>(<DateTime>date)._dateItem;
			}
			else if (date.constructor == Date)
			{
				this._dateItem = <Date>date;
			}
			else
			{
				throw new Error("NotSupported: " + date);
			}
		}

		//#endregion

		//#region Add... methods

		public AddHours(hours: number) { return new Calysto.DateTime(new Date(this._dateItem.getTime() + hours * 60 * 60 * 1000)); }
		public AddMinutes(minutes: number) { return new Calysto.DateTime(new Date(this._dateItem.getTime() + minutes * 60 * 1000)); }
		public AddSeconds(seconds: number) { return new Calysto.DateTime(new Date(this._dateItem.getTime() + seconds * 1000)); }
		public AddMiliseconds(misliseconds: number) { return new Calysto.DateTime(new Date(this._dateItem.getTime() + misliseconds)); }
		public AddDays(days: number) { return new Calysto.DateTime(new Date(this._dateItem.getTime() + days * 24 * 60 * 60 * 1000)); }

		public AddMonths(months: number)
		{
			var currMonths = this._dateItem.getFullYear() * 12 + this._dateItem.getMonth() + months;
			var year = currMonths / 12;
			var month = currMonths % 12;
			var date = new Date(this._dateItem.getTime());
			date.setMonth(month);
			date.setFullYear(year);
			return new Calysto.DateTime(date);
		}

		public AddYears(years: number)
		{
			var year = this._dateItem.getFullYear() + years;
			var date = new Date(this._dateItem.getTime());
			date.setFullYear(year);
			return new Calysto.DateTime(date);
		}

		//#endregion

		//#region To... methods

		/** to system Date object, create copy */
		public ToSystemDate()
		{
			// IE cannot instantinate new Date from date, so get ticks first
			let ticks = this._dateItem ? this._dateItem.getTime() : 0;
			return new Date(ticks);
		}

		/** to Calysto.DateTime, create copy */
		public ToDateTime() { return new DateTime(this._dateItem); }

		public ToStringFormated(format?: string) { return DateFormat.Format(this._dateItem, format); }
		public ToShortDateString() { return this.ToStringFormated(Calysto.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern); }
		public ToLongDateString() { return this.ToStringFormated(Calysto.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.LongDatePattern); }
		public ToShortTimeString() { return this.ToStringFormated(Calysto.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern); }
		public ToLongTimeString() { return this.ToStringFormated(Calysto.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.LongTimePattern); }
		public toString() { return this._isoDateStr; }

		//#endregion

		//#region static properties

		public static get Now() { return new Calysto.DateTime(new Date()); }

		//#endregion

		//#region instance properties

		/** The year, between 1 and 9999. */
		public get Year() { return this._dateItem.getFullYear(); }

		/** The month component, expressed as a value between 1 and 12. */
		public get Month() { return this._dateItem.getMonth() + 1; }

		/** The day component, expressed as a value between 1 and 31. */
		public get Day() { return this._dateItem.getDate(); }

		/** NET DayOfWeek:
			Sunday = 0,
			Monday = 1,
			Tuesday = 2,
			Wednesday = 3,
			Thursday = 4,
			Friday = 5,
			Saturday = 6
		*/
		public get DayOfWeek() { return <DayOfWeek>this._dateItem.getDay(); }

		/** The hour component, expressed as a value between 0 and 23. */
		public get Hour() { return this._dateItem.getHours(); }

		/** The minute component, expressed as a value between 0 and 59.*/
		public get Minute() { return this._dateItem.getMinutes(); }

		/** The seconds component, expressed as a value between 0 and 59. */
		public get Second() { return this._dateItem.getSeconds(); }

		/** The milliseconds component, expressed as a value between 0 and 999. */
		public get Millisecond() { return this._dateItem.getMilliseconds(); }

		/** The number of ticks that represent the date and time of this instance. 
		 * The value is between DateTime.MinValue.Ticks and DateTime.MaxValue.Ticks.*/
		public get Ticks() { return this._dateItem.getTime(); }

		/** Gets the date component of this instance with time 00:00:00*/
		public get Date() { return Calysto.DateTime.Create(this.Year, this.Month, this.Day); }

		/** A time interval that represents the fraction of the day that has elapsed since midnight.*/
		public get TimeOfDay() { return Calysto.TimeSpan.Create(0, this.Hour, this.Minute, this.Second, this.Millisecond); }

		//#endregion

		//#region create & parse dates

		/**
		 * 
		 * @param year e.g. 2017
		 * @param month 1 - 12
		 * @param day 1 - 31
		 * @param hours 0 - 23
		 * @param minutes 0 - 59
		 * @param seconds 0 - 59
		 * @param miliseconds 0 - 999
		 */
		public static Create(year: number, month: number, day: number, hours?: number, minutes?: number, seconds?: number, miliseconds?: number)
		{
			if (arguments.length > 2 && Calysto.Type.TypeInspector.IsNumber(year, month, day))
			{
				// Date accepts month [0-11]
				return new Calysto.DateTime(new Date(year || 1700, (month || 1) - 1, day || 1, hours || 0, minutes || 0, seconds || 0, miliseconds || 0));
			}
			else
			{
				throw new Error("Can not create DateTime");
			}
		}

		public static TryParseDateTime(str: string | Date | DateTime, format: string, refOut: BoxValue<DateTime>): boolean
		{
			/// <summary>
			/// Parse str using format or current culture GeneralLongTimePattern.<br/>
			/// Than try using Date.parse(str)<br/>
			/// Returns Calysto.DateTime, or null if can't be parsed.
			/// </summary>
			/// <param name="str"></param>
			/// <param name="format" type="String" optional="true">.NET like date format string, if not provided, will use CurrentCulture format</param>

			if (format)
			{
				return DateFormat.TryParseExact(str, format, refOut);
			}
			else if (DateFormat.TryParseExact(str, Calysto.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GeneralLongTimePattern, refOut))
			{
				return true;
			}
			else if (DateFormat.TryParseExact(str, Calysto.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern, refOut))
			{
				return true;
			}
			return false;
		}

		public static TryParseDate(str: string | Date | DateTime, format: string, refOut: BoxValue<DateTime>): boolean
		{
			if (DateTime.TryParseDateTime(str, format, refOut))
			{
				refOut.SetValue(refOut.GetValue().Date);
				return true;
			}
			return false;
		}

		/**
		 * Returns Calysto.DateTime, throw exception if can't be parsed.
		 * @param {string} str
		 * @param {string} format?
		 * @returns
		 */
		public static ParseDateTime(str: string | Date | DateTime, format?: string, throwEx?: boolean): DateTime
		{
			/// <summary>
			/// Parse str using format or current culture GeneralLongTimePattern.<br/>
			/// Than try using Date.parse(str)<br/>
			/// Returns Calysto.DateTime, or null if can't be parsed.
			/// </summary>
			/// <param name="str"></param>
			/// <param name="format" type="String" optional="true">.NET like date format string, if not provided, will use CurrentCulture format</param>

			let refOut = new BoxValue<DateTime>();
			if (DateTime.TryParseDateTime(str, <any>format, refOut))
			{
				return refOut.GetValue();
			}
			if (throwEx)
			{
				throw Error("Error in ParseDateTime, can not parse: " + str);
			}
			return <DateTime><any>undefined; // we need this for imagine, to prevent from throwing exception
		}

		/**
		 * Returns Calysto.DateTime, date part only, throw exception if can't be parsed.
		 * @param {string} str
		 * @param {string} format?
		 * @returns
		 */
		public static ParseDate(str: string | Date | DateTime, format?: string, throwEx?: boolean): DateTime
		{
			let refOut = new BoxValue<DateTime>();
			if (DateTime.TryParseDate(str, <any>format, refOut))
			{
				return refOut.GetValue();
			}
			if (throwEx)
			{
				throw Error("Error in ParseDate, can not parse: " + str);
			}
			return <DateTime><any>undefined;
		}

		//#endregion
	}
}


interface Date
{
	ToStringFormated(format?: string): string;

	/** to system Date object, create copy */
	ToSystemDate(): Date;

	/** to Calysto.DateTime, create copy */
	ToDateTime(): Calysto.DateTime;
}


// used in CalystoDatePicker:
Date.prototype.ToStringFormated = function (format)
{
	/// <summary>
	/// format DateTime to string, default is yyyy-MM-dd HH:mm:ss.fff
	/// </summary>
	/// <param name="format" optional="true">.NET date time string format</param>
	return Calysto.DateFormat.Format(this, format);
};

Date.prototype.ToDateTime = function ()
{
	return new Calysto.DateTime(this);
};

Date.prototype.ToSystemDate = function()
{
	return new Date(this);
}

Date.prototype.ToDateTime = function ()
{
	return new Calysto.DateTime(this);
};



