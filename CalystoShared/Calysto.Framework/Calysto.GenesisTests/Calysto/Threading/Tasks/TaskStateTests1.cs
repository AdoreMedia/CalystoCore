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
	public class TaskStateTests1
	{
		[TestMethod()]
		public void TaskTest1()
		{
			List<string> results = new List<string>();
			Test1(results).Wait();

			string res1 = string.Join(", ", results);
			string exp1 = "#0, #1: cancelled1, #3: True";
			Assert.AreEqual(exp1, res1);
		}

		private async Task Test1(List<string> results)
		{
			var token = new CancellationTokenSource(50);

			results.Add("#0");

			string res1 = await Task.Run(async () =>
			{
				if (!token.IsCancellationRequested)
					await TaskUtility.SleepAsync(100);

				if (token.IsCancellationRequested)
					return "cancelled1";
				else
					return "success1";
			});

			results.Add("#1: " + res1);

			bool res3 = await Task.Run(async () =>
			{
				await TaskUtility.SleepAsync(50);
				return true;
			});

			results.Add("#3: " + res3);
		}

	}
}
