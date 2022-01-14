//using Calysto.Common;
//using Calysto.Linq;
//using Calysto.Web.EnvDTE;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;

//namespace Calysto.Web.CalystoTextTemplating
//{
//	public class CSSFilesListGenerator
//	{
//		readonly string _destinationFile = EnvDTECalystoWeb.ProjectDir + "_generated\\CSSFilesList.cs";
//		string _projectRoot = EnvDTECalystoWeb.ProjectDir;
//		string _mapDirectory = "WebLib";

//		public void GenerateCalystoWebCSSFilesList()
//		{
//			// search for all views in all referenced files
//			// than generate ts controller and generate classes for C# and TS from .xlsx resource files
//			var files = Directory.EnumerateFiles(_projectRoot + _mapDirectory, "*.css", SearchOption.AllDirectories)
//				.Where(f => !f.Contains("\\bin\\") && !f.Contains("\\obj\\") && !f.Contains("\\elite\\"));

//			string str1 = GenerateClass(files);

//			File.WriteAllText(_destinationFile, str1);
//		}

//		private string CreateFilePath(string str)
//		{
//			// file path is relative to Web directory
//			return "~/" + str.Substring((_projectRoot + _mapDirectory + "\\").Length).Replace("\\", "/");
//		}

//		private string CreatePropertyName(string str)
//		{
//			// property name starts from Web
//			return str.Substring((_projectRoot).Length)
//				.Replace(".css", "").Trim('.', ',', '/', '\\', ' ').Replace(".", "_").Replace("/", "_").Replace("\\", "_").Replace("-", "_");
//		}

//		private string GenerateClass(IEnumerable<string> views)
//		{
//			return $@"namespace Calysto.Resources
//{{
//	internal static class CSSFilesList
//	{{
//{GenerateMembers(views).ToStringJoined("\r\n")}
//	}}
//}}
//";
//		}

//		private IEnumerable<string> GenerateMembers(IEnumerable<string> views)
//		{
//			foreach (string item in views)
//			{
//				yield return $"		public const string {CreatePropertyName(item)} = \"{CreateFilePath(item)}\";";
//			}
//		}
//	}
//}
