using Calysto.Data.Direct;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;

namespace Calysto.EntityFrameworkCore
{
	/// <summary>
	/// EntityFramework data context extensions
	/// </summary>
	public static class DbContextExtensions2
	{
		private static DbDirectContext CreateDbDirectContext(this DbContext context)
		{
			var db = new DbDirectContext(context.Database.GetDbConnection());
			db.CurrentTransaction = context.Database.CurrentTransaction?.GetDbTransaction();
			db.CommandTimeout = context.Database.GetCommandTimeout();
			return db;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="context"></param>
		/// <param name="command"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		public static int ExecuteCommand(this DbContext context, string command, params object[] parameters)
		{
			// don't use context.Database.ExecuteSqlRaw(...), it creates decimal(x,2) always, rounding decimal parameters to 2 decimals

			return context.CreateDbDirectContext().ExecuteCommand(command, parameters);
		}

		/// <summary>
		/// Load data from database into data set.
		/// </summary>
		/// <param name="context"></param>
		/// <param name="command"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		public static DataSet ExecuteDataSet(this DbContext context, string command, params object[] parameters)
		{
			return context.CreateDbDirectContext().ExecuteDataSet(command, parameters);
		}

		/// <summary>
		/// Create reder to read results from database on demand, without any buffering. 
		/// .ReadResults(...) has to be invoked to read data from database.
		/// Closes reader at the end.
		/// </summary>
		/// <param name="context"></param>
		/// <param name="command"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		public static MultipleResultsReader ExecuteMultipleResults(this DbContext context, string command, params object[] parameters)
		{
			return context.CreateDbDirectContext().ExecuteMultipleResults(command, parameters);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="context"></param>
		/// <param name="command"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		public static List<TResult> ExecuteList<TResult>(this DbContext context, string command, params object[] parameters)
		{
			return context.CreateDbDirectContext().ExecuteList<TResult>(command, parameters);
		}

		/// <summary>
		/// Bulk insert items collection
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="source"></param>
		/// <param name="items"></param>
		/// <param name="identityInsert"></param>
		public static void ExecuteBulkInsert<TEntity>(this DbContext context, IEnumerable<TEntity> items, bool identityInsert = false, int batchSize = 10000) where TEntity : class
		{
			context.CreateDbDirectContext().ExecuteBulkInsert(typeof(TEntity).Name, items, identityInsert, batchSize);
		}

	}
}
