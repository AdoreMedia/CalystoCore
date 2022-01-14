interface ICalystoException
{
	/**
		* short message
	*/
	Message: string;
	/**
		* detailed message used in debug mode
	*/
	Details: string;
	/**
		* details from server
	*/
	HtmlDetails: string;
	/**
		* true if exception was thrown on server
	*/
	IsServerError: boolean;
}

interface Error
{
	CalystoException: ICalystoException;

	AppendErrorDetails(additionalInfo?: Object | String | Array<any>, isServerError?: boolean): Error;

	ToErrorEvent(): ErrorEvent;
}

if (typeof (Error) != "undefined")
{
	Error.prototype.ToErrorEvent = function ()
	{
		return <ErrorEvent>{
			error: this,
			message: this.message
		};
	};

	Error.prototype.AppendErrorDetails = function (additionalInfo, isServerError)
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="additionalInfo" type="String|Object|Array" optional="true"></param>
		/// <param name="isServerError" type="Boolean" optional="true">if true exception received from server, will not create JS call stack and will not send to Elmah on server</param>

		var detailsArr: any[] = [];
		var htmlArr: any[] = [];
		if (additionalInfo)
		{
			try
			{
				if (typeof (additionalInfo) == "string")
				{
					detailsArr.push(additionalInfo);
				}
				else if ("length" in additionalInfo) // moze i dom array
                {
                    Calysto.Collections.ForEach(<any[]>additionalInfo, (item, index) => detailsArr.push(item));
				}
				else
				{
                    Calysto.Collections.ForEachProperties(additionalInfo, (name, value, index) =>
					{
						if (name == "errorHtml")
						{
							htmlArr.push(value);
						}
						else if (name == "errorDescription")
						{
							detailsArr.push(value);
						}
						else
						{
							detailsArr.push(name + ": " + value)
						}
					});
				}
			}
			catch (ex2)
			{ }
		}

		this.CalystoException = {
			// string - short message
			Message: this.message,
			// string - detailed message used in debug mode
			Details: detailsArr.join("\r\n"),
			// string - details from server
			HtmlDetails: htmlArr.join("<br/>"),
			// bool - true if exception was thrown on server
			IsServerError: !!isServerError
		};

		return this;
	}
}
