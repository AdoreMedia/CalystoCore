//#if DEBUG
Calysto.TestTools.TestRunner.AddTest(() =>
{
	// warning: it should not loop loading the same page over and over
	//if (!location.href.Contains("test=done"))
	//{
	//	var cc = new Calysto.Net.WebClient(location.pathname + "?test=done").OnLoad((sender, ev) =>
	//	{
	//		console.log(sender.GetResponseText());
	//	}).Start();
	//}

});
//#endif
