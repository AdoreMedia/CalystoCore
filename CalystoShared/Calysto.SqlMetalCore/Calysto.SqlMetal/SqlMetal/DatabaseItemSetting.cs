using Calysto.ComponentModel;
using Calysto.Serialization.Json;
using Calysto.SqlMetal.SqlMetal;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace SqlMetal
{
	public enum ResultStatusEnum
	{
		Pending,
		Success,
		Warning,
		Error,
		Skip,
		Working
	}

	public class DatabaseItemSetting : BindableBase<DatabaseItemSetting>
	{
		/// <summary>
		/// Table, View, Procedure, Function
		/// </summary>
		public string Kind { get => base.Get(o => o.Kind); set => base.Set(o => o.Kind, value); }
		/// <summary>
		/// If checked, will include in ORM classes generator.
		/// </summary>
		public bool Checked { get => base.Get(o => o.Checked); set => base.Set(o => o.Checked, value); }
		/// <summary>
		/// Db schema
		/// </summary>
		public string Schema { get => base.Get(o => o.Schema); set => base.Set(o => o.Schema, value); }
		/// <summary>
		/// Full name with schema. eg. dbo.fnGetSomething
		/// </summary>
		public string FullName { get => base.Get(o => o.FullName); set => base.Set(o => o.FullName, value); }
		/// <summary>
		/// If true, will try to execute procedure or function in transaction to get schema.
		/// </summary>
		public bool Execute { get => base.Get(o => o.Execute); set => base.Set(o => o.Execute, value); }
		/// <summary>
		/// Arguments passed to procedure or function.
		/// </summary>
		public string CsvArgs { get => base.Get(o => o.CsvArgs); set => base.Set(o => o.CsvArgs, value); }
		/// <summary>
		/// Name used in CSharp
		/// </summary>
		public string CSharpName { get => base.Get(o => o.CSharpName); set => base.Set(o => o.CSharpName, value); }

		public FunctionReturnKindEnum ReturnKind { get => base.Get(o => o.ReturnKind); set => base.Set(o => o.ReturnKind, value); }
		/// <summary>
		/// Result sets, one per line: PropertyName:Type <br/>
		/// List result: Clients:List&lt;tblClient&gt; <br/>
		/// Single result: TotalClients:int; <br/>
		/// Single result: TotalClients:Single&lt;int&gt; <br/>
		/// </summary>
		public string ResultSets { get => base.Get(o => o.ResultSets); set => base.Set(o => o.ResultSets, value); }
		/// <summary>
		/// Execute duration.
		/// </summary>
		[JsonIgnore]
		public double? DurationSec { get => base.Get(o => o.DurationSec); set => base.Set(o => o.DurationSec, value); }
		/// <summary>
		/// Developer notes.
		/// </summary>
		public string Note { get => base.Get(o => o.Note); set => base.Set(o => o.Note, value); }

		[JsonIgnore]
		public ResultStatusEnum? ResultStatus { get => base.Get(o => o.ResultStatus); set => base.Set(o => o.ResultStatus, value); }

		public List<ResultSetInfo> GetResultSetInfos()
		{
			if (string.IsNullOrWhiteSpace(this.ResultSets))
				return null;

			return this.ResultSets.Split('\r', '\n').Select(o => o.Trim()).Where(o => !string.IsNullOrEmpty(o)).Select(o => new ResultSetInfo(o)).ToList();
		}
	}
}
