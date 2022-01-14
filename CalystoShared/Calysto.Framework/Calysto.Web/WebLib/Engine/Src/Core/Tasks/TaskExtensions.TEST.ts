//#if DEBUG
namespace Calysto.Tasks
{
	Calysto.TestTools.TestRunner.AddTest(async () =>
	{
		let resAll: boolean[] = [];

		// test1 start
		let results1: any[] = [];

		async function Test1()
		{
			try
			{
				results1.push("#1");
				let res1 = await TaskUtility.CallbackAsync<number>(async (fnResolve) =>
				{
					setTimeout(() => fnResolve(1234), 500);
				}).TimeoutAsync(3000).TimeoutAsync(4000).TimeoutAsync(200);

				results1.push(res1);
			}
			catch (e1)
			{
				results1.push(e1);
			}
		}

		await Test1();

		let exp1 = "#1 Error: Promise timeouted after 200 ms";
		if (Calysto.TestTools.UnitTesting.Assert.AreEqual(exp1, results1.join(" ")))
			resAll.push(true);

		// test2 start
		let results2: any[] = [];

		async function Test2()
		{
			results2.push("#1");
			let res1 = await TaskUtility.CallbackAsync<number>(async (fnResolve) =>
			{
				setTimeout(() => fnResolve(1234), 200);
			}).TimeoutAsync(3000).TimeoutAsync(4000);

			results2.push(res1);
		}

		await Test2();

		let exp2 = "#1 1234";
		if (Calysto.TestTools.UnitTesting.Assert.AreEqual(exp2, results2.join(" ")))
			resAll.push(true);


		if (resAll.length == 2)
			console.log("TaskExtensions test successful");
		else
			console.error("TaskExtensions failed")

	});
}
//#endif
