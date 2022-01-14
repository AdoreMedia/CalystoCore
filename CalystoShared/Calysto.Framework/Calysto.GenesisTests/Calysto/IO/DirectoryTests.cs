using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.IO;
using Calysto.Linq;

namespace Calysto.IO.Tests
{
	[TestClass()]
	public class DirectoryTests
	{
		[TestMethod()]
		public void DirectoryCreateTest1()
		{
			string path1 = @"c:\LOCAL2372426\UniTest4624734\Dva\Tri";
			string path2 = @"c:\LOCAL2372426";

			string root1 = Directory.GetDirectoryRoot(path1);
			Assert.AreEqual("c:\\", root1);

			DirectoryInfo di1 = Directory.CreateDirectory(path1);
			bool res1 = Directory.Exists(path1);
			Assert.IsTrue(res1);

			while (di1 != null && di1.Parent != null)
			{
				di1.Delete(true);
				Assert.IsFalse(Directory.Exists(di1.FullName));
				di1 = di1.Parent;
			}

			bool res2 = Directory.Exists(path2);
			Assert.IsFalse(res2);

		}

		[TestMethod()]
		public void DirectoryCreateTest2()
		{
			string path1 = @"c:\LOCAL6722343\UniTest4624734\Dva\Tri";
			string path2 = @"c:\LOCAL6722343";

			DirectoryInfo di1 = Directory.CreateDirectory(path1);

			var list1 = di1.Ancestors().ToList();
			Assert.AreEqual(3, list1.Count);
			Assert.AreEqual(@"LOCAL6722343\UniTest4624734\Dva", list1.AsEnumerable().Reverse().Select(o => o.Name.Trim('\\')).ToStringJoined("\\"));

			di1.Ancestors(true).ForEach(o => o.Delete(true));
			Assert.IsFalse(Directory.Exists(path2));
		}

		[TestMethod()]
		public void DirectoryCreateTest3()
		{
			string path1 = @"c:\LOCAL6722343\UniTest4624734\Dva\Tri";
			string path2 = @"c:\LOCAL6722343";

			DirectoryInfo di1 = Directory.CreateDirectory(path1);

			var list2 = di1.Ancestors(false, true).ToList();
			Assert.AreEqual(4, list2.Count);
			Assert.AreEqual(@"c:\LOCAL6722343\UniTest4624734\Dva", list2.AsEnumerable().Reverse().Select(o => o.Name.Trim('\\')).ToStringJoined("\\"));

			di1.Ancestors(true).ForEach(o => o.Delete(true));
			Assert.IsFalse(Directory.Exists(path2));
		}

		[TestMethod()]
		public void DirectoryCreateTest4()
		{
			string path1 = @"c:\LOCAL6722343\UniTest4624734\Dva\Tri";
			string path2 = @"c:\LOCAL6722343";

			DirectoryInfo di1 = Directory.CreateDirectory(path1);

			var list2 = di1.Ancestors(true, false).ToList();
			Assert.AreEqual(4, list2.Count);
			Assert.AreEqual(@"LOCAL6722343\UniTest4624734\Dva\Tri", list2.AsEnumerable().Reverse().Select(o => o.Name.Trim('\\')).ToStringJoined("\\"));

			di1.Ancestors(true).ForEach(o => o.Delete(true));
			Assert.IsFalse(Directory.Exists(path2));
		}

		[TestMethod()]
		public void DirectoryCreateTest5()
		{
			string path1 = @"c:\LOCAL6722343\UniTest4624734\Dva\Tri";
			string path2 = @"c:\LOCAL6722343";

			DirectoryInfo di1 = Directory.CreateDirectory(path1);

			var list2 = di1.Ancestors(true, true).ToList();
			Assert.AreEqual(5, list2.Count);
			Assert.AreEqual(@"c:\LOCAL6722343\UniTest4624734\Dva\Tri", list2.AsEnumerable().Reverse().Select(o => o.Name.Trim('\\')).ToStringJoined("\\"));

			di1.Ancestors(true).ForEach(o => o.Delete(true));
			Assert.IsFalse(Directory.Exists(path2));
		}

		[TestMethod()]
		public void DirectoryCreateTest6()
		{
			string path1 = @"c:\LOCAL6722343\UniTest4624734\Dva\Tri";
			string path2 = @"c:\LOCAL6722343";

			DirectoryInfo di1 = Directory.CreateDirectory(path1);
			DirectoryInfo di2 = new DirectoryInfo(path2);

			var list2 = di2.Descendants(true).ToList();
			Assert.AreEqual(4, list2.Count);
			Assert.AreEqual(@"LOCAL6722343\UniTest4624734\Dva\Tri", list2.AsEnumerable().Select(o => o.Name.Trim('\\')).ToStringJoined("\\"));

			di1.Ancestors(true).ForEach(o => o.Delete(true));
			Assert.IsFalse(Directory.Exists(path2));
		}

		[TestMethod()]
		public void DirectoryCreateTest7()
		{
			string path1 = @"c:\LOCAL6722343\UniTest4624734\Dva\Tri";
			string path2 = @"c:\LOCAL6722343";
			string path3 = @"c:\LOCAL6722343\Test1234\One\Two\";
			string path4 = @"c:\LOCAL6722343\Test1234\One\Pet\Nesto\";

			DirectoryInfo di1 = Directory.CreateDirectory(path1);
			DirectoryInfo di2 = new DirectoryInfo(path2);
			DirectoryInfo di3 = Directory.CreateDirectory(path3);
			DirectoryInfo di4 = Directory.CreateDirectory(path4);

			var list2 = di2.Descendants(true).ToList();
			Assert.AreEqual(9, list2.Count);
			Assert.AreEqual(@"LOCAL6722343\Test1234\One\Pet\Nesto\Two\UniTest4624734\Dva\Tri", list2.AsEnumerable().Select(o => o.Name.Trim('\\')).ToStringJoined("\\"));

			di1.Ancestors(true).ForEach(o => o.Delete(true));
			Assert.IsFalse(Directory.Exists(path2));
		}

	}
}
