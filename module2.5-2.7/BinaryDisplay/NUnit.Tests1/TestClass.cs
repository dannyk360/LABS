using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests1
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void Test_zeroCount_success()
        {
            int num = 0;
            BinaryDisplay.Program c = new BinaryDisplay.Program();
            Assert.AreEqual(0, c.CalcRec(num));
        }
        [Test]
        public void Test_maxValue_success()
        {
            int num = int.MaxValue;
            BinaryDisplay.Program c = new BinaryDisplay.Program();
            Assert.AreEqual(31, c.CalcRec(num));
        }
        [Test]
        public void Test_minValue_success()
        {
            BinaryDisplay.Program c = new BinaryDisplay.Program();
            int num = int.MinValue;
            Assert.AreEqual(1, c.CalcRec(num));
        }
        [Test]
        public void Test_Regular_success()
        {
            int num = 31;
            BinaryDisplay.Program c = new BinaryDisplay.Program();
            Assert.AreEqual(5, c.CalcRec(num));
        }
    }
}
