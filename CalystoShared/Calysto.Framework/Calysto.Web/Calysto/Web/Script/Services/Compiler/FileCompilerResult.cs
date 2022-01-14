using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Calysto.Common.Extensions;
using Calysto.Converter;
using Calysto.Extensions;
using Calysto.IO.Compression;
using Calysto.Linq;
using Calysto.Text.RegularExpressions;
using Microsoft.Ajax.Utilities.Css2;

namespace Calysto.Web.Script.Services.Compiler
{
	internal class FileCompilerResult
	{
		public FileCompilerResult(
			CompileSetting compileSetting,
			string content1,
			bool isContentCss,
			HashSet<string> definedWords,
			string uniqueContentKey,
			string appRelativeVirtualPath,
			bool isInline)
		{
			this.CompileSett = compileSetting;
			this.FileContent = content1;
			this.IsCSS = isContentCss;
			this.DefinedWords = new HashSet<string>(definedWords);
			this.UniqueContentKey = uniqueContentKey;
			this.AppRelativeVirtualPath = appRelativeVirtualPath;
			this.LastModified = DateTime.Now;
			this.IsInline = isInline;
		}

		public DateTime LastModified { get; }

		public string AppRelativeVirtualPath { get; }

		public string UniqueContentKey { get; }

		public string FileContent { get; }

		public bool IsCSS { get; }

		public bool IsInline { get; }

		public CompileSetting CompileSett { get; }

		private HashSet<string> DefinedWords { get; }

		private string _preprocessed;
		/// <summary>
		/// will generate content on first invocation and keep it cached
		/// </summary>
		public string PreprocessedContent => _preprocessed ?? this.UsingLock(m => _preprocessed ?? (_preprocessed = this.PreprocessFileContent(this.FileContent)));

		private string _minified;
		/// <summary>
		/// will generate content on first invocation and keep it cached
		/// </summary>
		public string MinifiedContent => _minified ?? this.UsingLock(m => _minified ?? (_minified = this.MinifyFileContent(this.PreprocessedContent)));

		private string _etag;
		/// <summary>
		/// will generate on first invocation and keep it cached
		/// </summary>
		public string ETag => _etag ?? this.UsingLock(m => _etag ?? (_etag = this.CreateETag()));

		internal string CreateETag(string prefix = null)
		{
			return CalystoBase64Encoder.Base64RndEncoder.EncodeToBase64String(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(prefix + this.MinifiedContent)));
		}

		#region script content preprocess and minify

		/// <summary>
		/// preprocess DEBUG, TDDSPECIFIC, etc.
		/// </summary>
		/// <param name="files"></param>
		private string PreprocessFileContent(string fileContent)
		{
			if (this.CompileSett.Compression == MinifyModeEnum.None)
				return fileContent;

			StringBuilder linesList = new StringBuilder();

			// preprocessor directive must be the first string in the row, there may by white space, // or /* in front only, but nothing else
			Regex re = new Regex("^[\\s]*" + "((\\/\\/)|(\\/\\*))" + "[\\s]*" + "(?<kw>#[\\w]+)" + "[\\s]*" + "(?<negation>[\\!]*)" + "[\\s]*" + "(?<word>[\\d\\w]+)*");

			Stack<bool> includeState = new Stack<bool>();
			includeState.Push(true); // include lines if not defined otherwise

			foreach (var match in new Regex("[\r\n]+").SelectSegments(fileContent))
			{
				if (match.Success)
				{
					// it is new line
					linesList.Append(match.Value);
					continue;
				}

				string line = match.Value;

				Match m = re.Match(line);
				if (m.Success)
				{
					linesList.Append(line); // add command line just to have it for debugging or #region, #endregion etc.

					switch (m.Groups["kw"].Value)
					{
						case "#define":
							this.DefinedWords.Add(m.Groups["word"].Value);
							break;
						case "#if":
							bool contains = this.DefinedWords.Contains(m.Groups["word"].Value);
							bool isNegation = m.Groups["negation"].Value.Split('!').Length % 2 == 0; // e.g. !!! is not, !! is yes, "!!".Split('!').Length % 2 == 0
							includeState.Push(contains != isNegation);
							break;
						case "#else":
							includeState.Push(!includeState.Pop()); // invert value
							break;
						case "#endif":
							includeState.Pop();
							break;

					}
				}
				else if (!includeState.Any())
				{
					throw new Exception("Error, JS preprocessor directive stack is empty at line: " + line);
				}
				else if (includeState.Peek())
				{
					linesList.Append(line);
				}
				else if (!this.IsCSS)
				{
					linesList.Append("// " + line); // add commented line in JS only
				}
			}

			if (includeState.Count != 1)
			{
				throw new Exception("Error, JS preprocessor directive stack count is " + includeState.Count + ", but should be 1");
			}

			return linesList.ToString();
		}

		private string MinifyFileContent(string scriptCode)
		{
			// warning: script content is changed on every recompile because of urls to embedded pictures in css and js
			MinifyModeEnum compressLevel = this.CompileSett.Compression;

			if(compressLevel >= MinifyModeEnum.Minify)
			{
				Microsoft.Ajax.Utilities.Minifier min = new Microsoft.Ajax.Utilities.Minifier();
				Microsoft.Ajax.Utilities.CodeSettings set = new Microsoft.Ajax.Utilities.CodeSettings();

				if (this.IsCSS)
				{
					scriptCode = min.MinifyCSS(scriptCode, compressLevel);
				}
				else
				{
					if (compressLevel >= MinifyModeEnum.Shrink)
						set.LocalRenaming = Microsoft.Ajax.Utilities.LocalRenaming.CrunchAll;
					else
						set.LocalRenaming = Microsoft.Ajax.Utilities.LocalRenaming.KeepAll;

					scriptCode = min.MinifyJavaScript(scriptCode, set);
				}
			}
			else if(compressLevel >= MinifyModeEnum.Preprocess)
			{
				// remove DEBUG blocks only
			}
			else
			{
				// none
			}

			if (!string.IsNullOrWhiteSpace(scriptCode))
			{
				return scriptCode;
			}
			else
			{
				return ""; // da ne bude null u this._minified pa da ne minificira vise puta
			}
		}

		#endregion

		#region compressed content

		internal class CompressedContent
		{
			public byte[] ScriptData;
			public int SciptDataLength;
			public BrowserCompression.KindName ContentEncoding;
		}

		private IEnumerable<CompressedContent> CompressContent(string uncompressedScriptContent)
		{
			CompressedContent ssStd = new CompressedContent();
			ssStd.ScriptData = Encoding.UTF8.GetBytes(uncompressedScriptContent);
			ssStd.SciptDataLength = ssStd.ScriptData.Length;
			ssStd.ContentEncoding = BrowserCompression.KindName.None;
			yield return ssStd;

			if (BrowserCompression.Allowed.Brotli)
			{
				CompressedContent ssBrotli = new CompressedContent();
				ssBrotli.ScriptData = BrotliHelper.Compress(ssStd.ScriptData);
				ssBrotli.SciptDataLength = ssBrotli.ScriptData.Length;
				ssBrotli.ContentEncoding = BrowserCompression.KindName.Brotli;
				yield return ssBrotli;
			}

			if (BrowserCompression.Allowed.Gzip)
			{
				CompressedContent ssGzip = new CompressedContent();
				ssGzip.ScriptData = GZipHelper.Compress(ssStd.ScriptData);
				ssGzip.SciptDataLength = ssGzip.ScriptData.Length;
				ssGzip.ContentEncoding = BrowserCompression.KindName.Gzip;
				yield return ssGzip;
			}

			if (BrowserCompression.Allowed.Deflate)
			{
				CompressedContent ssDeflate = new CompressedContent();
				ssDeflate.ScriptData = DeflateHelper.Compress(ssStd.ScriptData);
				ssDeflate.SciptDataLength = ssDeflate.ScriptData.Length;
				ssDeflate.ContentEncoding = BrowserCompression.KindName.Deflate;
				yield return ssDeflate;
			}
		}

		private Dictionary<BrowserCompression.KindName, CompressedContent> _itemsDic;

		internal Dictionary<BrowserCompression.KindName, CompressedContent> GetCompressedContents()
		{
			if(_itemsDic == null)
			{
				lock (this)
				{
					if(_itemsDic == null)
					{
						_itemsDic = this.CompressContent(this.MinifiedContent).ToDictionary(o => o.ContentEncoding);
					}
				}
			}
			return _itemsDic;
		}

		//private CompressedContent GetCompressedContent()
		//{
		//	if(_itemsDic == null)
		//		_itemsDic = this.UseLock(m => _itemsDic ?? (_itemsDic = CompressContent(this.MinifiedContent).ToDictionary(o=>o.ContentEncoding)));

		//	var encs = Calysto.Web.Hosting.CalystoMvcHostingEnvironment.Current.BrowserCompression;
		//	// get the first one which is supported by the browser
		//	foreach (var kv in this._itemsDic)
		//	{
		//		if (encs.IsSupported(kv.Key))
		//		{
		//			return kv.Value;
		//		}
		//	}
		//	return this._itemsDic[BrowserCompression.KindName.None];
		//}

		///// <summary>
		///// Resolve acceptEncoding from header and return appropriate script package
		///// </summary>
		///// <param name="context"></param>
		///// <returns></returns>
		//internal async Task WriteCachedScriptContentAsync(HttpContext context)
		//{
		//	CalystoContextMvc.Current.ResponseFilter.DisableAll().Lock();

		//	var cc = this.GetCompressedContent();

		//	context.Response.ContentType = (this.IsCSS ? "text/css" : "application/x-javascript") + ";charset=utf-8;";

		//	if (cc.ContentEncoding != BrowserCompression.KindName.None)
		//	{
		//		context.Response.Headers["Content-Encoding"] = cc.ContentEncoding.GetStringValue();
		//	}
		//	context.Response.ContentLength = cc.SciptDataLength;

		//	await context.Response.Body.WriteAsync(cc.ScriptData, 0, cc.SciptDataLength);
		//	await context.Response.Body.FlushAsync();
		//}

		#endregion
	}
}