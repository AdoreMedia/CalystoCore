using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Data.Common;
using Calysto.Data.Direct;
using Calysto.Genesis.UnitTests.Database;
using System.Data.SqlClient;
using Calysto.Genesis.Tests.Database;
using Microsoft.Data.Sqlite;

namespace Calysto.Data.Direct.Tests
{
	[TestClass()]
	public class DbDirectContextSQLiteTests
	{
		public virtual DbConnection DbConn => new SqliteConnection(DatabaseConstants.SQLiteConnectionString);

		[TestMethod()]
		public void PrepareCommand1Test()
		{
			DbCommand cmd = this.DbConn.CreateCommand();

			DbQueryBuilder.PrepareCommand(
				cmd,
				@"select * from Table1 where [Table1.Col1] = {0} and {1} = `Table1.Col3` or {2} <= Col5 limit 2 offset 0", // limit -1 for unulimited
				null,
				null,
				53
			);

			Assert.AreEqual("select * from Table1 where \"Table1\".\"Col1\" IS NULL  and \"Table1\".\"Col3\" IS NULL  or @p2_0 <= \"Col5\" limit 2 offset 0", cmd.CommandText);
			Assert.AreEqual(1, cmd.Parameters.Count);
		}

		[TestMethod()]
		public void ExecuteMultipleResultsTest1()
		{
			DbDirectContext cx = new DbDirectContext(this.DbConn);

			string sql = $@"select * from {nameof(tblAppMember)} limit 2;
select * from {nameof(tblAppPermission)} limit 1;
select count(1) from {nameof(tblAppMember)}";

			var result = cx.ExecuteMultipleResults(sql)
			.ReadResults(mm => new
			{
				Members = mm.GetSequence<tblAppMember>().ToList(),
				Permisssions = mm.GetSequence<tblAppPermission>().ToList(),
				Count = mm.GetSequence<int>().First()
			});

			Assert.AreEqual(2, result.Members.Count);
			Assert.AreEqual(1, result.Permisssions.Count);
			Assert.AreEqual(8, result.Count);
		}

		[TestMethod()]
		public void ExecuteDataSetTest1()
		{
			DbDirectContext cx = new DbDirectContext(this.DbConn);

			string sql = $@"select * from {nameof(tblAppMember)} limit 2;
select * from {nameof(tblAppPermission)} limit 1;
select count(1) from {nameof(tblAppMember)}";

			var dset = cx.ExecuteDataSet(sql);
			Assert.AreEqual(3, dset.Tables.Count);
			Assert.AreEqual(2, dset.Tables[0].Rows.Count);
			Assert.AreEqual(1, dset.Tables[1].Rows.Count);
			Assert.AreEqual(1, dset.Tables[2].Rows.Count);
			Assert.AreEqual(8, (long)dset.Tables[2].Rows[0][0]);
		}

		[TestMethod()]
		public void ExecuteListTest1()
		{
			DbDirectContext cx = new DbDirectContext(this.DbConn);

			string sql = $@"select * from {nameof(tblAppMember)} limit 2;
select * from {nameof(tblAppPermission)} limit 1;
select count(1) from {nameof(tblAppMember)}";

			var items2 = cx.ExecuteList<tblAppMember>(sql);
			Assert.AreEqual(2, items2.Count);
		}

		/// <summary>
		/// Use tblAppMember2 for bulk insert, there is no PK and no autoincrement column.
		/// </summary>
		[TestMethod()]
		public void BulkInsertTest1()
		{
			DbDirectContext cx = new DbDirectContext(this.DbConn);

			var items = cx.ExecuteList<tblAppMember2>($"select * from {nameof(tblAppMember2)} limit 10");
			int cnt1 = cx.ExecuteList<int>($"select count(1) from {nameof(tblAppMember2)}").First();
			int cnt2 = 0;
			//bool isCatch = false;

			cx.UsingTransaction(state =>
			{
				state.RollbackTransaction = true; // obavezno rollback da ne ostane insertirano u bazi

				cx.ExecuteBulkInsert(nameof(tblAppMember2), items);
				cnt2 = cx.ExecuteList<int>($"select count(1) from {nameof(tblAppMember2)}").First();
				cx.ExecuteBulkInsert(nameof(tblAppMember2), items);

				//try
				//{
				//	cx.ExecuteBulkInsert(nameof(tblAppMember2), items, true); // mora baciti ex jer ne moze insertirati duple ID-ove
				//}
				//catch
				//{
				//	isCatch = true;
				//}
			});

			int cnt3 = cx.ExecuteList<int>($"select count(1) from {nameof(tblAppMember2)}").First();

			Assert.AreEqual(8, cnt1);
			Assert.AreEqual(16, cnt2); // biti ce 16 jer u tablici imamo 8 redova
			//Assert.AreEqual(true, isCatch);
			Assert.AreEqual(8, cnt3);
		}

	}
}