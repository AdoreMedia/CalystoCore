namespace Calysto.Net.WebService
{
	export type FNReturnValueCallbackDelegate = (value: any) => void;
	export type FNErrorCallbackDelegate = (errMsg: string, errDetails?: string | object, isServerError?: boolean) => void;
	export type FNResponseReceivedCallbackDelegate<TReturn> = (container: IWebServiceResponseContainerWithReturn<TReturn>) => void;

	export type StateTypeSmall<TReturn> = {
		/** execute before any other callback, if PreventDefault is true, invoke OnEnd and stop processing any more events */
		fnResponseContainerCallback: FNResponseReceivedCallbackDelegate<TReturn>;
		fnResponseEndCallback: () => void,
		fnReturnValueCallback: FNReturnValueCallbackDelegate,
		fnErrorCallback: FNErrorCallbackDelegate,
	};

	export type StateTypeFull = StateTypeSmall<any> & {
		wclient: WebClient,
		responseContainer: IWebServiceResponseContainerWithReturn<any>,
		httpStatus: number,
		isErrorStatus: boolean,
		contentType: string,
		isHtml: boolean,
		isJson: boolean,
		calystoType: string,
		arrayBuffer: ArrayBuffer,
		blob: Blob,
		respTxt: string,
		errorText: string,
		errorDescription: string,
		errorHtml: string
	};
}
