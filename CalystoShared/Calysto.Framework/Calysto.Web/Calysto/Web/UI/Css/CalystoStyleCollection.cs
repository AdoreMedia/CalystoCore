using System.Collections.Generic;
using System.Linq;
using Calysto.Linq;

namespace Calysto.Web.UI.Css
{
	public class CalystoStyleCollection
	{
		List<KeyValuePair<string, string>> _items = new List<KeyValuePair<string,string>>();

		public CalystoStyleCollection()
		{

		}

		public CalystoStyleCollection(List<KeyValuePair<string, string>> style)
		{
			this.ApplyValues(style);
		}

		public int Count { get { return _items.Count; } }

		public CalystoStyleCollection Clone()
		{
			return new CalystoStyleCollection() { _items = this._items.Select(o => new KeyValuePair<string, string>(o.Key, o.Value)).ToList() };
		}

		public IEnumerable<KeyValuePair<string,string>> AsEnumerable()
		{
			foreach (var item in this._items)
			{
				yield return new KeyValuePair<string, string>(item.Key, item.Value);
			}
		}

		public CalystoStyleCollection ApplyValues(List<KeyValuePair<string, string>> style)
		{
			var forRemoval = _items.Intersect(style, (a, b) => a.Key == b.Key).ToList();
			forRemoval.ForEach(o => _items.Remove(o));
			style.ForEach(o =>_items.Add(o));
			return this;
		}

		public CalystoStyleCollection ApplyValues(string styleValues)
		{
			this.ApplyValues(CalystoWebTools.ParseCssStyleValues(styleValues));
			return this;
		}

		public CalystoStyleCollection ApplyValues(CalystoStyleCollection style)
		{
			this.ApplyValues(style.AsEnumerable().ToList());
			return this;
		}

		public string this[string propertyName]
		{
			get { return _items.Where(o => o.Key == propertyName).Select(o=>o.Value).FirstOrDefault(); }
			set
			{
				var forRemoval = _items.Where(o => o.Key == propertyName).ToList();
				forRemoval.ForEach(o => _items.Remove(o));
				_items.Add(new KeyValuePair<string, string>(propertyName, value));
			}
		}

	}
}
