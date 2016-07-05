using System;
using GenericApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Add_TwoSameKeys_Success()
        {
            var multiDictionary = new MultiDictionary<int, string>
            {
                {1, "one"},
                {1, "ich"},
            };

            Assert.AreEqual(2,multiDictionary.Count);

        }

        [TestMethod]
        public void Add_TwoSameValues_Success()
        {
            var multiDictionary = new MultiDictionary<int, string>
            {
                {2, "ich"},
                {1, "ich"},
            };

            Assert.AreEqual(2, multiDictionary.Count);

        }

        [TestMethod]
        public void Remove_Key_Success()
        {
            var multiDictionary = new MultiDictionary<int, string>
            {
                {1, "one"},
                {1, "ich"},
            };

            multiDictionary.Remove(1);
            Assert.AreEqual(0, multiDictionary.Count);

        }
        [TestMethod]
        public void Remove_KeyValue_Success()
        {
            var multiDictionary = new MultiDictionary<int, string>
            {
                {1, "one"},
                {1, "ich"},
            };

            multiDictionary.Remove(1,"one");
            Assert.AreEqual(1, multiDictionary.Count);

        }

        [TestMethod]
        public void Clear_Dictonary_Success()
        {
            var multiDictionary = new MultiDictionary<int, string>
            {
                {1, "one"},
                {1, "ich"},
            };

            multiDictionary.Clear();
            Assert.AreEqual(0, multiDictionary.Count);

        }

        [TestMethod]
        public void ContainsKey_True_Success()
        {
            var multiDictionary = new MultiDictionary<int, string>
            {
                {1, "one"},
                {1, "ich"},
            };

            Assert.AreEqual(true, multiDictionary.ContainsKey(1));

        }
        [TestMethod]
        public void ContainsKey_False_Success()
        {
            var multiDictionary = new MultiDictionary<int, string>
            {
                {1, "one"},
                {1, "ich"},
            };

            Assert.AreEqual(false, multiDictionary.ContainsKey(2));

        }


    }
    
}
