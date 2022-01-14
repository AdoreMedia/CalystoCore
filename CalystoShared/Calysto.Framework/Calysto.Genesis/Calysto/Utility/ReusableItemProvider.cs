using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calysto.Utility
{
	public class ReusableItemProvider<TItem>
	{
		class ReusableState
		{
			public ReusableState(Func<TItem> fnCreateItem)
			{
				Item = fnCreateItem.Invoke();
				IsBussy = true;
			}
			public readonly TItem Item;
			public bool IsBussy;
		}

		Func<TItem> _fnCreateItem;

		public ReusableItemProvider(Func<TItem> fnCreateItem)
		{
			_fnCreateItem = fnCreateItem;
		}

		List<ReusableState> _list = new List<ReusableState>();

		public class StateItem : IDisposable
		{
			public TItem Item { get; private set; }
			Action _fnRelease;
			public void Dispose()
			{
				this.Item = default;
				_fnRelease?.Invoke();
				_fnRelease = null;
			}
			public StateItem(TItem item, Action release)
			{
				this.Item = item;
				_fnRelease = release;
			}
		}

		public StateItem GetItem()
		{
			lock (this)
			{
				var state = _list.Where(o => !o.IsBussy).FirstOrDefault();
				if (state == null)
				{
					state = new ReusableState(_fnCreateItem);
					_list.Add(state);
				}
				state.IsBussy = true;
				return new StateItem(state.Item, () => state.IsBussy = false);
			}
		}
	}
}
