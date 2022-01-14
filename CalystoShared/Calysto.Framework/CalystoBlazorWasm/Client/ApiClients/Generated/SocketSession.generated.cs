using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Calysto.Net.WebService;
using Calysto.Blazor.Utility;
using Calysto.Web.Script.Services;

namespace Calysto.Web.TestSite.Web.CalystoUI.Sockets
{
	public partial class SocketSessionClient : CalystoSocketClientBase<string>
	{
		public SocketSessionClient(BrowserContext browser) : base(browser, "/calysto-handler-ty?calysto-mm=__calysto_method_name__&calysto-um=calysto-X6UuiOpH&calysto-py=gS5IundQrOVnpm8Kl6lPt5dFt6kKlSlybAdxr7BPt6ZliiVjrSdHpnhPbBdLoSJBt5dBsTdFrSUI84dxr7BPt6YKlSlybBtBoBdFt6kI85pBsDdFrSUZciUMbz0Kc2MwgTlIt7lOpjRKpnlQsC5Ib21gtm9IqmdbpnBkrSJBrzRKtmNI&calysto-lc=__calysto_culture__&calysto-ye=__calysto_ss__&calysto-hd=__calysto_current_url____calysto_json_arg__&calysto-ug=")
		{
		}

		public Task<Calysto.Web.TestSite.Web.CalystoUI.Sockets.SocketResponse1> HelloWorld(string text, Calysto.Web.CalystoBlob[] blob)
		{
			CalystoWebMethodAttribute attr = new CalystoWebMethodAttribute();
			return base.MakeRequestAsync<Calysto.Web.TestSite.Web.CalystoUI.Sockets.SocketResponse1>(attr, nameof(HelloWorld), new {text, blob});
		}

		public Task SocketErrorTest(string name, string prezime, int age, Calysto.Web.CalystoBlob[] blob)
		{
			CalystoWebMethodAttribute attr = new CalystoWebMethodAttribute();
			return base.MakeRequestAsync<System.Threading.Tasks.Task>(attr, nameof(SocketErrorTest), new {name, prezime, age, blob});
		}

		public Task<string> SetHelloString(string text)
		{
			CalystoWebMethodAttribute attr = new CalystoWebMethodAttribute();
			return base.MakeRequestAsync<string>(attr, nameof(SetHelloString), new {text});
		}

		public Task SocketSendToAll(string text)
		{
			CalystoWebMethodAttribute attr = new CalystoWebMethodAttribute();
			return base.MakeRequestAsync<System.Threading.Tasks.Task>(attr, nameof(SocketSendToAll), new {text});
		}

	}
}
