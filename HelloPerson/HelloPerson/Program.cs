using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloPerson
{
    //Doesn't handle invalid input.

    class Program
    {
        public static void PrintN(int k)
        {
            //the convention in C# is to always use "{ }" bracets in body of expressions, even for one liners.
            for (int i = 0; i < k; i++)
            {
                Console.Write(" ");
            }
        }
        static void Main(string[] args)
        {
            //Unlike in C, in C# you don't have to declare variables at the begining. You can declare them wheneven you want.
            int i;
            string str;

            Console.WriteLine("Whats your name");
            str = Console.ReadLine();

            //It is better to use string formatting instead of concatenations in such a way.
            //You can use string.Format, string interpolation (the '$' sign in c# 6) or even the Console.WriteLine overload that accepts formats
            //Console.WirteLine("Hello", str);
            Console.WriteLine("Hello " + str);
            i = int.Parse(Console.ReadLine());
            for (int j = 0; j < i; j++)
            {
                PrintN(j);
                Console.WriteLine(str);
            }
            Console.ReadLine();
        }
    }
}
