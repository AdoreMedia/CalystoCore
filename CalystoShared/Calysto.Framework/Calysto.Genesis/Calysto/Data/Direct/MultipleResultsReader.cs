using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Web;

namespace Calysto.Data.Direct
{
	public class MultipleResultsReader
	{
		DbDirectContext _context;
		Func<DbCommand> _fnPrepare;

		public MultipleResultsReader(DbDirectContext context, Func<DbCommand> fnPrepareCommand)
		{
			this._context = context;
			this._fnPrepare = fnPrepareCommand;
		}

		private string DumpCommand(DbCommand cmd)
		{
			StringBuilder sb = new StringBuilder();
			cmd?.Parameters.Cast<DbParameter>().ToList().ForEach(o =>
			{
				sb.AppendLine("declare " + o.ParameterName + " = " + (o.Value ?? System.DBNull.Value) + ";");
			});

			sb.AppendLine();
			sb.AppendLine(cmd == null ? "DbCommand is null" : cmd.CommandText);
			return sb.ToString();
		}

		/// <summary>
		/// Created command
		/// </summary>
		public DbCommand Command { get; private set; }

		/// <summary>
		/// Open reader, read data and materialize inside fnMaterialize, close reader, assign this.Command with parameters for output parameters reading.
		/// </summary>
		/// <param name="fnMaterialize"></param>
		public TResult ReadResults<TResult>(Func<SingleResultReader, TResult> fnMaterialize)
		{
			TResult res1 = default(TResult);

			this._context.UsingConnection(state =>
			{
				DbDataReader reader = null;
				DbCommand cmd1 = null;
				try
				{
					this.Command = cmd1 = this._fnPrepare();
					reader = cmd1.ExecuteReader();
					var mres = new SingleResultReader(reader);
					res1 = fnMaterialize.Invoke(mres);
					reader.Close();
				}
				catch (Exception ex)
				{
					reader?.Close();
					throw new Exception(DumpCommand(cmd1), ex);
				}
			});

			return res1;
		}

	}


}