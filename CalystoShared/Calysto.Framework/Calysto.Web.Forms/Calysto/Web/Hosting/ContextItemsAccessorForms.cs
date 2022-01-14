using System;
using System.Web;

/**************************************************************
 * We're extracting interface with get properties only 
 * and Current return interface, not the instance,
 * to prevent accidental property assignment.
 * **************************************************************/
namespace Calysto.Web.Hosting
{
	public class ContextItemsAccessorForms : ContextItemsAccessor
	{
		Func<HttpContext> _fnAccessor;
		public ContextItemsAccessorForms(Func<HttpContext> fnContextAccessor)
		{
			_fnAccessor = fnContextAccessor;
		}

		private HttpContext GetContext()
		{
			HttpContext context = _fnAccessor.Invoke();
			if (context == null)
				throw new InvalidOperationException($"{nameof(HttpContext)} not assigned.");
			return context;
		}

		public override void SetValue<TKey, TValue>(TKey key, TValue value)
		{
			this.GetContext().Items[key] = value;
		}

		public override TValue GetValueOrNew<TKey, TValue>(TKey key, Func<TKey, TValue> fnNew = null)
		{
			HttpContext context = this.GetContext();
			var val = context.Items[key];
			if (val == null)
			{
				if (fnNew != null)
					val = fnNew.Invoke(key);

				context.Items[key] = val;
			}
			return val == null ? default(TValue) : (TValue)val;
		}

		public override bool TryGetValue<TKey, TValue>(TKey key, out TValue value)
		{
			value = default;
			object obj1 = this.GetContext().Items[key];
			if (obj1 == null)
				return false;

			value = (TValue)obj1;
			return true;
		}

		public override TReturn UseLockOnContext<TReturn>(Func<TReturn> func)
		{
			HttpContext context = this.GetContext();
			lock (context)
			{
				return func.Invoke();
			}
		}

		public override bool AllowOncePerContext<TKey>(TKey key)
		{
			HttpContext context = this.GetContext();
			lock (context)
			{
				object val1 = context.Items[key];
				if (val1 != null)
					return false; // already exists

				context.Items[key] = true;
				return true;
			}
		}
	}
}
