//using CalystoUnittestNamespace4;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.Linq;
//using Calysto.EntityFrameworkCore;
//using System;
//using System.IO;

//namespace SqlMetal.Tests.ReadDatabaseTests
//{
//	//[Ignore("MySQL server should be installed")]
//	[TestClass]
//	public class MySqlEFModelTests1
//	{
//		public static string TestFilesPath => Path.Combine(EnvDTE.EnvDTESqlMetalTests.ProjectDir, "ReadDatabaseTests\\MySql\\TestFiles");

//		/// <summary>
//		/// Use dbCalystoUnittestDataContext from file CalystoDbmlEFCoreTest2.cs which is generated from database.
//		/// Model generated from dbml doesn't have correct MultipleResults types.
//		/// All other genereated cs files must have properties BuildAction: None
//		/// </summary>
//		public class MyContext : dbCalystoUnittestDataContext4
//		{
//			public MyContext()
//				: base(new DbContextOptionsBuilder<dbCalystoUnittestDataContext4>()
//					  .UseMySql(DatabaseSettings.MySqlConnectionString)
//					  .UseLazyLoadingProxies()
//					  .Options)
//			{
//			}
//		}

//		/// <summary>
//		/// Navigation properties loading test.
//		/// </summary>
//		[TestMethod]
//		public void TestMethod1()
//		{
//			MyContext db = new MyContext();

//			var item1 = db.tblAppMember
//				.Where(o => o.AppMemberID == 2)
//				.Include(o => o.tblAppMemberPictureList)
//				.Include(o => o.tblAppMemberStatus)
//				.FirstOrDefault();

//			Assert.AreEqual(200, item1.tblAppMemberStatus?.AppMemberStatusID);
//			Assert.AreEqual(1, item1.tblAppMemberPictureList.Count);
//		}

//		/// <summary>
//		/// ExecuteDataSet() test.
//		/// </summary>
//		[TestMethod]
//		public void TestMethod2()
//		{
//			MyContext db = new MyContext();
//			var ds1 = db.ExecuteDataSet("select * from tblAppMember where AppMemberID > {0}", 5);
//			Assert.AreEqual(1, ds1.Tables.Count);
//			Assert.AreEqual(28, ds1.Tables[0].Columns.Count);
//			Assert.AreEqual(7, ds1.Tables[0].Rows.Count);
//			Assert.AreEqual("evi@htj.com", ds1.Tables[0].Rows[1]["Email"]);
//		}

//		/// <summary>
//		/// ExecuteMultipleResults() test.
//		/// </summary>
//		[TestMethod]
//		public void TestMethod3()
//		{
//			MyContext db = new MyContext();

//			var res1 = db.ExecuteMultipleResults("select {1} as CurrentDate; select * from tblAppMember where AppMemberID > {0}", 5, DateTime.Now);
//			var res2 = res1.ReadResults(res => new
//			{
//				CurrentDate = res.GetResult<DateTime>().First(),
//				Members = res.GetResult<object[]>().ToList()
//			});

//			Assert.IsTrue(res2.CurrentDate > DateTime.Now.AddDays(-1));
//			Assert.IsTrue(res2.CurrentDate < DateTime.Now.AddDays(1));

//			Assert.AreEqual(7, res2.Members.Count);
//			Assert.AreEqual(28, res2.Members[0].Length);
//			Assert.AreEqual("toto@mbds.com", res2.Members[2][5]);
//		}

//		/// <summary>
//		/// UseTransaction() test.
//		/// </summary>
//		[TestMethod]
//		public void TestMethod4()
//		{
//			MyContext db = new MyContext();
//			db.UseTransaction(state =>
//			{
//				state.RollbackTransaction = true;

//				int rows1 = db.ExecuteCommand("update tblAppMember set Email = 'novi-email'");
//				Assert.AreEqual(8, rows1);

//				var items1 = db.ExecuteList<string>("select Email from tblAppMember");
//				Assert.AreEqual(8, items1.Count);
//				Assert.IsTrue(items1.All(o => o == "novi-email"));
//			});

//			// will test email after rollback
//			var email1 = db.ExecuteList<string>("select Email from tblAppMember where AppMemberID = {0}", 22);
//			Assert.AreEqual(1, email1.Count);
//			Assert.AreEqual("mm@nyyws.com", email1.First());
//		}

//		/// <summary>
//		/// DeleteDirect() test.
//		/// Testiramo samo da ne skoci exception.
//		/// </summary>
//		[TestMethod]
//		public void TestMethod5()
//		{
//			MyContext db = new MyContext();
//			DateTime dt1 = DateTime.Now.AddYears(-100);
//			DateTime dt2 = DateTime.Now.AddYears(100);
//			int id1 = 0;
//			int affected1 = db.tblAppMember.Where(o => o.AppMemberID < id1 && o.BirthDate > dt1 && o.BirthDate < dt2)
//				.DeleteDirect();
//		}

//		/// <summary>
//		/// DeleteDirect() test.
//		/// Testiramo samo da ne skoci exception.
//		/// </summary>
//		[TestMethod]
//		public void TestMethod51()
//		{
//			MyContext db = new MyContext();
//			DateTime dt1 = DateTime.Now.AddYears(-100);
//			DateTime dt2 = DateTime.Now.AddYears(100);
//			int id1 = 0;
//			int affected1 = db.tblAppMember.Where(o => o.AppMemberID < id1 && o.BirthDate > dt1 && o.BirthDate < dt2 && o.tblAppMemberPermissionList.Any())
//				.DeleteDirect();
//		}

//		/// <summary>
//		/// DeleteDirect() test.
//		/// Testiramo samo da ne skoci exception.
//		/// </summary>
//		[TestMethod]
//		public void TestMethod52()
//		{
//			MyContext db = new MyContext();
//			DateTime dt1 = DateTime.Now.AddYears(-100);
//			DateTime dt2 = DateTime.Now.AddYears(100);
//			int id1 = 0;
//			int affected1 = db.tblAppMember.Where(o => o.AppMemberID < id1 && o.BirthDate > dt1 && o.BirthDate < dt2 && o.tblAppMemberStatus.IsActive)
//				.DeleteDirect();
//		}

//		/// <summary>
//		/// UpdateDirect() test.
//		/// Testiramo samo da ne skoci exception.
//		/// </summary>
//		[TestMethod]
//		public void TestMethod6()
//		{
//			MyContext db = new MyContext();
//			DateTime dt1 = DateTime.Now.AddYears(-100);
//			DateTime dt2 = DateTime.Now.AddYears(100);
//			int id1 = 0;
//			int affected1 = db.tblAppMember.Where(o => o.AppMemberID < id1 && o.BirthDate > dt1 && o.BirthDate < dt2)
//				.UpdateDirect(() => new tblAppMember() { MSISDN = "1234" });
//		}

//		/// <summary>
//		/// UpdateDirect() test.
//		/// Testiramo samo da ne skoci exception.
//		/// </summary>
//		[TestMethod]
//		public void TestMethod61()
//		{
//			MyContext db = new MyContext();
//			DateTime dt1 = DateTime.Now.AddYears(-100);
//			DateTime dt2 = DateTime.Now.AddYears(100);
//			int id1 = 0;
//			int affected1 = db.tblAppMember.Where(o => o.AppMemberID < id1 && o.BirthDate > dt1 && o.BirthDate < dt2 && o.tblAppMemberPermissionList.Any())
//				.UpdateDirect(() => new tblAppMember() { MSISDN = "1234" });
//		}

//		/// <summary>
//		/// UpdateDirect() test.
//		/// Testiramo samo da ne skoci exception.
//		/// </summary>
//		[TestMethod]
//		public void TestMethod62()
//		{
//			MyContext db = new MyContext();
//			DateTime dt1 = DateTime.Now.AddYears(-100);
//			DateTime dt2 = DateTime.Now.AddYears(100);
//			int id1 = 0;
//			int affected1 = db.tblAppMember.Where(o => o.AppMemberID < id1 && o.BirthDate > dt1 && o.BirthDate < dt2 && o.tblAppMemberStatus.IsActive)
//				.UpdateDirect(() => new tblAppMember() { MSISDN = "1234" });
//		}

//		/// <summary>
//		/// DeleteDirect() test.
//		/// Pise u bazu u transakciji pa rollback.
//		/// </summary>
//		[TestMethod]
//		public void TestMethod7()
//		{
//			MyContext db = new MyContext();
//			int cnt1 = db.tblAppMemberPicture.Count();
//			int cnt2 = 0;
//			int affected1 = 0;

//			db.UseTransaction(state =>
//			{
//				state.RollbackTransaction = true;

//				int id1 = 20;
//				affected1 = db.tblAppMemberPicture.Where(o => o.AppMemberID > id1 && o.ImageData == null && o.FileName != null)
//					.DeleteDirect();

//				Assert.AreEqual(2, affected1);

//				cnt2 = db.tblAppMemberPicture.Count();
//			});

//			int cnt3 = db.tblAppMemberPicture.Count();

//			// load in new context to have correct count
//			int cnt4 = new MyContext().tblAppMemberPicture.Count();

//			Assert.AreEqual(6, cnt1);
//			Assert.AreEqual(cnt1 - affected1, cnt2);
//			Assert.AreEqual(cnt1, cnt3);
//			Assert.AreEqual(cnt1, cnt4);
//		}

//		/// <summary>
//		/// UpdateDirect() test.
//		/// Pise u bazu u transakciji pa rollback.
//		/// </summary>
//		[TestMethod]
//		public void TestMethod8()
//		{
//			MyContext db = new MyContext();
//			var list1 = db.tblAppMemberPicture.Select(o => o.FileName).ToList();

//			db.UseTransaction(state =>
//			{
//				state.RollbackTransaction = true;

//				int id1 = 20;
//				int affected1 = db.tblAppMemberPicture.Where(o => o.AppMemberID > id1 && o.ImageData == null && o.FileName != null)
//					.UpdateDirect(() => new tblAppMemberPicture() { FileName = "file1", ImageMimeType = "mime1" });

//				Assert.AreEqual(2, affected1);

//				var list2 = db.tblAppMemberPicture.Where(o => o.FileName == "file1").Select(o => o.FileName).ToList();
//				Assert.AreEqual(2, list2.Count);

//				var list3 = db.tblAppMemberPicture.Where(o => o.ImageMimeType == "mime1").Select(o => o.ImageMimeType).ToList();
//				Assert.AreEqual(2, list3.Count);

//				int aff2 = db.tblAppMemberPicture.UpdateDirect(() => new tblAppMemberPicture() { ThumbMimeType = "thumb1" });
//				Assert.AreEqual(6, aff2);

//				int aff3 = db.tblAppMemberPicture.DeleteDirect();
//				Assert.AreEqual(6, aff3);

//				int cnt1 = db.tblAppMemberPicture.Count();
//				Assert.AreEqual(0, cnt1);
//			});

//			var list4 = db.tblAppMemberPicture.Select(o => o.FileName).ToList();
//			Assert.IsTrue(list4.SequenceEqual(list1));

//			// load in new context to have correct count
//			var list5 = new MyContext().tblAppMemberPicture.Select(o => o.FileName).ToList();
//			Assert.IsTrue(list5.SequenceEqual(list1));

//		}

//		/// <summary>
//		/// View test.
//		/// </summary>
//		[TestMethod]
//		public void TestMethod9()
//		{
//			MyContext db = new MyContext();
//			var list1 = db.viewRandom.ToList();
//			Assert.AreEqual(1, list1.Count);

//			db = new MyContext();
//			var list2 = db.viewRandom.Select(o => o.Random).ToList();
//			Assert.AreEqual(1, list2.Count);
//		}

//		/// <summary>
//		/// Use tblAppMember2 for bulk insert, there is no PK and no autoincrement column.
//		/// </summary>
//		[TestMethod()]
//		public void BulkInsertTest1()
//		{
//			MyContext cx = new MyContext();

//			var items = cx.ExecuteList<tblAppMember2>($"select * from {nameof(tblAppMember2)} limit 10");
//			int cnt1 = cx.ExecuteList<int>($"select count(1) from {nameof(tblAppMember2)}").First();
//			int cnt2 = 0;
//			//bool isCatch = false;

//			cx.UseTransaction(state =>
//			{
//				state.RollbackTransaction = true; // obavezno rollback da ne ostane insertirano u bazi

//				cx.ExecuteBulkInsert(items);
//				cnt2 = cx.ExecuteList<int>($"select count(1) from {nameof(tblAppMember2)}").First();
//				cx.ExecuteBulkInsert(items);
//				int cnt21 = cx.ExecuteList<int>($"select count(1) from {nameof(tblAppMember2)}").First();

//				//try
//				//{
//				//	cx.ExecuteBulkInsert(items, true); // mora baciti ex jer ne moze insertirati duple ID-ove
//				//}
//				//catch
//				//{
//				//	isCatch = true;
//				//}
//			});

//			int cnt3 = cx.ExecuteList<int>($"select count(1) from {nameof(tblAppMember2)}").First();

//			Assert.AreEqual(8, cnt1);
//			Assert.AreEqual(16, cnt2); // biti ce 16 jer u tablici imamo 8 redova
//									   //Assert.AreEqual(true, isCatch);
//			Assert.AreEqual(8, cnt3);
//		}

//		/// <summary>
//		/// Update existing item.
//		/// </summary>
//		[TestMethod]
//		public void TestMethod20()
//		{
//			MyContext cx = new MyContext();
//			int cnt1 = new MyContext().tblAppMemberPicture2.Count();
//			var item = cx.tblAppMemberPicture2.First();
//			item.FileName = Guid.NewGuid().ToString();
//			int aff1 = item.SaveToDB();
//			int cnt2 = new MyContext().tblAppMemberPicture2.Count();

//			Assert.AreEqual(1, aff1);
//			Assert.AreEqual(cnt1, cnt2);
//		}

//		/// <summary>
//		/// Insert than delete.
//		/// </summary>
//		[TestMethod]
//		public void TestMethod21()
//		{
//			int cnt1 = new MyContext().tblAppMemberPicture2.Count();
//			var item = new tblAppMemberPicture2(new MyContext());
//			item.FileName = Guid.NewGuid().ToString();
//			item.AppMemberPictureID = 1234; // polje nije autonumber u MySQL bazi
//			int aff1 = item.SaveToDB();
//			int cnt2 = new MyContext().tblAppMemberPicture2.Count();
//			int aff2 = item.DeleteFromDB();
//			int cnt3 = new MyContext().tblAppMemberPicture2.Count();

//			Assert.AreEqual(1, aff1);
//			Assert.AreEqual(1, aff2);
//			Assert.AreEqual(cnt1 + 1, cnt2);
//			Assert.AreEqual(cnt1, cnt3);
//		}

//		/// <summary>
//		/// Navigation properties loading test.
//		/// </summary>
//		[TestMethod]
//		public void TestMethod22()
//		{
//			MyContext db = new MyContext();
//			var item1 = db.tblAppMember.Where(o => o.AppMemberID == 19).FirstOrDefault();

//			var status1 = item1.GetNavigation(f => f.tblAppMemberStatus);
//			var status2 = item1.GetNavigation(f => f.tblAppMemberStatus);
//			Assert.AreEqual(50, status1?.AppMemberStatusID);

//			var pics1 = item1.GetNavigation(f => f.tblAppMemberPictureList);
//			var pics2 = item1.GetNavigation(f => f.tblAppMemberPictureList);
//			Assert.AreEqual(1, pics1.Count);
//			Assert.AreEqual(69, pics1.First().AppMemberPictureID);
//		}

//		/// <summary>
//		/// Navigation properties loading using UseLazyLoadingProxies()
//		/// </summary>
//		[TestMethod]
//		public void TestMethod23()
//		{
//			MyContext db = new MyContext();
//			var item1 = db.tblAppMember.Where(o => o.AppMemberID == 19).FirstOrDefault();

//			var status1 = item1.tblAppMemberStatus;
//			Assert.AreEqual(50, status1?.AppMemberStatusID);

//			var pics1 = item1.tblAppMemberPictureList;
//			Assert.AreEqual(1, pics1.Count);
//			Assert.AreEqual(69, pics1.First().AppMemberPictureID);
//		}

//		[TestMethod]
//		public void TestMethod24()
//		{
//			MyContext db = new MyContext();
//			var x1 = new DateTime(2019, 6, 16, 15, 55, 26);
//			var x2 = 352;
//			var a1 = db.tblAppMember.Where(o => o.BirthDate > x1 && o.AppMemberID > x2).Skip(1).Take(2).ToRawSqlQuery();
//			var a2 = a1.ToInterpolatedSqlQuery();

//			TestHelpers.AssertAreEqual(TestFilesPath, "TestMethod24-raw-sql", a1.CommandText);
//			Assert.AreEqual(4, a1.Parameters.Count);

//			TestHelpers.AssertAreEqual(TestFilesPath, "TestMethod24-interpolated-sql", a2.CommandText);
//			Assert.AreEqual(4, a2.Values.Length);
//		}

//		[TestMethod]
//		public void TestMethod25()
//		{
//			MyContext db = new MyContext();
//			var a1 = db.tblAppMember.Where(o => o.BirthDate > new DateTime(2019, 6, 16, 15, 55, 26) && o.AppMemberID > 253).ToRawSqlQuery();
//			var a2 = a1.ToInterpolatedSqlQuery();

//			TestHelpers.AssertAreEqual(TestFilesPath, "TestMethod25-raw-sql", a1.CommandText);
//			Assert.AreEqual(0, a1.Parameters.Count);

//			TestHelpers.AssertAreEqual(TestFilesPath, "TestMethod25-interpolated-sql", a2.CommandText);
//			Assert.AreEqual(0, a2.Values.Length);

//		}

//		[TestMethod]
//		public void TestMethod26()
//		{
//			MyContext db = new MyContext();
//			var a1 = db.tblAppMember.Where(o => o.AppMemberID > 2534 && !string.IsNullOrEmpty(o.FirstName)).ToRawSqlQuery();
//			TestHelpers.AssertAreEqual(TestFilesPath, "TestMethod26-raw-sql", a1.CommandText);
//		}

//		[TestMethod]
//		public void TestMethod27()
//		{
//			MyContext db = new MyContext();
//			var a1 = db.tblAppMember.Where(o => o.AppMemberID > 2534 && !string.IsNullOrWhiteSpace(o.FirstName)).ToRawSqlQuery();
//			TestHelpers.AssertAreEqual(TestFilesPath, "TestMethod27-raw-sql", a1.CommandText);
//		}


//	}
//}
