//#if DEBUG
Calysto.TestTools.TestRunner.AddTest(() =>
{
	function TestDiagnosticString(uri: Calysto.Uri, expected: string)
	{
		let s1 = Object.getOwnPropertyNames(uri).AsEnumerable().Select(prop => prop + ":::" + uri[prop]).ToStringJoined(";;;");
		if (s1 != expected) throw new Error("Uri error, expected: " + expected + ", result: " + s1);
	}


	TestDiagnosticString(new Calysto.Uri("https://85.114.41.97/"),
			"Scheme:::https;;;Username:::;;;Password:::;;;Host:::85.114.41.97;;;Port:::;;;Path:::/;;;Query:::;;;Hash:::");

	TestDiagnosticString(new Calysto.Uri("http://domena.com:43/nesto/dva/dru.aspx?qu=3&gr=3#dd=rel"),
			"Scheme:::http;;;Username:::;;;Password:::;;;Host:::domena.com;;;Port:::43;;;Path:::/nesto/dva/dru.aspx;;;Query:::?qu=3&gr=3;;;Hash:::#dd=rel");

	TestDiagnosticString(new Calysto.Uri("http://domaena.com:233/../dva.aspx?a=10&b=22#dva"),
			"Scheme:::http;;;Username:::;;;Password:::;;;Host:::domaena.com;;;Port:::233;;;Path:::/../dva.aspx;;;Query:::?a=10&b=22;;;Hash:::#dva");

	TestDiagnosticString(new Calysto.Uri("http://domain.com/?m=10"),
			"Scheme:::http;;;Username:::;;;Password:::;;;Host:::domain.com;;;Port:::;;;Path:::/;;;Query:::?m=10;;;Hash:::");

	TestDiagnosticString(new Calysto.Uri("http://username:password@www.nesto.com:1233/mypath/bill.aspx?a=10&b=20#c=3&c=4"),
			"Scheme:::http;;;Username:::username;;;Password:::password;;;Host:::www.nesto.com;;;Port:::1233;;;Path:::/mypath/bill.aspx;;;Query:::?a=10&b=20;;;Hash:::#c=3&c=4");

	TestDiagnosticString(new Calysto.Uri("/"),
			"Scheme:::;;;Username:::;;;Password:::;;;Host:::;;;Port:::;;;Path:::/;;;Query:::;;;Hash:::");

	TestDiagnosticString(new Calysto.Uri("/some/path.aspx"),
			"Scheme:::;;;Username:::;;;Password:::;;;Host:::;;;Port:::;;;Path:::/some/path.aspx;;;Query:::;;;Hash:::");

	TestDiagnosticString(new Calysto.Uri("?q=13&b=32"),
			"Scheme:::;;;Username:::;;;Password:::;;;Host:::;;;Port:::;;;Path:::;;;Query:::?q=13&b=32;;;Hash:::");

	console.log("Uri test successful");

});
//#endif
