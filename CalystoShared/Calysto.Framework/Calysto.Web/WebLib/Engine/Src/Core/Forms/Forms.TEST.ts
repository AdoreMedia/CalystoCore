//#if DEBUG
Calysto.TestTools.TestRunner.AddTest(() =>
{
	function UsingCulture(culture, func)
	{
		// we need US culture for number formating to string
		var original = Calysto.Globalization.CultureInfo.CurrentCulture;
		Calysto.Globalization.CultureInfo.CurrentCulture = culture || Calysto.Globalization.CultureInfo.USCulture; // set US culture as default
		func();
		Calysto.Globalization.CultureInfo.CurrentCulture = original; // restore culture
	}

	UsingCulture(Calysto.Globalization.CultureInfo.USCulture, function ()
	{
		var isOldMsie = Calysto.Features.GetBrowser().KindName == "MSIE" && Calysto.Features.GetBrowser().Version <= 8;
		if (isOldMsie) return;

		var html1 = '<div id="divForm1" style="background:whitesmoke;padding:10px;margin-top:10px;border:solid 5px red;;">\
		<input type="text" calysto-id="Game.Name" name="GameName" value="the name of the game" />\
		<input type="text" calysto-id="Store.Name" name="StoreName" value="store name" />\
		<input type="text" calysto-id="Realization.IncomeSum1" calysto-getter="()=>Calysto.Type.NumberConverter.ToDecimal(this.value, -5)" name="ctl00$clientNavigation1$IncomeSum1">\
		<input type="text" calysto-id="Realization.IncomeSum2" calysto-setter="(a1)=>this.value=a1.ToStringFormated(\'n2\')" name="ctl00$clientNavigation1$IncomeSum2">\
		<input type="text" calysto-id="Realization.IncomeSum3" name="ctl00$clientNavigation1$IncomeSum3" calysto-format="N3">\
		<input type="text" calysto-id="Realization.IncomeSum4" calysto-setter="(a1)=>this.value=a1.ToStringFormated(\'n2\')" calysto-getter="()=>Calysto.Type.NumberConverter.ToDecimal(this.value, -1)" name="ctl00$clientNavigation1$IncomeSum4">\
		<div class="right" calysto-id="Realization.IncomeSum5" calysto-setter="(a1)=>this.innerHTML=a1.ToStringFormated(\'n2\')"></div>\
		<select calysto-id="Realization.Color" name="TheColor">\
			<option value="red">Red color</option>\
			<option value="blue">Blue color</option>\
			<option selected="selected">No color</option>\
		</select>\
\
		<select calysto-id="Realization.Height" name="TheHeight" multiple="multiple">\
			<option value="1">One inch</option>\
			<option value="2" selected="selected">Two inch</option>\
			<option value="3" selected="selected">Three inch</option>\
			<option value="4">Four inch</option>\
			<option selected="selected" value="">No height</option>\
		</select>\
\
		<input type="radio" calysto-id="Income.Salary" name="ctl00$clientNavigation1$Salary1" value="1000" />\
		<input type="radio" calysto-id="Income.Salary" name="ctl00$clientNavigation1$Salary1" value="2000" />\
		<input type="radio" calysto-id="Income.Salary" name="ctl00$clientNavigation1$Salary1" value="3000" />\
		<input type="radio" calysto-id="Income.Salary" name="ctl00$clientNavigation1$Salary1" value="4000" checked="checked" calysto-type="Decimal" />\
		<input type="radio" calysto-id="Income.Salary" name="ctl00$clientNavigation1$Salary1" value="5000" />\
\
		<input type="checkbox" calysto-id="Addition.Bonus1" name="ctl00$clientNavigation1$Addition1" value="5000" />\
		<input type="checkbox" calysto-id="Addition.Bonus2" name="ctl00$clientNavigation1$Addition2" value="6000" checked="checked" />\
		<input type="checkbox" calysto-id="Addition.Bonus3" name="ctl00$clientNavigation1$Addition3" value="7000" checked="checked" />\
		<input type="checkbox" calysto-id="Addition.Bonus4" name="ctl00$clientNavigation1$Addition4" value="8000" />\
</div>\
';

		var divEl = Calysto.Utility.Dom.ConvertToElementsArray(html1);

		// initial values from html
		var json1 = '{"Game":{"Name":"the name of the game"},"Store":{"Name":"store name"},"Realization":{"IncomeSum1":-5,"IncomeSum2":"","IncomeSum3":"","IncomeSum4":-1,"Color":"No color","Height":["2","3",""]},"Income":{"Salary":4000},"Addition":{"Bonus2":"6000","Bonus3":"7000"}}';

		var el3 = $$calysto(divEl).CloneNodes().First();
		var res1 = Calysto.Json.Serialize(Calysto.Forms.CalystoSerialize(el3));
		Calysto.TestTools.UnitTesting.Assert.AreEqual(json1, res1);

		var res11 = Calysto.Json.Serialize(Calysto.Forms.MvcSerialize(el3));
		var exp11 = `{"GameName":"the name of the game","StoreName":"store name","ctl00$clientNavigation1$IncomeSum1":-5,"ctl00$clientNavigation1$IncomeSum4":-1,"ctl00$clientNavigation1$Salary1":4000,"ctl00$clientNavigation1$Addition2":"6000","ctl00$clientNavigation1$Addition3":"7000","TheColor":"No color","TheHeight":["2","3",""]}`;
		Calysto.TestTools.UnitTesting.Assert.AreEqual(exp11, res11);

		var res12 = Calysto.Json.Serialize(Calysto.Forms.FormSerialize(el3));
		var exp12 = `{"GameName":"the name of the game","StoreName":"store name","ctl00$clientNavigation1$Addition2":"6000","ctl00$clientNavigation1$Addition3":"7000","TheColor":"No color","TheHeight":["2","3",""]}`;
		Calysto.TestTools.UnitTesting.Assert.AreEqual(exp12, res12);

		//*******************************************************************************************************************
		// modified values without type
		var json2 = '{"Game":{"Name":"game1"},"Store":{"Name":"store1"},"Realization":{"IncomeSum1":2,"IncomeSum2":-34.556,"IncomeSum3":"-23.63423","IncomeSum4":4,"Color":"blue","Height":["1","2","4"]},"Income":{"Salary":"2000"},"Addition":{"Bonus3":"7000","Bonus4":"8000"}}';

		var el3 = $$calysto(divEl).CloneNodes().First();
		////$$calysto(document.body).AddChildren(el3); // dodaje u dom
		Calysto.Forms.CalystoDeserialize(Calysto.Json.Deserialize(json2), el3);
		var res2 = Calysto.Json.Serialize(Calysto.Forms.CalystoSerialize(el3));
		var exp2 = '{"Game":{"Name":"game1"},"Store":{"Name":"store1"},"Realization":{"IncomeSum1":2,"IncomeSum2":-34.56,"IncomeSum3":"-23.63423","IncomeSum4":4,"Color":"blue","Height":["1","2","4"]},"Income":{"Salary":"2000"},"Addition":{"Bonus2":"6000","Bonus3":"7000","Bonus4":"8000"}}';
		Calysto.TestTools.UnitTesting.Assert.AreEqual(exp2, res2);

		var res21 = Calysto.Json.Serialize(Calysto.Forms.MvcSerialize(el3));
		var exp21 = `{"GameName":"game1","StoreName":"store1","ctl00$clientNavigation1$IncomeSum1":2,"ctl00$clientNavigation1$IncomeSum2":-34.56,"ctl00$clientNavigation1$IncomeSum3":"-23.63423","ctl00$clientNavigation1$IncomeSum4":4,"ctl00$clientNavigation1$Salary1":"2000","ctl00$clientNavigation1$Addition2":"6000","ctl00$clientNavigation1$Addition3":"7000","ctl00$clientNavigation1$Addition4":"8000","TheColor":"blue","TheHeight":["1","2","4"]}`;
		Calysto.TestTools.UnitTesting.Assert.AreEqual(exp21, res21);

		var res22 = Calysto.Json.Serialize(Calysto.Forms.FormSerialize(el3));
		var exp22 = '{"GameName":"game1","StoreName":"store1","ctl00$clientNavigation1$IncomeSum3":"-23.63423","ctl00$clientNavigation1$Salary1":"2000","ctl00$clientNavigation1$Addition2":"6000","ctl00$clientNavigation1$Addition3":"7000","ctl00$clientNavigation1$Addition4":"8000","TheColor":"blue","TheHeight":["1","2","4"]}';
		Calysto.TestTools.UnitTesting.Assert.AreEqual(exp22, res22);

		//*******************************************************************************************************************

		// modified values with type
		var json3 = '{"Game":{"Name":"game1"},"Store":{"Name":"store1"},"Realization":{"IncomeSum1":2,"IncomeSum2":-34.556,"IncomeSum3":-23.63463,"IncomeSum4":4,"Color":"blue","Height":[1,2,4]},"Income":{"Salary":20.0034},"Addition":{"Bonus3":70.00643,"Bonus4":-8.000435}}';

		var el3 = $$calysto(divEl).CloneNodes().First();
		Calysto.Forms.CalystoDeserialize(Calysto.Json.Deserialize(json3), el3);
		var res3 = Calysto.Json.Serialize(Calysto.Forms.CalystoSerialize(el3));
		var exp3 = '{"Game":{"Name":"game1"},"Store":{"Name":"store1"},"Realization":{"IncomeSum1":2,"IncomeSum2":-34.56,"IncomeSum3":-23.635,"IncomeSum4":4,"Color":"blue","Height":["1","2","4"]},"Addition":{"Bonus2":"6000"}}';
		Calysto.TestTools.UnitTesting.Assert.AreEqual(exp3, res3);

		var res31 = Calysto.Json.Serialize(Calysto.Forms.MvcSerialize(el3));
		var exp31 = `{"GameName":"game1","StoreName":"store1","ctl00$clientNavigation1$IncomeSum1":2,"ctl00$clientNavigation1$IncomeSum2":-34.56,"ctl00$clientNavigation1$IncomeSum3":-23.635,"ctl00$clientNavigation1$IncomeSum4":4,"ctl00$clientNavigation1$Addition2":"6000","TheColor":"blue","TheHeight":["1","2","4"]}`;
		Calysto.TestTools.UnitTesting.Assert.AreEqual(exp31, res31);

		var res32 = Calysto.Json.Serialize(Calysto.Forms.FormSerialize(el3));
		var exp32 = '{"GameName":"game1","StoreName":"store1","ctl00$clientNavigation1$Addition2":"6000","TheColor":"blue","TheHeight":["1","2","4"]}';
		Calysto.TestTools.UnitTesting.Assert.AreEqual(exp32, res32);

		//*******************************************************************************************************************

		console.log("Forms test succesful");
	});

});
//#endif
