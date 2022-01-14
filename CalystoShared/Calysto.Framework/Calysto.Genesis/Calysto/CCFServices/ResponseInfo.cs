using Calysto.Common;

namespace Calysto.CCFServices
{
	public class ResponseInfo
	{
		public string SessionId { get; set; }

		public string RequestId { get; set; }

		public object ReturnValue { get; set; }

		public CalystoExceptionNode Error { get; set; }
		public ActionEnum Action { get; set; }
		public string MethodName { get; set; }
	}
}
