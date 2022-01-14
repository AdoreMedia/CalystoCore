using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SqlMetal.Tests
{
	static class DatabaseConnectionsSettings
	{
		public static string SqlCalystoUnittestConnectionString => $@"Data Source=.\MSSQL2019;Initial Catalog=dbCalystoUnittest;Integrated Security=True;Connect Timeout=30;";

		public static string SqlAdventureWorksConnectionString => $@"Data Source=.\MSSQL2019;Initial Catalog=dbAdventureWorks;Integrated Security=True;Connect Timeout=30;";

		public static string SqLiteConnectionString => $@"Data Source={Path.Combine(EnvDTE.EnvDTESqlMetalTests.ProjectDir)}Database\dbCalystoUnittest.db";

		public static string MySqlConnectionString => $@"Server=localhost;Database=dbCalystoUnittest;User=root;Password=root;";

		public static string DbmlFilePath => $@"{Path.Combine(EnvDTE.EnvDTESqlMetalTests.ProjectDir)}Database\dbCalystoUnittest.dbml-a";
	}
}
