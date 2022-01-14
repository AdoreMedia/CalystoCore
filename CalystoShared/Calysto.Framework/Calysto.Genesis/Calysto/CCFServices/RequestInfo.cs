namespace Calysto.CCFServices
{
	public class RequestInfo
	{
		public string SessionId { get; set; }

		public string MethodName { get; set; }
		
		public object[] Arguments { get; set; }
		
		public bool UseSession { get; set; }
		
		public string RequestId { get; set; }
		
		public ActionEnum Action { get; set; }
	}
}
