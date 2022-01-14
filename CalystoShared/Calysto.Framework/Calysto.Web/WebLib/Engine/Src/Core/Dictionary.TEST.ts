//#if DEBUG
Calysto.TestTools.TestRunner.AddTest(() =>
{
	var dic: Calysto.Dictionary<any, any> = new Calysto.Dictionary();
    dic.Add("dva", "fasdf");
    dic.Add(1, 3);
    dic.Add(5, 342352362344237623453734);
    dic.Add(51, 344237623453734);
    dic.Add(true, 344237623453734);
    dic.Add(false, 344237623453734);
    //dic.Add(() => { }, "novi");
    //dic.Add(() => { }, "novi");
    //dic.Add(() => { }, "novi");
    //dic.Add(() => { }, "novi");
    //console.log(dic.GetKeys());
    //console.log(dic.GetHashKeys()); // hash se mijenja za ref objekte, kao funkcije
    //console.log(dic.GetValues());
    //console.log(dic.GetItems());

	var res1 = [
		dic.Count(),
		dic.GetValue(5),
		dic.ContainsKey(51),
		dic.ContainsKey("51"),
		dic.GetKeys().join(","),
		dic.GetValues().join(",")
	].join(";");

	let exp1 = "6;3.423523623442376e+23;true;false;dva,1,5,51,true,false;fasdf,3,3.423523623442376e+23,344237623453734,344237623453734,344237623453734";

	Calysto.TestTools.UnitTesting.Assert.AreEqual(exp1, res1);

	var dic2: Calysto.Dictionary<string, string> = new Calysto.Dictionary();
	dic2.Add("name", "first").Add("last", "lastname");
	var res2 = [
		dic2.Count(),
		dic2.GetValues().join(","),
		dic2.GetKeys().join(",")
	].join(";");

	Calysto.TestTools.UnitTesting.Assert.AreEqual("2;first,lastname;name,last", res2);

	console.log("Dictionary test successful");

});
//#endif
