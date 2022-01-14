using Calysto.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;

/**************************************************************
 * We're extracting interface with get properties only 
 * and Current return interface, not the instance,
 * to prevent accidental property assignment.
 * **************************************************************/
namespace Calysto.Web.Hosting
{
	/// <summary>
	/// Variables has to be initialized in Startup.cx
	/// </summary>
	public class CalystoFormsHostingEnvironment : CalystoHostingEnvironment
	{
		public static new CalystoFormsHostingEnvironment Current => (CalystoFormsHostingEnvironment)CalystoHostingEnvironment.Current;

		public void SetPrivateValue<TValue>(Expression<Func<CalystoFormsHostingEnvironment, TValue>> pathSelector, TValue value)
		{
			var path1 = new MemberPropertyPathExtractor<CalystoFormsHostingEnvironment>();
			string pathStr = path1.GetPath(pathSelector);
			Calysto.Data.CalystoDataBinder.Private.SetValue(this, pathStr, value);
		}

		private ContextItemsAccessor _accessor;
		public override ContextItemsAccessor ContextItemsAccessor => _accessor ?? (_accessor = new ContextItemsAccessorForms(() => this.HttpContext));

		public HttpContext HttpContext => HttpContext.Current; // at Unittest there is no context

		private BrowserCompression _browserCompression;

		public BrowserCompression BrowserCompression => _browserCompression
			?? (_browserCompression = BrowserCompression.Detect(this.HttpContext.Request.Headers["Accept-Encoding"] + ""));

		private CalystoUri _hostingAbsoluteUri;

		public override CalystoUri HostingAbsoluteUri => _hostingAbsoluteUri ?? (this.HttpContext == null ? null : (_hostingAbsoluteUri = new CalystoUriForms(this.HttpContext)));

	}
}
