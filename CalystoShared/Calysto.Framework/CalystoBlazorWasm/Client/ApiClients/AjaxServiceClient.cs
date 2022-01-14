using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Calysto.Web.TestSite.Web.CalystoUI.Ajax
{
	public partial class AjaxServiceClient : IAjaxService
	{
		public override Task BeforeRequestSentAsync(HttpRequestMessage request)
		{
			return base.BeforeRequestSentAsync(request);
		}

		public override Task HeadersReceivedAsync(HttpResponseMessage response)
		{
			return base.HeadersReceivedAsync(response);
		}
	}
}
