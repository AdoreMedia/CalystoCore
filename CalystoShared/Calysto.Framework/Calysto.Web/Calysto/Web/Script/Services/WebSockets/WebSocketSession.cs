using Calysto.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Calysto.Web.Script.Services.WebSockets
{
	public class WebSocketSession<TBroadcastMessage> : IWebSocketSession
	{
		public bool IsDisposed { get; private set; }
		public void Dispose()
		{
			if (!this.IsDisposed)
			{
				this.IsDisposed = true;
				try { this.OnClose(); } catch { }
				try { this.Service?.Dispose(); } catch { }
			}
		}

		~WebSocketSession() => this.Dispose();

		public WebSocketService Service { get; set; }

		public virtual void OnOpen()
		{
		}

		public virtual void OnClose()
		{

		}

		public async Task BroadcastResponse(ListenersKind kind, Action<CalystoResponse> action)
		{
			var listeners = this.Service.GetListeners(kind);
			if (listeners.Count > 0)
			{
				CalystoResponse response = new CalystoResponse().SetMethodName(Calysto.Utility.CalystoConstants.BroadcastMethodName);
				action.Invoke(response);
				ArraySegment<byte> respBuffer = response.ToArraySegmentCompiled();
				await listeners.SendAsync(respBuffer);
			}
		}

		/// <summary>
		/// Send value to all listerners
		/// </summary>
		/// <param name="fnGetValue">function which returns value to be set, fn is invoked once and only if there is listerens to be sent to</param>
		public async Task BroadcastMessage(ListenersKind kind, Func<TBroadcastMessage> fnGetValue)
		{
			await this.BroadcastResponse(kind, a => a.SetReturnValue(fnGetValue.Invoke()));
		}
	}
}
