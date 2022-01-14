using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Calysto.Blazor.Utility
{
	public class EventListenerState<IEventArg> : IAsyncDisposable 
		where IEventArg : EventArgs
	{
		Func<IEventArg, bool> _callback;
		BrowserContext _browser;

		public EventListenerState(BrowserContext browserContext, Func<IEventArg, bool> callback)
		{
			_browser = browserContext;
			_callback = callback;
		}

		[JSInvokable]
		public bool Callback(IEventArg arg)
		{
			return _callback.Invoke(arg);
		}

		DotNetObjectReference<EventListenerState<IEventArg>> _thisRef;
		public DotNetObjectReference<EventListenerState<IEventArg>> ListenerStateRef => _thisRef ?? (_thisRef = DotNetObjectReference.Create(this));

		public JSObjectReference JsRemovalRef { get; internal set; }

		public async ValueTask DisposeAsync()
		{
			await _browser.RemoveEventListener(this.JsRemovalRef);
			_thisRef?.Dispose();
		}
	}
}
