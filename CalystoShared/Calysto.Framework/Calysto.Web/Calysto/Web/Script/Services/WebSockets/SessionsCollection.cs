using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calysto.Web.Script.Services.WebSockets
{
	public class SessionsCollection
	{
		private Type _sessionType;
		private HashSet<IWebSocketSession> _listeners;

		public SessionsCollection(Type sessionType, HashSet<IWebSocketSession> sessions)
		{
			_sessionType = sessionType;
			_listeners = sessions;
		}

		public int Count => _listeners.Count;

		/// <summary>
		/// Send to all listeners in collection.
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Task SendAsync(ArraySegment<byte> data)
		{
			var list2 = _listeners.Select(o => o.Service.SendAsync(data)).ToList();
			return Task.WhenAll(list2);
		}
	}
}
