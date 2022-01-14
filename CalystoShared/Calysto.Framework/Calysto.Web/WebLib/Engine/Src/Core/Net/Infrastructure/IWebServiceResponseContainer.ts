namespace Calysto.Net.WebService
{
	/** istoimeni tip postoji u C# */
	export interface IWebServiceResponseContainer
	{
		/** true if server method invoked without exception thrown, returning void or value */
		IsSuccessful?: boolean;

		/** "IWebServiceResponseContainer" */
		Type?: "IWebServiceResponseContainer";

		/** */
		IsEngineExpired?: boolean;

		////JavaScriptHI?: string; // not used any more

		/**execute javascript */
		JavaScriptLO?: string;

		/** once the JavaScriptLO is used, mark it as done to prevent double execution */
		IsJavaScriptLODone: boolean;

		/** short message */
		ExceptionMessage?: string;

		/** once the ExceptionMessage is used, mark it as done to prevent double execution */
		IsExceptionMessageDone: boolean;

		/** detailed message */
		ExceptionDetails?: string;

		/** method name on server */
		Method?: string;

		/**unique message reference */
		ReferenceGuid: string;

		/** socket echo message */
		EchoMsg: string;
	}
}
