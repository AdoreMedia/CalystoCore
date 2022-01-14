using System;

namespace Calysto.Diagnostics
{
	/// <summary>
	/// .NETCore log
	/// </summary>
	public class CoreLogProvider : IApplicationLogProvider
	{
		string _sourceName;

		// pisanje je moguce samo u Application i System log, ali sourceName koji se koristi u jednom logu, ne moze se koristiti u drugom (nece upisati event)

		internal CoreLogProvider(string sourceName)
		{
			this._sourceName = sourceName;
		}

		private void WriteLogEntry(Func<string> fnGetMessage)
		{
			Console.WriteLine(fnGetMessage.Invoke()); // default: write to console
		}

		public void WriteError(Func<string> fnGetMessage)
		{
			this.WriteLogEntry(fnGetMessage);
		}

		public void WriteWarning(Func<string> fnGetMessage)
		{
			this.WriteLogEntry(fnGetMessage);
		}

		public void WriteInformation(Func<string> fnGetMessage)
		{
			this.WriteLogEntry(fnGetMessage);
		}
	}
}
