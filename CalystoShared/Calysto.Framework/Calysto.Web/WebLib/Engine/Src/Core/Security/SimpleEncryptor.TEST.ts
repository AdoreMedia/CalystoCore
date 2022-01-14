//#if DEBUG
Calysto.TestTools.TestRunner.AddTest(() =>
{
	// this is test for .OrderBy() which now uses grouping by Key first, then is sorted, it is how .NET works too
	var enc = new Calysto.Security.Cryptography.SimpleEncryptor("lozinka");
	var encrypted = Calysto.Utility.Encoding.RfcBase64.EncodeToBase64String(enc.Encrypt("this is my text čćžđš"));
	if (encrypted != "LNnDGAHDGAFAkAEs5E8sAZMtkxl1IZNRdX4=")
	{
		throw new Error("SimpleEncryptor.Encrypt() error, result: " + encrypted);
	}

	var decrypted = enc.DecryptToString(Calysto.Utility.Encoding.RfcBase64.DecodeBase64StringToArray(encrypted));
	if (decrypted != "this is my text čćžđš")
	{
		throw new Error("SimpleEncryptor.Decrypt() error, result: " + decrypted);
	}

	console.log("SimpleEncryptor test succesful");

});
//#endif
