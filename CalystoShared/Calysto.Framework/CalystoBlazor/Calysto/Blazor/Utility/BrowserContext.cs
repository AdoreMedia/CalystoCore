using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Calysto.Blazor.Utility.Infrastructure;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;

namespace Calysto.Blazor.Utility
{
	public class BrowserContext
	{
		ScriptContext _module;

		public IWebAssemblyHostEnvironment HostEnvironment { get; private set; }

		public BrowserContext(IJSRuntime jsRuntime, IWebAssemblyHostEnvironment environment)
		{
			this.HostEnvironment = environment;
			
			_module = new ScriptContext(
				jsRuntime,
				new(() =>jsRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/Calysto.Blazor/ts/Calysto.Blazor.Interop.js").AsTask())
			);
		}

		#region sessionStorage & localStorage

		StorageProvider _sessionStorage;

		public StorageProvider SessionStorage => _sessionStorage ?? (_sessionStorage = new StorageProvider(_module, "sessionStorage"));

		StorageProvider _localStorage;

		public StorageProvider LocalStorage => _localStorage ?? (_localStorage = new StorageProvider(_module, "localStorage"));

		#endregion

		#region execute js

		public async Task<TResult> ExecuteScriptAsync<TResult>(string js)
		{
			return await _module.InvokeAsync<TResult>("Calysto.Blazor.Interop.ExecuteScriptAsync", js);
		}

		public async Task ExecuteScriptVoidAsync(string js)
		{
			await _module.InvokeVoidAsync("Calysto.Blazor.Interop.ExecuteScriptAsync", js);
		}

		#endregion

		#region alert, confirm, prompt

		public async Task SystemAlertAsync(string txt)
		{
			await _module.InvokeVoidAsync("Calysto.Blazor.Interop.SystemAlertAsync", txt);
		}

		public async Task<bool> SystemConfirmAsync(string txt)
		{
			return await _module.InvokeAsync<bool>("Calysto.Blazor.Interop.SystemConfirmAsync", txt);
		}

		public async Task<string> SystemPromptAsync(string txt)
		{
			return await _module.InvokeAsync<string>("Calysto.Blazor.Interop.SystemPromptAsync", txt);
		}

		#endregion

		#region get element methods

		public async Task<DomElement> GetElementByReference(ElementReference elementReference)
		{
			return await _module.InvokeAsync<DomElement>("Calysto.Blazor.Interop.GetElementByReference", elementReference);
		}

		public async Task<DomElement> GetElementByIdAsync(string id)
		{
			return await _module.InvokeAsync<DomElement>("Calysto.Blazor.Interop.GetElementById", id);
		}

		public async Task<IEnumerable<DomElement>> GetElementsByTagNameAsync(string tagName, int skip = 0, int take = int.MaxValue)
		{
			return await _module.InvokeAsync<List<DomElement>>("Calysto.Blazor.Interop.GetElementsByTagName", tagName, skip, take);
		}

		public async Task<IEnumerable<DomElement>> GetElementsByClassNameAsync(string clasName, int skip = 0, int take = int.MaxValue)
		{
			return await _module.InvokeAsync<List<DomElement>>("Calysto.Blazor.Interop.GetElementsByClassName", clasName, skip, take);
		}

		public async Task<IEnumerable<DomElement>> GetElementsByNameAsync(string name, int skip = 0, int take = int.MaxValue)
		{
			return await _module.InvokeAsync<List<DomElement>>("Calysto.Blazor.Interop.GetElementsByName", name, skip, take);
		}

		#endregion

		#region element / object property get / set

		public async Task<bool> HasObjectProperty(JSObjectReference el, string propPath = null)
		{
			return await _module.InvokeAsync<bool>("Calysto.Blazor.Interop.HasObjectProperty", el, propPath);
		}

		public async Task<bool> HasObjectFunction(JSObjectReference el, string propPath = null)
		{
			return await _module.InvokeAsync<bool>("Calysto.Blazor.Interop.HasObjectFunction", el, propPath);
		}

		public async Task<bool> HasObjectProperty(ElementReference el, string propPath = null)
		{
			return await _module.InvokeAsync<bool>("Calysto.Blazor.Interop.HasObjectProperty", el, propPath);
		}

		public async Task<bool> HasObjectFunction(ElementReference el, string propPath = null)
		{
			return await _module.InvokeAsync<bool>("Calysto.Blazor.Interop.HasObjectFunction", el, propPath);
		}

		public async Task SetPropertyValue<TValue>(JSObjectReference el, string propPath, TValue value)
		{
			await _module.InvokeVoidAsync("Calysto.Blazor.Interop.SetPropertyValue", el, propPath, value);
		}

		public async Task SetPropertyValue<TValue>(ElementReference el, string propPath, TValue value)
		{
			await _module.InvokeVoidAsync("Calysto.Blazor.Interop.SetPropertyValue", el, propPath, value);
		}

		public async Task<TValue> GetPropertyValue<TValue>(JSObjectReference el, string propPath)
		{
			return await _module.InvokeAsync<TValue>("Calysto.Blazor.Interop.GetPropertyValue", el, propPath);
		}

		public async Task<TValue> GetPropertyValue<TValue>(ElementReference el, string propPath)
		{
			return await _module.InvokeAsync<TValue>("Calysto.Blazor.Interop.GetPropertyValue", el, propPath);
		}

		public async Task<JSObjectReference> GetPropertyReference(ElementReference el, string propPath)
		{
			return await _module.InvokeAsync<JSObjectReference>("Calysto.Blazor.Interop.GetPropertyReference", el, propPath);
		}

		public async Task<JSObjectReference> GetPropertyReference(JSObjectReference el, string propPath)
		{
			return await _module.InvokeAsync<JSObjectReference>("Calysto.Blazor.Interop.GetPropertyReference", el, propPath);
		}

		#endregion

		#region invoke element / object function

		public async Task<TValue> InvokeObjectFunction<TValue>(JSObjectReference el, string propertyPath, params object[] args)
		{
			return await _module.InvokeAsync<TValue>("Calysto.Blazor.Interop.InvokeObjectFunction", el, propertyPath, args);
		}

		public async Task InvokeObjectFunctionVoid(JSObjectReference el, string propertyPath, params object[] args)
		{
			await _module.InvokeVoidAsync("Calysto.Blazor.Interop.InvokeObjectFunctionVoid", el, propertyPath, args);
		}

		public async Task<TValue> InvokeObjectFunction<TValue>(ElementReference el, string propertyPath, params object[] args)
		{
			return await _module.InvokeAsync<TValue>("Calysto.Blazor.Interop.InvokeObjectFunction", el, propertyPath, args);
		}

		public async Task InvokeObjectFunctionVoid(ElementReference el, string propertyPath, params object[] args)
		{
			await _module.InvokeVoidAsync("Calysto.Blazor.Interop.InvokeObjectFunctionVoid", el, propertyPath, args);
		}

		#endregion

		#region window property manipulation

		public async Task<bool> HasWindowProperty(string propPath = null)
		{
			return await _module.InvokeAsync<bool>("Calysto.Blazor.Interop.HasWindowProperty", propPath);
		}

		public async Task<bool> HasWindowFunction(string propPath = null)
		{
			return await _module.InvokeAsync<bool>("Calysto.Blazor.Interop.HasWindowFunction", propPath);
		}

		public async Task<TValue> GetWindowPropertyValue<TValue>(string propPath = null)
		{
			return await _module.InvokeAsync<TValue>("Calysto.Blazor.Interop.GetWindowPropertyValue", propPath);
		}

		public async Task<JSObjectReference> GetWindowPropertyReference(string propPath = null)
		{
			return await _module.InvokeAsync<JSObjectReference>("Calysto.Blazor.Interop.GetWindowPropertyReference", propPath);
		}

		#endregion

		#region invoke window function

		public async Task<TValue> InvokeWindowFunction<TValue>(string propertyPath, params object[] args)
		{
			return await _module.InvokeAsync<TValue>("Calysto.Blazor.Interop.InvokeWindowFunction", propertyPath, args);
		}

		public async Task InvokeWindowFunctionVoid(string propertyPath, params object[] args)
		{
			await _module.InvokeVoidAsync("Calysto.Blazor.Interop.InvokeWindowFunctionVoid", propertyPath, args);
		}

		#endregion

		#region element attributes

		public async Task SetAttributeValue<TValue>(ElementReference el, string attrName, TValue value)
		{
			await _module.InvokeVoidAsync("Calysto.Blazor.Interop.SetAttributeValue", el, attrName, value);
		}

		public async Task<TValue> GetAttributeValue<TValue>(ElementReference el, string attrName)
		{
			return await _module.InvokeAsync<TValue>("Calysto.Blazor.Interop.GetAttributeValue", el, attrName);
		}

		public async Task SetAttributeValue<TValue>(JSObjectReference el, string attrName, TValue value)
		{
			await _module.InvokeVoidAsync("Calysto.Blazor.Interop.SetAttributeValue", el, attrName, value);
		}

		public async Task<TValue> GetAttributeValue<TValue>(JSObjectReference el, string attrName)
		{
			return await _module.InvokeAsync<TValue>("Calysto.Blazor.Interop.GetAttributeValue", el, attrName);
		}

		#endregion

		#region server version helpers

		public async Task<string> GetServerVersionFromHtmlAsync()
		{
			return await _module.InvokeAsync<string>("Calysto.Blazor.Interop.GetServerVersionFromHtmlAsync");
		}

		public async Task RemoveBlazorOfflineCacheAndReloadAsync()
		{
			await _module.InvokeVoidAsync("Calysto.Blazor.Interop.RemoveBlazorOfflineCacheAndReloadAsync");
		}

		public async Task LocationReloadAsync()
		{
			await _module.InvokeVoidAsync("location.reload", true);
		}

		#endregion

		#region dom events

		public async Task<TEventArg> WaitForDomEventAsync<TEventArg>(string eventName, string targetElementId = null)
			where TEventArg : EventArgs
		{
			return await _module.InvokeAsync<TEventArg>("Calysto.Blazor.Interop.WaitForDomEventAsync", eventName, targetElementId, typeof(TEventArg).Name);
		}

		public async Task<EventListenerState<TEventArg>> AddEventListener<TEventArg>(JSObjectReference el, string eventName, Func<TEventArg, bool> callback)
			where TEventArg : EventArgs
		{
			EventListenerState<TEventArg> state1 = new EventListenerState<TEventArg>(this, callback);
			state1.JsRemovalRef = await _module.InvokeAsync<JSObjectReference>("Calysto.Blazor.Interop.AddEventListener", el, eventName, state1.ListenerStateRef, typeof(TEventArg).Name);
			return state1;
		}

		public async Task<EventListenerState<TEventArg>> AddEventListener<TEventArg>(ElementReference el, string eventName, Func<TEventArg, bool> callback)
			where TEventArg : EventArgs
		{
			EventListenerState<TEventArg> state1 = new EventListenerState<TEventArg>(this, callback);
			state1.JsRemovalRef = await _module.InvokeAsync<JSObjectReference>("Calysto.Blazor.Interop.AddEventListener", el, eventName, state1.ListenerStateRef, typeof(TEventArg).Name);
			return state1;
		}

		public async Task RemoveEventListener(JSObjectReference jsRemovalRef)
		{
			await _module.InvokeAsync<DotNetObjectReference<object>>("Calysto.Blazor.Interop.RemoveEventListener", jsRemovalRef);
		}

		#endregion

		#region window.location

		public async Task<WindowLocation> GetLocationAsync()
		{
			return await _module.InvokeAsync<WindowLocation>("Calysto.Blazor.Interop.GetLocationAsync");
		}

		#endregion
	}
}
