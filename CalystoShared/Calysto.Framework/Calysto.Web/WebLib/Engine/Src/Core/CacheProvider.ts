namespace Calysto.CacheProvider
{
	interface CachedItem
	{
		/** cached content */
		Content: any;
		/** absolute expiration at ticks */
		Expiration: number;
		/** sliding duration seconds */
		SlidingDuration: number;
	}

	function AdjustExpiration(item: CachedItem)
	{
		if (item.SlidingDuration > 0)
			item.Expiration = Math.round(Date.now() + (1000 * item.SlidingDuration));
	}

	function IsExpired(item: CachedItem)
	{
		return item.Expiration && item.Expiration < Date.now();
	}

	/**
	 * Set item into storage.
	 * @param storage Storage to be used: localStorage or sessionStorage
	 * @param key cache key
	 * @param item item to be cached
	 * @param expirationAfterSeconds
	 * @param slidingDurationSeconds item will expire if not used more than x seconds
	 */
	export function Set<TContent>(storage: Storage, key: string, item: TContent, expirationAfterSeconds?: number, slidingDurationSeconds?: number)
	{
		var expires = expirationAfterSeconds ? Math.round(Date.now() + (1000 * expirationAfterSeconds)) : null;

		let cached1 = <CachedItem>{
			Content: item,
			Expiration: expires,
			SlidingDuration: slidingDurationSeconds
		};

		AdjustExpiration(cached1);

		let json1 = JSON.stringify(cached1);
		storage.setItem(key, json1);
	}

	export function Get<TContent>(storage: Storage, key: string) : TContent
	{
		let json1 = storage.getItem(key);
		if (json1)
		{
			let cached1: CachedItem = JSON.parse(json1);
			if (!IsExpired(cached1))
			{
				AdjustExpiration(cached1);
				return <TContent> cached1.Content;
			}
			else
				storage.removeItem(key);
		}
		return <any>undefined;
	}

	export function Remove(storage: Storage, key: string)
	{
		storage.removeItem(key);
	}

	export function Clear(storage: Storage)
	{
		storage.clear();
	}
}
