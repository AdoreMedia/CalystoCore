namespace Calysto.Net.WebService
{
	/** u C# postoji class SocketServiceRquestContainer */
	export interface ISocketServiceRequestContainer
	{
		/** method name */
		Method: string;

		/** object to send */
		RequestObj: any;

		/**unique message reference */
		ReferenceGuid: string;

		/** socket echo message */
		EchoMsg: string;
	}
}
