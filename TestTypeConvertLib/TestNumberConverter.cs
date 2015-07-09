using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ACLibrary.TypeConvert;
using System.Collections.Generic;

namespace TestTypeConvertLib
{
    [TestClass]
    public class TestNumberConverter
    {
        [TestMethod]
        public void TestIC2SC() // Int collection to string.
        {
            List<int> il = new List<int>();
            il.Add(120);
            il.Add(240);
            il.Add(180);

            List<string> sl = NumberConverter.IntCollectionToStringList(il);

            Assert.AreEqual("120", sl[0]);
        }

        [TestMethod]
        public void TestLC2SC() // Long collection to string.
        {
            List<long> ll = new List<long>();
            ll.Add(12021121200012L);
            ll.Add(12312121121200012L);
            ll.Add(1231342422121120012L);

            List<string> sl = NumberConverter.LongCollectionToStringList(ll);

            Assert.AreEqual("12021121200012", sl[0]);
        }

        [TestMethod]
        public void TestI2S() // Int to string.
        {
            Assert.AreEqual("120", NumberConverter.Int2String(120));
        }

        [TestMethod]
        public void TestL2S() // Long to string.
        {
            Assert.AreEqual("12021121200012", NumberConverter.Long2String(12021121200012L));
        }
    }
}
