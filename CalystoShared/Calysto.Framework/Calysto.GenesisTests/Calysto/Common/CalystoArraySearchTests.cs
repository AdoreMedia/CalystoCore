using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text;

namespace Calysto.Common.Tests
{
	[TestClass()]
	public class CalystoArraySearchTests
	{
		string _source = @"sdirliiepu---twe--<-<----<--tewq-----><r3214--fsda..-----<--<---<<-";
		string _pattern = "--<-";
		string _source2 => _pattern + _source + _pattern;

		private byte[] GetBytes(string str) => str == null ? null : Encoding.UTF8.GetBytes(str);
		private string GetString(byte[] data) => data == null ? null : Encoding.UTF8.GetString(data);

		private byte[] Source => GetBytes(_source);
		private byte[] Source2 => GetBytes(_source2);
		private byte[] Pattern => GetBytes(_pattern);

		[TestMethod()]
		public void PatternAtTest()
		{
			var list = CalystoArraySearch.PatternAt(this.Source, this.Pattern).ToList();
			string res1 = string.Join(", ", list);
			string expect1 = "16, 23, 55";
			Assert.AreEqual(expect1, res1);
		}

		[TestMethod()]
		public void PatternAtTest2()
		{
			var list = CalystoArraySearch.PatternAt(this.Source2, this.Pattern).ToList();
			string res1 = string.Join(", ", list);
			string expect1 = "0, 20, 27, 59, 71";
			Assert.AreEqual(expect1, res1);
		}

		[TestMethod()]
		public void SplitByPatternTest()
		{
			var list = CalystoArraySearch.SplitByPattern(this.Source, this.Pattern).Select(o => GetString(o)).ToList();
			string res1 = string.Join("[@@@]", list);
			string expect1 = "sdirliiepu---twe[@@@]<--[@@@]-tewq-----><r3214--fsda..---[@@@]-<---<<-";
			Assert.AreEqual(expect1, res1);
			Assert.AreEqual(_source, expect1.Replace("[@@@]", _pattern));
		}

		[TestMethod()]
		public void SplitByPatternTest2()
		{
			var list = CalystoArraySearch.SplitByPattern(this.Source2, this.Pattern).Select(o => GetString(o)).ToList();
			string res1 = string.Join("[@@@]", list);
			string expect1 = "[@@@]sdirliiepu---twe[@@@]<--[@@@]-tewq-----><r3214--fsda..---[@@@]-<---<<-[@@@]";
			Assert.AreEqual(expect1, res1);
			Assert.AreEqual(_source2, expect1.Replace("[@@@]", _pattern));
		}

		[TestMethod()]
		public void IndexOfPatternTest1()
		{
			int index1 = CalystoArraySearch.IndexOfPattern(this.Source, this.Pattern);
			Assert.AreEqual(16, index1);
		}

		[TestMethod()]
		public void IndexOfPatternTest2()
		{
			int index1 = CalystoArraySearch.IndexOfPattern(this.Source, this.Pattern, 16);
			Assert.AreEqual(16, index1);
		}

		[TestMethod()]
		public void IndexOfPatternTest3()
		{
			int index1 = CalystoArraySearch.IndexOfPattern(this.Source, this.Pattern, 17);
			Assert.AreEqual(23, index1);
		}

		[TestMethod()]
		public void IndexOfPatternTest4()
		{
			int index1 = CalystoArraySearch.IndexOfPattern(this.Source, Encoding.UTF8.GetBytes("eqetwr"), 17);
			Assert.AreEqual(-1, index1);
		}

		[TestMethod()]
		public void IndexOfPatternTest5()
		{
			int index1 = CalystoArraySearch.IndexOfPattern(this.Source, Encoding.UTF8.GetBytes("eqetwr"), 500);
			Assert.AreEqual(-1, index1);
		}
	}
}