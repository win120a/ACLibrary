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
    public class TestACList
    {
        ACList<int> acl;
        List<int> sl;

        [TestInitialize]
        public void Setup()
        {
            sl = new List<int>();
            sl.Add(1);
            sl.Add(2);

            acl = new ACList<int>();
        }

        [TestMethod]
        public void TestAddAll()
        {
            acl.AddAll(sl);
            Assert.AreEqual(1, acl[0]);
        }

        [TestMethod]
        public void TestIsEmpty()
        {
            Assert.AreEqual(true, new ACList<int>().IsEmpty());
        }
    }
}
