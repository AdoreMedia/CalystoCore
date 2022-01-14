using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text;

namespace Calysto.Common.Tests
{
	[TestClass]
	public class CalystoArrayBufferTests
	{
		string _source = @"sdirliiepu---twe--<-<----<--tewq-----><r3214--fsda..-----<--<---<<-1sdirliiepu---twe--<-<----<--tewq-----><r3214--fsda..-----<--<---<<-";
		string _pattern = "--<-";
		string _pattern2 = "<-sdir";// proteze se kroz 2 buffera

		private byte[] GetBytes(string str) => str == null ? null : Encoding.UTF8.GetBytes(str);
		private string GetString(byte[] data) => data == null ? null : Encoding.UTF8.GetString(data);
		private string GetString(char[] data) => data == null ? null : string.Join("", data);

		private byte[] Source => GetBytes(_source);
		private byte[] Pattern => GetBytes(_pattern);
		private byte[] Pattern2 => GetBytes(_pattern2);

		[TestMethod]
		public void CompleteTest1()
		{
			CalystoArrayBuffer<byte> ff = new CalystoArrayBuffer<byte>();
			ff.Add(this.Source);
			Assert.AreEqual(135, ff.Available);
			Assert.AreEqual(135, ff.TotalLength);
			Assert.AreEqual(0, ff.Position);

			var res1 = ff.PatternAt(this.Pattern).ToArray();
			Assert.AreEqual("16, 23, 55, 84, 91, 123", string.Join(", ", res1));

			ff.Add(this.Source);
			Assert.AreEqual(270, ff.Available);
			Assert.AreEqual(270, ff.TotalLength);
			Assert.AreEqual(0, ff.Position);

			var res2 = ff.PatternAt(this.Pattern).ToArray();
			Assert.AreEqual("16, 23, 55, 84, 91, 123, 151, 158, 190, 219, 226, 258", string.Join(", ", res2));

			ff.Add(this.Source);
			Assert.AreEqual(405, ff.Available);
			Assert.AreEqual(405, ff.TotalLength);
			Assert.AreEqual(0, ff.Position);

			ff.Position = 0;
			Assert.AreEqual(405, ff.Available);
			Assert.AreEqual(405, ff.TotalLength);
			Assert.AreEqual(0, ff.Position);

			var res4 = ff.PatternAt(this.Pattern2).ToArray();
			Assert.AreEqual("133, 268", string.Join(", ", res4));

			ff.Position = 200;
			Assert.AreEqual(205, ff.Available);
			Assert.AreEqual(405, ff.TotalLength);
			Assert.AreEqual(200, ff.Position);

			var res41 = ff.PatternAt(this.Pattern2).ToArray();
			Assert.AreEqual("268", string.Join(", ", res41));

			ff.TrimStart();
			Assert.AreEqual(205, ff.Available);
			Assert.AreEqual(205, ff.TotalLength);
			Assert.AreEqual(0, ff.Position);

			ff.Position = 25;
			Assert.AreEqual(180, ff.Available);
			Assert.AreEqual(205, ff.TotalLength);

			string str11 = GetString(ff.ToArray());
			Assert.AreEqual("<-1sdirliiepu---twe--<-<----<--tewq-----><r3214--fsda..-----<--<---<<-sdirliiepu---twe--<-<----<--tewq-----><r3214--fsda..-----<--<---<<-1sdirliiepu---twe--<-<----<--tewq-----><r3214--fsda..-----<--<---<<-", str11);

			var res5 = ff.PatternAt(this.Pattern2).ToArray();
			Assert.AreEqual("68", string.Join(", ", res5));

			ff.Position = ff.TotalLength - 1;
			Assert.AreEqual(1, ff.Available);
		}

		[TestMethod]
		public void CompleteParallelTest1()
		{
			CalystoArrayBuffer<byte> ff = new CalystoArrayBuffer<byte>();
			ff.Add(this.Source);
			Assert.AreEqual(135, ff.Available);
			Assert.AreEqual(135, ff.TotalLength);
			Assert.AreEqual(0, ff.Position);

			var res1 = ff.PatternAtParallel(this.Pattern).ToArray();
			Assert.AreEqual("16, 23, 55, 84, 91, 123", string.Join(", ", res1));

			ff.Add(this.Source);
			Assert.AreEqual(270, ff.Available);
			Assert.AreEqual(270, ff.TotalLength);
			Assert.AreEqual(0, ff.Position);

			var res2 = ff.PatternAtParallel(this.Pattern).ToArray();
			Assert.AreEqual("16, 23, 55, 84, 91, 123, 151, 158, 190, 219, 226, 258", string.Join(", ", res2));

			ff.Add(this.Source);
			Assert.AreEqual(405, ff.Available);
			Assert.AreEqual(405, ff.TotalLength);
			Assert.AreEqual(0, ff.Position);

			ff.Position = 0;
			Assert.AreEqual(405, ff.Available);
			Assert.AreEqual(405, ff.TotalLength);
			Assert.AreEqual(0, ff.Position);

			var res4 = ff.PatternAtParallel(this.Pattern2).ToArray();
			Assert.AreEqual("133, 268", string.Join(", ", res4));

			ff.Position = 200;
			Assert.AreEqual(205, ff.Available);
			Assert.AreEqual(405, ff.TotalLength);
			Assert.AreEqual(200, ff.Position);

			var res41 = ff.PatternAtParallel(this.Pattern2).ToArray();
			Assert.AreEqual("268", string.Join(", ", res41));

			ff.TrimStart();
			Assert.AreEqual(205, ff.Available);
			Assert.AreEqual(205, ff.TotalLength);
			Assert.AreEqual(0, ff.Position);

			ff.Position = 25;
			Assert.AreEqual(180, ff.Available);
			Assert.AreEqual(205, ff.TotalLength);

			string str11 = GetString(ff.ToArray());
			Assert.AreEqual("<-1sdirliiepu---twe--<-<----<--tewq-----><r3214--fsda..-----<--<---<<-sdirliiepu---twe--<-<----<--tewq-----><r3214--fsda..-----<--<---<<-1sdirliiepu---twe--<-<----<--tewq-----><r3214--fsda..-----<--<---<<-", str11);

			var res5 = ff.PatternAtParallel(this.Pattern2).ToArray();
			Assert.AreEqual("68", string.Join(", ", res5));

			ff.Position = ff.TotalLength - 1;
			Assert.AreEqual(1, ff.Available);
		}

		[TestMethod]
		public void CompleteTest12()
		{
			// TrimStart tests, kriticno, ne mijenjati nista

			CalystoArrayBuffer<byte> ff = new CalystoArrayBuffer<byte>();
			ff.Add(this.Source);
			Assert.AreEqual(135, ff.Available);
			Assert.AreEqual(135, ff.TotalLength);
			Assert.AreEqual(0, ff.Position);

			// testiranje kako se racuna novi offset kad se nesto trima, tocno ovako mora testirati jer je bio problem kad se nije dobro racunalo relativnu poziciju unutar noda koji je vec imao offset > 0
			ff.Position = 130;
			ff.TrimStart();
			ff.Add(this.Source);
			ff.Position += 2;
			ff.TrimStart();
			ff.Add(GetBytes("andor-dorme-timpb-"));

			string res1 = GetString(ff.ToArray());
			Assert.AreEqual("<<-sdirliiepu---twe--<-<----<--tewq-----><r3214--fsda..-----<--<---<<-1sdirliiepu---twe--<-<----<--tewq-----><r3214--fsda..-----<--<---<<-andor-dorme-timpb-", res1);
		}

		[TestMethod]
		public void CompleteTest2()
		{
			// pattern se proteze kroz 2 buffera
			CalystoArrayBuffer<byte> ff = new CalystoArrayBuffer<byte>();
			ff.Add(GetBytes("dvsa"));
			ff.Add(GetBytes("ds<-s"));
			ff.Add(GetBytes("direw"));
			ff.Add(GetBytes("dvsa"));
			ff.Add(GetBytes("ds<-s"));
			ff.Add(GetBytes("direw"));

			var res3 = ff.PatternAt(GetBytes("<-sdir")).ToArray();
			Assert.AreEqual("6, 20", string.Join(", ", res3));

			ff.Position = 2;
			string res1 = Encoding.UTF8.GetString(ff.Read(14));
			Assert.AreEqual("sads<-sdirewdv", res1);
			Assert.AreEqual(16, ff.Position);
		}

		[TestMethod]
		public void CompleteParallelTest2()
		{
			// pattern se proteze kroz 2 buffera
			CalystoArrayBuffer<byte> ff = new CalystoArrayBuffer<byte>();
			ff.Add(GetBytes("dvsa"));
			ff.Add(GetBytes("ds<-s"));
			ff.Add(GetBytes("direw"));
			ff.Add(GetBytes("dvsa"));
			ff.Add(GetBytes("ds<-s"));
			ff.Add(GetBytes("direw"));

			var res3 = ff.PatternAtParallel(GetBytes("<-sdir")).ToArray();
			Assert.AreEqual("6, 20", string.Join(", ", res3));

			ff.Position = 2;
			string res1 = Encoding.UTF8.GetString(ff.Read(14));
			Assert.AreEqual("sads<-sdirewdv", res1);
			Assert.AreEqual(16, ff.Position);
		}

		[TestMethod]
		public void CompleteTest3()
		{
			CalystoArrayBuffer<byte> ff = new CalystoArrayBuffer<byte>();
			ff.Add(this.Source);
			ff.Add(this.Source);
			ff.Add(this.Source);
			Assert.AreEqual(135 * 3, ff.Available);
			Assert.AreEqual(135 * 3, ff.TotalLength);
			Assert.AreEqual(0, ff.Position);

			ff.Position = 100;
			Assert.AreEqual(135 * 3 - 100, ff.Available);

			ff.Position = 130;
			string res1 = Encoding.UTF8.GetString(ff.Read(20));
			Assert.AreEqual("--<<-sdirliiepu---tw", res1);
			Assert.AreEqual(150, ff.Position);

			ff.Position = 0;
			string res7 = Encoding.UTF8.GetString(ff.Read(ff.Available));
			Assert.AreEqual(_source + _source + _source, res7);
			Assert.AreEqual(ff.TotalLength, ff.Position);

			ff.Position = ff.TotalLength - 1;

			try
			{
				byte[] data1 = ff.Read(800); // should trhow exception
				Assert.Fail();
			}
			catch
			{
			}
		}

		[TestMethod]
		public void CompleteTest4()
		{
			CalystoArrayBuffer<byte> ff = new CalystoArrayBuffer<byte>();
			ff.Add(this.Source);
			ff.Add(this.Source);
			ff.Add(this.Source);
			Assert.AreEqual(135 * 3, ff.Available);
			Assert.AreEqual(135 * 3, ff.TotalLength);
			Assert.AreEqual(0, ff.Position);

			string str11 = GetString(ff.ToArray());
			Assert.AreEqual(_source + _source + _source, str11);

			var res5 = ff.PatternAt(this.Pattern2).ToArray();
			Assert.AreEqual("133, 268", string.Join(", ", res5));

			ff.Position = 2;
			ff.TrimStart();
			string str12 = GetString(ff.ToArray());
			Assert.AreEqual(_source.Substring(2) + _source + _source, str12);

			var res6 = ff.PatternAt(this.Pattern2).ToArray();
			Assert.AreEqual("131, 266", string.Join(", ", res6));

			ff.Position = 142;
			ff.TrimStart();
			string str13 = GetString(ff.ToArray());
			Assert.AreEqual(_source.Substring(9) + _source, str13);

			var res7 = ff.PatternAt(this.Pattern2).ToArray();
			Assert.AreEqual("124", string.Join(", ", res7));

			string res8 = Encoding.UTF8.GetString(ff.ToArray());
			Assert.AreEqual("u---twe--<-<----<--tewq-----><r3214--fsda..-----<--<---<<-1sdirliiepu---twe--<-<----<--tewq-----><r3214--fsda..-----<--<---<<-sdirliiepu---twe--<-<----<--tewq-----><r3214--fsda..-----<--<---<<-1sdirliiepu---twe--<-<----<--tewq-----><r3214--fsda..-----<--<---<<-", res8);

		}

		[TestMethod]
		public void CompleteParallelTest4()
		{
			CalystoArrayBuffer<byte> ff = new CalystoArrayBuffer<byte>();
			ff.Add(this.Source);
			ff.Add(this.Source);
			ff.Add(this.Source);
			Assert.AreEqual(135 * 3, ff.Available);
			Assert.AreEqual(135 * 3, ff.TotalLength);
			Assert.AreEqual(0, ff.Position);

			string str11 = GetString(ff.ToArray());
			Assert.AreEqual(_source + _source + _source, str11);

			var res5 = ff.PatternAtParallel(this.Pattern2).ToArray();
			Assert.AreEqual("133, 268", string.Join(", ", res5));

			ff.Position = 2;
			ff.TrimStart();
			string str12 = GetString(ff.ToArray());
			Assert.AreEqual(_source.Substring(2) + _source + _source, str12);

			var res6 = ff.PatternAtParallel(this.Pattern2).ToArray();
			Assert.AreEqual("131, 266", string.Join(", ", res6));

			ff.Position = 142;
			ff.TrimStart();
			string str13 = GetString(ff.ToArray());
			Assert.AreEqual(_source.Substring(9) + _source, str13);

			var res7 = ff.PatternAtParallel(this.Pattern2).ToArray();
			Assert.AreEqual("124", string.Join(", ", res7));

			string res8 = Encoding.UTF8.GetString(ff.ToArray());
			Assert.AreEqual("u---twe--<-<----<--tewq-----><r3214--fsda..-----<--<---<<-1sdirliiepu---twe--<-<----<--tewq-----><r3214--fsda..-----<--<---<<-sdirliiepu---twe--<-<----<--tewq-----><r3214--fsda..-----<--<---<<-1sdirliiepu---twe--<-<----<--tewq-----><r3214--fsda..-----<--<---<<-", res8);

		}

		char[] _src4 => "--one-three--<<--mk-km--<<".ToCharArray();
		char[] _src5 => "--four-five--<<--six-seven--<<".ToCharArray();
		char[] _patt4 = "<--".ToCharArray();

		[TestMethod]
		public void CompleteTest5()
		{
			CalystoArrayBuffer<char> ff = new CalystoArrayBuffer<char>();
			ff.Add(_src4);
			ff.Add(_src4);
			ff.Add(_src4);
			ff.Add(_src4);
			Assert.AreEqual(104, ff.Available);
			Assert.AreEqual(104, ff.TotalLength);
			Assert.AreEqual(0, ff.Position);

			var res1 = ff.SelectCompleteSegments(_patt4).ToList();
			Assert.AreEqual("--one-three--<@@@mk-km--<@@@one-three--<@@@mk-km--<@@@one-three--<@@@mk-km--<@@@one-three--<", string.Join("@@@", res1.Select(o => GetString(o))));

			Assert.AreEqual(9, ff.Available);
			Assert.AreEqual(104, ff.TotalLength);
			Assert.AreEqual(95, ff.Position);

			ff.TrimStart();
			Assert.AreEqual(9, ff.Available);
			Assert.AreEqual(9, ff.TotalLength);
			Assert.AreEqual(0, ff.Position);

			ff.Add(_src5);
			ff.Add(_src5);
			Assert.AreEqual(69, ff.Available);
			Assert.AreEqual(69, ff.TotalLength);
			Assert.AreEqual(0, ff.Position);

			var res2 = ff.SelectCompleteSegments(_patt4).ToList();
			Assert.AreEqual("mk-km--<@@@four-five--<@@@six-seven--<@@@four-five--<", string.Join("@@@", res2.Select(o => GetString(o))));

			ff.Add(_src4);
			var res3 = ff.SelectCompleteSegments(_patt4).ToList();
			Assert.AreEqual("six-seven--<@@@one-three--<", string.Join("@@@", res3.Select(o => GetString(o))));

			Assert.AreEqual(9, ff.Available);
			Assert.AreEqual(95, ff.TotalLength);
			Assert.AreEqual(86, ff.Position);

			ff.TrimStart();
			Assert.AreEqual(9, ff.Available);
			Assert.AreEqual(9, ff.TotalLength);
			Assert.AreEqual(0, ff.Position);

		}

		private byte[] _smallFile;
		/// <summary>
		/// size "34,479"
		/// </summary>
		private byte[] SmallFile => _smallFile ?? (_smallFile = System.IO.File.ReadAllBytes(@"TestFiles\small.mp4"));

		private byte[] _middleFile;
		/// <summary>
		/// size: "19,701,913"
		/// </summary>
		private byte[] MiddleFile => _middleFile ?? (_middleFile = System.IO.File.ReadAllBytes(@"TestFiles\middle.mp4"));

		private byte[] SmallSearchPattern = new byte[] { 0x01, 0x00, 0x00, 0x26 };
		private byte[] MiddleSearchPattern = new byte[] { 0x66, 0x79, 0x64 };

		[TestMethod]
		public void PerformanceSmallTest1()
		{
			CalystoArrayBuffer<byte> buffer = new CalystoArrayBuffer<byte>();
			Enumerable.Range(0, 10).ToList().ForEach(o => buffer.Add(this.SmallFile));
			var res1 = buffer.PatternAt(this.SmallSearchPattern).ToList();
			Assert.AreEqual(610, res1.Count);
		}

		[TestMethod]
		public void PerformanceSmallParallelTest1()
		{
			CalystoArrayBuffer<byte> buffer = new CalystoArrayBuffer<byte>();
			Enumerable.Range(0, 10).ToList().ForEach(o => buffer.Add(this.SmallFile));
			var res1 = buffer.PatternAtParallel(this.SmallSearchPattern).ToList();
			Assert.AreEqual(610, res1.Count);
		}

		[TestMethod]
		public void PerformanceSmallParallelTest2()
		{
			CalystoArrayBuffer<byte> buffer = new CalystoArrayBuffer<byte>();
			Enumerable.Range(0, 100).ToList().ForEach(o => buffer.Add(this.SmallFile));
			var res1 = buffer.PatternAtParallel(this.SmallSearchPattern).ToList();
			Assert.AreEqual(6100, res1.Count);
		}

		[TestMethod]
		public void PerformanceMiddleTest1()
		{
			CalystoArrayBuffer<byte> buffer = new CalystoArrayBuffer<byte>();
			Enumerable.Range(0, 50).ToList().ForEach(o => buffer.Add(this.MiddleFile));
			var res1 = buffer.PatternAt(this.MiddleSearchPattern).ToList();
			Assert.AreEqual(100, res1.Count);
		}

		[TestMethod]
		public void PerformanceMiddleParallelTest1()
		{
			CalystoArrayBuffer<byte> buffer = new CalystoArrayBuffer<byte>();
			Enumerable.Range(0, 50).ToList().ForEach(o => buffer.Add(this.MiddleFile));
			var res1 = buffer.PatternAtParallel(this.MiddleSearchPattern).ToList();
			Assert.AreEqual(100, res1.Count);
		}

	}
}

