using Calysto.TypeLite;
using Calysto.Web.Script.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalystoWebTests.Calysto.TypeLite.Model
{
	public class MessageItem2
	{
		public string Name { get; set; }
	}

	[TsClass]
	public class MyAsyncFunctions2
	{
		[CalystoWebMethod]
		public async Task<IEnumerable<string>> AreYouReady2Async()
		{
			await Task.CompletedTask;
			throw new NotImplementedException();
		}

		[CalystoWebMethod]
		public Task<IEnumerable<string>> AreYouReady3Async()
		{
			throw new NotImplementedException();
		}

		[CalystoWebMethod]
		public IEnumerable<string> AreYouReady4Async()
		{
			throw new NotImplementedException();
		}

		[CalystoWebMethod]
		public async Task<IEnumerable<MessageItem2>> AreYouReady5Async()
		{
			await Task.CompletedTask;
			throw new NotImplementedException();
		}
	}
}
