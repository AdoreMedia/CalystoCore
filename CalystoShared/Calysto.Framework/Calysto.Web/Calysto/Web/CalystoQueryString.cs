using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using Calysto.Utility;
using Calysto.Linq;
#if !SILVERLIGHT
using System.Web;
using System.Collections.Specialized;
#else
using System.Windows.Browser;
#endif

namespace Calysto.Web
{
	/// <summary>
	/// Key case non-sensitive
	/// </summary>
	[DebuggerDisplay("{FullUrl}")]
	public class CalystoQueryString
	{
		private string FullUrl { get { return this.GetUrl(); } }

		protected Dictionary<string, KeyValuePair<string, object>> _dic = new Dictionary<string, KeyValuePair<string, object>>();

		/// <summary>
		/// Get or set scheme://host:port/path
		/// </summary>
		public string BaseURL
		{
			get 
			{ 
				return this.InnerUri.GetSchemeHostPath(); 
			}			
			set
			{
				CalystoUri uri = new CalystoUri(value);
				this.InnerUri.Scheme = uri.Scheme;
				this.InnerUri.Host = uri.Host;
				this.InnerUri.Port = uri.Port;
				this.InnerUri.Path = uri.Path;
			}
		}

		private CalystoUri _uri;

		public CalystoUri InnerUri
		{
			get { return _uri ?? (_uri = new CalystoUri());}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value">if null, removes key and value from collection, bool value can be null, true, false</param>
		/// <returns></returns>
		public CalystoQueryString SetValue(string key, object value)
		{
			if (value == null)
			{
				this._dic.Remove(key.ToLower());
			}
			else
			{
				if (value.GetType() == typeof(bool))
				{
					value = (bool)value == true ? "1" : "0";
				}

				this._dic[key.ToLower()] = new KeyValuePair<string, object>(key, value);
			}
			return this;
		}

		public CalystoQueryString RemoveValue(string key)
		{
			this._dic.Remove(key.ToLower());
			return this;
		}

		public T GetValue<T>(string key)
		{
			KeyValuePair<string, object> kv;
			if (this._dic.TryGetValue(key.ToLower(), out kv))
			{
				return CalystoTypeConverter.ChangeType<T>(kv.Value);
			}
			return default(T);
		}

		/// <summary>
		/// Extract query part from url and parse it.
		/// </summary>
		/// <param name="url"></param>
		public void ParseUrl(string url)
		{
			// accept:
			// 1. /path.aspx?d=43&gg=22#fg
			// 2. d=34&bb=534
			// 3. ?d=gg&dt=443

			this._dic = new Dictionary<string, KeyValuePair<string, object>>();
			this._uri = new CalystoUri(url);
			var qstr = (this._uri.Query ?? "").Trim('?');

			if (!string.IsNullOrEmpty(qstr))
			{
				// extract query string only

				foreach(string pair in qstr.Split('&'))
				{
					string [] pp = pair.Split('=');
					string name = HttpUtility.UrlDecode(pp.FirstOrDefault());
					string value = HttpUtility.UrlDecode(pp.Skip(1).FirstOrDefault());
					this.SetValue(name, value);
				}
			}
		}

		/// <summary>
		/// Return query string with ? if there is any data
		/// </summary>
		/// <returns></returns>
		public string GetQuery()
		{
			string qstr = _dic.Values.Select(o => HttpUtility.UrlEncode(o.Key) + "=" + HttpUtility.UrlEncode(o.Value + "")).ToStringJoined("&");
			return string.IsNullOrEmpty(qstr) ? null : ("?" + qstr);
		}

		/// <summary>
		/// Return full url
		/// </summary>
		/// <returns></returns>
		public virtual string GetUrl()
		{
			CalystoUri uri = this.InnerUri.CloneUri();
			uri.Query = this.GetQuery();
			return uri.GetAbsoluteUri();
		}

		public NameValueCollection ToNameValueCollection()
		{
			NameValueCollection nv = new NameValueCollection();
			// dic.Key is lowercase key
			// dic.Value contains KeyValue item with original case key and value
			_dic.ForEach(o => nv.Add(o.Value.Key, o.Value.Value == null ? null : o.Value.Value+""));
			return nv;
		}

		public Dictionary<string, object> ToDictionary()
		{
			return _dic.Values.ToDictionary(o => o.Key, o => o.Value);
		}

	}
}
