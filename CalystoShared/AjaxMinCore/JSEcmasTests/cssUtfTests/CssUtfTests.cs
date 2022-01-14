using CalystoMinTests.EnvDTE;
using Microsoft.Ajax.Utilities;
using Microsoft.Ajax.Utilities.Css2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;

namespace JSEcmasTests.cssUtfTests
{
	[TestClass]
	public class CssUtfTests
	{
		[TestMethod]
		public void TestMethod11()
		{
			string inputJs = File.ReadAllText(EnvDteCalystoMinTests.ProjectDir + "cssUtfTests\\TestFiles\\TestMethod11\\Input.css");
			string expectedJs = File.ReadAllText(EnvDteCalystoMinTests.ProjectDir + "cssUtfTests\\TestFiles\\TestMethod11\\Expected.css");
			string outputFile = (EnvDteCalystoMinTests.ProjectDir + "cssUtfTests\\TestFiles\\TestMethod11\\Output.css");

			Minifier minifier = new Minifier();
			string min1 = minifier.MinifyCSS(inputJs, MinifyModeEnum.Minify);
			File.WriteAllText(outputFile, min1);

			Assert.AreEqual(expectedJs, min1);
		}

		[TestMethod]
		public void TestMethod12()
		{
			string inputJs = File.ReadAllText(EnvDteCalystoMinTests.ProjectDir + "cssUtfTests\\TestFiles\\TestMethod12\\Input.css");
			string expectedJs = File.ReadAllText(EnvDteCalystoMinTests.ProjectDir + "cssUtfTests\\TestFiles\\TestMethod12\\Expected.css");
			string outputFile = (EnvDteCalystoMinTests.ProjectDir + "cssUtfTests\\TestFiles\\TestMethod12\\Output.css");

			Minifier minifier = new Minifier();
			string min1 = minifier.MinifyCSS(inputJs, MinifyModeEnum.Minify);
			File.WriteAllText(outputFile, min1);

			Assert.AreEqual(expectedJs, min1);
		}

		[TestMethod]
		public void TestMethod13()
		{
			string inputJs = File.ReadAllText(EnvDteCalystoMinTests.ProjectDir + "cssUtfTests\\TestFiles\\TestMethod13\\Input.css", Encoding.UTF8);
			string expectedJs = File.ReadAllText(EnvDteCalystoMinTests.ProjectDir + "cssUtfTests\\TestFiles\\TestMethod13\\Expected.css");
			string outputFile = (EnvDteCalystoMinTests.ProjectDir + "cssUtfTests\\TestFiles\\TestMethod13\\Output.css");

			Minifier minifier = new Minifier();
			string min1 = minifier.MinifyCSS(inputJs, MinifyModeEnum.Minify);
			File.WriteAllText(outputFile, min1, Encoding.UTF8);

			Assert.AreEqual(expectedJs, min1);
		}

		[TestMethod]
		public void TestMethod14()
		{
			string inputJs = File.ReadAllText(EnvDteCalystoMinTests.ProjectDir + "cssUtfTests\\TestFiles\\TestMethod14\\Input.css", Encoding.UTF8);
			string expectedJs = File.ReadAllText(EnvDteCalystoMinTests.ProjectDir + "cssUtfTests\\TestFiles\\TestMethod14\\Expected.css");
			string outputFile = (EnvDteCalystoMinTests.ProjectDir + "cssUtfTests\\TestFiles\\TestMethod14\\Output.css");

			Minifier minifier = new Minifier();
			string min1 = minifier.MinifyCSS(inputJs, MinifyModeEnum.Minify);
			File.WriteAllText(outputFile, min1, Encoding.UTF8);

			Assert.AreEqual(expectedJs, min1);
		}

	}
}
