using Calysto.Globalization;
using Calysto.Utility;
using Calysto.Web.Script.Services.WebSockets;
using System.Collections.Generic;
using System.Globalization;
using Calysto.Linq;
using System.Web;
using Calysto.Web.EnvDTE;
using System.IO;
using System.Text;
using System;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Run this code from unittest to generate output. 
/// This is replacement for .tt template generator which is not fully supported in .NET Core
/// </summary>
namespace Calysto.Web.CalystoTextTemplating
{
	/// <summary>
	/// There is problem with embedded js files! 
	/// Since embedding starts before the TS compiler is finished, there is no JS files available for embedding.
	/// We have to let TS compiller to create output js in different location and than copy it to _dist directory.
	/// </summary>
	public class OutputCopier
	{
		// relative paths in .js.map can not be changed, so EngineComplete.ts must be in the same relative path from destination .js.map
		const string _sourceDir = EnvDTECalystoWeb.ProjectDir + @"WebLib\Engine\Build\Core\Output\";
		const string _destinationDir = EnvDTECalystoWeb.ProjectDir + @"WebLib\Engine\Build\Core\_dist\";

		public async Task CopyOutputAsync()
		{
			foreach(string srcfile in Directory.GetFiles(_sourceDir).Where(o=>o.EndsWith(".js") || o.EndsWith(".js.map")))
			{
				while (!File.Exists(srcfile))
				{
					Console.WriteLine("Waitig for: " + srcfile);
					await Task.Delay(500);
				}

				string newContent = File.ReadAllText(srcfile, Encoding.UTF8);
				string destFile = Path.Combine(_destinationDir, Path.GetFileName(srcfile));
				if(CalystoTools.WriteFileIfChanged(destFile, newContent))
				{
					Console.WriteLine("Replaced: " + destFile);
				}
				else
				{
					//Console.WriteLine("Same: " + destFile);
				}
			}
		}

	}
}

