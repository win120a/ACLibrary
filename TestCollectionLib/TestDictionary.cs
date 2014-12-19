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
    public class TestDictionary
    {
        ACDictionary<string, int> testDict;

        [TestInitialize]
        public void SetUp()
        {
            testDict = new ACDictionary<string,int>();
            testDict.Add("First", 1);
            testDict.Add("Second", 1);
        }

        [TestMethod]
        public void TestKeySet()
        {
            List<string> ls = new List<string>();

            foreach (string s in testDict.KeySet())
            {
                ls.Add(s);
            }

            Assert.AreEqual("First", ls[0]);
        }

        [TestMethod]
        public void TestValueSet()
        {
            List<int> ls = new List<int>();

            foreach (int s in testDict.ValueSet())
            {
                ls.Add(s);
            }

            Assert.AreEqual(1, ls[0]);
        }
    }
}
