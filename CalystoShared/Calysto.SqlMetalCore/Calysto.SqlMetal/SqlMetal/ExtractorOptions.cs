namespace SqlMetal
{
	using Calysto.ComponentModel;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Linq;

	public class ExtractorOptions : BindableBase<ExtractorOptions>
    {
        public string SettingsFile { get => base.Get(o => o.SettingsFile); set => base.Set(o => o.SettingsFile, value); }
        public string ConnectionString { get => base.Get(o => o.ConnectionString); set => base.Set(o => o.ConnectionString, value); }
        public string ContextClass { get => base.Get(o => o.ContextClass); set => base.Set(o => o.ContextClass, value); }
        public string Namespace { get => base.Get(o => o.Namespace); set => base.Set(o => o.Namespace, value); }
        public string CollectionNavigationPropSufix { get => base.Get(o => o.CollectionNavigationPropSufix); set => base.Set(o => o.CollectionNavigationPropSufix, value); }
        public List<string> FkPrefixesForPropName { get => base.Get(o => o.FkPrefixesForPropName); set => base.Set(o => o.FkPrefixesForPropName, value); }
        public List<string> NeverAddSchemaPrefixForSchemas { get => base.Get(o => o.NeverAddSchemaPrefixForSchemas); set => base.Set(o => o.NeverAddSchemaPrefixForSchemas, value); }

        public OutputType OutputType { get =>base.Get(o=>o.OutputType); set => base.Set(o=>o.OutputType, value); }
        public int CommandTimeout { get=>base.Get(o=>o.CommandTimeout); set=>base.Set(o=>o.CommandTimeout,value); }
        public bool Pluralize { get=>base.Get(o=>o.Pluralize); set=>base.Set(o=>o.Pluralize, value); }
        public ExtractTypes Types { get=>base.Get(o=>o.Types); set=>base.Set(o=>o.Types, value); }
        public DbProvider TargetMode { get=>base.Get(o=>o.TargetMode); set=>base.Set(o=>o.TargetMode, value); }
        public string EntityBase { get=>base.Get(o=>o.EntityBase); set=>base.Set(o=>o.EntityBase, value); }
        public string OutputFile { get=>base.Get(o=>o.OutputFile); set=>base.Set(o=>o.OutputFile, value); }

        public Dictionary<string, DatabaseItemSetting> SelectionDic { get; set; }

        public ExtractorOptions()
		{
            this.CommandTimeout = 30;
            this.Namespace = "DatabaseNamespace";
            this.FkPrefixesForPropName = new List<string>() { "FKEF_" };
            this.NeverAddSchemaPrefixForSchemas = new List<string>() { "dbo" };
            this.CollectionNavigationPropSufix = "List";
            this.Types = ExtractTypes.All;
            this.TargetMode = DbProvider.MSSQL;
            this.ConnectionString = @"Data Source=.\MSSQL2017;Initial Catalog=dbAny;Integrated Security=True;Connect Timeout=30;";
            this.ContextClass = "dbAnyDataContext";
        }

        internal bool RetrieveNamesOnly => this.OutputType == OutputType.NamesOnly;
        internal bool UseEFCoreEntityBase => this.OutputType == OutputType.CalystoEFCoreFluent;

        /// <summary>
        /// Test for schema and fullName conditions.
        /// </summary>
        /// <param name="fullName">schema.name</param>
        /// <returns></returns>
        public bool MayGenerate(string fullName)
		{
            if (this.RetrieveNamesOnly || this.SelectionDic == null)
                return true;
            else if (this.SelectionDic.TryGetValue(fullName, out var item1))
                return item1.Checked;
            else
                return false;
		}

	}
}

