using LinqToSqlShared.DbmlObjectModel;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using static SqlMetal.SqlMetalMain;

namespace SqlMetal
{
	public class DatabaseItem
	{
		public string Schema { get; internal set; }
		public string FullName { get; internal set; }
		public DbObjectKind Kind { get; internal set; }
	}

	public class DatabaseResult
	{
		public List<DatabaseItem> Tables { get; internal set; }
		public List<DatabaseItem> Functions { get; internal set; }
		public string OutputContent { get; internal set; }
		public List<LogItem> LogItems { get; internal set; }

	}
}
