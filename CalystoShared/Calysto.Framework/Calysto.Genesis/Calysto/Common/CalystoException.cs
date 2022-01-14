using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Calysto.Common
{
	public class CalystoException : Exception
	{
		public CalystoException(CalystoExceptionNode node, CalystoException innerException) 
			: base(node.Message, innerException)
		{
			this._message = node.Message;
			this._stackTraceString = $"{node.Type}: {node.Message} \r\n{node.StackTrace}";
			this._helpURL = HelpLink;
			this._source = Source;
			this._data = Data;
		}

		string _message;
		public override string Message => _message;

		private IDictionary _data;
		public override IDictionary Data => _data;

		private string _stackTraceString;
		public override string StackTrace => _stackTraceString;

		private string _helpURL;
		public override string HelpLink { get => _helpURL; set => _helpURL = value; }

		private string _source;
		public override string Source { get => _source; set => _source = value; }

	}
}
