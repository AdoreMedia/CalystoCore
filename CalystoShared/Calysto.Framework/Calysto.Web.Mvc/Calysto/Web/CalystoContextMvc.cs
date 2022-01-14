using Calysto.AspNetCore.Middlewares;
using Calysto.AspNetCore.Mvc.Razor;
using Calysto.AspNetCore.Mvc.Razor.Templating;
using Calysto.Common.Extensions;
using Calysto.Utility;
using Calysto.Web.Filter;
using Calysto.Web.Hosting;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System;
using System.Text;

namespace Calysto.Web
{
	public class CalystoContextMvc : CalystoContext
	{
		// for unittest only
		static object _rwlock = new object();
		static CalystoContextMvc _tmpcx;

		public static CalystoContextMvc Current
		{
			get
			{
				if (CalystoTools.IsLocalMachine && CalystoTools.IsUnitTest)
					return _tmpcx ?? (_rwlock.UsingLock(m => _tmpcx ?? (_tmpcx = new CalystoContextMvc())));

				return CalystoMvcHostingEnvironment.Current.ContextItemsAccessor.GetValueOrNew(nameof(CalystoContextMvc), key => new CalystoContextMvc());
			}
		}

		private CalystoContextMvc() { }

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
			var headers = CalystoMvcHostingEnvironment.Current.HttpContext.Request.Headers;
			StringBuilder sb = new StringBuilder();

			if (headers.TryGetValue(HeaderNames.AcceptLanguage, out var value))
				sb.Append(value.ToString());

			if (headers.TryGetValue(HeaderNames.UserAgent, out value))
				sb.Append(value.ToString());

			return sb.ToString();
		}
	}
}
