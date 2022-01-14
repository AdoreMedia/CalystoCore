namespace LinqToSqlShared.DbmlObjectModel
{
	using SqlMetal;
	using System;
    using System.Collections.Generic;

    internal class Database : Node
    {
		internal bool UseEFCoreEntityBase { get; set; }

        internal string ContextClass { get; set; }

        internal LinqToSqlShared.DbmlObjectModel.Connection Connection { get; set; }

        internal string ContextNamespace { get; set; }

        internal string EntityBase { get; set; }

        internal string EntityNamespace { get; set; }
        
        internal ClassModifier? Modifier { get; set; }
        
        internal string DatabaseName { get; set; }

        internal DbProvider TargetMode { get; set; }

        internal List<Table> Tables { get; } = new List<Table>();

        internal List<Function> Functions { get; } = new List<Function>();

    }
}

