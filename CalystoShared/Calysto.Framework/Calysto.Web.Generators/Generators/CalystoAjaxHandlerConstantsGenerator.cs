using Calysto.Globalization;
using Calysto.Linq;
using Calysto.Utility;
using Calysto.Web.EnvDTE;
using Calysto.Web.Script.Services;
using System.Globalization;
using System.Linq;
using System.Reflection;

/// <summary>
/// Run this code from unittest to generate output. 
/// This is replacement for .tt template generator which is not fully supported in .NET Core
/// </summary>
namespace Calysto.Web.CalystoTextTemplating
{
	public class CalystoAjaxHandlerConstantsGenerator
	{
		const string _destinationFile = EnvDTECalystoWeb.ProjectDir + @"WebLib\Engine\Src\Core\Constants\CalystoAjaxHandlerConstants.ts";

		public void GenerateCalystoWebAjaxHandlerConstants()
		{
			string txt = this.Generate();
			CalystoTools.WriteFileIfChanged(_destinationFile, txt);
		}

		private string Generate()
		{
			var props = typeof(CalystoAjaxHandlerConstants).GetFields();

			string result1 = CalystoCultureInfoHelper.UsingCulture(CultureInfo.InvariantCulture, () =>
			{
				return this.GenerateWorker(props);
			});

			return result1;
		}

		private string GenerateWorker(FieldInfo[] props)
		{
			return $@"namespace Calysto.Constants.CalystoAjaxHandlerConstants
{{{this.GenerateProperties(props)}
}}
";
		}

		private string GenerateProperties(FieldInfo[] props)
		{
			return props.Select(pp => $@"
	export const {pp.Name} = `{pp.GetValue(null)}`;
").ToStringJoined();
		}

	}
}

