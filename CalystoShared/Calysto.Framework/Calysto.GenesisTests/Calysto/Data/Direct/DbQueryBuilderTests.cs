using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using System.Linq;

namespace Calysto.Data.Direct.Tests
{
	[TestClass()]
	public class DbQueryBuilderTests
	{
		[TestMethod()]
		public void PrepareCommandTest1()
		{
			var cmd1 = DbQueryBuilder.PrepareCommand(new SqlCommand() { Connection = new SqlConnection() },
				@"update t1 set t1.BirthDate = {0}, t1.Naziv = {4}
from (
	select * from Table1 
	where AppMemberID > {1} and LastLoginDate < {2} and Nesto = {3} and {3} = Col1 and Col2 in ({5}) and Col3 = {6}
) as t1;
exec spTestStore {0}, {4}, {2};
select * from dbo.fnTestFunct({4}, {2});
insert into Table1 (Column1, Column2, Column3) values ({2}, {4}, {1})",
				7432,
				2142,
				1234,
				null,
				null,
				new[] { 2, 3, 72 }.ToList(),
				"testword");

			string expected1 = @"update t1 set [t1].[BirthDate] = @p0_0, [t1].[Naziv] = @p4_1
from (
	select * from Table1 
	where [AppMemberID] > @p1_2 and [LastLoginDate] < @p2_3 and [Nesto] IS NULL  and [Col1] IS NULL  and Col2 in (@p5_4,@p5_5,@p5_6) and [Col3] = @p6_7
) as t1;
exec spTestStore @p0_8, @p4_9, @p2_10;
select * from dbo.fnTestFunct(@p4_11, @p2_12);
insert into Table1 (Column1, Column2, Column3) values (@p2_13, @p4_14, @p1_15)";

			Assert.AreEqual(expected1, cmd1.CommandText);
			Assert.AreEqual(16, cmd1.Parameters.Count);

			string params2 = string.Join("; ", cmd1.Parameters.Cast<SqlParameter>().Select(o => o.ParameterName + ": " + o.Value));
			string expected2 = "@p0_0: 7432; @p4_1: ; @p1_2: 2142; @p2_3: 1234; @p5_4: 2; @p5_5: 3; @p5_6: 72; @p6_7: testword; @p0_8: 7432; @p4_9: ; @p2_10: 1234; @p4_11: ; @p2_12: 1234; @p2_13: 1234; @p4_14: ; @p1_15: 2142";

			Assert.AreEqual(expected2, params2);

		}
	}
}