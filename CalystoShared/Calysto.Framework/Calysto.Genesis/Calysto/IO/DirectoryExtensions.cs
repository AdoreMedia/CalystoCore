using System.Collections.Generic;
using System.IO;

namespace Calysto.IO
{
	public static class DirectoryExtensions
	{
		public static IEnumerable<DirectoryInfo> Ancestors(this DirectoryInfo directoryInfo, bool includeCurrent = false, bool includeDrive = false)
		{
			if (includeCurrent)
				yield return directoryInfo;

			DirectoryInfo di1 = directoryInfo.Parent;

			while (di1 != null)
			{
				if (di1.Parent != null)
				{
					yield return di1;
					di1 = di1.Parent;
				}
				else if (includeDrive) // if di1.Parent == null, di1 is drive letter
				{
					yield return di1;
					break;
				}
				else
				{
					break;
				}
			}
		}

		public static IEnumerable<DirectoryInfo> Descendants(this DirectoryInfo directoryInfo, bool includeCurrent = false)
		{
			if (includeCurrent)
				yield return directoryInfo;

			foreach(var di1 in directoryInfo.EnumerateDirectories()) // first level children
			{
				foreach(var di2 in di1.Descendants(true))
				{
					yield return di2;
				}
			}
		}
	}
}