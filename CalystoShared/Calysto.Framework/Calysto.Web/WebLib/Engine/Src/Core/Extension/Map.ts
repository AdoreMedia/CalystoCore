namespace Calysto
{
	// IE11, IE10, IE9 tested to work
	// required for generators function*(){}
	if (!window.Symbol)
	{
		let fn1 = <any>function () { };
		fn1.iterator = {};
		window.Symbol = <any>fn1;
	}
	
	class CalystoMapInternal<TKey, TValue>
	{
		public constructor()
		{
		}

		public get size() { return this._kvArr.length; }

		private _kvArr: { key: TKey, value: TValue }[] = [];

		public has(key: TKey) { return this._kvArr.AsEnumerable().Where(o => o.key === key).Any(); }

		public get(key: TKey) { return this._kvArr.AsEnumerable().Where(o => o.key === key).Select(o => o.value).FirstOrDefault(); }

		public set(key: TKey, value: TValue)
		{
			let kv = this._kvArr.AsEnumerable().Where(o => o.key === key).FirstOrDefault();
			if (kv)
				kv.value = value;
			else
				this._kvArr.push({ key: key, value: value });
			return this;
		}

		// "window.Set" specific
		public add(key: TKey, value?: any) { return this.set(key, value || true); }

		public delete(key: TKey)
		{
			let kv = this.get(key);
			this._kvArr.RemoveBy(o => o.key == key);
			return !!kv;
		}

		public clear() { this._kvArr.Clear();}

		public * keys()
		{
			for (let item of this._kvArr)
				yield item.key;
		}

		public * entries()
		{
			for (let item of this._kvArr)
				yield [item.key, item.value];
		}
	}

	// IE <= 10 doesn't have Map
	// IE <= 11 doesn't have entries and keys
	// IE11 has Map, but it has no entries, no keys and not iterable
	if (!(window.Map?.prototype?.entries))
	{
		window["Set"] = <any>CalystoMapInternal;
		window["Map"] = <any>CalystoMapInternal;
	}
}
