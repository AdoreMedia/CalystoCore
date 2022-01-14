using Calysto.Common;
using Calysto.TypeLite;
using Calysto.Web.Script.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Calysto.Genesis.UnitTest.Calysto.TypeLite.Model
{
	public class MessageItem1
	{
		public string Name { get; set; }
	}

	[TsClass]
	public class HostObject3 : ICalystoWebViewHostObject
	{
		[CalystoWebMethod]
		public List<MessageItem1> GetTranslationMessages1()
		{
			return new List<MessageItem1>();
		}

		public class MessageItem2
		{
			public string Color { get; set; }
		}

		[CalystoWebMethod]
		public bool? Test1(int size, int? wheels, int height = 34, string name = "ivanho", DateTime? birth = null)
		{
			return false;
		}

		[CalystoWebMethod]
		public List<MessageItem2> GetTranslationMessages2()
		{
			return new List<MessageItem2>();
		}

		[CalystoWebMethod]
		public void NoResult(string s1, int num1)
		{
			
		}

		[CalystoWebMethod]
		public int DoSomething(string s1, int num1)
		{
			return 111000 + num1;
		}

		[CalystoWebMethod]
		public string DoNesto(string name)
		{
			return "nesto je " + name;
		}

	}
}
