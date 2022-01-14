//#if DEBUG
Calysto.TestTools.TestRunner.AddTest(() =>
{
	type Func1 = (name: string, age: number, isWhite: boolean) => void;

	let results: any[] = [];
	let OnTest = new Calysto.MulticastDelegate<Func1>().OnAdd((delegate: Func1) =>
	{
		results.push("in_OnAdd");
		delegate("ante", 10, false);
	}).AsFunc({ Prop1: true, Prop2: false });

	OnTest((name, age, isWhite) =>
	{
		results.push("Invocation");
		results.push({ name: name, age: age, isWhite: isWhite });
	});


	OnTest.Invoke(f => f("jura", 22, true));
	OnTest.Invoke(f => f("karmen", 55, false));
	OnTest.Invoke(f => f("junior", 11, true));

	// has to be invokable with 0 arguments, for compatibility with Calysto.Page.OnVersionExpired.Invoke();
	(<any>OnTest).Invoke();

	let res1 = Calysto.Json.Serialize(results);
	if (res1 != `["in_OnAdd","Invocation",{"name":"ante","age":10,"isWhite":false},"Invocation",{"name":"jura","age":22,"isWhite":true},"Invocation",{"name":"karmen","age":55,"isWhite":false},"Invocation",{"name":"junior","age":11,"isWhite":true},"Invocation",{"name":null,"age":null,"isWhite":null}]`)
	{
		throw new Error("Error in Calysto.MulticastDelegate, result1: " + res1);
	}

	console.log("MulticastDelegate test successful");
});
//#endif
