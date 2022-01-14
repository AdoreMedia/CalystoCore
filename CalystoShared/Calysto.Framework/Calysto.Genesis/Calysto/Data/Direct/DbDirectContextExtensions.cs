using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace Calysto.Data.Direct
{
	public static class DbDirectContextExtensions
	{
		public class TranState
		{
			/// <summary>
			/// if manualy set to true, will always rollback the transaction
			/// </summary>
			public bool RollbackTransaction { get; set; }

			public DbDirectContext Context { get; set; }
		}

		/// <summary>
		/// Handle transaction inside try-catch, and commit at the end. Throw exception if fails.
		/// </summary>
		/// <param name="context"></param>
		/// <param name="action"></param>
		public static TResult UsingTransaction<TResult>(this DbDirectContext context, Func<TranState, TResult> action)
		{
			if (context.CurrentTransaction != null)
			{
				throw new Exception("Transaction is already opened, can not use nested transactions");
			}

			bool doCloseConnection = false;

			try
			{
				if (context.Connection.State != ConnectionState.Open)
				{
					doCloseConnection = true;
					context.Connection.Open();
				}

				context.CurrentTransaction = context.Connection.BeginTransaction();

				TranState state = new TranState() { Context = context };
				TResult res1 = action.Invoke(state);

				if (state.RollbackTransaction)
				{
					context.CurrentTransaction?.Rollback();
					context.CurrentTransaction = null;
				}
				else
				{
					context.CurrentTransaction?.Commit();
					context.CurrentTransaction = null;
				}

				if (doCloseConnection)
				{
					context.Connection?.Close();
				}

				return res1;
			}
			catch
			{
				context.CurrentTransaction?.Rollback();
				context.CurrentTransaction = null;

				if (doCloseConnection)
				{
					context.Connection?.Close();
				}

				throw;
			}
		}

		public static void UsingTransaction(this DbDirectContext context, Action<TranState> action)
		{
			context.UsingTransaction(state =>
			{
				action.Invoke(state);
				return true;
			});
		}

		public class ConnState
		{
			public DbDirectContext Context { get; set; }

			public DbConnection Connection { get; set; }
		}

		/// <summary>
		/// Open connection if was closed, execute action inside try-catch, close connection if was closed before.
		/// </summary>
		/// <param name="context"></param>
		/// <param name="action"></param>
		public static TResult UsingConnection<TResult>(this DbDirectContext context, Func<ConnState, TResult> action)
		{
			bool closeConnection = false;
			try
			{
				if (context.Connection.State != ConnectionState.Open)
				{
					closeConnection = true;
					context.Connection.Open();
				}

				ConnState ss = new ConnState() { Context = context, Connection = context.Connection };

				TResult res1 = action.Invoke(ss);

				if (closeConnection)
				{
					context.Connection?.Close();
				}

				return res1;
			}
			catch
			{
				if (closeConnection)
				{
					context.Connection.Close();
				}

				throw;
			}
		}

		public static void UsingConnection(this DbDirectContext context, Action<ConnState> action)
		{
			context.UsingConnection(state =>
			{
				action.Invoke(state);
				return true;
			});
		}
	}
}