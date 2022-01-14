using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Calysto.Data.Direct
{
	/// <summary>
	/// Parse interpolated SQL query text, extract parameters with values and return DbCommand with query text and parameters.
	/// interpolated sql query: (select * from Table1 where Name = {0} and Size > {1}, 'name1', 22)
	/// </summary>
	public class DbQueryBuilder
	{
		enum QueryPartKindEnum
		{
			Text,
			Select,
			Where,
			Update,
			Insert,
			Exec,
			Declare,
			From,
			Set
		}

		class QueryPart
		{
			public QueryPartKindEnum Kind;
			public string SqlText;

			public QueryPart(string kind, string sql)
			{
				this.Kind = (QueryPartKindEnum)Enum.Parse(typeof(QueryPartKindEnum), kind, true);
				this.SqlText = sql;
			}

			public QueryPart(QueryPartKindEnum kind, string sql)
			{
				this.Kind = kind;
				this.SqlText = sql;
			}
		}

		static string _reWords = "select|where|update|insert|exec|declare|from|set";
		static Regex _re1 = new Regex("^(" + _reWords + ")$" , RegexOptions.IgnoreCase);
		static Regex _re2 = new Regex("(^|[\\s]+)(" + _reWords + ")([\\s]+|$)", RegexOptions.IgnoreCase);

		private static IEnumerable<QueryPart> GetQueryParts(string command)
		{
			string[] partsArr = _re2.Split(command).Where(o=>!string.IsNullOrEmpty(o)).ToArray();
			string kind = null;
			foreach(string part in partsArr)
			{
				if (_re1.IsMatch(part))
				{
					yield return new QueryPart(QueryPartKindEnum.Text, part);
					kind = part;
				}
				else if (kind != null)
				{
					yield return new QueryPart(kind, part);
				}
				else
				{
					yield return new QueryPart(QueryPartKindEnum.Text, part);
				}
			}
		}

		const string strReCol = "(?<column>[\\w_\\.\\-\\[\\]\\`\"]+)";
		const string strReSign = "[\\s]*(?<sign>[\\=<>\\!]+)[\\s]*";
		const string strRePar = "(?<arg>\\{(?<index>[\\d]+)\\})";
		const string strReOut = "(?<out>[\\s]+OUT)*";

		public static DbCommand PrepareCommand(DbCommand cmd, string command, params object[] parameters)
		{
			if (parameters != null && parameters.Any())
			{
				// query: where Column1 = {0} and Column2 > {1}
				// query: update t1 set Column1 = {0}, Column2 = {1} where Column3 = {2} and Column4 = {3}
				// query: exec spGetData {0}, {1}, {2}
				// query: select dbo.fnGetData({0}, {1})
				// query: select * from dbo.fnGetData({0}, {1})
				// query: select * from dbo.spGetData({0}, {1} out) // <<< output parameter

				SqlIdentifier sett = SqlIdentifier.GetIdentifier(cmd.Connection);
				int uniqueNum = 0;

				var parts = GetQueryParts(command).ToList();

				foreach (QueryPart qq in parts.Where(o=>o.Kind != QueryPartKindEnum.Text))
				{
					Regex re = new Regex(
						"(?<leftCol>" + strReCol + strReSign + strRePar + ")"
						+ "|(?<rightCol>" + strRePar + strReSign + strReCol + ")"
						+ "|(?<rightPar>" + strReSign + strRePar + ")" // instead of column name, we may have another expression
						+ "|(?<leftPar>" + strRePar + strReSign + ")" // instead of column name, we may have another expression
						+ "|(?<singlePar>" + strRePar + strReOut + ")", RegexOptions.IgnoreCase); // exec spTest {0}, {1} out, insert (...) values ({0}, {1})

					// process statements with column name, eg. Column1 = {0}
					qq.SqlText = re.Replace(qq.SqlText, delegate (Match m)
					{
						int indexInString = System.Convert.ToInt32(m.Groups["index"].Value);
						string colName = sett.QuoteCompoundIdentifier(m.Groups["column"].Value);
						string sign = m.Groups["sign"].Value;

						bool isLefColumn = m.Groups["leftCol"].Success;
						bool isRighColumn = m.Groups["rightCol"].Success;

						bool isLeftParameter = m.Groups["leftPar"].Success; // no column name, parameter only
						bool isRightParameter = m.Groups["rightPar"].Success; // no column name, parameter only

						bool isSingleParameter = m.Groups["singlePar"].Success;

						bool isOutParameter = m.Groups["out"].Success;

						object par1 = parameters[indexInString];
						DbParameter sqlpar = par1 == null ? null : (par1 as DbParameter);

						if (qq.Kind == QueryPartKindEnum.Where
							&& (par1 == null
									|| par1 == DBNull.Value
									|| (sqlpar != null && (sqlpar.Value == null || sqlpar.Value == DBNull.Value))))
						{
							switch (sign)
							{
								case "=":
									return colName + " IS NULL ";
								case "!=":
								case "<>":
									return colName + " IS NOT NULL ";
								default:
									// >, <, <=, >=
									throw new Exception($"Invalid sql, parameter {indexInString} is null in {command}");
							}
						}
						else
						{
							List<string> placeholders = new List<string>();

							if (sqlpar != null)
							{
								if (string.IsNullOrWhiteSpace(sqlpar.ParameterName))
								{
									sqlpar.ParameterName = sett.CreateParamName(indexInString, uniqueNum++);
								}
								placeholders.Add(sett.UnnamedParms ? "?" : sqlpar.ParameterName);
								cmd.Parameters.Add(sqlpar);
							}
							else
							{
								if (par1 is IEnumerable && !(par1 is string))
								{
									foreach(var p1 in (IEnumerable)par1)
									{
										string name = sett.CreateParamName(indexInString, uniqueNum++);
										AddParameter(cmd, sett, name, p1, isOutParameter, placeholders);
									}
								}
								else
								{
									string name = sett.CreateParamName(indexInString, uniqueNum++);
									AddParameter(cmd, sett, name, par1, isOutParameter, placeholders);
								}
							}

							if (isLefColumn || isRightParameter)
							{
								return colName + " " + sign + " " + string.Join(",", placeholders);
							}
							else if (isRighColumn || isLeftParameter)
							{
								return string.Join(",", placeholders) + " " + sign + " " + colName;
							}
							else if (isSingleParameter)
							{
								return string.Join(",", placeholders) + (isOutParameter ? " out" : null);
							}

							throw new Exception("Invalid sql expression: " + command);
						}
					});
				}

				cmd.CommandText = string.Join("", parts.Select(o => o.SqlText));
			}
			else
			{
				cmd.CommandText = command;
			}

			return cmd;
		}

		private static void AddParameter(DbCommand cmd, SqlIdentifier sett, string name, object par1, bool isOutParameter, List<string> placeholders)
		{
			DbParameter par2 = cmd.CreateParameter();
			placeholders.Add(sett.UnnamedParms ? "?" : name);
			par2.ParameterName = name;
			par2.Value = par1 ?? System.DBNull.Value;
			if(isOutParameter)
				par2.Direction = System.Data.ParameterDirection.InputOutput;

			cmd.Parameters.Add(par2);
		}
	}
}