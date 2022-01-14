using Calysto.IO;
using Calysto.Utility;
using Calysto.Web;
using Calysto.Web.Script.MapFile;
using Microsoft.Web.WebView2.Wpf;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Calysto.WebView
{
	/********************************************************************************
	 * Nikad ne stavljati await _webView.CoreWebView2.ExecuteScriptAsync()
	 *	jer se ponekad zblokira kad se ceka odgovor, koristiti iskljucivo za slanje podatka
	 *	a ako treba odgovor, onda koristiti ProcessResponseCallback kao sto je u kodu ispod,
	 *	tako da se sa klijenta salje novi request kroz hostObject sa pripadajucima guid-om po cemu
	 *	se pronalazi pending task u _pendingTasks
	 *	PAZI:
	 * invoking CoreWebView2.ExecuteScriptAsync with large script (> 1kb) will cause memory leaks
	 * bolji nacin je da se predaju pathovi skripti, a potom se sadrzaj dohvaca sa GetMyScripts(...) kroz host objekt
	 * kao sto je sad izvedeno, vidi InjectScriptsWorkerAsync(...)
	********************************************************************************/
	public enum DocumentReadyState
	{
		interactive,
		complete
	}

	/// <summary>
	/// Handles requests from Wpf host to WebView client.
	/// </summary>
	public class HostScriptService
	{
		const string _hostName = "hostScriptService4";
		WebView2 _webView;
		ConcurrentDictionary<string, Action<object>> _pendingTasks = new ConcurrentDictionary<string, Action<object>>();

		public HostScriptService(WebView2 webView, DocumentReadyState completeState = DocumentReadyState.interactive)
		{
			_webView = webView;
			_webView.CoreWebView2.AddHostObjectToScript(_hostName, this);

			// novi event koji su dodali nedavno, okida nakon sto je html loadiran i parsiran
			webView.CoreWebView2.DOMContentLoaded += CoreWebView2_DOMContentLoaded;
		}

		private void CoreWebView2_DOMContentLoaded(object sender, Microsoft.Web.WebView2.Core.CoreWebView2DOMContentLoadedEventArgs e)
		{
			this.OnDocumentCreated?.Invoke();
		}

		public event Action OnDocumentCreated;

		/// <summary>
		/// Receives callback from chrome?.webview?.hostObjects
		/// </summary>
		/// <param name="guid"></param>
		/// <param name="result"></param>
		public void ProcessResponseCallback(string guid, object result)
		{
			if (_pendingTasks.TryRemove(guid, out var callback1))
			{
				callback1?.Invoke(result);
			}
		}

		class VoidReturn
		{
		}

		/// <summary>
		/// Execute script with return. Doesn't create script tag.
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="js"></param>
		/// <returns></returns>
		public Task<TResult> ExecuteScriptAsync<TResult>(string js)
		{
			string key1 = Guid.NewGuid().ToString();

			TaskCompletionSource<TResult> tresult1 = new TaskCompletionSource<TResult>();

			Action<object> callback = new Action<object>(result2 =>
			{
				if (typeof(TResult) == typeof(VoidReturn))
				{
					tresult1.SetResult(default);
				}
				else
				{
					var tmp1 = System.Text.Json.JsonSerializer.Deserialize<TResult>(result2 + "");
					tresult1.SetResult(tmp1);
				}
			});

			_pendingTasks.TryAdd(key1, callback);

			_webView.Dispatcher.InvokeAsync(new Action(() =>
			{
				// invoking CoreWebView2.ExecuteScriptAsync and waiting for response may block browser
				// better way is to use ProcessResponseCallback to get resonse
				// invoking CoreWebView2.ExecuteScriptAsync with large script (> 1kb) will cause memory leaks
				// bolji nacin je da se predaju pathovi skripti, a potom se sadrzaj dohvaca sa GetMyScripts(..) kroz host objekt
				_webView.CoreWebView2.ExecuteScriptAsync($@"(async function(){{
	var res1 = await (async function(){{
		try{{
			{js};
		}} catch (e){{
			alert(e);
		}}
	}})();
	await chrome?.webview?.hostObjects?.{_hostName}.ProcessResponseCallback(""{key1}"", JSON.stringify(res1));
}})()");
			}));

			return tresult1.Task;
		}

		public Task ExecuteScriptAsync(string js)
		{
			return this.ExecuteScriptAsync<VoidReturn>(js);
		}

		public string GetMyScripts(string path)
		{
			CalystoFileInfo fileInfo = new CalystoPhysicalPathHelper(path).FindFile();

			string scriptWithMap = MapFileCache.GetFileScriptWithMap(fileInfo.FilePath, fileInfo.FileText);

			return scriptWithMap;
		}

		private async Task InjectScriptsWorkerAsync(ScriptsBag bag)
		{
			await this.ExecuteScriptAsync<bool>($@"return (async function()
{{
	function SleepAsync(durationMs) 
	{{ 
		return new Promise(function (resolve, reject) {{ 
			setTimeout(function () {{ resolve() }}, durationMs); 
		}}); 
	}}

	var fnGetScripts;
	while(!(fnGetScripts = chrome?.webview?.hostObjects?.{_hostName}.GetMyScripts))
	{{
		await SleepAsync(50);
	}}

	var el1;
	while(!(window.document && (el1=(document.getElementsByTagName(""head"")[0] || document.body || document.documentElement))))
	{{
		await SleepAsync(50);
	}}
	
	var itemsArr = JSON.parse(""{HttpUtility.JavaScriptStringEncode(bag.ToJson())}"");
	for(var n1 = 0; n1 < itemsArr.length; n1++)
	{{
		var item1 = itemsArr[n1];
		if(eval(item1.JsCondition))
		{{
			var s = document.createElement(item1.IsCss ? ""style"" : ""script"");
			s.id = ""calysto-"" + (item1.Path || Math.random());
			s.type = item1.IsCss ? ""text/css"" : ""text/javascript"";
			if(!!item1.Path)
			{{
				try
				{{
					s.text = s.textContent = await fnGetScripts(item1.Path);
					el1.appendChild(s);
				}}
				catch(e)
				{{
					alert(e);
				}}
			}}
			else if(!!item1.Content)
			{{
				try
				{{
					s.text = s.textContent = item1.Content;
					el1.appendChild(s);
				}}
				catch(e)
				{{
					alert(e);
				}}
			}}
		}}
	}}

	return true;
}})();");
		}

		public class ScriptItem
		{
			public string Path { get; set; }
			public string Content { get; set; }
			public bool IsCss { get; set; }
			public string JsCondition { get; set; } = "true";
		}

		public class ScriptsBag
		{
			List<ScriptItem> _items = new List<ScriptItem>();

			public string ToJson() => System.Text.Json.JsonSerializer.Serialize(_items);

			public ScriptsBag AddCalystoEngine(string cultureName = "hr-HR")
			{
				_items.Add(new ScriptItem() { Path = Calysto.Web.JSFilesList.WebLib_Engine__dist_EngineConstants_hr_HR_js.Replace("hr-HR", cultureName) });
				_items.Add(new ScriptItem() { Path = Calysto.Web.JSFilesList.WebLib_Engine__dist_Core_EngineComplete_js , JsCondition = "!window.$$calysto" });
				return this;
			}

			public ScriptsBag SetCalystoVariables(bool isLocallyHosted, bool isDebugDefined, bool isTddSpecific)
			{
				_items.Add(new ScriptItem() { Content = "Calysto.Core.Constants.IsLocallyHosted=" + isLocallyHosted.ToString().ToLower() });
				_items.Add(new ScriptItem() { Content = "Calysto.Core.Constants.IsDebugDefined=" + isDebugDefined.ToString().ToLower() });
				_items.Add(new ScriptItem() { Content = "Calysto.Core.Constants.IsTddSpecific=" + isTddSpecific.ToString().ToLower() });
				return this;
			}

			public ScriptsBag AddXmlHttpInterceptor()
			{
				_items.Add(new ScriptItem() { Path = JSFilesList.WebView_TypeScriptEngine__dist_WebViewComplete_js });
				return this;
			}
			
			public ScriptsBag AddScriptFile(string path, string jsCondition = "true")
			{
				_items.Add(new ScriptItem() { Path = path, JsCondition = jsCondition, IsCss = Path.GetExtension(path).ToLower() == ".css"});
				return this;
			}

			public ScriptsBag AddJsContent(string content, string jsCondition = "true")
			{
				_items.Add(new ScriptItem() { Content = content, JsCondition = jsCondition });
				return this;
			}

			public ScriptsBag AddCssContent(string content, string jsCondition = "true")
			{
				_items.Add(new ScriptItem() { Content = content, JsCondition = jsCondition, IsCss = true });
				return this;
			}
		}

		public Task InjectScriptsAsync(Action<ScriptsBag> action)
		{
			ScriptsBag bag = new ScriptsBag();
			action.Invoke(bag);
			return this.InjectScriptsWorkerAsync(bag);
		}
	}
}
