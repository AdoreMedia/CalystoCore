using LinqToSqlShared.DbmlObjectModel;

namespace Calysto.SqlMetal.CalystoGenerator.CalystoEFCoreFluent
{
	class ColumnData
	{
		public Column item;
		public int index;
		public string typeString;
		public string FixedMember { get { return EFUtility.GetCSharpValidName(item.Member); } }
	}
}
