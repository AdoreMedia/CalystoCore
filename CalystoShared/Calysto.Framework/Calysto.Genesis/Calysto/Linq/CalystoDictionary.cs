using System;
using System.Collections.Generic;
using System.Linq;

namespace Calysto.Linq
{
	/// <summary>
	/// Thread safe dictionary with null key supported.
	/// </summary>
	public class CalystoDictionary<TKey, TValue>
	{
		private object _objLock = new object();
		private Dictionary<TKey, TValue> _dic = new Dictionary<TKey, TValue>();

		private bool _hasNullKey = false;
		private TValue _nullKeyValue;

		public bool ContainsKey(TKey key)
		{
			lock (_objLock)
			{
				if (key == null) return this._hasNullKey;

				return _dic.ContainsKey(key);
			}
		}

		public void Clear()
		{
			lock(_objLock)
			{
				this._hasNullKey = false;
				this._dic.Clear();
			}
		}

		public IEnumerable<KeyValuePair<TKey, TValue>> AsEnumerable()
		{
			if(this._hasNullKey)
			{
				yield return new KeyValuePair<TKey, TValue>((TKey)(object)null, this._nullKeyValue);
			}
			foreach(var kv in this._dic)
			{
				yield return kv;
			}
		}

		public IEnumerable<TValue> Values => this.AsEnumerable().Select(o => o.Value);

		public IEnumerable<TKey> Keys => this.AsEnumerable().Select(o => o.Key);

		public CalystoDictionary<TKey, TValue> Add(TKey key, TValue value)
		{
			lock (_objLock)
			{
				if (key == null)
				{
					this._hasNullKey = true;
					this._nullKeyValue = value;
				}
				else
				{
					_dic.Add(key, value);
				}
				return this;
			}
		}

		public int Count
		{
			get
			{
				lock (_objLock)
				{
					return _dic.Count + (this._hasNullKey ? 1 : 0);
				}
			}
		}

		public bool Any()
		{
			lock (_objLock)
			{
				return this._hasNullKey || _dic.Any();
			}
		}

		public TValue this[TKey key]
		{
			get
			{
				lock (_objLock)
				{
					if(key == null)
					{
						if (this._hasNullKey)
							return this._nullKeyValue;
						else
							throw new ArgumentOutOfRangeException("Key is not found");
					}

					return _dic[key];
				}
			}
			set
			{
				lock (_objLock)
				{
					if (key == null)
					{
						this._nullKeyValue = value;
					}
					else
					{
						_dic[key] = value;
					}
				}
			}
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			lock (_objLock)
			{
				if (key == null)
				{
					value = this._nullKeyValue;
					return this._hasNullKey;
				}
				else
				{
					return _dic.TryGetValue(key, out value);
				}
			}
		}

		public TValue GetValueOrDefault(TKey key, TValue defaultValue = default(TValue))
		{
			lock(_objLock)
			{
				TValue value;
				if(_dic.TryGetValue(key, out value))
				{
					return value;
				}
				return defaultValue;
			}
		}

	}
}
