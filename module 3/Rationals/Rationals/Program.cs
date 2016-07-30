using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rationals
{
    public class Program
    {
        //Consider extracting this to a seperate file and outside of ther type

         //Why does the implementation of the Rational type is not in the Rational type?
        public struct Rational
        {
            public int numerator ;
            public int denominator;
        }

        //Consider a better name
        public Rational r1;

        public Program(int num,int den)
        {
            if (den == 0)
                throw new DivideByZeroException();
            if (den < 0)
            {
                num *= -1;
                den *= -1;
            }
            r1.numerator = num;
            r1.denominator = den;
            Reduce();
        }

        public Program(int num)
        {
            r1.numerator = num;
            r1.denominator = 1;
            Reduce();
        }

        public int Numerator
        {
            get { return r1.numerator; }
        }
        public int denominator
        {
            get { return r1.denominator; }
        }

        public double value { get { return r1.numerator / r1.denominator; } }

        public Rational Add(Rational r2)
        {
            Rational res;
            if(r1.numerator >= 0 && r1.denominator >= 0 && r2.denominator >= 0 && r2.numerator >= 0)
                if ((r1.numerator > (int.MaxValue - r2.numerator) / r2.denominator) || (r2.numerator > (int.MaxValue - r1.numerator) / r1.denominator))
                    throw new StackOverflowException();
            r1.numerator *= r2.denominator;
            r2.numerator *= r1.denominator;
            res.numerator = r1.numerator + r2.numerator;
            res.denominator = r1.denominator * r2.denominator;
            Reduce();
            return res;
        }

        private void Reduce()
        {
            int max = 1;
            dynamic res = r1;
            for (int i = 2; i <= res.denominator; i++)
            {
                if (res.denominator % i == 0 && res.numerator % i == 0)
                    max = i;
            }
            res.numerator /= max;
            res.denominator /= max;
            r1 = res;
        }

        public Rational Mul( Rational r2)
        {
            Rational res;
            if (r1.numerator > int.MaxValue / r2.numerator || r1.denominator > int.MaxValue / r2.denominator)
                throw new StackOverflowException();
            res.numerator = r1.numerator * r2.numerator;
            res.denominator = r1.denominator * r2.denominator;

            Reduce();
            return res;
        }

        public override String ToString()
        {
            if (r1.denominator == 0)
                return ("cannot be solved");
            return r1.numerator + "/" + r1.denominator + "=" + value;
        }

        //No checking wither ob is of type Rational
        public override bool Equals(Object ob)
        {
            var r2 = (Program)ob;
            return (r1.numerator == r2.r1.numerator) && (r1.denominator == r2.r1.denominator);
        }

        static void Main(string[] args)
        {
            var num1 = new Program(1, 2);
            var num2 = new Program(1, 2);

            var num3 = num1.Add(num2.r1);

            var num4 = num2.Mul(num2.r1);

            var num6 = new Program(2, 4);
            var num7 = new Program(2, 4);
            num7.Reduce();


            Console.WriteLine($"{num1} + {num2} = {num3}");
            Console.WriteLine($"{num2} * {num2} = {num4}");
            Console.WriteLine($"{num6} reduced {num7}");

        }
    }
}
