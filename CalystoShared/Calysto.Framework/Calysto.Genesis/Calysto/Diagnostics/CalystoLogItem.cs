using Calysto.Common;
using Calysto.Common.Extensions;
using System;
using System.Text;
using System.Threading;

namespace Calysto.Diagnostics
{
	public class CalystoLogItem
	{
		public enum KindEnum
		{
			Info,
			Diagnostic,
			Error,
			Exception,
			Verbose
		}

		public KindEnum Kind;
		public object Sender;
		public Func<string> FuncGetMessage;
		public Func<Exception> FuncGetException;
		public DateTime CreationDate;
		public string ThreadName;

		static int _cnt1 = 0;

		public CalystoLogItem(KindEnum kind, object sender)
		{
			this.ThreadName = Thread.CurrentThread.Name ?? (Thread.CurrentThread.Name = "#" + Interlocked.Increment(ref _cnt1));
			this.CreationDate = DateTime.Now;
			this.Kind = kind;
			this.Sender = sender;
		}

		public CalystoLogItem(KindEnum kind, object sender, Func<string> fnGetMsg)
			: this(kind, sender)
		{
			this.FuncGetMessage = fnGetMsg;
		}

		public CalystoLogItem(KindEnum kind, object sender, Func<Exception> fnGetException)
			: this(kind, sender)
		{
			this.FuncGetException = fnGetException;
		}

		public string ToStringFormated()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(this.CreationDate.ToString("HH:mm:ss.ffff"));
			sb.Append(" - ");
			sb.Append(this.Kind);
			sb.Append(" - ");
			sb.Append(this.ThreadName);
			sb.Append(" - ");
			sb.Append(this.Sender?.GetType()?.Name);
			sb.Append(" - ");
			if (this.FuncGetException != null)
				sb.Append(this.FuncGetException?.Invoke()?.UnwindToString());
			else
				sb.Append(this.FuncGetMessage?.Invoke());

			return sb.ToString();
		}
	}

}
