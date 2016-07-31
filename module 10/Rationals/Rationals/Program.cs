using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rationals
{
    /**
     Eyal:
      
     1) You were asked to override the operators for the Rational class, not for the Program class
     2) Were you hesitant, at least, to put your name on code which looks like this when reaching module 10?
     I understand that you started this class in module 3, and back then you did not know better
     But a lot more is expected from you in this point of the course.
     Consider revising your solution, and seriously, you should take your assignments more seriously.
     This does not fulfill the requirements of the assignment.
   */

    public class Program
    {
        public struct Rational
        {
            public int numerator ;
            public int denominator;
            public static implicit operator double(Rational r1)
            {
                return (double)r1.numerator / r1.denominator;//Bug: DivideByZeroException
            }

            public static explicit operator Rational(int num)
            {
                return (new Program(num).r1);
            }
        }
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

        public double value { get { return (double)r1; } }

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
            r1 = res;
            Reduce();
            return r1;
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
            r1 = res;
            Reduce();
            return r1;
        }

        public override String ToString()
        {
            if (r1.denominator == 0)
                return ("cannot be solved");
            return r1.numerator + "/" + r1.denominator + "=" + value;
        }

        public override bool Equals(Object ob)
        {
            var r2 = (Program)ob;
            return (r1.numerator == r2.r1.numerator) && (r1.denominator == r2.r1.denominator);
        }

     
        public static Rational operator +(Program r1,Program r2)
        {
            return r1.Add(r2.r1);
        }

     
        public static Rational operator -(Program r1, Rational r2)
        {
            return r1.Add(new Program((-1)*r2.numerator,r2.denominator).r1);
        }

       
        public static Rational operator *(Program r1, Rational r2)
        {
            return r1.Mul(r2);
        }

    
        public static Rational operator /(Program r1, Rational r2)
        {
            return r1.Mul(new Program(r2.denominator, r2.numerator).r1);
        }

        static void Main(string[] args)
        {
            Program R1 = new Program(4,2);
            Program R2 = new Program(3) ;
            Rational r3 = (Rational)5;
            if(r3.numerator == 5 && r3.denominator == 1)
                Console.WriteLine("succsses with casting from int");
            Console.WriteLine(R1 + " and " + R2);
            
            R1.r1 = R1 + R2 ;
            Console.WriteLine("after + " + R1);
            R1.r1 = R1 - R2.r1;
            Console.WriteLine("after - " + R1);
            R1.r1 = R1 * R2.r1;
            Console.WriteLine("after * " + R1);
            R1.r1 = R1 / R2.r1;
            Console.WriteLine("after / " + R1);
            R1.r1 = R1.Mul(R2.r1);

            Console.Write(R1 + " and " + R2 + " is " );
            if (!R1.Equals(R2))
                Console.Write("Not ");
            Console.WriteLine("Equal");
            Console.ReadLine();

        }
    }
}
