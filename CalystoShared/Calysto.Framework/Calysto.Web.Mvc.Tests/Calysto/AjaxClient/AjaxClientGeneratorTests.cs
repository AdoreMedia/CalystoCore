using Calysto.Net.WebService.Generator;
using Calysto.UnitTesting;
using CalystoWebTests.Calysto.AjaxClient.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CalystoWebTests.Calysto.AjaxClient
{
	[TestClass]
	public class AjaxClientGeneratorTests
	{
		string _root = $"Calysto\\AjaxClient\\TestFiles\\";

		[TestMethod]
		public void TestMethod001()
		{
			CalystoAjaxClientGenerator generator = new CalystoAjaxClientGenerator();
			generator.ForType(typeof(AjaxService22));
			var res1 = generator.GenerateSingleFile();

			TestFilesProvider2 provider = new TestFilesProvider2(Path.Combine(_root, MethodInfo.GetCurrentMethod().Name + ".txt"));
			provider.Assert(Assert.AreEqual, res1);
		}

		[TestMethod]
		public void TestMethod002()
		{
			CalystoAjaxClientGenerator generator = new CalystoAjaxClientGenerator();
			generator.ForType(typeof(SocketSession22));
			var res1 = generator.GenerateSingleFile();

			TestFilesProvider2 provider = new TestFilesProvider2(Path.Combine(_root, MethodInfo.GetCurrentMethod().Name + ".txt"));
			provider.Assert(Assert.AreEqual, res1);
		}

		[TestMethod]
		public void TestMethod003()
		{
			CalystoAjaxClientGenerator generator = new CalystoAjaxClientGenerator();
			generator.ForAssemlyContainingType(typeof(AjaxService22));
			var res1 = generator.GenerateSingleFile();

			TestFilesProvider2 provider = new TestFilesProvider2(Path.Combine(_root, MethodInfo.GetCurrentMethod().Name + ".txt"));
			provider.Assert(Assert.AreEqual, res1);
		}

	}
}
