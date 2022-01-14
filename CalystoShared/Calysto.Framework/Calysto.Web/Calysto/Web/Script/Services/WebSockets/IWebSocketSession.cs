using System;

namespace Calysto.Web.Script.Services.WebSockets
{
	public interface IWebSocketSession : IDisposable
	{
		void OnClose();
		void OnOpen();
		WebSocketService Service { get; set; }
	}
}
