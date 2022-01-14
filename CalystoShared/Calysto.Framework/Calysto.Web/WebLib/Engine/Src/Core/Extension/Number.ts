interface Number
{
	/**
	 * Format number to string using Calysto.Globalization.CultureInfo.CurrentCulture.NumberFormat
	 * @param format 
	 * nX to thousand separtor format with exact X decimal places
	 * cX for currency thousand separtor format with exact X decimal places
	 * #,##0.00## where zeros are mandatory and hashes are optional
	 */
	ToStringFormated(format?: string): string;
}


if (!Number.prototype.ToStringFormated)
{
	Number.prototype.ToStringFormated = function (this: number, format: string)
	{
		let _tmpthis = this;

		if (isFinite(_tmpthis) && !isNaN(_tmpthis))
		{
			let minDecPlaces = 0;
			let maxDecPlaces = 0;
			let isCurrency = false;
			let useThousandsSepator = false;
			let hashPattern = false;

			let m1;

			if (!format)
			{
				// unlimited decPlaces
				// will use decimal separator in current culture
				maxDecPlaces = 15;
			}
			else if ((m1 = format.toLowerCase().match(new RegExp("([NnCc])([\\d]*)"))))
			{
				useThousandsSepator = true;

				if (m1[1] == "c")
					isCurrency = true;

				minDecPlaces = maxDecPlaces = !!m1[2] ? parseInt(m1[2], 10) : 2; // eg. N equals N2 (like in .NET), if not specified, 2 is default

				if (m1[3])
					maxDecPlaces = parseInt(m1[3])

				if (maxDecPlaces > 15)
					throw new Error("Number format, allowed maxDecPlaces is 15, current: " + maxDecPlaces);
			}
			else if (format.indexOf("#") >= 0 && (m1 = format.match(new RegExp("([\\,\\.]*)([\\#]*)([0]*)([\\,\\.]+)([0]*)([\\#]*)$"))))
			{
				// format pattern ##,##0.##### // 0 is mandatory
				// "###,###,##0.00###".match(new RegExp("([\\,\\.]*)([\\#]*)([0]*)([\\,\\.]+)([0]*)([\\#]*)$"))
				// result: [",###0.00###", ",", "##", "0", ".", "00", "###"]
				let thousandSeparator = m1[1];
				useThousandsSepator = !!thousandSeparator;
				let decimalSeparator = m1[4];
				minDecPlaces = (m1[5] || "").length;
				maxDecPlaces = minDecPlaces + (m1[6] || "").length;
			}
			else
			{
				// unsupported format
				throw new Error("Unsupported number format in Number.ToStringFormated(" + format + ")");
			}

			let rounded = Calysto.Mathm.DecimalRound(_tmpthis, maxDecPlaces);
			let isNegative = rounded < 0;
			let parts = (Math.abs(rounded) + "").split('.'); // ne koristiti value % 1 za extrahiranje decimalnog dijela jer se dobije float infinite number

			let intpart = parts[0];
			let decpart = parts[1] || "";

			while (decpart.length < minDecPlaces)
				decpart += "0";

			// decimal separator
			if (decpart)
				decpart = Calysto.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator + decpart;

			if (useThousandsSepator)
			{
				let arr = intpart.split(""); // split to chars
				let chars1: string[] = [];
				let tmp1;
				while (tmp1 = arr.pop())
				{
					if ((chars1.length + 1) % 4 == 0)
						chars1.unshift(Calysto.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator);

					chars1.unshift(tmp1);
				}
				intpart = chars1.join("");
			}

			let numStr = (isNegative ? "-" : "") + intpart + decpart;

			// final:
			if (isCurrency)
			{
				return Calysto.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyPositivePatternString
					.replace("{CurrencySymbol}", Calysto.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol)
					.replace("{Value}", numStr);
			}
			else
			{
				return numStr;
			}
		}
		else
		{
			throw new Error("NaN or undefined number can not be formated to string");
		}
	};
}

