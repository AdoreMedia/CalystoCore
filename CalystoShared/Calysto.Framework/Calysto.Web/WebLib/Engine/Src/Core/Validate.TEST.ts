//#if DEBUG
Calysto.TestTools.TestRunner.AddTest(() =>
{
	var res1 = [
		Calysto.Validate.IsEmail("myname@mfsd"), // not e-mail
		Calysto.Validate.IsEmail("myname@mfsd.com"), // valid email
		Calysto.Validate.IsEmail("myname.me@mfsd"), // not email
		Calysto.Validate.IsEmail("myname.me@mfsd.com"), // valid email
		"---",
		Calysto.Validate.CanConvertToNumber("gasdfg"),
		Calysto.Validate.CanConvertToNumber("gasdf432523"),
		Calysto.Validate.CanConvertToNumber("234.532"),
		Calysto.Validate.CanConvertToNumber("23,4532.63"),
		"---",
		Calysto.Validate.CanConvertToDecimal("234.532"),
		Calysto.Validate.ContainsNumber("f423gsda6234"),
		"---",
		Calysto.Validate.CanConvertToInteger("-432.652354"),
		Calysto.Validate.IsIPv4Address("4234"),
		Calysto.Validate.IsIPv4Address("234"),
		Calysto.Validate.IsIPv4Address("234.23.4.5"),
		Calysto.Validate.IsIPv4Address("234.23.4")
	];

	let exp3 = "false;true;false;true;---;false;false;true;true;---;true;true;---;false;false;false;true;false";
	let res3 = res1.join(";");
	Calysto.TestTools.UnitTesting.Assert.AreEqual(exp3, res3);

	console.log("Validate test successful");

});
//#endif
