namespace LinqToSqlShared.DbmlObjectModel
{
    using System;

    internal class Association : Node
    {
        private string name;
        private string otherKey;
        private string thisKey;

		public Association()
        {
        }


        internal static string BuildKeyField(string[] columnNames)
        {
            if (columnNames == null)
            {
                return string.Empty;
            }
            return string.Join(",", columnNames);
        }

        internal static string[] ParseKeyField(string keyField)
        {
            if (string.IsNullOrEmpty(keyField))
            {
                return new string[0];
            }
            return keyField.Split(new char[] { ',' });
        }

        public string[] GetOtherKey()
        {
            return ParseKeyField(this.otherKey);
        }

		public string[] GetThisKey()
        {
            return ParseKeyField(this.thisKey);
        }

		public void SetOtherKey(string[] columnNames)
        {
            this.otherKey = BuildKeyField(columnNames);
        }

		public void SetThisKey(string[] columnNames)
        {
            this.thisKey = BuildKeyField(columnNames);
        }

		public LinqToSqlShared.DbmlObjectModel.AccessModifier? AccessModifier { get; set; }

		public LinqToSqlShared.DbmlObjectModel.Cardinality? Cardinality { get; set; }

		public bool? DeleteOnNull { get; set; }

		public FkDeleteRule? DeleteRule { get; set; }

		public bool? IsForeignKey { get; set; }

		public string Member { get; set; }

		public MemberModifier? Modifier { get; set; }

		public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value == null)
                {
                    throw Error.SchemaRequirementViolation("Association", "Name");
                }
                this.name = value;
            }
        }

        public string Storage => "_" + this.Member;

		public string Type { get; set; }
    }
}

