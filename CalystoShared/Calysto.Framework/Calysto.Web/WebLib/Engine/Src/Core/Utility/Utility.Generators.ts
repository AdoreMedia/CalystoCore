namespace Calysto.Utility.Generators
{
	const _smallLetters = "abcdefghijklmnopqrstuvwxyz";

	const _capitalLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

	const _nums = "0123456789";

	const _special = "!@#$%^&*()_+=-~/\][><.,?>:;'\}{";

	function GetRndCharsFromTable(table: string, finalLength: number)
	{
		if (!(finalLength > 0))
			throw new Error("Invalid finalLength in Calysto.Utility.Generators.GetRndCharsFromTable(...)");

		let tlen = table.length;

		if (!(tlen > 0))
			throw new Error("Invalid tlen in Calysto.Utility.Generators.GetRndCharsFromTable(...)");

		let arr: string[] = [];

		while (tlen > 0 && arr.length < finalLength)
		{
			arr.push(table.charAt(Math.floor(Math.random() * tlen)));
		}
		return arr.join("");
	}

	function GetRndChars(finalLength: number, letterFirst = true, smallLetters = true, capitalLetters = true, numbers = true, specialChars = true)
	{
		let arr: string[] = [];
		let table = "";
		if (letterFirst)
			arr.push(GetRndCharsFromTable(_smallLetters + _capitalLetters, 1));

		if (smallLetters)
			table += _smallLetters;

		if (capitalLetters)
			table += _capitalLetters;

		if (numbers)
			table += _nums;

		if (specialChars)
			table += _special;

		arr.push(GetRndCharsFromTable(table, finalLength));

		return arr.join("");
	}

	/**
	* Generate alpha-numeric password. 
    * Always starts with letter.
    * Contains lowercased letters, uppercased letters, and digits, may be used as label of element name.
	* @param length
	*/
	export function GeneratePassword(length: number)
	{
		return GetRndChars(length, true, true, true, true, false);
	}

	/**
	* Generate new strong random password. 
    * Contains lowercased letters, uppercased letters, digits and special chars.
	* @param length
	*/
	export function GenerateStrongPassword(length: number)
	{
		return GetRndChars(length, true, true, true, true, true);
	}

	/**
	 * Generate new numeric password.
	 * @param length
	 */
	export function GenerateNumericPassword(length: number)
	{
		return GetRndCharsFromTable(_nums, length);
	}

	/**
	* Generate alpha-numeric label. 
	* Always starts with letter.
	* Contains lowercased letters, uppercased letters, and digits, may be used as label of element name.
	* @param length
	*/
	export function GenerateLabel(length: number)
	{
		return GetRndChars(length, true, true, true, true, false);
	}

}