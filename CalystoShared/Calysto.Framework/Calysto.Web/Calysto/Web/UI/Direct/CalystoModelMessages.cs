using Calysto.Extensions;
using Calysto.Linq;
using Calysto.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Calysto.Web.UI.Direct
{
	public class CalystoModelMessages<TModel>
	{
		string _propertyPath;
		CalystoHtmlBuilder _htmlBuilder;
		public CalystoModelMessages(Expression<Func<TModel, object>> selector, CalystoHtmlBuilder htmlBuilder)
		{
			_propertyPath = new MemberPropertyPathExtractor<TModel>().GetPath(selector);
			_htmlBuilder = htmlBuilder;
		}

		public string ToJavaScript()
		{
			string html = _htmlBuilder.ToHtml();

			return CalystoDirectQuery.FromSelector($"[name={_propertyPath}]")
				.ReplaceChildren(html)
				.AddClass("calysto-visible", !string.IsNullOrWhiteSpace(html))
				.ToJavaScript();
		}

	}
}
