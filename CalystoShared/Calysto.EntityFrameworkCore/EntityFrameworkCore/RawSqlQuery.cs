using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Calysto.EntityFrameworkCore
{
	public class RawSqlQuery
	{
		internal DbContext Context { get; set; }
		public string CommandText { get; set; }
		public List<RawSqlParameter> Parameters { get; set; }

		/// <summary>
		/// Replace @par in query with {index} placehodlers.
		/// </summary>
		/// <param name="sqlQuery"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		public InterpolatedSqlQuery ToInterpolatedSqlQuery()
		{
			List<object> values = new List<object>();
			int index = -1;
			string name1 = null;
			string sqlText = this.CommandText;

			foreach (var par in this.Parameters.OrderByDescending(o => o.ParamName.Length))
			{
				values.Add(par.Value);
				index++;
				name1 = "{" + index + "}";
				sqlText = sqlText.Replace(par.ParamName, name1);
			}

			return new InterpolatedSqlQuery()
			{
				Context = this.Context,
				CommandText = sqlText,
				Values = values.ToArray()
			};
		}
	}

}