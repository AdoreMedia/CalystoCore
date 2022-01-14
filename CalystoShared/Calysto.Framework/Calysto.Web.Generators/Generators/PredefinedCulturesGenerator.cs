using Calysto.Utility;
using Calysto.Web.EnvDTE;
using Calysto.Web.Script.Services.Compiler;

/// <summary>
/// Run this code from unittest to generate output. 
/// This is replacement for .tt template generator which is not fully supported in .NET Core
/// </summary>
namespace Calysto.Web.CalystoTextTemplating
{
	public class PredefinedCulturesGenerator
	{
		const string _destinationFile = EnvDTECalystoWeb.ProjectDir + @"WebLib\Engine\Src\Core\Constants\PredefinedCultures.ts";

		public void GenerateCalystoWebPredefinedCultures()
		{
			string txt = this.Generate();
			CalystoTools.WriteFileIfChanged(_destinationFile, txt);
		}

		private string Generate()
		{
			var cultures = new CulturesGenerator().GetDefaultCultures();
			string json = Calysto.Serialization.Json.JsonSerializer.Serialize(cultures);
			string pretty = Calysto.Serialization.Json.PrettyJSON.PrettyJSONFormat(json, startingIndentLevel: 1);

			return GenerateWorker(pretty);
		}

		private string GenerateWorker(string pretty)
		{
			return $@"namespace Calysto.Constants
{{
	export const PredefinedCultures = {pretty};
}}
";
		}
	}
}

