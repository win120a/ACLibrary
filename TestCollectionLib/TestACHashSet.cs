using ACLibrary.Collection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCollectionLib
{
    [TestClass]
    public class TestACHashSet
    {
        ACHashSet<string> testHashSet;

        public TestACHashSet()
        {
            testHashSet = new ACHashSet<string>();
        }
        

        [TestMethod]
        public void TestAddAll()
        {
            ACList<string> sacl = new ACList<string>();
            sacl.Add("A");
            sacl.Add("B");
            sacl.Add("C");

            testHashSet.AddAll(sacl);

            Assert.AreEqual(3, testHashSet.Count);
        }

        [TestMethod]
        public void TestIsEmpty()
        {
            testHashSet.Clear();
            Assert.IsTrue(testHashSet.IsEmpty());
        }
    }
}
