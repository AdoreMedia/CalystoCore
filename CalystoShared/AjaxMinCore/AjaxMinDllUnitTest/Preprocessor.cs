using System;
using System.Collections.Generic;
using System.IO;
using DllUnitTest.EnvDTE;
using Microsoft.Ajax.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DllUnitTest
{
    [TestClass]
    public class Preprocessor
    {
        private static TestDirectoryService _directoryService = new TestDirectoryService(EnvDteDllUnitTest.ProjectDir, "TestData\\Dll\\Preprocessor\\");

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void SourceDirectiveJS()
        {
            string source;
            using (var reader = new StreamReader(_directoryService.CreateFilePath(d => d.InputDirectory, @"SourceDirective.js")))
            {
                source = reader.ReadToEnd();
            }

            var errors = new List<Tuple<string, int, int>>
                {
                    new Tuple<string, int, int>("foo.js", 12, 3),
                    new Tuple<string, int, int>("foo.js", 12, 7),
                    new Tuple<string, int, int>("fargo.htm", 5, 44),
                    new Tuple<string, int, int>("fargo.htm", 5, 48),
                };

            var errorCount = 0;
            var parser = new JSParser();
            parser.CompilerError += (sender, ea) =>
                {
                    Assert.IsTrue(errors.Count > errorCount, "too many errors");
                    Assert.AreEqual(errors[errorCount].Item1, ea.Error.File, "file path");
                    Assert.AreEqual(errors[errorCount].Item2, ea.Error.StartLine, "line number");
                    Assert.AreEqual(errors[errorCount].Item3, ea.Error.StartColumn, "column number");

                    ++errorCount;
                };
            var block = parser.Parse(source, new CodeSettings());
            Assert.AreEqual(errors.Count, errorCount, "errors found");
        }


    }
}
