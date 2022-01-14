namespace LinqToSqlShared.DbmlObjectModel
{
	using System;

	internal class Return : Node
	{
		private string typeName;

		internal Return(string typeName)
		{
			if (typeName == null)
			{
				throw Error.SchemaRequirementViolation("Return", "Type");
			}
			this.typeName = typeName;
		}

		internal string DbType { get; set; }

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
					throw Error.SchemaRequirementViolation("Return", "Type");
				}
				this.typeName = value;
			}
		}
	}
}

