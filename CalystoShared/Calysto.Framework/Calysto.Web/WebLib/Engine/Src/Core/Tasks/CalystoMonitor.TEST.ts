//#if DEBUG
namespace Calysto.Tasks
{
	Calysto.TestTools.TestRunner.AddTest(async () =>
	{
		let results1: string[] = [];

		let monitor1 = new Calysto.Tasks.CalystoMonitor<string>();

		async function Test4()
		{
			results1.push("#start");
			let cnt = 0;
			while (cnt++ < 5)
			{
				results1.push("#before:" + cnt)
				results1.push(await monitor1.WaitAsync(200) || "[#]");
				results1.push("#after:" + cnt);
			}
			results1.push("#end");
		}

		async function Test5()
		{
			monitor1.Pulse("[pulse]");
		}

		async function Test6()
		{
			monitor1.PulseAll("[all]");
		}

		let test4 = Test4();

		await Calysto.Tasks.TaskUtility.SleepAsync(300);

		await Test5();

		await Calysto.Tasks.TaskUtility.SleepAsync(100);

		await Test6();

		await test4; // wait to finish

		let exp1 = "#start #before:1 [#] #after:1 #before:2 [pulse] #after:2 #before:3 [all] #after:3 #before:4 [#] #after:4 #before:5 [#] #after:5 #end";
		if (Calysto.TestTools.UnitTesting.Assert.AreEqual(exp1, results1.join(" ")))
			console.log("CalystoMonitor test successful");

	});
}
//#endif
