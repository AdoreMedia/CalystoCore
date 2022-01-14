namespace LinqToSqlShared.DbmlObjectModel
{
	using Calysto.Common;
	using System;
	using System.Linq;

	internal class Table : Node
    {
        private string name;
        private LinqToSqlShared.DbmlObjectModel.Type type;

        internal Table()
        {
        }

        internal LinqToSqlShared.DbmlObjectModel.AccessModifier? AccessModifier { get; set; }

        internal DbObjectKind Kind { get; set; }

        internal TableFunction DeleteFunction { get; set; }

        internal TableFunction InsertFunction { get; set; }

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
        internal string Member { get; set; }

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
                    throw Error.SchemaRequirementViolation("Table", "Name");
                }
                this.name = value;

            }
        }

        internal LinqToSqlShared.DbmlObjectModel.Type Type
        {
            get
            {
                return this.type;
            }
            set
            {
                if (value == null)
                {
                    throw Error.SchemaRequirementViolation("Table", "Type");
                }
                this.type = value;
            }
        }

        internal TableFunction UpdateFunction { get; set; }
    }
}

