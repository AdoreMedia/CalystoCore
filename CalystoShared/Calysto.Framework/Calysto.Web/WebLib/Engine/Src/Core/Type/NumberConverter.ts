namespace Calysto.Type.NumberConverter
{
	function ReplaceAll(str, search, replacement, ignoreCase)
	{
		if (!str) { return str; }
		var re = new RegExp(RegExp.Escape(search), ignoreCase ? "ig" : "g");
		return str.replace(re, replacement);
	}

	/**
	 * Parse as float number using current culture, or decimalSeparator. Returns number of defaultValue or null.
	 * @param strOrNum
	 * @param defaultValue default value to be returned if strOrNum is not number
	 * @param decimalSeparator if not set, will use current culture
	 */
	function ToNumberWithCulture(strOrNum, defaultValue, decimalSeparator?: string)
	{
		if (TypeInspector.IsNumber(strOrNum))
		{
			return strOrNum;
		}

		if (isNaN(defaultValue))
		{
			// leave NaN
		}
		else if (TypeInspector.IsNullOrUndefined(defaultValue))
		{
			defaultValue = null;
		}

		decimalSeparator = decimalSeparator || Calysto.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

		// negative sign may have space after it, .NET formats with space: - 33
		var re = new RegExp("[\\-]*[ ]*[ \\.\\,]?[\\d]+[\\d\\.\\,]*"); // extract number from eg. "fsd---.423,636.432 kn"// masked edit will add "." eg: -.453.643,643
		var m = (strOrNum + "").match(re);
		var str1 = m && m[0] ? m[0] : "";

		// convert to US culture since parseFloat uses US culture always
		var str2 = str1
			.replace(new RegExp(RegExp.Escape(decimalSeparator == "." ? "," : "."), "ig"), "")
			.replace(new RegExp(RegExp.Escape(decimalSeparator), "ig"), ".")
			.replace(new RegExp("[ ]*", "ig"), ""); // remove white spaces because parseFloat("- 43.53") fails if has space after minus

		// parseFloat("-432.6324") // ok
		// parseFloat("- 432.6324") // fails

		var parsed = parseFloat(str2);
		if (!isNaN(parsed) && isFinite(parsed)) //  && parsed + "" == str2 + "") // don't convert to string and compare because if parsing from : -00432.63 will get -432.63 and verification would fail
		{
			return parsed;
		}
		else
		{
			return defaultValue;
		}
	};

	/**
	 * Extract number from string and parse using current culture. Parse strOrNum and return number, if can't be parsed, return defaultValue
	 * @param strOrNum
	 * @param defaultValue default value to be returned if strOrNum is not number
	 * @param decimalSeparator
	 */
	export function ToNumberOrDefault(strOrNum, defaultValue?: number, decimalSeparator?: string)
	{
		return ToNumberWithCulture(strOrNum, defaultValue, decimalSeparator);
	};

	/**
	 * Extract number from string and parse using current culture. Parse strOrNum and return number, if can't be parsed, return defaultValue
	 * @param strOrNum
	 * @param defaultValue default value to be returned if strOrNum is not number
	 * @param decimalSeparator
	 */
	export function ToDecimal(strOrNum, defaultValue?: number, decimalSeparator?: string)
	{
		return ToNumberWithCulture(strOrNum, defaultValue, decimalSeparator);
	};

	/**
	 * Extract number from string and parse as float number using current culture, than convert to integer.
	 * @param strOrNum
	 * @param defaultValue
	 */
	export function ToInteger(strOrNum, defaultValue?: number)
	{
		if (TypeInspector.IsNullOrUndefined(defaultValue))
		{
			defaultValue = NaN;
		}

		var num = ToNumberOrDefault(strOrNum, defaultValue);
		if (!isNaN(num) && isFinite(num))
		{
			return num > 0 ? Math.floor(num) : Math.ceil(num);
		}
		else
		{
			return defaultValue;
		}
	};

	export function ToBoolean(str, defaultValue?: boolean)
	{
		if (TypeInspector.IsBoolean(str)) return str;
		if (str == "true" || str == "True") return true;
		if (str == "false" || str == "False") return false;
		if (str > 0) return true;
		if (str === 0) return false;
		if (TypeInspector.IsNullOrUndefined(defaultValue))
		{
			return null;
		}
		else
		{
			return defaultValue;
		}
	};

	/**
	 * always returns string "" or default value +"" or ""
	 * @param value
	 * @param defaultValue
	 */
	export function ToString(value: any, defaultValue?: any)
	{
		if (!TypeInspector.IsNullOrUndefined(value))
		{
			return value + "";
		}
		else if (!TypeInspector.IsNullOrUndefined(defaultValue))
		{
			return defaultValue + "";
		}
		return "";
	};

}
