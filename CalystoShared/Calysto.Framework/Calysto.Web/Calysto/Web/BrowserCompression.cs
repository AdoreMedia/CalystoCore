using Calysto.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calysto.Web
{
	public class BrowserCompression
	{
		public enum KindName
		{
			[StringValue(null)]
			None,

			[StringValue("gzip")]
			Gzip,

			[StringValue("deflate")]
			Deflate,

			[StringValue("br")]
			Brotli
		}

		public class Allowed
		{
			public const bool Gzip = true;

			/// <summary>
			/// 
			/// </summary>
			public const bool Deflate = true;

			/// <summary>
			/// Firefox and old browsers doesn't support brotli very well.
			/// </summary>
			public const bool Brotli = false;
		}

		private Dictionary<string, string> _dic;

		/// <summary>
		/// Original Accept-Encoding string from browser
		/// </summary>
		public string AcceptEncoding;
		public bool IsNone => !_dic.Any();
		public bool IsBrotli => _dic.ContainsKey("br");
		public bool IsGzip => _dic.ContainsKey("gzip");
		public bool IsDeflate => _dic.ContainsKey("deflate");

		public bool IsSupported(KindName compr)
		{
			switch (compr)
			{
				case KindName.None:
					return this.IsNone;
				case KindName.Brotli:
					return this.IsBrotli;
				case KindName.Deflate:
					return this.IsDeflate;
				case KindName.Gzip:
					return this.IsGzip;
				default:
					return false; // e.g. "identity" which is sent by Safari sometimes
			}
		}

		// headers example, .NET Core 3.1
		//header keys:
		//	[0]: "Accept"
		//  [1]: "Accept-Encoding"
		//  [2]: "Accept-Language"
		//  [3]: "Authorization"
		//  [4]: "Cache-Control"
		//  [5]: "Connection"
		//  [6]: "Host"
		//  [7]: "User-Agent"
		//  [8]: "Upgrade-Insecure-Requests"
		//  [9]: "Sec-Fetch-Site"
		//  [10]: "Sec-Fetch-Mode"
		//  [11]: "Sec-Fetch-User"
		//  [12]: "Sec-Fetch-Dest"

		// header values:
		//	[0]: {text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9}
		//  [1]: {gzip, deflate, br}
		//  [2]: {en-US,en;q=0.9,hr;q=0.8}
		//  [3]: {Basic YTph}
		//  [4]: {keep-alive}
		//  [5]: {localhost}
		//  [6]: {Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/81.0.4044.129 Safari/537.36 Edg/81.0.416.68}
		//  [7]: {1}
		//  [8]: {none}
		//  [9]: {navigate}
		//  [10]: {?1}
		//  [11]: {document}


		public static BrowserCompression Detect(string acceptEncoding)
		{
			var bc = new BrowserCompression();
			bc.AcceptEncoding = acceptEncoding; // CalystoHostingEnvironment.Current.HttpContext.Request.Headers["Accept-Encoding"]+"";
			string s1 = bc.AcceptEncoding
				.Replace("identity", "") // means no compression
				.Replace("*", ",br,gzip,deflate,");

			bc._dic = Regex.Split(s1, "[^\\w]+")
				.Distinct()
				.Select(o => o.ToLower())
				.Distinct()
				// br doesn't work well on older browsers
				.Where(o =>
					(Allowed.Gzip && o == "gzip")
					|| (Allowed.Deflate && o == "deflate")
					|| (Allowed.Brotli && o == "br")
				).ToDictionary(o => o);

			return bc;
		}

	}
}