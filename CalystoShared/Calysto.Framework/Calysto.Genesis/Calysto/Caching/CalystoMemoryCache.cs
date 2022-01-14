using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Calysto.Threading;
using System.Threading;
using Calysto.Common;
using System.Net.Http.Headers;
using System.Collections.Concurrent;
using Calysto.Common.Extensions;

namespace Calysto.Caching
{
	/// <summary>
	/// Thread safe cahe provider.
	/// </summary>
	/// <typeparam name="TKey"></typeparam>
	/// <typeparam name="TValue"></typeparam>
	public class CalystoMemoryCache<TKey, TValue> : IDisposable
	{
		public class CacheItem
		{
			DateTime? _expirationDate;
			bool _isSlidingExpiration;
			TimeSpan? _cacheDuration;
			CalystoMemoryCache<TKey, TValue> _owner;
			
			public TKey Key { get; set; }
			public TValue Value { get; set; }

			public CacheItem(CalystoMemoryCache<TKey, TValue> owner, TKey key, TValue value, TimeSpan? cacheDuration, bool isSlidingExpiration)
			{
				_owner = owner;
				_isSlidingExpiration = isSlidingExpiration;
				_cacheDuration = cacheDuration;
				this.Key = key;
				this.Value = value;
			}

			/// <summary>
			/// if it is sliding expiration, will increase expiration date, else will leave expiration date unchanged
			/// </summary>
			public void AdjustExpiration()
			{
				if (_cacheDuration.HasValue)
				{
					// adjust cache expiration on first invocation
					// if it is sliding expiration, adjust cache expiration every time
					if (_isSlidingExpiration || _expirationDate == null)
					{
						_expirationDate = DateTime.Now.Add(_cacheDuration.Value);
					}
				}
			}

			public bool IsExpired => this._expirationDate != null && this._expirationDate < DateTime.Now;

			public void RemoveFromCache()
			{
				_owner.Remove(this.Key);
			}
		}

		public event Action<CacheItem> OnItemRemoved;

		/// <summary>
		/// Contains all items, with and without expiration
		/// </summary>
		private Dictionary<TKey, CacheItem> _dicCacheItems = new Dictionary<TKey, CacheItem>();

		/// <summary>
		/// Contains expiration items only for faster enumeration by the cleaner.
		/// </summary>
		private Dictionary<TKey, CacheItem> _expirationItems = new Dictionary<TKey, CacheItem>();

		public bool IsDisposed { get; private set; }

		public void Dispose()
		{
			this.IsDisposed = true;
			this._timer?.Stop();
			this.Clear();
		}

		~CalystoMemoryCache()
		{
			this.Dispose();
		}

		public CalystoMemoryCache()
		{
		}

		System.Timers.Timer _timer;

		private void EnsureTimerStarted()
		{
			if(_timer?.Enabled != true)
			{
				lock(this)
				{
					if(_timer?.Enabled != true)
					{
						_timer = new System.Timers.Timer(15000);
						_timer.Elapsed += _timer_Elapsed;
						_timer.AutoReset = true;
						_timer.Start();
					}
				}
			}
		}

		private void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			lock (this)
			{
				this._expirationItems.Where(o => o.Value.IsExpired).ToList().ForEach(o => o.Value.RemoveFromCache());
			}
		}

		public bool ContainsKey(TKey key) => this.UsingLock(o => o._dicCacheItems.ContainsKey(key));

		public int Count => this.UsingLock(o=>o._dicCacheItems.Count);

		/// <summary>
		/// Clear compelte cache.
		/// </summary>
		/// <returns></returns>
		public void Clear()
		{
			lock (this)
			{
				this._dicCacheItems.Clear();
				this._expirationItems.Clear();
			}
			GC.Collect();
		}

		/// <summary>
		/// Remove item from cache and invoke OnItemRemoved.
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public void Remove(TKey key)
		{
			CacheItem cc1;

			lock (this)
			{
				if (this._dicCacheItems.TryGetValue(key, out cc1))
				{
					this._dicCacheItems.Remove(key);
					this._expirationItems.Remove(key);
				}
			}

			if (this.OnItemRemoved != null && cc1 != null)
			{
				try { this.OnItemRemoved.Invoke(cc1); }
				catch { }
			}
		}

		/// <summary>
		/// Will overwrite previous value by the key.
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value"></param>
		/// <param name="expiration"></param>
		/// <param name="isSlidingExpiration"></param>
		/// <returns></returns>
		public void SetValue(TKey key, TValue value, TimeSpan? expiration = null, bool isSlidingExpiration = false)
		{
			lock (this)
			{
				CacheItem ci = new CacheItem(this, key, value, expiration, isSlidingExpiration);
				this._dicCacheItems[key] = ci;

				if (expiration != null)
				{
					this._expirationItems[key] = ci;
					this.EnsureTimerStarted();
				}

				ci.AdjustExpiration();

			}
		}

		/// <summary>
		/// Try get cached value and adjust expiration if item exists.
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public bool TryGetValue(TKey key, out TValue value)
		{
			if (this._dicCacheItems.TryGetValue(key, out CacheItem cc))
			{
				// item found
				if (cc.IsExpired)
				{
					cc.RemoveFromCache();
					cc = null;
				}
				else
				{
					cc.AdjustExpiration();
				}
			}

			if (cc == null)
			{
				value = default;
				return false;
			}
			else
			{
				value = cc.Value;
				return true;
			}
		}

		/// <summary>
		/// Get value or default if not found
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public TValue GetValue(TKey key, TValue defaultValue = default)
		{
			if (this.TryGetValue(key, out TValue value))
				return value;
			else
				return defaultValue;
		}

		/// <summary>
		/// No locking. Get value if exists, else create new one using fnCreateNew, add value to cache and return value.
		/// </summary>
		/// <param name="key"></param>
		/// <param name="fnCreateNew"></param>
		/// <param name="expiration"></param>
		/// <param name="isSlidingExpiration"></param>
		/// <returns></returns>
		public TValue GetValueOrNewNoLocking(TKey key, Func<TValue> fnCreateNew, TimeSpan? expiration = null, bool isSlidingExpiration = false)
		{
			if(!this.TryGetValue(key, out TValue value))
			{
				value = fnCreateNew.Invoke();
				this.SetValue(key, value, expiration, isSlidingExpiration);
			}
			return value;
		}
	}
}
