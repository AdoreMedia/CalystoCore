namespace Calysto.Enum
{
	/**
	 * Get numeric value.
	 * @param {TEnum} objEnum
	 * @param {string} name
	 * @returns
	 */
	export function GetValue<TEnum>(objEnum: TEnum, name: string): TEnum
	{
		var val = (<any>objEnum)[name];
		if (Calysto.Type.TypeInspector.IsNumber(val)) return val;
		throw new Error("enum name not found: " + name);
	}

	/**
	 * Get values as number[]
	 * @param {TEnum} objEnum
	 * @returns
	 */
	export function GetValues<TEnum>(objEnum: TEnum): TEnum[]
	{
		var arr: any[] = [];
		Calysto.Collections.ForEachOwnProperties(objEnum, (name, value, index) =>
		{
			if (typeof (value) == "number") arr.push(value);
		});
		return arr;
	}

	/**
	 * Test if numeric value exists in enum.
	 * @param {TEnum} objEnum
	 * @param {number} value
	 * @returns
	 */
	export function HasValue<TEnum>(objEnum: TEnum, value: number): boolean
	{
		var val = (<any>objEnum)[value];
		if (Calysto.Type.TypeInspector.IsString(val)) return true;
		return false;
	}

	/**
	 * Test if name exists in enum.
	 * @param {TEnum} objEnum
	 * @param {string} name
	 * @returns
	 */
	export function HasName<TEnum>(objEnum: TEnum, name: string): boolean
	{
		var val = (<any>objEnum)[name];
		if (Calysto.Type.TypeInspector.IsNumber(val)) return true;
		return false;
	}

	/**
	 * Get name as string from it's numeric value.
	 * @param {TEnum} objEnum
	 * @param {number} value
	 * @returns
	 */
	export function GetName<TEnum>(objEnum: TEnum, value: number): string
	{
		var val = (<any>objEnum)[value];
		if (Calysto.Type.TypeInspector.IsString(val)) return val;
		throw new Error("enum value not found: " + value);
	}

	/**
	 * Get names as string[].
	 * @param {TEnum} objEnum
	 * @returns
	 */
	export function GetNames<TEnum>(objEnum: TEnum): string[]
	{
		var arr: string[] = [];
		Calysto.Collections.ForEachOwnProperties(objEnum, (name, value, index) =>
		{
			if (typeof (value) == "string") arr.push(value);
		});
		return arr;
	}
}
