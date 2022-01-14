using Calysto.Serialization.Json;
using Calysto.Serialization.Json.Core.Serialization;
using Calysto.Timers;
using Calysto.Web.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.WebSockets;

namespace Calysto.Web.Script.Services.WebSockets
{
	public class WebSocketServiceForms: WebSocketService
	{
		HttpContext Context;

		public WebSocketServiceForms(HttpContext context, Type targetType, bool isReloadRequired)
		{
			this.Context = context;
			this.TargetType = targetType;
			this.IsReloadRequired = isReloadRequired;
		}

		internal void Start()
		{
			Task.Run(() =>
			{
				this.Context.AcceptWebSocketRequest(this.AcceptCallbackAsync);
			}).Wait();
		}

		private async Task AcceptCallbackAsync(AspNetWebSocketContext socketContext)
		{
			this.WebSocket = socketContext.WebSocket;
			await this.ProcessWebSocketRequestAsync();
		}

		protected override void MarkWebSocket()
		{
			CalystoContextForms.Current.Request.IsCalystoWebSocketRequest = true;
		}

		protected override void MarkDiagnostic(string jsonStr, List<CalystoBlob> blobs, string method)
		{
			CalystoContextForms.Current.Request.Diagnostic.CALYSTO_JSON_RECEIVED = jsonStr;
			CalystoContextForms.Current.Request.Diagnostic.CALYSTO_BLOBS_COUNT = (blobs == null ? 0 : blobs.Count) + "";
			CalystoContextForms.Current.Request.Diagnostic.CALYSTO_SERVICE_METHOD = method;
		}

		protected override async Task<CalystoResponse> InvokeMethodAsync(IWebSocketSession webSocketSessionInstance, AjaxQueryStringHelper astr, CalystoRequest request1, CalystoResponse response1)
		{
			return await new CalystoAjaxHandlerForms(null).ProcessRequestAsync(webSocketSessionInstance, astr, request1, response1);
		}

	}
}