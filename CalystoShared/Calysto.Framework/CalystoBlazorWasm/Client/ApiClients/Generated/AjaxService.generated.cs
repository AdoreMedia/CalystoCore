using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Calysto.Net.WebService;
using Calysto.Blazor.Utility;
using Calysto.Web.Script.Services;

namespace Calysto.Web.TestSite.Web.CalystoUI.Ajax
{
	public partial class AjaxServiceClient : CalystoAjaxClientBase
	{
		public AjaxServiceClient(BrowserContext browser) : base(browser, "/calysto-handler-ty?calysto-mm=__calysto_method_name__&calysto-um=calysto-X6UuiOpH&calysto-py=gS5IundQrOVnpm8Kl6lPt5dFt6kKlSlybAdxr7BPt6ZliiV1qC5UbA5Gonxjpn9SqmdBb213omNVsThLbBtBoyVnpm9jqnhBb21mpn9PqmZKfj4Kc2UMbz0I84dRr7hRsCkZrClRt79xr2Mwk7lyr6BziSlVl6ZHpmUZrDlIr0&calysto-lc=__calysto_culture__&calysto-ye=__calysto_ss__&calysto-hd=__calysto_current_url____calysto_json_arg__&calysto-ug=")
		{
		}

		public Task<string> AjaxSend(string msg, Calysto.Web.CalystoBlob[] files)
		{
			CalystoWebMethodAttribute attr = new CalystoWebMethodAttribute();
			attr.Timeout = 5000;
			return base.MakeRequestAsync<string>(attr, nameof(AjaxSend), new {msg, files});
		}

		public Task<string> AjaxSendThrow()
		{
			CalystoWebMethodAttribute attr = new CalystoWebMethodAttribute();
			attr.SessionState = true;
			return base.MakeRequestAsync<string>(attr, nameof(AjaxSendThrow), new {});
		}

		public Task<string> InvokeAjaxError()
		{
			CalystoWebMethodAttribute attr = new CalystoWebMethodAttribute();
			return base.MakeRequestAsync<string>(attr, nameof(InvokeAjaxError), new {});
		}

		public Task<Calysto.Web.CalystoBlob> DownloadBlob()
		{
			CalystoWebMethodAttribute attr = new CalystoWebMethodAttribute();
			return base.MakeRequestAsync<Calysto.Web.CalystoBlob>(attr, nameof(DownloadBlob), new {});
		}

		public Task<IEnumerable<Calysto.Web.CalystoBlob>> DownloadBlobArray()
		{
			CalystoWebMethodAttribute attr = new CalystoWebMethodAttribute();
			return base.MakeRequestAsync<IEnumerable<Calysto.Web.CalystoBlob>>(attr, nameof(DownloadBlobArray), new {});
		}

		public Task<System.DateTime> SendClientDateTime(System.DateTime dt)
		{
			CalystoWebMethodAttribute attr = new CalystoWebMethodAttribute();
			return base.MakeRequestAsync<System.DateTime>(attr, nameof(SendClientDateTime), new {dt});
		}

		public Task<Calysto.Web.TestSite.Web.CalystoUI.Ajax.BinaryFrameObj> DownloadBinaryFrameObject()
		{
			CalystoWebMethodAttribute attr = new CalystoWebMethodAttribute();
			return base.MakeRequestAsync<Calysto.Web.TestSite.Web.CalystoUI.Ajax.BinaryFrameObj>(attr, nameof(DownloadBinaryFrameObject), new {});
		}

		public Task<Calysto.Web.CalystoBlob[]> DownloadBlobArrayError()
		{
			CalystoWebMethodAttribute attr = new CalystoWebMethodAttribute();
			return base.MakeRequestAsync<Calysto.Web.CalystoBlob[]>(attr, nameof(DownloadBlobArrayError), new {});
		}

		public Task<Calysto.Web.CalystoBlob> DownloadBlobError()
		{
			CalystoWebMethodAttribute attr = new CalystoWebMethodAttribute();
			return base.MakeRequestAsync<Calysto.Web.CalystoBlob>(attr, nameof(DownloadBlobError), new {});
		}

		public Task Javascript1()
		{
			CalystoWebMethodAttribute attr = new CalystoWebMethodAttribute();
			return base.MakeRequestAsync<System.Threading.Tasks.Task>(attr, nameof(Javascript1), new {});
		}

	}
}
