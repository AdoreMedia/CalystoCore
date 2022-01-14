interface DateConstructor
{
	FromLocalISOTString(dateStr: string): Date;
	ToLocalISOTString(date: Date): string;
}

if (!Date.FromLocalISOTString)
{
	(function ()
	{
		Date.now = function ()
		{
			/// <summary>
			/// Calysto extension, added if desn't already exist Get ticks now.
			/// </summary>
			/// <returns type=""></returns>
			return new Date().getTime();
		};


		var fnPadLeft = function (n, places)
		{
			n += "";
			while (n.length < places)
			{
				n = "0" + n;
			}
			return n;
		};

		var fnPadRight = function (n, places)
		{
			n += "";
			while (n.length < places)
			{
				n = n + "0";
			}
			return n;
		};

		Date.ToLocalISOTString = (date: Date) =>
		{
			/// <summary>
			/// Serialize current datetime to ISO string, ignoring browser time zone. yyyy-MM-ddTHH:mm:ss.ffffff
			/// </summary>
			/// <returns type=""></returns>
			var str1 =
				fnPadLeft(date.getFullYear(), 4) + "-" +
				fnPadLeft(date.getMonth() + 1, 2) + "-" +
				fnPadLeft(date.getDate(), 2) + "T" +
				fnPadLeft(date.getHours(), 2) + ":" +
				fnPadLeft(date.getMinutes(), 2) + ":" +
				fnPadLeft(date.getSeconds(), 2) + "." +
				fnPadRight(date.getMilliseconds(), 3);
			return str1;
		};

		Date.FromLocalISOTString = function (dateStr)
		{
		    /// <summary>
			/// Parse ISO string into Date, ignore browser time zone. yyyy-MM-ddTHH:mm:ss.ffffff
		    /// </summary>
			/// <param name="dateStr" type="type"></param>
		    /// <returns type=""></returns>

			// received from Calysto server: new Date("2015-04-25T11:37:32.323444"), convert to exact time, ignore time zone, this way we have the same time in brower as on server
			// this method parses ISO datetime with or without T and Z "2015-04-25T11:37:32.323444"

			var m = dateStr.match(new RegExp("[\\d]+", "g"));
			var date = new Date(0);
			if (m)
			{
				date.setFullYear(parseInt(m[0]));
				date.setMonth(parseInt(m[1]) - 1); // month: 0-11
				date.setDate(parseInt(m[2]));
				date.setHours(parseInt(m[3]));
				date.setMinutes(parseInt(m[4]));
				date.setSeconds(parseInt(m[5]));
				date.setMilliseconds(parseInt((fnPadRight(m[6] || "", 3)).substr(0, 3)) || 0); // limit to 3 digits since we don't want > 999 ms
			}
			return date;
		};


	})();
}
