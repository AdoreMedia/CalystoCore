//#if DEBUG
Calysto.TestTools.TestRunner.AddTest(() =>
{
	function UsingCulture2(culture, func)
	{
		// formating numbers to string, we need US culture
		var original = Calysto.Globalization.CultureInfo.CurrentCulture;
		Calysto.Globalization.CultureInfo.CurrentCulture = culture || Calysto.Globalization.CultureInfo.USCulture; // set US culture as default
		func();
		Calysto.Globalization.CultureInfo.CurrentCulture = original; // restore culture
	};

	UsingCulture2(Calysto.Globalization.CultureInfo.USCulture, function ()
	{
		let res1 = [
			(-36324263299.492342423532423532).ToStringFormated("n6"),
			(-36324263299.492342423532423532).ToStringFormated("n8"),
			(-36324263299.492342423532423532).ToStringFormated("n7"),
			(-3.6324263299492342423532423532).ToStringFormated("n15"),
			(-3.6324263299492342423532423532).ToStringFormated("n12"),
			(-3.6324263299492342423532423532).ToStringFormated("n13"),
			(-3.6324263299492342423532423532).ToStringFormated("n10"),
			(-3.6324263299492342423532423532).ToStringFormated("n9"),
			(-3.6324263299492342423532423532).ToStringFormated("n3"),
			(-3.6324263299492342423532423532).ToStringFormated("n2"),
			(-3.6324263299492342423532423532).ToStringFormated("n1"),
			(-3.6324263299492342423532423532).ToStringFormated("n0"),
			(-3.6324263299492342423532423532).ToStringFormated("n6"),
			(-3.6324263299492342423532423532).ToStringFormated("n5"),
			(3.6324263299492342423532423532).ToStringFormated("n5"),
			(3.6324263299492342423532423532).ToStringFormated("n6"),
			(3.6324263299492342423532423532).ToStringFormated("n3"),
			(3.6324263299492342423532423532).ToStringFormated("n1"),
			(3.6324263299492342423532423532).ToStringFormated("n0"),
			(3.6324263299492342423532423532).ToStringFormated("n")
		];

		let expected1 = [
			"-36,324,263,299.492350",
			"-36,324,263,299.49234000",
			"-36,324,263,299.4923400",
			"-3.632426329949234",
			"-3.632426329949",
			"-3.6324263299492",
			"-3.6324263299",
			"-3.632426330",
			"-3.632",
			"-3.63",
			"-3.6",
			"-4",
			"-3.632426",
			"-3.63243",
			"3.63243",
			"3.632426",
			"3.632",
			"3.6",
			"4",
			"3.63"
		];

		let s1 = res1.join(";");
		let exp1 = expected1.join(";");
		if (s1 != exp1)
		{
			throw new Error("Error in Number test1, result: " + s1 + ", expected: " + exp1);
		}

		console.log("Number test successful");
	});

});
//#endif
