namespace Calysto.Net.WebService
{
	export interface ISocketWebRequestArguments
	{
		/** ajax request over socket*/
		IsSocketWebClient: boolean;

		/** used for ajax request over socket */
		AjaxQueryString?: string;

		/** used for ajax request over socket */
		AjaxArgs: { [x: string]: object };
	}

}
