using Calysto.Common.Extensions;
using Calysto.Linq;
using System;
using System.Collections.Generic;

namespace Calysto.AspNetCore.Http
{
	public class CalystoSession
	{
		Dictionary<object, object> _dic = new Dictionary<object, object>();

		public string SessionId { get; }
		public DateTime CreationDate { get; }
		
		// diagnostics only:
		public DateTime? LastGetDate { get; private set; }
		public DateTime? LastSetDate { get; private set; }
		public DateTime? CookieSavedDate { get; private set; }

		private Action _fnSaveCookie;
		private CalystoSessionProvider _owner;

		public CalystoSession(CalystoSessionProvider owner, string sessionId, Action fnSaveCookie)
		{
			this._owner = owner;
			this.SessionId = sessionId;
			this.CreationDate = DateTime.Now;
			this._fnSaveCookie = fnSaveCookie;
		}

		public void Remove(object key)
		{
			_dic.Remove(key);
		}

		public object GetValue(object key)
		{
			this.LastGetDate = DateTime.Now;
			return _dic.GetValueOrDefault(key);
		}

		public bool TryGetValue(object key, out object value)
		{
			return _dic.TryGetValue(key, out value);
		}

		public void SetValue(object key, object value)
		{
			this.LastSetDate = DateTime.Now;
			this.UsingLock(o => o._dic[key] = value);
			// save cookie if not already saved, only when value is set
			if (this._fnSaveCookie != null)
			{
				this._fnSaveCookie.Invoke();
				this._fnSaveCookie = null;
				this.CookieSavedDate = DateTime.Now;
			}
		}

		public void RemoveSession()
		{
			_owner.RemoveSession(this.SessionId);
		}
	}
}
