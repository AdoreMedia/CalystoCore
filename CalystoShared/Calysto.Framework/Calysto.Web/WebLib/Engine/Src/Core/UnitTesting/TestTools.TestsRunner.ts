namespace Calysto.TestTools.TestRunner
{
	let _tests: (() => void)[] = [];

	export function AddTest(fn: () => void)
	{
		_tests.push(fn);
	}

	export function RunTests()
	{
		setTimeout(async () =>
		{
			for (let fn of _tests)
			{
				await fn();
			}
			let res1 = ">>> UnitTests complete: " + _tests.length;
			console.log(res1);
		});
	}


	if (Calysto.Core.IsTddSpecific)
	{
		Calysto.Page.OnInteractive(() => TestRunner.RunTests());
	}
}