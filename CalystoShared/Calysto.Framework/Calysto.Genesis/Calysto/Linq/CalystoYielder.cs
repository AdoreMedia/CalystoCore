using System;
using System.Collections.Generic;
using System.Linq;

namespace Calysto.Linq
{
	/// <summary>
	/// Thread safe yielder. All member functions are thread safe.
	/// </summary>
	public class CalystoYielder<TItem> : CalystoStatisticsProvider
	{
		public class CalystoYieldResult
		{
			public CalystoYielder<TItem> Yielder { get; private set; }
			public TItem Item { get; private set; }
			public CalystoYielderStatisticsItem GetStatisticsItem() => this.Yielder.GetStatisticsItem();
			public string StatisticsString => this.GetStatisticsItem().ToStringFormated();
			public int AttemptsCount{ get; internal set; }
			public bool IsCancelYielding { get; set; }

			public CalystoYieldResult(CalystoYielder<TItem> owner, TItem item)
			{
				this.Yielder = owner;
				this.Item = item;
			}

			/// <summary>
			/// Return to yielder and retry up to maxRetryCount. Return true if it is set for retry, return false if will not retry any more.
			/// </summary>
			/// <param name="maxRetryCount"></param>
			/// <returns></returns>
			public bool RetryMax(int? maxRetryCount = null)
			{
				if (maxRetryCount > 0)
				{
					lock (this.Yielder)
					{
						if (this.AttemptsCount <= maxRetryCount)
						{
							this.Yielder._innerList.Add(this);
							return true;
						}
					}
				}
				else if (maxRetryCount == null)
				{
					lock (this.Yielder)
					{
						this.Yielder._innerList.Add(this);
						return true;
					}
				}

				return false;
			}
		}

		private List<CalystoYieldResult> _innerList = new List<CalystoYieldResult>();

		/// <summary>
		/// Total items left for processing.
		/// </summary>
		public override int CountLeft => this.Count;

		public CalystoYielder(IEnumerable<TItem> collection)
		{
			_innerList.AddRange(collection.Select(o => new CalystoYieldResult(this, o)));
			this.CountTotal = _innerList.Count;
		}

		public CalystoYielder<TItem> Append(TItem item)
		{
			lock (this)
			{
				_innerList.Add(new CalystoYieldResult(this, item));
				this.CountTotal++;
			}
			return this;
		}

		/// <summary>
		/// Clone collection to List.
		/// </summary>
		/// <returns></returns>
		public List<TItem> ToList()
		{
			lock (this)
			{
				return _innerList.Select(o=>o.Item).ToList();
			}
		}

		public bool Any()
		{
			lock(this)
			{
				return _innerList.Any();
			}
		}

		public int Count
		{
			get
			{
				lock (this)
				{
					return _innerList.Count;
				}
			}
		}

		public bool Yield(out CalystoYieldResult result)
		{
			lock (this)
			{
				if (!_innerList.Any())
				{
					result = null;
					return false; // return false from here
				}
				else
				{
					result = _innerList[0];
					_innerList.RemoveAt(0);
					result.AttemptsCount++;

					if (!this.TimeStart.HasValue) this.TimeStart = DateTime.Now;
					++this.CountTaken;
					return true;
				}
			}
		}

		/// <summary>
		/// Yield all available elements, one by one, and invoke action for each of them.
		/// May be invoked from different threads on the same Yielder instance.
		/// </summary>
		/// <param name="action"></param>
		public void YieldAll(Action<CalystoYieldResult> action)
		{
			bool isCancelYielding = false;
			while (!isCancelYielding && this.Yield(out var res))
			{
				action.Invoke(res);
				if (res.IsCancelYielding)
				{
					isCancelYielding = res.IsCancelYielding;
				}
			}
		}

	}
}
