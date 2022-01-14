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
	public class TaskStateTests3
	{
		const int _time = 10;

		[TestMethod()]
		public void TaskTest1()
		{
			List<string> results = new List<string>();
			Test2(results).Wait();

			string res1 = string.Join(", ", results);
			string exp1 = "#0, #1, #2, #3, success1, success342, yes2, all done";
			Assert.AreEqual(exp1, res1);
		}

		private void DoWork(Action<string> state)
		{
			Task.Run(() =>
			{
				Thread.Sleep(_time * 2);
				state("success342");
			});
		}

		private async Task Test2(List<string> results)
		{
			results.Add("#0");

			var res1 = TaskUtility.CallbackAsync<string>(state =>
			{
				Task.Run(() =>
				{
					Thread.Sleep(_time);
					state("success1");
				});
			}, new CancellationTokenSource(_time * 10).Token);

			results.Add("#1");

			var res2 = TaskUtility.CallbackAsync<string>(state =>
			{
				DoWork(state);
			}, new CancellationTokenSource(_time * 40).Token);

			results.Add("#2");

			var res3 = TaskUtility.CallbackAsync<string>(async state =>
			{
				await TaskUtility.SleepAsync(_time * 10);
				state("yes2");
			});

			results.Add("#3");

			results.Add(res1.Result);
			results.Add(res2.Result);
			results.Add(res3.Result);

			results.Add("all done");

			await Task.CompletedTask;
		}

	}
}
