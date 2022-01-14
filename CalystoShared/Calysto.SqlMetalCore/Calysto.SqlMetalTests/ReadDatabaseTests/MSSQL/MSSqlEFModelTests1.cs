using CalystoUnittestNamespace3;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Calysto.EntityFrameworkCore;
using System;
using System.IO;
using System.Data;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Calysto.UnitTesting;

namespace SqlMetal.Tests.ReadDatabaseTests
{
	[TestClass]
	public class MSSqlEFModelTests1
	{
		private const string _root1 = "ReadDatabaseTests\\MSSQL\\TestFiles";

		public static string RootPath = new TestFilesProvider2(_root1).CreateAbsolutePath("");

		/// <summary>
		/// Use dbCalystoUnittestDataContext from file CalystoDbmlEFCoreTest2.cs which is generated from database.
		/// Model generated from dbml doesn't have correct MultipleResults types.
		/// All other genereated cs files must have properties BuildAction: None
		/// </summary>
		public class MyContext : dbCalystoUnittestDataContext3
		{
			public MyContext()
				: base(new DbContextOptionsBuilder<dbCalystoUnittestDataContext3>()
					  .UseSqlServer(DatabaseConnectionsSettings.SqlCalystoUnittestConnectionString)
					  .UseLazyLoadingProxies()
					  .Options)
			{
			}

			public MyContext(DbContextOptions<dbCalystoUnittestDataContext3> options) : base(options)
			{
			}
		}

		/// <summary>
		/// Navigation properties loading test.
		/// </summary>
		[TestMethod]
		public void TestMethod1()
		{
			MyContext db = new MyContext();

			var item1 = db.tblAppMember
				.Where(o => o.AppMemberID == 2)
				.Include(o => o.tblAppMemberPictureList)
				.Include(o => o.tblAppMemberStatus)
				.FirstOrDefault();

			Assert.AreEqual(200, item1.tblAppMemberStatus?.AppMemberStatusID);
			Assert.AreEqual(1, item1.tblAppMemberPictureList.Count);
		}

		/// <summary>
		/// ExecuteDataSet() test.
		/// </summary>
		[TestMethod]
		public void TestMethod2()
		{
			MyContext db = new MyContext();
			var ds1 = db.ExecuteDataSet("select * from tblAppMember where AppMemberID > {0}", 5);
			Assert.AreEqual(1, ds1.Tables.Count);
			Assert.AreEqual(28, ds1.Tables[0].Columns.Count);
			Assert.AreEqual(7, ds1.Tables[0].Rows.Count);
			Assert.AreEqual("evi@htj.com", ds1.Tables[0].Rows[1]["Email"]);
		}

		/// <summary>
		/// ExecuteMultipleResults() test.
		/// </summary>
		[TestMethod]
		public void TestMethod3()
		{
			MyContext db = new MyContext();

			var res1 = db.ExecuteMultipleResults("select getdate() as CurrentDate; select * from tblAppMember where AppMemberID > {0}", 5);
			var res2 = res1.ReadResults(res => new
			{
				CurrentDate = res.GetSequence<DateTime>().First(),
				Members = res.GetSequence<object[]>().ToList()
			});

			Assert.IsTrue(res2.CurrentDate > DateTime.Now.AddDays(-1));
			Assert.IsTrue(res2.CurrentDate < DateTime.Now.AddDays(1));

			Assert.AreEqual(7, res2.Members.Count);
			Assert.AreEqual(28, res2.Members[0].Length);
			Assert.AreEqual("toto@mbds.com", res2.Members[2][5]);
		}

		/// <summary>
		/// UsingTransaction() test.
		/// </summary>
		[TestMethod]
		public void TestMethod4()
		{
			MyContext db = new MyContext();
			db.UsingTransaction(state =>
			{
				state.RollbackTransaction = true;

				int rows1 = db.ExecuteCommand("update tblAppMember set Email = 'novi-email'");
				Assert.AreEqual(8, rows1);

				var items1 = db.ExecuteList<string>("select Email from tblAppMember");
				Assert.AreEqual(8, items1.Count);
				Assert.IsTrue(items1.All(o => o == "novi-email"));
			});

			// will test email after rollback
			var email1 = db.ExecuteList<string>("select Email from tblAppMember where AppMemberID = {0}", 22);
			Assert.AreEqual(1, email1.Count);
			Assert.AreEqual("mm@nyyws.com", email1.First());
		}

		/// <summary>
		/// DeleteDirect() test.
		/// Testiramo samo da ne skoci exception.
		/// </summary>
		[TestMethod]
		public void TestMethod5()
		{
			MyContext db = new MyContext();
			DateTime dt1 = DateTime.Now.AddYears(-100);
			DateTime dt2 = DateTime.Now.AddYears(100);
			int id1 = 0;

			RawSqlQuery res1 = QueryableExtensions1.CreateDeleteDirect(db.tblAppMember.Where(o => o.AppMemberID < id1 && o.BirthDate > dt1 && o.BirthDate < dt2));

			TestFilesProvider2 provider = new TestFilesProvider2(Path.Combine(_root1, "TestMethod5-raw-sql"));
			provider.Assert(Assert.AreEqual, res1.CommandText);
			Assert.AreEqual(3, res1.Parameters.Count);

			// test executor
			int affected = db.tblAppMember.Where(o => o.AppMemberID < id1 && o.BirthDate > dt1 && o.BirthDate < dt2).DeleteDirect();
		}

		/// <summary>
		/// DeleteDirect() test.
		/// Testiramo samo da ne skoci exception.
		/// </summary>
		[TestMethod]
		public void TestMethod51()
		{
			MyContext db = new MyContext();
			DateTime dt1 = DateTime.Now.AddYears(-100);
			DateTime dt2 = DateTime.Now.AddYears(100);
			int id1 = 0;
			RawSqlQuery res1 = QueryableExtensions1.CreateDeleteDirect(db.tblAppMember.Where(o => o.AppMemberID < id1 && o.BirthDate > dt1 && o.BirthDate < dt2 && o.tblAppMemberPermissionList.Any()));

			TestFilesProvider2 provider = new TestFilesProvider2(Path.Combine(_root1, "TestMethod51-raw-sql"));
			provider.Assert(Assert.AreEqual, res1.CommandText);
			Assert.AreEqual(3, res1.Parameters.Count);
		}

		/// <summary>
		/// DeleteDirect() test.
		/// Testiramo samo da ne skoci exception.
		/// </summary>
		[TestMethod]
		public void TestMethod52()
		{
			MyContext db = new MyContext();
			DateTime dt1 = DateTime.Now.AddYears(-100);
			DateTime dt2 = DateTime.Now.AddYears(100);
			int id1 = 0;
			RawSqlQuery res1 = QueryableExtensions1.CreateDeleteDirect(db.tblAppMember.Where(o => o.AppMemberID < id1 && o.BirthDate > dt1 && o.BirthDate < dt2 && o.tblAppMemberStatus.IsActive));

			TestFilesProvider2 provider = new TestFilesProvider2(Path.Combine(_root1, "TestMethod52-raw-sql"));
			provider.Assert(Assert.AreEqual, res1.CommandText);
			Assert.AreEqual(3, res1.Parameters.Count);
		}

		/// <summary>
		/// UpdateDirect() test.
		/// Testiramo samo da ne skoci exception.
		/// </summary>
		[TestMethod]
		public void TestMethod6()
		{
			MyContext db = new MyContext();
			DateTime dt1 = DateTime.Now.AddYears(-100);
			DateTime dt2 = DateTime.Now.AddYears(100);
			int id1 = 0;

			RawSqlQuery res1 = QueryableExtensions1.CreateUpdateDirect(
				db.tblAppMember.Where(o => o.AppMemberID < id1 && o.BirthDate > dt1 && o.BirthDate < dt2), 
				() => new tblAppMember() { MSISDN = "1234" }
			);

			TestFilesProvider2 provider = new TestFilesProvider2(Path.Combine(_root1, "TestMethod6-raw-sql"));
			provider.Assert(Assert.AreEqual, res1.CommandText);
			Assert.AreEqual(4, res1.Parameters.Count);

			// test executor
			int affected = db.tblAppMember.Where(o => o.AppMemberID < id1 && o.BirthDate > dt1 && o.BirthDate < dt2)
				.UpdateDirect(() => new tblAppMember() { MSISDN = "1234" });
		}

		/// <summary>
		/// UpdateDirect() test.
		/// Testiramo samo da ne skoci exception.
		/// </summary>
		[TestMethod]
		public void TestMethod61()
		{
			MyContext db = new MyContext();
			DateTime dt1 = DateTime.Now.AddYears(-100);
			DateTime dt2 = DateTime.Now.AddYears(100);
			int id1 = 0;
			RawSqlQuery res1 = QueryableExtensions1.CreateUpdateDirect(
				db.tblAppMember.Where(o => o.AppMemberID < id1 && o.BirthDate > dt1 && o.BirthDate < dt2 && o.tblAppMemberPermissionList.Any()),
				() => new tblAppMember() { MSISDN = "1234" }
			);

			TestFilesProvider2 provider = new TestFilesProvider2(Path.Combine(_root1, "TestMethod61-raw-sql"));
			provider.Assert(Assert.AreEqual, res1.CommandText);
			Assert.AreEqual(4, res1.Parameters.Count);
		}

		/// <summary>
		/// UpdateDirect() test.
		/// Testiramo samo da ne skoci exception.
		/// </summary>
		[TestMethod]
		public void TestMethod62()
		{
			MyContext db = new MyContext();
			DateTime dt1 = DateTime.Now.AddYears(-100);
			DateTime dt2 = DateTime.Now.AddYears(100);
			int id1 = 0;
			RawSqlQuery res1 = QueryableExtensions1.CreateUpdateDirect(
				db.tblAppMember.Where(o => o.AppMemberID < id1 && o.BirthDate > dt1 && o.BirthDate < dt2 && o.tblAppMemberStatus.IsActive),
				() => new tblAppMember() { MSISDN = "1234" }
			);

			TestFilesProvider2 provider = new TestFilesProvider2(Path.Combine(_root1, "TestMethod62-raw-sql"));
			provider.Assert(Assert.AreEqual, res1.CommandText);
			Assert.AreEqual(4, res1.Parameters.Count);
		}

		/// <summary>
		/// UpdateDirect() test.
		/// Testiramo samo da ne skoci exception.
		/// </summary>
		[TestMethod]
		public void TestMethod63()
		{
			//var builder = new DbContextOptionsBuilder<dbCalystoUnittestDataContext3>();
			//builder.UseSqlServer(DatabaseSettings.SqlServerConnectionString);
			//builder.UseLazyLoadingProxies();
			//builder.EnableSensitiveDataLogging().LogTo(msg => Trace.WriteLine(msg));
			//MyContext db = new MyContext(builder.Options);

			MyContext db = new MyContext();
			DateTime dt1 = DateTime.Now.AddYears(-100);
			DateTime dt2 = DateTime.Now.AddYears(100);
			int id1 = 0;
			RawSqlQuery res1 = QueryableExtensions1.CreateUpdateDirect(
				db.tblAppMember.Where(o => o.AppMemberID < id1 && o.BirthDate > dt1 && o.BirthDate < dt2 && o.tblAppMemberStatus.IsActive),
				() => new tblAppMember() { MSISDN = "1234", BirthDate = null }
			);

			TestFilesProvider2 provider = new TestFilesProvider2(Path.Combine(_root1, "TestMethod63-raw-sql"));
			provider.Assert(Assert.AreEqual, res1.CommandText);
			Assert.AreEqual(4, res1.Parameters.Count);
		}

		/// <summary>
		/// DeleteDirect() test.
		/// Pise u bazu u transakciji pa rollback.
		/// </summary>
		[TestMethod]
		public void TestMethod7()
		{
			MyContext db = new MyContext();
			int cnt1 = db.tblAppMemberPicture.Count();
			int cnt2 = 0;
			int affected1 = 0;

			db.UsingTransaction(state =>
			{
				state.RollbackTransaction = true;

				int id1 = 20;
				affected1 = db.tblAppMemberPicture.Where(o => o.AppMemberID > id1 && o.ImageData == null && o.FileName != null)
					.DeleteDirect();

				Assert.AreEqual(2, affected1);

				cnt2 = db.tblAppMemberPicture.Count();
			});

			int cnt3 = db.tblAppMemberPicture.Count();

			// load in new context to have correct count
			int cnt4 = new MyContext().tblAppMemberPicture.Count();

			Assert.AreEqual(6, cnt1);
			Assert.AreEqual(cnt1 - affected1, cnt2);
			Assert.AreEqual(cnt1, cnt3);
			Assert.AreEqual(cnt1, cnt4);
		}

		/// <summary>
		/// UpdateDirect() test.
		/// Pise u bazu u transakciji pa rollback.
		/// </summary>
		[TestMethod]
		public void TestMethod8()
		{
			MyContext db = new MyContext();
			var list1 = db.tblAppMemberPicture.Select(o => o.FileName).ToList();

			db.UsingTransaction(state =>
			{
				state.RollbackTransaction = true;

				int id1 = 20;
				int affected1 = db.tblAppMemberPicture.Where(o => o.AppMemberID > id1 && o.ImageData == null && o.FileName != null)
					.UpdateDirect(() => new tblAppMemberPicture() { FileName = "file1", ImageMimeType = "mime1" });

				Assert.AreEqual(2, affected1);

				var list2 = db.tblAppMemberPicture.Where(o => o.FileName == "file1").Select(o => o.FileName).ToList();
				Assert.AreEqual(2, list2.Count);

				var list3 = db.tblAppMemberPicture.Where(o => o.ImageMimeType == "mime1").Select(o => o.ImageMimeType).ToList();
				Assert.AreEqual(2, list3.Count);

				int aff2 = db.tblAppMemberPicture.UpdateDirect(() => new tblAppMemberPicture() { ThumbMimeType = "thumb1" });
				Assert.AreEqual(6, aff2);

				int aff3 = db.tblAppMemberPicture.DeleteDirect();
				Assert.AreEqual(6, aff3);

				int cnt1 = db.tblAppMemberPicture.Count();
				Assert.AreEqual(0, cnt1);
			});

			var list4 = db.tblAppMemberPicture.Select(o => o.FileName).ToList();
			Assert.IsTrue(list4.SequenceEqual(list1));

			// load in new context to have correct count
			var list5 = new MyContext().tblAppMemberPicture.Select(o => o.FileName).ToList();
			Assert.IsTrue(list5.SequenceEqual(list1));

		}

		/// <summary>
		/// View test.
		/// </summary>
		[TestMethod]
		public void TestMethod9()
		{
			MyContext db = new MyContext();
			var list1 = db.viewRandom.ToList();
			Assert.AreEqual(1, list1.Count);

			db = new MyContext();
			var list2 = db.viewRandom.Select(o => o.Random).ToList();
			Assert.AreEqual(1, list2.Count);
		}

		/// <summary>
		/// Scalar-valued function.
		/// </summary>
		[TestMethod]
		public void TestMethod10()
		{
			MyContext db = new MyContext();
			double? res1 = db.fnSumNumbers(1.22, 3.33);
			Assert.AreEqual(4.55, res1);
		}

		/// <summary>
		/// Table-valued function.
		/// </summary>
		[TestMethod]
		public void TestMethod11()
		{
			MyContext db = new MyContext();
			var list1 = db.fnSplitStringByPattern("hešđčllo hšđčow are yšđčou today 1234 todšđčay 1234 hello", "šđč");
			Assert.AreEqual("he_llo h_ow are y_ou today 1234 tod_ay 1234 hello", string.Join("_", list1.Select(o => o.part)));

			var list2 = db.fnSplitStringByPattern("hešđčllo hšđčow are yšđčou today 1234 todšđčay 1234 hello", " ");
			Assert.AreEqual("hešdcllo_hšdcow_are_yšdcou_today_1234_todšdcay_1234_hello", string.Join("_", list2.Select(o => o.part)));

			var list3 = db.fnSplitStringByPattern("hešđčllo     hšđčow  are yšđčou   today  1234 todšđčay 1234   hello", "  ");
			Assert.AreEqual("hešdcllo_ hšdcow_are yšdcou_ today_1234 todšdcay 1234_ hello", string.Join("_", list3.Select(o => o.part)));
		}

		/// <summary>
		/// MultipleResults function.
		/// </summary>
		[TestMethod]
		public void TestMethod12()
		{
			MyContext db = new MyContext();

			int? m1 = 22;
			var multi1 = db.spMultiResults(0, 10, ref m1);

			Assert.AreEqual(1, multi1.Result1.Count);
			Assert.AreEqual(1, multi1.Result2.Count);
			Assert.AreEqual(13, multi1.Result3.Count);
			Assert.AreEqual(1, multi1.Result4.Count);
		}

		/// <summary>
		/// Use tblAppMember2 for bulk insert, there is no PK and no autoincrement column.
		/// </summary>
		[TestMethod()]
		public void BulkInsertTest1()
		{
			MyContext cx = new MyContext();

			// tblAppMember2 nema PK pa moze bulk insert bez identity inserta
			// tblAppMember ima PK pa treba koristiti identity insert
			var items = cx.ExecuteList<tblAppMember2>($"select top 10 * from {nameof(tblAppMember2)}");
			int cnt1 = cx.ExecuteList<int>($"select count(1) from {nameof(tblAppMember2)}").First();
			int cnt2 = 0;
			//bool isCatch = false;

			cx.UsingTransaction(state =>
			{
				state.RollbackTransaction = true; // obavezno rollback da ne ostane insertirano u bazi

				// insert u tblAppMember2 radi
				cx.ExecuteBulkInsert(items);
				cnt2 = cx.ExecuteList<int>($"select count(1) from {nameof(tblAppMember2)}").First();
				cx.ExecuteBulkInsert(items);

				// insert u tblAppMember treba koristiti idenitity insert
				//try
				//{
				//	cx.ExecuteBulkInsert(items, true); // mora baciti ex jer ne moze insertirati duple ID-ove
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

		/// <summary>
		/// Update existing item.
		/// </summary>
		[TestMethod]
		public void TestMethod20()
		{
			MyContext cx = new MyContext();
			int cnt1 = new MyContext().tblAppMemberPicture2.Count();
			var item = cx.tblAppMemberPicture2.First();
			item.FileName = Guid.NewGuid().ToString();
			int aff1 = item.SaveToDB();
			int cnt2 = new MyContext().tblAppMemberPicture2.Count();

			Assert.AreEqual(1, aff1);
			Assert.AreEqual(cnt1, cnt2);
		}

		/// <summary>
		/// Insert than delete.
		/// </summary>
		[TestMethod]
		public void TestMethod21()
		{
			int cnt1 = new MyContext().tblAppMemberPicture2.Count();
			var item = new tblAppMemberPicture2(new MyContext());
			item.FileName = Guid.NewGuid().ToString();
			int aff1 = item.SaveToDB();
			int cnt2 = new MyContext().tblAppMemberPicture2.Count();
			int aff2 = item.DeleteFromDB();
			int cnt3 = new MyContext().tblAppMemberPicture2.Count();

			Assert.AreEqual(1, aff1);
			Assert.AreEqual(1, aff2);
			Assert.AreEqual(cnt1 + 1, cnt2);
			Assert.AreEqual(cnt1, cnt3);
		}

		/// <summary>
		/// Navigation properties loading test.
		/// </summary>
		[TestMethod]
		public void TestMethod22()
		{
			MyContext db = new MyContext();
			var item1 = db.tblAppMember.Where(o => o.AppMemberID == 19).FirstOrDefault();

			var status1 = item1.GetNavigation(f => f.tblAppMemberStatus);
			var status2 = item1.GetNavigation(f => f.tblAppMemberStatus);
			Assert.AreEqual(50, status1?.AppMemberStatusID);

			var pics1 = item1.GetNavigation(f => f.tblAppMemberPictureList);
			var pics2 = item1.GetNavigation(f => f.tblAppMemberPictureList);
			Assert.AreEqual(1, pics1.Count);
			Assert.AreEqual(69, pics1.First().AppMemberPictureID);
		}

		/// <summary>
		/// Navigation properties loading using UseLazyLoadingProxies()
		/// </summary>
		[TestMethod]
		public void TestMethod23()
		{
			MyContext db = new MyContext();
			var item1 = db.tblAppMember.Where(o => o.AppMemberID == 19).FirstOrDefault();

			var status1 = item1.tblAppMemberStatus;
			Assert.AreEqual(50, status1?.AppMemberStatusID);

			var pics1 = item1.tblAppMemberPictureList;
			Assert.AreEqual(1, pics1.Count);
			Assert.AreEqual(69, pics1.First().AppMemberPictureID);
		}

		[TestMethod]
		public void TestMethod24()
		{
			MyContext db = new MyContext();
			var x1 = new DateTime(2019, 6, 16, 15, 55, 26);
			var x2 = 352;
			var a1 = db.tblAppMember.Where(o => o.BirthDate > x1 && o.AppMemberID > x2 && o.Address != null && o.BirthDate == null).Skip(1).Take(2).ToRawSqlQuery();
			var a2 = a1.ToInterpolatedSqlQuery();

			TestFilesProvider2 provider = new TestFilesProvider2(Path.Combine(_root1, "TestMethod24-raw-sql"));
			provider.Assert(Assert.AreEqual, a1.CommandText);
			Assert.AreEqual(4, a1.Parameters.Count);

			TestFilesProvider2 provider2 = new TestFilesProvider2(Path.Combine(_root1, "TestMethod24-interpolated-sql"));
			provider2.Assert(Assert.AreEqual, a2.CommandText);
			Assert.AreEqual(4, a2.Values.Length);
		}

		[TestMethod]
		public void TestMethod241()
		{
			MyContext db = new MyContext();
			var x1 = new DateTime(2019, 6, 16, 15, 55, 26);
			var x2 = 352;
			var a1 = db.tblAppMember.Where(o => o.BirthDate > x1 && o.AppMemberID > x2 && o.Address != null && o.BirthDate == null).Skip(1).Take(2).ToQueryString();

			TestFilesProvider2 provider = new TestFilesProvider2(Path.Combine(_root1, "TestMethod241-qstr-sql"));
			provider.Assert(Assert.AreEqual, a1);
		}

		[TestMethod]
		public void TestMethod242()
		{
			MyContext db = new MyContext();
			var x1 = new DateTime(2019, 6, 16, 15, 55, 26);
			var x2 = 352;
			var a1 = db.tblAppMember.Where(o => o.BirthDate > x1 && o.AppMemberID > x2 && o.Address != null && o.BirthDate == null).Skip(1).Take(2).ToRawSqlQuery();
			var a2 = a1.ToInterpolatedSqlQuery();

			TestFilesProvider2 provider = new TestFilesProvider2(Path.Combine(_root1, "TestMethod242-raw-sql"));
			provider.Assert(Assert.AreEqual, a1.CommandText);
			Assert.AreEqual(4, a1.Parameters.Count);

			TestFilesProvider2 provider2 = new TestFilesProvider2(Path.Combine(_root1, "TestMethod242-interpolated-sql"));
			provider2.Assert(Assert.AreEqual, a2.CommandText);
			Assert.AreEqual(4, a2.Values.Length);

		}

		[TestMethod]
		public void TestMethod243()
		{
			MyContext db = new MyContext();
			var a1 = db.tblAppMember.Where(o => o.Address != null && o.BirthDate == null).ToList();
			Assert.AreEqual(1, a1.Count);
		}

		[TestMethod]
		public void TestMethod244()
		{
			MyContext db = new MyContext();
			var a1 = db.tblAppMember.Where(o => o.Address == null && o.BirthDate != null).ToList();
			Assert.AreEqual(3, a1.Count);
		}

		[TestMethod]
		public void TestMethod25()
		{
			MyContext db = new MyContext();
			var a1 = db.tblAppMember.Where(o => o.BirthDate > new DateTime(2019, 6, 16, 15, 55, 26) && o.AppMemberID > 253).ToRawSqlQuery();
			var a2 = a1.ToInterpolatedSqlQuery();

			TestFilesProvider2 provider = new TestFilesProvider2(Path.Combine(_root1, "TestMethod25-raw-sql"));
			provider.Assert(Assert.AreEqual, a1.CommandText);
			Assert.AreEqual(0, a1.Parameters.Count);

			TestFilesProvider2 provider2 = new TestFilesProvider2(Path.Combine(_root1, "TestMethod25-interpolated-sql"));
			provider2.Assert(Assert.AreEqual, a2.CommandText);
			Assert.AreEqual(0, a2.Values.Length);

		}

		[TestMethod]
		public void TestMethod26()
		{
			MyContext db = new MyContext();
			var a1 = db.tblAppMember.Where(o => o.AppMemberID > 2534 && !string.IsNullOrEmpty(o.FirstName)).ToRawSqlQuery();

			TestFilesProvider2 provider = new TestFilesProvider2(Path.Combine(_root1, "TestMethod26-raw-sql"));
			provider.Assert(Assert.AreEqual, a1.CommandText);
		}

		[TestMethod]
		public void TestMethod27()
		{
			MyContext db = new MyContext();
			var a1 = db.tblAppMember.Where(o => o.AppMemberID > 2534 && !string.IsNullOrWhiteSpace(o.FirstName)).ToRawSqlQuery();

			TestFilesProvider2 provider = new TestFilesProvider2(Path.Combine(_root1, "TestMethod27-raw-sql"));
			provider.Assert(Assert.AreEqual, a1.CommandText);
		}

		[TestMethod]
		public void TestMethod28()
		{
			MyContext db = new MyContext();
			int? totalCnt = -5;
			var res1 = db.spGetAppMembers(0, 100, ref totalCnt);

			Assert.AreEqual(5555, totalCnt);
			Assert.AreEqual(8, res1.Result1.Count);
			Assert.AreEqual(1, res1.Result2.Count);
			Assert.AreEqual(8, res1.Result2.First().TotalCount);
			Assert.AreEqual(77, res1.ReturnValue);
		}

		[TestMethod]
		public void TestMethod29()
		{
			MyContext db = new MyContext();
			int? totalCnt = -6;
			var res1 = db.spSysRebuildAllIndexes(0, ref totalCnt);

			Assert.AreEqual(23, totalCnt);
			Assert.AreEqual(23, res1.Result1.Count);
			Assert.AreEqual(1, res1.Result1[1].page_count);
			Assert.AreEqual(10, res1.Result1[2].page_count);
		}

		[TestMethod]
		public void TestMethod30()
		{
			MyContext db = new MyContext();
			var res1 = db.fnAddPaddingSpace("123", 6, true);
			Assert.AreEqual("   123", res1);
		}

		[TestMethod]
		public void TestMethod31()
		{
			MyContext db = new MyContext();
			var res1 = db.fnAddPaddingSpace("123", 6, false);
			Assert.AreEqual("123   ", res1);
		}

		[TestMethod]
		public void TestMethod32()
		{
			MyContext db = new MyContext();
			var res1 = db.fnAddPaddingSpace("1234567", 6, true);
			Assert.AreEqual("234567", res1);
		}

		[TestMethod]
		public void TestMethod33()
		{
			MyContext db = new MyContext();
			var res1 = db.fnAddPaddingSpace("1234567", 6, false);
			Assert.AreEqual("123456", res1);
		}

		[TestMethod]
		public void TestMethod34()
		{
			MyContext db = new MyContext();
			var res1 = db.spNoTablesResults();
			Assert.AreEqual(22, res1.ReturnValue);
		}

		[TestMethod]
		public void TestMethod35()
		{
			MyContext db = new MyContext();
			int? total = -10;
			var res1 = db.spNoTablesResults2(ref total);
			Assert.AreEqual(22, res1.ReturnValue);
			Assert.AreEqual(3232, total);
		}

		[TestMethod]
		public void TestMethod36()
		{
			MyContext db = new MyContext();
			tblAppMember m1 = db.tblAppMember.First();

			Assert.IsTrue(db.Entry(m1).State == EntityState.Unchanged);

			// detached in new context
			MyContext db2 = new MyContext();
			Assert.IsTrue(db2.Entry(m1).State == EntityState.Detached);

			Assert.IsTrue(db.Entry(m1).State == EntityState.Unchanged);

			// test never attached object
			Assert.IsTrue(db.Entry(new tblAppMember()).State == EntityState.Detached);

		}

		[TestMethod]
		public void TestMethod37()
		{
			// without loading proxy
			dbCalystoUnittestDataContext3 db = new dbCalystoUnittestDataContext3(c => c.UseSqlServer(DatabaseConnectionsSettings.SqlCalystoUnittestConnectionString));

			tblAppMember m1 = db.tblAppMember
				.Where(o => o.AppMemberID == 21)
				.Include(o => o.tblAppMemberPermissionList)
				.Include(o => o.tblAppMemberPictureList)
				.First();

			m1.tblAppMemberPictureList[0].ImageMimeType = "fsdgasdf4q4ytqwereqhqwertryhqwerwetywrwe";

			try
			{
				db.ValidateColumnsDataLength(m1, true);
				Assert.Fail("Should throw exception before reaching this line.");
			}
			catch (Exception ex)
			{
				Assert.IsTrue(ex.Message.Contains("tblAppMemberPicture.ImageMimeType"));
				Assert.IsTrue(ex.Message.Contains("String would be truncated in"));
			}

		}

		[TestMethod]
		public void TestMethod38()
		{
			// without loading proxy
			dbCalystoUnittestDataContext3 db = new dbCalystoUnittestDataContext3(c => c.UseSqlServer(DatabaseConnectionsSettings.SqlCalystoUnittestConnectionString));
			var q1 = db.tblAppMember.IncludeDescendants(2, true, true);
			var res1 = q1.ToRawSqlQuery();

			TestFilesProvider2 provider = new TestFilesProvider2(Path.Combine(_root1, "TestMethod38-raw-sql"));
			provider.Assert(Assert.AreEqual, res1.CommandText);

			var res2 = q1.ToList();
			Assert.AreEqual(8, res2.Count);
			Assert.AreEqual(1, res2.First().tblAppMemberPictureList.Count);
		}

		[TestMethod]
		public void TestMethod39()
		{
			/*
				test locking table, works with default db settings (isolation level:	read committed)
				ALTER DATABASE dbCalystoUnittest  SET ALLOW_SNAPSHOT_ISOLATION ON
				ALTER DATABASE dbCalystoUnittest  SET READ_COMMITTED_SNAPSHOT OFF
				DBCC useroptions
			*/
			DateTime? dt1 = default;
			DateTime? dt2 = default;
			MyContext db1 = new MyContext();
			MyContext db2 = new MyContext();
			
			Task task2 = new Task(() =>
			{
				// this task will wait untill transaction is complete,
				// so dt2 >= dt1
				var m2 = db2.tblAppMobileLog.FirstOrDefault();
				dt2 = DateTime.Now;
				Thread.Sleep(1000);
			});

			Task task1 = Task.Run(() =>
			{
				db1.UsingTransaction(state =>
				{
					state.RollbackTransaction = true;

					// lock table inside transaction
					// table lock will be released when transacation is complete
					state.LockTableExclusive(o => o.tblAppMobileLog);

					task2.Start();

					var m1 = db1.tblAppMobileLog.FirstOrDefault();
					dt1 = DateTime.Now;
					Thread.Sleep(1000);

				});
			});

			Task.WaitAll(task1, task2);

			double delta = (dt2.Value - dt1.Value).TotalMilliseconds;

			Assert.IsTrue(delta >= 1000, $"delta: {delta}");
		}

		[TestMethod]
		public void TestMethod40()
		{
			/* USES sp_getapplock which works with any isolation level
				DBCC useroptions
			*/
			DateTime? dt1 = default;
			DateTime? dt2 = default;
			MyContext db1 = new MyContext();
			MyContext db2 = new MyContext();

			Task task2 = new Task(() =>
			{
				db2.UsingTransaction(state =>
				{
					state.RollbackTransaction = true;
					state.LockResourceExclusive("myres1");
					// this task will wait untill transaction is complete,
					// so dt2 >= dt1
					var m2 = db2.tblAppMobileLog.FirstOrDefault();
					dt2 = DateTime.Now;
					Thread.Sleep(1000);
				});
			});

			Task task1 = Task.Run(() =>
			{
				db1.UsingTransaction(state =>
				{
					state.RollbackTransaction = true;

					// lock table inside transaction
					// table lock will be released when transacation is complete
					state.LockResourceExclusive("myres1");

					task2.Start();

					var m1 = db1.tblAppMobileLog.FirstOrDefault();
					dt1 = DateTime.Now;
					Thread.Sleep(1000);

				});
			});

			Task.WaitAll(task1, task2);

			double delta = (dt2.Value - dt1.Value).TotalMilliseconds;

			Assert.IsTrue(delta >= 1000, $"delta: {delta}");
		}
	}
}
