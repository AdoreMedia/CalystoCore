//#if DEBUG
namespace Calysto.Tasks
{
	Calysto.TestTools.TestRunner.AddTest(async () =>
	{
		async function PromiseTest(promiseName, promiseCtor)
		{
			// firefox doesn't work if delay is less than 100 ms (sport je pa se eventi preklope)
			let t1 = 200;

			let result1: string[] = [];

			async function GetName()
			{
				return new promiseCtor((resolve, reject) =>
				{
					result1.push("#1");
					//throw new Error("greska");
					setTimeout(() => resolve("success1"), t1);
					//setTimeout(() => resolve("success2"), 1500);
					//setTimeout(() => reject("success3"), 2000);
				})
					.then(value =>
					{
						result1.push("#2");
						result1.push(value);
						//console.log("then: " + value);
						return value;
					})
					.then(value =>
					{
						result1.push("#3");
						result1.push(value);
						//console.log("then2: " + value);
						return new promiseCtor((resolve, reject) =>
						{
							setTimeout(() =>
							{
								result1.push("#4");
								resolve("success2222");
							}, t1);
						});
					})
					.then(value =>
					{
						result1.push("#5");
						result1.push(value);

						//console.log("then2: " + value);
						return new promiseCtor((resolve, reject) =>
						{
							setTimeout(() =>
							{
								result1.push("#6");
								resolve("success1111");
							}, t1);
						});
					})
					.catch(err =>
					{
						result1.push("#7");
						result1.push(err);
						//console.log("catch: " + err);
						return "dva";//err;
					})
					.finally(() =>
					{
						result1.push("#8");
						//console.log("finally");
						return "amd";
					})
			}

			async function ShowResult()
			{
				//console.log("point1");
				let res1 = await GetName();
				result1.push(res1);
				//console.log("result: " + res1);
			}

			result1.push("s0");

			ShowResult();

			result1.push("s1");
			setTimeout(() =>
			{
				let str1 = result1.ToStringJoined(", ");
				Calysto.TestTools.UnitTesting.Assert.AreEqual("s0, #1, s1, s2, s3, #2, success1, #3, success1, #4, #5, success2222, #6, #8, success1111", str1);
				console.log(promiseName + " test successful");
			}, t1 * 3.5);

			result1.push("s2");
			setTimeout(() =>
			{
				let str1 = result1.ToStringJoined(", ");
				Calysto.TestTools.UnitTesting.Assert.AreEqual("s0, #1, s1, s2, s3, #2, success1, #3, success1, #4, #5, success2222", str1);
			}, t1 * 2.5);

			result1.push("s3");
			setTimeout(() =>
			{
				let str1 = result1.ToStringJoined(", ");
				Calysto.TestTools.UnitTesting.Assert.AreEqual("s0, #1, s1, s2, s3", str1);
			}, t1 * 0.5);

			return new promiseCtor((resolve) =>
			{
				setTimeout(() => resolve(), t1 * 4);
			});
		}

		await PromiseTest("CPromise", CPromise);

		await PromiseTest("Promise", window.Promise);

	});
}
//#endif
