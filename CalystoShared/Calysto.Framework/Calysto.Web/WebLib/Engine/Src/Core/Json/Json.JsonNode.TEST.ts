//#if DEBUG
Calysto.TestTools.TestRunner.AddTest(() =>
{
	var isOldMsie = Calysto.Features.GetBrowser().KindName == "MSIE" && Calysto.Features.GetBrowser().Version <= 8;
	if (isOldMsie) return;

	var js1 = '{"msg":"hasdfs","files":[{"DataUrl":"","BlobIndex":0,"FileName":"img_1.gif","MimeType":"image/gif","Size":56591,"__calystotype":"Calysto222222_Blob"},{"DataUrl":"","BlobIndex":1,"FileName":"img_2.gif","MimeType":"image/gif","Size":70622,"__calystotype":"Calysto222222_Blob"},{"DataUrl":"","BlobIndex":2,"FileName":"img_3.gif","MimeType":"image/gif","Size":68342,"__calystotype":"Calysto222222_Blob"},{"DataUrl":"","BlobIndex":3,"FileName":"img_4.gif","MimeType":"image/gif","Size":95296,"__calystotype":"Calysto222222_Blob"},{"DataUrl":"","BlobIndex":4,"FileName":"img_5.gif","MimeType":"image/gif","Size":87117,"__calystotype":"Calysto222222_Blob"}]}';

	var o1 = Calysto.Json.Deserialize(js1);
	var o2 = new Calysto.Json.JsonNode(o1);

	var res55 = Calysto.Json.Serialize(o2.Descendants(true).Skip(1).Take(2).ToArray());
	var res55exp = `[{"Property":"msg","Level":1,"Type":1,"Value":"hasdfs","Parent":{"Property":"@","Level":0,"Type":2,"Value":{"msg":"hasdfs","files":[{"DataUrl":"","BlobIndex":0,"FileName":"img_1.gif","MimeType":"image/gif","Size":56591,"__calystotype":"Calysto222222_Blob"},{"DataUrl":"","BlobIndex":1,"FileName":"img_2.gif","MimeType":"image/gif","Size":70622,"__calystotype":"Calysto222222_Blob"},{"DataUrl":"","BlobIndex":2,"FileName":"img_3.gif","MimeType":"image/gif","Size":68342,"__calystotype":"Calysto222222_Blob"},{"DataUrl":"","BlobIndex":3,"FileName":"img_4.gif","MimeType":"image/gif","Size":95296,"__calystotype":"Calysto222222_Blob"},{"DataUrl":"","BlobIndex":4,"FileName":"img_5.gif","MimeType":"image/gif","Size":87117,"__calystotype":"Calysto222222_Blob"}]}}},{"Property":"files","Level":1,"Type":3,"Value":[{"DataUrl":"","BlobIndex":0,"FileName":"img_1.gif","MimeType":"image/gif","Size":56591,"__calystotype":"Calysto222222_Blob"},{"DataUrl":"","BlobIndex":1,"FileName":"img_2.gif","MimeType":"image/gif","Size":70622,"__calystotype":"Calysto222222_Blob"},{"DataUrl":"","BlobIndex":2,"FileName":"img_3.gif","MimeType":"image/gif","Size":68342,"__calystotype":"Calysto222222_Blob"},{"DataUrl":"","BlobIndex":3,"FileName":"img_4.gif","MimeType":"image/gif","Size":95296,"__calystotype":"Calysto222222_Blob"},{"DataUrl":"","BlobIndex":4,"FileName":"img_5.gif","MimeType":"image/gif","Size":87117,"__calystotype":"Calysto222222_Blob"}],"Parent":{"Property":"@","Level":0,"Type":2,"Value":{"msg":"hasdfs","files":[{"DataUrl":"","BlobIndex":0,"FileName":"img_1.gif","MimeType":"image/gif","Size":56591,"__calystotype":"Calysto222222_Blob"},{"DataUrl":"","BlobIndex":1,"FileName":"img_2.gif","MimeType":"image/gif","Size":70622,"__calystotype":"Calysto222222_Blob"},{"DataUrl":"","BlobIndex":2,"FileName":"img_3.gif","MimeType":"image/gif","Size":68342,"__calystotype":"Calysto222222_Blob"},{"DataUrl":"","BlobIndex":3,"FileName":"img_4.gif","MimeType":"image/gif","Size":95296,"__calystotype":"Calysto222222_Blob"},{"DataUrl":"","BlobIndex":4,"FileName":"img_5.gif","MimeType":"image/gif","Size":87117,"__calystotype":"Calysto222222_Blob"}]}}}]`;

	Calysto.TestTools.UnitTesting.Assert.AreEqual(res55exp, res55, "#ref res55exp");

	var res56 = Calysto.Json.Serialize(o2.Children(true).Take(2).ToArray());
	var res56exp = `[{"Property":"@","Level":0,"Type":2,"Value":{"msg":"hasdfs","files":[{"DataUrl":"","BlobIndex":0,"FileName":"img_1.gif","MimeType":"image/gif","Size":56591,"__calystotype":"Calysto222222_Blob"},{"DataUrl":"","BlobIndex":1,"FileName":"img_2.gif","MimeType":"image/gif","Size":70622,"__calystotype":"Calysto222222_Blob"},{"DataUrl":"","BlobIndex":2,"FileName":"img_3.gif","MimeType":"image/gif","Size":68342,"__calystotype":"Calysto222222_Blob"},{"DataUrl":"","BlobIndex":3,"FileName":"img_4.gif","MimeType":"image/gif","Size":95296,"__calystotype":"Calysto222222_Blob"},{"DataUrl":"","BlobIndex":4,"FileName":"img_5.gif","MimeType":"image/gif","Size":87117,"__calystotype":"Calysto222222_Blob"}]}},{"Property":"msg","Level":1,"Type":1,"Value":"hasdfs","Parent":{"Property":"@","Level":0,"Type":2,"Value":{"msg":"hasdfs","files":[{"DataUrl":"","BlobIndex":0,"FileName":"img_1.gif","MimeType":"image/gif","Size":56591,"__calystotype":"Calysto222222_Blob"},{"DataUrl":"","BlobIndex":1,"FileName":"img_2.gif","MimeType":"image/gif","Size":70622,"__calystotype":"Calysto222222_Blob"},{"DataUrl":"","BlobIndex":2,"FileName":"img_3.gif","MimeType":"image/gif","Size":68342,"__calystotype":"Calysto222222_Blob"},{"DataUrl":"","BlobIndex":3,"FileName":"img_4.gif","MimeType":"image/gif","Size":95296,"__calystotype":"Calysto222222_Blob"},{"DataUrl":"","BlobIndex":4,"FileName":"img_5.gif","MimeType":"image/gif","Size":87117,"__calystotype":"Calysto222222_Blob"}]}}}]`;

	Calysto.TestTools.UnitTesting.Assert.AreEqual(res56exp, res56, "#ref res56exp");

	var all = o2.Descendants(true)
		.Where(o => o.Index > 0 || o.Index == 0)
		.Select(o=>o)
		.Where(o=>!!o);

	var arr1 = all.ToArray();
	var all1 = o2.Descendants(true).Where(o => o.Index > 0 || o.Index == 0).Skip(2).Take(1).ToArray();
	var all2 = o2.Descendants(true).ToArray();

	var complete1 = [all1];
	var res1 = Calysto.Json.Serialize(complete1); // use JSON.stringify
	var res11 = Calysto.Json.Serialize(complete1, 100); // force Calysto serializer
	var res11exp = `[[{"Index":2,"Property":"2","Level":2,"Type":2,"Value":{"DataUrl":"","BlobIndex":2,"FileName":"img_3.gif","MimeType":"image/gif","Size":68342,"__calystotype":"Calysto222222_Blob"},"Parent":{"Property":"files","Level":1,"Type":3,"Value":[{"DataUrl":"","BlobIndex":0,"FileName":"img_1.gif","MimeType":"image/gif","Size":56591,"__calystotype":"Calysto222222_Blob"},{"DataUrl":"","BlobIndex":1,"FileName":"img_2.gif","MimeType":"image/gif","Size":70622,"__calystotype":"Calysto222222_Blob"},{"DataUrl":"","BlobIndex":2,"FileName":"img_3.gif","MimeType":"image/gif","Size":68342,"__calystotype":"Calysto222222_Blob"},{"DataUrl":"","BlobIndex":3,"FileName":"img_4.gif","MimeType":"image/gif","Size":95296,"__calystotype":"Calysto222222_Blob"},{"DataUrl":"","BlobIndex":4,"FileName":"img_5.gif","MimeType":"image/gif","Size":87117,"__calystotype":"Calysto222222_Blob"}],"Parent":{"Property":"@","Level":0,"Type":2,"Value":{"msg":"hasdfs","files":[{"DataUrl":"","BlobIndex":0,"FileName":"img_1.gif","MimeType":"image/gif","Size":56591,"__calystotype":"Calysto222222_Blob"},{"DataUrl":"","BlobIndex":1,"FileName":"img_2.gif","MimeType":"image/gif","Size":70622,"__calystotype":"Calysto222222_Blob"},{"DataUrl":"","BlobIndex":2,"FileName":"img_3.gif","MimeType":"image/gif","Size":68342,"__calystotype":"Calysto222222_Blob"},{"DataUrl":"","BlobIndex":3,"FileName":"img_4.gif","MimeType":"image/gif","Size":95296,"__calystotype":"Calysto222222_Blob"},{"DataUrl":"","BlobIndex":4,"FileName":"img_5.gif","MimeType":"image/gif","Size":87117,"__calystotype":"Calysto222222_Blob"}]}}}}]]`;

	Calysto.TestTools.UnitTesting.Assert.AreEqual(res11exp, res11, "#ref res11exp");

	var lastOne = all.Last();
	var arr22 = lastOne.Ancestors(true).ToArray();
	var cnt11 = arr22.length;

	Calysto.TestTools.UnitTesting.Assert.AreEqual(3, cnt11, "#ref cnt11");

	var arr23 = lastOne.Ancestors(false).ToArray();
	var cnt13 = arr23.length;

	Calysto.TestTools.UnitTesting.Assert.AreEqual(2, cnt13, "#ref cnt13");

	Calysto.TestTools.UnitTesting.Assert.AreEqual(res1, res11, "#ref res11");

	var obj1 = { a: new Calysto.DateTime("2016-07-02T11:08:25.244Z"), b: (<any>window).tqwefdhdasrtyqwer, c: null, d: parseInt((<any>window).tqweyshasdfsg) };
	var json1 = Calysto.Json.Serialize(obj1);
	var json2 = Calysto.Json.Serialize(obj1, 100); // force Calysto serializer

	Calysto.TestTools.UnitTesting.Assert.AreEqual(`{"a":{"__calystotype":"Calysto_Date","Date":"2016-07-02T11:08:25.244"},"b":null,"c":null,"d":null}`, json1, "#ref json1");

	Calysto.TestTools.UnitTesting.Assert.AreEqual(json1, json2);

	console.log("JsonNode1 test successful");

});

Calysto.TestTools.TestRunner.AddTest(() =>
{
	let data1 = {
		Ime: "janko",
		Prezime: "bobetko",
		Sub1: {
			Name: "sub1",
			Sub2: {
				Name: "sub2",
				One: "jedan",
				Size: 25
			}
		},
		Age: 150,
		List1: [{ a: 10 }, { a: 20 }, { a: 30 }],
		List2: [1, 2, 3, 4, 5]
	};

	let tree1 = new Calysto.Json.JsonNode(data1);

	Calysto.TestTools.UnitTesting.Assert.AreEqual(`{"Property":"@","Level":0,"Type":2,"Value":{"Ime":"janko","Prezime":"bobetko","Sub1":{"Name":"sub1","Sub2":{"Name":"sub2","One":"jedan","Size":25}},"Age":150,"List1":[{"a":10},{"a":20},{"a":30}],"List2":[1,2,3,4,5]}}`, JSON.stringify(tree1), "#reference tree1");

	let d3 = tree1.Children(true).ToArray();
	Calysto.TestTools.UnitTesting.Assert.AreEqual(`[{\"Property\":\"@\",\"Level\":0,\"Type\":2,\"Value\":{\"Ime\":\"janko\",\"Prezime\":\"bobetko\",\"Sub1\":{\"Name\":\"sub1\",\"Sub2\":{\"Name\":\"sub2\",\"One\":\"jedan\",\"Size\":25}},\"Age\":150,\"List1\":[{\"a\":10},{\"a\":20},{\"a\":30}],\"List2\":[1,2,3,4,5]}},{\"Property\":\"Ime\",\"Level\":1,\"Type\":1,\"Value\":\"janko\",\"Parent\":{\"Property\":\"@\",\"Level\":0,\"Type\":2,\"Value\":{\"Ime\":\"janko\",\"Prezime\":\"bobetko\",\"Sub1\":{\"Name\":\"sub1\",\"Sub2\":{\"Name\":\"sub2\",\"One\":\"jedan\",\"Size\":25}},\"Age\":150,\"List1\":[{\"a\":10},{\"a\":20},{\"a\":30}],\"List2\":[1,2,3,4,5]}}},{\"Property\":\"Prezime\",\"Level\":1,\"Type\":1,\"Value\":\"bobetko\",\"Parent\":{\"Property\":\"@\",\"Level\":0,\"Type\":2,\"Value\":{\"Ime\":\"janko\",\"Prezime\":\"bobetko\",\"Sub1\":{\"Name\":\"sub1\",\"Sub2\":{\"Name\":\"sub2\",\"One\":\"jedan\",\"Size\":25}},\"Age\":150,\"List1\":[{\"a\":10},{\"a\":20},{\"a\":30}],\"List2\":[1,2,3,4,5]}}},{\"Property\":\"Sub1\",\"Level\":1,\"Type\":2,\"Value\":{\"Name\":\"sub1\",\"Sub2\":{\"Name\":\"sub2\",\"One\":\"jedan\",\"Size\":25}},\"Parent\":{\"Property\":\"@\",\"Level\":0,\"Type\":2,\"Value\":{\"Ime\":\"janko\",\"Prezime\":\"bobetko\",\"Sub1\":{\"Name\":\"sub1\",\"Sub2\":{\"Name\":\"sub2\",\"One\":\"jedan\",\"Size\":25}},\"Age\":150,\"List1\":[{\"a\":10},{\"a\":20},{\"a\":30}],\"List2\":[1,2,3,4,5]}}},{\"Property\":\"Age\",\"Level\":1,\"Type\":1,\"Value\":150,\"Parent\":{\"Property\":\"@\",\"Level\":0,\"Type\":2,\"Value\":{\"Ime\":\"janko\",\"Prezime\":\"bobetko\",\"Sub1\":{\"Name\":\"sub1\",\"Sub2\":{\"Name\":\"sub2\",\"One\":\"jedan\",\"Size\":25}},\"Age\":150,\"List1\":[{\"a\":10},{\"a\":20},{\"a\":30}],\"List2\":[1,2,3,4,5]}}},{\"Property\":\"List1\",\"Level\":1,\"Type\":3,\"Value\":[{\"a\":10},{\"a\":20},{\"a\":30}],\"Parent\":{\"Property\":\"@\",\"Level\":0,\"Type\":2,\"Value\":{\"Ime\":\"janko\",\"Prezime\":\"bobetko\",\"Sub1\":{\"Name\":\"sub1\",\"Sub2\":{\"Name\":\"sub2\",\"One\":\"jedan\",\"Size\":25}},\"Age\":150,\"List1\":[{\"a\":10},{\"a\":20},{\"a\":30}],\"List2\":[1,2,3,4,5]}}},{\"Property\":\"List2\",\"Level\":1,\"Type\":3,\"Value\":[1,2,3,4,5],\"Parent\":{\"Property\":\"@\",\"Level\":0,\"Type\":2,\"Value\":{\"Ime\":\"janko\",\"Prezime\":\"bobetko\",\"Sub1\":{\"Name\":\"sub1\",\"Sub2\":{\"Name\":\"sub2\",\"One\":\"jedan\",\"Size\":25}},\"Age\":150,\"List1\":[{\"a\":10},{\"a\":20},{\"a\":30}],\"List2\":[1,2,3,4,5]}}}]`, JSON.stringify(d3), "#reference d3");

	let d2 = tree1.Descendants(true).Where(o => o.Level >= 2).ToArray();
	Calysto.TestTools.UnitTesting.Assert.AreEqual(16, d2.length, "#reference d2");

	let d5 = tree1.Descendants(false).ToArray();
	Calysto.TestTools.UnitTesting.Assert.AreEqual(22, d5.length, "#reference d5");

	let d1 = tree1.Descendants().Where(o => o.Property == "Sub1").Select(o => o.Value).ToArray();
	Calysto.TestTools.UnitTesting.Assert.AreEqual(1, d1.length, "#reference d1");

	let d2a = tree1.Descendants(true).Where(o => o.Level >= 2).First();
	Calysto.TestTools.UnitTesting.Assert.AreEqual("Name", d2a.Property, "#reference d2a");

	let chain = d2a.SelectChain("Nest.Tamo.@.Sub1.Sub2.Size.Next.Home").ToArray();
	let chain22 = chain.AsEnumerable().Select(o => ({ Property: o.Property, Level: o.Level, Value: o.Value + "" })).ToArray();
	Calysto.TestTools.UnitTesting.Assert.AreEqual(`[]`, JSON.stringify(chain22), "#reference chain22");

	let chain2 = tree1.SelectChain("List1.2.a.c").ToArray();
	Calysto.TestTools.UnitTesting.Assert.AreEqual(`[{"Property":"List1","Level":1,"Type":3,"Value":[{"a":10},{"a":20},{"a":30}],"Parent":{"Property":"@","Level":0,"Type":2,"Value":{"Ime":"janko","Prezime":"bobetko","Sub1":{"Name":"sub1","Sub2":{"Name":"sub2","One":"jedan","Size":25}},"Age":150,"List1":[{"a":10},{"a":20},{"a":30}],"List2":[1,2,3,4,5]}}},{"Index":2,"Property":"2","Level":2,"Type":2,"Value":{"a":30},"Parent":{"Property":"List1","Level":1,"Type":3,"Value":[{"a":10},{"a":20},{"a":30}],"Parent":{"Property":"@","Level":0,"Type":2,"Value":{"Ime":"janko","Prezime":"bobetko","Sub1":{"Name":"sub1","Sub2":{"Name":"sub2","One":"jedan","Size":25}},"Age":150,"List1":[{"a":10},{"a":20},{"a":30}],"List2":[1,2,3,4,5]}}}},{"Property":"a","Level":3,"Type":1,"Value":30,"Parent":{"Index":2,"Property":"2","Level":2,"Type":2,"Value":{"a":30},"Parent":{"Property":"List1","Level":1,"Type":3,"Value":[{"a":10},{"a":20},{"a":30}],"Parent":{"Property":"@","Level":0,"Type":2,"Value":{"Ime":"janko","Prezime":"bobetko","Sub1":{"Name":"sub1","Sub2":{"Name":"sub2","One":"jedan","Size":25}},"Age":150,"List1":[{"a":10},{"a":20},{"a":30}],"List2":[1,2,3,4,5]}}}}}]`, JSON.stringify(chain2), "#reference chain2");

	//let list1 = chain.AsEnumerable().Last().Ancestors(true).Skip(2).Take(1).ToArray();
	//Calysto.TestTools.UnitTesting.Assert.AreEqual(`[{\"Property\":\"Size\",\"Level\":3,\"Type\":1,\"Value\":25,\"Parent\":{\"Property\":\"Sub2\",\"Level\":2,\"Type\":2,\"Value\":{\"Name\":\"sub2\",\"One\":\"jedan\",\"Size\":25},\"Parent\":{\"Property\":\"Sub1\",\"Level\":1,\"Type\":2,\"Value\":{\"Name\":\"sub1\",\"Sub2\":{\"Name\":\"sub2\",\"One\":\"jedan\",\"Size\":25}},\"Parent\":{\"Property\":\"@\",\"Level\":0,\"Type\":2,\"Value\":{\"Ime\":\"janko\",\"Prezime\":\"bobetko\",\"Sub1\":{\"Name\":\"sub1\",\"Sub2\":{\"Name\":\"sub2\",\"One\":\"jedan\",\"Size\":25}},\"Age\":150,\"List1\":[{\"a\":10},{\"a\":20},{\"a\":30}],\"List2\":[1,2,3,4,5]}}}}}]`, JSON.stringify(list1), "#reference list1");

	//let list11 = chain.AsEnumerable().Last().Ancestors(true).Skip(2).ToArray();
	//Calysto.TestTools.UnitTesting.Assert.AreEqual(`[{\"Property\":\"Size\",\"Level\":3,\"Type\":1,\"Value\":25,\"Parent\":{\"Property\":\"Sub2\",\"Level\":2,\"Type\":2,\"Value\":{\"Name\":\"sub2\",\"One\":\"jedan\",\"Size\":25},\"Parent\":{\"Property\":\"Sub1\",\"Level\":1,\"Type\":2,\"Value\":{\"Name\":\"sub1\",\"Sub2\":{\"Name\":\"sub2\",\"One\":\"jedan\",\"Size\":25}},\"Parent\":{\"Property\":\"@\",\"Level\":0,\"Type\":2,\"Value\":{\"Ime\":\"janko\",\"Prezime\":\"bobetko\",\"Sub1\":{\"Name\":\"sub1\",\"Sub2\":{\"Name\":\"sub2\",\"One\":\"jedan\",\"Size\":25}},\"Age\":150,\"List1\":[{\"a\":10},{\"a\":20},{\"a\":30}],\"List2\":[1,2,3,4,5]}}}}},{\"Property\":\"Sub2\",\"Level\":2,\"Type\":2,\"Value\":{\"Name\":\"sub2\",\"One\":\"jedan\",\"Size\":25},\"Parent\":{\"Property\":\"Sub1\",\"Level\":1,\"Type\":2,\"Value\":{\"Name\":\"sub1\",\"Sub2\":{\"Name\":\"sub2\",\"One\":\"jedan\",\"Size\":25}},\"Parent\":{\"Property\":\"@\",\"Level\":0,\"Type\":2,\"Value\":{\"Ime\":\"janko\",\"Prezime\":\"bobetko\",\"Sub1\":{\"Name\":\"sub1\",\"Sub2\":{\"Name\":\"sub2\",\"One\":\"jedan\",\"Size\":25}},\"Age\":150,\"List1\":[{\"a\":10},{\"a\":20},{\"a\":30}],\"List2\":[1,2,3,4,5]}}}},{\"Property\":\"Sub1\",\"Level\":1,\"Type\":2,\"Value\":{\"Name\":\"sub1\",\"Sub2\":{\"Name\":\"sub2\",\"One\":\"jedan\",\"Size\":25}},\"Parent\":{\"Property\":\"@\",\"Level\":0,\"Type\":2,\"Value\":{\"Ime\":\"janko\",\"Prezime\":\"bobetko\",\"Sub1\":{\"Name\":\"sub1\",\"Sub2\":{\"Name\":\"sub2\",\"One\":\"jedan\",\"Size\":25}},\"Age\":150,\"List1\":[{\"a\":10},{\"a\":20},{\"a\":30}],\"List2\":[1,2,3,4,5]}}},{\"Property\":\"@\",\"Level\":0,\"Type\":2,\"Value\":{\"Ime\":\"janko\",\"Prezime\":\"bobetko\",\"Sub1\":{\"Name\":\"sub1\",\"Sub2\":{\"Name\":\"sub2\",\"One\":\"jedan\",\"Size\":25}},\"Age\":150,\"List1\":[{\"a\":10},{\"a\":20},{\"a\":30}],\"List2\":[1,2,3,4,5]}}]`, JSON.stringify(list11), "#reference list11");

	let anc1 = d2a.Ancestors(true).ToArray();
	Calysto.TestTools.UnitTesting.Assert.AreEqual(`[{\"Property\":\"Name\",\"Level\":2,\"Type\":1,\"Value\":\"sub1\",\"Parent\":{\"Property\":\"Sub1\",\"Level\":1,\"Type\":2,\"Value\":{\"Name\":\"sub1\",\"Sub2\":{\"Name\":\"sub2\",\"One\":\"jedan\",\"Size\":25}},\"Parent\":{\"Property\":\"@\",\"Level\":0,\"Type\":2,\"Value\":{\"Ime\":\"janko\",\"Prezime\":\"bobetko\",\"Sub1\":{\"Name\":\"sub1\",\"Sub2\":{\"Name\":\"sub2\",\"One\":\"jedan\",\"Size\":25}},\"Age\":150,\"List1\":[{\"a\":10},{\"a\":20},{\"a\":30}],\"List2\":[1,2,3,4,5]}}}},{\"Property\":\"Sub1\",\"Level\":1,\"Type\":2,\"Value\":{\"Name\":\"sub1\",\"Sub2\":{\"Name\":\"sub2\",\"One\":\"jedan\",\"Size\":25}},\"Parent\":{\"Property\":\"@\",\"Level\":0,\"Type\":2,\"Value\":{\"Ime\":\"janko\",\"Prezime\":\"bobetko\",\"Sub1\":{\"Name\":\"sub1\",\"Sub2\":{\"Name\":\"sub2\",\"One\":\"jedan\",\"Size\":25}},\"Age\":150,\"List1\":[{\"a\":10},{\"a\":20},{\"a\":30}],\"List2\":[1,2,3,4,5]}}},{\"Property\":\"@\",\"Level\":0,\"Type\":2,\"Value\":{\"Ime\":\"janko\",\"Prezime\":\"bobetko\",\"Sub1\":{\"Name\":\"sub1\",\"Sub2\":{\"Name\":\"sub2\",\"One\":\"jedan\",\"Size\":25}},\"Age\":150,\"List1\":[{\"a\":10},{\"a\":20},{\"a\":30}],\"List2\":[1,2,3,4,5]}}]`, JSON.stringify(anc1), "#reference anc1");

	let anc2 = d2a.Ancestors(true).Reverse().Select(o => o.Property).ToStringJoined(".");
	Calysto.TestTools.UnitTesting.Assert.AreEqual(`@.Sub1.Name`, anc2, "#reference anc2");

	let tree2 = new Calysto.Json.JsonNode(data1.List1);
	var m1 = tree2.Descendants(true).ToArray();
	Calysto.TestTools.UnitTesting.Assert.AreEqual(`[{"Property":"@","Level":0,"Type":3,"Value":[{"a":10},{"a":20},{"a":30}]},{"Index":0,"Property":"0","Level":1,"Type":2,"Value":{"a":10},"Parent":{"Property":"@","Level":0,"Type":3,"Value":[{"a":10},{"a":20},{"a":30}]}},{"Property":"a","Level":2,"Type":1,"Value":10,"Parent":{"Index":0,"Property":"0","Level":1,"Type":2,"Value":{"a":10},"Parent":{"Property":"@","Level":0,"Type":3,"Value":[{"a":10},{"a":20},{"a":30}]}}},{"Index":1,"Property":"1","Level":1,"Type":2,"Value":{"a":20},"Parent":{"Property":"@","Level":0,"Type":3,"Value":[{"a":10},{"a":20},{"a":30}]}},{"Property":"a","Level":2,"Type":1,"Value":20,"Parent":{"Index":1,"Property":"1","Level":1,"Type":2,"Value":{"a":20},"Parent":{"Property":"@","Level":0,"Type":3,"Value":[{"a":10},{"a":20},{"a":30}]}}},{"Index":2,"Property":"2","Level":1,"Type":2,"Value":{"a":30},"Parent":{"Property":"@","Level":0,"Type":3,"Value":[{"a":10},{"a":20},{"a":30}]}},{"Property":"a","Level":2,"Type":1,"Value":30,"Parent":{"Index":2,"Property":"2","Level":1,"Type":2,"Value":{"a":30},"Parent":{"Property":"@","Level":0,"Type":3,"Value":[{"a":10},{"a":20},{"a":30}]}}}]`, JSON.stringify(m1), "#reference m1");

	console.log("JsonNode2 test successful");
});

//#endif
