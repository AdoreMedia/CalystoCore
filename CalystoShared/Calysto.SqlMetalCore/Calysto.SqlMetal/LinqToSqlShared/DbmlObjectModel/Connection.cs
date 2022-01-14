namespace LinqToSqlShared.DbmlObjectModel
{
    using System;

    internal class Connection : Node
    {
        private string provider;

        internal Connection(string provider)
        {
            if (provider == null)
            {
                throw Error.SchemaRequirementViolation("Connection", "Provider");
            }
            this.provider = provider;
        }

        internal string ConnectionString { get; set; }

        internal ConnectionMode? Mode { get; set; }

        internal string Provider
        {
            get
            {
                return this.provider;
            }
            set
            {
                if (value == null)
                {
                    throw Error.SchemaRequirementViolation("Connection", "Provider");
                }
                this.provider = value;
            }
        }

        internal string SettingsObjectName { get; set; }

        internal string SettingsPropertyName { get; set; }
    }
}

