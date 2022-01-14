using Calysto.Extensions;
using Calysto.IO;
using Calysto.Linq;
using Calysto.Utility;
using Calysto.Web.Hosting;
using Calysto.Web.Script.MapFile;
using Microsoft.Ajax.Utilities.Css2;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace Calysto.Web.Script.Services.Compiler
{
	public enum CssTheme
	{
		[StringValue(CSSFilesList.WebLib_Style__dist_aero_light_gray_css)]
		AeroLightGray,

		[StringValue(CSSFilesList.WebLib_Style__dist_aero_light_blue_css)]
		AeroLightBlue,

		[StringValue(CSSFilesList.WebLib_Style__dist_aero_light_green_css)]
		AeroLightGreen,

		[StringValue(CSSFilesList.WebLib_Style__dist_aero_light_magenta_css)]
		AeroLightMagenta,

		// metro light themes

		[StringValue(CSSFilesList.WebLib_Style__dist_metro_light_gray_css)]
		MetroLightGray,

		[StringValue(CSSFilesList.WebLib_Style__dist_metro_light_blue_css)]
		MetroLightBlue,

		[StringValue(CSSFilesList.WebLib_Style__dist_metro_light_green_css)]
		MetroLightGreen,

		[StringValue(CSSFilesList.WebLib_Style__dist_metro_light_magenta_css)]
		MetroLightMagenta,

		[StringValue(CSSFilesList.WebLib_Style__dist_metro_light_purple_css)]
		MetroLightPurple,

		[StringValue(CSSFilesList.WebLib_Style__dist_metro_light_arizonablue_css)]
		MetroLightArizonaBlue,

		// metro dark themes

		[StringValue(CSSFilesList.WebLib_Style__dist_metro_dark_blue_css)]
		MetroDarkBlue,

		[StringValue(CSSFilesList.WebLib_Style__dist_metro_dark_green_css)]
		MetroDarkGreen,

		[StringValue(CSSFilesList.WebLib_Style__dist_metro_dark_magenta_css)]
		MetroDarkMagenta,

		[StringValue(CSSFilesList.WebLib_Style__dist_metro_dark_purple_css)]
		MetroDarkPurple,

		[StringValue(CSSFilesList.WebLib_Style__dist_metro_dark_arizonablue_css)]
		MetroDarkArizonaBlue,
	}

	class CompileSetting
	{
		public bool Bundle { get; }
		public bool Debug { get; }
		public MinifyModeEnum Compression { get; }

		public CompileSetting(bool doBundle, MinifyModeEnum compression, bool isDebug)
		{
			this.Bundle = doBundle;
			this.Debug = isDebug;
			this.Compression = compression;
		}

		public string GetUniqueKey(string segment) => segment + "$$$" + this.Bundle + "$$$" + this.Debug + "$$$" + this.Compression;
	}

	public abstract class ScriptsBundle<TMain> where TMain : ScriptsBundle<TMain>
	{
		public abstract string GetConstantsJavaScript();

		protected bool AllowOncePerContext(string key)
		{
			if (CalystoTools.IsUnitTest)
			{
				return true;
			}
			else
			{
				return CalystoHostingEnvironment.Current.ContextItemsAccessor.AllowOncePerContext("__ScriptsBundleKey_" + key);
			}
		}

		#region global scripts cache

		internal static ConcurrentDictionary<string, FileContent> _cache = new ConcurrentDictionary<string, FileContent>();

		#endregion

		#region script registration methods

		internal List<Func<CompileSetting, FileContent>> _fileLocations = new List<Func<CompileSetting, FileContent>>();

		public TMain RegisterJavaScriptCode(string jscode)
		{
			if (!string.IsNullOrWhiteSpace(jscode) && this.AllowOncePerContext(jscode))
				_fileLocations.Add((sett) => _cache.GetOrAdd(sett.GetUniqueKey(jscode), (key2) => new FileContent(jscode)));
			return (TMain)this;
		}

		public TMain RegisterCssCode(string cssCode)
		{
			if (!string.IsNullOrWhiteSpace(cssCode) && this.AllowOncePerContext(cssCode))
				_fileLocations.Add((sett) => _cache.GetOrAdd(sett.GetUniqueKey(cssCode), (key2) => new FileContent(cssCode, true)));
			return (TMain)this;
		}

		public TMain RegisterPageState(string pageState)
		{
			string jscode = ($"window.{WsjsHeaderConstants.XCalystoPageStateValue}=\"{pageState}\";");
			if (!string.IsNullOrWhiteSpace(jscode) && this.AllowOncePerContext(jscode))
				_fileLocations.Add((sett) => _cache.GetOrAdd(sett.GetUniqueKey(jscode), (key2) => new FileContent(jscode, isInline: true)));
			return (TMain)this;
		}

		public TMain RegisterResxLanguage<ResxType>()
		{
			Type resxType = typeof(ResxType);
			string key = resxType.FullName
				+ "#" + Thread.CurrentThread.CurrentCulture.Name
				+ "#" + Thread.CurrentThread.CurrentUICulture.Name;

			if (this.AllowOncePerContext(key))
			{
				_fileLocations.Add((sett) => _cache.GetOrAdd(sett.GetUniqueKey(key), (key2) =>
				{
					var dic = resxType.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static)
								.Where(o => o.PropertyType == typeof(string))
								.ToDictionary(o => o.Name, o => o.GetValue(null));

					string fullNameJs = resxType.FullName.Replace("+", ".");

					StringBuilder sb = new StringBuilder();
					sb.AppendLine($"Calysto.Core.RegisterGlobalNs(\"{fullNameJs}\");");
					sb.AppendLine($"{fullNameJs} = {(global::Calysto.Serialization.Json.JsonSerializer.Serialize(dic))};");

					return new FileContent(sb.ToString());
				}));
			}

			return (TMain)this;
		}

		class FileInfoCacheItem
		{
			public string Key;
			public CalystoFileInfo Fi;
			public DateTime Expiration;
		}

		// global file info cache
		static ConcurrentDictionary<string, CalystoFileInfo> _fileInfoCache = new ConcurrentDictionary<string, CalystoFileInfo>();

		private void RegisterScriptFileImpl(string appRelativeVirtualPath)
		{
			//Trace.WriteLine(appRelativeVirtualPath);

			if (this.AllowOncePerContext(appRelativeVirtualPath))
			{
				_fileLocations.Add((sett) =>
				{
					string keyBase = sett.GetUniqueKey(appRelativeVirtualPath);

					CalystoFileInfo fileInfo = _fileInfoCache.GetOrAdd(keyBase + "$#finfo", key => new CalystoPhysicalPathHelper(appRelativeVirtualPath).FindFile());

					// ovako ce se file content reloadirati na serveru, mozemo staviti novi js koji se odmah reloadira, ne treba restart aplikacije
					return _cache.GetOrAdd(keyBase + "$#" + fileInfo.GetFileLastWriteTimeHash(), (key2) =>
					{
						bool isCss = Path.GetExtension(appRelativeVirtualPath) == ".css";
						bool isPhysical = fileInfo is PhysicalFileInfo;

						if (isPhysical && CalystoTools.IsDebugDefined && !sett.Bundle && sett.Debug
							&& sett.Compression == MinifyModeEnum.None
							&& appRelativeVirtualPath.StartsWith("~/")
							&& !CalystoTools.IsUnitTest)
						{
							// najbolje odmah ubaciti map content u file da se kasnije ne zezamo sa hendlanjem .map requesta
							string content2 = MapFileCache.GetFileScriptWithMap(fileInfo.FilePath, fileInfo.FileText);
							return new FileContent(content2, isCss, appRelativeVirtualPath);
						}
						else
						{
							return new FileContent(fileInfo.FileText, isCss);
						}
					});
				});
			}
		}

		public TMain RegisterScriptFile(IEnumerable<string> appRelativeVirtualPath, bool register = true)
		{
			if (register)
				appRelativeVirtualPath.ToList().ForEach(o => this.RegisterScriptFileImpl(o));
			return (TMain)this;
		}

		public TMain RegisterScriptFile(string appRelativeVirtualPath, bool register = true)
		{
			if (register)
				this.RegisterScriptFileImpl(appRelativeVirtualPath);
			return (TMain)this;
		}

		public class AjaxFormSubmitSetting
		{
			/// <summary>
			/// Ajax request timeout in milliseconds.
			/// </summary>
			public int Timeout { get; set; } = 90000;
		}

		private string GetBoolString(bool enable) => enable ? "true" : "false";

		public TMain UseMvcAjaxFormSubmit(bool enable = true)
		{
			return this.RegisterJavaScriptCode($"Calysto.Mvc.AjaxForm.UseAjaxFormSubmit({GetBoolString(enable)});");
		}

		private TMain RegisterEngineConstants()
		{
			string key = nameof(RegisterEngineConstants)
				+ "$$$" + Thread.CurrentThread.CurrentCulture.Name
				+ "$$$" + Thread.CurrentThread.CurrentUICulture.Name;

			if (this.AllowOncePerContext(key))
			{
				_fileLocations.Add((sett) => _cache.GetOrAdd(sett.GetUniqueKey(key), (key2) => new FileContent(this.GetConstantsJavaScript())));
			}
			return (TMain)this;
		}

		public virtual TMain RegisterEngineJS(bool register = true)
		{
			if (register)
			{
				this.RegisterEngineConstants();
				this.RegisterScriptFile(JSFilesList.WebLib_Engine__dist_Core_EngineComplete_js);
			}
			return (TMain)this;
		}

		public TMain RegisterFontAwesome()
		{
			return this.RegisterScriptFile(CSSFilesList.WebLib_Fa__dist_fa_css);
		}

		public TMain RegisterEngineCSS(CssTheme cssTheme = CssTheme.MetroLightBlue)
		{
			return this.RegisterScriptFile(cssTheme.GetStringValue());
		}

		public TMain RegisterJQuery()
		{
			return this.RegisterScriptFile(JSFilesList.WebLib_Extern_jQuery__dist_js_jquery_js);
		}

		public TMain RegisterJQueryValidate()
		{
			this.RegisterScriptFile(JSFilesList.WebLib_Extern_jQuery__dist_js_jquery_validate_js);
			this.RegisterScriptFile(JSFilesList.WebLib_Extern_jQuery__dist_js_jquery_validate_additional_methods_js);
			this.RegisterScriptFile(JSFilesList.WebLib_Extern_jQuery__dist_js_jquery_validate_unobtrusive_js);
			this.RegisterScriptFile(JSFilesList.WebLib_Extern_jQuery__dist_js_jquery_calysto_fixes_js);
			return (TMain)this;
		}

		public TMain RegisterBootstrap()
		{
			// jquery is required for bootstrap js
			this.RegisterScriptFile(CSSFilesList.WebLib_Extern_Bootstrap__dist_css_bootstrap_css);
			this.RegisterScriptFile(JSFilesList.WebLib_Extern_Bootstrap__dist_js_bootstrap_bundle_js);
			return (TMain)this;
		}

		// preprocess for #define, #if, #else, #endif
		HashSet<string> _definedWords = new HashSet<string>();

		/// <summary>
		/// Register DEBUG, TRACE, etc.
		/// </summary>
		/// <param name="words"></param>
		public TMain RegisterDefinedWords(params string[] words)
		{
			foreach (string word in words)
				_definedWords.Add(word);
			return (TMain)this;
		}

		#endregion

		internal IEnumerable<FileCompilerResult> GetCompileResults(CompileSetting sett)
		{
			var fileLocs = _fileLocations.Select(o => o.Invoke(sett));

			if (sett.Bundle)
			{
				return fileLocs.GroupBy(o => o.IsCss + "|" + o.IsInline).Select(group =>
				{
					string uniqueKey = sett.Compression + "$$$" + group.Select(k => k.GetUniqueContentKey()).ToStringJoined("$$$");
					return ScriptsBundleCache.GetCachedCompilerResult(uniqueKey, () =>
					{
						bool isCss = group.First().IsCss;
						bool isInline = group.First().IsInline;
						string joiner = (isCss ? " " : ";") + "\r\n";
						string content = group.Select(m => m.Content).ToStringJoined(joiner) + joiner;
						return new FileCompilerResult(sett, content, isCss, _definedWords, uniqueKey, null, isInline);
					});
				}).OrderBy(o => o.IsCSS ? 0 : 1); // css first
			}
			else
			{
				return fileLocs.Select(o =>
				{
					string uniqueKey = sett.Compression + "$$$" + o.GetUniqueContentKey();
					return ScriptsBundleCache.GetCachedCompilerResult(uniqueKey, () =>
					{
						return new FileCompilerResult(sett, o.Content, o.IsCss, _definedWords, uniqueKey, o.AppRelativeVirtualPath, o.IsInline);
					});
				});
			}
		}

	}
}
