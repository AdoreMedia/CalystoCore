using System;
using System.Diagnostics;

using Microsoft.Ajax.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DllUnitTest
{
    /// <summary>
    /// Summary description for CssErrorStrings
    /// </summary>
    [TestClass]
    public class ErrorStrings
    {
        [TestMethod]
        public void JSErrorStringsExist()
        {
            var hasFailed = false;
            foreach (var jsErrorName in Enum.GetNames(typeof(JSError)))
            {
                if (jsErrorName != "NoError")
                {
                    JSError errorCode;
                    if (Enum.TryParse(jsErrorName, out errorCode))
                    {
                        var message = Context.GetErrorString(errorCode);
                        if (message.IsNullOrWhiteSpace())
                        {
                            Trace.WriteLine(jsErrorName + " has no corresponding error message");
                            hasFailed = true;
                        }
                    }
                    else
                    {
                        Trace.WriteLine(jsErrorName + " failed to parse back into enum");
                        hasFailed = true;
                    }
                }
            }

            Assert.IsFalse(hasFailed);
        }
    }
}
