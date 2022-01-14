#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace Calysto.Linq.Tests
{
	[TestClass()]
	public class SelectParallelExtensionsTests
	{
		IEnumerable<string> GetCollectionValues()
		{
			for(int n1 = 0; n1 < 100; n1++)
			{
				//Trace.WriteLine($"GetCollectionValues-thr-{Thread.CurrentThread.Name}");
				yield return $"GetCollectionValues-{n1}-thr-{Thread.CurrentThread.Name}-{DateTime.Now.ToString("HH:mm:ss.ffffff")}";
			}
		}

		[TestMethod()]
		public void SelectParallelTest001()
		{
			// trajanje cca 6 sekundi
			Task.Run(async () =>
			{
				var query1 = GetCollectionValues().Select((o,n)=>new {item=o, index = n }).SelectParallel3(async s =>
				{
					await Task.Delay(10);
					return new { s, res = "e1-" + s };

				}, 20, 0).SelectParallel3(async s=>new { s, res = "e2-" + s }, 20, 0).SelectParallel3(async s=>new { s, res = "e3-" + s }, 50, 50);

				int cnt1 = 0;
				foreach (var item in query1.OrderBy(o=>o.s.s.s.index))
				{
					Trace.WriteLine($"Final: {cnt1++} {item.s.s.s.item}");
				}
			}).Wait();
		}

		[TestMethod()]
		public void SelectParallelTest002()
		{
			// trajanje cca 6 sekundi
			Task.Run(async () =>
			{
				var query1 = GetCollectionValues().Select((o, n) => new { item = o, index = n }).SelectParallel3(async s =>
				{
					await Task.Delay(10);
					return new { s, res = "e1-" + s };
				}, 20, 0).SelectParallel3(s => Task.Run(()=> new { s, res = "e2-" + s }), 20, 0).SelectParallel3(s => new { s, res = "e3-" + s }, 50, 50);

				int cnt1 = 0;
				foreach (var item in query1.OrderBy(o => o.s.s.s.index))
				{
					Trace.WriteLine($"Final: {cnt1++} {item.s.s.s.item}");
				}
			}).Wait();
		}

		[TestMethod()]
		public void SelectParallelTest003()
		{
			// trajanje cca 2 sekunde
			Task.Run(async () =>
			{
				var query1 = GetCollectionValues().SelectParallel3(async s =>
				{
					await Task.Delay(10);
					return s;
				}, 50);

				int cnt1 = 0;
				foreach (var item in query1)
				{
					Trace.WriteLine($"Final: {cnt1++} {item}");
				}

			}).Wait();
		}

		[TestMethod()]
		public void SelectParallelTest004()
		{
			// trajanje cca 300 ms
			Task.Run(() =>
			{
				var query1 = GetCollectionValues().SelectParallel3(async s =>
				{
					await Task.Delay(10);
					return s;
				}, 50);

				int cnt1 = 0;
				foreach (var item in query1)
				{
					Trace.WriteLine($"Final: {cnt1++} {item}");
				}

			}).Wait();
		}


	}
}
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
