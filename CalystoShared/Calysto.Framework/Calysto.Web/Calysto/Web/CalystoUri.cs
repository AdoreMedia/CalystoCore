using Calysto.Linq;
using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Calysto.Web
{
	public class CalystoUri
	{
		public CalystoUri()
		{

		}

		public CalystoUri(string url)
		{
			this.ParseUrl(url);
		}

		/// <summary>
		/// True if host is IP address
		/// </summary>
		/// <returns></returns>
		public bool IsIpAddress()
		{
			var parts = (this.Host ?? "").Split('.');
			int tmp;
			return parts.Any() && parts.All(p => int.TryParse(p, out tmp));
		}

		/// <summary>
		/// http, https, ws, etc.
		/// </summary>
		public string Scheme { get; set; }

		public string Username { get; set; }

		public string Password { get; set; }

		/// <summary>
		/// domain, eg. domain.com
		/// </summary>
		public string Host { get; set; }

		/// <summary>
		/// port number as string, eg. 21
		/// </summary>
		public int? Port { get; set; }

		/// <summary>
		/// e.g. /path1
		/// </summary>
		public string PathBase { get; set; }

		/// <summary>
		/// app relative path
		/// eg. /regs.aspx
		/// </summary>
		public string Path { get; set; }

		/// <summary>
		/// eg. ?par1=10&par2=3
		/// </summary>
		public string Query { get; set; }

		/// <summary>
		/// eg. #h1=46
		/// </summary>
		public string Hash { get; set; }

		public enum PartEnum
		{
			Scheme,
			Host,
			Port,
			PathBase,
			Path,
			Query,
			Hash
		}

		private static PropertyInfo[] _properties = typeof(CalystoUri).GetProperties();

		public CalystoUri CloneUri()
		{
			var item = new CalystoUri();
			_properties.ForEach(prop => prop.SetValue(item, prop.GetValue(this)));
			return item;
		}

		public CalystoUri CloneUri(PartEnum startKind = PartEnum.Scheme, PartEnum endKind = PartEnum.Hash)
		{
			CalystoUri uri = new CalystoUri();
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

			if (startKind <= PartEnum.PathBase && endKind >= PartEnum.PathBase)
				uri.PathBase = this.PathBase;

			if (startKind <= PartEnum.Path && endKind >= PartEnum.Path)
				uri.Path = this.Path;

			if (startKind <= PartEnum.Query && endKind >= PartEnum.Query)
				uri.Query = this.Query;

			if (startKind <= PartEnum.Hash && endKind >= PartEnum.Hash)
				uri.Hash = this.Hash;

			return uri;
		}

		private string BuildUri()
		{
			StringBuilder sb = new StringBuilder();

			// scheme
			if (!string.IsNullOrEmpty(this.Scheme)) sb.Append(this.Scheme + ":");

			// user, pass, host, port
			if (!string.IsNullOrEmpty(this.Host))
			{
				sb.Append("//");
				if (!string.IsNullOrEmpty(this.Username))
				{
					sb.Append(this.Username);
					if (!string.IsNullOrEmpty(this.Password)) sb.Append(":" + this.Password);
					if (!string.IsNullOrEmpty(this.Username) || !string.IsNullOrEmpty(this.Password)) sb.Append("@");
				}
				if (!string.IsNullOrEmpty(this.Host)) sb.Append(this.Host);

				// port
				if (this.Port.HasValue) sb.Append(":" + this.Port);
			}

			// pathBase + path
			var list1 = new string[] { this.PathBase, this.Path }.Select(o => o?.Trim(' ', '/')).Where(o => !string.IsNullOrEmpty(o)).ToList();
			if (list1.Any())
			{
				sb.Append("/");
				sb.Append(string.Join("/", list1));
			}

			// query
			if (!string.IsNullOrEmpty(this.Query))
			{
				if (!this.Query.StartsWith("?"))
				{
					sb.Append("?");
				}
				sb.Append(this.Query);
			}

			// hash
			if (!string.IsNullOrEmpty(this.Hash))
			{
				if (!this.Hash.StartsWith("#"))
				{
					sb.Append("#");
				}
				sb.Append(this.Hash);
			}

			return sb.ToString();
		}

		/// <summary>
		/// Create scheme://host:port
		/// </summary>
		/// <returns></returns>
		public string GetSchemeHost()
		{
			return this.CloneUri(PartEnum.Scheme, PartEnum.Port).BuildUri();
		}

		/// <summary>
		/// Create scheme://host:port/path
		/// </summary>
		/// <returns></returns>
		public string GetSchemeHostPathBase()
		{
			return this.CloneUri(PartEnum.Scheme, PartEnum.PathBase).BuildUri();
		}

		/// <summary>
		/// Create scheme://host:port/path
		/// </summary>
		/// <returns></returns>
		public string GetSchemeHostPath()
		{
			return this.CloneUri(PartEnum.Scheme, PartEnum.Path).BuildUri();
		}

		/// <summary>
		/// Create complete URI with hash.
		/// </summary>
		/// <returns></returns>
		public string GetAbsoluteUri()
		{
			return this.CloneUri(PartEnum.Scheme).BuildUri();
		}

		/// <summary>
		/// Create relative url.
		/// </summary>
		/// <returns></returns>
		public string GetPathQueryHash()
		{
			return this.CloneUri(PartEnum.Path).BuildUri();
		}

		protected CalystoUri ParseUrl(string url)
		{
			/// <summary>
			/// Parse url and retuns this instance.
			/// </summary>
			/// <param name="url" type="String"></param>

			// var m = "http://domena.com:43/nesto/dva/dru.aspx?qu=3&gr=3#dd=rel".match(new RegExp("(([\\w]+)\\:)?" + "((//)([^/\\:]+)(:([\\d]+))?)?" + "([^\\?\\#]+)?" + "(\\?[^\\#]+)?" + "(\\#[\\w\\W]+)?"))

			// ["http://domena.com:43/nesto/dva/dru.aspx?qu=3&gr=3#dd=rel", "http:", "http", "//domena.com:43", "//", "domena.com", ":43", "43", "/nesto/dva/dru.aspx", "?qu=3&gr=3", "#dd=rel"]

			//var m = "http://domaena.com:233/../dva.aspx?a=10&b=22#dva".match(new RegExp("(([\\w]+)\\:)?" + "((//)([^/\\:]+)(:([\\d]+))?)?" + "(([/]?[\\.]{2})?/[^\\?\\#]*)?" + "(\\?[^\\#]+)?" + "(\\#[\\w\\W]+)?"));
			//["http://domaena.com:233/../dva.aspx?a=10&b=22#dva", "http:", "http", "//domaena.com:233", "//", "domaena.com", ":233", "233", "/../dva.aspx", "/..", "?a=10&b=22", "#dva"]

			// host starts with //
			// port starts with : followed by digit
			// path start with / or ../ or /../, path may have / only, and nothing after, eg: http://domain.com/?m=10
			// query starts with ?
			// hash starts with #

			if (!string.IsNullOrEmpty(url))
			{
				Match m = new Regex(
					"(([\\w]+)\\:)?" // scheme
					+ "((//)(([^\\:@]+)(:([^\\:@]+))?@)?([^/\\:]+)(:([\\d]+))?)?"  // user:pass@host:port, all values are optional
					+ "(/[^\\?\\#]*)?" // path
					+ "(\\?[^\\#]+)?"  // query
					+ "(\\#[\\w\\W]+)?" // hash
					).Match(url);
				if (m.Success)
				{
					this.Scheme = m.Groups[2].Value;
					this.Username = m.Groups[6].Value;
					this.Password = m.Groups[8].Value;
					this.Host = m.Groups[9].Value;
					this.Path = m.Groups[12].Value;
					this.Query = m.Groups[13].Value;
					this.Hash = m.Groups[14].Value;

					int port;
					if (int.TryParse(m.Groups[11].Value, out port))
					{
						this.Port = port;
					}
				}
			}
			return this;
		}

		/// <summary>
		/// Will invoke action on current instance and return current instance.
		/// </summary>
		/// <param name="action"></param>
		/// <returns></returns>
		public CalystoUri Set(Action<CalystoUri> action)
		{
			action.Invoke(this);
			return this;
		}
	}
}
