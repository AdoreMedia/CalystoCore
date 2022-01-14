using Calysto.Genesis.Tests.EnvDTE;
using Calysto.UnitTesting;
using Calysto.Utility;
using System.IO;

namespace Calysto.Genesis.Tests.Database
{
	class DatabaseConstants
	{
		public const string MSSqlConnectionString = @"Data Source=.\MSSQL2019;Initial Catalog=dbCalystoUnittest;Integrated Security=True;Connect Timeout=30;";

		private static string GetDbPath()
		{
			return Path.Combine(CalystoTools.FindProjectFileInfo().DirectoryName, "Database\\SQLite\\dbCalystoUnittest.db");
		}

		public static string SQLiteConnectionString => $"Data source={GetDbPath()}";
	}
}
