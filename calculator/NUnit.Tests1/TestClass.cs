using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NUnit.Tests1
{
    [TestFixture]
    public class CalcTestClass
    {

        [Test]
        public void divByZeroTestMethod()
        {
            double number = 8;
            Calculator.Program p = new Calculator.Program();
            double number2 = 0;
            try
            {
                p.div(number, number2);
                Assert.Fail();
            }
            catch (DivideByZeroException) { Assert.Pass("Your first passing test"); }
        }

        [Test]
        public void divTestMethod()
        {
            Calculator.Program p = new Calculator.Program();
            double number = 8;
            double number2 = 4;
            Assert.AreEqual(2, p.div(number, number2));
        }
        [Test]
        public void divNegativeTestMethod()
        {
            Calculator.Program p = new Calculator.Program();
            double number = -8;
            double number2 = 4;
            Assert.AreEqual(-2, p.div(number, number2));
        }

        [Test]
        public void mulTestMethod()
        {
            Calculator.Program p = new Calculator.Program();
            double number = 8;
            double number2 = 4;
            Assert.AreEqual(32, p.mul(number, number2));
        }
        [Test]
        public void mulNegativeTestMethod()
        {
            double number = -8;
            double number2 = 4;
            Calculator.Program p = new Calculator.Program();
            Assert.AreEqual(-32, p.mul(number, number2));
        }
        [Test]
        public void addTestMethod()
        {
            Calculator.Program p = new Calculator.Program();
            double number = 8;
            double number2 = 4;
            Assert.AreEqual(12, p.add(number, number2));
        }
        [Test]
        public void addMaxValueTestMethod()
        {
            double number = double.MaxValue - 2;
            double number2 = 4;
            Calculator.Program p = new Calculator.Program();
            try
            {
                p.add(number, number2);
                Assert.Fail();
            }
            catch (OverflowException)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void addNegativeTestMethod()
        {
            double number =  -2;
            double number2 = -4;
            Calculator.Program p = new Calculator.Program();
            Assert.AreEqual(-6,p.add(number, number2));
        }

        [Test]
        public void subTestMethod()
        {
            double number = 8;
            double number2 = 4;
            Calculator.Program p = new Calculator.Program();
            Assert.AreEqual(4, p.sub(number, number2));
        }

        [Test]
        public void subNegativeTestMethod()
        {
            double number = -2;
            double number2 = -4;
            Calculator.Program p = new Calculator.Program();
            Assert.AreEqual(2, p.sub(number, number2));
        }
    }


}
