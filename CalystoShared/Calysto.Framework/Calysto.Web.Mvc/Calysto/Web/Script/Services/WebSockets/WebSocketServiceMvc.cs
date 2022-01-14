using Calysto.Serialization.Json;
using Calysto.Serialization.Json.Core.Serialization;
using Calysto.Timers;
using Calysto.Web.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace Calysto.Web.Script.Services.WebSockets
{
	public class WebSocketServiceMvc : WebSocketService
	{
		HttpContext Context;

		public WebSocketServiceMvc(HttpContext context, Type targetType, bool isReloadRequired)
		{
			this.Context = context;
			this.TargetType = targetType;
			this.IsReloadRequired = IsReloadRequired;
		}

		internal void Start()
		{
			Task.Run(async () =>
			{
				this.WebSocket = await this.Context.WebSockets.AcceptWebSocketAsync();
				await this.ProcessWebSocketRequestAsync();
			}).Wait();
		}

		protected override void MarkWebSocket()
		{
			CalystoContextMvc.Current.Request.IsCalystoWebSocketRequest = true;
		}

		protected override void MarkDiagnostic(string jsonStr, List<CalystoBlob> blobs, string method)
		{
			CalystoContextMvc.Current.Request.Diagnostic.CALYSTO_JSON_RECEIVED = jsonStr;
			CalystoContextMvc.Current.Request.Diagnostic.CALYSTO_BLOBS_COUNT = (blobs == null ? 0 : blobs.Count) + "";
			CalystoContextMvc.Current.Request.Diagnostic.CALYSTO_SERVICE_METHOD = method;
		}

		protected override async Task<CalystoResponse> InvokeMethodAsync(IWebSocketSession webSocketSessionInstance, AjaxQueryStringHelper astr, CalystoRequest request1, CalystoResponse response1)
		{
			return await new CalystoAjaxHandlerMvc(null).ProcessRequestAsync(webSocketSessionInstance, astr, request1, response1);
		}

	}
}