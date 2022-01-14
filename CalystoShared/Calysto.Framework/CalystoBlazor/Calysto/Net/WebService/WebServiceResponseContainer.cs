using Calysto.Web.Script.Services;

namespace Calysto.Net.WebService
{
	class WebServiceResponseContainer : IWebServiceResponseContainer
	{
		public bool IsSuccessful { get; set; }
		public string Type { get; set; }
		public bool IsEngineExpired { get; set; }
		public string JavaScriptLO { get; set; }
		public string ExceptionMessage { get; set; }
		public string ExceptionDetails { get; set; }
		public object ReturnedValue { get; set; }
		public string Method { get; set; }
		public string ReferenceGuid { get; set; }
		public string EchoMsg { get; set; }
	}

	class WebServiceResponseContainerWithReturn<TReturn> : WebServiceResponseContainer, IWebServiceResponseContainerWithReturn<TReturn>
	{
		public new TReturn ReturnedValue { get; set; }
	}
}
