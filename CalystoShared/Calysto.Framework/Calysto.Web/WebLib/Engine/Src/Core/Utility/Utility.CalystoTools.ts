namespace Calysto.Utility.CalystoTools
{
	export function LongToByteArray(longNum: number, truncateEmptyBytes?: boolean)
	{
		/// <summary>
		/// LSB is first
		/// </summary>
		/// <param name="longNum" type="type"></param>
		/// <param name="truncateEmptyBytes" type="Boolean" optional="true">if true, will truncate unused bytes</param>
		/// <returns type=""></returns>
		// we want to represent the input as a n-bytes array
		if (!(longNum > 0 || longNum === 0))
		{
			throw new Error("LongToByteArray argument may not be negative");
		}
		var byteArray: number[] = [];
		for (var index = 0; index < 8; index++)
		{
			var b1 = longNum & 0xff;
			if (truncateEmptyBytes && Math.pow(2, index * 8) > longNum)
			{
				if (b1 > 0 || byteArray.length == 0) byteArray.push(b1);
				break;
			}
			else
			{
				byteArray.push(b1);
				longNum = (longNum - b1) / 256;
			}
		}

		return byteArray;
	}

	export function ByteArrayToLong(byteArray: number[] | Uint8Array)
	{
		/// <summary>
		/// LSB is first
		/// </summary>
		/// <param name="byteArray" type="type"></param>
		/// <returns type=""></returns>
		var value = 0;
		for (var i = byteArray.length - 1; i >= 0; i--)
		{
			value = (value * 256) + byteArray[i];
		}

		return value;
	}
}

