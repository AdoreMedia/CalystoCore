namespace Calysto.Validate
{
	/**
	 *  Returns true if str is valid e-mail
	 * @param str
	 */
	export function IsEmail(str: string)
	{
		var __emailRegexPattern = Calysto.Constants.AppConstants.EmailRegexPattern;

		str += ""; // convert to string
		return !!(str && str.match(new RegExp(__emailRegexPattern)));
	}

	/**
	 * Returns true if str is valid number formated in current culture, eg. - 43.634,634, but not - 43,53 kn (may include -,.0-9, no currency symbol)
	 * @param str
	 */
	export function CanConvertToNumber(str: string)
	{
		str += ""; // convert to string

		return !!(str && str.match(new RegExp("^[\\-]*[ ]*[ \\.\\,]?[\\d]+[\\d\\.\\,]*$")));
	};

	/**
	 * same as IsNumber()
	 * @param str
	 */
	export function CanConvertToDecimal(str: string)
	{
		return CanConvertToNumber(str);
	}

	/**
	 * Returns true if str is valid integer, eg. -34534 (may not include any other symbol)
	 * @param str
	 */
	export function CanConvertToInteger(str: string)
	{
		str += ""; // convert to string
		return !!(str && str.match(new RegExp("^[\\- ]?[\\d]+$")));
	};

	/**
	 * Returns true if str contains valid number, eg. last - 43.634,634 kn
	 * @param str
	 */
	export function ContainsNumber(str: string)
	{
		str += ""; // convert to string
		return !!(str && str.match(new RegExp("[\\- ]?[ \\.\\,]?[\\d]+[\\d\\.\\,]*")));
	};

	/**
	 * Is valid date formated in current culture.
	 * @param str
	 * @param format
	 */
	export function CanConvertToDate(str: string, format?: string)
	{
		let refArr = new BoxValue<DateTime>();
		return Calysto.DateFormat.TryParseExact(str, format || Calysto.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern, refArr);
	};

	/**
	 * Is valid dateTime in current culture.
	 * @param str
	 * @param format
	 */
	export function CanConvertToDateTime(str: string, format?: string)
	{
		let refArr = new BoxValue<DateTime>();
		return Calysto.DateFormat.TryParseExact(
			str,
			format || Calysto.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GeneralLongTimePattern,
			refArr
		);
	};

	function CanConvertToByte(str: string)
	{
		var val = parseFloat(str);
		return (isFinite(val) && val > 0 && val < 256) || val === 0;
	}

	/**
	 * Is valid IPv4 address d.d.d.d
	 * @param str
	 */
	export function IsIPv4Address(str: string)
	{
		var m = str.match(new RegExp("^([\\d]+)\\.([\\d]+)\\.([\\d]+)\\.([\\d]+)$"));
		return !!(m && CanConvertToByte(m[1]) && CanConvertToByte(m[2]) && CanConvertToByte(m[3]) && CanConvertToByte(m[4]));
	}
}

