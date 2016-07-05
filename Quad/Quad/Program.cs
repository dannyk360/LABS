using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quad
{
    public class Program
    {
        public bool checkArguments(string[] args1)
        {
            if (args1.Length < 3)
            {
         
                Console.WriteLine("there aren't 3 arguments");
                return false;
            }
            return true;
        }

        public bool checkParse(string[] args1,out double  a,out double  b,out double  c)
        {
            if (!double.TryParse(args1[0], out a) || !double.TryParse(args1[1], out b) || !double.TryParse(args1[2], out c))
            {
                Console.WriteLine("parsing didn't succseed");
                a = 0;
                b = 0;
                c = 0;
                return false;
            }
            return true;

        }
        public double OneSolutionA(double a, double b, double c)
        {
            return (-1) * c / b;
 
        }
        public double OneSolutionB(double a, double b, double c)
        {
            return - Math.Sqrt(c) / Math.Sqrt(a);
        }
        public bool noSolution(out double toSqrt,double a,double b , double c)
        {
            toSqrt = Math.Pow(b, 2) - 4 * a * c;
            if (toSqrt < 0)
            {
                Console.WriteLine("no solution");
                return false;
            }

            return true;
        }
        public string stringequation(double toSqrt, double a, double b, double c)
        {
            return ("X1 = " + ((toSqrt - b) / (2 * a)).ToString() + ",X2 = " + ((-1) * (toSqrt + b) / (2 * a))).ToString();
        }
        static void Main(string[] args)
        {
            double a, b, c,toSqrt;
            Program q = new Program() ;
            if (!q.checkArguments(args))
            {
                Console.ReadLine();
                return;
            }

            if (!q.checkParse(args,out a,out b,out c))
            {
                Console.ReadLine();
                return;
            }
            
            if (a == 0)
            {
                Console.WriteLine("x = {0}", q.OneSolutionA(a, b, c));
                Console.ReadLine();
                return;
            }
            if (b == 2*a*c)
            {
                Console.WriteLine("x = {0}", q.OneSolutionB(a, b, c));
                Console.ReadLine();
                return;
            }

            if (q.noSolution(out toSqrt,a,b,c) == false )
            {
                Console.ReadLine();
                return;
            }

            toSqrt = Math.Sqrt(toSqrt);
            Console.WriteLine(q.stringequation(toSqrt,a,b,c));
            Console.ReadLine();
        }
    }
}
