using System;
using System.Text;
using System.Collections.Generic;
using System.IO;

using Microsoft.Ajax.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DllUnitTest.EnvDTE;

namespace DllUnitTest
{
    /// <summary>
    /// Summary description for ReplacementTokens
    /// </summary>
    [TestClass]
    public class ReplacementTokens
    {
        private static TestDirectoryService _directoryService = new TestDirectoryService(EnvDteDllUnitTest.ProjectDir, "TestData\\Dll\\ReplacementTokens\\");

        #region Additional test attributes

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        #endregion

        [TestMethod]
        public void ReplacementStringsJS()
        {
            // reuse the same parser object
            var parser = new JSParser();

            // default should leave tokens intact
            var settings = new CodeSettings();
            var source = "var a = 'He said, %My.Token:foo%'";
            var actual = Parse(parser, settings, source);
            Assert.AreEqual("var a=\"He said, %My.Token:foo%\"", actual);

            settings.ReplacementTokensApplyDefaults(new Dictionary<string, string> { 
                    { "my.token", "\"Now he's done it!\"" },
                    { "num_token", "123" },
                    { "my-json", "{\"a\": 1, \"b\": 2, \"c\": [ 1, 2, 3 ] }" },
                });
            settings.ReplacementFallbacks.Add("zero", "0");

            actual = Parse(parser, settings, source);
            Assert.AreEqual("var a='He said, \"Now he\\'s done it!\"'", actual);

            actual = Parse(parser, settings, "var b = '%Num_Token%';");
            Assert.AreEqual("var b=\"123\"", actual);

            actual = Parse(parser, settings, "var c = '%My-JSON%';");
            Assert.AreEqual("var c='{\"a\": 1, \"b\": 2, \"c\": [ 1, 2, 3 ] }'", actual);
        }

        [TestMethod]
        public void ReplacementNodesJS()
        {
            // reuse the same parser object
            var parser = new JSParser();

            // default should leave tokens intact
            var settings = new CodeSettings();
            var source = "var a = %My.Token:foo%;";
            var actual = Parse(parser, settings, source);
            Assert.AreEqual("var a=%My.Token:foo%", actual);

            settings.ReplacementTokensApplyDefaults(new Dictionary<string, string> { 
                    { "my.token", "\"Now he's done it!\"" },
                    { "num_token", "123" },
                    { "my-json", "{\"a\": 1, \"b\": 2, \"c\": [ 1, 2, 3 ] }" },
                });
            settings.ReplacementFallbacks.Add("zero", "0");

            actual = Parse(parser, settings, source);
            Assert.AreEqual("var a=\"Now he's done it!\"", actual);

            actual = Parse(parser, settings, "var b = %Num_Token%;");
            Assert.AreEqual("var b=123", actual);

            actual = Parse(parser, settings, "var c = %My-JSON%;");
            Assert.AreEqual("var c={\"a\":1,\"b\":2,\"c\":[1,2,3]}", actual);

            actual = Parse(parser, settings, "var d = '*%MissingToken:zero%*';");
            Assert.AreEqual("var d=\"*0*\"", actual);

            actual = Parse(parser, settings, "var e = '*%MissingToken:ack%*';");
            Assert.AreEqual("var e=\"**\"", actual);

            actual = Parse(parser, settings, "var f = '*%MissingToken:%*';");
            Assert.AreEqual("var f=\"**\"", actual);
        }

        [TestMethod]
        public void ReplacementFallbacksJS()
        {
            // reuse the same parser object
            var parser = new JSParser();

            // default should leave tokens intact
            var settings = new CodeSettings();

            settings.ReplacementTokensApplyDefaults(new Dictionary<string, string> { 
                    { "my.token", "\"Now he's done it!\"" },
                    { "num_token", "123" },
                    { "my-json", "{\"a\": 1, \"b\": 2, \"c\": [ 1, 2, 3 ] }" },
                });
            settings.ReplacementFallbacks.Add("zero", "0");

            var actual = Parse(parser, settings, "var a = %MissingToken:zero%;");
            Assert.AreEqual("var a=0", actual);

            actual = Parse(parser, settings, "var b = %MissingToken:ack% + 0;");
            Assert.AreEqual("var b=+0", actual);

            actual = Parse(parser, settings, "var c = %MissingToken:% + 0;");
            Assert.AreEqual("var c=+0", actual);

            actual = Parse(parser, settings, "var d = %MissingToken:%;debugger;throw 'why?';");
            Assert.AreEqual("var d=;throw\"why?\";", actual);
        }

        private string Parse(JSParser parser, CodeSettings settings, string source)
        {
            var block = parser.Parse(source, settings);
            return OutputVisitor.Apply(block, settings);
        }
    }
}
