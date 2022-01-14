using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Calysto.Linq
{
	public class CalystoSortedRangeLookup<TKey, TItem>
	{
		Func<TItem, TKey> _minKeySelector;
		Func<TItem, TKey> _maxKeySelector;
		CalystoSortedLookup<TKey, TItem> _minKeyLookup;
		CalystoSortedLookup<TKey, TItem> _maxKeyLookup;

		public int Count => _minKeyLookup.Count;

		public CalystoSortedRangeLookup(IEnumerable<TItem> list, Func<TItem, TKey> minKeySelector, Func<TItem, TKey> maxKeySelector)
		{
			// use sortedList.Comparer to compare keys
			// Comparer.Compare(smaller, greater) returns -1 if correct, 0 if equals, 1 if not correct
			SortedList<TKey, TItem> sortedList = new SortedList<TKey, TItem>();

			// ako je list enumerable, moramo imati instancirane objekte tako da imamo 1 referencu za obje min i max liste
			// select items where minkey <= maxkey only
			var list1 = list.Where(o=>sortedList.Comparer.Compare(minKeySelector(o), maxKeySelector(o)) <= 0).ToList();
			
			_minKeySelector = minKeySelector;
			_maxKeySelector = maxKeySelector;
			_minKeyLookup = new CalystoSortedLookup<TKey, TItem>(list1, minKeySelector);
			_maxKeyLookup = new CalystoSortedLookup<TKey, TItem>(list1, maxKeySelector);
		}

		public void Add(TItem item)
		{
			_minKeyLookup.Add(item);
			_maxKeyLookup.Add(item);
		}

		public IEnumerable<TItem> WhereKeyRangeContains(TKey searchKey)
		{
			// index where item key >= searchKey
			var pos1 = _minKeyLookup.FindKeyPosition(searchKey);
			int index1 = pos1?.ExactKeyIndex ?? pos1?.HigherKeyIndex ?? -1;
			if (index1 == -1)
				yield break;

			// ending nodes
			var endingNodesDic = _minKeyLookup.InnerList.Values[index1].ToDictionary(o => o);

			// index where item key <= searchKey
			var pos2 = _maxKeyLookup.FindKeyPosition(searchKey);
			int index2 = pos2?.ExactKeyIndex ?? pos2?.LowerKeyIndex ?? -1;
			if (index2 == -1)
				yield break;

			TKey minKey, maxKey;
			int res1, res2, cnt1 = 0, cnt2 = _maxKeyLookup.Count;

			for (int n1 = index2; n1 < cnt2 && endingNodesDic.Any(); n1++)
			{
				maxKey = _maxKeyLookup.InnerList.Keys[n1];
				res1 = _maxKeyLookup.InnerList.Comparer.Compare(searchKey, maxKey); // returns value depending on which argument is smaller(-1, 1)
				if (res1 <= 0)
				{
					foreach (var item2 in _maxKeyLookup.InnerList.Values[n1])
					{
						endingNodesDic.Remove(item2);

						minKey = _minKeySelector(item2);
						res2 = _maxKeyLookup.InnerList.Comparer.Compare(minKey, searchKey); // returns value depending on which argument is smaller(-1, 1)
						if(res2 <= 0)
						{
							yield return item2;
						}
					}
				}
				else if(cnt1++ > 2)
				{
					// for safety, prevent endless loop
					break;
				}
			}
		}

		public IEnumerable<TItem> WhereKeyRangeContains(TKey minKey, TKey maxKey)
		{
			var en1 = this.WhereKeyRangeContains(minKey);
			var en2 = this.WhereKeyRangeContains(maxKey);
			return en1.Intersect(en2);
		}
	}
}
