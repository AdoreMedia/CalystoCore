using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calysto.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calysto.Utility.Tests
{
	[TestClass()]
	public class CyrilicConverterTests
	{
		[TestMethod()]
		public void ConvertTextTest01()
		{
			CyrilicConverter converter = new CyrilicConverter();
			string latin1 = "Kako lijepo";
			string cyr1 = converter.ConvertToCyrilic(latin1);
			Assert.AreEqual("Кaко лијепо", cyr1);
			string latin2 = converter.ConvertToLatin(cyr1);
			Assert.AreEqual(latin1, latin2);
		}

		[TestMethod()]
		public void ConvertTextTest02()
		{
			CyrilicConverter converter = new CyrilicConverter();
			string latin1 = "Ovo je LJEpota";
			string cyr1 = converter.ConvertToCyrilic(latin1);
			Assert.AreEqual("Ово је ЉЕпотa", cyr1);
			string latin2 = converter.ConvertToLatin(cyr1);
			Assert.AreEqual(latin1, latin2);
		}

		[TestMethod()]
		public void ConvertTextTest03()
		{
			CyrilicConverter converter = new CyrilicConverter();
			string latin1 = "Nije NJEžnost nježnost za DŽEpove ljepote";
			string cyr1 = converter.ConvertToCyrilic(latin1);
			Assert.AreEqual("Није ЊЕжност њежност зa ЏЕпове љепоте", cyr1);
			string latin2 = converter.ConvertToLatin(cyr1);
			Assert.AreEqual(latin1, latin2);
		}

		[TestMethod()]
		public void ConvertTextTest04()
		{
			CyrilicConverter converter = new CyrilicConverter();
			string latin1 = "Nije nježnost za džepove ljepote";
			string cyr1 = converter.ConvertToCyrilic(latin1);
			Assert.AreEqual("Није њежност зa џепове љепоте", cyr1);
			string latin2 = converter.ConvertToLatin(cyr1);
			Assert.AreEqual(latin1, latin2);
		}
	}
}