namespace Calysto
{
	export class KeyValue<TKey, TValue>
	{
		public Key: TKey;
		public Value: TValue;

		constructor(key: TKey, value: TValue)
		{
			this.Key = key;
			this.Value = value;
		}
	}

	export class Dictionary<TKey, TValue>
	{
		private _map: Map<TKey, TValue> = new Map();

		constructor()
		{
		}

		public AsEnumerable()
		{
			return CalystoEnumerable.From(() => function* (__this)
			{
				for (let kv of __this._map.entries())
					yield new KeyValue<TKey, TValue>(kv[0], kv[1]);
			}(this));
		}

		public GetItems(): KeyValue<TKey, TValue>[]
		{
			return this.AsEnumerable().ToArray();
		}

		public ToRawObject(errorOnDuplicateKey?: boolean)
		{
			var d = {};
			// key must be string, since key in {} is always string
			// dic[1] = "test"; dic[1] returns "test", but ["1"] returns "test" too, which means that key is converted into string by JS engine
			this.GetItems().ForEach(o =>
			{
				let keyStr = o.Key + "";

				if (errorOnDuplicateKey && d[keyStr] != undefined)
					throw new Error("Duplicated key: " + o.Key);

				d[keyStr] = o.Value;
			});
			return d;
		}

		public Clear()
		{
			this._map.clear();
		}

		public RemoveKey(key: TKey)
		{
			this._map.delete(key);
		}

		public GetValues(): TValue[]
		{
			return this.AsEnumerable().Select(o => o.Value).ToArray();
		}

		public GetKeys(): TKey[]
		{
			return this.AsEnumerable().Select(o => o.Key).ToArray();
		}

		public Count(): number
		{
			return this._map.size;
		}

		public ContainsKey(key: TKey): boolean
		{
			return !!this._map.has(key);
		}

		private AddKeyValue(kv: KeyValue<TKey, TValue>)
		{
			return this.Add(kv.Key, kv.Value);
		}

		public Add(key: TKey, value: TValue): Dictionary<TKey, TValue>
		{
			if (this._map.has(key))
			{
				throw Error("Duplicated key: " + key);
			}
			this._map.set(key, value);
			return this;
		}

		public SetValue(key: TKey, value: TValue): Dictionary<TKey, TValue>
		{
			this._map.set(key, value);
			return this;
		}

		public TryGetValue(key: TKey, refOut: BoxValue<TValue>): boolean
		{
			if (this._map.has(key))
			{
				refOut.SetValue(<TValue>this._map.get(key));
				return true;
			}
			return false;
		}

		public GetValue(key: TKey): TValue
		{
			var refOut = new BoxValue<TValue>();
			if (this.TryGetValue(key, refOut))
			{
				return refOut.GetValue();
			}
			throw new Error("Key not found: " + key);
		}

		public GetValueOrDefault(key: TKey, defaultValue?: TValue): TValue
		{
			var refOut = new BoxValue<TValue>();
			if (this.TryGetValue(key, refOut))
			{
				return refOut.GetValue();
			}
			return <TValue>defaultValue;
		}

	}
}