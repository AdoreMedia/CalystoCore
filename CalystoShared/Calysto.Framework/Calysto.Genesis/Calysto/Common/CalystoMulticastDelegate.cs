using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Calysto.Common
{
	public class CalystoMulticastDelegate2<TDelegate> : IDisposable
	{
		List<TDelegate> _handlers = new List<TDelegate>();

		public void Add(TDelegate fn)
		{
			lock(this)
				_handlers.Add(fn);
		}

		public void Remove(TDelegate fn)
		{
			lock(this)
				_handlers.Remove(fn);
		}

		private List<TDelegate> GetSafeCopy()
		{
			lock (this)
				return _handlers.ToList();
		}

		public void Invoke(Action<TDelegate> action)
		{
			this.GetSafeCopy().ForEach(d => action.Invoke(d));
		}

		public Task Invoke(Func<TDelegate, Task> action)
		{
			var tasks = this.GetSafeCopy().Select(d => action.Invoke(d)).ToList();
			return Task.WhenAll(tasks);
		}

		public bool Any()
		{
			lock(this)
				return _handlers.Any();
		}

		public int Count()
		{
			lock(this)
				return _handlers.Count;
		}

		public void Clear()
		{
			lock (this)
				_handlers.Clear();
		}

		public bool IsDisposed { get; private set; }

		public void Dispose()
		{
			lock (this)
				_handlers.Clear();

			if (this.IsDisposed) return;
			this.IsDisposed = true;
		}

		~CalystoMulticastDelegate2() => this.Dispose();
	}
}
