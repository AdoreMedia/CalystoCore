using System.Collections.Generic;
using System.Text;
using Calysto.Web.Script.Services;
using System.Linq;
using Calysto.Converter;
using Calysto.Web.Script.Services.Compiler;
using Calysto.Linq;
using Calysto.Globalization;
using Microsoft.Ajax.Utilities.Css2;
using Calysto.Web.Hosting;
using Calysto.Web.EnvDTE;
using System;
using System.Collections.Concurrent;
using Calysto.Utility;

namespace Calysto.Web.UI
{
	public enum BuildKindEnum
	{
		Release = 0,
		Debug = 1,
		TddSpecific = 2
	}

	public class RuntimeConstants
	{
		public bool IsDebugDefined { get; set; }
		public bool IsTddSpecific { get; set; }
		public bool IsLocallyHosted { get; set; }
		public int WebClientGlobalTimeout { get; set; }
		// camuflate it to prevent Google from reading URL
		public string ServerDiagnosticUrl { get; set; }
		public string UrlPathBase { get; set; }
		public CalystoCultureInfo CurrentCulture { get; set; }
		public string RandomRFCTable64 { get; set; }
	}

	public class CalystoScriptManagerBase<TInstance> : ScriptsBundle<TInstance> where TInstance: CalystoScriptManagerBase<TInstance>
	{
		private static ConcurrentDictionary<string, CalystoCultureInfo> _dicCultures = new ConcurrentDictionary<string, CalystoCultureInfo>();

		private string CreateConstantsJavascript()
		{
			// en-US i hr-HR is required for parsing numbers in unittests (dot or comma)
			string currentCulture = System.Threading.Thread.CurrentThread.CurrentCulture.Name;

			var obj = new RuntimeConstants() // obj is IRuntimeConstants
			{
				IsDebugDefined = CalystoTools.IsDebugDefined,
				IsTddSpecific = CalystoTools.IsTddSpecific,
				IsLocallyHosted = CalystoTools.IsLocalMachine,
				WebClientGlobalTimeout = this.Timeout,
				// camuflate it to prevent Google from reading URL
				ServerDiagnosticUrl = !this.WriteElmah ? null : CreateElmahUrl(),
				UrlPathBase = CalystoHostingEnvironment.Current?.HostingAbsoluteUri?.PathBase,
				RandomRFCTable64 = BaseXCharsTable.RandomRFCTable64,
				CurrentCulture = _dicCultures.GetOrAdd(currentCulture, (key2)=>new CulturesGenerator().GetSingleCulture(currentCulture))
			};

			return global::Calysto.Serialization.Json.JsonSerializer.Serialize(obj);
		}

		public override string GetConstantsJavaScript()
		{
			return @"var Calysto_Core_RuntimeConstants = " + CreateConstantsJavascript() + ";";
		}

		public class Settings
		{
			/// <summary>
			/// Script compression level
			/// </summary>
			public MinifyModeEnum Compression { get; set; } = MinifyModeEnum.None;

			/// <summary>
			/// If true, add attribute async="async" to script tag
			/// </summary>
			public bool Async { get; set; }

			/// <summary>
			/// If true, bundle all js together, and all css together
			/// </summary>
			public bool Bundle { get; set; }

			public List<string> PreprocessorDefinedWords { get; } = new List<string>();

			public Settings()
			{
				if (Calysto.Utility.CalystoTools.IsDebugDefined)
				{
					this.PreprocessorDefinedWords.Add("DEBUG");
				}
			}
		}

		public static readonly Settings DefaultConfig = new Settings();

		public CalystoScriptManagerBase()
		{
			this.Compression = DefaultConfig.Compression;
			this.Bundle = DefaultConfig.Bundle;
			this.Async = DefaultConfig.Async;
			this.RegisterDefinedWords(DefaultConfig.PreprocessorDefinedWords.ToArray());
		}

		#region properties

		/// <summary>
		/// Script compression level
		/// </summary>
		public MinifyModeEnum Compression { get; set; }

		/// <summary>
		/// If true, add attribute async="async" to script tag
		/// </summary>
		public bool Async { get; set; }

		/// <summary>
		/// If true, bundle all js together, and all css together
		/// </summary>
		public bool Bundle { get; set; }

		public bool WriteElmah { get; set; }

		private int _timeout = 90000;
		/// <summary>
		/// Timeout in ms. Default 90000ms
		/// </summary>
		public int Timeout { get { return _timeout; } set { _timeout = value; } }

		#endregion

		#region url create & decode

		static string _virtualPathBase;

		private static string GetVirtualPathBase()
		{
			if (_virtualPathBase == null)
			{
				// unittest doesn't have Current
				if (CalystoHostingEnvironment.Current?.IsHosted == true)
				{
					// ako je rezultat /, nek vrati prazan string jer se dodaje: /path1/path2 pa da nema 2 puta / na pocetku
					_virtualPathBase = new CalystoVirtualPathHelper("/").ToVirtualUrlPath().TrimEnd('/');
				}
				else
				{
					// win app or unittest
					_virtualPathBase = "/[winapp1]/";
				}
			}
			return _virtualPathBase;
		}

		private string CreateScriptUrl(FileCompilerResult script)
		{
			// all files are embedded resources
			StringBuilder sb = new StringBuilder();
			sb.Append(CalystoVirtualPathHelper.CombineToVirtualPath(
				GetVirtualPathBase(),
				CalystoAjaxHandlerConstants.ScriptResourceRequest,
				// dodajemo vpath da se slozi hijerarhija u browseru: devtools -> Sources, za lakse debugiranje, samo u Debugu,
				// u Releaseu nemamo script.AppRelativeVirtualPath postavljen
				// extenziju treba maknuti da je ne hvata static file middleware (dodajem FileNameAddon)
				string.IsNullOrEmpty(script.AppRelativeVirtualPath) ? null : (script.AppRelativeVirtualPath + CalystoAjaxHandlerConstants.FileNameAddon)
			)); ;
			sb.Append("?");
			sb.Append(CalystoAjaxHandlerConstants.QueryStringEtagKey);
			sb.Append("=");
			sb.Append(script.ETag);
			return sb.ToString();
		}

		internal static string CreateElmahUrl()
		{
			return CalystoVirtualPathHelper.CombineToVirtualPath(
				GetVirtualPathBase(), 
				CalystoAjaxHandlerConstants.ElmahRequest
			);
		}

		public static event Action<string> OnPageStateRestore;

		internal static void NotifyPageStateRestore(string pageState)
		{
			OnPageStateRestore?.Invoke(pageState);
		}

		#endregion

		#region render tags

		private string CreateScriptTag(FileCompilerResult script)
		{
			if (script.IsInline)
			{
				if (script.IsCSS)
				{
					return $@"<style type=""text/css"">{script.MinifiedContent}</style>";
				}
				else
				{
					return $@"<script type=""text/javascript"">{script.MinifiedContent}</script>";
				}
			}
			else
			{
				string url = CreateScriptUrl(script);

				string asyncAttr = this.Async ? @" async=""async""" : null;

				if (script.IsCSS)
				{
					return $@"<link{asyncAttr} rel=""stylesheet"" type=""text/css"" href=""{url}"" />";
				}
				else
				{
					return $@"<script{asyncAttr} type=""text/javascript"" src=""{url}""></script>";
				}
			}
		}

		private IEnumerable<FileCompilerResult> GetCurrentCompileResults()
		{
			CompileSetting sett = new CompileSetting(
				this.Bundle || this.Async,
				this.Compression,
				CalystoTools.IsDebugDefined
			);

			return this.GetCompileResults(sett)
				.GroupBy(o => o.IsCSS)
				.OrderBy(group => group.Key ? 0 : 1) // css first, than js
				.SelectMany(group => group);
		}

		public IEnumerable<string> GetScriptsTags()
		{
			return GetCurrentCompileResults()
				.Select(o => CreateScriptTag(o));
		}

		public string GetAllScriptsTags()
		{
			return string.Join("\r\n", this.GetScriptsTags());
		}

		public IEnumerable<string> GetScriptsUrls()
		{
			return GetCurrentCompileResults()
				.Select(o => CreateScriptUrl(o));
		}

		public string GetJavascriptCode()
		{
			return GetCurrentCompileResults().Where(o => !o.IsCSS).Select(o => o.MinifiedContent).ToStringJoined(";\r\n"); 
		}

		public string GetJavascriptTag()
		{
			return GetCurrentCompileResults().Where(o => !o.IsCSS).Select(o => CreateScriptTag(o)).ToStringJoined();
		}

		public string GetCssCode()
		{
			return GetCurrentCompileResults().Where(o => o.IsCSS).Select(o => o.MinifiedContent).ToStringJoined("\r\n");
		}

		public string GetCssTag()
		{
			return GetCurrentCompileResults().Where(o => o.IsCSS).Select(o => CreateScriptTag(o)).ToStringJoined();
		}

		#endregion

	}
}