using Calysto.IO;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace Calysto.AspNetCore
{
	public class StaticFileCache
	{
		MemoryCache _cache;

		private StaticFileCache()
		{
			MemoryCacheOptions options = new MemoryCacheOptions();
			_cache = new MemoryCache(options);
		}

		public static StaticFileCache Cache = new StaticFileCache();

		public bool TryGetValue(string key, out CalystoFileInfo value)
		{
			return _cache.TryGetValue(key, out value);
		}

		public CalystoFileInfo GetOrCreate(string key, Func<ICacheEntry, CalystoFileInfo> fn)
		{
			return _cache.GetOrCreate(key, fn);
		}

	}
}
