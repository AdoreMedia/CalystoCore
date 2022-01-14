using Calysto.Net.WebService.Generator;
using Calysto.TypeLite;
using Calysto.UnitTesting;
using Calysto.Utility;
using Calysto.Web.Script.Services;
using System;
using System.IO;
using System.Linq;

/// <summary>
/// Run this code from unittest to generate output. 
/// This is replacement for .tt template generator which is not fully supported in .NET Core
/// </summary>
namespace Calysto.Web.WebSiteGenerators.Generators
{
	public class CSharpLiteGenerator
	{
		private static string GetDestinationDirectory()
		{
			string projectRoot = CalystoTools.FindProjectFileInfo().DirectoryName;
			string destDir = Path.Combine(projectRoot, "..", "..", "CalystoBlazorWasm\\Client\\ApiClients");
			
			return Path.Combine(destDir, "Generated");
		}

		public void GenerateCalystoLiteClient()
		{
			if (!Directory.Exists(GetDestinationDirectory()))
				Directory.CreateDirectory(GetDestinationDirectory());

			CalystoAjaxClientGenerator generator = new CalystoAjaxClientGenerator();
			generator.ForAssemlyContainingType(typeof(Calysto.Web.TestSite.Web.CalystoUI.Ajax.AjaxController));
			var results = generator.GenerateMultipleFiles();
			foreach (var res1 in results)
			{
				string path = Path.Combine(GetDestinationDirectory(), res1.TypeName + ".generated.cs");
				CalystoTools.WriteFileIfChanged(path, res1.UsingsAndCode);
			}
		}
	}
}
