//#if DEBUG
Calysto.TestTools.TestRunner.AddTest(() =>
{
	var str = "fasdg423675wefdfhuioyfasdyqpoeriu7234rfdsdhlkj6rfa234fdashasdf";

	var res1 = new Calysto.Regex("fa").Matches(str).AsEnumerable().Select(function (o) { return o.Value + ", " + o.Success + ", " + o.Index }).ToStringJoined(";");
	if(res1 != "fa, true, 0;fa, true, 21;fa, true, 48")
	{
		throw new Error("Calysto.Regex selftest #1 failed, res: " + res1);
	}

	var res2 = new Calysto.Regex("fa").SelectMatches(str).Select(function (o) { return o.Value + ", " + o.Success + ", " + o.Index }).ToStringJoined(";");
	if (res2 != "fa, true, 0;fa, true, 21;fa, true, 48")
	{
		throw new Error("Calysto.Regex selftest #2 failed, res: " + res2);
	}

	var res3 = new Calysto.Regex("fa").SelectSegments(str).Select(function (o) { return o.Value + ", " + o.Success + ", " + o.Index }).ToStringJoined(";");
	if (res3 != "fa, true, 0;sdg423675wefdfhuioy, false, 2;fa, true, 21;sdyqpoeriu7234rfdsdhlkj6r, false, 23;fa, true, 48;234fdashasdf, false, 50")
	{
		throw new Error("Calysto.Regex selftest #3 failed, res: " + res3);
	}

	var res4 = new Calysto.Regex("fa").SelectSegments(str).Select(function (o) { return o.Value}).ToStringJoined(";");
	if (res4 != "fa;sdg423675wefdfhuioy;fa;sdyqpoeriu7234rfdsdhlkj6r;fa;234fdashasdf")
	{
		throw new Error("Calysto.Regex selftest #4 failed, res: " + res4);
	}

	var res5 = new Calysto.Regex("fa").SelectSegments(str).Select(function (o) { return o.Value }).ToStringJoined("");
	if (res5 != "fasdg423675wefdfhuioyfasdyqpoeriu7234rfdsdhlkj6rfa234fdashasdf")
	{
		throw new Error("Calysto.Regex selftest #5 failed, res: " + res5);
	}

	var res6 = "pos-bottom-center, pos-bottom-center2".ReplaceAll("pos-", "replacedText");
	if (res6 != "replacedTextbottom-center, replacedTextbottom-center2")
	{
		throw new Error("Calysto.Regex selftest #6 failed, res: " + res6);
	}

	console.log("Regex test successful");

});
//#endif
