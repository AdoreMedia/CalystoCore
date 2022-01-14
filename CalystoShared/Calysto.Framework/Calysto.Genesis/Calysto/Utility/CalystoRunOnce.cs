using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calysto.Utility
{
	/// <summary>
	/// Will invoke func on first invocation of GetValue(). Next invocation of GetValue() will return previous value.
	/// </summary>
	/// <typeparam name="TValue"></typeparam>
	public class CalystoRunOnce<TValue>
	{
		private TValue _value;
		private bool _isLoaded;
		private Func<TValue> _onFirstCall;

		/// <summary>
		/// On first call to Value, will invoke onFirstCall and keep result cached.
		/// </summary>
		public TValue Value
		{
			get
			{
				if (!_isLoaded)
				{
					lock (this)
					{
						if (!_isLoaded)
						{
							_isLoaded = true;
							_value = _onFirstCall.Invoke();
						}
					}
				}

				return _value;
			}
		}

		public CalystoRunOnce(Func<TValue> onFirstCall)
		{
			_onFirstCall = onFirstCall;
		}

		/// <summary>
		/// Request for value to be reloaded (invoke onFirstCall) on next invocation of GetValue().
		/// </summary>
		public void Reset()
		{
			lock (this)
			{
				_isLoaded = false;
				_value = default;
			}
		}
	}
}