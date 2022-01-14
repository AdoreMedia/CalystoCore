using Calysto.SqlMetal.Model;
using Calysto.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

namespace SqlMetal.Tests.GeneratorTests
{
	[TestClass()]
	public class AdventureWorksEFCoreTests
	{
		/// <summary>
		/// Create C# model from database with custom return types.
		/// </summary>
		[TestMethod()]
		public void Test01()
		{
			TestFilesProvider2 provider = new TestFilesProvider2("GeneratorTests\\AdventureWorksEFCoreTests\\TestFiles\\Actual\\AdventureWorksEFCoreTest01.cs-a");

			string path1 = provider.CreateAbsolutePath("Input\\AdventureWorksEFCoreTest01.calystoef");
			DatabaseSettings settings = DatabaseSettings.Load(path1);
			settings.OutputType = OutputType.CalystoEFCoreFluent;
			settings.ConnectionString = DatabaseConnectionsSettings.SqlAdventureWorksConnectionString;

			SqlMetalMain main = new SqlMetalMain();	
			DatabaseResult result = main.Process(settings);

			provider.Assert(Assert.AreEqual, result.OutputContent);
		}
	}
}