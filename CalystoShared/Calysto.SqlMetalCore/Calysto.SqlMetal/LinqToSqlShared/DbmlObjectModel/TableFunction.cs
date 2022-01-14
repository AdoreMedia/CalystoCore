namespace LinqToSqlShared.DbmlObjectModel
{
    using System;
    using System.Collections.Generic;

    internal class TableFunction : Node
    {
        internal TableFunction()
        {
        }

        internal LinqToSqlShared.DbmlObjectModel.AccessModifier? AccessModifier { get; set; }

        internal List<TableFunctionParameter> Arguments { get; } = new List<TableFunctionParameter>();

        internal Function MappedFunction {get; set; }

        internal TableFunctionReturn Return { get; set; }
    }
}

