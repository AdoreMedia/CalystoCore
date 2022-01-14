////#if DEBUG
//Calysto.TestTools.TestRunner.AddTest(() =>
//{
//	let result1: string[] = [];

//	let promise1 = new Calysto.CalystoPromise<number>()
//		.Run((state) => setTimeout(() => state.Success(123), 300))
//		.Then<string>((state, data) => setTimeout(() =>
//		{
//			result1.Add("res#1");
//			state.Success("naziv-" + data);
//		}, 100))
//		.Then<number>((state, data) =>
//		{
//			state.Watchdog(2000);
//			setTimeout(() =>
//			{
//				result1.Add("res#2");
//				state.Success(data.length);
//			}, 200);
//		})
//		.Then<string>((state, data) =>
//		{
//			result1.Add("res#3");
//			state.Success("ime");
//		})
//		.Then<boolean>((state, data) =>
//		{
//			result1.Add("res#4");
//			console.log("CalystoPromise result: " + data);
//		});


//	setTimeout(() =>
//	{
//		let str1 = result1.ToStringJoined(", ");
//		Calysto.TestTools.UnitTesting.Assert.AreEqual("res#1, res#2, res#3, res#4", str1);
//	}, 1000);


//	let result2: string[] = [];

//	let promise2 = new Calysto.CalystoPromise<string>()
//	.Run(state =>
//	{
//		result2.Add("r#1");
//		state.Success("res");
//	})
//	.Then<number>((state, result) =>
//	{
//		result2.Add("r#2");
//		state.Success(result.length);
//	})
//	.Then<number>((state, result) =>
//	{
//		result2.Add("r#3");
//		state.Success(22);
//	})
//	.Then<string>((state, result) =>
//	{
//		result2.Add("r#4");
//		state.Success("to je to");
//	});

//	setTimeout(() =>
//	{
//		let str2 = result2.ToStringJoined(", ");
//		if (str2 != "r#1, r#2, r#3, r#4")
//			throw new Error("Calysto.CalystoPromise #2 error, result: " + str2);
//	}, 1000);

//});

////#endif