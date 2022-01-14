namespace Calysto
{
	enum PartEnum
	{
		Scheme,
		Host,
		Port,
		Path,
		Query,
		Hash
	}

	export class Uri
	{
		/**
		 * Create new instance from url.
		 * @param url
		 */
		constructor(url?: string)
		{
			if (url) this.ParseUrl(url);
		}

		// http, https, ws, etc.
		public Scheme = "";

		public Username = "";

		public Password = "";

		// domain, eg. domain.com
		public Host = "";

		// port number as string, eg. 21
		public Port = "";

		// eg. /path1/regs.aspx
		public Path = "";

		// eg. ?par1=10&par2=3
		public Query = "";

		// eg. #h1=46
		public Hash = "";

		public CloneUri(startKind: PartEnum, endKind: PartEnum = PartEnum.Hash)
		{
			let uri = new Calysto.Uri();
			if (startKind <= PartEnum.Scheme && endKind >= PartEnum.Scheme)
				uri.Scheme = this.Scheme;

			if (startKind <= PartEnum.Host && endKind >= PartEnum.Host)
			{
				uri.Username = this.Username;
				uri.Password = this.Password;
				uri.Host = this.Host;
			}

			if (startKind <= PartEnum.Port && endKind >= PartEnum.Port)
				uri.Port = this.Port;

			if (startKind <= PartEnum.Path && endKind >= PartEnum.Path)
				uri.Path = this.Path;

			if (startKind <= PartEnum.Query && endKind >= PartEnum.Query)
				uri.Query = this.Query;

			if (startKind <= PartEnum.Hash && endKind >= PartEnum.Hash)
				uri.Hash = this.Hash;

			return uri;
		}

		private BuildUri()
		{
			let sb: string[] = [];

			// scheme
			if (!String.IsNullOrEmpty(this.Scheme)) sb.push(this.Scheme + ":");

			// user, pass, host, port
			if (!String.IsNullOrEmpty(this.Host))
			{
				sb.push("//");
				if (!String.IsNullOrEmpty(this.Username))
				{
					sb.push(this.Username);
					if (!String.IsNullOrEmpty(this.Password)) sb.push(":" + this.Password);
					if (!String.IsNullOrEmpty(this.Username) || !String.IsNullOrEmpty(this.Password)) sb.push("@");
				}

				// host
				if (!String.IsNullOrEmpty(this.Host)) sb.push(this.Host);

				// port
				if (this.Port) sb.push(":" + this.Port);
			}

			// path
			if (!String.IsNullOrEmpty(this.Path)) sb.push(this.Path);

			// query
			if (!String.IsNullOrEmpty(this.Query))
			{
				if (!this.Query.StartsWith("?"))
				{
					sb.push("?");
				}
				sb.push(this.Query);
			}

			// hash
			if (!String.IsNullOrEmpty(this.Hash))
			{
				if (!this.Hash.StartsWith("#"))
				{
					sb.push("#");
				}

				sb.push(this.Hash);
			}

			return sb.join("");
		}

		/**Create scheme://host:port */
		public GetSchemeHost()
		{
			return this.CloneUri(PartEnum.Scheme, PartEnum.Port).BuildUri();
		}

		/**Create scheme://host:port/path */
		public GetSchemeHostPath()
		{
			return this.CloneUri(PartEnum.Scheme, PartEnum.Path).BuildUri();
		}

		/**Create complete URI with hash. */
		public GetAbsoluteUri()
		{
			return this.CloneUri(PartEnum.Scheme).BuildUri();
		}

		/** Relative url: /path?query#hash */
		public GetPathQueryHash()
		{
			return this.CloneUri(PartEnum.Path).BuildUri();
		}

		private ParseUrl(url: string)
		{
			/// <summary>
			/// Parse url.
			/// </summary>
			/// <param name="url" type="String"></param>

			// var m = "http://domainname.com:43/some1/some2/dru.aspx?qu=3&gr=3#dd=rel".match(new RegExp("(([\\w]+)\\:)?" + "((//)([^/\\:]+)(:([\\d]+))?)?" + "([^\\?\\#]+)?" + "(\\?[^\\#]+)?" + "(\\#[\\w\\W]+)?"))
			// ["http://domainname.com:43/some1/some2/dru.aspx?qu=3&gr=3#dd=rel", "http:", "http", "//domainname.com:43", "//", "domainname.com", ":43", "43", "/some1/some2/dru.aspx", "?qu=3&gr=3", "#dd=rel"]

			//var m = "http://domaena.com:233/../some2.aspx?a=10&b=22#some2".match(new RegExp("(([\\w]+)\\:)?" + "((//)([^/\\:]+)(:([\\d]+))?)?" + "(([/]?[\\.]{2})?/[^\\?\\#]*)?" + "(\\?[^\\#]+)?" + "(\\#[\\w\\W]+)?"));
			//["http://domaena.com:233/../some2.aspx?a=10&b=22#some2", "http:", "http", "//domaena.com:233", "//", "domaena.com", ":233", "233", "/../some2.aspx", "/..", "?a=10&b=22", "#some2"]

			// host starts with //
			// port starts with : followed by digit
			// path start with / or ../ or /../, path may have / only, and nothing after, eg: http://domain.com/?m=10
			// query starts with ?
			// hash starts with #

			// test:
			//"http://username:password@www.some1.com:1233/mypath/bill.aspx?a=10&b=20#c=3&c=4"
			// ["http://username:password@www.some1.com:1233/mypath/bill.aspx?a=10&b=20#c=3&c=4", "http:", "http", "//username:password@www.some1.com:1233", "//", "username:password@", "username", ":password", "password", "www.some1.com", ":1233", "1233", "/mypath/bill.aspx", "?a=10&b=20", "#c=3&c=4"]

			if (url)
			{
				var m = url.match(new RegExp(
					"(([\\w]+)\\:)?" // scheme
					+ "((//)(([^\\:@]+)(:([^\\:@]+))?@)?([^/\\:]+)(:([\\d]+))?)?"  // user:pass@host:port, all values are optional
					+ "(/[^\\?\\#]*)?" // path
					+ "(\\?[^\\#]+)?"  // query
					+ "(\\#[\\w\\W]+)?" // hash
				));

				if (m)
				{
					this.Scheme = m[2] || "";
					this.Username = m[6] || "";
					this.Password = m[8] || "";
					this.Host = m[9] || "";
					this.Port = m[11] || "";
					this.Path = m[12] || "";
					this.Query = m[13] || "";
					this.Hash = m[14] || "";
				}
			}
		}
	}
}

