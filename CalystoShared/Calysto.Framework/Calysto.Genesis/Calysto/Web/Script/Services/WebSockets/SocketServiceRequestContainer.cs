namespace Calysto.Web.Script.Services.WebSockets
{
	public class SocketServiceRequestContainer
	{
		public string Method { get; set; }
		public object RequestObj { get; set; }
		public string ReferenceGuid { get; set; }
		public string EchoMsg { get; set; }
	}
}