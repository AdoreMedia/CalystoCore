using Calysto.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Calysto.Web.UI.Direct
{
	public class CalystoDirectQueryBuilder
	{
		private string _rootSelector;
		public CalystoDirectQueryBuilder(string rootSelector = null)
		{
			_rootSelector = rootSelector;
		}

		private List<string> _items = new List<string>();

		public CalystoDirectQueryBuilder UseDirectQuery(string calystoSelector, Action<CalystoDirectQuery> action)
		{
			if (_rootSelector != null)
			{
				CalystoDirectQuery query = CalystoDirectQuery.FromSelector(_rootSelector).Query("*, //*").Query(calystoSelector);
				action.Invoke(query);
				_items.Add(query.ToJavaScript());
			}
			else
			{
				CalystoDirectQuery query = CalystoDirectQuery.FromSelector(calystoSelector);
				action.Invoke(query);
				_items.Add(query.ToJavaScript());
			}
			return this;
		}

		public string ToJavaScript()
		{
			return _items.Where(o => !string.IsNullOrWhiteSpace(o)).ToStringJoined();
		}
	}

}
