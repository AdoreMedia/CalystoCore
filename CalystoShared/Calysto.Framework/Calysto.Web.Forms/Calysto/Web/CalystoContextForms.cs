using Calysto.Common.Extensions;
using Calysto.Utility;
using Calysto.Web.Filter;
using Calysto.Web.Hosting;
using System.Text;

namespace Calysto.Web
{
	public class CalystoContextForms : CalystoContext
	{
		// for unittest only
		static object _rwlock = new object();
		static CalystoContextForms _tmpcx;

		public static CalystoContextForms Current
		{
			get
			{
				if (CalystoTools.IsLocalMachine && CalystoTools.IsUnitTest)
					return _tmpcx ?? (_rwlock.UsingLock(m => _tmpcx ?? (_tmpcx = new CalystoContextForms())));

				return CalystoFormsHostingEnvironment.Current.ContextItemsAccessor.GetValueOrNew(nameof(CalystoContextForms), key => new CalystoContextForms());
			}
		}

		private CalystoContextForms() { }

		static object _rwlock2 = new object();
		ResponseFilterHelper _filter;
		public ResponseFilterHelper ResponseFilter => _filter ?? _rwlock2.UsingLock(k => _filter ?? (_filter = new ResponseFilterHelper()));

		string _distinctHeaders;
		/// <summary>
		/// Create signer with secret based on current browser headers.
		/// </summary>
		public string BrowserDistinctHeaderString => _distinctHeaders ?? (_distinctHeaders = GetBrowserDistinctHeaders());

		private string GetBrowserDistinctHeaders()
		{
			var headers = CalystoFormsHostingEnvironment.Current.HttpContext.Request.Headers;
			StringBuilder sb = new StringBuilder();

			string str1 = headers.Get("Accept-Language");
			if (!string.IsNullOrEmpty(str1))
				sb.Append(str1);

			string str2 = headers.Get("User-Agent");
			if (!string.IsNullOrEmpty(str2))
				sb.Append(str2);

			return sb.ToString();
		}
	}
}
