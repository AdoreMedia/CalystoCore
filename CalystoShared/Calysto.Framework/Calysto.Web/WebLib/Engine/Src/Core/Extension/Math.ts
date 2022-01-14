if (!Math["trunc"])
{
	Math["trunc"] = (x: number) =>
	{
		// IE doesn't have trunc
		if (isFinite(x) && !isNaN(x))
		{
			return parseInt((x + "").split(".")[0], 10);
		}
		else
		{
			return x;
		}
	};
}
