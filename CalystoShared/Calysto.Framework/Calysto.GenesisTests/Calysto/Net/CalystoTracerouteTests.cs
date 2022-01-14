using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calysto.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calysto.Net.Tests
{
	[TestClass()]
	public class CalystoTracerouteTests
	{
		[TestMethod()]
		[Timeout(10000)]
		public void GetTraceRouteTest()
		{
			var list1 = CalystoTraceroute.GetTraceRoute("google.com").Take(3).ToList();
			Assert.AreEqual(3, list1.Count);
		}
	}
}