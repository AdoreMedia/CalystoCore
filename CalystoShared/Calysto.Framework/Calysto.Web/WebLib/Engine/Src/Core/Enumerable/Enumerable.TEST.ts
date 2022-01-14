//#if DEBUG
Calysto.TestTools.TestRunner.AddTest(() =>
{

	//var en1 = Calysto.CalystoEnumerator.FromString("ovo je string");

	//var en2 = Calysto.CalystoEnumerator.From([1, 2, 3, 4]);

	//var en4 = new Calysto.CalystoEnumerable(() => Calysto.CalystoEnumerator.FromString("ovo je moj string"));
	//console.log(en4.Select(o => o).ToArray());
	//console.log(en4.ToArray());
	//console.log(en4.ToStringJoined("-"));

    var res1 = [{ Ime: "ante", Godine: [1, 2, 3, 4] }, { Ime: "ante2", Godine: [13, 2, 3, 4] }, { Ime: "ante", Godine: [5, 43, 4] }].AsEnumerable().SelectMany(o => o.Godine).ToArray();

    var res2 = ["fsdagasd", "fdder", "ff", "tt", "oc", "one", "one", "one", "two", "two", "nemza", "temza", "aa", "bb", "cc"]
        .AsEnumerable()
        //.Distinct()
        .OrderBy(o => o.length, true)
        .ThenBy(o => o, true)
        .ThenBy(o => o.length, true)
        //.GroupBy(o => o.length)
        //.Select(o => "Key: " + o.Key + ", Values: [" + o.ToStringJoined(", ") + "]")
        .Skip(1).Take(4)
        .ToStringJoined("; ");

	console.log("CalystoEnumerable test successful");
});
//#endif
