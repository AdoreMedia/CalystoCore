using Calysto.Common;
using Calysto.Data.Direct;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;

namespace Calysto.EntityFrameworkCore
{
	/// <summary>
	/// EntityFramework data context extensions
	/// </summary>
	public static class DbContextExtensions1
	{
		public class TranState<TContext> where TContext : DbContext
		{
			/// <summary>
			/// if manualy set to true, will always rollback the transaction
			/// </summary>
			public bool RollbackTransaction { get; set; }

			public TContext Context { get; set; }

			/// <summary>
			/// Invoke select 1 from [table_name] with (TABLOCKX) where 1=2. <br/>
			/// Creates exclusive lock on table allowing operations from current transaction only. <br/>
			/// All other read/write operations will wait until current transaction is completed. <br/>
			/// Lock is released when transaction ends. <br/>
			/// Database isolation has to be READ COMMITED (default), to check, execute DBCC useroptions. <br/>
			/// Set READ COMMITED isolation level: ALTER DATABASE [db-name] SET READ_COMMITTED_SNAPSHOT OFF <br/>
			/// </summary>
			/// <typeparam name="TEntity"></typeparam>
			/// <param name="tableSelector"></param>
			public void LockTableExclusive<TEntity>(Func<TContext, DbSet<TEntity>> tableSelector) where TEntity : class
			{
				var res = tableSelector.Invoke(this.Context);
				var type = res.AsQueryable().ElementType;
				var ett = this.Context.Model.FindEntityType(type);
				
				string sql = $"declare @dumy{new CalystoRandom().Next(10000, 100000)} int = (select 1 from {ett.GetTableName()} with (TABLOCKX) where 1=2);";
				this.Context.ExecuteCommand(sql);
			}

			/// <summary>
			/// Lock using sp_getapplock inside of transaction.  <br/>
			/// Lock is released when transaction ends. <br/>
			/// Uses resourceName as object to lock on, like C# lock(resourceName){...} <br/>
			/// After lock applied, access to the same resourceName lock is synchronous. <br/>
			/// Works with any isolation level. <br/>
			/// </summary>
			/// <param name="resourceName"></param>
			public void LockResourceExclusive(string resourceName)
			{
				if (string.IsNullOrWhiteSpace(resourceName))
					throw new ArgumentNullException(nameof(resourceName));

				string sql = $"exec sp_getapplock '{resourceName}', 'Exclusive', 'Transaction';";
				// does not require exec sp_releaseapplock '{resourceName}', 'Transaction' since lock is released when transaction ends.
				this.Context.ExecuteCommand(sql);
			}
		}

		/// <summary>
		/// Handle transaction inside try-catch, and commit at the end. Throw exception if fails.
		/// </summary>
		/// <param name="context"></param>
		/// <param name="func"></param>
		public static TResult UsingTransaction<TContext, TResult>(
			this TContext context,
			Func<TranState<TContext>, TResult> func,
			IsolationLevel isolation = IsolationLevel.Unspecified) where TContext:DbContext
		{
			if (context.Database.CurrentTransaction != null)
			{
				throw new Exception("Transaction is already opened, can not use nested transactions");
			}

			try
			{
				// if isolation == Unspecified, will use database default (execute sql to check: DBCC useroptions)
				context.Database.BeginTransaction(isolation);
				
				var state = new TranState<TContext>() { Context = context };
				TResult res = func.Invoke(state);
				if (state.RollbackTransaction)
				{
					context.Database.CurrentTransaction?.Rollback();
				}
				else
				{
					context.Database.CurrentTransaction?.Commit();
				}
				return res;
			}
			catch
			{
				context.Database.CurrentTransaction?.Rollback();
				throw;
			}
		}

		/// <summary>
		/// Handle transaction inside try-catch, and commit at the end. Throw exception if fails.
		/// </summary>
		/// <param name="context"></param>
		/// <param name="action"></param>
		public static void UsingTransaction<TContext>(
			this TContext context,
			Action<TranState<TContext>> action,
			IsolationLevel isolation = IsolationLevel.Unspecified) where TContext : DbContext
		{
			context.UsingTransaction(state =>
			{
				action.Invoke(state);
				return true;
			}, isolation);
		}

		public class ConnState<TContext> where TContext:DbContext
		{
			public TContext Context { get; set; }

			public DbConnection Connection { get; set; }
		}

		/// <summary>
		/// Open connection if was closed, execute action inside try-catch, close connection if was closed before.
		/// </summary>
		/// <param name="context"></param>
		/// <param name="func"></param>
		public static TResult UsingConnection<TContext, TResult>(
			this TContext context,
			Func<ConnState<TContext>, TResult> func) where TContext: DbContext
		{
			bool closeConnection = false;
			try
			{
				if (context.Database.GetDbConnection().State != ConnectionState.Open)
				{
					closeConnection = true;
					context.Database.GetDbConnection().Open();
				}

				var ss = new ConnState<TContext>() { Context = context, Connection = context.Database.GetDbConnection() };

				TResult res =func.Invoke(ss);

				if (closeConnection)
				{
					context.Database.GetDbConnection().Close();
				}

				return res;
			}
			catch
			{
				if (closeConnection)
				{
					context.Database.GetDbConnection().Close();
				}

				throw;
			}
		}

		/// <summary>
		/// Open connection if was closed, execute action inside try-catch, close connection if was closed before.
		/// </summary>
		/// <param name="context"></param>
		/// <param name="action"></param>
		public static void UsingConnection<TContext>(
			this TContext context,
			Action<ConnState<TContext>> action) where TContext : DbContext
		{
			context.UsingConnection(state =>
			{
				action.Invoke(state);
				return true;
			});
		}

	}
}
