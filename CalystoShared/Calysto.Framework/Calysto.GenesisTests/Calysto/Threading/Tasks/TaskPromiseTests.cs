//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Calysto.Threading.Tasks;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;
//using System.Threading;

//namespace Calysto.Threading.Tasks.Tests
//{
//	[TestClass()]
//	public class TaskPromiseTests
//	{
//		[TestMethod()]
//		public void RunTest1()
//		{
//			var promise = new TaskPromise<bool>(state =>
//			{
//				Task.Run(() =>
//				{
//					Thread.Sleep(500);
//					state(true);
//				});

//			}).Then<string>((last, state) =>
//			{
//				Task.Run(() =>
//				{
//					Thread.Sleep(500);
//					state("done1");
//				});
//			});

//			var res = promise.ResultAsync().Result;
//			Assert.AreEqual("done1", res);
//		}

//		[TestMethod()]
//		public void RunTest2()
//		{
//			Task.Run(async () =>
//			{
//				var promise = new TaskPromise<bool>(state =>
//				{
//					Task.Run(() =>
//					{
//						Thread.Sleep(1000);
//						state(true);
//					});

//				}).Then<string>((last, state) =>
//				{
//					Task.Run(() =>
//					{
//						Thread.Sleep(1000);
//						state("done2");
//					});
//				});

//				var res = await promise.ResultAsync();
//				Assert.AreEqual("done2", res);

//			}).Wait();
//		}
//	}
//}