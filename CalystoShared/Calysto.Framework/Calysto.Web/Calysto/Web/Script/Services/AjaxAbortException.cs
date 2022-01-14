using System;

namespace Calysto.Web.Script.Services
{
	public abstract class AjaxAbortException : Exception
	{
		public AjaxAbortException(string errorMsg) : base(errorMsg)
		{ }
	}
}
