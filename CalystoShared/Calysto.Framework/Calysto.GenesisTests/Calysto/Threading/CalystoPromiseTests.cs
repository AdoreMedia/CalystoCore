//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System;
//using System.Linq;
//using System.Threading.Tasks;
//using Calysto.Linq;
//using System.Threading;

//namespace Calysto.Threading.Tests
//{
//	[TestClass()]
//	public class CalystoPromiseTests
//	{
//		[TestMethod()]
//		public void ThenTest1()
//		{
//			var res1 = new CalystoPromise<string>().Run(state => state.Success("first-result"))
//				.Then<int>((state, data) => state.Success(234))
//				.Then<string>((state, data) => state.Success("previous: " + data))
//				.Result();

//			Assert.AreEqual("previous: 234", res1);
//		}

//		[TestMethod()]
//		public void ThenTest2()
//		{
//			var res1 = new CalystoPromise<string>().Run(state => state.Success("first-result"))
//				.Then<int>((state, data) => state.Success(234))
//				.Then<string>((state, data) => Task.Run(() =>
//				{
//					Thread.Sleep(100); // sleep
//					state.Success("previous: " + data);
//				}))
//				.Then<int>((state, data) => state.Success(data.Length))
//				.Then<string>((state, data) => state.Success("previous: " + data))
//				.Result();

//			// imidiate results doesn't have the rest of the results since thread is sleeping
//			Assert.AreEqual("previous: 13", res1);
//		}

//		[ExpectedException(typeof(TimeoutException))]
//		[TestMethod()]
//		public void ThenTest3()
//		{
//			var res1 = new CalystoPromise<string>().Run(state => state.Success("first-result"))
//				.Then<int>((state, data) => state.Success(234))
//				.Then<string>((state, data) => Task.Run(() =>
//				{
//					state.Watchdog(50); // kratki timeout, nek skoci exception
//					Thread.Sleep(100); // sleep
//					state.Success("previous: " + data);
//				}))
//				.Then<int>((state, data) => state.Success(data.Length))
//				.Then<string>((state, data) => state.Success("previous: " + data))
//				.Result();

//			Assert.AreEqual("previous: 13", res1);
			
//		}

//	}
//}


