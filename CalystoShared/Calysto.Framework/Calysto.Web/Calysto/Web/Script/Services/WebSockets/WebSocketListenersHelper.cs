using Calysto.Common;
using Calysto.Common.Extensions;
using Calysto.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Calysto.Web.Script.Services.WebSockets
{
	public class WebSocketListenersHelper
	{
		static Dictionary<Type, WebSocketListenersHelper> _sessionsBySessionType = new Dictionary<Type, WebSocketListenersHelper>();

		public static WebSocketListenersHelper GetSessionsHelper(Type sessionType)
		{
			if (!_sessionsBySessionType.TryGetValue(sessionType, out WebSocketListenersHelper helper))
			{
				lock (_sessionsBySessionType)
				{
					if (!_sessionsBySessionType.TryGetValue(sessionType, out helper))
					{
						helper = new WebSocketListenersHelper();
						helper._listeners = new HashSet<IWebSocketSession>();
						helper._sessionType = sessionType;
						_sessionsBySessionType.Add(sessionType, helper);
					}
				}
			}
			return helper;
		}

		private Type _sessionType;
		private HashSet<IWebSocketSession> _listeners;

		public int Count => this.UsingLock(o => o._listeners.Count);

		public void AddSession(IWebSocketSession session)
		{
			lock (this)
				_listeners.Add(session);
		}

		public void RemoveSession(IWebSocketSession session)
		{
			lock (this)
				_listeners.Remove(session);
		}

		public SessionsCollection GetSessions(Func<IWebSocketSession, bool> predicate = null)
		{
			lock (this)
			{
				return new SessionsCollection(_sessionType, new HashSet<IWebSocketSession>(_listeners.Where(o=> predicate == null || predicate(o))));
			}
		}
	}
}
