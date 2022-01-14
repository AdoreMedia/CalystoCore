using LinqToSqlShared.DbmlObjectModel;
using System.Collections.Generic;
using System.Linq;

namespace Calysto.SqlMetal.CalystoGenerator.CalystoEFCoreFluent
{
	class AssociationData
	{
		public Association thisAssociation;
		public Association otherAssociation;
		public string thisKey;
		public string otherKey;
		public Table thisTable;
		public Table otherTable;
		public Column thisColumn;
		public Column otherColumn;
		private bool _isDataValid;

		private AssociationData(Database data, Association assoc)
		{
			// ako imamo FK u dbml designeru, a tabela je obrisana, nece naci drugu tabelu, zato je u try-cach-u pa nece ni kreirati asocijaciju u C#
			try
			{
				this.thisAssociation = assoc;
				this.thisKey = assoc.GetThisKey().First();
				this.thisTable = data.Tables.Where(o => o.Type.Associations.Contains(assoc)).Single();
				this.thisColumn = this.thisTable.Type.Columns.Where(o => o.Member == thisKey).Single();

				this.otherKey = assoc.GetOtherKey().First();
				this.otherTable = data.Tables.Where(o => o.Type.TypeName == assoc.Type).Single();
				this.otherAssociation = otherTable.Type.Associations.Where(o => o.Type == thisTable.Type.TypeName && o.GetThisKey().First() == otherKey && o.GetOtherKey().First() == thisKey).Single();
				this.otherColumn = otherTable.Type.Columns.Where(o => o.Member == otherKey).Single();
				this._isDataValid = true;
			}
			catch
			{
			}
		}

		private bool HasPrimaryKey(LinqToSqlShared.DbmlObjectModel.Type type)
		{
			return type.Columns.Where(o => o.IsPrimaryKey == true).Any();
		}

		private bool IsValidAssociation()
		{
			// EF requres that tables have PK
			return this._isDataValid && HasPrimaryKey(this.thisTable.Type) && HasPrimaryKey(this.otherTable.Type);
		}

		public static IEnumerable<AssociationData> CreateValidCollection(LinqToSqlShared.DbmlObjectModel.Database data, IEnumerable<Association> collection)
		{
			foreach (Association assoc in collection)
			{
				AssociationData dd = new AssociationData(data, assoc);
				if (dd.IsValidAssociation())
				{
					yield return dd;
				}
			}
		}
	}
}

