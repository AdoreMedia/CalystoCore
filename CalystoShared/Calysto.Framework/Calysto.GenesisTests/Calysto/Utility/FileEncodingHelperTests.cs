using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace Calysto.Utility.Tests
{
	[TestClass()]
	public class FileEncodingHelperTests
	{
		const string _expected1 = "<div>nn</div>";

		[TestMethod]
		public void EncodeToBytesTest1()
		{
			byte[] data1 = FileEncodingHelper.EncodeToBytes(_expected1);
			string res1 = FileEncodingHelper.DecodeToString(data1);
			Assert.AreEqual(_expected1, res1);
		}

		[TestMethod]
		public void EncodeToBytesTest2()
		{
			byte[] data1 = FileEncodingHelper.EncodeToBytes(_expected1, Encoding.ASCII);
			string res1 = FileEncodingHelper.DecodeToString(data1);
			Assert.AreEqual(_expected1, res1);
		}

		[TestMethod]
		public void EncodeToBytesTest3()
		{
			byte[] data1 = FileEncodingHelper.EncodeToBytes(_expected1, Encoding.BigEndianUnicode);
			string res1 = FileEncodingHelper.DecodeToString(data1);
			Assert.AreEqual(_expected1, res1);
		}

		////[TestMethod]
		////public void EncodeToBytesTest4()
		////{
		////	byte[] data1 = FileEncodingHelper.EncodeToBytes(_expected1, Encoding.Default); // system default, moze varirati od sistema do sistema
		////	string res1 = FileEncodingHelper.DecodeToString(data1);
		////	Assert.AreEqual(_expected1, res1);
		////}

		[TestMethod]
		public void EncodeToBytesTest5()
		{
			byte[] data1 = FileEncodingHelper.EncodeToBytes(_expected1, Encoding.Unicode);
			string res1 = FileEncodingHelper.DecodeToString(data1);
			Assert.AreEqual(_expected1, res1);
		}

		[TestMethod]
		public void EncodeToBytesTest6()
		{
			byte[] data1 = FileEncodingHelper.EncodeToBytes(_expected1, Encoding.UTF32);
			string res1 = FileEncodingHelper.DecodeToString(data1);
			Assert.AreEqual(_expected1, res1);
		}

		////[TestMethod]
		////public void EncodeToBytesTest7()
		////{
		////	byte[] data1 = FileEncodingHelper.EncodeToBytes(_expected1, Encoding.UTF7); // UTF7 nema BOM, autodetekcija nije moguca
		////	string res1 = FileEncodingHelper.DecodeToString(data1);
		////	Assert.AreEqual(_expected1, res1);
		////}

		[TestMethod]
		public void EncodeToBytesTest8()
		{
			byte[] data1 = FileEncodingHelper.EncodeToBytes(_expected1, Encoding.UTF8);
			string res1 = FileEncodingHelper.DecodeToString(data1);
			Assert.AreEqual(_expected1, res1);
		}
	}
}