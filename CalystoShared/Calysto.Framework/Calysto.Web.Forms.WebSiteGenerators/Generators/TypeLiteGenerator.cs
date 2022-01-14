using Calysto.TypeLite;
using Calysto.UnitTesting;
using Calysto.Utility;
using Calysto.Web.EnvDTE;
using Calysto.Web.Forms.WebSite.EnvDTE;
using System;
using System.IO;

/// <summary>
/// Run this code from unittest to generate output. 
/// This is replacement for .tt template generator which is not fully supported in .NET Core
/// </summary>
namespace Calysto.Web.Forms.WebSiteGenerators.Generators
{
	public class TypeLiteGenerator
	{
		static string _destinationDirectory = Path.Combine(CalystoTools.FindProjectFileInfo().DirectoryName, @"Web\_ts\");

		public void GenerateCalystoTestSiteTypeLite()
		{
			var ts = TypeLite.TypeScript.Definitions()
				.ForAssemblyWith<Calysto.Web.TestSite.Web.CalystoUI.Ajax.AjaxService>()
				.IgnoreNamespace("ArizonaDatabases.ArizonaApp.Database")
				.IgnoreNamespace("ArizonaDatabases.ArizonaSpider.Database");

			if (!Directory.Exists(_destinationDirectory))
				Directory.CreateDirectory(_destinationDirectory);

			// generate classes
			string classes = ts.Generate(TsGeneratorOutput.Properties | TsGeneratorOutput.AjaxMethods | TsGeneratorOutput.SocketMethods).Trim();
			CalystoTools.WriteFileIfChanged(_destinationDirectory + "Classes.d.ts", classes);

			// generate enums
			string enums = ts.Generate(TsGeneratorOutput.Enums | TsGeneratorOutput.Constants).Trim();
			CalystoTools.WriteFileIfChanged(_destinationDirectory + "Enums.ts", enums);

			// generate resx
			string resx = ts.Generate(TsGeneratorOutput.Resx).Trim();
			CalystoTools.WriteFileIfChanged(_destinationDirectory + "Resx.d.ts", resx);

		}
	}
}
