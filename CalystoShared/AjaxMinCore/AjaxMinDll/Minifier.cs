// Minifier.cs
//
// Copyright 2010 Microsoft Corporation
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Microsoft.Ajax.Utilities.Css2;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Microsoft.Ajax.Utilities
{
	/// <summary>
	/// Minifier class for quick minification of JavaScript or Stylesheet code without needing to
	/// access or modify any abstract syntax tree nodes. Just put in source code and get our minified
	/// code as strings.
	/// </summary>
	public class Minifier
	{
#if NETSTANDARD
		private static bool? _isDotNetCore;

		private static bool IsDotNetCore => _isDotNetCore ?? (_isDotNetCore = ResolveIsDotNetCore()) ?? false;

		private static bool ResolveIsDotNetCore()
		{
			if (typeof(object).AssemblyQualifiedName.StartsWith("System.Object, System.Private.CoreLib"))
				return true;
			else if (typeof(object).AssemblyQualifiedName.StartsWith("System.Object, mscorlib"))
				return false;
			else
				throw new NotSupportedException(); // radi sigurnosti, ako se nesto promijeni da ne postoji nikakav podatak
		}

		public static void RegisterEncodingProviders()
		{
			// By default, ExcelDataReader throws a NotSupportedException "No data is available for encoding 1252." on.NET Core.
			// To fix, add a dependency to the package System.Text.Encoding.CodePages and then add code to register the code page provider during application initialization(f.ex in Startup.cs):
			// System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
			// This is required to parse strings in binary BIFF2-5 Excel documents encoded with DOS - era code pages. These encodings are registered by default in the full .NET Framework, but not on .NET Core.

			System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
		}

		static Minifier()
		{
			if (IsDotNetCore)
			{
				Minifier.RegisterEncodingProviders();
			}
		}

#endif

		#region Properties

		/// <summary>
		/// Warning level threshold for reporting errors.
		/// Default value is zero: syntax/run-time errors.
		/// </summary>
		public int WarningLevel
		{
			get; set;
		}

		/// <summary>
		/// File name to use in error reporting.
		/// Default value is null: use Minify... method name.
		/// </summary>
		public string FileName
		{
			get; set;
		}

		/// <summary>
		/// Collection of ContextError objects found during minification process
		/// </summary>
		public ICollection<ContextError> ErrorList { get { return m_errorList; } }
		private List<ContextError> m_errorList; // = null;

		/// <summary>
		/// Collection of any error strings found during the crunch process.
		/// </summary>
		public ICollection<string> Errors
		{
			get
			{
				var errorList = new List<string>(ErrorList.Count);
				foreach (var error in ErrorList)
				{
					errorList.Add(error.ToString());
				}
				return errorList;
			}
		}

		#endregion

		#region JavaScript methods

		/// <summary>
		/// MinifyJavaScript JS string passed to it using default code minification settings.
		/// The ErrorList property will be set with any errors found during the minification process.
		/// </summary>
		/// <param name="source">source Javascript</param>
		/// <returns>minified Javascript</returns>
		public string MinifyJavaScript(string source)
		{
			// just pass in default settings
			return MinifyJavaScript(source, new CodeSettings());
		}

		/// <summary>
		/// Crunched JS string passed to it, returning crunched string.
		/// The ErrorList property will be set with any errors found during the minification process.
		/// </summary>
		/// <param name="source">source Javascript</param>
		/// <param name="codeSettings">code minification settings</param>
		/// <returns>minified Javascript</returns>
		public string MinifyJavaScript(string source, CodeSettings codeSettings)
		{
			// default is an empty string
			var crunched = string.Empty;

			// reset the errors builder
			m_errorList = new List<ContextError>();

			// create the parser and hook the engine error event
			var parser = new JSParser();
			parser.CompilerError += OnJavaScriptError;

			var sb = StringBuilderPool.Acquire();
			try
			{
				var preprocessOnly = codeSettings != null && codeSettings.PreprocessOnly;
				using (var stringWriter = new StringWriter(sb, CultureInfo.InvariantCulture))
				{
					if (preprocessOnly)
					{
						parser.EchoWriter = stringWriter;
					}

					// parse the input
					var scriptBlock = parser.Parse(new DocumentContext(source) { FileContext = this.FileName }, codeSettings);
					if (scriptBlock != null && !preprocessOnly)
					{
						// we'll return the crunched code
						if (codeSettings != null && codeSettings.Format == JavaScriptFormat.JSON)
						{
							// we're going to use a different output visitor -- one
							// that specifically returns valid JSON.
							if (!JSONOutputVisitor.Apply(stringWriter, scriptBlock, codeSettings))
							{
								m_errorList.Add(new ContextError()
								{
									Severity = 0,
									File = this.FileName,
									Message = CommonStrings.InvalidJSONOutput,
								});
							}
						}
						else
						{
							// just use the normal output visitor
							OutputVisitor.Apply(stringWriter, scriptBlock, codeSettings, parser.ParsedVersion);

							// if we are asking for a symbols map, give it a chance to output a little something
							// to the minified file.
							if (codeSettings != null && codeSettings.SymbolsMap != null)
							{
								codeSettings.SymbolsMap.EndFile(stringWriter, codeSettings.LineTerminator);
							}
						}
					}
				}

				crunched = sb.ToString();
			}
			catch (Exception e)
			{
				m_errorList.Add(new ContextError()
				{
					Severity = 0,
					File = this.FileName,
					Message = e.Message,
				});
				throw;
			}
			finally
			{
				sb.Release();
			}

			return crunched;
		}

		#endregion

		#region CSS methods

		public string MinifyCSS(string source, MinifyModeEnum mode)
		{
			return CssMinifier.Minify(source, mode);
		}

		#endregion

		#region Error-handling Members

		private void OnJavaScriptError(object sender, ContextErrorEventArgs e)
		{
			var error = e.Error;
			if (error.Severity <= WarningLevel)
			{
				m_errorList.Add(error);
			}
		}

		#endregion
	}
}