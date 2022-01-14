using Calysto.UnitTesting;
using CalystoMinTests.EnvDTE;
using Microsoft.Ajax.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;
using System.Reflection;

namespace JSEcmasTests.es5Tests
{
	[TestClass]
	public class JSes5Tests
	{
		string _root = "es5Tests\\TestFiles\\";

		[TestMethod]
		public void TestMethod11()
		{
			TestFilesProvider2 provider = new Calysto.UnitTesting.TestFilesProvider2(Path.Join(_root, MethodInfo.GetCurrentMethod().Name + ".js"));
			string inputJs = provider.Input.Read().Text;
			string expectedJs = provider.Expected.Read().Text;
			string outputFile = provider.Actual.FullPath;

			Minifier minifier = new Minifier();
			CodeSettings sett = new CodeSettings();
			sett.LocalRenaming = LocalRenaming.KeepAll;
			string min1 = minifier.MinifyJavaScript(inputJs, sett);
			File.WriteAllText(outputFile, min1);

			if (minifier.ErrorList.Any()) Assert.Fail(minifier.ErrorList.First() + "");
			if (minifier.Errors.Any()) Assert.Fail(minifier.Errors.First() + "");
			Assert.AreEqual(expectedJs, min1);
		}

		/// <summary>
		/// complete Calysto engine, es5, minify, keep local variables names
		/// </summary>
		[TestMethod]
		public void TestMethod22()
		{
			TestFilesProvider2 provider = new Calysto.UnitTesting.TestFilesProvider2(Path.Join(_root, MethodInfo.GetCurrentMethod().Name + ".js"));
			string inputJs = provider.Input.Read().Text;
			string expectedJs = provider.Expected.Read().Text;
			string outputFile = provider.Actual.FullPath;

			Minifier minifier = new Minifier();
			CodeSettings sett = new CodeSettings();
			sett.LocalRenaming = LocalRenaming.KeepAll; // <<<<< KeepAll
			string min1 = minifier.MinifyJavaScript(inputJs, sett);
			File.WriteAllText(outputFile, min1);

			if (minifier.ErrorList.Any()) Assert.Fail(minifier.ErrorList.First() + "");
			if (minifier.Errors.Any()) Assert.Fail(minifier.Errors.First() + "");
			Assert.AreEqual(expectedJs, min1);
		}

		/// <summary>
		/// complete Calysto engine, es5, minify, crunch local variables names
		/// </summary>
		[TestMethod]
		public void TestMethod23()
		{
			TestFilesProvider2 provider = new Calysto.UnitTesting.TestFilesProvider2(Path.Join(_root, MethodInfo.GetCurrentMethod().Name + ".js"));
			string inputJs = provider.Input.Read().Text;
			string expectedJs = provider.Expected.Read().Text;
			string outputFile = provider.Actual.FullPath;

			Minifier minifier = new Minifier();
			CodeSettings sett = new CodeSettings();
			sett.LocalRenaming = LocalRenaming.CrunchAll; // <<<< CrunchAll
			string min1 = minifier.MinifyJavaScript(inputJs, sett);
			File.WriteAllText(outputFile, min1);

			if (minifier.ErrorList.Any()) Assert.Fail(minifier.ErrorList.First() + "");
			if (minifier.Errors.Any()) Assert.Fail(minifier.Errors.First() + "");
			Assert.AreEqual(expectedJs, min1);
		}
	}
}
