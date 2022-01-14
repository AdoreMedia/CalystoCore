using Calysto.SqlMetal.Model;
using Calysto.UnitTesting;
using LinqToSqlShared.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlMetal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SqlMetal.Tests.GeneratorTests
{
	[TestClass()]
	public class CalystoLinq2SqlTests
	{
		private const string _root1 = "GeneratorTests\\CalystoLinq2SqlTests\\TestFiles";

		/// <summary>
		/// generate C# model from database
		/// </summary>
		[TestMethod()]
		public void CalystoDbmlLinq2SqlTest01()
		{
			TestFilesProvider2 provider = new TestFilesProvider2(Path.Combine(_root1, "CalystoDbmlLinq2SqlTest01.cs-a"));

			string path1 = provider.CreateAbsolutePath("Input\\CalystoDbmlLinq2SqlTest01.calystoef");
			DatabaseSettings settings = DatabaseSettings.Load(path1);
			settings.OutputType = OutputType.CalystoLinq2SqlCSharp;
			settings.ConnectionString = DatabaseConnectionsSettings.SqlCalystoUnittestConnectionString;

			SqlMetalMain main = new SqlMetalMain();
			DatabaseResult result = main.Process(settings);

			provider.Assert(Assert.AreEqual, result.OutputContent);
		}

		/// <summary>
		/// generate C# model from database
		/// </summary>
		[TestMethod()]
		public void CalystoDbmlLinq2SqlTest02()
		{
			ExtractorOptions settings = new ExtractorOptions();
			settings.Namespace = "CalystoUnittestNamespace";
			settings.ContextClass = "dbCalystoUnittestDataContext";
			settings.ConnectionString = DatabaseConnectionsSettings.SqlCalystoUnittestConnectionString;
			settings.OutputType = OutputType.CalystoLinq2SqlCSharp;
			SqlMetalMain main = new SqlMetalMain();
			DatabaseResult result = main.Process(settings);

			TestFilesProvider2 provider = new TestFilesProvider2(Path.Combine(_root1, "CalystoDbmlLinq2SqlTest02.cs-a"));
			provider.Assert(Assert.AreEqual, result.OutputContent);
		}

	}
}