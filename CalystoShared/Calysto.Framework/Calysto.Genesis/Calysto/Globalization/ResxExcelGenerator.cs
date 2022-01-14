using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Web;
using System.Linq;
using Calysto.Utility;
using Calysto.Linq;

namespace Calysto.Globalization
{
	/// <summary>
	/// Generate C# and TypeScript classes
	/// </summary>
	public class ResxExcelGenerator
	{
		/// <summary>
		/// Property name inside Resx generated class.
		/// Name is used to get field value using reflection in <see cref="ResxExcelProvider"/>
		/// </summary>
		public const string ResourceProvider = nameof(ResourceProvider);
		private byte[] _excelData;
		private string _namespace;
		private string _className;
		private string _resxProviderTypeName;
		private string _commentsFromColumn;
		private bool _allowDuplicatedProperties;
		private static string _defaultResxProviderType = typeof(ResxExcelProvider).Name;

		public ResxExcelGenerator(
			byte[] excelData,
			string nameSpace,
			string className,
			string commentsFromColumn = default,
			string resxProviderType = default,
			bool allowDuplicatedProperties = false)
		{
			_excelData = excelData;
			_namespace = nameSpace;
			_className = className;
			_commentsFromColumn = commentsFromColumn;
			_resxProviderTypeName = resxProviderType ?? _defaultResxProviderType;
			_allowDuplicatedProperties = allowDuplicatedProperties;
		}

		public class Result
		{
			public string CSharp { get; set; }
			public string TypeScript { get; set; }
			public string ClassName { get; set; }
			public string NameSpace { get; set; }
			public string DefTypeScript { get; set; }
		}

		public Result Generate()
		{
			ResxExcelProvider provider = new ResxExcelProvider(_excelData);
			string jsonTable = Calysto.Serialization.Json.JsonSerializer.Serialize(provider.Table);
			var defaultColumn = provider.Columns.Skip(1).First();
			if (!string.IsNullOrEmpty(_commentsFromColumn))
				defaultColumn = provider.Columns.Where(colName => colName == _commentsFromColumn).First();

			if (!_allowDuplicatedProperties)
			{
				var list1 = provider.ReadTableCells().Where(o => o.ColumnName == defaultColumn).GroupBy(o => o.PropertyName).Where(o => o.Count() > 1).ToList();
				if (list1.Any())
				{
					throw new Exception("Duplicated properties: \r\n" + list1.Select(o => o.Key + "=" + o.Count()).ToStringJoined(" \r\n"));
				}
			}

			return new Result()
			{
				// C#
				CSharp = this.GenerateCSharpWorker(provider, HttpUtility.JavaScriptStringEncode(jsonTable), defaultColumn),

				// TS
				TypeScript = this.GenerateTypeScriptWorker(provider, jsonTable, defaultColumn),

				// d.ts
				DefTypeScript = this.GenerateDefTypeScriptWorker(provider, jsonTable, defaultColumn)
			};
		}

		/// <summary>
		/// Split txt by \r\n and return lines
		/// </summary>
		/// <param name="str"></param>
		/// <param name="newLine"></param>
		/// <returns></returns>
		public static IEnumerable<string> SplitToLines(string str)
		{
			return (str ?? "").Split('\r', '\n')
			 .Select(o => o.Trim())
			 .Where(o => !string.IsNullOrWhiteSpace(o));
		}

		#region C# resources

		/// <summary>
		/// Tenerated class has to be public class name, this way it may be sent as generic type argument.
		/// Static class may not be used as generic type argument.
		/// Default constructor has to be private to disable class instantination.
		/// Properties has to be public static for MS localization in MVC data model binding to be able to read them.
		/// </summary>
		/// <param name="provider"></param>
		/// <param name="jsonDic"></param>
		/// <param name="ns"></param>
		/// <param name="cls"></param>
		/// <returns></returns>
		private string GenerateCSharpWorker(ResxExcelProvider provider, string jsonDic, string defaultColumn)
		{
			return $@"using Calysto.Globalization;

namespace {_namespace}
{{
    public class {_className} : {nameof(ICalystoResx)}
    {{
		private {_className}(){{ }}

		static string[] _columns = new string[] {{ {provider.Columns.Select(o => CalystoTools.QuoteString(o)).ToStringJoined(", ")} }};

		const string _json = ""{jsonDic}"";

        public static readonly {_resxProviderTypeName} ResourceProvider = {_resxProviderTypeName}.FromJson<{_resxProviderTypeName}>(_json);

{this.GenerateCSharpProperties(provider, defaultColumn)}
	}}
}}
";
		}

		private string GetUniquePropertyName(Dictionary<string, int> dic, string propName)
		{
			if(dic.TryGetValue(propName, out int cnt))
			{
				dic[propName] = cnt + 1;
				return propName + "_duplicated" + (cnt + 1);
			}
			else
			{
				dic[propName] = 0;
				return propName;
			}
		}

		private string GenerateCSharpProperties(ResxExcelProvider provider, string defaultColumn)
		{
			Dictionary<string, int> dic1 = new Dictionary<string, int>();

			return provider.ReadTableCells().Where(o=>o.ColumnName == defaultColumn)
				.OrderBy(o=>o.PropertyName)
				.Select(pp => $@"
        /// <summary>{this.GetCSharpSummaryLines(pp.CellValue)} 
        /// </summary>
		public static string {GetUniquePropertyName(dic1, pp.PropertyName)} => ResourceProvider.GetString(""{pp.PropertyName}"");
").ToStringJoined();
		}

		private string GetCSharpSummaryLines(string txt)
		{
			return SplitToLines(txt)
				.Select(line => line.Replace("<", "&lt;").Replace(">", "&gt;"))
				.Select(line => $@"
        /// {line}").ToStringJoined("<br/>");
		}

		#endregion

		#region TypeScript resources

		private string GenerateDefTypeScriptWorker(ResxExcelProvider provider, string jsonDic, string defaultColumn)
		{
			return $@"declare namespace {_namespace}
{{
    namespace {_className}
	{{
		{this.GenerateDefTypeScriptProperties(provider, defaultColumn)}
	}}
}}
";
		}

		private string GenerateDefTypeScriptProperties(ResxExcelProvider provider, string defaultColumn)
		{
			Dictionary<string, int> dic1 = new Dictionary<string, int>();

			return provider.ReadTableCells().Where(o => o.ColumnName == defaultColumn)
				.Distinct(o => o.PropertyName)
				.OrderBy(o => o.PropertyName)
				.Select(pp => $@"
		/** {this.GetTypeScriptSummaryLines(pp.CellValue)} */
		export const {GetUniquePropertyName(dic1, pp.PropertyName)} = ""{HttpUtility.JavaScriptStringEncode(pp.CellValue)}"";
").ToStringJoined();
		}

		private string GenerateTypeScriptWorker(ResxExcelProvider provider, string jsonDic, string defaultColumn)
		{
			return $@"namespace {_namespace}
{{
	const _columns = [ {provider.Columns.Select(o => CalystoTools.QuoteString(o)).ToStringJoined(", ")} ];

	const _json = {jsonDic};

	export interface {_className} {{ }}

    export class {_className}
	{{
		public static readonly ResourceProvider = Calysto.Globalization.ResxExcelProvider.FromJson(_json);

		{this.GenerateTypeScriptProperties(provider, defaultColumn)}
	}}
}}
";
		}

		private string GenerateTypeScriptProperties(ResxExcelProvider provider, string defaultColumn)
		{
			Dictionary<string, int> dic1 = new Dictionary<string, int>();

			return provider.ReadTableCells().Where(o => o.ColumnName == defaultColumn)
				.Distinct(o=>o.PropertyName)
				.OrderBy(o => o.PropertyName)
				.Select(pp => $@"
		/** {this.GetTypeScriptSummaryLines(pp.CellValue)} */
		public static get {GetUniquePropertyName(dic1, pp.PropertyName)}() {{ return {_className}.ResourceProvider.GetString(""{pp.PropertyName}"") }}
").ToStringJoined();
		}

		private string GetTypeScriptSummaryLines(string txt)
		{
			return SplitToLines(txt).Select(line => $@"{line}").ToStringJoined("\r\n");
		}

		#endregion

	}
}
