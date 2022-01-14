//#if DEBUG
Calysto.TestTools.TestRunner.AddTest(async () =>
{
	//$$calysto("input").Where(o => o.innerHTML); o.checked)
	//$$calysto<HTMLInputElement>("Input").Where(o => o.checked)
	//$$calysto<HTMLInputElement>("input").Where(o => o.checked)
	var test1 = new Calysto.List(["one", "aa", "nemza", "two", "temza", "bb", "cc"])
		.GroupBy(<any>"o=>o.length") // returns [].Key objects
		.SelectMany(function (group) { return group.ToArray() })
		.Select(<any>"o=>o.length + ': ' + o")
		.ToStringJoined(", ");

	if (test1 != "3: one, 3: two, 2: aa, 2: bb, 2: cc, 5: nemza, 5: temza")
	{
		throw new Error("Self test failed in Calysto.List GroupBy test 1! Result: " + test1);
	}

	var test11 = new Calysto.List(["one", "two", "nemza", "temza", "aa", "bb", "cc"])
		.OrderBy(<any>"o => o.length", true)
		.ThenBy(<any>"o=>o", true) // then order by, automatic recognition
		.GroupBy(<any>"o=>o.length") // then order by, automatic recognition
		.Select(<any>"o=> o.Key + ', items: ' + o.ToArray().join('|')")
		.ToStringJoined(", ");

	if (test11 != "5, items: temza|nemza, 3, items: two|one, 2, items: cc|bb|aa")
	{
		throw new Error("Self test failed in Calysto.List test 1! Result: " + test11);
	}

	//********************************************
	// test 2
	//********************************************
	var test2 = new Calysto.List([1, 2, 3, 4, 5])
		.Where(<any>"o=>o > 2")
		.Select(<any>"(o, n) => new {item: o, index: n}")
		.OrderBy(<any>"o=>o.index", true)
		.Select(<any>"(o, n) => 'index: ' + n + ', value: ' + o.item")
		.ToStringJoined("; ");

	if (test2 != "index: 0, value: 5; index: 1, value: 4; index: 2, value: 3")
	{
		throw new Error("Self test failed in Calysto.List test 2! Result: " + test2);
	}

});

Calysto.TestTools.TestRunner.AddTest(() =>
{
	var obj1 = [{ "DataUrl": function () { }, "BlobIndex": 1, "FileName": "img_2.gif", "MimeType": "image/gif", "Size": 70622, "__calystotype": "Calysto22_Blob" },
	{ "DataUrl": function () { }, "BlobIndex": 2, "FileName": "img_2.gif", "MimeType": "image/gif", "Size": 50622, "__calystotype": "Calysto11_Blob" },
	{ "DataUrl": function () { return 3 }, "BlobIndex": 3, "FileName": "img_3.gif", "MimeType": "image/gif", "Size": 50622, "__calystotype": "Calysto33_Blob" },
	{ "DataUrl": "", "BlobIndex": 4, "FileName": "img_3.gif", "MimeType": "image/gif", "Size": 70622, "__calystotype": "Calysto222222_Blob" },
	{ "DataUrl": "", "BlobIndex": 5, "FileName": "img_2.gif", "MimeType": "image/gif", "Size": 70622, "__calystotype": "Calysto222222_Blob" }];

	var m1 = obj1.AsEnumerable().Cycle(20).ToArray();
	var m2 = obj1.AsEnumerable().Distinct(o => o.DataUrl).ToArray();

	// warning: although we set o.Numbe = n, actually we use the same 5 objects, and there will be 5 distinct objects at the end
	var arr1 = obj1.AsEnumerable().Cycle(100).Distinct(function (o) { return o.DataUrl }).ToArray();

	if (arr1.length != 4)
	{
		throw new Error("Self test failed in Distinct test 01, result: " + arr1.length);
	}

	var arr2 = obj1.AsEnumerable()
		.Cycle(100)
		.Distinct(function (o) { return o })
		.ToArray();

	if (arr2.length != 5)
	{
		throw new Error("Self test failed in Distinct test 02, result: " + arr2.length);
	}

	var res1 = [2, 3, 4, 5, 6, null, -1, -6].AsEnumerable().Min();
	if (res1 != -6)
	{
		throw new Error("Self test failed in Min test 01, result: " + res1);
	}

	var res2 = [2, 3, 4, 5, null, -1, -6].AsEnumerable().Max();
	if (res2 != 5)
	{
		throw new Error("Self test failed in Max test 01, result: " + res1);
	}

	var res3 = [2, 3, 4, 5, 6, null, null, null, null, null, null, -1, -6].AsEnumerable().Average();
	if (res3 != 1.8571428571428572)
	{
		throw new Error("Self test failed in Average test 01, result: " + res1);
	}

	var res4 = [2, 3, 4, 5, 6, null, null, null, null, null, null, -1, -6].AsEnumerable().Sum();
	if (res4 != 13)
	{
		throw new Error("Self test failed in Sum test 01, result: " + res1);
	}

});

Calysto.TestTools.TestRunner.AddTest(() =>
{
	var js1 = '{"msg":"hasdfs","files":[{"DataUrl":"","BlobIndex":0,"FileName":"img_1.gif","MimeType":"image/gif","Size":56591,"__calystotype":"Calysto222222_Blob"},{"DataUrl":"","BlobIndex":1,"FileName":"img_2.gif","MimeType":"image/gif","Size":70622,"__calystotype":"Calysto222222_Blob"},{"DataUrl":"","BlobIndex":2,"FileName":"img_3.gif","MimeType":"image/gif","Size":68342,"__calystotype":"Calysto222222_Blob"},{"DataUrl":"","BlobIndex":3,"FileName":"img_4.gif","MimeType":"image/gif","Size":95296,"__calystotype":"Calysto222222_Blob"},{"DataUrl":"","BlobIndex":4,"FileName":"img_5.gif","MimeType":"image/gif","Size":87117,"__calystotype":"Calysto222222_Blob"}]}';

	if ((<any>window).JSON) // IE <= 8 doesn't have JSON
	{
		var res1 = JSON.stringify(Calysto.Json.Deserialize(js1));
		if (res1 != js1)
		{
			throw new Error("Self test failed in Calysto.JSON test 01! Result: " + res1);
		}

		var item1 = JSON.parse(js1);
		var res1 = Calysto.Json.Serialize(item1);
		if (res1 != js1)
		{
			throw new Error("Self test failed in Calysto.JSON test 02! Result: " + res1);
		}
	}
});

Calysto.TestTools.TestRunner.AddTest(() =>
{
	var kewsrc = [{ name: "one", age: 22, sub: { dva: 22, tri: 33, coll: [{ nn: 22 }, { nn: 33 }, { nn: 44 }] } }]
		.AsEnumerable()
		.Select(o => o)
		.Select(<any>"o => o.sub")
		.Where(<any>"o => !!o")
		.Where(<any>"o => !!o")
		.SelectMany(<any>"o => o.coll")
		.Where(<any>"o => o.nn > 1")
		.Intersect([{ kk: 22 }, { kk: 23 }, { kk: 44 }], <any>"(o1, o2) => o1.nn == o2.kk")
		.Where(<any>"o => !!o.nn")
		.ForEach(<any>'(o, n) => o.addedProperty = "ter-" + n')
		;

	var kew = kewsrc.ToArray();

	var res1 = Calysto.Json.Serialize(kew);
	if (res1 != '[{"nn":22,"addedProperty":"ter-0"},{"nn":44,"addedProperty":"ter-1"}]')
	{
		throw new Error("Self test failed in Calysto.List test 03! Result: " + res1);
	}

});

Calysto.TestTools.TestRunner.AddTest(async () =>
{
	var kewsrc = [{ name: "one", age: 22, sub: { dva: 22, tri: 33, coll: [{ nn: 22 }, { nn: 33 }, { nn: 44 }] } }]
		.AsEnumerable()
		.Select(o => o.sub)
		.Where(o => !!o)
		.Where(o => !!o)
		.SelectMany(o => o.coll)
		.Where(o => o.nn > 1)
		.Intersect([{ kk: 22 }, { kk: 23 }, { kk: 44 }], (o1, o2) => o1.nn == o2.kk)
		.Where(o => !!o.nn)
		.ForEach((o, n) => (<any>o).addedProperty = "ter-" + n)
		;

	var kew = kewsrc.ToArray();

	var res1 = Calysto.Json.Serialize(kew);
	if (res1 != '[{"nn":22,"addedProperty":"ter-0"},{"nn":44,"addedProperty":"ter-1"}]')
	{
		throw new Error("Self test failed in Calysto.List test 03! Result: " + res1);
	}

	// {"_items":{"_num_22":{"Key":22,"Value":{"nn":22,"addedProperty":"ter-0"}},"_num_44":{"Key":44,"Value":{"nn":44,"addedProperty":"ter-1"}}}}

	//var dic33 = kew.AsEnumerable().ToDictionary(key => key.nn, o => o);
	//var res1 = Calysto.Json.Serialize(dic33);
	//if (res1 != '{"22":{"nn":22,"addedProperty":"ter-0"},"44":{"nn":44,"addedProperty":"ter-1"}}')
	//{
	//	throw new Error("Self test failed in Calysto.List test 04! Result: " + res1);
	//}

	// dictionary object has changed, so we have to use different approach:
	var dic33 = kew.AsEnumerable().ToDictionary(key => key.nn, o => o).ToRawObject();
	var res1 = Calysto.Json.Serialize(dic33);
	if (res1 != '{"22":{"nn":22,"addedProperty":"ter-0"},"44":{"nn":44,"addedProperty":"ter-1"}}')
	{
		throw new Error("Self test failed in Calysto.List test 04! Result: " + res1);
	}

	// test select many if collection is null
	var res33 = [
		[1, 2, 3, 4],
		null,
		[8, 7, 5]
	].AsEnumerable().SelectMany(o => <any>o).ToArray().join(";");

	if (res33 != "1;2;3;4;8;7;5") 
	{
		throw new Error("Self test failed in SelectMay when collection is null, result: " + res33);
	}

	var testconcat = [1].AsEnumerable().Skip(1).Concat([3, 4, 5]).Concat([5, 6]).ToArray();
	if (testconcat.length != 5)
	{
		throw new Error("Self test failed in Calysto.List test Concat 1! Result: " + testconcat.length);
	}

	var test8 = ["one", "aa", "nemza", "two", "temza", "bb", "cc"]
		.AsEnumerable()
		.GroupBy(o => o.length) // returns [].Key objects
		.SelectMany(function (group) { return group.ToArray() })
		.Select(o => o.length + ": " + o)
		.ToStringJoined(", ");

	if (test8 != "3: one, 3: two, 2: aa, 2: bb, 2: cc, 5: nemza, 5: temza")
	{
		throw new Error("Self test failed in Calysto.List GroupBy test 1! Result: " + test8);
	}

	var test9 = ["one", "two", "nemza", "temza", "aa", "bb", "cc"]
		.AsEnumerable()
		.OrderBy(o => o.length, true)
		.ThenBy(o => o, true) // then order by, automatic recognition
		.GroupBy(o => o.length) // then order by, automatic recognition
		.Select(o => o.Key + ', items: ' + o.ToArray().join('|'))
		.ToStringJoined(", ");

	if (test9 != "5, items: temza|nemza, 3, items: two|one, 2, items: cc|bb|aa")
	{
		throw new Error("Self test failed in Calysto.List test 1! Result: " + test9);
	}

	//********************************************
	// test 2
	//********************************************
	var test2b = [1, 2, 3, 4, 5].AsEnumerable()
		.Where(o => o > 2)
		.Select((o, n) => ({ item: o, index: n }))
		.OrderBy(o => o.index, true)
		.Select((o, n) => 'index: ' + n + ', value: ' + o.item)
		.ToStringJoined("; ");

	if (test2b != "index: 0, value: 5; index: 1, value: 4; index: 2, value: 3")
	{
		throw new Error("Self test failed in Calysto.List test 2b! Result: " + test2b);
	}


	var aaa =
		[
			{ Ordinal: 11, ParentCategoryID: 5, Name: "111" },
			{ Ordinal: 11, ParentCategoryID: 5, Name: "222" },
			{ Ordinal: 11, ParentCategoryID: 5, Name: "333" },
			{ Ordinal: 11, ParentCategoryID: 5, Name: "" },
			{ Ordinal: 11, ParentCategoryID: 5, Name: undefined },
			{ Ordinal: 11, ParentCategoryID: 5, Name: undefined },

			{ Ordinal: 24, ParentCategoryID: 22, Name: "SomeName" },
			{ Ordinal: 24, ParentCategoryID: 22, Name: "555" },
			{ Ordinal: 24, ParentCategoryID: 55, Name: "666" },

			{ Ordinal: 88, ParentCategoryID: 33, Name: "Mark" },
			{ Ordinal: 88, ParentCategoryID: 55, Name: undefined },

			{ Ordinal: 11, ParentCategoryID: 22, Name: undefined },
			{ Ordinal: 11, ParentCategoryID: 33, Name: undefined },
			{ Ordinal: 11, ParentCategoryID: 55, Name: "Anthon" },

			{ Ordinal: 24, ParentCategoryID: 22, Name: undefined },
			{ Ordinal: 24, ParentCategoryID: 33, Name: undefined },
			{ Ordinal: 24, ParentCategoryID: 55, Name: "Clara" },

			{ Ordinal: 11, ParentCategoryID: 55, Name: "Runna" },
			{ Ordinal: 11, ParentCategoryID: 55, Name: "Inta" },
			{ Ordinal: 11, ParentCategoryID: 55, Name: "333" },
			{ Ordinal: 11, ParentCategoryID: 55, Name: "333" },

			{ Ordinal: 88, ParentCategoryID: 22, Name: undefined },
			{ Ordinal: 88, ParentCategoryID: 33, Name: undefined },
			{ Ordinal: 88, ParentCategoryID: 55, Name: undefined }

		];

	//********************************************
	// test 3
	//********************************************
	var bb = aaa.AsEnumerable()
		.OrderBy(o => o.Ordinal, false)
		.ThenBy(o => o.ParentCategoryID, true)
		.ThenBy(o => o.Name, false)
		.Skip(2)
		//.Where(o => o.Ordinal > -11)
		.OrderBy(o => 1) ////o.ParentCategoryID, true)
		.ThenBy(o => o.ParentCategoryID, true)
		.ThenBy(o => o.Ordinal);

	var cc = bb.Select(o => o.Ordinal + ', ' + o.ParentCategoryID + ', ' + o.Name).ToStringJoined("|");
	if (cc != "11, 55, Anthon|11, 55, Inta|11, 55, Runna|24, 55, 666|24, 55, Clara|88, 55, undefined|88, 55, undefined|11, 33, undefined|24, 33, undefined|88, 33, undefined|88, 33, Mark|11, 22, undefined|24, 22, undefined|24, 22, 555|24, 22, SomeName|88, 22, undefined|11, 5, undefined|11, 5, undefined|11, 5, |11, 5, 111|11, 5, 222|11, 5, 333")
	{
		throw new Error("Self test failed in Calysto.List test 3. Result: " + cc);
	}

	var kk = bb.Count();

	if (kk != 22)
	{
		throw new Error("Self test failed in Calysto.List test 5. Result: " + kk);
	}

	var res1 = ["auto", "autoo", "aut", "buton", "1", "2"].AsEnumerable().OrderBy(o => o).ToArray().join(", ");
	var res2 = ["auto", "autoo", "aut", "buton", "1", "2", "3"].AsEnumerable().OrderBy(o => o).ToArray().join(", ");
	var res3 = ["auao", "autoo", "aut", "buton", "1", "2", "3"].AsEnumerable().OrderBy(o => o).ToArray().join(", ");
	// 
	var res4 = [undefined, 1, NaN, null, "auto", "autoo", "aut", "buton", "1", "2", 3, NaN, undefined].AsEnumerable().OrderBy(o => o).ToArray().join(", ");

	if (res1 != "1, 2, aut, auto, autoo, buton") throw new Error("Self test failed in OrderBy test 1, result: " + res1);
	if (res2 != "1, 2, 3, aut, auto, autoo, buton") throw new Error("Self test failed in OrderBy test 2, result: " + res2);
	if (res3 != "1, 2, 3, auao, aut, autoo, buton") throw new Error("Self test failed in OrderBy test 3, result: " + res3);

	if (res4 != ", , , NaN, NaN, 1, 3, 1, 2, aut, auto, autoo, buton") throw new Error("Self test failed in OrderBy test 4, result: " + res4);

	//********************************************
	// test 4
	// full test for GroupBy, OrderBy, ThenBy
	//********************************************

	var list1 = "987654321".ToCharArray().AsEnumerable().Cycle(600).Select((ch, fromByte) =>
	({
			ch: ch.charCodeAt(0),
			fromByte: fromByte % 4
	}))
		.Take(100)
		.OrderByDescending(function (o) { return o.ch })
		.Select(function (o, toByte)
		{
			return { ch: o.ch, fromByte: o.fromByte, toByte: toByte }
		}).ToList();

	var res11 = list1.Select(function (o) { return o.ch + "_" + o.fromByte + "_" + o.toByte }).ToArray();
	var res21 = list1.OrderBy(o => o.ch).ThenBy(o => o.fromByte).Select(function (o) { return o.ch + "_" + o.fromByte + "_" + o.toByte }).ToArray();
	var res31 = list1.OrderBy(o => o.ch).ThenByDescending(o => o.fromByte).ThenByDescending(o => o.toByte).Select(function (o) { return o.ch + "_" + o.fromByte + "_" + o.toByte }).ToArray();
	var res41 = list1.OrderBy(o => o.ch).ThenBy(o => o.fromByte).ThenByDescending(o => o.toByte).Select(function (o) { return o.ch + "_" + o.fromByte + "_" + o.toByte }).ToArray();
	var res51 = list1.OrderByDescending(o => o.ch).ThenByDescending(o => o.fromByte).ThenBy(o => o.toByte).Select(function (o) { return o.ch + "_" + o.fromByte + "_" + o.toByte }).ToArray();

	if (res11.join(", ") != "57_0_0, 57_1_1, 57_2_2, 57_3_3, 57_0_4, 57_1_5, 57_2_6, 57_3_7, 57_0_8, 57_1_9, 57_2_10, 57_3_11, 56_1_12, 56_2_13, 56_3_14, 56_0_15, 56_1_16, 56_2_17, 56_3_18, 56_0_19, 56_1_20, 56_2_21, 56_3_22, 55_2_23, 55_3_24, 55_0_25, 55_1_26, 55_2_27, 55_3_28, 55_0_29, 55_1_30, 55_2_31, 55_3_32, 55_0_33, 54_3_34, 54_0_35, 54_1_36, 54_2_37, 54_3_38, 54_0_39, 54_1_40, 54_2_41, 54_3_42, 54_0_43, 54_1_44, 53_0_45, 53_1_46, 53_2_47, 53_3_48, 53_0_49, 53_1_50, 53_2_51, 53_3_52, 53_0_53, 53_1_54, 53_2_55, 52_1_56, 52_2_57, 52_3_58, 52_0_59, 52_1_60, 52_2_61, 52_3_62, 52_0_63, 52_1_64, 52_2_65, 52_3_66, 51_2_67, 51_3_68, 51_0_69, 51_1_70, 51_2_71, 51_3_72, 51_0_73, 51_1_74, 51_2_75, 51_3_76, 51_0_77, 50_3_78, 50_0_79, 50_1_80, 50_2_81, 50_3_82, 50_0_83, 50_1_84, 50_2_85, 50_3_86, 50_0_87, 50_1_88, 49_0_89, 49_1_90, 49_2_91, 49_3_92, 49_0_93, 49_1_94, 49_2_95, 49_3_96, 49_0_97, 49_1_98, 49_2_99")
	{
		throw new Error("Self test failed in Calysto.OrderBy test 4. res1: " + res11.join(", "));
	}

	if (res21.join(", ") != "49_0_89, 49_0_93, 49_0_97, 49_1_90, 49_1_94, 49_1_98, 49_2_91, 49_2_95, 49_2_99, 49_3_92, 49_3_96, 50_0_79, 50_0_83, 50_0_87, 50_1_80, 50_1_84, 50_1_88, 50_2_81, 50_2_85, 50_3_78, 50_3_82, 50_3_86, 51_0_69, 51_0_73, 51_0_77, 51_1_70, 51_1_74, 51_2_67, 51_2_71, 51_2_75, 51_3_68, 51_3_72, 51_3_76, 52_0_59, 52_0_63, 52_1_56, 52_1_60, 52_1_64, 52_2_57, 52_2_61, 52_2_65, 52_3_58, 52_3_62, 52_3_66, 53_0_45, 53_0_49, 53_0_53, 53_1_46, 53_1_50, 53_1_54, 53_2_47, 53_2_51, 53_2_55, 53_3_48, 53_3_52, 54_0_35, 54_0_39, 54_0_43, 54_1_36, 54_1_40, 54_1_44, 54_2_37, 54_2_41, 54_3_34, 54_3_38, 54_3_42, 55_0_25, 55_0_29, 55_0_33, 55_1_26, 55_1_30, 55_2_23, 55_2_27, 55_2_31, 55_3_24, 55_3_28, 55_3_32, 56_0_15, 56_0_19, 56_1_12, 56_1_16, 56_1_20, 56_2_13, 56_2_17, 56_2_21, 56_3_14, 56_3_18, 56_3_22, 57_0_0, 57_0_4, 57_0_8, 57_1_1, 57_1_5, 57_1_9, 57_2_2, 57_2_6, 57_2_10, 57_3_3, 57_3_7, 57_3_11")
	{
		throw new Error("Self test failed in Calysto.OrderBy test 4. res2: " + res21.join(", "));
	}

	if (res31.join(", ") != "49_3_96, 49_3_92, 49_2_99, 49_2_95, 49_2_91, 49_1_98, 49_1_94, 49_1_90, 49_0_97, 49_0_93, 49_0_89, 50_3_86, 50_3_82, 50_3_78, 50_2_85, 50_2_81, 50_1_88, 50_1_84, 50_1_80, 50_0_87, 50_0_83, 50_0_79, 51_3_76, 51_3_72, 51_3_68, 51_2_75, 51_2_71, 51_2_67, 51_1_74, 51_1_70, 51_0_77, 51_0_73, 51_0_69, 52_3_66, 52_3_62, 52_3_58, 52_2_65, 52_2_61, 52_2_57, 52_1_64, 52_1_60, 52_1_56, 52_0_63, 52_0_59, 53_3_52, 53_3_48, 53_2_55, 53_2_51, 53_2_47, 53_1_54, 53_1_50, 53_1_46, 53_0_53, 53_0_49, 53_0_45, 54_3_42, 54_3_38, 54_3_34, 54_2_41, 54_2_37, 54_1_44, 54_1_40, 54_1_36, 54_0_43, 54_0_39, 54_0_35, 55_3_32, 55_3_28, 55_3_24, 55_2_31, 55_2_27, 55_2_23, 55_1_30, 55_1_26, 55_0_33, 55_0_29, 55_0_25, 56_3_22, 56_3_18, 56_3_14, 56_2_21, 56_2_17, 56_2_13, 56_1_20, 56_1_16, 56_1_12, 56_0_19, 56_0_15, 57_3_11, 57_3_7, 57_3_3, 57_2_10, 57_2_6, 57_2_2, 57_1_9, 57_1_5, 57_1_1, 57_0_8, 57_0_4, 57_0_0")
	{
		throw new Error("Self test failed in Calysto.OrderBy test 4. res3: " + res31.join(", "));
	}

	if (res41.join(", ") != "49_0_97, 49_0_93, 49_0_89, 49_1_98, 49_1_94, 49_1_90, 49_2_99, 49_2_95, 49_2_91, 49_3_96, 49_3_92, 50_0_87, 50_0_83, 50_0_79, 50_1_88, 50_1_84, 50_1_80, 50_2_85, 50_2_81, 50_3_86, 50_3_82, 50_3_78, 51_0_77, 51_0_73, 51_0_69, 51_1_74, 51_1_70, 51_2_75, 51_2_71, 51_2_67, 51_3_76, 51_3_72, 51_3_68, 52_0_63, 52_0_59, 52_1_64, 52_1_60, 52_1_56, 52_2_65, 52_2_61, 52_2_57, 52_3_66, 52_3_62, 52_3_58, 53_0_53, 53_0_49, 53_0_45, 53_1_54, 53_1_50, 53_1_46, 53_2_55, 53_2_51, 53_2_47, 53_3_52, 53_3_48, 54_0_43, 54_0_39, 54_0_35, 54_1_44, 54_1_40, 54_1_36, 54_2_41, 54_2_37, 54_3_42, 54_3_38, 54_3_34, 55_0_33, 55_0_29, 55_0_25, 55_1_30, 55_1_26, 55_2_31, 55_2_27, 55_2_23, 55_3_32, 55_3_28, 55_3_24, 56_0_19, 56_0_15, 56_1_20, 56_1_16, 56_1_12, 56_2_21, 56_2_17, 56_2_13, 56_3_22, 56_3_18, 56_3_14, 57_0_8, 57_0_4, 57_0_0, 57_1_9, 57_1_5, 57_1_1, 57_2_10, 57_2_6, 57_2_2, 57_3_11, 57_3_7, 57_3_3")
	{
		throw new Error("Self test failed in Calysto.OrderBy test 4. res4: " + res41.join(", "));
	}

	if (res51.join(", ") != "57_3_3, 57_3_7, 57_3_11, 57_2_2, 57_2_6, 57_2_10, 57_1_1, 57_1_5, 57_1_9, 57_0_0, 57_0_4, 57_0_8, 56_3_14, 56_3_18, 56_3_22, 56_2_13, 56_2_17, 56_2_21, 56_1_12, 56_1_16, 56_1_20, 56_0_15, 56_0_19, 55_3_24, 55_3_28, 55_3_32, 55_2_23, 55_2_27, 55_2_31, 55_1_26, 55_1_30, 55_0_25, 55_0_29, 55_0_33, 54_3_34, 54_3_38, 54_3_42, 54_2_37, 54_2_41, 54_1_36, 54_1_40, 54_1_44, 54_0_35, 54_0_39, 54_0_43, 53_3_48, 53_3_52, 53_2_47, 53_2_51, 53_2_55, 53_1_46, 53_1_50, 53_1_54, 53_0_45, 53_0_49, 53_0_53, 52_3_58, 52_3_62, 52_3_66, 52_2_57, 52_2_61, 52_2_65, 52_1_56, 52_1_60, 52_1_64, 52_0_59, 52_0_63, 51_3_68, 51_3_72, 51_3_76, 51_2_67, 51_2_71, 51_2_75, 51_1_70, 51_1_74, 51_0_69, 51_0_73, 51_0_77, 50_3_78, 50_3_82, 50_3_86, 50_2_81, 50_2_85, 50_1_80, 50_1_84, 50_1_88, 50_0_79, 50_0_83, 50_0_87, 49_3_92, 49_3_96, 49_2_91, 49_2_95, 49_2_99, 49_1_90, 49_1_94, 49_1_98, 49_0_89, 49_0_93, 49_0_97")
	{
		throw new Error("Self test failed in Calysto.OrderBy test 4. res5: " + res51.join(", "));
	}

	//********************************************
	// test 5
	//********************************************

	var res = new Calysto.List(["word1 word2 word3", "this is next", "menu item three"]).Cycle(10).Select((o, n) => ({ Key: n, Value: o })).SkipWhile(o => o.Key < 2).TakeWhile(o => o.Key < 26).Select(o => o.Key + '_' + o.Value).ToStringJoined();

	Calysto.TestTools.UnitTesting.Assert.AreEqual("2_menu item three3_word1 word2 word34_this is next5_menu item three6_word1 word2 word37_this is next8_menu item three9_word1 word2 word3", res);


	//********************************************
	// DomQuery testovie
	//********************************************




	var html =
		'<div class="search_v2" style="margin-right: 5px;" >\
		<form id="form_search" name="search_main" onsubmit="return check_search_box_keyword()" action="/index.php" method="get">\
			<input name="ctl" type="hidden" value=" ddfe nedgd search2iio" style="display: none" calysto-num="45"/>\
			<label calysto-num="55" for="f_keywords">Upiši pojam...</label>\
			<input name="f_keywords" id="f_keywords" type="text" style="width: 263px" onfocus="javascript:reset_search_style()" />\
			<input calysto-num="25" class="mini_button" type="submit" value="Tražiiio" />\
			<img alt="Beta" style="float: left; margin-top: -3px; padding-left: 5px;" />\
		</form>\
	</div>\
	<div class="clear1" ></div>\
	<div class="clear" ></div>';

	var ddd = Calysto.DomQuery.FromHtml(html);

	//alert(ddd.Query("div:not(>input[name])").Count()); // result: 3

	//var nn = ddd.Query("//[calysto-num <= 45]").Count();

	var results = [
		ddd.Query("div:is(>>input[name='ctl'])").Count(), // 1
		ddd.Query("div:not(>>input[name=ctl])").Count(), // 2 // div whic doesn't have second child input[name=ctl33]
		ddd.Query("//input[type=hidden]").Count(), // 1 input with attribute type="hidden"
		ddd.Query("//input[type]").Count(), //3 contains input with attribute type
		ddd.Query("//[type]").Count(), //3 contains attribute type
		ddd.Query("//[value^=Tra]").Count(), //1 attribute value begins with Tra
		ddd.Query("//[value$=io]").Count(), //2 ends with io
		ddd.Query("//[value~=ddfe]").Count(), //1 contains exact word ddfe in list of space-separated values
		ddd.Query("//[calysto-num]").Count(), // 3
		ddd.Query("//[calysto-num==25]").Count(), // 1
		ddd.Query("//[calysto-num > 25]").Count(), // 2
		ddd.Query("//[calysto-num <= 45]").Count(), // 2
		ddd.Query("div:not(>input[name])").Count() // 3
	];

	// 1, 2, 1, 3, 8, 1, 2, 1, 8, 1, 2, 2

	var attrTest1 = results.join(", ");
	if (attrTest1 != "1, 2, 1, 3, 3, 1, 2, 1, 3, 1, 2, 2, 3")
	{
		throw new Error("error in Calysto.DomQuery attribute test, result: " + attrTest1);
	}

	var test1 = ddd.Select(o => o.tagName)
		.Where(o => !!o) // don't take text nodes which doesn't have tagname
		.ToStringJoined(", ").toLowerCase();

	if (test1 != "div, div, div")
	{
		throw new Error("error in Calysto.DomQuery test1, result: " + test1);
	}

	var test2a = ddd.DescendantNodes()
		.Query("form>label, a, IMG, input.mini_button")
		.Select((o: any) => o.tagName + o.id + o.name + o.className).ToStringJoined(", ").toLowerCase();

	if (test2a != "labelundefined, img, inputmini_button")
	{
		throw new Error("self test failed in Calysto.DomQuery test2a, result: " + test2a);
	}

	// animation and color test in Chrome requires node to be attached to DOM
	var html2 = 
`<div>
	<span id="col333" style="background-color:aliceblue">fdsa</span>
	<span></span>
	<div id="dd22" style="overflow:auto;width:100px;height:100px;">
		<div style="width:500px;height:500px;">inner content</div>
	</div>
	<div id="dd1" style="overflow:hidden; border:solid 1px red; width:900px; height:65px; position:absolute; margin-top:0;; top:200px; left:200px; background:red; "> prvi</div>
	<div>drugi</div>
	<div hrEF="hadsfmojurlfasd">treci
		<p>
			<a class="mmkk" href="http://www.dd.com/somemylink1">moj link</a>
		</p>
	</div>
	<div hrEF="hadsfmojurlfasd">treci
		<p>
			<a class="mmkk" href="http://www.dd.com/somemylink2">moj link</a>
		</p>
	</div>
	<div hrEF="hadsfmojurlfasd">treci
		<p>
			<a class="mmkk" href="http://www.dd.com/somemylink31">moj link</a>
			<a class="mmkk" href="http://www.dd.com/somemylink32">moj link</a>
			<a class="mmkk" href="http://www.dd.com/somemylink33">moj link</a>
		</p>
	</div>
	<div>cetvrti</div>
	<div id="hh">peti</div>
</div>`;

	var bbb1 = Calysto.DomQuery.FromHtml(html2);

	/// html has to be attached to dom or else Chrome won't mesure runtime widht and height
	var bbb = Calysto.DomQuery.FromSelector(document.documentElement).InsertChildren(html2).ChildNodes().Take(1);

	var test3 = bbb.DescendantNodes().Query("div>>a:reverse:take(4):skip(1):reverse").SelectAttribute("hrEF").ToStringJoined(", ");

	if (test3 != "http://www.dd.com/somemylink2, http://www.dd.com/somemylink31, http://www.dd.com/somemylink32")
	{
		throw new Error("Self test failed in Calysto.DomQuery test3. Result: " + test3);
	}

	//throw new Error("Calysto.DomLink tests ok");

	// test4
	var bcolor = $$calysto("#col333").SelectStyle("background-color").FirstOrDefault();
	// IE < v9 returns named color, aliceblue in this case
	if (bcolor != "rgb(240, 248, 255)" && bcolor != "aliceblue")
	{
		// aliceblue "rgb(240, 248, 255)"
		throw new Error("Self test failed in Calysto.DomQuery test5. Result: " + bcolor + ", expected: " + "rgb(240, 248, 255)");
	}


	let el1 = bbb.DescendantNodes().Query("#dd22").First();
	let styleItem1 = Calysto.Utility.Dom.Style.GetComputedStyle(el1, "scrollLeft");
	Calysto.TestTools.UnitTesting.Assert.AreEqual(0, styleItem1.NumericValue);

	Calysto.Utility.Dom.Style.SetStyleValue(el1, "scrollLeft", 1);
	styleItem1 = Calysto.Utility.Dom.Style.GetComputedStyle(el1, "scrollLeft");
	Calysto.TestTools.UnitTesting.Assert.AreEqual(1, styleItem1.NumericValue);

	Calysto.Utility.Dom.Style.SetStyleValue(el1, "scrollLeft", 0);
	styleItem1 = Calysto.Utility.Dom.Style.GetComputedStyle(el1, "scrollLeft");
	Calysto.TestTools.UnitTesting.Assert.AreEqual(0, styleItem1.NumericValue);


	var item = bbb.DescendantNodes().Query("#dd1");

	let kk11 = item.SelectStyle("margin-top").FirstOrDefault();
	Calysto.TestTools.UnitTesting.Assert.AreEqual(0, kk11);

	item.ApplyStyle("margin-top", "-15px");
	kk11 = item.SelectStyle("margin-top").FirstOrDefault();
	Calysto.TestTools.UnitTesting.Assert.AreEqual(-15, kk11);

	item.ApplyStyle("margin-top", "25px");
	kk11 = item.SelectStyle("margin-top").FirstOrDefault();
	Calysto.TestTools.UnitTesting.Assert.AreEqual(25, kk11);

	item.ApplyStyle("margin-top", "0");
	kk11 = item.SelectStyle("margin-top").FirstOrDefault();
	Calysto.TestTools.UnitTesting.Assert.AreEqual(0, kk11);


	let mm11 = item.SelectStyle("height").FirstOrDefault();
	Calysto.TestTools.UnitTesting.Assert.AreEqual(65, mm11);

	item.ApplyStyle("height", 30);
	mm11 = item.SelectStyle("height").FirstOrDefault();
	Calysto.TestTools.UnitTesting.Assert.AreEqual(30, mm11);

	item.ApplyStyle("height", "-=10");
	mm11 = item.SelectStyle("height").FirstOrDefault();
	Calysto.TestTools.UnitTesting.Assert.AreEqual(20, mm11);

	item.ApplyStyle("height", "-=10%");
	mm11 = item.SelectStyle("height").FirstOrDefault();
	Calysto.TestTools.UnitTesting.Assert.AreEqual(18, mm11);

	item.ApplyStyle("height", "+=47");
	mm11 = item.SelectStyle("height").FirstOrDefault();
	Calysto.TestTools.UnitTesting.Assert.AreEqual(65, mm11);

	var hh11 = item.SelectStyle("height").FirstOrDefault(); // before
	item.ApplyStyleMap({ width: "950px", opacity: "-=60", height: "+=500" });
	var hh1 = item.SelectStyle("height").FirstOrDefault(); // after
	var hh2 = item.SelectStyle("width").FirstOrDefault();
	var hh3 = item.SelectStyle("opacity").FirstOrDefault();
	var h5 = $$calysto([hh11, hh1, hh2, hh3]).ToStringJoined(", ");
	if (h5 != "65, 565, 950, 40")
	{
		throw new Error("Self test failed in Calysto.DomQuery test4. Result: " + h5);
	}

	await Calysto.Tasks.TaskUtility.CallbackAsync<void>(resolve =>
	{
		// test5
		item.ToAnimator({ height: "+=460", opacity: "-=10" }).Easing("easeInOutExpo").OnComplete((sender) =>
		{
			var gg11 = sender.AsDomQuery();
			var kk1 = gg11.SelectStyle("opacity").FirstOrDefault();
			var kk2 = gg11.SelectStyle("height").FirstOrDefault();
			var kk6 = $$calysto([kk1]).ToStringJoined(", ");

			if (Calysto.TestTools.UnitTesting.Assert.AreEqual("30", kk6, "Animator test failed"))
				console.log("Animator element style test successful");

			resolve();
		})
			//.OnProgress((sender, percent) => console.log(percent))
			.Start();
	});

	await Calysto.Tasks.TaskUtility.CallbackAsync<void>(resolve =>
	{
		var anim1 = new Calysto.Animator().AddValue(100, 500 /*, (sender, curr) => console.log("tick: " + curr)*/).OnComplete(sender =>
		{
			var km1 = sender.Items().AsEnumerable().Select(o => o.numCurrent).FirstOrDefault();

			if (Calysto.TestTools.UnitTesting.Assert.AreEqual(500, km1, "Animator test failed"))
				console.log("Animator numeric value test successful");

			resolve();
		})
			//.OnProgress((sender, percent) => console.log("progress: " + percent))
			.Start();
	});

	// test6
	var cnt11 = item.PreviousSiblings().Where(o => o.nodeType != 3).Count();
	if (cnt11 != 3) // count non-text nodes, different doctypes count text node as node or ignore it
	{
		throw new Error("Self test failed in Calysto.DomQuery test6. Result: " + cnt11);
	}

	// test7
	var cnt12 = item.NextSiblings().Where(o => o.nodeType != 3).Count();
	if (cnt12 != 6) // count non-text nodes
	{
		throw new Error("Self test failed in Calysto.DomQuery test7. Result: " + cnt12);
	}

	// remove from dom
	bbb.RemoveFromDom();


	//***********************************************************************
	var kk1 = "my text is this".TakeFirst(9, "...");
	var kk2 = "my text is this".TakeLast(9, "...");

	if (kk1 != "my tex...")
	{
		throw new Error("Self test failed in String.TakeLast, result: " + kk1);
	}

	if (kk2 != "...s this")
	{
		throw new Error("Self test failed in String.TakeFirst, result: " + kk2);
	}

	var items11 = Calysto.DomQuery.CreateElement("div").ApplyStyle("border:solid 1px blue; padding:5px;position:absolute;")
		.AddAsChildrenTo(<any>document.documentElement) // script tag must not be outside of html tag
		.AddChildren("<div style='position:absolute;border:solid 10px red;'>this is my div11</div>");

	items11.ChildNodes().ApplyStyle("border:solid 1px green; padding:5px;")
		.InsertBefore
		(
		Calysto.DomQuery.CreateElement("div").ApplyStyle("border:15px solid red;").ForEach(o => o.innerHTML = 'div 2'),
		Calysto.DomQuery.CreateElement("div").ApplyStyle("border:15px solid red;").ForEach(o => o.innerHTML = 'div 3'),
		Calysto.DomQuery.CreateElement("div").ApplyStyle("border:25px solid red;").ForEach(o => o.innerHTML = 'div 4'),
		"<div>prvi div</div><div class='hhret435' style='border:solid 18px blue;width:200px;padding:5px;'>drugi div</div><div>third div11</div>",
		"this is some text node",
		Calysto.DomQuery.CreateElement("div").ApplyStyle("border:5px solid red;width:auto;").ForEach(o => o.innerHTML = 'div 5') // computed width will be 236px because .hhret435 keeps parent width at 236px
		);

	var dd00 = items11.DescendantNodes("div").ToArray();
	var dd11 = items11.DescendantNodes().WhereStyle("border-top-width", o => o == 18).ToArray(); // .hhret435 // in computedStyleObject border-width is "" on FF and ID
	var dd12 = items11.DescendantNodes().WhereStyle("width", o => o == 236).ToArray(); // div with style="border:5px solid red;width:auto"
	var useBoxSizing = items11.DescendantNodes().SelectStyle("box-sizing").Where(function (o) { return o == "border-box" }).Any();

	items11.RemoveFromDom();

	if (dd00.length != 8)
	{
		throw new Error("Self test dd00 failed in Calysto.DomQuery, result: " + dd00.length);
	}

	if (dd11.length != 1)
	{
		throw new Error("Self test dd11 failed in Calysto.DomQuery, result: " + dd11.length);
	}

	var isOldMsie = Calysto.Features.GetBrowser().KindName == "MSIE" && Calysto.Features.GetBrowser().Version <= 8;


	if (dd12.length != 1 && !isOldMsie && !useBoxSizing) // this test doesn't work in IE <= 8
	{
		throw new Error("Self test dd12 failed in Calysto.DomQuery, result: " + dd12.length);
	}




	var ddd = Calysto.DomQuery.CreateElement("div");
	ddd.ApplyStyle("border:solid 1px blue; padding:5px;")
		.AddChildren("<div style='position:absolute;border:solid 10px red;'>this is my div</div>")
		.ChildNodes().ApplyStyle("border:solid 1px green; padding:5px;")
		.InsertBefore
		(
		Calysto.DomQuery.CreateElement("div").ApplyStyle("border:5px solid red;").ForEach(o => o.innerHTML = 'div 2'),
		Calysto.DomQuery.CreateElement("div").ApplyStyle("border:5px solid red;").ForEach(o => o.innerHTML = 'div 3'),
		Calysto.DomQuery.CreateElement("div").ApplyStyle("border:5px solid red;").ForEach(o => o.innerHTML = 'div 4'),
		"<div>first div</div><div>second div</div><div>third div</div>",
		"some text node 4325",
		Calysto.DomQuery.CreateElement("div").ApplyStyle("border:5px solid red;").ForEach(o => o.innerHTML = 'div 5')
		).ParentNodes().DescendantNodes().ApplyStyle("margin:5px;").Where(o => o.childNodes && o.childNodes.length == 1);

	var html111 = ddd.Select(function (o) { return o.innerHTML.replace(/<[^>]+>/g, ""); }).FirstOrDefault(); // ie8 i ie7 prilikom kreiranja elemenata dodaju new line iza svakog elementa pa konacni html nije isti ko na chreomeu i ostalima

	var arr = ddd.DescendantNodes().Where(o => o.nodeType == 1).Select(o => o.nodeValue || o.innerHTML).ToList();
	var hhtml = arr.ToStringJoined(", ");

	if (hhtml != "div 2, div 3, div 4, first div, second div, third div, div 5, this is my div")
	{
		throw new Error("SelfTest failed in test #html1, result: " + hhtml);
	}

	console.log("DomQuery test successful");

});
//#endif

