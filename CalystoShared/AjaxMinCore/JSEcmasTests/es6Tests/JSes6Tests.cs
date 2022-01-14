using Calysto.UnitTesting;
using CalystoMinTests.EnvDTE;
using Microsoft.Ajax.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;
using System.Reflection;

namespace JSEcmasTests.es6Tests
{
	[TestClass]
	public class JSes6Tests
	{
		string _root = "es6Tests\\TestFiles\\";

		[TestMethod]
		public void TestMethod11()
		{
			string _input1 = @"
function * ReadColor (__this, includeCurrent) 
{
    yield 1;
	if(includeCurrent)
		yield 2;
	yield 55;
	if(includeCurrent)
		yield 66;
	yield 3;
}";

			string _expected1 = @"function*ReadColor(__this,includeCurrent){yield 1;if(includeCurrent){yield 2};yield 55;if(includeCurrent){yield 66};yield 3}";

			Minifier minifier = new Minifier();
			CodeSettings sett = new CodeSettings();
			sett.LocalRenaming = LocalRenaming.KeepAll;
			string min1 = minifier.MinifyJavaScript(_input1, sett);
			if (minifier.ErrorList.Any()) Assert.Fail(minifier.ErrorList.First() + "");
			if (minifier.Errors.Any()) Assert.Fail(minifier.Errors.First() + "");
			Assert.AreEqual(_expected1, min1);
		}

		[TestMethod]
		public void TestMethod12()
		{
			string _input1 = @"
function * ReadColor (__this, includeCurrent) 
{
    if (includeCurrent)
        yield __this;

    for (let child1 of [1,2,3]) 
	{
        yield child1;

        for (let child2 of [5,6,7])
			if(child)
				yield child2;
    }
}";

			string _expected1 = @"function*ReadColor(__this,includeCurrent){if(includeCurrent){yield __this};for(let child1 of[1,2,3]){yield child1;for(let child2 of[5,6,7]){if(child){yield child2}}}}";

			Minifier minifier = new Minifier();
			CodeSettings sett = new CodeSettings();
			sett.LocalRenaming = LocalRenaming.KeepAll;
			string min1 = minifier.MinifyJavaScript(_input1, sett);
			if (minifier.ErrorList.Any()) Assert.Fail(minifier.ErrorList.First() + "");
			if (minifier.Errors.Any()) Assert.Fail(minifier.Errors.First() + "");
			Assert.AreEqual(_expected1, min1);
		}

		[TestMethod]
		public void TestMethod13()
		{
			string js1 = "var obj = ((a,b,c) => {this.sum = a + b + c;})(1,2,3);";
			string exp1 = "var obj=((a,b,c)=>{this.sum=a+b+c})(1,2,3)";
			Minifier minifier = new Minifier();
			CodeSettings sett = new CodeSettings();
			sett.LocalRenaming = LocalRenaming.KeepAll;
			string min1 = minifier.MinifyJavaScript(js1, sett);
			if (minifier.ErrorList.Any()) Assert.Fail(minifier.ErrorList.First() + "");
			if (minifier.Errors.Any()) Assert.Fail(minifier.Errors.First() + "");
			Assert.AreEqual(exp1, min1);
		}

		[TestMethod]
		public void TestMethod14()
		{
			string js1 = "var array_after_spread = (...[foo]) => foo;";
			string exp1 = "var array_after_spread=(...[foo])=>foo";
			Minifier minifier = new Minifier();
			CodeSettings sett = new CodeSettings();
			sett.LocalRenaming = LocalRenaming.KeepAll;
			string min1 = minifier.MinifyJavaScript(js1, sett);
			if (minifier.ErrorList.Any()) Assert.Fail(minifier.ErrorList.First() + "");
			if (minifier.Errors.Any()) Assert.Fail(minifier.Errors.First() + "");
			Assert.AreEqual(exp1, min1);
		}

		[TestMethod]
		public void TestMethod3()
		{
			string js1 = @"
function One(fn)
{
	return console.log(
		fn ? x => { fn(); return 222; /*return*/ } : x=>x,
		fn? x => { fn(); throw x; /*throw*/ } : x => x
	);
}";

			string exp1 = "function One(fn){return console.log(fn?()=>{fn();return 222}:x=>x,fn?x=>{fn();throw x;}:x=>x)}";
			Minifier minifier = new Minifier();
			CodeSettings sett = new CodeSettings();
			sett.LocalRenaming = LocalRenaming.KeepAll;
			string min1 = minifier.MinifyJavaScript(js1, sett);
			if (minifier.ErrorList.Any()) Assert.Fail(minifier.ErrorList.First() + "");
			if (minifier.Errors.Any()) Assert.Fail(minifier.Errors.First() + "");
			Assert.AreEqual(exp1, min1);
		}

		[TestMethod]
		public void TestMethod31()
		{
			string js1 = @"(x => { fn(); return 66; })(5)";

			string exp1 = "(()=>{fn();return 66})(5)";
			Minifier minifier = new Minifier();
			CodeSettings sett = new CodeSettings();
			sett.LocalRenaming = LocalRenaming.KeepAll;
			string min1 = minifier.MinifyJavaScript(js1, sett);
			if (minifier.ErrorList.Any()) Assert.Fail(minifier.ErrorList.First() + "");
			if (minifier.Errors.Any()) Assert.Fail(minifier.Errors.First() + "");
			Assert.AreEqual(exp1, min1);
		}

		[TestMethod]
		public void TestMethod33()
		{
			string js1 = @"var m = x => { fn(); fn2(x); let k = b + 66; return k; };";

			string exp1 = "var m=x=>{fn();fn2(x);return b+66}";
			Minifier minifier = new Minifier();
			CodeSettings sett = new CodeSettings();
			sett.LocalRenaming = LocalRenaming.KeepAll;
			string min1 = minifier.MinifyJavaScript(js1, sett);
			if (minifier.ErrorList.Any()) Assert.Fail(minifier.ErrorList.First() + "");
			if (minifier.Errors.Any()) Assert.Fail(minifier.Errors.First() + "");
			Assert.AreEqual(exp1, min1);
		}

		[TestMethod]
		public void TestMethod34()
		{
			string js1 = @"var m = x => { fn(); fn2(x); return k; };";

			string exp1 = "var m=x=>{fn();fn2(x);return k}";
			Minifier minifier = new Minifier();
			CodeSettings sett = new CodeSettings();
			sett.LocalRenaming = LocalRenaming.KeepAll;
			string min1 = minifier.MinifyJavaScript(js1, sett);
			if (minifier.ErrorList.Any()) Assert.Fail(minifier.ErrorList.First() + "");
			if (minifier.Errors.Any()) Assert.Fail(minifier.Errors.First() + "");
			Assert.AreEqual(exp1, min1);
		}

		[TestMethod]
		public void TestMethod32()
		{
			string js1 = @"var m = x => { fn(); return b+66; };";

			string exp1 = "var m=()=>{fn();return b+66}";
			Minifier minifier = new Minifier();
			CodeSettings sett = new CodeSettings();
			sett.LocalRenaming = LocalRenaming.KeepAll;
			string min1 = minifier.MinifyJavaScript(js1, sett);
			if (minifier.ErrorList.Any()) Assert.Fail(minifier.ErrorList.First() + "");
			if (minifier.Errors.Any()) Assert.Fail(minifier.Errors.First() + "");
			Assert.AreEqual(exp1, min1);
		}

		[TestMethod]
		public void TestMethod36()
		{
			string js1 = @"var m = x => { fn(); yield b+66; };";

			string exp1 = "var m=()=>{fn();yield b+66}";
			Minifier minifier = new Minifier();
			CodeSettings sett = new CodeSettings();
			sett.LocalRenaming = LocalRenaming.KeepAll;
			string min1 = minifier.MinifyJavaScript(js1, sett);
			if (minifier.ErrorList.Any()) Assert.Fail(minifier.ErrorList.First() + "");
			if (minifier.Errors.Any()) Assert.Fail(minifier.Errors.First() + "");
			Assert.AreEqual(exp1, min1);
		}

		[TestMethod]
		public void TestMethod37()
		{
			string js1 = @"var m = x => { yield b+66; };";

			string exp1 = "var m=()=>{yield b+66}";
			Minifier minifier = new Minifier();
			CodeSettings sett = new CodeSettings();
			sett.LocalRenaming = LocalRenaming.KeepAll;
			string min1 = minifier.MinifyJavaScript(js1, sett);
			if (minifier.ErrorList.Any()) Assert.Fail(minifier.ErrorList.First() + "");
			if (minifier.Errors.Any()) Assert.Fail(minifier.Errors.First() + "");
			Assert.AreEqual(exp1, min1);
		}

		[TestMethod]
		public void TestMethod35()
		{
			string js1 = @"var m = x => { fn(); };";

			string exp1 = "var m=()=>{fn()}";
			Minifier minifier = new Minifier();
			CodeSettings sett = new CodeSettings();
			sett.LocalRenaming = LocalRenaming.KeepAll;
			string min1 = minifier.MinifyJavaScript(js1, sett);
			if (minifier.ErrorList.Any()) Assert.Fail(minifier.ErrorList.First() + "");
			if (minifier.Errors.Any()) Assert.Fail(minifier.Errors.First() + "");
			Assert.AreEqual(exp1, min1);
		}
		
		[TestMethod]
		public void TestMethod38()
		{
			string js1 = @"let res = yield fbInitializeEngineAsync();
yield 33;
let kk = yield 6435();";

			string exp1 = "let res=yield fbInitializeEngineAsync();yield 33;let kk=yield 6435()";
			Minifier minifier = new Minifier();
			CodeSettings sett = new CodeSettings();
			sett.LocalRenaming = LocalRenaming.KeepAll;
			string min1 = minifier.MinifyJavaScript(js1, sett);
			if (minifier.ErrorList.Any()) Assert.Fail(minifier.ErrorList.First() + "");
			if (minifier.Errors.Any()) Assert.Fail(minifier.Errors.First() + "");
			Assert.AreEqual(exp1, min1);
		}

		[TestMethod]
		public void TestMethod39()
		{
			string js1 = @"let mm = 	fn ? x => { fn(); return x; } : x=>x;";
			
			string exp1 = "let mm=fn?x=>{fn();return x}:x=>x";
			Minifier minifier = new Minifier();
			CodeSettings sett = new CodeSettings();
			sett.LocalRenaming = LocalRenaming.KeepAll;
			string min1 = minifier.MinifyJavaScript(js1, sett);
			if (minifier.ErrorList.Any()) Assert.Fail(minifier.ErrorList.First() + "");
			if (minifier.Errors.Any()) Assert.Fail(minifier.Errors.First() + "");
			Assert.AreEqual(exp1, min1);
		}

		[TestMethod]
		public void TestMethod391()
		{
			string js1 = @"function One(){ return `Wellcome ${yourName}, you've been here ${count1} times and ${age2} ages.`;}";

			string exp1 = @"function One(){return`Wellcome ${yourName}, you've been here ${count1} times and ${age2} ages.`}";
			Minifier minifier = new Minifier();
			CodeSettings sett = new CodeSettings();
			sett.LocalRenaming = LocalRenaming.KeepAll;
			string min1 = minifier.MinifyJavaScript(js1, sett);
			if (minifier.ErrorList.Any()) Assert.Fail(minifier.ErrorList.First() + "");
			if (minifier.Errors.Any()) Assert.Fail(minifier.Errors.First() + "");
			Assert.AreEqual(exp1, min1);
		}


		[TestMethod]
		public void TestMethod392()
		{
			string js1 = @"function One(){ return `Wellcome ""${yourName}"", you've been here ""${count1}"" times and ""${age2}"" ages.`;}";

			string exp1 = @"function One(){return`Wellcome ""${yourName}"", you've been here ""${count1}"" times and ""${age2}"" ages.`}";
			Minifier minifier = new Minifier();
			CodeSettings sett = new CodeSettings();
			sett.LocalRenaming = LocalRenaming.KeepAll;
			string min1 = minifier.MinifyJavaScript(js1, sett);
			if (minifier.ErrorList.Any()) Assert.Fail(minifier.ErrorList.First() + "");
			if (minifier.Errors.Any()) Assert.Fail(minifier.Errors.First() + "");
			Assert.AreEqual(exp1, min1);
		}

		[TestMethod]
		public void TestMethod393()
		{
			string js1 = @"function One(){ return `Wellcome ""${yourName}"", have a great time.
 `;}";

			string exp1 = @"function One(){return`Wellcome ""${yourName}"", have a great time.
 `}";
			Minifier minifier = new Minifier();
			CodeSettings sett = new CodeSettings();
			sett.LocalRenaming = LocalRenaming.KeepAll;
			string min1 = minifier.MinifyJavaScript(js1, sett);
			if (minifier.ErrorList.Any()) Assert.Fail(minifier.ErrorList.First() + "");
			if (minifier.Errors.Any()) Assert.Fail(minifier.Errors.First() + "");
			Assert.AreEqual(exp1, min1);
		}

		[TestMethod]
		public void TestMethod394()
		{
			string js1 = @"function One(){ return `Wellcome ""${yourName}"", have a great time.`;}";

			string exp1 = @"function One(){return`Wellcome ""${yourName}"", have a great time.`}";
			Minifier minifier = new Minifier();
			CodeSettings sett = new CodeSettings();
			sett.LocalRenaming = LocalRenaming.KeepAll;
			string min1 = minifier.MinifyJavaScript(js1, sett);
			if (minifier.ErrorList.Any()) Assert.Fail(minifier.ErrorList.First() + "");
			if (minifier.Errors.Any()) Assert.Fail(minifier.Errors.First() + "");
			Assert.AreEqual(exp1, min1);
		}

		[TestMethod]
		public void TestMethod395()
		{
			string js1 = @"function One(){ return `Wellcome ""${yourName}"", nice.
`;}";

			string exp1 = @"function One(){return`Wellcome ""${yourName}"", nice.
`}";
			Minifier minifier = new Minifier();
			CodeSettings sett = new CodeSettings();
			sett.LocalRenaming = LocalRenaming.KeepAll;
			string min1 = minifier.MinifyJavaScript(js1, sett);
			if (minifier.ErrorList.Any()) Assert.Fail(minifier.ErrorList.First() + "");
			if (minifier.Errors.Any()) Assert.Fail(minifier.Errors.First() + "");
			Assert.AreEqual(exp1, min1);
		}

		/// <summary>
		/// encapsulated function fnCreateAndSendRequest()
		/// </summary>
		[TestMethod]
		public void TestMethod42()
		{
			TestFilesProvider2 provider = new Calysto.UnitTesting.TestFilesProvider2(Path.Join(_root, MethodInfo.GetCurrentMethod().Name + ".js"));
			string inputJs = provider.Input.Read().Text;
			string expectedJs = provider.Expected.Read().Text;
			string outputFile = provider.Actual.FullPath;

			Minifier minifier = new Minifier();
			CodeSettings sett = new CodeSettings();
			sett.LocalRenaming = LocalRenaming.KeepAll;
			string min1 = minifier.MinifyJavaScript(inputJs, sett);
			File.WriteAllText(outputFile, min1);

			if (minifier.ErrorList.Any()) Assert.Fail(minifier.ErrorList.First() + "");
			if (minifier.Errors.Any()) Assert.Fail(minifier.Errors.First() + "");
			Assert.AreEqual(expectedJs, min1);
		}

		/// <summary>
		/// encapsulated namespace Mvc.AjaxForm
		/// </summary>
		[TestMethod]
		public void TestMethod43()
		{
			TestFilesProvider2 provider = new Calysto.UnitTesting.TestFilesProvider2(Path.Join(_root, MethodInfo.GetCurrentMethod().Name + ".js"));
			string inputJs = provider.Input.Read().Text;
			string expectedJs = provider.Expected.Read().Text;
			string outputFile = provider.Actual.FullPath;

			Minifier minifier = new Minifier();
			CodeSettings sett = new CodeSettings();
			sett.LocalRenaming = LocalRenaming.KeepAll;
			string min1 = minifier.MinifyJavaScript(inputJs, sett);
			File.WriteAllText(outputFile, min1);

			if (minifier.ErrorList.Any()) Assert.Fail(minifier.ErrorList.First() + "");
			if (minifier.Errors.Any()) Assert.Fail(minifier.Errors.First() + "");
			Assert.AreEqual(expectedJs, min1);
		}

		[TestMethod]
		public void TestMethod44()
		{
			TestFilesProvider2 provider = new Calysto.UnitTesting.TestFilesProvider2(Path.Join(_root, MethodInfo.GetCurrentMethod().Name + ".js"));
			string inputJs = provider.Input.Read().Text;
			string expectedJs = provider.Expected.Read().Text;
			string outputFile = provider.Actual.FullPath;

			Minifier minifier = new Minifier();
			CodeSettings sett = new CodeSettings();
			sett.LocalRenaming = LocalRenaming.CrunchAll;
			string min1 = minifier.MinifyJavaScript(inputJs, sett);
			File.WriteAllText(outputFile, min1);

			if (minifier.ErrorList.Any()) Assert.Fail(minifier.ErrorList.First() + "");
			if (minifier.Errors.Any()) Assert.Fail(minifier.Errors.First() + "");
			Assert.AreEqual(expectedJs, min1);
		}

		/// <summary>
		/// encapsulated namespace Calysto.Tasks
		/// </summary>
		[TestMethod]
		public void TestMethod45()
		{
			TestFilesProvider2 provider = new Calysto.UnitTesting.TestFilesProvider2(Path.Join(_root, MethodInfo.GetCurrentMethod().Name + ".js"));
			string inputJs = provider.Input.Read().Text;
			string expectedJs = provider.Expected.Read().Text;
			string outputFile = provider.Actual.FullPath;

			Minifier minifier = new Minifier();
			CodeSettings sett = new CodeSettings();
			sett.LocalRenaming = LocalRenaming.KeepAll;
			string min1 = minifier.MinifyJavaScript(inputJs, sett);
			File.WriteAllText(outputFile, min1);

			if (minifier.ErrorList.Any()) Assert.Fail(minifier.ErrorList.First() + "");
			if (minifier.Errors.Any()) Assert.Fail(minifier.Errors.First() + "");
			Assert.AreEqual(expectedJs, min1);
		}

		/// <summary>
		/// es6 string format
		/// </summary>
		[TestMethod]
		public void TestMethod46()
		{
			TestFilesProvider2 provider = new Calysto.UnitTesting.TestFilesProvider2(Path.Join(_root, MethodInfo.GetCurrentMethod().Name + ".js"));
			string inputJs = provider.Input.Read().Text;
			string expectedJs = provider.Expected.Read().Text;
			string outputFile = provider.Actual.FullPath;

			Minifier minifier = new Minifier();
			CodeSettings sett = new CodeSettings();
			sett.LocalRenaming = LocalRenaming.KeepAll;
			string min1 = minifier.MinifyJavaScript(inputJs, sett);
			File.WriteAllText(outputFile, min1);

			if (minifier.ErrorList.Any()) Assert.Fail(minifier.ErrorList.First() + "");
			if (minifier.Errors.Any()) Assert.Fail(minifier.Errors.First() + "");
			Assert.AreEqual(expectedJs, min1);
		}

		/// <summary>
		/// complete Calysto engine js, keep local variables
		/// </summary>
		[TestMethod]
		public void TestMethod51()
		{
			TestFilesProvider2 provider = new Calysto.UnitTesting.TestFilesProvider2(Path.Join(_root, MethodInfo.GetCurrentMethod().Name + ".js"));
			string inputJs = provider.Input.Read().Text;
			string expectedJs = provider.Expected.Read().Text;
			string outputFile = provider.Actual.FullPath;

			Minifier minifier = new Minifier();
			CodeSettings sett = new CodeSettings();
			sett.LocalRenaming = LocalRenaming.KeepAll; /// <<< KeepAll
			string min1 = minifier.MinifyJavaScript(inputJs, sett);
			File.WriteAllText(outputFile, min1);

			if (minifier.ErrorList.Any()) Assert.Fail(minifier.ErrorList.First() + "");
			if (minifier.Errors.Any()) Assert.Fail(minifier.Errors.First() + "");
			Assert.AreEqual(expectedJs, min1);
		}

		/// <summary>
		/// complete Calysto engine js, crunch local variables
		/// </summary>
		[TestMethod]
		public void TestMethod52()
		{
			TestFilesProvider2 provider = new Calysto.UnitTesting.TestFilesProvider2(Path.Join(_root, MethodInfo.GetCurrentMethod().Name + ".js"));
			string inputJs = provider.Input.Read().Text;
			string expectedJs = provider.Expected.Read().Text;
			string outputFile = provider.Actual.FullPath;

			Minifier minifier = new Minifier();
			CodeSettings sett = new CodeSettings();
			sett.LocalRenaming = LocalRenaming.CrunchAll; /// <<< CrunchAll
			string min1 = minifier.MinifyJavaScript(inputJs, sett);
			File.WriteAllText(outputFile, min1);

			if (minifier.ErrorList.Any()) Assert.Fail(minifier.ErrorList.First() + "");
			if (minifier.Errors.Any()) Assert.Fail(minifier.Errors.First() + "");
			Assert.AreEqual(expectedJs, min1);
		}

		[TestMethod]
		public void TestMethod62()
		{
			TestFilesProvider2 provider = new Calysto.UnitTesting.TestFilesProvider2(Path.Join(_root, MethodInfo.GetCurrentMethod().Name + ".js"));
			string inputJs = provider.Input.Read().Text;
			string expectedJs = provider.Expected.Read().Text;
			string outputFile = provider.Actual.FullPath;

			Minifier minifier = new Minifier();
			CodeSettings sett = new CodeSettings();
			sett.LocalRenaming = LocalRenaming.CrunchAll; /// <<< CrunchAll
			string min1 = minifier.MinifyJavaScript(inputJs, sett);
			File.WriteAllText(outputFile, min1);

			if (minifier.ErrorList.Any()) Assert.Fail(minifier.ErrorList.First() + "");
			if (minifier.Errors.Any()) Assert.Fail(minifier.Errors.First() + "");
			Assert.AreEqual(expectedJs, min1);
		}

		[TestMethod]
		public void TestMethod63()
		{
			TestFilesProvider2 provider = new Calysto.UnitTesting.TestFilesProvider2(Path.Join(_root, MethodInfo.GetCurrentMethod().Name + ".js"));
			string inputJs = provider.Input.Read().Text;
			string expectedJs = provider.Expected.Read().Text;
			string outputFile = provider.Actual.FullPath;

			Minifier minifier = new Minifier();
			CodeSettings sett = new CodeSettings();
			sett.LocalRenaming = LocalRenaming.CrunchAll; /// <<< CrunchAll
			string min1 = minifier.MinifyJavaScript(inputJs, sett);
			File.WriteAllText(outputFile, min1);

			if (minifier.ErrorList.Any()) Assert.Fail(minifier.ErrorList.First() + "");
			if (minifier.Errors.Any()) Assert.Fail(minifier.Errors.First() + "");
			Assert.AreEqual(expectedJs, min1);
		}

		[TestMethod]
		public void TestMethod64()
		{
			TestFilesProvider2 provider = new Calysto.UnitTesting.TestFilesProvider2(Path.Join(_root, MethodInfo.GetCurrentMethod().Name + ".js"));
			string inputJs = provider.Input.Read().Text;
			string expectedJs = provider.Expected.Read().Text;
			string outputFile = provider.Actual.FullPath;

			Minifier minifier = new Minifier();
			CodeSettings sett = new CodeSettings();
			sett.LocalRenaming = LocalRenaming.CrunchAll; /// <<< CrunchAll
			string min1 = minifier.MinifyJavaScript(inputJs, sett);
			File.WriteAllText(outputFile, min1);

			if (minifier.ErrorList.Any()) Assert.Fail(minifier.ErrorList.First() + "");
			if (minifier.Errors.Any()) Assert.Fail(minifier.Errors.First() + "");
			Assert.AreEqual(expectedJs, min1);
		}

		[TestMethod]
		public void TestMethod65()
		{
			TestFilesProvider2 provider = new Calysto.UnitTesting.TestFilesProvider2(Path.Join(_root, MethodInfo.GetCurrentMethod().Name + ".js"));
			string inputJs = provider.Input.Read().Text;
			string expectedJs = provider.Expected.Read().Text;
			string outputFile = provider.Actual.FullPath;

			Minifier minifier = new Minifier();
			CodeSettings sett = new CodeSettings();
			sett.LocalRenaming = LocalRenaming.CrunchAll; /// <<< CrunchAll
			string min1 = minifier.MinifyJavaScript(inputJs, sett);
			File.WriteAllText(outputFile, min1);

			if (minifier.ErrorList.Any()) Assert.Fail(minifier.ErrorList.First() + "");
			if (minifier.Errors.Any()) Assert.Fail(minifier.Errors.First() + "");
			Assert.AreEqual(expectedJs, min1);
		}

		[TestMethod]
		public void TestMethod66()
		{
			TestFilesProvider2 provider = new Calysto.UnitTesting.TestFilesProvider2(Path.Join(_root, MethodInfo.GetCurrentMethod().Name + ".js"));
			string inputJs = provider.Input.Read().Text;
			string expectedJs = provider.Expected.Read().Text;
			string outputFile = provider.Actual.FullPath;

			Minifier minifier = new Minifier();
			CodeSettings sett = new CodeSettings();
			sett.LocalRenaming = LocalRenaming.CrunchAll; /// <<< CrunchAll
			string min1 = minifier.MinifyJavaScript(inputJs, sett);
			File.WriteAllText(outputFile, min1);

			if (minifier.ErrorList.Any()) Assert.Fail(minifier.ErrorList.First() + "");
			if (minifier.Errors.Any()) Assert.Fail(minifier.Errors.First() + "");
			Assert.AreEqual(expectedJs, min1);
		}

		[TestMethod]
		public void TestMethod67()
		{
			TestFilesProvider2 provider = new Calysto.UnitTesting.TestFilesProvider2(Path.Join(_root, MethodInfo.GetCurrentMethod().Name + ".js"));
			string inputJs = provider.Input.Read().Text;
			string expectedJs = provider.Expected.Read().Text;
			string outputFile = provider.Actual.FullPath;

			Minifier minifier = new Minifier();
			CodeSettings sett = new CodeSettings();
			sett.LocalRenaming = LocalRenaming.CrunchAll; /// <<< CrunchAll
			string min1 = minifier.MinifyJavaScript(inputJs, sett);
			File.WriteAllText(outputFile, min1);

			if (minifier.ErrorList.Any()) Assert.Fail(minifier.ErrorList.First() + "");
			if (minifier.Errors.Any()) Assert.Fail(minifier.Errors.First() + "");
			Assert.AreEqual(expectedJs, min1);
		}

		[TestMethod]
		public void TestMethod68()
		{
			TestFilesProvider2 provider = new Calysto.UnitTesting.TestFilesProvider2(Path.Join(_root, MethodInfo.GetCurrentMethod().Name + ".js"));
			string inputJs = provider.Input.Read().Text;
			string expectedJs = provider.Expected.Read().Text;
			string outputFile = provider.Actual.FullPath;

			Minifier minifier = new Minifier();
			CodeSettings sett = new CodeSettings();
			sett.LocalRenaming = LocalRenaming.CrunchAll; /// <<< CrunchAll
			string min1 = minifier.MinifyJavaScript(inputJs, sett);
			File.WriteAllText(outputFile, min1);

			if (minifier.ErrorList.Any()) Assert.Fail(minifier.ErrorList.First() + "");
			if (minifier.Errors.Any()) Assert.Fail(minifier.Errors.First() + "");
			Assert.AreEqual(expectedJs, min1);
		}

		[TestMethod]
		public void TestMethod69()
		{
			TestFilesProvider2 provider = new Calysto.UnitTesting.TestFilesProvider2(Path.Join(_root, MethodInfo.GetCurrentMethod().Name + ".js"));
			string inputJs = provider.Input.Read().Text;
			string expectedJs = provider.Expected.Read().Text;
			string outputFile = provider.Actual.FullPath;

			Minifier minifier = new Minifier();
			CodeSettings sett = new CodeSettings();
			sett.LocalRenaming = LocalRenaming.CrunchAll; /// <<< CrunchAll
			string min1 = minifier.MinifyJavaScript(inputJs, sett);
			File.WriteAllText(outputFile, min1);

			if (minifier.ErrorList.Any()) Assert.Fail(minifier.ErrorList.First() + "");
			if (minifier.Errors.Any()) Assert.Fail(minifier.Errors.First() + "");
			Assert.AreEqual(expectedJs, min1);
		}

		[TestMethod]
		public void TestMethod90()
		{
			TestFilesProvider2 provider = new Calysto.UnitTesting.TestFilesProvider2(Path.Join(_root, MethodInfo.GetCurrentMethod().Name + ".js"));
			string inputJs = provider.Input.Read().Text;
			string expectedJs = provider.Expected.Read().Text;
			string outputFile = provider.Actual.FullPath;

			Minifier minifier = new Minifier();
			CodeSettings sett = new CodeSettings();
			sett.LocalRenaming = LocalRenaming.CrunchAll; /// <<< CrunchAll
			string min1 = minifier.MinifyJavaScript(inputJs, sett);
			File.WriteAllText(outputFile, min1);

			if (minifier.ErrorList.Any()) Assert.Fail(minifier.ErrorList.First() + "");
			if (minifier.Errors.Any()) Assert.Fail(minifier.Errors.First() + "");
			Assert.AreEqual(expectedJs, min1);
		}

		[TestMethod]
		public void TestMethod91()
		{
			TestFilesProvider2 provider = new Calysto.UnitTesting.TestFilesProvider2(Path.Join(_root, MethodInfo.GetCurrentMethod().Name + ".js"));
			string inputJs = provider.Input.Read().Text;
			string expectedJs = provider.Expected.Read().Text;
			string outputFile = provider.Actual.FullPath;

			Minifier minifier = new Minifier();
			CodeSettings sett = new CodeSettings();
			sett.LocalRenaming = LocalRenaming.KeepAll;
			string min1 = minifier.MinifyJavaScript(inputJs, sett);
			File.WriteAllText(outputFile, min1);

			if (minifier.ErrorList.Any()) Assert.Fail(minifier.ErrorList.First() + "");
			if (minifier.Errors.Any()) Assert.Fail(minifier.Errors.First() + "");
			Assert.AreEqual(expectedJs, min1);
		}

		[TestMethod]
		public void TestMethod92()
		{
			TestFilesProvider2 provider = new Calysto.UnitTesting.TestFilesProvider2(Path.Join(_root, MethodInfo.GetCurrentMethod().Name + ".js"));
			string inputJs = provider.Input.Read().Text;
			string expectedJs = provider.Expected.Read().Text;
			string outputFile = provider.Actual.FullPath;

			Minifier minifier = new Minifier();
			CodeSettings sett = new CodeSettings();
			sett.LocalRenaming = LocalRenaming.KeepAll;
			string min1 = minifier.MinifyJavaScript(inputJs, sett);
			File.WriteAllText(outputFile, min1);

			if (minifier.ErrorList.Any()) Assert.Fail(minifier.ErrorList.First() + "");
			if (minifier.Errors.Any()) Assert.Fail(minifier.Errors.First() + "");
			Assert.AreEqual(expectedJs, min1);
		}

	}
}
