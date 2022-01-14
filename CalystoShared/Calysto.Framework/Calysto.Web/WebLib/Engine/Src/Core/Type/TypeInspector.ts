namespace Calysto.Type.TypeInspector
{
	function fnTest(arr: IArguments, fn: Function)
	{
		if (arr && arr.length > 0)
		{
			for (var n = 0; n < arr.length; n++)
			{
				if (!fn(arr[n]))
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}

	/**
	 * for unittests
	 * @param obj
	 * @param property
	 */
	export function ContainsProperty(obj: any, property: string)
	{
		return obj && property && obj[property] !== undefined;
	}

	/**
	 * is boolean
	 * @param args
	 */
	export function IsBoolean(...args: any[])
	{
		return fnTest(arguments, (obj) => typeof (obj) == "boolean");
	};

	/**
	 * is finite number, not NaN
	 * @param args
	 */
	export function IsNumber(...args: any[])
	{
		//return !isNaN(parseFloat(obj)) && isFinite(obj); // from jQuery
		// if obj already is nuber, it may be parsed with parseFloat again
		// be carefull with null value, this is fnTested way to make sure we have the number and not (null or NaN or undefined)
		// isFinite(null) gives true
		// isFinite("") gives true
		// isFinite(NaN) gives false
		return fnTest(arguments, (obj) => typeof (obj) == "number" && !isNaN(obj) && isFinite(obj)); // provjereno ispravan test za number
	};

	/**
	 * is string
	 * @param args
	 */
	export function IsString(...args: any[])
	{
		return fnTest(arguments, (obj) => typeof (obj) == "string");
	};

	/**
	 * is system Array
	 * @param args
	 */
	export function IsArray(...args: any[])
	{
		// if obj is string, typeof(obj) == "string", everything else is the same as in array
		// dom array has length only, no push, pop, etc.
		return fnTest(arguments, (obj) => obj && obj.push && obj.pop && (obj.length > 0 || obj.length === 0));
	};

	/**
	 * is DOM array
	 * @param args
	 */
	export function IsDomArray(...args: any[])
	{
		// if obj is string, typeof(obj) == "string", everything else is the same as in array
		// dom array has length only, no push, pop, etc.
		// when used lambda, this is correct
		return fnTest(arguments, (obj) =>
		{
			var type = typeof (obj);
			return obj
				&& (type == "object" || type == "function")
				&& !(type["tagName"] && type["nodeType"]) // exclude from and select elements which are arary of element or options
				&& (obj.length > 0 || obj.length === 0) // DOM array has length only, in Safari it is function
				&& !IsFunction(obj); // safari DOM array type is "function", but doesnt have Function specific properties
		});
	};

	/**
	 * is Array or DOM array
	 * @param args
	 */
	export function IsArrayOrDomArray(...args: any[])
	{
		return IsArray.apply(null, <any>arguments) || IsDomArray.apply(null, <any>arguments);
	};

	/**
	 * is functions with call and apply properties
	 * @param args
	 */
	export function IsFunction(...args: any[])
	{
		return fnTest(arguments, function (obj)
		{
			// safari DOM array type is "function", but doesnt have Function specific properties
			return typeof (obj) == "function" && "call" in obj && "apply" in obj;
		});
	};

	/**
	 * is null or undefined or NaN
	 * @param args
	 */
	export function IsNullOrUndefined(...args: any[])
	{
		if (arguments.length == 0) return true;

		return fnTest(arguments, function (obj)
		{
			if (obj === null || typeof (obj) == "undefined")
			{
				return true;
			}
			else if (typeof (obj) == "number" && (isNaN(obj) || !isFinite(obj)))
			{
				return true;
			}
			return false;
		});
	};

	/**
	 * Test if all values are valid string, number or boolean (excluding NaN, undefined and null of any type).
	 * @param args
	 */
	export function IsValueType(...args: any[])
	{
		return IsString.apply(null, <any>arguments) || IsNumber.apply(null, <any>arguments) || IsBoolean.apply(null, <any>arguments);
	};

	/**
	 * is Calysto.DateTime
	 * @param value
	 */
	export function IsDateTime(value)
	{
		return value && value.constructor == Calysto.DateTime;
	};

	/**
	 * is system Date
	 * @param value
	 */
	export function IsDate(value)
	{
		return value && value.constructor == Date;
	};

	export function Coalesce(...args: any[])
	{
		/// <summary>
		/// Returns first obj which is not null or undefined
		/// </summary>

		var tmp: any;
		for (var n = 0; n < arguments.length; n++)
		{
			tmp = arguments[n];
			if (!IsNullOrUndefined(tmp))
			{
				return tmp;
			}
		}
		// don't return anything, this way method will return undefined
	};

	/**
	* 1. If references are equal, returns true.
	* 2. If JSON is not supported, return false.
	* 3. If references are not equal, serializes both object into JSON and compare json strings. 
	* @param {any} obj1
	* @param {any} obj2
	* @returns
	*/
	export function AreValuesEqual(obj1: any, obj2: any): boolean
	{
		if (obj1 === obj2) return true; // references are equal
		if (!(<any>window).JSON) return false; // JSON is not supported, return false
		return JSON.stringify(obj1) === JSON.stringify(obj2);
	}

	interface IHashElement extends Object
	{
		__$$hash: string;
	}

	export function CalculateHashCode(obj: IHashElement)
	{
		if (obj?.__$$hash)
			return obj?.__$$hash;

		let val1 = JSON.stringify(obj);
		if (typeof val1 != "string")
			val1 = obj + "";

		try
		{
			obj.__$$hash = val1; // cache it for later
		}
		catch (e)
		{
		}

		return val1;
	}
}
