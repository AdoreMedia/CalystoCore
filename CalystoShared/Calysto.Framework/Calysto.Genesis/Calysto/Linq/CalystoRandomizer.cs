using Calysto.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Calysto.Linq
{
	/// <summary>
	/// Randomizer with probability settings.
	/// </summary>
	/// <typeparam name="TElement"></typeparam>
	public class CalystoRandomizer<TElement>
	{
		private class CalystoRndItem
		{
			public TElement Element;
			public double Probability;

			public CalystoRndItem(TElement element, double probability)
			{
				this.Element = element;
				this.Probability = probability;
			}
		}

		IEnumerable<CalystoRndItem> _items;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="source"></param>
		/// <param name="probabilitySelector">if null, will use default probability 1</param>
		public CalystoRandomizer(IEnumerable<TElement> source, Func<TElement, double> probabilitySelector = null)
		{
			if (probabilitySelector == null) probabilitySelector = item => 1; // default probability is 1
			this._items = source.Select(o => new CalystoRndItem(o, probabilitySelector.Invoke(o)));
		}

		/// <summary>
		/// Yield randomly sorted elements with probability greater than 0 and respecting probability.
		/// </summary>
		/// <param name="allowRepeating">allow repeating the same element endlessly</param>
		/// <returns></returns>
		public IEnumerable<TElement> SelectRandom(bool allowRepeating)
		{
			CalystoRandom rnd1 = new CalystoRandom();
			// create items copy
			var list = _items.Where(o=>o.Probability > 0).ToList();
			// sum all
			double sumAll = list.Sum(o => o.Probability);

			while (list.Any())
			{
				double threshold = rnd1.NextDouble() * sumAll;
				double tmpSum = 0;
				var item = list.SkipWhile(o => (tmpSum += o.Probability) <= threshold).First();
				yield return item.Element;
				if (!allowRepeating)
				{
					list.Remove(item);
					// item was removed, calculate sum again
					sumAll = list.Sum(o => o.Probability);
				}
			}
		}
	}
}