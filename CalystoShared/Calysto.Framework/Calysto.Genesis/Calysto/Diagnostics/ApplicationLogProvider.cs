using Calysto.Utility;

namespace Calysto.Diagnostics
{
	public class ApplicationLogProvider
	{
		/// <summary>
		/// Create log provider for Core or Windows, auto select by IsDotNetCore
		/// </summary>
		/// <param name="sourceName"></param>
		/// <returns></returns>
		public static IApplicationLogProvider CreateLogProvider(string sourceName)
		{
			return new CoreLogProvider(sourceName);

			//if (DotNetCoreUtility.IsDotNetCore)
			//	return new CoreLogProvider(sourceName);
			//else
			//	return new WindowsLogProvider(sourceName);
		}
	}
}
