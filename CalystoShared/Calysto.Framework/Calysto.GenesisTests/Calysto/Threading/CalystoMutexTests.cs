using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calysto.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Calysto.Threading.Tasks;

namespace Calysto.Threading.Tests
{
	[TestClass()]
	public class CalystoMutexTests
	{
		const int _time1 = 10;

		private Thread StartBackgroundThread(Action action) => new Thread(()=>action()).StartBackground();

		[TestMethod()]
		public void WaitManyTest1()
		{
			CalystoMutex mutex1 = new CalystoMutex(3);
			List<string> results = new List<string>();
			Task.Run(() =>
			{
				Thread th1 = StartBackgroundThread(() => { Thread.Sleep(_time1 * 8); results.Add("th1"); mutex1.ReleaseOne(); });
				Thread th2 = StartBackgroundThread(() => { Thread.Sleep(_time1 * 2); results.Add("th2"); mutex1.ReleaseOne(); });
				Thread th3 = StartBackgroundThread(() => { Thread.Sleep(_time1 * 4); results.Add("th3"); mutex1.ReleaseOne(); });
				Thread th4 = StartBackgroundThread(() => { Thread.Sleep(_time1 * 6); results.Add("th4"); mutex1.ReleaseOne(); });
			});

			if (!mutex1.Wait(TimeSpan.FromSeconds(21)))
				throw new TimeoutException();

			Assert.AreEqual("th2, th3, th4, th1", string.Join(", ", results));
		}

		[TestMethod()]
		public void WaitManyTest2()
		{
			CalystoMutex mutex1 = new CalystoMutex(3);
			List<string> results = new List<string>();
			Task.Run(() =>
			{
				Thread th1 = StartBackgroundThread(() => { Thread.Sleep(_time1 * 10); results.Add("th1"); mutex1.ReleaseOne(); });
				Thread th2 = StartBackgroundThread(() => { Thread.Sleep(_time1 * 2); results.Add("th2"); mutex1.ReleaseOne(); });
				Thread th3 = StartBackgroundThread(() => { Thread.Sleep(_time1 * 4); results.Add("th3"); mutex1.ReleaseOne(); });
				Thread th4 = StartBackgroundThread(() => { Thread.Sleep(_time1 * 8); results.Add("th4"); mutex1.ReleaseOne(); });
			});

			if (!mutex1.Wait(TimeSpan.FromSeconds(2)))
				throw new TimeoutException();

			Assert.AreEqual("th2, th3, th4, th1", string.Join(", ", results));
		}

		[TestMethod()]
		public void WaitManyTest3()
		{
			CalystoMutex mutex1 = new CalystoMutex(1);
			List<string> results = new List<string>();
			Task.Run(() =>
			{
				Thread th1 = StartBackgroundThread(() => { Thread.Sleep(_time1 * 5); results.Add("th1"); mutex1.ReleaseOne(); });
				Thread th4 = StartBackgroundThread(() => { Thread.Sleep(_time1 * 4); results.Add("th4"); mutex1.ReleaseOne(); });
			});

			if (!mutex1.Wait(TimeSpan.FromSeconds(1)))
				throw new TimeoutException();

			Assert.AreEqual("th4, th1", string.Join(", ", results));
		}


	}
}