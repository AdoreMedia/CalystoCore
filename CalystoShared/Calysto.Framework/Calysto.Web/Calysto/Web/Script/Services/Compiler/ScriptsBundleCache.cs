using Calysto.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Calysto.Web.Script.Services.Compiler
{
	public class ScriptsBundleCache
	{
		static ConcurrentDictionary<string, FileCompilerResult> _dicByUniqueKeyResults = new ConcurrentDictionary<string, FileCompilerResult>();
		static ConcurrentDictionary<string, FileCompilerResult> _dicByETagResults = new ConcurrentDictionary<string, FileCompilerResult>();

		internal static FileCompilerResult GetCompilerResultByETag(string etag)
		{
			return _dicByETagResults.GetValueOrDefault(etag);
		}

		internal static FileCompilerResult GetCachedCompilerResult(string uniqueContentKey, Func<FileCompilerResult> fncreate)
		{
			return _dicByUniqueKeyResults.GetOrAdd(uniqueContentKey, (key2) =>
			{
				FileCompilerResult loc = fncreate.Invoke();

				// if we have many files with the same content or empty content, ETag will be the same
				// so test if we already have that etag
				if (!_dicByETagResults.TryGetValue(loc.ETag, out FileCompilerResult existsingLoc))
				{
					_dicByETagResults.TryAdd(loc.ETag, loc);
				}
				else if (loc.MinifiedContent != existsingLoc.MinifiedContent)
				{
					// same ETag already exists, but with different MinifiedContent
					// meaning content hashes are the same for diferent content, probability is very low, but possible
					string guid = Guid.NewGuid().ToString();
					loc.CreateETag(guid);
					// add it, if we still have duplicated ETag, let's throw exception
					_dicByETagResults.TryAdd(loc.ETag, loc);
				}
				else
				{
					// ETag alreay exists in dictionary and contents are equal
				}

				return loc;
			});
		}
	}
}

