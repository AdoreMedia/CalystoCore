using Calysto.SqlMetal.Model;
using Calysto.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

namespace SqlMetal.Tests.GeneratorTests
{
	[TestClass()]
	public class CalystoEFCoreTests
	{
		const string _root1 = "GeneratorTests\\CalystoEFCoreTests\\TestFiles";

		/// <summary>
		/// Create C# model from database with custom return types.
		/// </summary>
		[TestMethod()]
		public void CalystoDbmlEFCoreTest01()
		{
			TestFilesProvider2 provider = new TestFilesProvider2(Path.Combine(_root1, "CalystoDbmlEFCoreTest01.cs-a"));

			string path1 = provider.CreateAbsolutePath("Input\\CalystoDbmlEFCoreTest01.calystoef");
			DatabaseSettings settings = DatabaseSettings.Load(path1);
			settings.OutputType = OutputType.CalystoEFCoreFluent;
			settings.ConnectionString = DatabaseConnectionsSettings.SqlCalystoUnittestConnectionString;

			SqlMetalMain main = new SqlMetalMain();
			DatabaseResult result = main.Process(settings);

			provider.Assert(Assert.AreEqual, result.OutputContent);
		}

		/// <summary>
		/// Create C# model from database with Many-to-Many relations.
		/// </summary>
		[TestMethod()]
		public void CalystoDbmlEFCoreTest012()
		{
			TestFilesProvider2 provider = new TestFilesProvider2(Path.Combine(_root1, "CalystoDbmlEFCoreTest012.cs-a"));

			string path1 = provider.CreateAbsolutePath("Input\\CalystoDbmlEFCoreTest012.calystoef");
			DatabaseSettings settings = DatabaseSettings.Load(path1);
			settings.OutputType = OutputType.CalystoEFCoreFluent;
			settings.ConnectionString = DatabaseConnectionsSettings.SqlCalystoUnittestConnectionString;

			SqlMetalMain main = new SqlMetalMain();
			DatabaseResult result = main.Process(settings);

			provider.Assert(Assert.AreEqual, result.OutputContent);
		}

		/// <summary>
		/// Create C# model from database with custom return types.
		/// </summary>
		[TestMethod()]
		public void CalystoDbmlEFCoreTest02()
		{
			TestFilesProvider2 provider = new TestFilesProvider2(Path.Combine(_root1, "CalystoDbmlEFCoreTest02.cs-a"));

			string path1 = provider.CreateAbsolutePath("Input\\CalystoDbmlEFCoreTest02.calystoef");
			DatabaseSettings settings = DatabaseSettings.Load(path1);
			settings.OutputType = OutputType.CalystoEFCoreFluent;
			settings.ConnectionString = DatabaseConnectionsSettings.SqlCalystoUnittestConnectionString;

			SqlMetalMain main = new SqlMetalMain();
			DatabaseResult result = main.Process(settings);

			provider.Assert(Assert.AreEqual, result.OutputContent);
		}

		/// <summary>
		/// Create C# model from database
		/// </summary>
		[TestMethod()]
		public void CalystoDbmlEFCoreTest03()
		{
			TestFilesProvider2 provider = new TestFilesProvider2(Path.Combine(_root1, "CalystoDbmlEFCoreTest03.cs-a"));

			string path1 = provider.CreateAbsolutePath("Input\\CalystoDbmlEFCoreTest03.calystoef");
			DatabaseSettings settings = DatabaseSettings.Load(path1);
			settings.OutputType = OutputType.CalystoEFCoreFluent;
			settings.ConnectionString = DatabaseConnectionsSettings.SqlCalystoUnittestConnectionString;

			SqlMetalMain main = new SqlMetalMain();
			DatabaseResult result = main.Process(settings);

			provider.Assert(Assert.AreEqual, result.OutputContent);
		}

		/// <summary>
		/// Create C# model from database.
		/// All objects, all schemas.
		/// </summary>
		[TestMethod()]
		public void CalystoDbmlEFCoreTest04()
		{
			TestFilesProvider2 provider = new TestFilesProvider2(Path.Combine(_root1, "CalystoDbmlEFCoreTest04.cs-a"));

			string path1 = provider.CreateAbsolutePath("Input\\CalystoDbmlEFCoreTest04.calystoef");
			DatabaseSettings settings = DatabaseSettings.Load(path1);
			settings.OutputType = OutputType.CalystoEFCoreFluent;
			settings.ConnectionString = DatabaseConnectionsSettings.SqlCalystoUnittestConnectionString;

			SqlMetalMain main = new SqlMetalMain();
			DatabaseResult result = main.Process(settings);

			provider.Assert(Assert.AreEqual, result.OutputContent);
		}

		/// <summary>
		/// Create C# model from database.
		/// Procedure has to be executed inside transaction to get the result schema.
		/// </summary>
		[TestMethod()]
		public void CalystoDbmlEFCoreTest05()
		{
			ExtractorOptions settings = new ExtractorOptions();
			settings.SelectionDic = new System.Collections.Generic.Dictionary<string, DatabaseItemSetting>();
			settings.SelectionDic.Add("dbo.tblAppMember", new DatabaseItemSetting()
			{
				Checked= true,
				FullName = "dbo.tblAppMember"
			});
			settings.SelectionDic.Add("dbo.spGetAppMembers2", new DatabaseItemSetting()
			{
				Checked = true,
				FullName = "dbo.spGetAppMembers2",
				Execute =true
			});

			settings.Namespace = "CalystoUnittestNamespace2";
			settings.ContextClass = "dbCalystoUnittestDataContext2";
			settings.ConnectionString = DatabaseConnectionsSettings.SqlCalystoUnittestConnectionString;
			settings.OutputType = OutputType.CalystoEFCoreFluent;
			SqlMetalMain main = new SqlMetalMain();
			DatabaseResult result = main.Process(settings);

			TestFilesProvider2 provider = new TestFilesProvider2(Path.Combine(_root1, "CalystoDbmlEFCoreTest05.cs-a"));
			provider.Assert(Assert.AreEqual, result.OutputContent);
		}

		/// <summary>
		/// Create C# model from database using EFCoreEntityBase
		/// </summary>
		[TestMethod()]
		public void CalystoDbmlEFCoreTest06()
		{
			ExtractorOptions settings = new ExtractorOptions();
			settings.Namespace = "CalystoUnittestNamespace3";
			settings.ContextClass = "dbCalystoUnittestDataContext3";
			settings.ConnectionString = DatabaseConnectionsSettings.SqlCalystoUnittestConnectionString;
			settings.OutputType = OutputType.CalystoEFCoreFluent;
			SqlMetalMain main = new SqlMetalMain();
			DatabaseResult result = main.Process(settings);

			TestFilesProvider2 provider = new TestFilesProvider2(Path.Combine(_root1, "CalystoDbmlEFCoreTest06.cs-a"));
			provider.Assert(Assert.AreEqual, result.OutputContent);
		}

		/// <summary>
		/// Create C# model from database using EFCoreEntityBase for MySql
		/// </summary>
		[TestMethod()]
		public void CalystoDbmlEFCoreTest07()
		{
			ExtractorOptions settings = new ExtractorOptions();
			settings.Namespace = "CalystoUnittestNamespace4";
			settings.ContextClass = "dbCalystoUnittestDataContext4";
			settings.ConnectionString = DatabaseConnectionsSettings.SqlCalystoUnittestConnectionString;
			settings.OutputType = OutputType.CalystoEFCoreFluent;
			settings.TargetMode = DbProvider.MySql; // <<< MySQL
			SqlMetalMain main = new SqlMetalMain();
			DatabaseResult result = main.Process(settings);

			TestFilesProvider2 provider = new TestFilesProvider2(Path.Combine(_root1, "CalystoDbmlEFCoreTest07.cs-a"));
			provider.Assert(Assert.AreEqual, result.OutputContent);
		}

		[TestMethod()]
		public void CalystoDbmlEFCoreTest3CopyFile()
		{
			// copy content to new file to be used for real database reading
			TestFilesProvider2 provider = new TestFilesProvider2(Path.Combine(_root1, "CalystoDbmlEFCoreTest03.cs-a"));
			string src1 = provider.Actual.FullPath;
			string dest1 = Path.Combine(ReadDatabaseTests.MSSqlEFModelTests1.RootPath, "CalystoDbmlEFCoreTest3.cs");
			File.Copy(src1, dest1, true);
		}

		#if MySQL
		[TestMethod()]
		public void CalystoDbmlEFCoreTest4CopyFile()
		{
			// copy content to new file to be used for real database reading
			TestFilesProvider2 provider = new TestFilesProvider2(Path.Combine(_root1, "CalystoDbmlEFCoreTest4.cs-a"));
			string src1 = provider.Actual.FullPath;
			string dest1 = Path.Combine(ReadDatabaseTests.MySqlEFModelTests1.RootPath, "CalystoDbmlEFCoreTest4.cs");
			File.Copy(src1, dest1, true);
		}
		#endif

	}
}