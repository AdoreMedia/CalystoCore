namespace Calysto.Net.WebService
{
	/** C# postoji class WebServiceSettings */
	export interface IWebServiceSettings
	{
		/** [int] ms, default 90000 */
		timeoutMs?: number;

		/** [bool] use asp.net session state */
		sstate?: boolean;

		/**
			[bool] If true, will not count ajax request and none of events connected with count will not be invoked
			e.g. (Calysto.Page.OnLoading, Calysto.Page.OnBeginRequest, Calysto.Page.OnEndRequest).
		*/
		silent?: boolean;

		/** string[], method arguments names: ["arg1", "arg2", etc]*/
		argNames?: string[];

		/** [string] method name*/
		method: string;

		/** [bool] if true, method may be invoked only on user event on client */
		reque?: boolean;

		/** [bool] if true, will always use POST to send data to server */
		post?: boolean;
	}
}
