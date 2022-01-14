using Calysto.Common;
using Calysto.Common.Extensions;
using System;
using System.Text;

namespace Calysto.Diagnostics
{
	public class CalystoLogger
	{
		//public TunnelServerTests1()
		//{
		//	AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException;
		//	AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
		//	Application.ThreadException += Application_ThreadException;
		//}

		static byte[] TakeFirst(byte[] buffer, int offsetStart, int takeLength)
		{
			int bufferLen = buffer.Length - offsetStart;
			int len1 = Math.Min(takeLength, bufferLen);

			if (len1 < 1)
			{
				return new byte[0];
			}
			else
			{
				byte[] data = new byte[len1];
				Array.Copy(buffer, offsetStart, data, 0, len1);
				return data;
			}
		}

		public static string BytesToStringLimitedLength(byte[] data, int maxLength = 100)
		{
			if (data == null) return "[no-data]";
			return Encoding.UTF8.GetString(TakeFirst(data, 0, maxLength)).Replace((char)0, '-');
		}

		private static object _rwlock = new object();
		private static CalystoLogger _current;
		public static CalystoLogger Current => _current ?? _rwlock.UsingLock(a => _current ?? (_current = new CalystoLogger()));

		public event Action<CalystoLogItem> OnLog;

		private void NotifyLog(CalystoLogItem item)
		{
			try
			{
				this.OnLog?.Invoke(item);
			}
			catch { }
		}

		public void Log(CalystoLogItem.KindEnum kind, object sender, Func<string> func) => this.NotifyLog(new CalystoLogItem(kind, sender, func));

		public void Info(object sender, Func<string> func) => this.NotifyLog(new CalystoLogItem(CalystoLogItem.KindEnum.Info, sender, func));

		public void Diagnostic(object sender, Func<string> func) => this.NotifyLog(new CalystoLogItem(CalystoLogItem.KindEnum.Diagnostic, sender, func));

		public void Verbose(object sender, Func<string> func) => this.NotifyLog(new CalystoLogItem(CalystoLogItem.KindEnum.Verbose, sender, func));

		public void Error(object sender, Func<string> func) => this.NotifyLog(new CalystoLogItem(CalystoLogItem.KindEnum.Error, sender, func));

		public void Exception(object sender, Func<Exception> func) => this.NotifyLog(new CalystoLogItem(CalystoLogItem.KindEnum.Exception, sender, func));
	}
}
