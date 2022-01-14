using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO.Compression;
using System.Text.RegularExpressions;
using Brotli;
using Calysto.Extensions;
using Calysto.Web.Hosting;

namespace Calysto.Web.Filter
{
	/* Add hander to Global.asax.cx:
	 
		protected void Application_PostRequestHandlerExecute(object sender, EventArgs e)
		{
			if (CalystoScriptManager.BuildKind == BuildKindEnum.Release)
			{
				Calysto.Web.Filter.ResponseFilterHelper.Current.ApplyIfHtml(true, true);
			}
		}

	*/
	public class ResponseFilterHelper
	{
		HttpContext _context;

		/// <summary>
		/// Returns null if HttpContext.Current is null
		/// </summary>
		public static ResponseFilterHelper GetCurrent(HttpContext context)
		{
			ResponseFilterHelper ss = context.Items[nameof(ResponseFilterHelper)] as ResponseFilterHelper;
			if (ss == null)
			{
				ss = new ResponseFilterHelper();
				ss._context = context;
				context.Items[nameof(ResponseFilterHelper)] = ss;
			}
			return ss;
		}

		public class Settings
		{
			/// <summary>
			/// if true, compress output stream
			/// </summary>
			public bool Compress { get; set; }
			/// <summary>
			/// if true, minify html
			/// </summary>
			public bool Minify { get; set; }
			/// <summary>
			/// if true, disable compression always
			/// </summary>
			public bool DisableCompress { get; set; }
			/// <summary>
			/// if true, disable minify always
			/// </summary>
			public bool DisableMinify { get; set; }
			/// <summary>
			/// if true, will not allow feature modification to settings
			/// </summary>
			public bool Locked { get; set; }

			public bool DisableEncryption { get; set; }

			public bool EncryptHtml { get; set; }
		}

		public static string HeaderSignature { get; set; }

		private Settings _settings = new Settings();

		#region public methods

		/// <summary>
		/// Lock settings to disable future modifications.
		/// </summary>
		/// <returns></returns>
		public ResponseFilterHelper Lock()
		{
			this._settings.Locked = true;
			return this;
		}

		/// <summary>
		/// Set settings and apply changes.
		/// </summary>
		/// <param name="action"></param>
		/// <returns></returns>
		public ResponseFilterHelper Apply(Action<Settings> action)
		{
			// if locked, prevent modifications
			if (this._settings.Locked) return this;

			action.Invoke(this._settings);
			return this.RemoveFiltersWorker().ApplyFiltersWorker();
		}

		/// <summary>
		/// if content type is text/html and not .axd extension, set filters in settings and apply changes.
		/// </summary>
		/// <param name="minifyHtml"></param>
		/// <param name="gZipCompress"></param>
		/// <returns></returns>
		public ResponseFilterHelper ApplyIfHtml(bool gZipCompress, bool minifyHtml = false, bool encryptHtml = false)
		{
			if (this.IsHtmlContent() && !this.IsAxdPath())
			{
				return this.Apply(o =>
				{
					o.Minify = minifyHtml;
					o.Compress = gZipCompress;
					o.EncryptHtml = encryptHtml;
				});
			}
			return this;
		}

		/// <summary>
		/// Disable filters in settings and apply changes.
		/// </summary>
		/// <param name="disableMinify"></param>
		/// <param name="disableCompress"></param>
		/// <returns></returns>
		public ResponseFilterHelper DisableEncryption()
		{
			return this.Apply(o =>
			{
				o.DisableEncryption = true;
			});
		}

		/// <summary>
		/// Disable filters in settings and apply changes.
		/// </summary>
		/// <param name="disableMinify"></param>
		/// <param name="disableCompress"></param>
		/// <returns></returns>
		public ResponseFilterHelper Disable(bool disableCompress, bool disableMinify)
		{
			return this.Apply(o =>
			{
				o.DisableMinify = disableMinify;
				o.DisableCompress = disableCompress;
			});
		}

		/// <summary>
		/// Disable all filters in settings and apply changes.
		/// </summary>
		/// <returns></returns>
		public ResponseFilterHelper DisableAll()
		{
			return this.Disable(true, true);
		}

		/// <summary>
		/// Remove all filters in settings and apply changes.
		/// </summary>
		/// <returns></returns>
		public ResponseFilterHelper RemoveAll()
		{
			return this.Apply(o =>
			{
				o.Minify = false;
				o.Compress = false;
			});
		}

		#endregion

		#region private methods

		public ResponseFilterHelper RemoveFiltersWorker()
		{
			_context.Response.Headers.Remove("Content-Encoding");

			int cnt = 0;
			bool isFound;

			do
			{
				if (++cnt > 10)
				{
					throw new Exception("Endless loop in RemoveFilters()");
				}

				isFound = false;

				if (_context.Response.Filter is CalystoHtmlMinifyFilter)
				{
					_context.Response.Filter = (_context.Response.Filter as CalystoHtmlMinifyFilter).BaseStream;
					isFound = true;
				}

				if (_context.Response.Filter is DeflateStream)
				{
					_context.Response.Filter = (_context.Response.Filter as DeflateStream).BaseStream;
					isFound = true;
				}

				if (_context.Response.Filter is GZipStream)
				{
					_context.Response.Filter = (_context.Response.Filter as GZipStream).BaseStream;
					isFound = true;
				}

			} while (isFound);

			return this;
		}

		private ResponseFilterHelper ApplyFiltersWorker()
		{
			HttpContext context = HttpContext.Current;
			HttpResponse resp = context?.Response;

			if (resp != null && resp.StatusCode == 200 && !resp.IsRequestBeingRedirected)
			{
				// allow
			}
			else
			{
				// don't use filters
				return this;
			}

			if (this._settings.Compress && !this._settings.DisableCompress)
			{
				ApplyCompressionFilter();
			}

			if (this._settings.Minify && !this._settings.DisableMinify)
			{
				ApplyMinifyFilter();
			}

			return this;
		}

		private bool IsHtmlContent()
		{
			string contentType = HttpContext.Current.Response.ContentType.ToLower();
			return contentType.Contains("text/html");
		}

		private bool IsAxdPath()
		{
			// https://mknew.hr/elmah.axd/detail?id=9b8d3a88-1629-438f-b36a-f785945949b0
			// https://mknew.hr/elmah.axd?page=1&size=100

			return _context.Request.RawUrl.Contains(".axd");
		}

		private void ApplyMinifyFilter()
		{
			if (_context.Response.ContentType?.ToLower().Contains("text/html") == true)
			{
				_context.Response.Filter = new CalystoHtmlMinifyFilter(
					_context.Response.Filter,
					this._settings.EncryptHtml && !this._settings.DisableEncryption
				);
			}
		}

		private void ApplyCompressionFilter()
		{
			string contentType = _context.Response.ContentType.ToLower();

			if (contentType.Contains("text") || contentType.Contains("json") || contentType.Contains("javascript"))
			{
				// allow
			}
			else
			{
				// don't allow compression
				return;
			}

			// context.Request.Headers["Accept-Encoding"];
			var compr = CalystoFormsHostingEnvironment.Current.BrowserCompression;

			if (compr.IsNone)
			{
				return;
			}
			else if (compr.IsGzip)
			{
				// gzip
				_context.Response.Filter = new GZipStream(_context.Response.Filter, CompressionMode.Compress);
				_context.Response.AppendHeader("Content-Encoding", BrowserCompression.KindName.Gzip.GetStringValue());
			}
			else if (compr.IsDeflate)
			{
				// defalte
				_context.Response.Filter = new DeflateStream(_context.Response.Filter, CompressionMode.Compress);
				_context.Response.AppendHeader("Content-Encoding", BrowserCompression.KindName.Deflate.GetStringValue());
			}
			else if (compr.IsBrotli)
			{
				// brotli
				// https://github.com/XieJJ99/brotli.net
				// let it has the lowest priority since IE has problem with brotli
				_context.Response.Filter = new BrotliStream(_context.Response.Filter, CompressionMode.Compress);
				_context.Response.AppendHeader("Content-Encoding", BrowserCompression.KindName.Brotli.GetStringValue());
			}
			else
			{
				// leave as-is (no compression)
				throw new Exception("Unknown browser compression: " + compr.AcceptEncoding);
			}

		}


		#endregion

	}
}
