namespace LinqToSqlShared.DbmlObjectModel
{
    using System;

    internal class TableFunctionParameter : Node
    {
        private string member;
        private string parameterName;

        internal TableFunctionParameter(string name, string member)
        {
            if (name == null)
            {
                throw Error.SchemaRequirementViolation("Parameter", "Parameter");
            }
            if (member == null)
            {
                throw Error.SchemaRequirementViolation("Parameter", "Member");
            }
            this.parameterName = name;
            this.member = member;
        }

        internal string Member
        {
            get
            {
                return this.member;
            }
            set
            {
                if (value == null)
                {
                    throw Error.SchemaRequirementViolation("Parameter", "Member");
                }
                this.member = value;
            }
        }

        internal string ParameterName
        {
            get
            {
                return this.parameterName;
            }
            set
            {
                if (value == null)
                {
                    throw Error.SchemaRequirementViolation("Parameter", "Parameter");
                }
                this.parameterName = value;
            }
        }

        internal LinqToSqlShared.DbmlObjectModel.Version? Version { get; set; }
    }
}

