using Calysto.Globalization;
using Calysto.Utility;
using Calysto.Web.Script.Services.WebSockets;
using System.Collections.Generic;
using System.Globalization;
using Calysto.Linq;
using System.Web;
using Calysto.Web.EnvDTE;

/// <summary>
/// Run this code from unittest to generate output. 
/// This is replacement for .tt template generator which is not fully supported in .NET Core
/// </summary>
namespace Calysto.Web.CalystoTextTemplating
{
	public class AppConstantsGenerator
	{
		const string _destinationFile = EnvDTECalystoWeb.ProjectDir + @"WebLib\Engine\Src\Core\Constants\AppConstants.ts";

		public void GenerateCalystoWebAppConstants()
		{
			string txt = this.Generate();
			CalystoTools.WriteFileIfChanged(_destinationFile, txt);
		}

		private string Generate()
		{
			Dictionary<string, string> dic = new Dictionary<string, string>()
			{
				{nameof(CalystoConstants.EmailRegexPattern), CalystoConstants.EmailRegexPattern },
				{nameof(CalystoConstants.BroadcastMethodName), CalystoConstants.BroadcastMethodName},
				{nameof(CalystoConstants.EchoServerRequest), CalystoConstants.EchoServerRequest},
				{nameof(CalystoConstants.EchoServerResponse), CalystoConstants.EchoServerResponse},
				{nameof(CalystoConstants.EchoClientRequest), CalystoConstants.EchoClientRequest},
				{nameof(CalystoConstants.EchoClientResponse), CalystoConstants.EchoClientResponse},

			};

			string result1 = CalystoCultureInfoHelper.UsingCulture(CultureInfo.InvariantCulture, () =>
			{
				return this.GenerateWorker(dic);
			});

			return result1;
		}

		private string GenerateWorker(Dictionary<string, string> dic)
		{
			return $@"namespace Calysto.Constants.AppConstants
{{{this.GenerateProperties(dic).ToStringJoined()}
}}
";
		}

		private IEnumerable<string> GenerateProperties(Dictionary<string, string> dic)
		{
			foreach(var kv in dic)
			{
				yield return @$"
	export const {kv.Key} = `{HttpUtility.JavaScriptStringEncode(kv.Value)}`;
";
			}
		}

	}
}

