using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Calysto.Net.WebService;
using Calysto.Blazor.Utility;
using Calysto.Web.Script.Services;

namespace Calysto.Web.TestSite.Web.VS.Home
{
	public partial class HomeControllerClient : CalystoAjaxClientBase
	{
		public HomeControllerClient(BrowserContext browser) : base(browser, "/calysto-handler-ty?calysto-mm=__calysto_method_name__&calysto-um=calysto-X6UuiOpH&calysto-py=gS5IundQrOVnpm8Kl6lPt5dFt6kKlSlybBpjbAxLrmkKi6ZJpkdLrDhOrSNIpn8I84dxr7BPt6YKlSlybBtBoBdFt6kI85pBsDdFrSUZciUMbz0Kc2MwgTlIt7lOpjRKpnlQsC5Ib21gtm9IqmdbpnBkrSJBrzRKtmNI&calysto-lc=__calysto_culture__&calysto-ye=__calysto_ss__&calysto-hd=__calysto_current_url____calysto_json_arg__&calysto-ug=")
		{
		}

		public Task<string> CheckLoginModel(Calysto.Web.TestSite.Web.VS.Home.Models.LoginViewModel model)
		{
			CalystoWebMethodAttribute attr = new CalystoWebMethodAttribute();
			return base.MakeRequestAsync<string>(attr, nameof(CheckLoginModel), new {model});
		}

		public Task<string> GetAgeString1(int age)
		{
			CalystoWebMethodAttribute attr = new CalystoWebMethodAttribute();
			return base.MakeRequestAsync<string>(attr, nameof(GetAgeString1), new {age});
		}

		public Task<string> GetAgeString2(int age)
		{
			CalystoWebMethodAttribute attr = new CalystoWebMethodAttribute();
			return base.MakeRequestAsync<string>(attr, nameof(GetAgeString2), new {age});
		}

		public Task<string> GetHtmlString1(int age)
		{
			CalystoWebMethodAttribute attr = new CalystoWebMethodAttribute();
			return base.MakeRequestAsync<string>(attr, nameof(GetHtmlString1), new {age});
		}

		public Task<string> GetHtmlString2(int age)
		{
			CalystoWebMethodAttribute attr = new CalystoWebMethodAttribute();
			return base.MakeRequestAsync<string>(attr, nameof(GetHtmlString2), new {age});
		}

		public Task<string> GetHtmlString3(int age)
		{
			CalystoWebMethodAttribute attr = new CalystoWebMethodAttribute();
			return base.MakeRequestAsync<string>(attr, nameof(GetHtmlString3), new {age});
		}

	}
}
