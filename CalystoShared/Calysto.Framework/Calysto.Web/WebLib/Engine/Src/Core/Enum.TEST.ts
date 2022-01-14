//#if DEBUG
Calysto.TestTools.TestRunner.AddTest(() =>
{
	var res1 = [
		Calysto.Enum.GetNames(Calysto.Type.JSType).join(","),
		Calysto.Enum.GetValues(Calysto.Type.JSType).join(","),
		Calysto.Enum.GetValue(Calysto.Type.JSType, "Boolean"),
		Calysto.Enum.GetValue(Calysto.Type.JSType, "Number"),
		Calysto.Enum.GetName(Calysto.Type.JSType, 3),
		Calysto.Enum.GetName(Calysto.DayOfWeek, 2),
		Calysto.Enum.GetValue(Calysto.DayOfWeek, "Monday"),
		Calysto.Enum.HasName(Calysto.DayOfWeek, "Monday"),
		Calysto.Enum.HasName(Calysto.DayOfWeek, "somename"),
		Calysto.Enum.HasName(Calysto.DayOfWeek, ""),
		Calysto.Enum.HasValue(Calysto.DayOfWeek, 3),
		Calysto.Enum.HasValue(Calysto.DayOfWeek, 33),
		Calysto.Enum.HasValue(Calysto.DayOfWeek, NaN)
	].join(";");

	if (res1 != "String,Boolean,Decimal,Number,Integer,Array,Function,DateTime,Date,Any;1,2,3,4,5,6,7,8,9,10;2;4;Decimal;Tuesday;1;true;false;false;true;false;false")
	{
		throw new Error("Error in Calysto.Enum tests, result: " + res1);
	}

	console.log("Enum tests successful");

});
//#endif
