using Calysto.Common;
using Calysto.Serialization.Json.Core.Serialization;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Web.WebView2.Wpf;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using Calysto.Linq;

namespace Calysto.WebView
{
	/// <summary>
	/// Handles requests from WebView client to Wpf host.
	/// </summary>
	public abstract class HostObjectBase : ICalystoWebViewHostObject, IDisposable
	{
		WebView2 _webView;

		public event Action<HostObjectBase> OnRequestReceived;
		public event Action<HostObjectBase> OnBeforeMethodInvoke;
		public event Action<HostObjectBase> OnAfterMethodInvoke;
		public event Action<HostObjectBase> OnResponseSent;

		public bool IsDisposed { get; private set; }

		public virtual void Dispose()
		{
			this.OnRequestReceived = null;
			this.OnBeforeMethodInvoke = null;
			this.OnAfterMethodInvoke = null;
			this.OnResponseSent = null;

			this.IsDisposed = true;
			try
			{
				_webView?.Dispose();
			}
			catch { }
			_webView = null;
		}

		~HostObjectBase() => this.Dispose();

		public HostObjectBase(WebView2 webView)
		{
			_webView = webView;
			_webView?.CoreWebView2.AddHostObjectToScript(this.GetType().Name, this);
		}

		ConcurrentDictionary<string, MethodInfo> _dicMethods = new ConcurrentDictionary<string, MethodInfo>();

		public class ResponseObject
		{
			public object Result { get; set; }
			public string Error { get; set; }
		}

		/// <summary>
		/// Create new task and invoke method async. On complete, response is sent back to client WebView with guid task reference. 
		/// </summary>
		/// <param name="guid"></param>
		/// <param name="methodName"></param>
		/// <param name="jsonArgsArray"></param>
		public void InvokeHostServiceMethodAsync(string guid, string methodName, string jsonArgsArray)
		{
			Task.Run(async () =>
			{
				this.OnRequestReceived?.Invoke(this);

				string json1;
				try
				{
					object[] argsArr = Calysto.Serialization.Json.JsonSerializer.Deserialize<object[]>(jsonArgsArray) ?? new object[0];

					MethodInfo mi = _dicMethods.GetOrAdd($"{methodName}[{argsArr.Length}]", (key) =>
					{
						return this.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public)
							.Select(mi => new
							{
								mi,
								parameters = mi.GetParameters()
							})
							.Where(o => o.mi.Name == methodName && o.parameters.Length == argsArr.Length)
							.Where(o=>o?.mi != null)
							.Select(o => o.mi)
							.Single();
					});
					
					object[] argsConverted = ConvertArguments(mi, argsArr);

					this.OnBeforeMethodInvoke?.Invoke(this);
					ResponseObject resp1 = new ResponseObject() { Result = await InvokeMethodAsync(mi, argsConverted) };
					this.OnAfterMethodInvoke?.Invoke(this);

					json1 = Calysto.Serialization.Json.JsonSerializer.Serialize(resp1, new SerializerOptions() {SkipCircularReference = true });
				}
				catch (Exception ex)
				{
					ResponseObject resp1 = new ResponseObject() { Error = ex.ToString() };
					json1 = Calysto.Serialization.Json.JsonSerializer.Serialize(resp1);
				}

				string js2 = $"window.$$$calystoHostCallbackHandler.HostServiceResolveCallback(\"{guid}\", \"{HttpUtility.JavaScriptStringEncode(json1)}\")";

				await _webView.Dispatcher.InvokeAsync(() => this._webView.ExecuteScriptAsync(js2));

				this.OnResponseSent?.Invoke(this);
			});
		}

		static Dictionary<Type, PropertyInfo> _dicProp = new Dictionary<Type, PropertyInfo>();

		private async Task<object> InvokeMethodAsync(MethodInfo mi, object[] argsConverted)
		{
			object resp;

			if (mi.IsStatic)
			{
				resp = mi.Invoke(null, argsConverted);
			}
			else
			{
				resp = mi.Invoke(this, argsConverted);
			}

			if (resp != null && resp is Task task1)
			{
				// Task uvijek ima 1 generic type argument, u slucaju da ne vraca rezultat, onda je tip argumenta System.Threading.Tasks.VoidTaskResult
				Type[] args1 = task1.GetType().GenericTypeArguments;

				// wait for task to complete
				await task1;

				if (args1.Length > 0)
				{
					if (args1[0].FullName == "System.Threading.Tasks.VoidTaskResult")
					{
						resp = null;
					}
					else
					{
						Type type1 = task1.GetType();
						PropertyInfo pi = _dicProp.GetValueOrAdd(type1, key => type1.GetProperty("Result"));
						resp = pi.GetValue(task1);
					}
				}
				else
				{
					// void result
					resp = null;
				}
			}

			return resp;
		}

		private static object[] ConvertArguments(MethodInfo mi, object[] argsArr)
		{
			Type[] argTypes = mi.GetParameters().Select(p => p.ParameterType).ToArray();
			
			if (argsArr.Length != argTypes.Length)
				throw new ArgumentException();

			ObjectConverter converter = new ObjectConverter();
			return argsArr.Select((item, index) => converter.ConvertObjectToType(item, argTypes[index])).ToArray();
		}
	}
}
