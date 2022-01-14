using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calysto.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calysto.Threading.Tasks.Tests
{
	[TestClass()]
	public class TaskExtensionsTests
	{
		[TestMethod()]
		public void TimeoutAsyncTest001()
		{
			var task1 = Task.Run(async () =>
			{
				Console.WriteLine("#1");

				await Task.Delay(200);

				Console.WriteLine("#2");
			});

			Task.Run(async () =>
			{
				try
				{
					await task1.TimeoutAsync(100);
				}
				catch(Exception ex)
				{
					Console.WriteLine(ex.ToString());
				}

			}).Wait();

		}
	}
}