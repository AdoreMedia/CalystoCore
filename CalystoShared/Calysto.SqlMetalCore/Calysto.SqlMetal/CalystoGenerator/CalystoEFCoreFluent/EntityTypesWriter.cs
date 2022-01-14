using LinqToSqlShared.DbmlObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Calysto.Linq;
using Calysto.Common;
using System.Text.RegularExpressions;

namespace Calysto.SqlMetal.CalystoGenerator.CalystoEFCoreFluent
{
	class EntityTypesWriter
	{
		internal static void WriteFunctionsReturnTypes(Database data, CalystoStringWriter writer)
		{
			writer.WriteLine();
			writer.WriteBlockLine("#region Functions Return types");
			writer.WriteLine();

			// ***********************************************************
			// return types
			// ***********************************************************
			var typesAll = data.Functions.SelectMany(o => o.Types).ToList();
			var subTypes = typesAll.SelectMany(o => o.SubTypes).ToList();

			foreach (var type in typesAll.Concat(subTypes).Distinct(o => o.TypeName).Where(o=>o.ResultSetInfo?.HasElementType != true))
			{
				writer.WriteBlockLine("#region " + type.TypeName);
				writer.WriteBlockLine("public partial class " + type.TypeName);
				writer.WriteBlockLine("{");
				writer.Indent++;
				var columns2 = EFUtility.CreateColumnData(type);

				writer.WriteBlockLine("public " + type.TypeName + "(){ }");
				writer.WriteLine();

				WriteTypeColumnsData(type, columns2, false, writer);

				writer.Indent--;
				writer.WriteBlockLine("}");
				writer.WriteBlockLine("#endregion " + type.TypeName);
				writer.WriteLine();
			}

			writer.WriteBlockLine("#endregion");
		}

		private static void WriteTableCtor(CalystoStringWriter writer, bool useEntityBase, string className)
		{
			string arg1 = useEntityBase ? "DbContext context" : null;
			string arg2 = useEntityBase ? "context" : null;

			writer.WriteBlockLine($@"public {className}({arg1})" + (useEntityBase ? $" : base({arg2})" : null));
			writer.WriteBlockLine("{");
			writer.Indent++;
			writer.WriteBlockLine("OnCreated();");
			writer.Indent--;
			writer.WriteBlockLine("}");
			writer.WriteLine();
		}

		internal static void WriteTablesTypes(Database data, CalystoStringWriter writer)
		{
			writer.WriteLine();
			writer.WriteBlockLine("#region Entity Tables");
			writer.WriteLine();

			foreach (var table in data.Tables)
			{
				writer.WriteBlockLine("#region " + table.FullName);
				writer.WriteBlockLine($"public partial class {table.Member}" + (data.UseEFCoreEntityBase ? $" : EFCoreEntityBase<{table.Member}>" : null));
				writer.WriteBlockLine("{");
				writer.Indent++;

				WriteTableCtor(writer, false, table.Member);

				if(data.UseEFCoreEntityBase)
					WriteTableCtor(writer, data.UseEFCoreEntityBase, table.Member);

				// ***********************************************************
				// columns
				// ***********************************************************
				var columns1 = EFUtility.CreateColumnData(table.Type);

				writer.WriteBlockLine("#region Columns");

				WriteTypeColumnsData(table.Type, columns1, true, writer);

				writer.WriteBlockLine("#endregion Columns");

				writer.WriteLine();

				// ***********************************************************
				// associations
				// ***********************************************************
				writer.WriteBlockLine("#region Associations");

				WriteAssociationsData(data, table, writer);

				writer.WriteBlockLine("#endregion Associations");

				writer.WriteLine();

				writer.WriteBlockLine("partial void OnCreated();");
				writer.Indent--;
				writer.WriteBlockLine("}");
				writer.WriteBlockLine("#endregion " + table.FullName);
				writer.WriteLine();
			}

			writer.WriteLine();
			writer.WriteBlockLine("#endregion");
		}

		private static void WriteTypeColumnsData(LinqToSqlShared.DbmlObjectModel.Type type, List<ColumnData> columns1, bool addEvents, CalystoStringWriter writer)
		{
			foreach (var column in columns1)
			{
				List<string> list = new List<string>();

				if (!string.IsNullOrEmpty(column.item.DbType))
				{
					string str1 = null;
					if(Regex.IsMatch(column.item.DbType??"", "NOT[ ]+NULL"))
					{
						// already have NOT NULL
					}
					else if(!column.item.CanBeNull.GetValueOrDefault())
					{
						str1 = " NOT NULL";
					}
					
					list.Add($"DbType = \"{column.item.DbType}{str1}\"");
				}
				
				if (column.item.IsPrimaryKey == true)
				{
					list.Add("IsPrimaryKey = true");
				}
				if (column.item.IsDbGenerated == true)
				{
					list.Add("IsDbGenerated = true");
				}
				if (column.item.IsVersion == true)
				{
					list.Add("IsVersion = true");
				}
				if (column.item.IsDiscriminator == true)
				{
					list.Add("IsDiscriminator = true");
				}
				if (column.item.AutoSync != AutoSync.Never)
				{
					list.Add("AutoSync = AutoSync." + column.item.AutoSync);
				}

				string defaultValue1 = null;
				if (!string.IsNullOrEmpty(column.item.ColumnDefaultNetValue))
				{
					list.Add("DefaultValue = " + column.item.ColumnDefaultNetValue);
					defaultValue1 = " = " + column.item.ColumnDefaultNetValue + ";";
				}

				if (list.Any())
				{
					writer.WriteBlockLine(@"/// <summary>
/// " + string.Join(", ", list) + @"
/// </summary>");
				}

				writer.WriteBlockLine($"public {column.typeString} {column.FixedMember} {{ get; set; }}" + defaultValue1);

				writer.WriteLine();
			}
		}

		private static void WriteAssociationsData(LinqToSqlShared.DbmlObjectModel.Database data, LinqToSqlShared.DbmlObjectModel.Table table, CalystoStringWriter writer)
		{
			foreach (AssociationData assocData in AssociationData.CreateValidCollection(data, table.Type.Associations))
			{
				bool isForeignKey = assocData.thisAssociation.IsForeignKey == true;
				bool isUnique = assocData.thisAssociation.Cardinality == Cardinality.One && assocData.otherAssociation.Cardinality == Cardinality.One;

				string desc1 = (assocData.thisAssociation.IsForeignKey == true ? "[FK]" : "[PK]")
					+ ("[" + assocData.otherAssociation.Cardinality + "]") // okrece se jer znaci this ima many asocijacija
					+ assocData.thisTable.Member + "." + assocData.thisColumn.Member
					+ " --- "
					+ (assocData.otherAssociation.IsForeignKey == true ? "[FK]" : "[PK]")
					+ ("[" + assocData.thisAssociation.Cardinality + "]")
					+ assocData.otherTable.Member + "." + assocData.otherColumn.Member;

				writer.WriteLine();
				writer.WriteBlockLine("/// <summary>");
				writer.WriteBlockLine("/// Association <br/>");
				writer.WriteBlockLine("/// " + desc1 + " <br/>");

				if (assocData.thisAssociation.DeleteOnNull == true)
					writer.WriteBlockLine("/// DeleteOnNull = true <br/>");
				
				if (assocData.thisAssociation.DeleteRule != null)
					writer.WriteBlockLine("/// DeleteRule = " + assocData.thisAssociation.DeleteRule + " <br/>");

				writer.WriteBlockLine("/// </summary>");

				if (assocData.thisAssociation.Cardinality == Cardinality.One)
				{
					string thisColumnType = EFUtility.GetColumnType(assocData.thisColumn.PropertyType, assocData.thisColumn.CanBeNull);

					// moguce kombinacije asocijacija:
					// IsUnique=false, IsForeignKey=true // 1 to many
					// IsUnique=false, IsForeignKey=false << ovo ne postoji
					// IsUnique=true, IsForeignKey=true // 1 to 1
					// IsUnique=true, IsForeignKey=false // 1 to 1

					writer.WriteBlockLine($"public virtual {assocData.thisAssociation.Type} {assocData.thisAssociation.Member} {{ get; set; }}");

					// if not unique, other property is EntitySet
					if (assocData.otherAssociation.Cardinality == Cardinality.One)
					{
						// member is EntityRef
					}
					else if (assocData.otherAssociation.Cardinality == Cardinality.Many)
					{
						// member is EntitySet
					}
					else
					{
						throw new NotSupportedException();
					}
				}
				else if (assocData.thisAssociation.Cardinality == Cardinality.Many)
				{
					writer.WriteIndent();
					writer.Write($"public virtual List<{assocData.thisAssociation.Type}> {assocData.thisAssociation.Member} {{ get; set; }}");
					writer.Write($" = new List<{assocData.thisAssociation.Type}>();");
					writer.WriteLine();
				}
				else
				{
					throw new NotSupportedException();
				}
			}
		}
	}
}
