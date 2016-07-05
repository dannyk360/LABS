using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestStrings
{
    [TestClass]
    public class UnitTestProgram
    {
        [TestMethod]
        public void Test_CheckIfStringEmpty_Success()
        {
            Strings.Program str = new Strings.Program();

            Assert.AreEqual(true, str.CheckIfStringEmpty(""));
        }

        [TestMethod]
        public void Test_CheckIfStringNotEmpty_Success()
        {
            Strings.Program str = new Strings.Program();

            Assert.AreEqual(false, str.CheckIfStringEmpty("there is a string"));
        }

        [TestMethod]
        public void Test_ReverseArray_Success()
        {
            Strings.Program st = new Strings.Program();
            
            string str = "am i here",str2 = "here i am";
            string[] strs = str.Split(),strs2 = str2.Split() ;
            strs = st.reverseAndWrite(strs);
            for (int i = 0; i < strs.Length; i++)
                Assert.AreEqual(strs[i],strs2[i]);
        }
        [TestMethod]
        public void Test_SortArray_Success()
        {
            Strings.Program st = new Strings.Program();

            string str = "danny is my name", str2 = "my name is danny";
            string[] strs = str.Split(), strs2 = str2.Split();
            strs2 = st.sortAndWrite(strs2);
            for (int i = 0; i < strs.Length; i++)
                Assert.AreEqual(strs[i], strs2[i]);
        }

    }
}
