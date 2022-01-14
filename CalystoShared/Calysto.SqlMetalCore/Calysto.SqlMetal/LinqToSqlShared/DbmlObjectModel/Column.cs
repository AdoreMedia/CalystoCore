namespace LinqToSqlShared.DbmlObjectModel
{
    using System;
	using System.Text.RegularExpressions;

	internal class Column : Node
    {
        private string type;

		public Column()
        {
        }

		public bool? CanBeNull { get; set; }

		public string DbType { get; set; }

        public int? MaxLength
		{
			get
			{
                Match m1 = Regex.Match(this.DbType ?? "", "[\\d]+");
                if (m1.Success)
                    return int.Parse(m1.Value);
                else
                    return null;
			}
		}

		public string Expression { get; set; }

		private bool? _isDbGenerated;
		public bool? IsDbGenerated
		{
			get
			{
				if (_isDbGenerated.HasValue)
					return _isDbGenerated.Value;
				else if (!string.IsNullOrEmpty(this.Expression) || (this.IsVersion == true))
					return true;
				else
					return false;
			}
			set
			{
				_isDbGenerated = value;
			}
		}

		public bool? IsDelayLoaded { get; set; }

		public bool? IsDiscriminator { get; set; }

		public bool? IsPrimaryKey { get; set; }

		public bool? IsReadOnly { get; set; }

		public bool? IsVersion { get; set; }

		public LinqToSqlShared.DbmlObjectModel.AccessModifier AccessModifier { get; set; } = AccessModifier.Public;

		private LinqToSqlShared.DbmlObjectModel.AutoSync? _autoSync;
		public LinqToSqlShared.DbmlObjectModel.AutoSync AutoSync
		{
			get
			{
				if (_autoSync.HasValue)
					return _autoSync.Value;
				else if ((this.IsDbGenerated == true) && (this.IsPrimaryKey == true))
					return AutoSync.OnInsert;
				else if (this.IsDbGenerated == true)
					return AutoSync.Always;
				else
					return AutoSync.Never;
			}
			set { _autoSync = value; }
		}

		public string Member { get; set; }
		
        public MemberModifier? Modifier { get; set; }

		public string Name { get; set; }

        public string Storage => "_" + this.Member;

		/// <summary>
		/// CLR Type string
		/// </summary>
		public string PropertyType
        {
            get
            {
                return this.type;
            }
            set
            {
                if (value == null)
                {
                    throw Error.SchemaRequirementViolation("Column", "Type");
                }
                this.type = value;
            }
        }

		private LinqToSqlShared.DbmlObjectModel.UpdateCheck? _updateCheck;
		public LinqToSqlShared.DbmlObjectModel.UpdateCheck UpdateCheck
		{
			get
			{
				if (_updateCheck.HasValue)
					return _updateCheck.Value;
				else if (this.IsReadOnly == true)
					return UpdateCheck.Never;
				else
					return UpdateCheck.WhenChanged;
			}
			set { _updateCheck = value; }
		}

		public string ColumnDefaultNetValue { get; set; }

		/// <summary>
		/// Sql type only, without NOT NULL and without IDENTITY.
		/// Used in EF Core to generate table column into which is stored ID after insert.
		/// </summary>
		public string SqlColumnType { get; set; }
	}
}

