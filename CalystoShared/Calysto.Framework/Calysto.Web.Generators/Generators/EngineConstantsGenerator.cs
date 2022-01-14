using Calysto.Globalization;
using Calysto.Utility;
using Calysto.Web.EnvDTE;
using Calysto.Web.UI;
using System.Collections.Generic;
using System.Globalization;

/// <summary>
/// Run this code from unittest to generate output. 
/// This is replacement for .tt template generator which is not fully supported in .NET Core
/// </summary>
namespace Calysto.Web.CalystoTextTemplating
{
	public class EngineConstantsGenerator
	{
		public void GenerateCalystoWebEngineConstants()
		{
			foreach (string cultureName in this.GetCultures())
			{
				string txt = this.Generate(cultureName);
				txt = global::Calysto.Serialization.Json.PrettyJSON.PrettyJSONFormat(txt);
				string destFile = $@"{EnvDTECalystoWeb.ProjectDir}WebLib\Engine\_dist\EngineConstants-{cultureName}.js";
				CalystoTools.WriteFileIfChanged(destFile, txt);
			}
		}

		private IEnumerable<string> GetCultures()
		{
			yield return "en-US";
			yield return "hr-HR";
			yield return "de-DE";
			yield return "sr-RS";
			yield return "sr-Latn-CS";
			yield return "sr-CS"; // cyrilic
		}

		class ScriptManagerSimple : CalystoScriptManagerBase<ScriptManagerSimple>
		{
		}

		private string Generate(string cultureName)
		{
			return CalystoCultureInfoHelper.UsingCulture(CultureInfo.GetCultureInfo(cultureName), () =>
			{
				return new ScriptManagerSimple().GetConstantsJavaScript();
			});
		}
	}

}

