using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calysto.Net.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calysto.Net.Authorization.Tests
{
	[TestClass()]
	public class BasicAuthorizationTests
	{
		[TestMethod()]
		public void TryDecodeTest1()
		{
			BasicAuthorization basic = new BasicAuthorization();
			basic.Username = "Tomas";
			basic.Password = "Mores";

			string res1 = basic.EncodeToString();
			Assert.AreEqual("Basic VG9tYXM6TW9yZXM=", res1);

			bool res2 = BasicAuthorization.TryDecode(res1, out BasicAuthorization res5);
			Assert.IsTrue(res2);
			Assert.AreEqual(basic.Username, res5.Username);
			Assert.AreEqual(basic.Password, res5.Password);
		}

		[TestMethod()]
		public void TryDecodeTest2()
		{
			BasicAuthorization basic = new BasicAuthorization();
			basic.Username = "Tomas";
			basic.Password = "Mores";

			string res1 = basic.EncodeToString();
			Assert.AreEqual("Basic VG9tYXM6TW9yZXM=", res1);

			bool res2 = BasicAuthorization.TryDecode(res1 + "m5", out BasicAuthorization res5);
			Assert.IsFalse(res2);
			Assert.IsNull(res5);
		}
	}
}
