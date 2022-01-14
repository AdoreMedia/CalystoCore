using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Calysto.Blazor.Utility.Infrastructure
{
	public class ScriptContext
	{
		Lazy<Task<IJSObjectReference>> _moduleTask2;
		IJSRuntime _jsRuntime2;

		public ScriptContext(IJSRuntime jsRuntime, Lazy<Task<IJSObjectReference>> lazyTask)
		{
			_jsRuntime2 = jsRuntime;
			_moduleTask2 = lazyTask;
		}

		public async Task<TResult> InvokeAsync<TResult>(string identifier, params object[] args)
		{
			await _moduleTask2.Value;
			return await _jsRuntime2.InvokeAsync<TResult>(identifier, args);
		}

		public async Task InvokeVoidAsync(string identifier, params object[] args)
		{
			await _moduleTask2.Value;
			await _jsRuntime2.InvokeVoidAsync(identifier, args);
		}
	}
}
