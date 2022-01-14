using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calysto.Data;
using Calysto.Genesis.UnitTests.Database;
using System.Data.SqlClient;
using Calysto.Data.Direct;
using Calysto.Genesis.Tests.Database;
using Calysto.Genesis.Tests.EnvDTE;
using Calysto.UnitTesting;
using System.IO;

// version 1 333

namespace System.Data.Tests
{
	[TestClass()]
	public class CSVDocumentTests
	{
		string _rootDir = $@"Calysto\Data\TestFiles\";

		[TestMethod()]
		public void EncodeAndDecodeCSV()
		{
			Threading.Thread.CurrentThread.CurrentCulture = Globalization.CultureInfo.InvariantCulture; // for DateTime formating

			SqlConnection conn = new SqlConnection(DatabaseConstants.MSSqlConnectionString);
			DbDirectContext cx = new DbDirectContext(conn);

			var dt = cx.ExecuteDataSet($"select * from {nameof(tblAppMember)}");
			string csv1 = CsvDocument.FromDataTable(dt.Tables[0], true).ToCsvString();

			TestFilesProvider2 provider1 = new TestFilesProvider2(Path.Join(_rootDir, "EncodeAndDecodeCSV1.csv"));
			provider1.Assert(Assert.AreEqual, csv1);

			TestFilesProvider2 provider2 = new TestFilesProvider2(Path.Join(_rootDir, "EncodeAndDecodeCSV2.csv"));
			string csv2 = CsvDocument.FromCsvString(csv1).Skip(2).Take(1).ToCsvString();
			provider2.Assert(Assert.AreEqual, csv2);
		}
	}
}
