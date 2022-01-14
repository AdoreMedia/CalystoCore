namespace LinqToSqlShared.DbmlObjectModel
{
	using Calysto.SqlMetal.SqlMetal;
	using System;
	using System.Collections.Generic;

	internal class Function : Node
    {
        private string name;

        internal Function()
        {
        }

		internal FunctionReturnKindEnum? ReturnKind { get; set; }

		internal LinqToSqlShared.DbmlObjectModel.AccessModifier? AccessModifier { get; set; }

        internal bool? HasMultipleResults { get; set; }
        
        internal DbObjectKind Kind { get; set; }

        /// <summary>
        /// True if result may be null.
        /// </summary>
        internal bool? IsComposable { get; set; }

        /// <summary>
        /// Database name.
        /// </summary>
        internal string Database { get; set; }

        /// <summary>
        /// Schema in database
        /// </summary>
        internal string Schema { get; set; }

        /// <summary>
        /// C# legal name
        /// </summary>
        internal string Method { get; set; }

        internal MemberModifier? Modifier { get; set; }

        /// <summary>
        /// Schema and name in database
        /// </summary>
        internal string FullName => GetFullName(this.Schema, this.Name);

        /// <summary>
        /// Name in database
        /// </summary>
        internal string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value == null)
                {
                    throw Error.SchemaRequirementViolation("Function", "Name");
                }
                this.name = value;
            }
        }

        internal List<Parameter> Parameters { get; } = new List<Parameter>();

        internal LinqToSqlShared.DbmlObjectModel.Return Return { get; set; }

        internal List<LinqToSqlShared.DbmlObjectModel.Type> Types { get; } = new List<Type>();
    }
}

