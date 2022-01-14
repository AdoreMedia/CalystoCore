//using Microsoft.Ajax.Utilities;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Calysto.Web.Tests.Calysto.Optimization
//{
//	[TestClass]
//	public class Class1
//	{
//		[TestMethod]
//		public void CssMinifyTest1()
//		{
//			CodeSettings codeSettings = new CodeSettings()
//			{

//			};

//			CssSettings sett = new CssSettings()
//			{
//				CommentMode = CssComment.None,
//			};

//			string content1 = "";

//			Minifier min = new Minifier();
//			string minifiedCss = min.MinifyStyleSheet(content1, sett);
//			if (min.ErrorList.Count > 0)
//			{
//				//JsMinify.GenerateErrorResponse(response, min.ErrorList);
//			}
//			else
//			{
//				//response.Content = minifiedCss;
//			}
//		}

//		[TestMethod]
//		public void JsMinifyTest1()
//		{
//			CodeSettings codeSettings = new CodeSettings()
//			{
//				EvalTreatment = EvalTreatment.MakeImmediateSafe,
//				PreserveImportantComments = false,
//				StrictMode = true,
//				SourceMode = JavaScriptSourceMode.Program,
//				Format = JavaScriptFormat.Normal,
//				ScriptVersion = ScriptVersion.EcmaScript6

//			};

//			string content1 = @"
//function ja(name){
//	return name;
//}

//let fn = (name)=> name;

//let fn2 = function(name){
//	ret	urn name;
//};


//";


//			Minifier min = new Minifier();
//			string minified = min.MinifyJavaScript(content1, codeSettings);
//			if (min.ErrorList.Count > 0)
//			{
//				//JsMinify.GenerateErrorResponse(response, min.ErrorList);
//			}
//			else
//			{
//				//response.Content = minified;
//			}
//		}

//	}
//}
