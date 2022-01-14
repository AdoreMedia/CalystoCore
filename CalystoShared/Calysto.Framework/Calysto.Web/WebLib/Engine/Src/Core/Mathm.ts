namespace Calysto.Mathm
{
	/**
	 * Generate rfc4122 version 4 compliant new GUID as function of current time and random number.
	 * Returns string: 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'
	*/
	export function NewGuid()
	{
		var d = new Date().getTime();
		var uuid = 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(new RegExp("[xy]", "g"), function (c)
		{
			// number | 0 is the same as Math.floor(number)
			var r = (d + Math.random() * 16) % 16 | 0;
			d = Math.floor(d / 16);
			return (c == 'x' ? r : (r & 0x7 | 0x8)).toString(16);
		});
		return uuid;
	};

	//#region random numbers

	/**
	 * Returns random float value.
	 * @param minVal inclusive min value, default: 0
	 * @param maxVal exclusive max value, default: 1
	 */
	export function Random(minVal: number, maxVal: number)
	{
		minVal = Calysto.Type.TypeInspector.IsNumber(minVal) ? minVal : 0;
		maxVal = Calysto.Type.TypeInspector.IsNumber(maxVal) ? maxVal : 1;
		if (minVal > maxVal)
		{
			throw new Error("Invalid range in Calysto.Mathm.Random(...)");
		}

		return Math.random() * (maxVal - minVal) + minVal;
	};

	/**
	 * Returns random int value.
	 * @param minVal inclusive min value, default: 0
	 * @param maxVal exclusive max value, default: 100
	 */
	export function RandomInt(minVal?: number, maxVal?: number)
	{
		return Math.floor(Random(Calysto.Type.TypeInspector.IsNumber(minVal) ? minVal as number : 0, Calysto.Type.TypeInspector.IsNumber(maxVal) ? maxVal as number : 100));
	};

	//#endregion

	//#region math functions

	function RunFunc(funcName: string, num: number, decimalPlaces: number)
	{
		// null == 0 is true
		if (!(decimalPlaces == 0 || decimalPlaces > 0)) throw new Error("Missing decimalPlaces");

		// ne koristiti value % 1 za extrahiranje decimalnog dijela jer se dobije float infinite number
		var mult = Math.pow(10, decimalPlaces);
		return Math[funcName](num * mult) / mult;
	}

	export function DecimalFloor(num: number, decimalPlaces: number)
	{
		/// <summary>
		/// Decimal floor to number of decimalPlaces.
		/// </summary>
		/// <param name="num" type="Number">number to invoke floor func on</param>
		/// <param name="decimalPlaces" type="int">decimal places to leave</param>
		return RunFunc("floor", num, decimalPlaces);
	};

	export function DecimalCeil (num, decimalPlaces)
	{
		/// <summary>
		/// Decimal ceil to number of decimalPlaces.
		/// </summary>
		/// <param name="num" type="Number">number to invoke ceil func on</param>
		/// <param name="decimalPlaces" type="int">decimal places to leave</param>
		return RunFunc("ceil", num, decimalPlaces);
	};

	export function DecimalRound (num, decimalPlaces)
	{
		/// <summary>
		/// Decimal round to number of decimalPlaces.
		/// </summary>
		/// <param name="num" type="Number">number to invoke round func on</param>
		/// <param name="decimalPlaces" type="int">decimal places to leave</param>
		return RunFunc("round", num, decimalPlaces);
	};

	export function DecimalTrunc (num, decimalPlaces)
	{
		/// <summary>
		/// Decimal truncate to number of decimalPlaces.
		/// </summary>
		/// <param name="num" type="Number">number to invoke trunc func on</param>
		/// <param name="decimalPlaces" type="int">decimal places to leave</param>
		return RunFunc("trunc", num, decimalPlaces);
	};

	//#endregion

}

