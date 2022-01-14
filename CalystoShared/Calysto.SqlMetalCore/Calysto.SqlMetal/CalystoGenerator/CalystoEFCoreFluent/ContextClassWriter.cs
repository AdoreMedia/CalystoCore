using Calysto.Common.Extensions;
using LinqToSqlShared.DbmlObjectModel;
using SqlMetal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Calysto.SqlMetal.CalystoGenerator.CalystoEFCoreFluent
{
	class ContextClassWriter
	{
		internal static void Write(Database data, CalystoStringWriter writer)
		{
			writer.WriteBlockLine($@"/// <summary>
/// CalystoEFCoreFluent for {data.TargetMode}
/// </summary>");

			writer.WriteBlockLine("public partial class " + data.ContextClass + " : DbContext");
			writer.WriteBlockLine("{");
			writer.Indent++;

			WriteContextConstructors(data, writer);

			WriteContextOnConfiguring(data, writer);

			WriteContextPropertiesForTables(data, writer);

			WriteContextPropertiesForFunctions(data, writer);

			WriteContextOnModelCreating(data, writer);

			WriteContextTablesMappingDetails(data, writer);

			WriteRelationshipsMappingDetails(data, writer);

			WriteOtherDetails(data, writer);

			writer.Indent--;
			writer.WriteLine();
			writer.WriteBlockLine("}");
		}

		private static void WriteContextConstructors(Database data, CalystoStringWriter writer)
		{
			writer.WriteBlockLine("#region Context constructors");

			// do not create default ctor, it has to be created in partial class using custom settings
			//			writer.WriteLine();
			//			writer.WriteBlockLine($@"public {data.Class}() : base()
			//{{
			//	OnCreated();
			//}}");
			/*
			writer.WriteBlockLine($@"
public {data.ContextClass}(bool useLazyLoadingProxies)
	: base(new DbContextOptionsBuilder<{data.ContextClass}>()
		.{nameof(CalystoObjectExtensions.UsingThis)}(builder => {{ if (useLazyLoadingProxies) builder.UseLazyLoadingProxies(); }})
		.Options)
{{
	OnCreated();
}}");
			*/
			writer.WriteBlockLine($@"
public {data.ContextClass}(Action<DbContextOptionsBuilder<{data.ContextClass}>> configure)
	: base(new DbContextOptionsBuilder<{data.ContextClass}>()
		.{nameof(CalystoObjectExtensions.UsingThis)}(builder => configure(builder))
		.Options)
{{
	OnCreated();
}}");

			writer.WriteLine();
			writer.WriteBlockLine($@"public {data.ContextClass}(DbContextOptions<{data.ContextClass}> options) : base(options)
{{
	OnCreated();
}}");

			writer.WriteLine();
			writer.WriteBlockLine(@"#endregion Context constructors");
		}

		private static void WriteContextOnConfiguring(Database data, CalystoStringWriter writer)
		{
			writer.WriteLine();
			writer.WriteBlockLine(@"#region OnConfiguring");

			writer.WriteLine();
			writer.WriteBlockLine($@"protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{{
	if (!optionsBuilder.IsConfigured ||
		(!optionsBuilder.Options.Extensions.OfType<RelationalOptionsExtension>().Any(ext => !string.IsNullOrEmpty(ext.ConnectionString) || ext.Connection != null) &&
		!optionsBuilder.Options.Extensions.Any(ext => !(ext is RelationalOptionsExtension) && !(ext is CoreOptionsExtension))))
	{{
		optionsBuilder.UseSqlServer(@""{data.Connection?.ConnectionString}"");
	}}
	CustomizeConfiguration(ref optionsBuilder);
	base.OnConfiguring(optionsBuilder);
}}");

			writer.WriteLine();
			writer.WriteBlockLine(@"partial void CustomizeConfiguration(ref DbContextOptionsBuilder optionsBuilder);");

			writer.WriteLine();
			writer.WriteBlockLine(@"#endregion OnConfiguring");
		}

		private static void WriteContextPropertiesForTables(Database data, CalystoStringWriter writer)
		{
			writer.WriteLine();
			writer.WriteBlockLine("#region Context properties for tables");
			writer.WriteLine();
			foreach (var table in data.Tables)
			{
				writer.WriteBlockLine("public virtual DbSet<" + table.Member + "> " + table.Member + " { get; set; }");
			}
			writer.WriteLine();
			writer.WriteBlockLine("#endregion Context properties for tables");
		}

		private static void WriteContextPropertiesForFunctions(Database data, CalystoStringWriter writer)
		{
			writer.WriteLine();
			writer.WriteBlockLine("#region Context database functions");
			writer.WriteLine();
			foreach (var func in data.Functions)
			{
				List<string> list = new List<string>();
				list.Add("Name=\"" + func.Name + "\"");

				if (func.IsComposable == true)
				{
					// if is function Table-valued or Scalar-valued return type
					list.Add("IsComposable=true");
				}
				else
				{
					// it is stored procedure
				}

				string returnType = "void";
				string listElementType = "";
				bool returnMultiple = false;
				bool returnList = false;
				bool returnSingleValue = false;
				//bool runCommand = false;
				bool returnDataTable = false;
				bool returnDataSet = false;

				bool isFunction = func.Kind == DbObjectKind.FunctionScalarValued || func.Kind == DbObjectKind.FunctionTableValued;
				string fromWord = isFunction ? "function" : "stored procedure";
				string commentReturns = null;

				if(func.ReturnKind == SqlMetal.FunctionReturnKindEnum.DataTable)
				{
					returnType = "DataTable";
					returnDataTable = true;
				}
				else if(func.ReturnKind == SqlMetal.FunctionReturnKindEnum.DataSet)
				{
					returnType = "DataSet";
					returnDataSet = true;
				}
				else if (func.HasMultipleResults == true)
				{
					// multiple results container type must be single, it's children are subtypes
					var type11 = func.Types.Single();

					returnMultiple = true;
					returnType = type11.TypeName; // "MultipleResultsReader";
					commentReturns = $"MultipleResults from {fromWord}";
				}
				else if (func.Types?.Count > 1)
				{
					throw new InvalidOperationException();
				}
				else if (func.Types?.Count == 1)
				{
					LinqToSqlShared.DbmlObjectModel.Type type1 = func.Types.First();
					// return List<type>
					bool isCollection = type1.ResultSetInfo == null || ResultSetInfo.IsCollectionType(type1.ResultSetInfo.PropertyType);
					if (isCollection)
					{
						returnList = true;
						returnType = ResultSetInfo.CreateCollectionType(EFUtility.GetColumnType(type1.TypeName, false));
						listElementType = type1.TypeName;
						commentReturns = $"Sequence from {fromWord}";
					}
					else
					{
						// return single value
						returnSingleValue = true;
						returnType = EFUtility.GetColumnType(type1.TypeName, func.IsComposable);
						commentReturns = $"Scalar value from {fromWord}";
					}
				}
				else if(func.Return?.TypeName != null)
				{
					LinqToSqlShared.DbmlObjectModel.Return type1 = func.Return;
					// return single value
					returnSingleValue = true;
					returnType = EFUtility.GetColumnType(type1.TypeName, func.IsComposable);
					commentReturns = $"Scalar value from {fromWord}";
				}
				else
				{
					throw new NotSupportedException();
				}

				var fnIsAsignable = new Func<Parameter, bool>(par =>
				{
					if (string.IsNullOrEmpty(par.ParameterDefaultNetValue))
						return false;

					if (par.IsOutput)
						return false;

					if (par.Type == "System.DateTime" && par.ParameterDefaultNetValue != "null")
						return false;

					return true;
				});

				var parameters1 = new FunctionParametersCollection(func.Parameters);

				foreach (var par1 in parameters1.Items)
				{
					// let's create comment with default value
					string defaultValue1 = par1.HasDefaultValue ? (", DefaultValue = " + par1.Parameter.ParameterDefaultNetValue) : null;
					writer.WriteBlockLine($"/// <param name=\"{par1.CleanedName}\">{par1.Parameter.DbType}{defaultValue1}</param>");
				}

				writer.WriteBlockLine($"/// <returns>{commentReturns}</returns>");

				writer.WriteIndent();
				writer.Write("public " + returnType + " " + func.Method + "(");

				if (parameters1.Items.Any())
				{
					writer.Indent++;
					bool hasParametersAdded = false;
					bool hasMultiParameters = parameters1.Items.Count > 1;

					foreach (var par1 in parameters1.Items)
					{
						string defaultValue1 = null;
						if (par1.MayHaveCSharpDefaultValue)
						{
							defaultValue1 = " = " + par1.Parameter.ParameterDefaultNetValue;
						}

						if (hasParametersAdded)
							writer.Write(", ");

						if (hasMultiParameters)
						{
							writer.WriteLine();
							writer.WriteIndent();
						}
						
						writer.Write((par1.Parameter.IsOutput? "ref " : null) + EFUtility.GetColumnType(par1.Parameter.Type, true) + " " + par1.CleanedName + defaultValue1);
						hasParametersAdded = true;
					}

					writer.Indent--;
				}

				writer.Write(")");
				writer.WriteLine();

				// write function body

				writer.WriteBlockLine("{");
				writer.Indent++;
				{
					string placeholdersStr = null;
					string placeSpace = null;

					var placeholders1 = parameters1.Items.Select((value, index) => "{" + index + "}" + (value.Parameter.IsOutput ? " out" : null)).ToArray();

					if (placeholders1.Any())
					{
						placeholdersStr = string.Join(", ", placeholders1)?.Replace("{", "{{").Replace("}", "}}");
						placeSpace = " ";
					}

					string argumentsStr = null;

					if (parameters1.Items.Any())
					{
						argumentsStr = $", { string.Join(", ", parameters1.Items.Select(o=>o.CleanedName)) }";
					}

					string schemaName = data.TargetMode == DbProvider.MySql ? func.Database : func.Schema;
					string adjustFuncName = $"{schemaName}.{func.Name}";

					if (isFunction && returnList)
					{
						writer.WriteBlockLine($@"return this.ExecuteList<{listElementType}>($@""select * from {adjustFuncName}({placeholdersStr})""{argumentsStr}).ToList();");
					}
					else if(isFunction && returnSingleValue)
					{
						writer.WriteBlockLine($@"return this.ExecuteList<{returnType}>($@""select {adjustFuncName}({placeholdersStr})""{argumentsStr}).First();");
					}
					else if(returnDataSet || returnDataTable)
					{
						string table1 = returnDataTable ? ".Tables[0]" : null;

						if(func.Kind == DbObjectKind.FunctionTableValued)
						{
							writer.WriteBlockLine($@"return this.ExecuteDataSet($@""select * from {adjustFuncName}({placeholdersStr})""{argumentsStr}){table1};");
						}
						else if(func.Kind == DbObjectKind.Procedure)
						{
							writer.WriteBlockLine($@"return this.ExecuteDataSet($@""exec {adjustFuncName}{placeSpace}{placeholdersStr}""{argumentsStr}){table1};");
						}
						else
						{
							throw new NotSupportedException();
						}
					}
					else if (!isFunction)
					{
						// sql procedure
						// procedure may have output parameters
						writer.WriteBlockLine($@"var multiple_results_1 = this.ExecuteMultipleResults($@""declare @return_value int; 
		exec @return_value = {adjustFuncName}{placeSpace}{placeholdersStr}; 
		select @return_value as ReturnValue;""{argumentsStr});");

						if (returnMultiple)
						{
							// procedure with multiple tables results
							// create results reader
							writer.WriteBlockLine($"var final_result_1 = multiple_results_1.ReadResults(res => new {returnType}()");
							writer.WriteBlockLine($"{{");
							writer.Indent++;
							var columns = EFUtility.CreateColumnData(func.Types.Single());
							foreach (var column1 in columns)
							{
								string elementType = ResultSetInfo.ExtractElementType(column1.item.PropertyType);
								bool isList = ResultSetInfo.IsCollectionType(column1.item.PropertyType);
								elementType = EFUtility.GetColumnType(elementType, column1.item.CanBeNull);
								writer.WriteBlockLine($"{column1.FixedMember} = res.GetSequence<{elementType}>().{(isList ? "ToList" : "Single")}(),");
							}
							writer.Indent--;
							writer.WriteBlockLine($"}});");
						}
						//else if (returnList)
						//{
						//	// create results reader
						//	string elementType = returnType;
						//	bool isList = false;
						//	if (elementType.StartsWith("List<"))
						//	{
						//		isList = true;
						//		elementType = elementType.Substring("List<".Length).TrimEnd('>');
						//	}
						//	writer.WriteBlockLine("// read Sequence from stored procedure");
						//	writer.WriteBlockLine($"var final_result_1 = multiple_results_1.ReadResults<{returnType}>(res => res.GetSequence<{elementType}>().{(isList ? "ToList" : "Single")}());");
						//}
						//else if (returnSingleValue)
						//{
						//	// we have to execute reader to get ReturnValue from stored procedure
						//	writer.WriteBlockLine("// read ReturnValue from stored procedure");
						//	writer.WriteBlockLine($"var final_result_1 = multiple_results_1.ReadResults<{returnType}>(res => res.GetSequence<{returnType}>().Single());");
						//}
						else
						{
							throw new NotSupportedException();
						}

						// create output parameters reader
						for (int index1 = 0; index1 < parameters1.Items.Count; index1++)
						{
							var par1 = parameters1.Items[index1];
							if (par1.Parameter.IsOutput)
							{
								writer.WriteBlockLine("// read Output parameter from stored procedure");
								writer.WriteBlockLine($"{par1.CleanedName} = Calysto.Utility.CalystoTypeConverter.ChangeType<{EFUtility.GetColumnType(par1.Parameter.Type, true)}>(multiple_results_1.Command.Parameters[{index1}].Value);");
							}
						}

						if (returnMultiple || returnList || returnSingleValue)
						{
							writer.WriteBlockLine("return final_result_1;");
						}
						else
						{
							// void return
						}
					}
					else
					{
						throw new NotSupportedException();
					}
				}
				writer.Indent--;
				writer.WriteBlockLine("}");
				writer.WriteLine();
			}
			writer.WriteLine();
			writer.WriteBlockLine("#endregion Context database functions");
		}

		private static string BuildQueryPlaceholders(object[] values)
		{
			return string.Join(", ", values.Select((value, index) => "{" + index + "}"));
		}

		private static void WriteContextOnModelCreating(Database data, CalystoStringWriter writer)
		{
			writer.WriteLine();
			writer.WriteBlockLine("#region OnModelCreating");
			writer.WriteLine();
			writer.WriteBlockLine("protected override void OnModelCreating(ModelBuilder modelBuilder)");
			writer.WriteBlockLine("{");
			writer.Indent++;
			foreach(var table in data.Tables)
			{
				writer.WriteBlockLine($"this.Map_{table.Member}(modelBuilder);");
				writer.WriteBlockLine($"this.Customize_{table.Member}(modelBuilder);");
				writer.WriteLine();
			}

			writer.WriteBlockLine("RelationshipsMapping(modelBuilder);");
			writer.WriteBlockLine("CustomizeMapping(ref modelBuilder);");
			writer.Indent--;

			writer.WriteBlockLine("}");
			writer.WriteLine();
			writer.WriteBlockLine("#endregion");
		}

		private static void WriteContextTablesMappingDetails(Database data, CalystoStringWriter writer)
		{
			writer.WriteLine();
			writer.WriteBlockLine("#region TablesMappingDetails");
			foreach (var table in data.Tables)
			{
				writer.WriteLine();
				writer.WriteBlockLine("#region " + table.Member);

				writer.WriteBlockLine($"private void Map_{table.Member}(ModelBuilder modelBuilder)");
				writer.WriteBlockLine("{");
				writer.Indent++;

				string schemaName = data.TargetMode == DbProvider.MySql ? table.Database : table.Schema;
				writer.WriteBlockLine($"modelBuilder.Entity<{table.Member}>().ToTable(\"{ table.Name}\", \"{schemaName}\");");

				var columns1 = EFUtility.CreateColumnData(table.Type);

				var pkkeys = columns1.Where(o => o.item.IsPrimaryKey == true).ToList();
				if (pkkeys.Any())
				{
					if (pkkeys.Count == 1)
					{
						writer.WriteBlockLine($"modelBuilder.Entity<{table.Member}>().HasKey(x=>x.{pkkeys.First().item.Member});");
					}
					else
					{
						List<string> membersList = pkkeys.Select(k => "\"" + k.item.Member + "\"").ToList();
						// EF requires PK to be set at once as csv in HasKey()
						writer.WriteBlockLine($"modelBuilder.Entity<{table.Member}>().HasKey({string.Join(", ", membersList)});");
					}
				}
				else
				{
					writer.WriteBlockLine($"modelBuilder.Entity<{table.Member}>().HasNoKey();");
				}

				foreach (var column in columns1)
				{
					writer.WriteIndent();
					writer.Write($"modelBuilder.Entity<{table.Member}>()");
					writer.Write($".Property(x=>x.{column.FixedMember})");
					writer.Write($".HasColumnName(\"{column.FixedMember}\")");

					writer.Write($".HasColumnType(\"{column.item.SqlColumnType}\")");

					if(column.item.CanBeNull != true)
						writer.Write($".IsRequired()");

					if(column.item.IsDbGenerated==true)
						writer.Write($".ValueGeneratedOnAdd()");
					else
						writer.Write($".ValueGeneratedNever()");

					int? maxLength = column.item.MaxLength;
					if(maxLength.HasValue)
						writer.Write($".HasMaxLength({maxLength})");

					writer.Write(";");

					writer.WriteLine();
				}

				writer.Indent--;
				writer.WriteBlockLine("}");
				
				writer.WriteLine();
				writer.WriteBlockLine($"partial void Customize_{table.Member}(ModelBuilder modelBuilder);");

				writer.WriteBlockLine("#endregion");
			}

			writer.WriteLine();
			writer.WriteBlockLine("#endregion");
		}

		private static void WriteRelationshipsMappingDetails(Database data, CalystoStringWriter writer)
		{
			writer.WriteLine();
			writer.WriteBlockLine("#region Relationships mapping");
			writer.WriteBlockLine("private void RelationshipsMapping(ModelBuilder modelBuilder)");
			writer.WriteBlockLine("{");
			writer.Indent++;

			foreach (var table in data.Tables)
			{
				bool hasAssoc = false;

				foreach (AssociationData assocData in AssociationData.CreateValidCollection(data, table.Type.Associations))
				{
					hasAssoc = true;
					bool isOneToOne = assocData.thisAssociation.Cardinality == Cardinality.One && assocData.otherAssociation.Cardinality == Cardinality.One;

					//string FKTableMember = null;
					bool FKCanBeNull = false;

					if (assocData.thisAssociation.IsForeignKey == true)
					{
						//FKTableMember = assocData.thisTable.Member;
						FKCanBeNull = assocData.thisColumn.CanBeNull == true;
					}
					else if (assocData.otherAssociation.IsForeignKey == true)
					{
						//FKTableMember = assocData.otherTable.Member;
						FKCanBeNull = assocData.otherColumn.CanBeNull == true;
					}
					else
						throw new InvalidOperationException("Association has no FK");

					writer.WriteIndent();

					writer.Write($"modelBuilder.Entity<{table.Member}>()");

					writer.Write($".{(assocData.thisAssociation.Cardinality == Cardinality.One ? "HasOne" : "HasMany")}(x=>x.{assocData.thisAssociation.Member})");

					writer.Write($".{(assocData.otherAssociation.Cardinality == Cardinality.One ? "WithOne" : "WithMany")}(x=>x.{assocData.otherAssociation.Member})");

					if (assocData.thisAssociation.Cardinality == Cardinality.One && assocData.otherAssociation.Cardinality == Cardinality.One)
					{
						writer.Write($".HasForeignKey<{assocData.otherTable.Member}>(x=>x.{assocData.otherKey})");
					}
					else if(assocData.thisAssociation.Cardinality == Cardinality.One && assocData.otherAssociation.Cardinality == Cardinality.Many)
					{
						writer.Write($".HasForeignKey(x=>x.{assocData.thisKey})");
					}
					else if(assocData.thisAssociation.Cardinality == Cardinality.Many && assocData.otherAssociation.Cardinality == Cardinality.One)
					{
						writer.Write($".HasForeignKey(x=>x.{assocData.otherKey})");
					}
					else
					{
						// Many to Many
						throw new InvalidOperationException("Many to Many is not supported.");
					}

					// EF5 requires IsRequired(...) to be invoked after HasForeignKey
					writer.Write($".IsRequired({(FKCanBeNull ? "false" : "true")})");

					switch (assocData.thisAssociation.DeleteRule)
					{
						case FkDeleteRule.Cascade:
						case FkDeleteRule.SetNull:
							writer.Write($".OnDelete(DeleteBehavior.{assocData.thisAssociation.DeleteRule})");
							break;
					}

					switch (assocData.otherAssociation.DeleteRule)
					{
						case FkDeleteRule.Cascade:
						case FkDeleteRule.SetNull:
							writer.Write($".OnDelete(DeleteBehavior.{assocData.otherAssociation.DeleteRule})");
							break;
					}

					writer.Write(";");

					writer.WriteLine();
				}

				if (hasAssoc)
					writer.WriteLine();
			}

			writer.Indent--;
			writer.WriteBlockLine("}");
			writer.WriteBlockLine("#endregion");
		}

		private static void WriteOtherDetails(Database data, CalystoStringWriter writer)
		{
			writer.WriteLine();

			writer.WriteBlockLine("#region Other details");
			writer.WriteBlockLine(@"partial void CustomizeMapping(ref ModelBuilder modelBuilder);

public bool HasChanges()
{
    return ChangeTracker.Entries().Any(e => e.State == Microsoft.EntityFrameworkCore.EntityState.Added || e.State == Microsoft.EntityFrameworkCore.EntityState.Modified || e.State == Microsoft.EntityFrameworkCore.EntityState.Deleted);
}

partial void OnCreated();");

			writer.WriteBlockLine("#endregion");
		}

	}
}
