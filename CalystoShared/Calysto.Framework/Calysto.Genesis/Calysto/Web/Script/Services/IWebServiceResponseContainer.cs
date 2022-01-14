namespace Calysto.Web.Script.Services
{
	public interface IWebServiceResponseContainer
	{
		bool IsSuccessful { get; set; }

		/** may have value "IWebServiceResponseContainer" */
		string Type { get; set; }

		bool IsEngineExpired { get; set; }

		string JavaScriptLO { get; set; }

		/** short message */
		string ExceptionMessage { get; set; }

		/** detailed message */
		string ExceptionDetails { get; set; }

		object ReturnedValue { get; set; }

		/** method name on server */
		string Method { get; set; }

		/**unique message reference*/
		string ReferenceGuid { get; set; }

		/** socket echo message */
		string EchoMsg { get; set; }
	};

	public interface IWebServiceResponseContainerWithReturn<TReturn>: IWebServiceResponseContainer
	{
		/** value returned from Method on server */
		new TReturn ReturnedValue { get; set; }
	};
}