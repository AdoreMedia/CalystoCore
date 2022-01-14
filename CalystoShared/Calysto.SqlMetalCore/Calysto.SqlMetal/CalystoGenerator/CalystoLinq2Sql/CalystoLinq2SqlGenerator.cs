using LinqToSqlShared.DbmlObjectModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Calysto.Linq;
using Calysto.Common.Extensions;
using Calysto.SqlMetal.CalystoGenerator.CalystoEFCoreFluent;

namespace LinqToSqlShared.CalystoGenerator.CalystoLinq2Sql
{
	class CalystoLinq2SqlGenerator
	{
		public string Generate(Database db)
		{
			//db = Dbml.CopyWithFilledInDefaults(db);
			CalystoStringWriter writer = new CalystoStringWriter();
			WriteWorker(db, writer);
			return writer.ToString();
		}

		private void WriteWorker(Database data, CalystoStringWriter writer)
		{
			writer.Write2(@"#pragma warning disable 1591
//************************************************************
// Generated using CalystoLinqToSQLGenerator - CalystoSqlMetal
//************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Calysto.Data.Linq;
using Calysto.Data.Linq.Mapping;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
");

			if (!string.IsNullOrEmpty(data.ContextNamespace))
			{
				writer.Write2("namespace " + data.ContextNamespace);
				writer.Write2("{");
				writer.Indent++;
			}

			#region Context class

			writer.Write2("[DatabaseAttribute(Name=\"" + data.DatabaseName + "\")]");
			writer.Write2("public partial class " + data.ContextClass + " : Calysto.Data.Linq.DataContext");
			writer.Write2("{");
			writer.Indent++;

			writer.Write2("private static MappingSource mappingSource = new AttributeMappingSource();");
			writer.WriteLine();

			#region Extensibility Method Definitions

			writer.Write2("#region Extensibility Method Definitions");
			writer.Write2("partial void OnCreated();");
			////// ovo se ne koristi:
			////foreach (var table in data.Tables)
			////{
			////	writer.Write2("partial void Insert" + table.Member + "(" + table.Member + " instance);");
			////	writer.Write2("partial void Update" + table.Member + "(" + table.Member + " instance);");
			////	writer.Write2("partial void Delete" + table.Member + "(" + table.Member + " instance);");
			////}
			writer.Write2("#endregion Extensibility Method Definitions");

			#endregion

			#region Context constructors

			writer.WriteLine();
			writer.Write2("#region Context constructors");

			/* do not create default constructor, enable setting it in the code manualy
			if (data.Connection != null)
			{
				writer.WriteLine();

				if (data.Connection.Mode == ConnectionMode.WebSettings)
				{
					writer.Write2("public " + data.Class + "() : base(" + data.Connection.SettingsObjectName + "[@\"" + data.Connection.SettingsPropertyName + "\"].ConnectionString, mappingSource)");
				}
				else if (data.Connection.Mode == ConnectionMode.AppSettings)
				{
					writer.Write2("public " + data.Class + "() : base(" + data.Connection.SettingsObjectName + ".Default." + data.Connection.SettingsPropertyName + ", mappingSource)");
				}
				else if (data.Connection.Mode == ConnectionMode.ConnectionString)
				{
					writer.Write2("public " + data.Class + "() : base(@\"" + data.Connection.ConnectionString + "\", mappingSource)");
				}
				else
				{
					throw new NotSupportedException();
				}

				writer.Write2("{");
				writer.Write3("OnCreated();");
				writer.Write2("}");
			}
			*/

			writer.WriteLine();
			writer.Write2("public " + data.ContextClass + "(string connection) : base(connection, mappingSource)");
			writer.Write2("{");
			writer.Write3("OnCreated();");
			writer.Write2("}");

			writer.WriteLine();
			writer.Write2("public " + data.ContextClass + "(IDbConnection connection) : base(connection, mappingSource)");
			writer.Write2("{");
			writer.Write3("OnCreated();");
			writer.Write2("}");

			writer.WriteLine();
			writer.Write2("public " + data.ContextClass + "(string connection, MappingSource mappingSource) : base(connection, mappingSource)");
			writer.Write2("{");
			writer.Write3("OnCreated();");
			writer.Write2("}");

			writer.WriteLine();
			writer.Write2("public " + data.ContextClass + "(IDbConnection connection, MappingSource mappingSource) : base(connection, mappingSource)");
			writer.Write2("{");
			writer.Write3("OnCreated();");
			writer.Write2("}");

			writer.Write2("#endregion Context constructors");

			#endregion

			#region Context properties for tables

			writer.WriteLine();
			writer.Write2("#region Context properties for tables");
			foreach (var table in data.Tables)
			{
				writer.Write2("public Calysto.Data.Linq.Table<" + table.Member + "> " + table.Member + " { get { return this.GetTable<" + table.Member + ">(); } }");
			}
			writer.Write2("#endregion Context properties for tables");

			#endregion

			#region Context properties for functions

			writer.WriteLine();
			writer.Write2("#region Context database functions");
			foreach (var func in data.Functions)
			{
				// MultipleResults not supported
				if (func.HasMultipleResults == true)
					continue;

				List<string> list = new List<string>();
				list.Add("Name=\"" + func.FullName + "\"");

				if(func.IsComposable == true)
				{
					list.Add("IsComposable=true");
				}

				writer.Write2("[FunctionAttribute(" + string.Join(", ", list) +")]");

				string returnType = "void";
				bool isSingleResult = false;
				bool hasReturnValue = false;
				bool hasMultipleResults = false;

				if (func.HasMultipleResults == true)
				{
					hasMultipleResults = true;
					returnType = "IMultipleResults";

					foreach (var class1 in func.Types)
					{
						writer.Write2("[ResultType(typeof(" + class1.TypeName + "))]");
					}
				}
				else if (func.Types != null && func.Types.Any())
				{
					returnType = "ISingleResult<" + func.Types.First().TypeName + ">";
					isSingleResult = true;
				}
				else if (func.Return != null && func.Return.TypeName != null)
				{
					hasReturnValue = true;
					returnType = EFUtility.GetColumnType(func.Return.TypeName, func.IsComposable);
				}

				writer.Write2("public " + returnType + " " + func.Method + "(");
				writer.Indent++;
				var parameters1 = new FunctionParametersCollection(func.Parameters);

				bool hasParametersAdded = false;
				foreach (var par1 in parameters1.Items)
				{
					string defaultValue1 = null;
					if (par1.MayHaveCSharpDefaultValue)
					{
						defaultValue1 = " = " + par1.Parameter.ParameterDefaultNetValue;
					}

					if (hasParametersAdded)
					{
						writer.WriteLine(",");
					}
					writer.WriteIndent();
					writer.Write("[ParameterAttribute(DbType=\"" + par1.Parameter.DbType + "\")]" 
						+ (par1.Parameter.IsOutput ? " ref" : null) 
						+ " " + EFUtility.GetColumnType(par1.Parameter.Type, true) + " " + par1.CleanedName + defaultValue1
					);
					hasParametersAdded = true;
				}
				if (hasParametersAdded)
				{
					writer.WriteLine();
				}

				writer.Indent--;
				writer.Write2(")");
				writer.Write2("{");
				writer.Indent++;
				{
					var arr = parameters1.Items.Select(o => ", " + o.CleanedName).ToArray();
					writer.Write2("IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod()))" + string.Join("", arr) + ");");

					foreach (var par2 in parameters1.Items.Where(o => o.Parameter.IsOutput))
					{
						writer.Write2(par2.CleanedName + " = ((" + EFUtility.GetColumnType(par2.Parameter.Type, true) + ")(result.GetParameterValue(" + par2.Index + ")));");
					}

					if(hasMultipleResults)
					{
						
					}
					else if (isSingleResult)
					{
						writer.Write2("return ((" + returnType + ") result.ReturnValue);");
					}
					else if (hasReturnValue)
					{
						writer.Write2("return ((" + returnType + ") result.ReturnValue);");
					}
				}
				writer.Indent--;
				writer.Write2("}");
				writer.WriteLine();
			}
			writer.Write2("#endregion Context database functions");

			#endregion

			writer.Indent--;
			writer.WriteLine();
			writer.Write2("}");

			#endregion Context class

			#region Entity Tables
			writer.WriteLine();
			writer.Write2("#region Entity Tables");
			writer.WriteLine();
			writer.Indent++;

			foreach (var table in data.Tables)
			{
				writer.Write2("#region " + table.FullName);
				writer.Write2("[TableAttribute(Name=\"" + table.FullName + "\")]");
				writer.Write2("public partial class " + table.Member + " : EntityBase<" + table.Member + ", " + data.ContextClass + ">, INotifyPropertyChanging, INotifyPropertyChanged, IPropertySetterInvoked");
				writer.Write2("{");
				writer.Indent++;
				writer.Write2("private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);");
				writer.WriteLine();

				var columns1 = CreateColumnData(table.Type);

				WriteTypeStorageMembers(data, table.Type, columns1, writer);

				writer.WriteLine();
				writer.Write2("#region Extensibility Method Definitions");
				writer.Write2("partial void OnLoaded();");
				writer.Write2("partial void OnValidate(Calysto.Data.Linq.ChangeAction action);");
				writer.Write2("partial void OnCreated();");
				foreach (var column in columns1)
				{
					writer.Write2("partial void On" + column.item.Member + "Changing(" + column.typeString + " value);");
					writer.Write2("partial void On" + column.item.Member + "Changed();");
				}
				writer.Write2("#endregion");
				writer.WriteLine();

				writer.Write2(@"public " + table.Member + @"()");
				writer.Write2("{");
				writer.Indent++;
				WriteAssociationInitializers(data, table, writer);
				writer.Write2("OnCreated();");
				writer.Indent--;
				writer.Write2("}");

				writer.WriteLine();

				// ***********************************************************
				// columns
				// ***********************************************************
				writer.Write2("#region Columns");

				WriteTypeColumnsData(table.Type, columns1, true, writer);

				writer.Write2("#endregion Columns");

				writer.WriteLine();

				// ***********************************************************
				// associations
				// ***********************************************************
				writer.Write2("#region Associations");

				WriteAssociationsData(data, table, writer);

				writer.Write2("#endregion Associations");

				writer.WriteLine();

				// ***********************************************************
				// property changed events
				// ***********************************************************
				writer.Write2("#region Property changing events");
				writer.Write2(@"public event PropertyChangingEventHandler PropertyChanging;
public event PropertyChangedEventHandler PropertyChanged;
public event PropertySetterInvokedEventHandler PropertySetterInvoked;");

				writer.Write2(@"
protected virtual void SendPropertyChanging()
{
	if (this.PropertyChanging != null)
	{
		this.PropertyChanging(this, emptyChangingEventArgs);
	}
}

protected virtual void SendPropertyChanged(String propertyName)
{
	if (this.PropertyChanged != null)
	{
		this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
	}
}

protected virtual void SendPropertySetterInvoked(String propertyName, Object value)
{
	if (this.PropertySetterInvoked != null)
	{
		this.PropertySetterInvoked.Invoke(this, propertyName, value);
	}
}");
				writer.Write2("#endregion Property changing events");

				writer.Indent--;
				writer.Write2("}");
				writer.Write2("#endregion " + table.FullName);
				writer.WriteLine();
			}

			writer.Indent--;
			writer.WriteLine();
			writer.Write2("#endregion Entity Tables");
			#endregion

			#region Entity Return types
			writer.WriteLine();
			writer.Write2("#region Entity Return types");
			writer.WriteLine();

			// ***********************************************************
			// return types
			// ***********************************************************
			var typesAll = data.Functions.SelectMany(o => o.Types).ToList();
			var subTypes = typesAll.SelectMany(o => o.SubTypes).ToList();

			foreach (var type in typesAll.Concat(subTypes).Distinct(o => o.TypeName))
			{
				writer.Write2("#region " + type.TypeName);
				writer.Write2("public partial class " + type.TypeName);
				writer.Write2("{");
				writer.Indent++;
				var columns2 = CreateColumnData(type);
				WriteTypeStorageMembers(data, type, columns2, writer);
				writer.WriteLine();

				writer.Write2("public " + type.TypeName + "(){ }");
				writer.WriteLine();

				WriteTypeColumnsData(type, columns2, false, writer);
				writer.Indent--;
				writer.Write2("}");
				writer.Write2("#endregion " + type.TypeName);
				writer.WriteLine();
			}

			writer.Write2("#endregion Entity Return types");
			#endregion

			if (!string.IsNullOrEmpty(data.ContextNamespace))
			{
				writer.Indent--;
				writer.WriteLine();
				writer.Write2("}");
			}

			writer.Write2("#pragma warning restore 1591");

		}


		class CalystoStringWriter : StringWriter
		{
			public int Indent;
			private string GetIndent(int cnt)
			{
				string str = "";
				for (int n = 0; n < cnt; n++)
				{
					str += "	";
				}
				return str;
			}
			public void WriteIndent()
			{
				base.Write(GetIndent(this.Indent));
			}
			/// <summary>
			/// Write line with indent
			/// </summary>
			/// <param name="str"></param>
			public void Write2(string str)
			{
				// ubaciti indent ispred svake linije
				foreach (string s1 in str.Replace("\r\n", "\n").Split('\n').Select(o => GetIndent(this.Indent) + o))
				{
					base.WriteLine(s1);
				}
			}

			/// <summary>
			/// Write only this string with increased indent
			/// </summary>
			/// <param name="str"></param>
			public void Write3(string str)
			{
				this.Indent++;
				Write2(str);
				this.Indent--;
			}
		}

		private List<ColumnData> CreateColumnData(DbmlObjectModel.Type type)
		{
			return type.Columns.Select((o, n) => new ColumnData()
			{
				item = o,
				index = n,
				typeString = EFUtility.GetColumnType(o.PropertyType, o.CanBeNull)
			}).ToList();
		}

		private void WriteAssociationInitializers(DbmlObjectModel.Database data, DbmlObjectModel.Table table, CalystoStringWriter writer)
		{
			foreach (AssociationData assocData in AssociationData.CreateValidCollection(data, table.Type.Associations))
			{
				if (assocData.thisAssociation.Cardinality == Cardinality.One)
				{
					writer.Write2(assocData.thisAssociation.Storage + " = default(EntityRef<" + assocData.thisAssociation.Type + ">);");
				}
				else if (assocData.thisAssociation.Cardinality == Cardinality.Many)
				{
					writer.Write2(assocData.thisAssociation.Storage + " = new EntitySet<" + assocData.thisAssociation.Type + @">(
	new Action<" + assocData.thisAssociation.Type + ">(item=>{this.SendPropertyChanging(); item." + assocData.otherAssociation.Member + @"=this;}), 
	new Action<" + assocData.thisAssociation.Type + ">(item=>{this.SendPropertyChanging(); item." + assocData.otherAssociation.Member + "=null;}));");
				}
				else
				{
					throw new NotSupportedException();
				}
			}
		}

		private void WriteTypeStorageMembers(DbmlObjectModel.Database data, DbmlObjectModel.Type type, List<ColumnData> columns1, CalystoStringWriter writer)
		{
			writer.Write2("#region Storage members");
			// ***********************************************************
			// storage members - columns
			// ***********************************************************
			foreach (var column in columns1)
			{
				writer.Write2("private " + column.typeString + " " + column.item.Storage + ";");
			}

			// ***********************************************************
			// storage member - associations
			// ***********************************************************
			foreach (AssociationData assocData in AssociationData.CreateValidCollection(data, type.Associations))
			{
				if (assocData.thisAssociation.Cardinality == Cardinality.One)
				{
					writer.Write2(@"private EntityRef<" + assocData.thisAssociation.Type + "> " + assocData.thisAssociation.Storage + ";");
				}
				else if (assocData.thisAssociation.Cardinality == Cardinality.Many)
				{
					writer.Write2(@"private EntitySet<" + assocData.thisAssociation.Type + "> " + assocData.thisAssociation.Storage + ";");
				}
				else
				{
					throw new NotSupportedException();
				}
			}

			writer.Write2("#endregion Storage members");
		}

		private void WriteTypeColumnsData(DbmlObjectModel.Type type, List<ColumnData> columns1, bool addEvents, CalystoStringWriter writer)
		{
			foreach (var column in columns1)
			{
				List<string> list = new List<string>();
				list.Add("Storage=\"" + column.item.Storage + "\"");
				if (column.item.AutoSync != AutoSync.Never)
				{
					list.Add("AutoSync=AutoSync." + column.item.AutoSync);
				}
				list.Add("DbType=\"" + column.item.DbType + "\"");
				list.Add("CanBeNull=" + (column.item.CanBeNull == true ? "true" : "false"));
				if (column.item.IsPrimaryKey == true)
				{
					list.Add("IsPrimaryKey=true");
				}
				if (column.item.IsDbGenerated == true)
				{
					list.Add("IsDbGenerated=true");
				}
				if(column.item.IsVersion == true)
				{
					list.Add("IsVersion=true");
				}
				if (column.item.IsDiscriminator == true)
				{
					list.Add("IsDiscriminator=true");
				}

				writer.Write2(@"/// <summary>
/// Column DbType=" + column.item.DbType + @"
/// </summary>");
				writer.Write2("[ColumnAttribute(" + string.Join(", ", list) + ")]");

				StringBuilder sb = new StringBuilder();
				sb.Append(@$"public {column.typeString} {column.FixedName}
{{
	get
	{{
		return this.{column.item.Storage};
	}}
	set
	{{
		if (this.{column.item.Storage} != value)
		{{");

				if(addEvents)
				{
					sb.Append(@$"
			this.On{column.item.Member}Changing(value);
			this.SendPropertyChanging();");
				}

				sb.Append(@$"
			this.{column.item.Storage} = value;");
				
				if (addEvents)
				{
					sb.Append(@$"
			this.SendPropertyChanged(""{column.item.Member}"");
			this.On{column.item.Member}Changed();");
				}

				sb.Append(@"
		}");
				if (addEvents)
				{
					sb.Append(@$"
		this.SendPropertySetterInvoked(""{column.item.Member}"", value);");
				}
				
		sb.Append(@"
	}
}
");
				writer.Write2(sb.ToString());
				
			}
		}

		private void WriteAssociationsData(DbmlObjectModel.Database data, DbmlObjectModel.Table table, CalystoStringWriter writer)
		{
			foreach (AssociationData assocData in AssociationData.CreateValidCollection(data, table.Type.Associations))
			{
				bool isForeignKey = assocData.thisAssociation.IsForeignKey == true;
				bool isUnique = assocData.thisAssociation.Cardinality == Cardinality.One && assocData.otherAssociation.Cardinality == Cardinality.One;

				List<string> list = new List<string>();
				list.Add("Name=\"" + assocData.thisAssociation.Name + "\"");
				list.Add("Storage=\"" + assocData.thisAssociation.Storage + "\"");
				list.Add("ThisKey=\"" + assocData.thisKey + "\"");
				list.Add("OtherKey=\"" + assocData.otherKey + "\"");
				list.Add("IsUnique=" + (isUnique ? "true" : "false"));
				list.Add("IsForeignKey=" + (isForeignKey ? "true" : "false"));
				if(assocData.thisAssociation.DeleteOnNull == true)
				{
					list.Add("DeleteOnNull=true");
				}
				if (assocData.thisAssociation.DeleteRule != null)
				{
					list.Add("DeleteRule=\"" + assocData.thisAssociation.DeleteRule + "\"");
				}

				string desc1 = (assocData.thisAssociation.IsForeignKey == true ? "[FK]" : "[PK]")
					+ ("[" + assocData.otherAssociation.Cardinality + "]") // okrece se jer znaci this ima many asocijacija
					+ assocData.thisTable.Member + "." + assocData.thisColumn.Member
					+ " --- "
					+ (assocData.otherAssociation.IsForeignKey == true ? "[FK]" : "[PK]")
					+("[" + assocData.thisAssociation.Cardinality + "]")
					+ assocData.otherTable.Member + "." + assocData.otherColumn.Member;

				writer.Write2(@"/// <summary>
/// Association " + desc1 + @"
/// </summary>");
				writer.Write2("[AssociationAttribute(" + string.Join(", ", list) + ")]");

				if (assocData.thisAssociation.Cardinality == Cardinality.One)
				{
					string thisColumnType = EFUtility.GetColumnType(assocData.thisColumn.PropertyType, assocData.thisColumn.CanBeNull);


					// moguce kombinacije asocijacija:
					// IsUnique=false, IsForeignKey=true // 1 to many
					// IsUnique=false, IsForeignKey=false << ovo ne postoji
					// IsUnique=true, IsForeignKey=true // 1 to 1
					// IsUnique=true, IsForeignKey=false // 1 to 1

					StringBuilder sb = new StringBuilder();
					sb.Append(@$"public {assocData.thisAssociation.Type} {assocData.thisAssociation.Member}
{{
	get
	{{
		return this.{assocData.thisAssociation.Storage}.Entity;
	}}
	set
	{{
		{assocData.thisAssociation.Type} previousValue = this.{assocData.thisAssociation.Storage}.Entity;
		if ((previousValue != value) || (this.{assocData.thisAssociation.Storage}.HasLoadedOrAssignedValue == false))
		{{
			this.SendPropertyChanging();
			if (previousValue != null)
			{{
				this.{assocData.thisAssociation.Storage}.Entity = null;");

					// if not unique, other property is EntitySet
					if (assocData.otherAssociation.Cardinality == Cardinality.One)
					{
						sb.Append(@$"
				previousValue.{assocData.otherAssociation.Member} = null;"); // member is EntityRef
					}
					else if (assocData.otherAssociation.Cardinality == Cardinality.Many)
					{
						sb.Append(@$"
				previousValue.{assocData.otherAssociation.Member}.Remove(this);"); // member is EntitySet
					}
					else
					{
						throw new NotSupportedException();
					}

					sb.Append(@$"
			}}
			this.{assocData.thisAssociation.Storage}.Entity = value;
			if (value != null)
			{{");

					if (assocData.otherAssociation.Cardinality == Cardinality.Many)
					{
						sb.Append(@$"
				value.{assocData.otherAssociation.Member}.Add(this);
				this.{assocData.thisColumn.Storage} = value.{assocData.otherColumn.Member};
			}}
			else
			{{
				this.{assocData.thisColumn.Storage} = default({thisColumnType});");

					}
					else if(assocData.thisAssociation.IsForeignKey==true)
					{
						sb.Append(@$"
				value.{assocData.otherAssociation.Member} = this;
				this.{assocData.thisColumn.Storage} = value.{assocData.otherColumn.Member};
			}}
			else
			{{
				this.{assocData.thisColumn.Storage} = default({thisColumnType});");

					}
					else if (assocData.otherAssociation.Cardinality == Cardinality.One)
					{
						sb.Append(@$"
				value.{assocData.otherAssociation.Member} = this;");
					}
					else
					{
						throw new NotSupportedException();
					}

					sb.AppendLine(@$"
			}}
			this.SendPropertyChanged(""{assocData.thisAssociation.Member}"");
		}}
		this.SendPropertySetterInvoked(""{assocData.thisAssociation.Member}"", value);
	}}
}}");
					writer.Write2(sb.ToString());

				}
				else if (assocData.thisAssociation.Cardinality == Cardinality.Many)
				{
					writer.Write2(@$"public EntitySet<{assocData.thisAssociation.Type}> {assocData.thisAssociation.Member}
{{
	get {{ return this.{assocData.thisAssociation.Storage}; }}
	set {{ this.{assocData.thisAssociation.Storage}.Assign(value); }}
}}
");
				}
				else
				{
					throw new NotSupportedException();
				}
			}
		}

		class ColumnData
		{
			public Column item;
			public int index;
			public string typeString;
			public string FixedName { get { return EFUtility.GetCSharpValidName(item.Member); } }
		}

	}
}