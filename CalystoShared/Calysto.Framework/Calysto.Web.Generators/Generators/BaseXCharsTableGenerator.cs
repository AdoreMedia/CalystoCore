using Calysto.Converter;
using Calysto.Globalization;
using Calysto.Linq;
using Calysto.Utility;
using Calysto.Web.EnvDTE;
using System.Collections.Generic;
using System.Globalization;

/// <summary>
/// Run this code from unittest to generate output. 
/// This is replacement for .tt template generator which is not fully supported in .NET Core
/// </summary>
namespace Calysto.Web.CalystoTextTemplating
{
	public class BaseXCharsTableGenerator
	{
		const string _destinationFile = EnvDTECalystoWeb.ProjectDir + @"WebLib\Engine\Src\Core\Constants\BaseXCharsTable.ts";

		public void GenerateCalystoWebBaseXCharsTable()
		{
			string txt = this.Generate();
			CalystoTools.WriteFileIfChanged(_destinationFile, txt);
		}

		private string Generate()
		{
			Dictionary<string, string> dic = new Dictionary<string, string>()
			{
				{nameof(BaseXCharsTable.JavaScriptRFCTable64), BaseXCharsTable.JavaScriptRFCTable64},
				{nameof(BaseXCharsTable.StandardBase64RFC), BaseXCharsTable.StandardBase64RFC},
				{nameof(BaseXCharsTable.Table36JavaScriptRFC), BaseXCharsTable.Table36JavaScriptRFC},
			};

			string result1 = CalystoCultureInfoHelper.UsingCulture(CultureInfo.InvariantCulture, () =>
			{
				return this.GenerateWorker(dic);
			});

			return result1;
		}

		private string GenerateWorker(Dictionary<string, string> dic)
		{
			return $@"namespace Calysto.Constants.BaseXCharsTable
{{{this.GenerateProperties(dic).ToStringJoined()}
}}
";
		}

		private IEnumerable<string> GenerateProperties(Dictionary<string, string> dic)
		{
			foreach (var kv in dic)
			{
				yield return @$"
	export const {kv.Key} = `{kv.Value}`;
";
			}
		}

	}
}

