namespace LinqToSqlShared
{
    using System;
    using System.Globalization;
    using System.Resources;
    using System.Runtime.InteropServices;
    using System.Threading;

    internal sealed class SR
    {
		public static string GetString(string str)
		{
			return str;
		}

		public static string GetString(string str, params object[] args)
		{
			string format = str;
			if ((args == null) || (args.Length <= 0))
			{
				return format;
			}
			for (int i = 0; i < args.Length; i++)
			{
				string str2 = args[i] as string;
				if ((str2 != null) && (str2.Length > 0x400))
				{
					args[i] = str2.Substring(0, 0x3fd) + "...";
				}
			}
			return string.Format(CultureInfo.CurrentCulture, format, args);
		}
    }
}

