using System;

namespace Calysto.Diagnostics
{
	public interface IApplicationLogProvider
	{
		void WriteError(Func<string> fnGetMessage);
		void WriteInformation(Func<string> fnGetMessage);
		void WriteWarning(Func<string> fnGetMessage);
	}
}