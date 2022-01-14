using Calysto.Data;
using Calysto.Data.Direct;
using Calysto.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace Calysto.EntityFrameworkCore
{
	public static class QueryableExtensions1
	{
		public static RawSqlQuery ToRawSqlQuery<TEntity>(this IQueryable<TEntity> query)
		{
			// EF 5:

			// official MS method: ToQueryString() to return sql query text with parameters defined at top
			//var enumerator = query.Provider.Execute<IEnumerable<TEntity>>(query.Expression) as IQueryingEnumerable;
			//string str1 = enumerator.ToQueryString();

			// we need sql text and parameters 
#pragma warning disable EF1001 // Internal EF Core API usage.
			IRelationalQueryingEnumerable enumerator = query.Provider.Execute<IEnumerable<TEntity>>(query.Expression) as IRelationalQueryingEnumerable;
			var cmd1 = enumerator.CreateDbCommand();
#pragma warning restore EF1001 // Internal EF Core API usage.
			return new RawSqlQuery()
			{
				CommandText = cmd1.CommandText,
				Parameters = cmd1.Parameters.Cast<DbParameter>().Select(kv => new RawSqlParameter()
				{
					ParamName = kv.ParameterName,
					Value = kv.Value
				}).ToList()
			};
		}

		private static DbContext GetDbContext<TEntity>(IQueryable<TEntity> query)
		{
			// db.tblAppMember.GetDbContext();
			if (CalystoDataBinder.Private.TryGetValue<DbContext>(query, "_context", out var context1))
			{
				return context1;
			}

			// db.tblAppMember.Where(...).GetDbContext()
			if (CalystoDataBinder.Private.TryGetValue<DbContext>(query, "_queryProvider._queryCompiler._database.RelationalDependencies.Connection.Context", out var context2))
			{
				return context2;
			}

			// db.tblAppMember.Include(...).GetDbContext()
			// db.tblAppMember.Include(...).ThenInclude().GetDbContext()
			if (CalystoDataBinder.Private.TryGetValue<DbContext>(query, "_queryable._queryProvider._queryCompiler._database.RelationalDependencies.Connection.Context", out var context3))
			{
				return context3;
			}

			throw new NotSupportedException(nameof(GetDbContext));
		}

		class QuerySplitResult
		{
			public readonly List<string> SelectParts = new List<string>();
			public string GetSelectSql(bool includeSelectWord) => this.SelectParts.Any() ? ((includeSelectWord ? "select " : "") + this.SelectParts.ToStringJoined().Trim()) : "";

			public readonly List<string> FromParts = new List<string>();
			public string GetFromString(bool includeFromWord) => this.FromParts.Any() ? ((includeFromWord ? "from " : "") + this.FromParts.ToStringJoined().Trim()) : "";

			public readonly List<string> WhereParts = new List<string>();
			public string GetWhereString(bool includeWhereWord) => this.WhereParts.Any() ? ((includeWhereWord ? "where " : "") + this.WhereParts.ToStringJoined().Trim()) : "";

			public bool HasFrom;
			public string FromAlias;
			public bool HasAlias;
		}

		enum QueryKind
		{
			Select,
			Where,
			From
		}

		static Regex _re1 = new Regex("(\\(|\\)|select|where|from)", RegexOptions.IgnoreCase);

		private static QuerySplitResult SplitQuery(string sqlText)
		{
			List<string> list = null;
			int level = 0;
			QuerySplitResult result = new QuerySplitResult();
			string[] parts1 = _re1.Split(sqlText);

			foreach(string part in parts1)
			{
				if(level > 0)
				{
					list.Add(part);
				}
				else if (part == ")")
				{
					level--;
					list.Add(part);
				}
				else if (part == "(")
				{
					level++;
					list.Add(part);
				}
				else if(part.Equals("select", StringComparison.OrdinalIgnoreCase))
				{
					list = result.SelectParts;
				}
				else if (part.Equals("where", StringComparison.OrdinalIgnoreCase))
				{
					list = result.WhereParts;
				}
				else if (part.Equals("from", StringComparison.OrdinalIgnoreCase))
				{
					list = result.FromParts;
				}
				else if(list != null)
				{
					list.Add(part);
				}
			}

			string fromStr = result.GetFromString(false);
			if(!string.IsNullOrEmpty(fromStr))
			{
				result.HasFrom = true;

				Match mAlias = Regex.Match(fromStr, "[\\s]+AS[\\s]+(?<alias>[^\\s]+)", RegexOptions.IgnoreCase);

				if (mAlias.Groups["alias"].Success)
				{
					result.FromAlias = mAlias.Groups["alias"].Value;
					result.HasAlias = true;
				}
			}
			return result;
		}

		public static RawSqlQuery CreateDeleteDirect<TSource>(IQueryable<TSource> source)
		{
			/* SQL server:
				delete t1 from (
					select * from tblAppMember m1 where m1.AppMemberID < -1
				) as t1

				-- can handle joined tables
				delete t1
				from tblAppMember t1
				inner join tblAppMemberPermissoin p1 on p1.AppMemberID = t1.AppMemberID
				where p1.AppMemberID < -1
			*/

			/* SQLite:
			 * * simple query only without joining tables
				delete from tblAppMember AS m1 where m1.AppMemberID < -1
			*/

			/* MySQL:
			 * * simple query only without joining tables
				delete m1 from tblAppMember AS m1 where m1.AppMemberID < -1

			** compound query with joined tables:
				delete t1
				from tblappmember as t1 
				inner join tblAppMemberPermission p1 on p1.AppMemberID = t1.AppMemberID
				where p1.AppMemberID < -1
			*/

			var context2 = GetDbContext(source);
			SqlIdentifier ident = SqlIdentifier.GetIdentifier(context2.Database.GetDbConnection());

			RawSqlQuery sqlQuery = source.ToRawSqlQuery();
			var res1 = sqlQuery.ToInterpolatedSqlQuery();

			var split1 = SplitQuery(res1.CommandText);
			string sql1 = null;

			if (ident.IsSqlServer || ident.IsMySql)
			{
				sql1 = "delete " + split1.FromAlias + "\r\n" + split1.GetFromString(true) + "\r\n" + split1.GetWhereString(true);
			}
			else
			{
				sql1 = "delete " + "\r\n" + split1.GetFromString(true) + "\r\n" + split1.GetWhereString(true);
			}

			return new RawSqlQuery()
			{
				Context = context2,
				CommandText = sql1,
				Parameters = sqlQuery.Parameters
			};
		}

		public static int DeleteDirect<TSource>(this IQueryable<TSource> source)
		{
			var res1 = CreateDeleteDirect(source).ToInterpolatedSqlQuery();
			return res1.Context.ExecuteCommand(res1.CommandText, res1.Values);
		}

		private static void ReplaceNullParameters(ref string sql, ref List<RawSqlParameter> rawSqlParameters)
		{
			foreach (var par in rawSqlParameters.ToList().OrderByDescending(o => o.ParamName.Length))
			{
				if (par.Value == null || par.Value == DBNull.Value)
				{
					rawSqlParameters.Remove(par);
					sql = sql.Replace(par.ParamName, "NULL");
				}
			}
		}

		public static RawSqlQuery CreateUpdateDirect<TSource>(IQueryable<TSource> source, Expression<Func<TSource>> updateExpression)
		{
			/* SQL server:
				update t1 set
				t1.Address = 'some address'
				from (
					select * from tblAppMember m1 where m1.AppMemberID < -1
				) as t1

				-- can handle joined tables
				update t1 
				set t1.Address = 'address'
				from tblAppMember t1
				inner join tblAppMemberPermissoin p1 on p1.AppMemberID = t1.AppMemberID
				where p1.AppMemberID < -1
			*/

			/* SQLite & MySQL
			 * simple query only without joining tables
				update tblAppMember as t
				set MSISDN = 'fsadgs'
				WHERE ((t.AppMemberID < -1))
			*/

			/* MySQL only:
				update tblappmember as t1
				inner join tblAppMemberPermission p1 on p1.AppMemberID = t1.AppMemberID
				set t1.Address = 'address'
				where p1.AppMemberID < -1
			*/

			var context2 = GetDbContext(source);
			SqlIdentifier ident = SqlIdentifier.GetIdentifier(context2.Database.GetDbConnection());

			var memberInitExpression = updateExpression.Body as MemberInitExpression;

			var update1 = memberInitExpression.Bindings.Select((MemberBinding binding, int index) =>
			{
				var memberAssignment = binding as MemberAssignment;
				string propertyName = memberAssignment.Member.Name;
				Expression memberExpression = memberAssignment.Expression;
				LambdaExpression lambda = Expression.Lambda(memberExpression, null);
				var value = lambda.Compile().DynamicInvoke();

				return new { PropertyName = propertyName, Value = value, ParamName = ident.ParameterPrefix + "p_upd1634_" + index + "_" + propertyName };
			}).ToList();

			var updateValues = update1.Select(o => new RawSqlParameter { ParamName = o.ParamName, Value = o.Value }).ToList();
			string sqlUpdateQuery = null;
			RawSqlQuery sqlQuery = source.ToRawSqlQuery();

			var split1 = SplitQuery(sqlQuery.CommandText);

			if (ident.IsSqlServer)
			{
				string sqlUpdate = string.Join(", ", update1.Select(o => ident.QuoteCompoundIdentifier(split1.FromAlias + "." + o.PropertyName) + " = " + o.ParamName));
				ReplaceNullParameters(ref sqlUpdate, ref updateValues);
				sqlUpdateQuery = "update " + split1.FromAlias + "\r\n" + "set " + sqlUpdate + "\r\n" + split1.GetFromString(true) + "\r\n" + split1.GetWhereString(true);
			}
			else if (ident.IsSqlite)
			{
				string sqlUpdate = string.Join(", ", update1.Select(o => ident.QuoteCompoundIdentifier(o.PropertyName) + " = " + o.ParamName));
				ReplaceNullParameters(ref sqlUpdate, ref updateValues);
				sqlUpdateQuery = "update " + split1.GetFromString(false) + "\r\n" + "set " + sqlUpdate + "\r\n" + split1.GetWhereString(true);
			}
			else if (ident.IsMySql)
			{
				string sqlUpdate = string.Join(", ", update1.Select(o => ident.QuoteCompoundIdentifier(split1.FromAlias + "." + o.PropertyName) + " = " + o.ParamName));
				ReplaceNullParameters(ref sqlUpdate, ref updateValues);
				sqlUpdateQuery = "update " + split1.GetFromString(false) + "\r\n" + "set " + sqlUpdate + "\r\n" + split1.GetWhereString(true);
			}

			return new RawSqlQuery()
			{
				Context = context2,
				CommandText = sqlUpdateQuery,
				Parameters = updateValues.Concat(sqlQuery.Parameters).ToList()
			};
		}

		public static int UpdateDirect<TSource>(this IQueryable<TSource> source, Expression<Func<TSource>> updateExpression)
		{
			var res1 = CreateUpdateDirect(source, updateExpression).ToInterpolatedSqlQuery();
			return res1.Context.ExecuteCommand(res1.CommandText, res1.Values);
		}

		/// <summary>
		/// Bulk insert items collection
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="source"></param>
		/// <param name="items"></param>
		/// <param name="identityInsert"></param>
		public static void BulkInsert<TEntity>(this DbSet<TEntity> source, IEnumerable<TEntity> items, bool identityInsert = false, int batchSize = 10000) where TEntity : class
		{
			GetDbContext(source).ExecuteBulkInsert(items, identityInsert, batchSize);
		}


		private static IEnumerable<string> GetNavigationPaths(this DbContext db,
			HashSet<string>parentPath,
			Type clrType,
			int levelsLeft,
			bool single,
			bool many)
		{
			if (levelsLeft < 1)
				yield break;

			levelsLeft--;

			// navi properties kinds:
			// 1. tblAuthor
			// 2. List<tblAuthor>
			Type listArgument = clrType.GetGenericArguments().FirstOrDefault();
			
			if (!many && listArgument != null)
				yield break;

			var entityType = db.Model.GetEntityTypes(listArgument ?? clrType).Single();

			foreach (var navi in entityType.GetNavigations())
			{
				// navi.Name is db table name
				
				// if name is repeating, don't include property: tblVehicle.tblDetail.tblVehicle
				if (string.IsNullOrEmpty(navi.Name) || parentPath.Contains(navi.Name))
					continue;

				Type listArg2 = navi.ClrType.GetGenericArguments().FirstOrDefault();
				if (!many && listArg2 != null)
					continue;

				// create copy of parent paths
				HashSet<string> paths2 = new HashSet<string>(parentPath);
				paths2.Add(navi.Name);

				yield return string.Join(".", paths2);

				if (levelsLeft > 0)
				{
					// get children
					foreach (var descendantPath in db.GetNavigationPaths(paths2, listArg2 ?? navi.PropertyInfo.PropertyType, levelsLeft, single, many))
					{
						yield return descendantPath;
					}
				}
			}
		}
		/// <summary>
		/// Include all child navigation properties in query results.
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="source"></param>
		/// <param name="subLevels">1: first level children, 2: first and second level children, etc.</param>
		/// <param name="includeOne"></param>
		/// <param name="includeMany"></param>
		/// <returns></returns>
		public static IQueryable<TEntity> IncludeDescendants<TEntity>(this IQueryable<TEntity> source,
			int subLevels = 1,
			bool includeOne = true,
			bool includeMany = false) where TEntity : class
		{
			var db = GetDbContext(source);
			var paths1 = db.GetNavigationPaths(new HashSet<string>(), typeof(TEntity), subLevels, includeOne, includeMany).ToList();

			foreach(string path1 in paths1)
			{
				source = source.Include(path1);
			}

			return source;
		}

		/// <summary>
		/// Include all child navigation properties in query results.
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <typeparam name="TProperty"></typeparam>
		/// <param name="source"></param>
		/// <param name="startProperty"></param>
		/// <param name="subLevels"></param>
		/// <param name="includeOne"></param>
		/// <param name="includeMany"></param>
		/// <returns></returns>
		public static IQueryable<TEntity> IncludeDescendants<TEntity, TProperty>(this IQueryable<TEntity> source,
			Expression<Func<TEntity, TProperty>> startProperty,
			int subLevels = 1,
			bool includeOne = true,
			bool includeMany = false) where TEntity : class
		{
			string startPath = startProperty.ToString().Trim();
			// o => o.tblVehicle.tblDetail
			int index = startPath.IndexOf('.');
			HashSet<string> basePath;
			if (index > 0)
				basePath = new HashSet<string>(startPath.Substring(index + 1).Split('.'));
			else
				basePath = new HashSet<string>();

			var db = GetDbContext(source);
			var paths1 = db.GetNavigationPaths(basePath, typeof(TProperty), subLevels, includeOne, includeMany).ToList();

			foreach (string path1 in paths1)
			{
				source = source.Include(path1);
			}

			return source;
		}

	}

}