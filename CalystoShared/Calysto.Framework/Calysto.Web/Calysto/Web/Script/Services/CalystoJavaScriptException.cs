namespace Calysto.Web.Script.Services
{
	//class CalystoJavascriptException : Exception
	//{
	//	public CalystoJavascriptException(string msg)
	//		: base(msg)
	//	{ }

	//	public CalystoJavascriptException(string msg, Exception ex)
	//		: base(msg, ex)
	//	{ }
	//}

	public class CalystoJavaScriptException
	{
		public bool rxExObj;
		public string errMsg;
		public string errDetails;
		public string url;
		public string cookie;
		public string screen;
		public string location;
		public string navigator;
		public string userAgent;
		public string inputValues;
	}
}
