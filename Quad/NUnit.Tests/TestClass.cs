using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//nice
namespace NUnit.Tests
{
    [TestFixture]
    public class QuadTestClass
    {
        [Test]
        public void QuadNumberArgumentsTestMethodSuccess()
        {
            Quad.Program q = new Quad.Program();
            string[] stringArr = { "2" , "3", "2" };
            Assert.AreEqual(true, q.checkArguments(stringArr));

        }

        [Test]
        public void QuadNumberArgumentsTestMethodFailed()
        {
            Quad.Program q = new Quad.Program();
            string[] stringArr = { "2", "3" };
            Assert.AreEqual(false, q.checkArguments(stringArr));

        }

        [Test]
        public void QuadParseArgumentsTestMethodSuccess()
        {
            double a, b, c;
            Quad.Program q = new Quad.Program();
            string[] stringArr = { "2", "3", "2" };
            Assert.AreEqual(true, q.checkParse(stringArr,out a,out b,out c));

        }

        [Test]
        public void QuadParseArgumentsTestMethodFailed()
        {
            Quad.Program q = new Quad.Program();
            double a, b, c;
            string[] stringArr = { "2", "3", "a" };
            Assert.AreEqual(false, q.checkParse(stringArr, out a, out b, out c));

        }

        [Test]
        public void Test_OneSolutionA_IsTrue()
        {
            Quad.Program q = new Quad.Program();
            double a = 0, b = 4, c= 2;

            Assert.AreEqual(-0.5, q.OneSolutionA(a,b,c));

        }
        [Test]
        public void Test_OneSolutionB_IsTrue()
        {
            Quad.Program q = new Quad.Program();
            double a = 4, b = 8, c = 4;

            Assert.AreEqual(-1, q.OneSolutionB(a, b, c));

        }

        [Test]
        public void Test_noSolution_IsFalse()
        {
            double sqrt;
            Quad.Program q = new Quad.Program();
            double a = 4, b = 0, c = 4;

            Assert.AreEqual(false, q.noSolution(out sqrt,a, b, c));

        }

        [Test]
        public void Test_noSolution_IsTrue()
        {
            double sqrt;
            double a = 4, b = 10, c = 4;
            Quad.Program q = new Quad.Program();
            Assert.AreEqual(true, q.noSolution(out sqrt, a, b, c));

        }

        [Test]
        public void Test_SqrtCheck_Is4()
        {
            double sqrt;
            Quad.Program q = new Quad.Program();
            double a = 4, b = 2, c = 0;
            q.noSolution(out sqrt, a, b, c);
            Assert.AreEqual(4, sqrt);

        }

    }
}
