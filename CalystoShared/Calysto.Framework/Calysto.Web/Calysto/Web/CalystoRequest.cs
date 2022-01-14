using Calysto.Linq;
using Calysto.Web.Hosting;
using System.Collections.Generic;

namespace Calysto.Web
{
	public class CalystoRequest
	{
		public class RequestDiagnostic
		{
			Dictionary<string, string> Items;

			public RequestDiagnostic()
			{
				ContextItemsAccessor _accessor = CalystoHostingEnvironment.Current.ContextItemsAccessor;
				// CalystoRequestDiagnostic used in Elmah to write diagnostic data.
				this.Items = _accessor.GetValueOrNew("CalystoRequestDiagnostic", key => new Dictionary<string, string>());
			}

			public string CALYSTO_JSON_RECEIVED { set { Items[nameof(CALYSTO_JSON_RECEIVED)] = value; } }
			public string CALYSTO_BLOBS_COUNT { set { Items[nameof(CALYSTO_BLOBS_COUNT)] = value; } }
			public string CALYSTO_SERVICE_VPATH { set { Items[nameof(CALYSTO_SERVICE_VPATH)] = value; } }
			public string CALYSTO_SERVICE_METHOD { set { Items[nameof(CALYSTO_SERVICE_METHOD)] = value; } }
			public string CALYSTO_FULLMETHOD { set { Items[nameof(CALYSTO_FULLMETHOD)] = value; } }
		}

		/// <summary>
		/// Used in Elmah to write diagnostic data.
		/// </summary>
		public readonly RequestDiagnostic Diagnostic = new RequestDiagnostic();

		public bool IsCalystoWebSocketRequest { get; internal set; }
	}
}
