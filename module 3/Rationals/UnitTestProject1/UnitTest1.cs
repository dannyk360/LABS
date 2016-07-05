using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class Test_Program
    {
        public delegate void ProcessExceptionDelegate();

        [TestMethod]
        public void Test_Add_Success()
        {
            Rationals.Program r1 = new Rationals.Program(4,2);
            Rationals.Program r2 = new Rationals.Program(8,5);

            r1.r1 = r1.Add(r2.r1);
            Rationals.Program res = new Rationals.Program(18,5);


            Assert.AreEqual(res.ToString(), r1.ToString());

        }

        [TestMethod]
        public void Test_AddToMuch_Failed()
        {
            Rationals.Program r1 = new Rationals.Program(4, 2);
            Rationals.Program r2 = new Rationals.Program(int.MaxValue);
            try
            {
                r1.r1 = r1.Add(r2.r1);
                Assert.Fail();
            }
            catch (StackOverflowException)
            {
                Assert.IsTrue(true);
            }
            


        }

        [TestMethod]
        public void Test_AddNegative_Success()
        {
            Rationals.Program r1 = new Rationals.Program(4, 2);
            Rationals.Program r2 = new Rationals.Program(-3);
            r1.r1 = r1.Add(r2.r1);

            Rationals.Program res = new Rationals.Program(-1);
            Assert.AreEqual(res.ToString(), r1.ToString());

        }

        [TestMethod]
        public void Test_Mul_Success()
        {
            Rationals.Program r1 = new Rationals.Program(4, 2);
            Rationals.Program r2 = new Rationals.Program(3 , 7);
            r1.r1 = r1.Mul(r2.r1);

            Rationals.Program res = new Rationals.Program(6,7);
            Assert.AreEqual(res.ToString(), r1.ToString());

        }

        [TestMethod]
        public void Test_MulNegative_Success()
        {
            Rationals.Program r1 = new Rationals.Program(-4, 2);
            Rationals.Program r2 = new Rationals.Program(3, 7);
            r1.r1 = r1.Mul(r2.r1);

            Rationals.Program res = new Rationals.Program(-6, 7);
            Assert.AreEqual(res.ToString(), r1.ToString());

        }
        [TestMethod]
        public void Test_MulToMuch_Failed()
        {
            Rationals.Program r1 = new Rationals.Program(4, 2);
            Rationals.Program r2 = new Rationals.Program(int.MaxValue);
            try
            {
                r1.r1 = r1.Mul(r2.r1);
                Assert.Fail();
            }
            catch (StackOverflowException)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void Test_ZeroDen_Failed()
        {
            try
            {
                Rationals.Program r1 = new Rationals.Program(-4, 0);
                Assert.Fail();
            }
            catch (DivideByZeroException) { Assert.IsTrue(true); }
        }

        [TestMethod]
        public void Test_negDen_Success()
        {
            Rationals.Program r1 = new Rationals.Program(2, -3);
            Rationals.Program res = new Rationals.Program(-2, 3);

            Assert.AreEqual(res, r1);
            
        }

        [TestMethod]
        public void Test_Equals_Success()
        {
            Rationals.Program r1 = new Rationals.Program(2, -3);
            Rationals.Program r2 = new Rationals.Program(-2, 3);
            Assert.AreEqual(true, r1.Equals(r2));
        }

        [TestMethod]
        public void Test_Equals_Failed()
        {
            Rationals.Program r1 = new Rationals.Program(2, -3);
            Rationals.Program r2 = new Rationals.Program(2, 3);
            Assert.AreEqual(false, r1.Equals(r2));
        }
        public void TestException(Rationals.Program r1,Rationals.Program r2, Exception e1)
        {
            try
            {
                r1.Add(r2.r1);
                Assert.Fail();
            }
            catch (Exception e)
            {
                if (e == e1)
                    throw new Exception("wasAnException");
            }
        }


    }
}
