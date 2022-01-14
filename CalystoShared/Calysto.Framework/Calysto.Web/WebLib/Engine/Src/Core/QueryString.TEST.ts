//#if DEBUG
Calysto.TestTools.TestRunner.AddTest(() =>
{
	var aa1 = new Calysto.QueryString("http://toolnix.com/widgetcontent?marker=1&balloon=0&width=400&height=200&mid=2004&sig=fsdaf");
	var res1 = aa1.GetUrl();
	if ("http://toolnix.com/widgetcontent?marker=1&balloon=0&width=400&height=200&mid=2004&sig=fsdaf" != res1)
	{
		throw new Error("Calysto.QueryString #1 selftest error. Result: " + res1 + ", expected: " + "http://toolnix.com/widgetcontent?marker=1&balloon=0&width=400&height=200&mid=2004&sig=fsdaf");
	}

	var aa1 = new Calysto.QueryString("http://toolnix.com/widgetcontent");
	var res1 = aa1.GetUrl();
	if ("http://toolnix.com/widgetcontent" != res1)
	{
		throw new Error("Calysto.QueryString #2 selftest error. Result: " + res1 + ", expected: " + "http://toolnix.com/widgetcontent");
	}

	var aa1 = new Calysto.QueryString("http://toolnix.com/widgetcontent?marker=1&balloon=0&width=400&height=200&mid=2004&#fasdf#fasdf");
	aa1.SetValue("mmm", 1043);
	aa1.RemoveValue("balloon");
	var res1 = aa1.GetUrl();
	if ("http://toolnix.com/widgetcontent?marker=1&width=400&height=200&mid=2004&mmm=1043#fasdf#fasdf" != res1)
	{
		throw new Error("Calysto.QueryString #3 selftest error. Result: " + res1 + ", expected: " + "http://toolnix.com/widgetcontent?marker=1&width=400&height=200&mid=2004&mmm=1043");
	}

	var aa1 = new Calysto.QueryString("http://toolnix.com/widgetcontent?marker=1&balloon=0&width=400&height=200&mid=2004&#fasdf#fasdf");
	aa1.SetValue("mmm", 1043);
	aa1.RemoveValue("balloon");
	var res1 = aa1.GetUrl();
	if ("http://toolnix.com/widgetcontent?marker=1&width=400&height=200&mid=2004&mmm=1043#fasdf#fasdf" != res1)
	{
		throw new Error("Calysto.QueryString #4 selftest error. Result: " + res1 + ", expected: " + "http://toolnix.com/widgetcontent?marker=1&width=400&height=200&mid=2004&mmm=1043#fasdf#fasdf");
	}

	var aa1 = new Calysto.QueryString("http://toolnix.com/widgetcontent?marker=1&balloon=0&width=400&height=200&mid=2004&");
	aa1.SetValue("height", 42353);
	var res1 = aa1.GetUrl();
	if ("http://toolnix.com/widgetcontent?marker=1&balloon=0&width=400&height=42353&mid=2004" != res1)
	{
		throw new Error("Calysto.QueryString #5 selftest error. Result: " + res1 + ", expected: " + "http://toolnix.com/widgetcontent?marker=1&balloon=0&width=400&height=42353&mid=2004");
	}

	console.log("QueryString test successful");

});
//#endif
