using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using DllUnitTest.EnvDTE;
using Microsoft.Ajax.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DllUnitTest
{
    /// <summary>
    /// Summary description for LogicalNot
    /// </summary>
    [TestClass]
    public class LogicalNot
    {
        private static TestDirectoryService _directoryService = new TestDirectoryService(EnvDteDllUnitTest.ProjectDir, "TestData\\Dll\\LogicalNot\\");

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        class TestItem
        {
            public string Input;
            public string Expected;
        }

        private static IEnumerable<TestItem> ReadLines(string txt)
        {
            return txt.Split('\r', '\n').Where(o => !string.IsNullOrEmpty(o))
                .Select(line => line.Split(new string[] { "###" }, System.StringSplitOptions.None))
                .Select(arr => new TestItem() { Input = arr[0], Expected = arr[1] });
        }

        [TestMethod]
        public void NotExpressions()
        {
            string path1 = _directoryService.CreateFilePath(o => o.InputDirectory, "NotExpressions.csv");
            string txt = File.ReadAllText(path1);

            foreach (var item in ReadLines(txt))
                RunTest(item.Input, item.Expected);
        }

        private void RunTest(string expressionSource, string expectedResult)
        {
            // parse the source into an AST
            var parser = new JSParser();
            var block = parser.Parse(expressionSource, new CodeSettings() { MinifyCode = false, SourceMode = JavaScriptSourceMode.Expression });

            if (block.Count == 1)
            {
                var expression = block[0];

                // create the logical-not visitor on the expression
                var logicalNot = new Microsoft.Ajax.Utilities.LogicalNot(expression, parser.Settings);

                // get the original code
                var original = OutputVisitor.Apply(expression, parser.Settings);

                Trace.Write("ORIGINAL EXPRESSION:    ");
                Trace.WriteLine(original);

                // get the measured delta
                var measuredDelta = logicalNot.Measure();

                // perform the logical-not operation
                logicalNot.Apply();

                // get the resulting code -- should still be only one statement in the block
                var notted = OutputVisitor.Apply(block[0], parser.Settings);

                Trace.Write("LOGICAL-NOT EXPRESSION: ");
                Trace.WriteLine(notted);

                Trace.Write("EXPECTED EXPRESSION:    ");
                Trace.WriteLine(expectedResult);

                Trace.Write("DELTA: ");
                Trace.WriteLine(measuredDelta);

                // what's the actual difference
                var actualDelta = notted.Length - original.Length;
                Assert.AreEqual(actualDelta, measuredDelta,
                    "Measurement was off; calculated {0} but was actually {1}",
                    measuredDelta,
                    actualDelta);

                Assert.AreEqual(expectedResult, notted, "Expected output is not the same!!!!");
            }
            else
            {
                Assert.Fail(string.Format("Source line '{0}' parsed to more than one statement!", expressionSource));
            }
        }
    }
}
