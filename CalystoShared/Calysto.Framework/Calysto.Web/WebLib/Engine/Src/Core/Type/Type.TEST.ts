//#if DEBUG
Calysto.TestTools.TestRunner.AddTest(() =>
{
	function UsingCulture(culture, func)
	{
		// radi formatiranja brojeva u string:
		var original = Calysto.Globalization.CultureInfo.CurrentCulture;
		Calysto.Globalization.CultureInfo.CurrentCulture = culture || Calysto.Globalization.CultureInfo.USCulture; // set US culture as default
		func();
		Calysto.Globalization.CultureInfo.CurrentCulture = original; // restore culture
	}

	UsingCulture(Calysto.Globalization.CultureInfo.USCulture, function ()
	{
		var isOldMsie = Calysto.Features.GetBrowser().KindName == "MSIE" && Calysto.Features.GetBrowser().Version <= 8;
		if (isOldMsie) return;

		//************************************************************************************************
		var list = new Calysto.List();
		Calysto.Collections.ForEachProperties(Calysto.Type.JSType, function (name, value, index)
		{
			list.Add(name + ":" + value);
		});

		var res1 = list.ToStringJoined("; ");

		let exp1 = "1:String; 2:Boolean; 3:Decimal; 4:Number; 5:Integer; 6:Array; 7:Function; 8:DateTime; 9:Date; 10:NullOrUndefined; String:1; Boolean:2; Decimal:3; Number:4; Integer:5; Array:6; Function:7; DateTime:8; Date:9; NullOrUndefined:10";

		Calysto.TestTools.UnitTesting.Assert.AreEqual(exp1, res1);

		//************************************************************************************************

		var vals1 = [
			"s1",
			"",
			null,
			"true",
			true,
			false,
			undefined,
			2.34,
			5.41e+5,
			64,
			[3, 4, 2],
			document.documentElement.childNodes,
			function One() { return 3 },
			//document.documentElement.appendChild, // in IE8 this is object
			Calysto.DateTime.Now,
			new Date(),
			{ custom: "fsdfsad" }
		];

		var list = new Calysto.List();
		for (var n = 0; n < vals1.length; n++)
		{
			try
			{
				list.Add(Calysto.Type.TypeDescriptor.FromValue(vals1[n]).NullableTypeName);
			}
			catch (e)
			{
				list.Add("unresolved");
			}
		}

		let exp2 = "String; String; NullOrUndefined?; String; Boolean; Boolean; NullOrUndefined?; Decimal; Decimal; Decimal; Array; Array; Function; DateTime; Date; unresolved";
		var res2 = list.ToStringJoined("; ");
		Calysto.TestTools.UnitTesting.Assert.AreEqual(exp2, res2);

		//************************************************************************************************
		// test convertion of all types to string
		// Calysto.TimeSpan testing
		//************************************************************************************************

		var vals2: any[] = [
			"s1",
			"",
			null,
			"true",
			true,
			false,
			undefined,
			{ value: 2.34, calystoFormat: "N3" },
			{ value: 5.41345, calystoFormat: "n2" },
			{ value: 5.41e+5, calystoFormat: "N4" },
			{ value: 5.41e+5, calystoFormat: "C4" },
			{ value: 5.41e+5, calystoFormat: "C4", culture: Calysto.Globalization.CultureInfo.USCulture },
			64,
			[3, 4, 2],
			// pazi: HR culture u .NET coreu ima razmake nakon dana i mjeseca, valuta je HRK, zato koristim samo USCulture ovdje
			{ value: Calysto.DateTime.ParseDateTime("18.5.2016. 22:44:26", "dd.MM.yyyy. HH:mm:ss"), culture: Calysto.Globalization.CultureInfo.USCulture },
			{ value: Calysto.DateTime.ParseDateTime("18.5.2016. 22:44:26", "dd.MM.yyyy. HH:mm:ss"), culture: Calysto.Globalization.CultureInfo.USCulture },
			{ value: Calysto.DateTime.ParseDateTime("18.5.2016. 22:44:26", "dd.MM.yyyy. HH:mm:ss"), calystoFormat: "dd.MM.yyyy. HH:mm:ss.ff" },
			{ value: new Calysto.DateTime("2016-05-19 02:44:00"), calystoFormat: "MM/dd/yyyy HH:mm" },
			{ custom: "fsdfsad" }, // custom object can not be converted to string
			new Calysto.TimeSpan()
				.AddDays(2)					// 172800s
				.AddHours(28)				// 100800s
				.AddMinutes(14)				// 840s
				.AddSeconds(156)			// 156s
				.AddMilliseconds(1463)	// 1.463s
				.AddTicks(234534)			// 234.534s
		];

		var list = new Calysto.List();
		for (var n = 0; n < vals2.length; n++)
		{
			try
			{
				var o1 = vals2[n];

				UsingCulture(o1 && o1.culture ? o1.culture : null, function ()
				{
					if (o1 && (o1.calystoFormat || o1.culture))
					{
						list.Add(Calysto.Type.TypeConverter.ToStringFormated(o1.value, o1.calystoFormat)); // if calystoFormat not provided, use default formating
					}
					else
					{
						list.Add(Calysto.Type.TypeConverter.ToStringFormated(o1));
					}
				});
			}
			catch (e)
			{
				list.Add("unresolved");
			}
		}

		var res3 = list.ToStringJoined("; ");

		// this works in .net Core 3.1
		//let exp3 = "s1; ; ; true; true; false; ; 2.340; 5.41; 541,000.0000; $541,000.0000; 541.000,0000 kn; 64; [3,4,2]; 5/18/2016 10:44:26 PM; 18.5.2016. 22:44:26; 18.05.2016. 22:44:26.00; 05/19/2016 02:44; unresolved; 76:20:31.997";
		// .net 5 has some changes:
		// .net 5 as currency symbol has "HRK", before it was "kn"
		// .net 5 has spaces in hr-HR date to string: 18. 05. 2016.
		let exp3 = "s1; ; ; true; true; false; ; 2.340; 5.41; 541,000.0000; $541,000.0000; $541,000.0000; 64; [3,4,2]; 5/18/2016 10:44:26 PM; 5/18/2016 10:44:26 PM; 18.05.2016. 22:44:26.00; 05/19/2016 02:44; unresolved; 76:20:31.997";
		Calysto.TestTools.UnitTesting.Assert.AreEqual(exp3, res3);

		//************************************************************************************************
		// test conversion of all types to other types
		// test Calysto.DataBinder
		// test Calysto.DateTime.Parse
		//************************************************************************************************

		class BoxStack<T> extends Calysto.BoxValue<T>
		{
			public Items: T[] = [];

			public SetValue(value: T)
			{
				this.Items.push(value);
			}
		}

		var temp1 = {};
		Calysto.DataBinder.SetValue(temp1, "prop1.prop2.prop3.prop4.prop5", 234);
		Calysto.DataBinder.SetValue(temp1, "prop1.prop2.prop3.Value5", 111);
		var refOutArr = new BoxStack<any>();

		var res4 = [

			Calysto.Type.TypeConverter.ChangeType("True", "Boolean"),
			Calysto.Type.TypeConverter.ChangeType("true", "Boolean"),
			Calysto.Type.TypeConverter.ChangeType("false", "Boolean"),
			Calysto.Type.TypeConverter.ChangeType("False", "Boolean"),
			Calysto.Type.TypeConverter.ChangeType("0", "Boolean"),
			Calysto.Type.TypeConverter.ChangeType("1", "Boolean"),
			Calysto.Type.TypeConverter.ChangeType(0, "Boolean"),
			Calysto.Type.TypeConverter.ChangeType(1, "Boolean"),

			Calysto.Type.TypeConverter.ChangeType(undefined, <any>"Boolean?"),
			Calysto.Type.TypeConverter.ChangeType(undefined, "Integer", true),
			Calysto.Type.TypeConverter.ChangeType("", "Decimal", true),
			Calysto.Type.TypeConverter.ChangeType("", "Boolean", true),
			Calysto.Type.TypeConverter.ChangeType("", "String", true),
			Calysto.Type.TypeConverter.ChangeType(null, "String", true),
			Calysto.Type.TypeConverter.ChangeType(undefined, <any>"String?"),
			//Calysto.Type.TypeConverter.ChangeType(function One() { return 4; }, Calysto.DotNetTypeName.String), // firefox will add "use string" to body so this can not be used

			Calysto.Type.TypeConverter.ChangeType("-2.53", "Decimal"),
			Calysto.Type.TypeConverter.ChangeType("-12.553", "Number"),
			Calysto.Type.TypeConverter.ChangeType("-42.1234", "Integer"),
			Calysto.Type.TypeConverter.ChangeType(-432.23432, "Decimal"),
			Calysto.Type.TypeConverter.ChangeType(-4435.53241, "Integer"),

			Calysto.Type.TypeConverter.ChangeType("[34,53,4325]", "Array"),

			Calysto.DateTime.ParseDateTime("18.05.2016. 22:44:26.42", "dd.MM.yyyy"),
			Calysto.DateTime.ParseDateTime("18.05.2016. 22:44:26.42", "dd.MM.yyyy"),
			Calysto.DateTime.ParseDateTime("18.05.2016. 22:44:26.42", "dd.MM.yyyy. HH:mm:ss.ff"),

			"valueTypeTest",
			Calysto.Type.TypeInspector.IsValueType(null),
			Calysto.Type.TypeInspector.IsValueType(""),
			Calysto.Type.TypeInspector.IsValueType(function () { }),
			Calysto.Type.TypeInspector.IsValueType({}),
			Calysto.Type.TypeInspector.IsValueType(2),
			Calysto.Type.TypeInspector.IsValueType(true),

			"containPropertyTest",
			Calysto.Type.TypeInspector.ContainsProperty({ dva: 43 }, "dva"),
			Calysto.Type.TypeInspector.ContainsProperty({ dvatri: 43 }, "dva"),

			"dataBinderTryGetValueTest",
			Calysto.DataBinder.TryGetValue({ dva: 2, trie: 3 }, "dva2", refOutArr),
			Calysto.DataBinder.TryGetValue({ dva: 2, trie: { dva: 2, trie: { dva: 2, trie: 3 } } }, "trie.trie.dva", refOutArr),
			Calysto.DataBinder.TryGetValue({ dva: 2, trie: 3 }, "dva", refOutArr),
			Calysto.DataBinder.TryGetValue({}, "dva", refOutArr),
			"temp1isnext",
			temp1,
			"trygetvalue11",
			Calysto.DataBinder.TryGetValue(temp1, "prop1.prop2.prop3.prop4.prop5", refOutArr),
			Calysto.DataBinder.TryGetValue(temp1, "prop1.prop2.prop3.Value5", refOutArr),
			Calysto.DataBinder.TryGetValue(temp1, "prop1.prop2", refOutArr),
			Calysto.DataBinder.TryGetValue(temp1, "prop1.prop2.", refOutArr), //. is ignored
			Calysto.DataBinder.TryGetValue(temp1, "prop1.prop4", refOutArr),
			"refOutArrStart",
			refOutArr.Items
		];

		let exp5 = '[true,true,false,false,false,true,false,true,null,null,null,null,"",null,null,-2.53,-12.553,-42,-432.23432,-4435,["34","53","4325"],{"__calystotype":"Calysto_Date","Date":"2016-05-18T00:00:00.000"},{"__calystotype":"Calysto_Date","Date":"2016-05-18T00:00:00.000"},{"__calystotype":"Calysto_Date","Date":"2016-05-18T22:44:26.420"},"valueTypeTest",false,true,false,false,true,true,"containPropertyTest",true,false,"dataBinderTryGetValueTest",false,true,true,false,"temp1isnext",{"prop1":{"prop2":{"prop3":{"prop4":{"prop5":234},"Value5":111}}}},"trygetvalue11",true,true,true,true,false,"refOutArrStart",[2,2,234,111,{"prop3":{"prop4":{"prop5":234},"Value5":111}},{"prop3":{"prop4":{"prop5":234},"Value5":111}}]]';
		var res5 = Calysto.Json.Serialize(res4);

		Calysto.TestTools.UnitTesting.Assert.AreEqual(exp5, res5);

		//************************************************************************************************



		//************************************************************************************************

		console.log("DataBinder.SetValue test successful");
		console.log("DataBinder.TryGetValue test successful");
		console.log("DateTime.Parse test successful");
		console.log("Type.ChangeType test successful");
		console.log("Type test successful");
	});

});
//#endif
