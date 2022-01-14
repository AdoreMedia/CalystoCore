using Calysto.Caching;
using Calysto.Linq.Expressions;
using Calysto.Utility;
using Calysto.Web.Script.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

/**************************************************************
 * We're extracting interface with get properties only 
 * and Current return interface, not the instance,
 * to prevent accidental property assignment.
 * **************************************************************/
namespace Calysto.Web.Hosting
{
	public abstract class ContextItemsAccessor
	{
		public abstract TValue GetValueOrNew<TKey, TValue>(TKey key, Func<TKey, TValue> fnNew = null);

		public abstract bool TryGetValue<TKey, TValue>(TKey key, out TValue value);

		public abstract void SetValue<TKey, TValue>(TKey key, TValue value);

		public abstract TReturn UseLockOnContext<TReturn>(Func<TReturn> func);

		public abstract bool AllowOncePerContext<TKey>(TKey key);
	}

	/// <summary>
	/// Variables has to be initialized in Startup.cx
	/// </summary>
	public abstract class CalystoHostingEnvironment
	{
		private static CalystoHostingEnvironment _current;
		public static CalystoHostingEnvironment Current
		{
			get => _current;
			set
			{
				if (_current != null)
					throw new InvalidOperationException("CalystoHostingEnvironment.Current is already intialized.");

				_current = value;
			}
		}

		public void SetPrivateValue<TValue>(Expression<Func<CalystoHostingEnvironment, TValue>> pathSelector, TValue value)
		{
			var path1 = new MemberPropertyPathExtractor<CalystoHostingEnvironment>();
			string pathStr = path1.GetPath(pathSelector);
			Calysto.Data.CalystoDataBinder.Private.SetValue(this, pathStr, value);
		}

		public abstract ContextItemsAccessor ContextItemsAccessor { get; }

		//public CalystoPhysicalPaths PathProvider { get; protected set; }

		///// <summary>
		///// Physical content root with ending back slash \\
		///// </summary>
		//public string ContentRootPath { get; protected set; }

		///// <summary>
		///// Physical web root with ending slash \\
		///// </summary>
		//public string WebRootPath { get; protected set; }

		public CalystoMemoryCache<object, object> CacheProvider { get; } = new CalystoMemoryCache<object, object>();

		public static CalystoUri GetUnittest2CalystoUri() => CalystoTools.IsUnitTest ? new CalystoUri("https://unit.test.server/") { PathBase = "/utest-base-path" } : null;

		/// <summary>
		/// https://www.server.com/pathBase
		/// Has to be initialized when context is available.
		/// </summary>
		public virtual CalystoUri HostingAbsoluteUri { get; }

		public bool IsHosted => this.ContextItemsAccessor != null || this.HostingAbsoluteUri != null;

		public event Action<object, Func<CalystoJavaScriptException>> OnWriteElmahError;

		public void NotifyJavaScriptError(object sender, Func<CalystoJavaScriptException> func) => this.OnWriteElmahError?.Invoke(sender, func);

		public event Action<object, Func<Exception>> OnException;

		public void NotifyException(object sender, Func<Exception> ex) => OnException?.Invoke(sender, ex);

		public event Action<object, Func<string>> OnLog;

		public void NotifyLog(object sender, Func<string> msg) => OnLog?.Invoke(sender, msg);

		/// <summary>
		/// IIS App pool name.
		/// </summary>
		public string AppPoolName => Environment.GetEnvironmentVariable("APP_POOL_ID");

		/// <summary>
		/// IIS App pool configuration file location.
		/// </summary>
		public string AppPoolConfigPath => Environment.GetEnvironmentVariable("APP_POOL_CONFIG");

		/// <summary>
		/// IIS Environment, e.g. Development
		/// </summary>
		public string AspNetCoreEnvironment => Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
	}
}
