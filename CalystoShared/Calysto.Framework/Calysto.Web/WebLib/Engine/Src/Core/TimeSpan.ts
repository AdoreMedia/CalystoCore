namespace Calysto
{
	export class TimeSpan
	{
		private _ticks: number;

		constructor()
		{
			this._ticks = 0;
		}

		/**
		 * Returns ticks in milliseconds
		 * @param {number} days
		 * @param {number} hours
		 * @param {number} minutes
		 * @param {number} seconds
		 * @param {number} milliseconds
		 * @returns {type} 
		 */
		public static GetTicks(days?: number, hours?: number, minutes?: number, seconds?: number, milliseconds?: number)
		{
			/// <summary>
			/// Returns ticks in milliseconds
			/// </summary>
			/// <param name="days"></param>
			/// <param name="hours"></param>
			/// <param name="minutes"></param>
			/// <param name="seconds"></param>
			/// <param name="milliseconds"></param>

			return 1000 * 3600 * 24 * (days || 0)
				+ 1000 * 3600 * (hours || 0)
				+ 1000 * 60 * (minutes || 0)
				+ 1000 * (seconds || 0)
				+ (milliseconds || 0);
		}

		public static Create(days?: number, hours?: number, minutes?: number, seconds?: number, milliseconds?: number)
		{
			var tt = new Calysto.TimeSpan();
			tt._ticks = Calysto.TimeSpan.GetTicks(days, hours, minutes, seconds, milliseconds);
			return tt;
		}

		public static FromMilliseconds(milliseconds: number) { return new Calysto.TimeSpan().AddMilliseconds(milliseconds); }
		public static FromTicks(milliseconds: number) { return new Calysto.TimeSpan().AddMilliseconds(milliseconds); }
		public static FromSeconds(seconds: number) { return new Calysto.TimeSpan().AddSeconds(seconds); }
		public static FromMinutes(minutes: number) { return new Calysto.TimeSpan().AddMinutes(minutes); }
		public static FromHours(hours: number) { return new Calysto.TimeSpan().AddHours(hours); }
		public static FromDays(days: number) { return new Calysto.TimeSpan().AddDays(days); }

		public AddTicks (ticksMs: number)
		{
			var tt = new Calysto.TimeSpan();
			tt._ticks = this._ticks + ticksMs;
			return tt;
		}

		public AddDays(days: number) { return this.AddTicks(Calysto.TimeSpan.GetTicks(days)); }
		public AddHours(hours: number) { return this.AddTicks(Calysto.TimeSpan.GetTicks(0, hours)); }
		public AddMinutes(minutes: number) { return this.AddTicks(Calysto.TimeSpan.GetTicks(0, 0, minutes)); }
		public AddSeconds(seconds: number) { return this.AddTicks(Calysto.TimeSpan.GetTicks(0, 0, 0, seconds)); }
		public AddMilliseconds(milliseconds: number) { return this.AddTicks(milliseconds); }

		/** [float] The total number of milliseconds represented by this instance. */
		public get TotalMilliseconds() { return this.Ticks; }

		/** [float] The total number of seconds Ticks by this instance. */
		public get TotalSeconds() { return this.Ticks / 1000.0; }

		/** [float] The total number of minutes represented by this instance. */
		public get TotalMinutes() { return this.Ticks / 1000.0 / 60.0; }

		/** [float] The total number of hours represented by this instance.*/
		public get TotalHours() { return this.TotalMinutes / 60.0; }

		/** [float] The total number of days represented by this instance. */
		public get TotalDays() { return this.TotalHours / 24.0; }

		/** [long] The number of ticks contained in this instance. */
		public get Ticks() { return Math.floor(this._ticks || 0); }

		/** [int] The day component of this instance. The return value can be positive or negative. */
		public get Days() { return Math.floor(this.TotalDays);}

		/** [int] The hour component of the current System.TimeSpan structure. The return value ranges from -23 through 23. */
		public get Hours() { return Math.floor(this.TotalHours % 24); }

		/** [int] The minute component of the current System.TimeSpan structure. The return value ranges from -59 through 59. */
		public get Minutes() { return Math.floor(this.TotalMinutes % 60); }

		/** [int] The second component of the current System.TimeSpan structure. The return value ranges from -59 through 59. */
		public get Seconds() { return Math.floor(this.TotalSeconds % 60); }

		/** [long] The millisecond component of the current System.TimeSpan structure. The return value ranges from -999 through 999. */
		public get Milliseconds() { return Math.floor(this.Ticks) % 1000; }

		private pad(val, len: number = 2)
		{
			val = String(val);
			len = len || 2;
			while (val.length < len) val = "0" + val;
			return val;
		}

		private static _token = new RegExp("[H]{1,2}|[h]{1,2}|[m]{1,2}|[s]{1,2}|[f]{1,3}", "g");

		private FormatTime(ticks, format)
		{
			// 1 tick == 1 ms
			var ms = this.pad(Math.floor(ticks) % 1000, 3);

			var totalSeconds = Math.floor(this.TotalSeconds);
			var totalHoursInt = Math.floor(this.TotalHours); // total hours, can be > 24
			var min = Math.floor(totalSeconds / 60) % 60;
			var s = totalSeconds % 60;

			var flags = {
				H: totalHoursInt,
				HH: this.pad(totalHoursInt),
				m: min,
				mm: this.pad(min),
				s: s,
				ss: this.pad(s),
				f: String(ms).substr(0, 1),
				ff: String(ms).substr(0, 2),
				fff: String(ms).substr(0, 3)
			};

			return format.replace(TimeSpan._token, function ($0)
			{
				//var dd = $0 in flags ? flags[$0] : $0.slice(1, $0.length - 1);
				var dd = $0 in flags ? flags[$0] : ""; // if HH:mm:ss.ffffffff, take only parts which exists in flags{}
				return dd;
			});
		}

		/**
		 * use format or current culture ShortTimePattern
		 * @param format
		 */
		public ToStringFormated(format?: string)
		{
			return this.FormatTime(this._ticks, format || "HH:mm:ss.fff");
		}

		public toString() { return this.ToStringFormated(); }
	}
}

