using Calysto.Common;
using Calysto.Common.Extensions;
using Calysto.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Calysto.Net
{
	public class CalystoDnsHelper : IDisposable
	{
		static object _rwlock = new object();
		static CalystoDnsHelper _current;
		public static CalystoDnsHelper Current => _current ?? _rwlock.UsingLock(m => _current ?? (_current = new CalystoDnsHelper()));

		public class DnsItem
		{
			public int TTLSeconds { get; set; } = 60;
			public string Hostname { get; private set; }
			public DateTime? LastSuccessfulDate { get; private set; }
			public IPAddress Address { get; private set; }
			public DateTime? InsertionDate { get; private set; }
			/// <summary>
			/// obaveno gledati prema insertionDate, npr. kad se dns domene promijeni, stari IP ce i dalje biti dobar, nece baciti exception
			/// </summary>
			public bool IsExpired => this.InsertionDate.GetValueOrDefault() < DateTime.Now.AddSeconds(-this.TTLSeconds);
			public bool IsInCache => this.InsertionDate.HasValue;
			CalystoDnsHelper _owner;

			internal DnsItem(CalystoDnsHelper owner, string hostname, IPAddress addr)
			{
				this._owner = owner;
				this.Hostname = hostname;
				this.Address = addr;
			}

			public void AddToCache()
			{
				this.LastSuccessfulDate = DateTime.Now;

				if (!this.IsInCache)
				{
					lock (_owner._dicDnsCache)
					{
						this.InsertionDate = DateTime.Now;
						_owner._dicDnsCache[this.Hostname] = this; // replace existing
					}
				}
			}

			public void RemoveFromCache()
			{
				lock (_owner._dicDnsCache)
					_owner._dicDnsCache.Remove(this.Hostname);
			}
		}

		Dictionary<string, DnsItem> _dicDnsCache = new Dictionary<string, DnsItem>();

		System.Timers.Timer _timer;

		private CalystoDnsHelper()
		{
			_timer = new System.Timers.Timer(5000);
			_timer.Elapsed += _timer_Elapsed; ;
			_timer.AutoReset = true;
			_timer.Start();
		}

		private void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			lock (_dicDnsCache)
			{
				_dicDnsCache.Where(o => o.Value.IsExpired)
					.ToList()
					.ForEach(o => _dicDnsCache.Remove(o.Key));
			}
		}

		~CalystoDnsHelper()
		{
			this.Dispose();
		}

		public bool IsDisposed { get; private set; }

		public void Dispose()
		{
			this.IsDisposed = true;
			try { this._timer?.Stop(); } catch { }
			try { this._timer?.Dispose(); } catch { }
			this._timer = null;

			lock (_dicDnsCache)
				_dicDnsCache.Clear();
		}

		public static readonly IPAddress LoopbackIPv4 = IPAddress.Parse("127.0.0.1");

		public IEnumerable<DnsItem> ResolveAddresses(string hostname)
		{
			if (string.IsNullOrWhiteSpace(hostname) || hostname == "localhost" || hostname == "local.server" || hostname == "127.0.0.1")
			{
				yield return new DnsItem(this, hostname, LoopbackIPv4);
				yield return new DnsItem(this, hostname, LoopbackIPv4);
				yield return new DnsItem(this, hostname, LoopbackIPv4);
			}
			else
			{
				if (_dicDnsCache.TryGetValue(hostname, out DnsItem dns) && !dns.IsExpired)
				{
					yield return dns;
				}

				var res1 = GetHostAddressSafe(hostname);
				if (res1 != null)
				{
					foreach (var item in res1)
					{
						yield return new DnsItem(this, hostname, item);
					}
				}
			}
		}

		/// <summary>
		/// ovo moze baciti exception
		/// </summary>
		/// <param name="hostname"></param>
		/// <returns></returns>
		private IPAddress[] GetHostAddressSafe(string hostname)
		{
			try
			{
				return Dns.GetHostAddresses(hostname); // ovo moze baciti exception
			}
			catch { }
			return null;
		}

	}

}
