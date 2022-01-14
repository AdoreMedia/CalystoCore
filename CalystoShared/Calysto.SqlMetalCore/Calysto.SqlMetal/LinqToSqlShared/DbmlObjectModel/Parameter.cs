namespace LinqToSqlShared.DbmlObjectModel
{
    using System;

    internal class Parameter : Node
    {
        private string name;
        private string type;

        internal Parameter(string name, string type)
        {
            if (name == null)
            {
                throw Error.SchemaRequirementViolation("Parameter", "Name");
            }
            this.name = name;
            if (type == null)
            {
                throw Error.SchemaRequirementViolation("Parameter", "Type");
            }
            this.type = type;
        }

		public string ParameterDefaultNetValue { get; set; }

		internal string DbType { get; set; }

        internal ParameterDirection? Direction { get; set; }

        public bool IsOutput => this.Direction == ParameterDirection.Out || this.Direction == ParameterDirection.InOut;

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
                    throw Error.SchemaRequirementViolation("Parameter", "Name");
                }
                this.name = value;
            }
        }

        internal string ParameterName { get; set; }

        internal string Type
        {
            get
            {
                return this.type;
            }
            set
            {
                if (value == null)
                {
                    throw Error.SchemaRequirementViolation("Parameter", "Type");
                }
                this.type = value;
            }
        }
    }
}

