using Microsoft.AspNetCore.Http;
using System;

/**************************************************************
 * We're extracting interface with get properties only 
 * and Current return interface, not the instance,
 * to prevent accidental property assignment.
 * **************************************************************/
namespace Calysto.Web.Hosting
{
	public class ContextItemsAccessorMvc : ContextItemsAccessor
	{
		Func<HttpContext> _fnAccessor;
		public ContextItemsAccessorMvc(Func<HttpContext> fnContextAccessor)
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

		public override TValue GetValueOrNew<TKey, TValue>(TKey key, Func<TKey, TValue> fnNew = null)
		{
			HttpContext context = this.GetContext();
			if (!context.Items.TryGetValue(key, out var val))
			{
				if (fnNew != null)
					val = fnNew.Invoke(key);

				context.Items[key] = val;
			}
			return val == null ? default(TValue) : (TValue)val;
		}

		public override void SetValue<TKey, TValue>(TKey key, TValue value)
		{
			this.GetContext().Items[key] = value;
		}

		public override bool TryGetValue<TKey, TValue>(TKey key, out TValue value)
		{
			if(this.GetContext().Items.TryGetValue(key, out object val))
			{
				value = (TValue)val;
				return true;
			}
			else
			{
				value = default;
				return false;
			}
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
				if (context.Items.ContainsKey(key))
					return false; // already exists

				context.Items[key] = true;
				return true;
			}
		}
	}
}
