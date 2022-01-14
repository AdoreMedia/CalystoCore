using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.Calysto.CCFServices.Contract;
using Calysto.UnitTesting;
using Calysto.Genesis.Tests.EnvDTE;
using System.IO;

namespace Calysto.CCFServices.Generator
{
	[TestClass()]
	public class ClientGeneratorTests
	{
		string _rootDir = @"Calysto\CCFServices\Generator\TestFiles\";

		[TestMethod()]
		public void GenerateCompleteClassTest1()
		{
			var generator = new ClientGenerator();
			string res1 = generator.GenerateClass<IRemoteController>("RemoteClient", "UnitTests.Calysto.CCFServices.Contract");

			TestFilesProvider2 provider1 = new TestFilesProvider2(Path.Combine(_rootDir, "GenerateCompleteClassTest1.cs-a"));
			provider1.Assert(Assert.AreEqual, res1);
		}

	}
}