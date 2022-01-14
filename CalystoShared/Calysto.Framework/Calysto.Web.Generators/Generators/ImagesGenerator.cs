using Calysto.Linq;
using Calysto.Utility;
using Calysto.Web.EnvDTE;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Calysto.Web.CalystoTextTemplating
{
	public class ImagesGenerator 
	{
		public void GenerateCalystoWebImages()
		{
			string outputClassFile = EnvDTECalystoWeb.ProjectDir + "WebLib\\Resources\\Images\\Images.cs";
			string outputTSFile = outputClassFile.Replace(".cs", ".ts");
			string outputEnumFile = EnvDTECalystoWeb.ProjectDir + "WebLib\\Resources\\Images\\ImagesEnum.cs";
			string rootDir = EnvDTECalystoWeb.ProjectDir + "WebLib\\";
			
			int length1 = rootDir.Length;
			string[] files1 = Directory.GetFiles(rootDir + "Images\\", "*", SearchOption.AllDirectories);

			List<string> classRows = new List<string>();
			List<string> enumRows = new List<string>();
			List<string> tsRows = new List<string>();

			foreach(string file in files1)
			{
				string path1 = file.Substring(length1);
				string propName = CreatePropertyName(path1);
				string url = CreateAppRelativeUrlPath(path1);

				classRows.Add($@"		public const string {propName} = ""{url}"";
");

				tsRows.Add($@"	export const {propName} = ""{url}"";
");

				enumRows.Add($@"		/// <summary>
		/// {url}
		/// </summary>
		[StringValue(""{url}"")]
		{propName},

");

			}

			string cls1 = GenerateClass(classRows.ToStringJoined());
			CalystoTools.WriteFileIfChanged(outputClassFile, cls1);

			// koristi se u TagHelperu
			string enum1 = GenerateEnum(enumRows.ToStringJoined());
			CalystoTools.WriteFileIfChanged(outputEnumFile, enum1);

			string tsFile = GenerateTSClass(tsRows.ToStringJoined());
			CalystoTools.WriteFileIfChanged(outputTSFile, tsFile);
		}

		private string CreateAppRelativeUrlPath(string path1)
		{
			return "~/" + path1.Replace("\\", "/");
		}

		static HashSet<char> _invalidChars = new HashSet<char>(Path.GetInvalidFileNameChars().Concat(Path.GetInvalidPathChars()).Distinct());

		private string CreatePropertyName(string path1)
		{
			
			string str1 = path1.Substring(7);
			string str2 = Path.GetDirectoryName(str1);
			string str3 = Path.GetFileNameWithoutExtension(str1);
			string str4 = Path.Combine(str2, str3);
			string str5 = str4.Replace("\\", "_").Replace("/", "_").Replace("-", "_");
			return str5;
		}

		private string GenerateClass(string content)
		{
			return $@"namespace Calysto.Resources
{{
	public static class Images
	{{
{content}
	}}
}}
";
		}

		private string GenerateTSClass(string content)
		{
			return $@"namespace Calysto.Resources.Images
{{
{content}
}}
";
		}

		private string GenerateEnum(string content)
		{
			return $@"using Calysto.Extensions;
namespace Calysto.Resources
{{
	public enum ImagesEnum
	{{
{content}
	}}
}}
;";
		}
	}
}

