using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calysto.Common.Extensions;

namespace Calysto.Utility.Tests
{
	[TestClass()]
	public class UnixTimeConversionTests
	{
		[TestMethod()]
		public void GetDateTimeTest()
		{
			Calysto.Globalization.CalystoCultureInfoHelper.UsingHRCulture(() =>
			{
				var dt1 = UnixTimeConversion.GetUTCDateTime(1534069726691);
				Assert.AreEqual(636696665266910000, dt1.Ticks);
				Assert.AreEqual("2018-08-12T10:28:46.691000", dt1.ToISOTDateTimeString());

				var ticks1 = UnixTimeConversion.GetUnixMilliseconds(dt1);
				Assert.AreEqual(1534069726691, ticks1);

				return true;
			});
		}
	}
}