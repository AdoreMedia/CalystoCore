using Calysto.TypeLite;
using Calysto.Web.Script.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalystoWebTests.Calysto.TypeLite.Model
{
	[TsClass]
	public class MyAsyncFunctions
	{
		[CalystoWebMethod]
		public Task DoWorkTask()
		{
			return Task.CompletedTask;
		}

		[CalystoWebMethod]
		public async Task DoWorkAsync()
		{
			await Task.CompletedTask;
		}

		[CalystoWebMethod]
		public Task<bool> AreYouReadyTask()
		{
			return Task.FromResult(true);
		}

		[CalystoWebMethod]
		public async Task<bool> AreYouReadyAsync()
		{
			return await Task.FromResult(true);
		}

	}
}
