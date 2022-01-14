namespace LinqToSqlShared.DbmlObjectModel
{
	using SqlMetal;
	using System;
    using System.Collections.Generic;
	using System.Linq;

	internal class Type : Node
    {
        private string typeName;

        internal Type(string typeName = null)
        {
            this.typeName = typeName;
        }

		internal ResultSetInfo ResultSetInfo { get; set; }

		internal LinqToSqlShared.DbmlObjectModel.AccessModifier? AccessModifier { get; set; }

        internal List<Association> Associations { get; } = new List<Association>();

        internal List<Column> Columns { get; } = new List<Column>();

        internal string InheritanceCode { get; set; }

        internal bool? IsInheritanceDefault { get; set; }

        internal ClassModifier? Modifier { get; set; }

        internal string TypeName
        {
            get
            {
                return this.typeName;
            }
            set
            {
                if (value == null)
                {
                    throw Error.SchemaRequirementViolation("Type", "Name");
                }
                this.typeName = value;
            }
        }

        internal List<LinqToSqlShared.DbmlObjectModel.Type> SubTypes { get; } = new List<Type>();

        internal IEnumerable<LinqToSqlShared.DbmlObjectModel.Type> Descendants(bool includeCurrent)
		{
            if (includeCurrent)
                yield return this;

            foreach(var sub in this.SubTypes.SelectMany(s=>s.Descendants(true)))
            {
                yield return sub;
			}
		}
    }
}

