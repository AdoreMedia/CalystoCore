using System;
using System.Collections.Generic;

namespace Calysto.Linq
{
	public class CalystoSortedLookup<TKey, TItem>
	{
		public class KeyPosition
		{
			public int? ExactKeyIndex;
			public int? LowerKeyIndex;
			public int? HigherKeyIndex;

			SortedList<TKey, List<TItem>> _sortedList;
			Func<TItem, TKey> _keySelector;

			public KeyPosition(SortedList<TKey, List<TItem>> sortedList, Func<TItem, TKey> keySelector)
			{
				_sortedList = sortedList;
				_keySelector = keySelector;
			}

			public KeyPosition SetExactKeyIndex(int? exactIndex)
			{
				this.ExactKeyIndex = exactIndex;
				return this.SetKeyIndex(exactIndex - 1, exactIndex + 1);
			}

			public KeyPosition SetKeyIndex(int? lowerIndex, int? higherIndex)
			{
				if(lowerIndex >= 0)
					this.LowerKeyIndex = lowerIndex;

				if (higherIndex < _sortedList.Count)
					this.HigherKeyIndex = higherIndex;

				return this;
			}
		}

		SortedList<TKey, List<TItem>> _sortedList;
		Func<TItem, TKey> _keySelector;

		public int Count => _sortedList.Count;

		public SortedList<TKey, List<TItem>> InnerList => _sortedList;

		public CalystoSortedLookup(IEnumerable<TItem> list, Func<TItem, TKey> keySelector)
		{
			_keySelector = keySelector;
			_sortedList = new SortedList<TKey, List<TItem>>();
			foreach(var item in list)
			{
				this.Add(item);
			}
		}

		public void Add(TItem item)
		{
			TKey key1 = _keySelector(item);
			if (!_sortedList.TryGetValue(key1, out List<TItem> list))
			{
				list = new List<TItem>();
				_sortedList.Add(key1, list);
			}
			list.Add(item);
		}

		/// <summary>
		/// Returns index where item key is less than <paramref name="searchKey"/><br/>
		/// </summary>
		public KeyPosition FindKeyPosition(TKey searchKey)
		{
			KeyPosition position1 = new KeyPosition(_sortedList, _keySelector);

			if (_sortedList.Count == 0)
				return position1;

			int exactIndex = _sortedList.IndexOfKey(searchKey);
			if (exactIndex >= 0)
				return position1.SetExactKeyIndex(exactIndex);

			int upperIndex = _sortedList.Count - 1;
			int lowerIndex = 0;
			int currentIndex = -1;
			int tempIndex = -1;

			while (true)
			{
				// buduci da se int dijeli s int, uvijek ce se dobivati nizi index, tako da ce i rezultat na kraju imati tendenciju odabira nizeg indexa
				tempIndex = lowerIndex + (upperIndex - lowerIndex) / 2;
				if (tempIndex == currentIndex)
				{
					// ponavlja se isti index
					int res3 =  _sortedList.Comparer.Compare(_sortedList.Keys[currentIndex], searchKey); // (smaller, larger), -1: true, 0: equal, 1: false
					if (res3 > 0)
						return position1.SetKeyIndex(currentIndex - 1, currentIndex); // Keys[currentIndex] > searchKey
					else if (res3 < 0)
						return position1.SetKeyIndex(currentIndex, currentIndex + 1); // Keys[currentIndex] < searchKey
					else
						return position1.SetExactKeyIndex(currentIndex); // Keys[currentIndex] == searchKey
				}
				else
				{
					currentIndex = tempIndex;
				}

				TKey tmp1 = _sortedList.Keys[currentIndex];
				int res1 = _sortedList.Comparer.Compare(tmp1, searchKey); // (smaller, larger), -1: true, 0: equal, 1: false
				if (res1 > 0) // searchValue > tmp1
				{
					upperIndex = currentIndex;
				}
				else if (res1 < 0) // searchValue < tmp1
				{
					lowerIndex = currentIndex;
				}
				else
				{
					// tmp1 == value
					return position1.SetExactKeyIndex(currentIndex);
				}
			}
		}

		/// <summary>
		/// Search for items where key is between minValueInclusive and maxValueInclusive.
		/// </summary>
		/// <param name="minValueInclusive"></param>
		/// <param name="maxValueInclusive"></param>
		/// <returns></returns>
		public IEnumerable<TItem> WhereKeyInRange(TKey minValueInclusive, TKey maxValueInclusive)
		{
			var pos1 = this.FindKeyPosition(minValueInclusive);
			int startIndex = pos1?.ExactKeyIndex ?? pos1.LowerKeyIndex ?? pos1.HigherKeyIndex ?? -1;
			if(startIndex == -1)
				yield break;

			TKey tmpKey;
			int res1, res2, cnt1 = 0, cnt2 = _sortedList.Count;

			for (int n1 = startIndex; n1 < cnt2; n1++)
			{
				tmpKey = _sortedList.Keys[n1];
				res1 = _sortedList.Comparer.Compare(minValueInclusive, tmpKey); // (smaller, larger) return -1: true, 0: equal, 1: false
				if (res1 <= 0)
				{
					// tmpKey is equal or larger than minValueInclusive
					res2 = _sortedList.Comparer.Compare(tmpKey, maxValueInclusive);
					if (res2 <= 0)
					{
						foreach (var item in _sortedList.Values[n1])
						{
							yield return item;
						}
					}
					else
					{
						// tmpKey > maxValueInclusive
						break;
					}
				}
				else if(cnt1++ > 2)
				{
					// for safety, to prevent endless loop
					// comes here if tmpKey < minValueInclusive, it may occure only once at start
					// if comes here multiple times, it is error
					break;
				}
			}
		}
	}
}
