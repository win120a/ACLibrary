/*
   Copyright (C) 2011-2014 AC Inc. (Andy Cheung)

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using ACLibrary.Collection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TestCollectionLib
{
    [TestClass]
    public class TestConvert
    {
        Dictionary<string, int> testODict;
        ACDictionary<string, int> testADict;
        Dictionary<string, int> anotherTestODict;

        [TestInitialize]
        public void SetUp()
        {
            testODict = new Dictionary<string, int>();
            testODict.Add("First", 1);
            testODict.Add("Second", 1);
        }

        [TestMethod]
        public void TestDict2ACDict()
        {
            testADict = (ACDictionary<string, int>) ACDictionary<string, int>.SystemCollection2ACCollection(testODict);
            Assert.AreEqual(1, testADict.Get("First"));
        }

        [TestMethod]
        public void TestACDict2SDict()
        {
            testADict = (ACDictionary<string, int>)ACDictionary<string, int>.SystemCollection2ACCollection(testODict);
            anotherTestODict = (Dictionary<string, int>) testADict.ToSystemCollection();
            Assert.AreEqual(1, anotherTestODict["First"]);
        }
    }
}
