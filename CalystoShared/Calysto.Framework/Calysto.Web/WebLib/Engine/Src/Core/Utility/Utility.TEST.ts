//#if DEBUG
Calysto.TestTools.TestRunner.AddTest(() =>
{

	var net = "dGhpcyBpcyBteSB0ZXh0IGFuZCBjaGFycyDFvsSHxI3EkcWhxJDFoMW9xIbEjD8=";

	var text1 = "this is my text and chars žćčđšĐŠŽĆČ?";
	var ss = Calysto.Utility.Encoding.RfcBase64.EncodeToBase64String(text1);
	if (ss != net)
	{
		throw new Error("Calysto.Utility.Encoding.RfcBase64.EncodeToBase64String() self test error. Result: " + ss);
	}

	var dd = Calysto.Utility.Encoding.RfcBase64.DecodeBase64StringToString(ss);
	if (dd != text1)
	{
		throw new Error("Calysto.Utility.Encoding.RfcBase64.DecodeBase64StringToString() self test error. Result: " + dd);
	}


	var text2 = "http://sitežlkjđšžćč.com/?čščćžđaša fds žhsdf";
	var hh = Calysto.Utility.Html.UrlEncode(text2);

	if (hh != "http%3A%2F%2Fsite%C3%85%C2%BElkj%C3%84%C2%91%C3%85%C2%A1%C3%85%C2%BE%C3%84%C2%87%C3%84%C2%8D.com%2F%3F%C3%84%C2%8D%C3%85%C2%A1%C3%84%C2%8D%C3%84%C2%87%C3%85%C2%BE%C3%84%C2%91a%C3%85%C2%A1a%20fds%20%C3%85%C2%BEhsdf")
	{
		throw new Error("Calysto.Utility.Html.UrlEncode() self test error. Result: " + hh);
	}

	var aa1 = Calysto.Utility.Html.UrlDecode(hh);
	if (aa1 != text2)
	{
		throw new Error("Calysto.Utility.Html.UrlDecode() self test error. Result: " + hh);
	}


	var txt1 = "this is my žćčđšŽĆČĐŠ string";
	var bytes = Calysto.Utility.Encoding.UTF8.GetBytes(txt1);
	var res1 = Calysto.Utility.Encoding.UTF8.GetString(bytes);
	if (res1 != txt1)
	{
		throw new Error("Calysto.Utility.Encoding.UTF8.GetString() self test error. Result: " + res1 + ", expected: " + txt1);
	}

	var base64 = new Calysto.Utility.Encoding.CalystoBaseConverter().EncodeToBaseString(bytes, 6);
	var res2 = new Calysto.Utility.Encoding.CalystoBaseConverter().DecodeBaseStringToString(base64, 6);
	if (res2 != txt1)
	{
		throw new Error("Calysto.Utility.Encoding.CalystoBaseConverter.DecodeBaseStringToString() self test error. Result: " + res2 + ", expected: " + txt1);
	}



	var res4 = [
		Calysto.Utility.Path.GetQueryString("\\fasdfs\\hhdfg\\yerrre.cs?fsfs=twerew"),
		Calysto.Utility.Path.GetDirectoryName("\\fasdfs\\hhdfg\\yerrre.cs?fsfs=twerew"),
		Calysto.Utility.Path.GetFilePath("\\fasdfs\\hhdfg\\yerrre.cs?fsfs=twerew"),
		Calysto.Utility.Path.GetFileName("\\fasdfs\\hhdfg\\yerrre.cs?fsfs=twerew"),
		Calysto.Utility.Path.GetExtension("\\fasdfs\\hhdfg\\yerrre.cs?fsfs=twerew")].join(", ");
	var res5 = "?fsfs=twerew, \\fasdfs\\hhdfg, \\fasdfs\\hhdfg\\yerrre.cs, yerrre.cs, .cs";
	if (res4 != res5)
	{
		throw new Error("Calysto.Utility.Path selftest error. Result: " + res4 + ", expected: " + res5);
	}


	if (Calysto.Utility.CalystoTools.ByteArrayToLong(Calysto.Utility.CalystoTools.LongToByteArray(20042362354623561)) != 20042362354623561)
	{
		throw new Error("Selftest ByteArrayToLong failed");
	}


	console.log("Utility test successful");

});
//#endif
