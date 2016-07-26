using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    //Doesn't handle invalid input
    //Crashes on division by zero.
    //calculator doesn't work. doesn't print correct results.
    public class Program
    {
        public  double add(double i,double j)
        {
            if (j > double.MaxValue - i )
                throw new OverflowException();

            //should been i + j;
            return i += j;
        }
        public  double sub(double i, double j)
        {
            if (i < double.MinValue + j)
                throw new OverflowException();

            // should been i - j
            return i -= j;
        }
        public  double mul(double i, double j)
        {
            //should been i * j
            return i *= j;
        }
        public  double div(double i, double j) 
        {
            if (j == 0)
                throw new DivideByZeroException();

            //should been i / j.
            return i /= j;
        }

        //Doesn't return's a value. 'i' is not a pointer (ref or out argument), so 'i' is not updated.
        public  void switchFunc(char ch,double i,double j)
        {
            switch (ch)
            {
                case '+':
                    i = add(i, j);
                    break;
                case '-':
                    i = sub(i, j);
                    break;
                case '*':
                    i = mul(i, j);
                    break;
                case '/':
                    i = div(i, j);
                    break;
            }
        }
        static void Main(string[] args)
        {
            //You don't have to declare variables at the begining of the scope.
            bool flag = false;
            double i, j;
            Program p = new Program();
            char ch;

            Console.WriteLine("input two numbers and an operator");
            i = double.Parse(Console.ReadLine());
            j = double.Parse(Console.ReadLine());
            ch = char.Parse(Console.ReadLine());
            p.switchFunc(ch, i, j);

            //i doesn't have the calculation result.

            //This is always true. flag is not changed anywhere.
            if (flag == false)
                Console.WriteLine("{0}", i);
            else
                Console.WriteLine("not true");
            Console.ReadLine();
        }
    }
}
