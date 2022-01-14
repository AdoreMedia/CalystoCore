interface Boolean
{
	/**
	 * returns string true or false
	 */
	ToStringFormated(): string;
}

if (!Boolean.prototype.ToStringFormated)
{
	Boolean.prototype.ToStringFormated = function ()
	{
		/// <summary>
		/// returns text "true" or "false"
		/// </summary>
		return this == true ? "true" : "false"; // use ==, DO NOT use === because on IE8 type is nt the same for: this === true
	};
}

