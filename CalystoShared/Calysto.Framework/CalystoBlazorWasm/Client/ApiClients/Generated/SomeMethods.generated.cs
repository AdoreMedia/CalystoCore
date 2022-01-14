using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Calysto.Net.WebService;
using Calysto.Blazor.Utility;
using Calysto.Web.Script.Services;

namespace Calysto.Genesis.WebSite.Controllers
{
	public partial class SomeMethodsClient : CalystoAjaxClientBase
	{
		public SomeMethodsClient(BrowserContext browser) : base(browser, "/calysto-handler-ty?calysto-mm=__calysto_method_name__&calysto-um=calysto-X6UuiOpH&calysto-py=gS5IundQrOV7pmVBsSBPbBtBoBdFt6kKgSZKt79Lr6NBsDcKkSZJpkRBt6xLp7cI84dxr7BPt6YKlSlybBtBoBdFt6kI85pBsDdFrSUZciUMbz0Kc2MwgTlIt7lOpjRKpnlQsC5Ib21gtm9IqmdbpnBkrSJBrzRKtmNI&calysto-lc=__calysto_culture__&calysto-ye=__calysto_ss__&calysto-hd=__calysto_current_url____calysto_json_arg__&calysto-ug=")
		{
		}

		public Task<string> GetAgeString(int age)
		{
			CalystoWebMethodAttribute attr = new CalystoWebMethodAttribute();
			return base.MakeRequestAsync<string>(attr, nameof(GetAgeString), new {age});
		}

		public Task<string> GetAgeString2(int age)
		{
			CalystoWebMethodAttribute attr = new CalystoWebMethodAttribute();
			return base.MakeRequestAsync<string>(attr, nameof(GetAgeString2), new {age});
		}

		public Task<string> GetHtmlString(int age)
		{
			CalystoWebMethodAttribute attr = new CalystoWebMethodAttribute();
			return base.MakeRequestAsync<string>(attr, nameof(GetHtmlString), new {age});
		}

	}
}
