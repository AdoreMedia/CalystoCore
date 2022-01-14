namespace Calysto.Net.WebService
{
	export interface IWebServiceResponseContainerWithReturn<TReturn> extends IWebServiceResponseContainer
	{
		/** value returned from Method on server */
		ReturnedValue: TReturn;
	};
}
