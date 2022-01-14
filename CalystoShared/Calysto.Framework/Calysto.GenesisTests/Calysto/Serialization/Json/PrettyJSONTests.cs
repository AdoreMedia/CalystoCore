using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calysto.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Calysto.Serialization.Json.Tests
{
	[TestClass()]
	public class PrettyJSONTests
	{
		const string _src = @"var cx = {""ModuleVersion"":""610aeb04-1b53-48f2-af78-fe245914e5cb"",""DomAttributes"":{""CalystoId"":""calysto-id"",""CalystoValidatorMsgFor"":""calysto-validator-msg-for"",""CalystoSummaryMsgFor"":""calysto-summary-msg-for"",""CalystoErrorMsgFor"":""calysto-error-msg-for"",""CalystoType"":""calysto-type"",""CalystoGetter"":""calysto-getter"",""CalystoSetter"":""calysto-setter""},""HandlerConstants"":{""XAjaxHeaderKey"":""calysto-x-ajax"",""XAjaxHeaderValue"":""calysto-ajax"",""XExceptionHeaderValue"":""calysto-exception"",""XTypeHeaderKey"":""calysto-x-type"",""XTypeHeaderBinaryFrameValue"":""calysto-binary-frame""}};";

		const string _result1 = @"var cx = 
{
    ""ModuleVersion"": ""610aeb04-1b53-48f2-af78-fe245914e5cb"",
    ""DomAttributes"": 
    {
        ""CalystoId"": ""calysto-id"",
        ""CalystoValidatorMsgFor"": ""calysto-validator-msg-for"",
        ""CalystoSummaryMsgFor"": ""calysto-summary-msg-for"",
        ""CalystoErrorMsgFor"": ""calysto-error-msg-for"",
        ""CalystoType"": ""calysto-type"",
        ""CalystoGetter"": ""calysto-getter"",
        ""CalystoSetter"": ""calysto-setter""
    },
    ""HandlerConstants"": 
    {
        ""XAjaxHeaderKey"": ""calysto-x-ajax"",
        ""XAjaxHeaderValue"": ""calysto-ajax"",
        ""XExceptionHeaderValue"": ""calysto-exception"",
        ""XTypeHeaderKey"": ""calysto-x-type"",
        ""XTypeHeaderBinaryFrameValue"": ""calysto-binary-frame""
    }
};";

		[TestMethod()]
		public void PrettyJSONFormatTest()
		{
			string res1 = PrettyJSON.PrettyJSONFormat(_src);
            //File.WriteAllText("c:\\local\\temp1\\res1.txt", res1);
            Assert.AreEqual(_result1, res1);
		}
	}
}