using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calysto.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Calysto.Linq.Expressions.Tests
{
	[TestClass()]
	public class MemberAccessorPathExtractorTests
	{
		int IndexValue => 4;
		int IndexValue2 { get { return this.IndexValue; } }
		int GetIndex() => this.IndexValue2;

		[TestMethod()]
		public void BaseTest1()
		{
			var extractor = new MemberPropertyPathExtractor<Driver3>();
			var base1 = extractor.GetExtractor(o => o.D2);
			string res1 = base1.GetPath(o =>o.Owner.Name1);
			Assert.AreEqual("Owner.Name1", res1);

			string res2 = base1.GetPath(o => o.Owner.Name1);
			Assert.AreEqual("Owner.Name1", res2);
		}

		[TestMethod()]
		public void BaseTest2()
		{
			// When collection is List<>: Colors
			var extractor = new MemberPropertyPathExtractor<Driver3>();
			var base1 = extractor.GetExtractor(o => o.D2);

			string res3 = base1.GetPath(o => o.Owner.Colors[2].Naziv);
			Assert.AreEqual("Owner.Colors[2].Naziv", res3);

			int index1 = 3;
			string res4 = base1.GetPath(o => o.Owner.Colors[index1].Naziv);
			Assert.AreEqual("Owner.Colors[3].Naziv", res4);

			string res5 = base1.GetPath(o => o.Owner.Colors[this.IndexValue].Naziv);
			Assert.AreEqual("Owner.Colors[4].Naziv", res5);

			string res6 = base1.GetPath(o => o.Owner.Colors[this.IndexValue2].Naziv);
			Assert.AreEqual("Owner.Colors[4].Naziv", res6);

			string res7 = base1.GetPath(o => o.Owner.Colors[this.GetIndex()].Naziv);
			Assert.AreEqual("Owner.Colors[4].Naziv", res7);
		}

		[TestMethod()]
		public void BaseTest3()
		{
			// when collection is Array[]: Colors2

			var extractor = new MemberPropertyPathExtractor<Driver3>();
			var base1 = extractor.GetExtractor(o => o.D2);

			string res3 = base1.GetPath(o => o.Owner.Colors2[2].Naziv);
			Assert.AreEqual("Owner.Colors2[2].Naziv", res3);

			int index1 = 3;
			string res4 = base1.GetPath(o => o.Owner.Colors2[index1].Naziv);
			Assert.AreEqual("Owner.Colors2[3].Naziv", res4);

			string res5 = base1.GetPath(o => o.Owner.Colors2[this.IndexValue].Naziv);
			Assert.AreEqual("Owner.Colors2[4].Naziv", res5);

			string res6 = base1.GetPath(o => o.Owner.Colors2[this.IndexValue2].Naziv);
			Assert.AreEqual("Owner.Colors2[4].Naziv", res6);

			string res7 = base1.GetPath(o => o.Owner.Colors2[this.GetIndex()].Naziv);
			Assert.AreEqual("Owner.Colors2[4].Naziv", res7);
		}


		class Color1
		{
			public string Naziv;
		}

		class Driver1
		{
			[Display(Name = nameof(Resources.CalystoLabelsResources.BirthDate_Label), ResourceType = typeof(Resources.CalystoLabelsResources))]
			public string Name5;

			public string Name1;
			public string Name3;
			public string Age { get; set; }
			public bool DoSomeWork() { return false; }

			public List<Color1> Colors;

			public Color1[] Colors2;
		}

		class Driver2
		{
			public string Name2;
			public string Name4;
			public string Age2 { get; set; }
			public Driver1 Owner { get; set; }
		}

		class Driver3
		{
			public string Name5 { get; set; }
			public Driver2 D2 { get; set; }
		}
	}
}