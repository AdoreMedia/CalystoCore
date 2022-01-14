using System;
using System.Collections.Generic;
using System.Text;

namespace LinqToSqlShared.DbmlObjectModel
{
	class SchemaObject
	{
		/// <summary>
		/// Database name
		/// </summary>
		public string Database { get; set; }

		/// <summary>
		/// Schema
		/// </summary>
		public string Schema { get; set; }

		/// <summary>
		/// Name in database
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Schema.Name in database
		/// </summary>
		public string FullName { get; set; }
	}
}
