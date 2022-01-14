using Microsoft.EntityFrameworkCore;

namespace Calysto.EntityFrameworkCore
{
	public class InterpolatedSqlQuery
	{
		internal DbContext Context { get; set; }
		public string CommandText { get; set; }
		public object[] Values { get; set; }
	}

}