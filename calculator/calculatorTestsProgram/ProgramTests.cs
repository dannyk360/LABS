using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.TestsProgram
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void addMaximum()
        {
            double i = Calculator.Program.add(double.MaxValue, 1);
            Assert.AreEqual(i, 0);
        }

        [TestMethod()]
        public void subTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void mulTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void divTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void switchFuncTest()
        {
            Assert.Fail();
        }
    }
}