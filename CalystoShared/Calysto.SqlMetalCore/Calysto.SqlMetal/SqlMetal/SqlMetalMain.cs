using LinqToSqlShared.Common;
using LinqToSqlShared.DbmlObjectModel;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using LinqToSqlShared.CalystoGenerator.CalystoLinq2Sql;
using LinqToSqlShared.CalystoGenerator.CalystoEFCoreFluent;

namespace SqlMetal
{
	public class SqlMetalMain
	{
		public class LogItem
		{
			public Severity Severity;
			public string Description;
			public int? LineNumber;
		}

		List<LogItem> _logItems = new List<LogItem>();

		public void WriteLine(string message = null, Severity severity = Severity.Information, int? lineNumber = null)
		{
			_logItems.Add(new LogItem() { Severity = severity, Description = message, LineNumber = lineNumber });
		}

		private bool hasError;

		private void DisplayMessageWorker(Severity severity, string desc)
		{
			if (severity == Severity.Information)
			{
				this.WriteLine(desc);
			}
			else
			{
				this.WriteLine(string.Format("{0} : {1}", GetSeverityString(severity), desc), severity);
				if (severity == Severity.Error)
				{
					hasError = true;
				}
			}
		}

		private string GetSeverityString(Severity severity)
		{
			if (severity == Severity.Error)
			{
				return "Error";
			}
			if (severity == Severity.Warning)
			{
				return "Warning";
			}
			return "";
		}

		public DatabaseResult Process(ExtractorOptions extopts)
		{
			Extractor extractor = new Extractor(extopts, this.DisplayMessageWorker);
			Database db = extractor.Extract();
			DatabaseResult result = new DatabaseResult() { LogItems = this._logItems };

			if (db == null)
			{
				return null;
			}

			result.Tables = db.Tables.Select(table => new DatabaseItem() { Schema = table.Schema, FullName = table.FullName, Kind = table.Kind }).ToList();
			result.Functions = db.Functions.Select(o => new DatabaseItem() { Schema = o.Schema, FullName = o.FullName, Kind = o.Kind }).ToList();

			if (extopts.SelectionDic != null)
			{
				// will generate only selected tables and functions
				db.Tables.ToList().ForEach(table =>
				{
					if (!extopts.SelectionDic.TryGetValue(table.FullName, out var val1) || !val1.Checked)
						db.Tables.Remove(table);
				});

				db.Functions.ToList().ForEach(fnitem =>
				{
					if (!extopts.SelectionDic.TryGetValue(fnitem.FullName, out var val2) || !val2.Checked)
						db.Functions.Remove(fnitem);
				});
			}

			if (extopts.UseEFCoreEntityBase)
			{
				db.UseEFCoreEntityBase = extopts.UseEFCoreEntityBase;
			}

			if (extopts.EntityBase != null)
			{
				db.EntityBase = extopts.EntityBase;
			}

			if (!string.IsNullOrEmpty(extopts.ContextClass))
			{
				db.ContextClass = extopts.ContextClass;
			}

			if (!string.IsNullOrEmpty(extopts.Namespace))
			{
				db.ContextNamespace = extopts.Namespace;
				db.EntityNamespace = extopts.Namespace;
			}

			db.TargetMode = extopts.TargetMode;

			if (db == null)
			{
				return null;
			}
			else if (extopts.RetrieveNamesOnly)
			{
				return result;
			}

			#region write generated file

			TextWriter textWriter = null;
			Stream outputStream = null;
			
			if (!string.IsNullOrEmpty(extopts.OutputFile))
			{
				outputStream = File.Open(extopts.OutputFile, FileMode.Create);
				textWriter = new StreamWriter(outputStream, Encoding.UTF8);
			}

			if (extopts.OutputType == OutputType.CalystoLinq2SqlCSharp)
			{
				result.OutputContent = new CalystoLinq2SqlGenerator().Generate(db);
				if (!string.IsNullOrEmpty(extopts.OutputFile))
				{
					textWriter.Write(result.OutputContent);
				}
			}
			else if (extopts.OutputType == OutputType.CalystoEFCoreFluent)
			{
				result.OutputContent = new CalystoEFCoreFluentGenerator().Generate(db);
				if (!string.IsNullOrEmpty(extopts.OutputFile))
				{
					textWriter.Write(result.OutputContent);
				}
			}

			textWriter?.Flush();
			outputStream?.Close();

			if ((hasError && !string.IsNullOrEmpty(extopts.OutputFile)) && File.Exists(extopts.OutputFile))
			{
				File.Delete(extopts.OutputFile);
			}

			#endregion

			return result;
		}

	}
}