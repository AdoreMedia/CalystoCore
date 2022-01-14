using Calysto.TypeLite;
using Calysto.Web.Script.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalystoWebTests.Calysto.TypeLite.Model
{
	[TsClass]
	public partial class ServiceOne
	{
		[CalystoWebMethod]
		public Dictionary<int, string> GetPrometItems(int skip, int take, Dictionary<string, int> keys1, Dictionary<string, string> keys2)
		{
			return new Dictionary<int, string>();
		}
	}
}

