using Calysto.Common.Extensions;
using Calysto.SqlMetal.CalystoGenerator.CalystoEFCoreFluent;
using System.Linq;

namespace SqlMetal
{
	public class ResultSetInfo
	{
		public static string CreateCollectionType(string elementType)
		{
			return "List<" + elementType + ">";
		}

		public static bool IsCollectionType(string typeName)
		{
			return typeName?.StartsWith("List<") == true;
		}

		public static string ExtractElementType(string typeName)
		{
			return typeName?.Replace("List<", "").Replace("Single<", "").Replace(">", "").Trim()?.ToNullIfEmpty(true);
		}

		public static bool IsSingleType(string typeName)
		{
			return typeName?.StartsWith("Single<") == true;
		}

		public string PropertyName { get; }
		public string PropertyType { get; }
		public string ElementType { get; }
		public bool HasElementType { get; }

		public ResultSetInfo(string row)
		{
			var arr = row.Split(':').Select(o=>o.Trim()).ToArray();
			this.PropertyName = arr.FirstOrDefault()?.ToNullIfEmpty(true);
			this.PropertyType = arr.Skip(1).FirstOrDefault()?.ToNullIfEmpty(true);

			if (this.PropertyType != null)
				this.ElementType = ExtractElementType(this.PropertyType);

			this.HasElementType = !string.IsNullOrWhiteSpace(this.ElementType);
		}
	}
}
