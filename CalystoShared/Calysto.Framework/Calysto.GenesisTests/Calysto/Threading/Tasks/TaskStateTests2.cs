using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calysto.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Calysto.Threading.Tasks.Tests
{
	[TestClass()]
	public class TaskStateTests2
	{
		const int _time = 50;

		[TestMethod()]
		public void TaskTest1()
		{
			List<string> results = new List<string>();
			Test2(results).Wait();

			string res1 = string.Join(", ", results);
			string exp1 = "#0, #1, #3, no1, yes2, all done";
			Assert.AreEqual(exp1, res1);
		}

		private async Task Test2(List<string> results)
		{
			var token = new CancellationTokenSource(_time);

			results.Add("#0");

			var res1 = Task.Run(async () =>
			{
				if (!token.IsCancellationRequested)
					await TaskUtility.SleepAsync(_time * 2);

				if (token.IsCancellationRequested)
					return "no1";
				else
					return "yes1";
			});

			results.Add("#1");

			var res3 = Task.Run(async () =>
			{
				await TaskUtility.SleepAsync(_time * 2);
				return "yes2";
			});

			results.Add("#3");

			results.Add(res1.Result);
			results.Add(res3.Result);

			results.Add("all done");

			await Task.CompletedTask;
		}

	}
}
