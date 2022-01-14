//#if DEBUG
Calysto.TestTools.TestRunner.AddTest(() =>
{

	var tests = [
		{
			kind: "CRC32",
			result: -195000461
		},
		{
			kind: "MD5",
			result: "8a96948889e8401307c59655ad28a2a7"
		},
		{
			kind: "SHA1",
			result: "22b6fdd72a6bc56c907326843b2c92512f8514ea"
		},
		{
			kind: "SHA224",
			result: "556f8662e3a4b4f55cbeda5d2877af200d83cf02d014b659e799b34b"
		},
		{
			kind: "SHA256",
			result: "dcb7d77bd67950d978154bef6d666ddf9ea4401f73324fb860cedeccca9c9652"
		},
		{
			kind: "SHA384",
			result: "547a15ed4c163e6aabb06277a83bb34e370d834888b57bc8806a3707fff3bad37df06a6f204bfc1092ef38c02ef38b61"
		},
		{
			kind: "SHA512",
			result: "559baa865847f2caf2fb10bcf8c0c6f643e9072d66c01f278fa9859850403c4c103bd65e87099b6a264ea6d8ec6b370deb05719bee5303ca5e7c8a8e769a9662"
		}
	];

	var resarr = [];
	for (var n = 0; n < tests.length; n++)
	{
		var tmp;
		if ((tmp = Calysto.Security.Cryptography[tests[n].kind].ComputeHash("some žćčČĆŽđšp text is this?")) != tests[n].result)
		{
			throw new Error(".Cryptography." + tests[n].kind + ".ComputeHash() selftest error. Result: " + tmp + ", expected: " + tests[n].result);
		}
	}

	console.log("Cryptography test successful");

});
//#endif
