//#if DEBUG
Calysto.TestTools.TestRunner.AddTest(() =>
{
	var res1 = [
		"hretygsadfewh/ghsd/.?gsadf".EndsWith("adf"),
		"hretygsadfewh/ghsd/.?gsadf".EndsWith("aDf", true),
		"hretygsadfewh/ghsd/.?gsadf".EndsWith("aDf"),
		"hretygshreadfewh/ghsd/.?gsadf".StartsWith("hre"),
		"hretygshreadfewh/ghsd/.?gsadf".StartsWith("hRe", true),
		"hretygshreadfewh/ghsd/.?gsadf".StartsWith("hRe"),
		"hretygsadfewh/ghsd/.?gsadf".Contains("gh"),
		"hretygsadfewh/ghsd/.?gsadf".Contains("G"),
		"hretygsadfewh/ghsd/.?gsadf".Contains("GH", true),
		"hretygsadfewh/ghsd/.?gsadf".GetHashCode(),
		"hretygsadfewh/ghsd/.?gsadf".Remove(4),
		"hretygsadfewh/ghsd/.?gsadf".Remove(324),
		"hretygsadfewh/ghsd/.?gsadf".Repeat(3),
		"hretygsadfewh/ghsd/.?gsadf".Repeat(0)
	].join("_");

	if (res1 != "true_true_false_true_true_false_true_false_true_-914965447_hret_hretygsadfewh/ghsd/.?gsadf_hretygsadfewh/ghsd/.?gsadfhretygsadfewh/ghsd/.?gsadfhretygsadfewh/ghsd/.?gsadf_")
	{
		throw new Error("Error in String test1, result: " + res1);
	}

	var res2 = [
		"testfunction(){reutrn false; {name1} was not {cars.1} {years.birth} {cars.2} hretygsadfewh/ghsd/.?gsadf}".FormatWith({ name1: "John Bravo", years: { birth: 22, school: 8 }, cars: ["ford", "bmw", "audi"] }),
		"hretygsadfewh/ghsd/.?gsadf".ReplaceAll("h", "1"),
		"hretygsadfewh/ghsd/.?gsadf".TakeFirst(5),
		"hretygsadfewh/ghsd/.?gsadf".TakeFirst(5, "..."),
		"hretyy".TakeFirst(5, "..."),
		"hrety".TakeFirst(5, "..."),
		"hretyy".TakeFirst(4, "..."),
		"hretygsadfewh/ghsd/.?gsadf".TakeLast(5),
		"hretygsadfewh/ghsd/.?gsadf".TakeLast(5, "..."),
		"hretyg".TakeLast(7, "..."),
		"hretyg".TakeLast(6, "..."),
		"hretyg".TakeLast(5, "..."),
		"this is my word number one".TakeLast(15, "..."),
		"this is my word number one".TakeLast(15, "...", true),
		"this is my word number one".TakeFirst(15, "...", true),
		"this is my word number one".TakeFirst(14, "...", true),
		"this is my word number one".TakeFirst(16, "...", true),
		String.IsNullOrEmpty(),
		String.IsNullOrEmpty(""),
		String.IsNullOrEmpty("d"),
		String.IsNullOrEmpty("gsdf", ),
		String.IsNullOrWhiteSpace(),
		String.IsNullOrWhiteSpace("false", ),
		String.IsNullOrWhiteSpace(""),
		String.IsNullOrWhiteSpace(" "),
		String.IsNullOrWhiteSpace(" e"),
		String.IsNullOrWhiteSpace(" \r\n\t"),
		String.IsNullOrWhiteSpace("\t"),
		String.IsNullOrWhiteSpace("\t\n")

	].join("_");


	if (res2 != "testfunction(){reutrn false; John Bravo was not bmw 22 audi hretygsadfewh/ghsd/.?gsadf}_1retygsadfew1/g1sd/.?gsadf_hrety_hr..._hr..._hr..._h..._gsadf_...df_hretyg_...tyg_...yg_...d number one_...number one_this is my..._this is my..._this is my..._true_true_false_false_true_false_true_true_false_true_true_true")
	{
		throw new Error("Error in String test2, result: " + res2);
	}

	console.log("String test successful");

});
//#endif
