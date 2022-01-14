//using Calysto.Threading;
//using Calysto.Timers;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace UnitTests.Calysto.Threading
//{
//	[TestClass]
//	public class CalystoPromiseTests2
//	{
//		[TestMethod]
//		public void PromiseTest1()
//		{
//			var promise = new CalystoPromise<int>().Run(state =>
//			{
//				state.Success(1235);
//			})
//			.Then<int>((state, data) =>
//			{
//				state.Success(133);
//			});

//			var promise2 = promise
//			.Then<string>((state, data) =>
//			{
//				Task.Run(() =>
//				{
//					Thread.Sleep(1000);
//					state.Success("fsdf");
//					state.Failed(new Exception("fsda")); // nema efekta jer postoji kontrola da se next pozove samo jednom
//				});
//			})
//			.Then<char>((state, data) =>
//			{
//				Task.Run(() =>
//				{
//					Thread.Sleep(1000);
//					//state.Failed();
//					state.Success('a');
//				});
//			});

//			var result1 = promise2.Result();

//			Assert.AreEqual('a', result1);

//		}

//		private void State_OnFailed(Exception obj)
//		{
			
//		}
//	}
//}
