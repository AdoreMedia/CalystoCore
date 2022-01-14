using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calysto.Genesis.UnitTest.Calysto.TypeLite.Model;
using Calysto.Genesis.Web.UnitTests.Calysto.TypeLite.Model;
using CalystoWebTests.Calysto.TypeLite.Validators;
using CalystoWebTests.Calysto.TypeLite.Model;
using Calysto.UnitTesting;
using Calysto.Web.Tests.EnvDTE;
using System.IO;
using System.Reflection;

namespace Calysto.TypeLite.Tests
{
	[TestClass()]
	public class TypeScriptTests
	{
		string _root = $"Calysto\\TypeLite\\TestFiles\\";

		[TestMethod()]
		public void DefinitionsTest1()
		{
			var tt1 = TypeScript.Definitions()
				.For(typeof(WebServiceClassExample));

			string res1 = tt1.Generate(TsGeneratorOutput.Properties | TsGeneratorOutput.Enums | TsGeneratorOutput.AjaxMethods);
			TestFilesProvider2 provider = new Calysto.UnitTesting.TestFilesProvider2(Path.Combine(_root, MethodInfo.GetCurrentMethod().Name + ".txt"));
			provider.Assert(Assert.AreEqual, res1);
		}

		[TestMethod()]
		public void DefinitionsTest2()
		{
			string res1 = Calysto.Globalization.CalystoCultureInfoHelper.UsingUSCulture(() =>
			{
				var tt1 = TypeScript.Definitions()
					.ForResx<Validators>();

				return tt1.Generate(TsGeneratorOutput.Resx);
			});

			TestFilesProvider2 provider = new Calysto.UnitTesting.TestFilesProvider2(Path.Combine(_root, MethodInfo.GetCurrentMethod().Name + ".txt"));
			provider.Assert(Assert.AreEqual, res1);

		}

		[TestMethod()]
		public void DefinitionsTest3()
		{
			var tt1 = TypeScript.Definitions()
				.For<AdminUrlExample>();

			//var res1 = tt1.GenerateAll();
			var res1 = tt1.Generate();
			TestFilesProvider2 provider = new Calysto.UnitTesting.TestFilesProvider2(Path.Combine(_root, MethodInfo.GetCurrentMethod().Name + ".txt"));
			provider.Assert(Assert.AreEqual, res1);

		}

		[TestMethod()]
		public void DefinitionsTest4()
		{
			var tt1 = TypeScript.Definitions()
				.For(typeof(WebServiceClassExample));

			string res1 = tt1.Generate(TsGeneratorOutput.Enums | TsGeneratorOutput.Fields | TsGeneratorOutput.Properties | TsGeneratorOutput.AjaxMethods | TsGeneratorOutput.SocketMethods | TsGeneratorOutput.WebViewHostMethods);

			TestFilesProvider2 provider = new Calysto.UnitTesting.TestFilesProvider2(Path.Combine(_root, MethodInfo.GetCurrentMethod().Name + ".txt"));
			provider.Assert(Assert.AreEqual, res1);

		}

		[TestMethod()]
		public void DefinitionsTest5()
		{
			var tt1 = TypeScript.Definitions()
				.For(typeof(CalystoWebSocketHandler));

			string res1 = tt1.Generate(TsGeneratorOutput.Enums | TsGeneratorOutput.Fields | TsGeneratorOutput.Properties | TsGeneratorOutput.SocketMethods);

			TestFilesProvider2 provider = new Calysto.UnitTesting.TestFilesProvider2(Path.Combine(_root, MethodInfo.GetCurrentMethod().Name + ".txt"));
			provider.Assert(Assert.AreEqual, res1);

		}


		[TestMethod()]
		public void DefinitionsTest7()
		{
			var tt1 = TypeScript.Definitions()
				.For(typeof(CustomCollection<>));

			string res1 = tt1.Generate();

			TestFilesProvider2 provider = new Calysto.UnitTesting.TestFilesProvider2(Path.Combine(_root, MethodInfo.GetCurrentMethod().Name + ".txt"));
			provider.Assert(Assert.AreEqual, res1);
		}

		[TestMethod()]
		public void DefinitionsTest8()
		{
			var tt1 = TypeScript.Definitions()
				.For(typeof(ServiceOne));

			string res1 = tt1.Generate(TsGeneratorOutput.Properties | TsGeneratorOutput.AjaxMethods);

			TestFilesProvider2 provider = new Calysto.UnitTesting.TestFilesProvider2(Path.Combine(_root, MethodInfo.GetCurrentMethod().Name + ".txt"));
			provider.Assert(Assert.AreEqual, res1);

		}

		[TestMethod()]
		public void DefinitionsTest9()
		{
			var tt1 = TypeScript.Definitions()
				.For(typeof(HostObject3));

			string res1 = tt1.Generate(TsGeneratorOutput.Enums | TsGeneratorOutput.Fields | TsGeneratorOutput.Properties | TsGeneratorOutput.WebViewHostMethods);

			TestFilesProvider2 provider = new Calysto.UnitTesting.TestFilesProvider2(Path.Combine(_root, MethodInfo.GetCurrentMethod().Name + ".txt"));
			provider.Assert(Assert.AreEqual, res1);

		}

		[TestMethod()]
		public void DefinitionsTest10()
		{
			var tt1 = TypeScript.Definitions()
				.For(typeof(HostObject3));

			string res1 = tt1.Generate(TsGeneratorOutput.Enums | TsGeneratorOutput.Fields | TsGeneratorOutput.Properties | TsGeneratorOutput.WebViewHostMethods | TsGeneratorOutput.Implementation);

			TestFilesProvider2 provider = new Calysto.UnitTesting.TestFilesProvider2(Path.Combine(_root, MethodInfo.GetCurrentMethod().Name + ".txt"));
			provider.Assert(Assert.AreEqual, res1);

		}

		[TestMethod()]
		public void DefinitionsTest11()
		{
			var tt1 = TypeScript.Definitions()
				.For(typeof(MyAsyncFunctions));

			string res1 = tt1.Generate(TsGeneratorOutput.Enums | TsGeneratorOutput.Fields | TsGeneratorOutput.Properties | TsGeneratorOutput.AjaxMethods | TsGeneratorOutput.SocketMethods | TsGeneratorOutput.WebViewHostMethods);

			TestFilesProvider2 provider = new Calysto.UnitTesting.TestFilesProvider2(Path.Combine(_root, MethodInfo.GetCurrentMethod().Name + ".txt"));
			provider.Assert(Assert.AreEqual, res1);

		}

		[TestMethod()]
		public void DefinitionsTest12()
		{
			var tt1 = TypeScript.Definitions()
				.For(typeof(MyAsyncFunctions2));

			string res1 = tt1.Generate(TsGeneratorOutput.Enums | TsGeneratorOutput.Fields | TsGeneratorOutput.Properties | TsGeneratorOutput.AjaxMethods | TsGeneratorOutput.SocketMethods | TsGeneratorOutput.WebViewHostMethods);

			TestFilesProvider2 provider = new Calysto.UnitTesting.TestFilesProvider2(Path.Combine(_root, MethodInfo.GetCurrentMethod().Name + ".txt"));
			provider.Assert(Assert.AreEqual, res1);

		}
	}
}