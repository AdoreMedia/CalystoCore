//using Calysto.Common;
//using Calysto.Genesis.EnvDTE;
//using Calysto.Globalization;
//using Calysto.Web.EnvDTE;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.IO;
//using System.Text;

///// <summary>
///// Run this code from unittest to generate output. 
///// This is replacement for .tt template generator which is not fully supported in .NET Core
///// </summary>
//namespace Calysto.Web.CalystoTextTemplating
//{
//	[TestCategory(nameof(ICalystoTextTemplating))]
//	[TestClass()]
//	public class CalystoLangGenerator
//	{
//		const string _sourceFile = EnvDTECalystoGenesis.ProjectDir + @"Calysto\Resources\CalystoLang\CalystoLang.xlsx";
//		// will save ts file only
//		const string _destinationFile = EnvDTECalystoWeb.ProjectDir + @"WebLib\Resources\CalystoLang\CalystoLang.generated.ts";

//		[TestMethod]
//		public void GenerateCalystoWebLang()
//		{
//			var result = new ResxExcelGenerator(File.ReadAllBytes(_sourceFile), "Calysto.Resources", "CalystoLang").Generate();

//			//File.WriteAllText(_destinationFile, result.CSharp, Encoding.UTF8);
//			File.WriteAllText(_destinationFile.Replace(".cs", ".ts"), result.TypeScript, Encoding.UTF8);

//			Assert.IsTrue(result.TypeScript.Length > 10);
//		}
//	}
//}
