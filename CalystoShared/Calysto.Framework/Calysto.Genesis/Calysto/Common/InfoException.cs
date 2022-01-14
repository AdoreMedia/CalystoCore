using System;
using System.Collections.Generic;
using System.Text;

namespace Calysto.Common
{
	public class InfoException : Exception
	{
		public InfoException(string msg)
			: base(msg)
		{
		}

		public InfoException(string msg, Exception innerException)
			: base(msg, innerException)
		{
		}

	}
}
