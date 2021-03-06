// ResourceMerge.cs
//
// Copyright 2010 Microsoft Corporation
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JSUnitTest
{
    /// <summary>
    /// Summary description for ResourceMerge
    /// </summary>
    [TestClass]
    public class ResourceMerge
    {
        [TestMethod]
        public void ResourceResx()
        {
            TestHelper.Instance.RunTest("-res:Strings");
        }

        //[TestMethod]
        //public void ResourceResx_I()
        //{
        //    TestHelper.Instance.RunTest("-res:Strings -echo -enc:out ascii");
        //}

        [TestMethod]
        public void Resources()
        {
            TestHelper.Instance.RunTest("-res:Strings -rename:all -literals:combine");
        }

        [TestMethod]
        public void StringsFooBar()
        {
            TestHelper.Instance.RunTest("-res:Strings.Foo.Bar");
        }

        [TestMethod]
        public void ReplacementTokens()
        {
            // parse replacement tokens without error
            TestHelper.Instance.RunErrorTest("-rename:none");
        }
    }
}
