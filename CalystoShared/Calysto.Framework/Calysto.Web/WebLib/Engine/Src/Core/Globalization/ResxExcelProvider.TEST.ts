//#if DEBUG
Calysto.TestTools.TestRunner.AddTest(() =>
{
	let culture1 = Calysto.Globalization.CultureInfo.CurrentCulture;
	Calysto.Globalization.CultureInfo.CurrentCulture = Calysto.Globalization.CultureInfo.USCulture;

	let pp = Calysto.Resources.CalystoLang.ResourceProvider;

	Calysto.TestTools.UnitTesting.Assert.AreEqual("Invocation forbidden", pp.GetString("MethodInvocationFobidden"));

	Calysto.TestTools.UnitTesting.Assert.AreEqual("Invocation forbidden", pp.GetString("MethodInvocationFobidden", ["en-US"]));

	Calysto.TestTools.UnitTesting.Assert.AreEqual("Nemate dozvolu za ovu akciju", pp.GetString("MethodInvocationFobidden", ["hr-HR"]));

	Calysto.TestTools.UnitTesting.Assert.ThrowsException(() => pp.GetString("MethodInvocationFobidden", ["nonexisting property"]));


	Calysto.TestTools.UnitTesting.Assert.AreEqual("Please wait, page is reloading...", pp.GetString("PageIsReloadingPleaseWait"));

	Calysto.TestTools.UnitTesting.Assert.AreEqual("Please wait, page is reloading...", pp.GetString("PageIsReloadingPleaseWait", ["en-US"]));

	Calysto.TestTools.UnitTesting.Assert.AreEqual("Molimo pričekajte, stranica se osvježava...", pp.GetString("PageIsReloadingPleaseWait", ["hr-HR"]));

	Calysto.TestTools.UnitTesting.Assert.ThrowsException(() => pp.GetString("PageIsReloadingPleaseWait", ["nonexisting property"]));

	// restore culture
	Calysto.Globalization.CultureInfo.CurrentCulture = culture1;
});
//#endif
