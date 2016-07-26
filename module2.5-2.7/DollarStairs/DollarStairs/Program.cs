using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DollarStairs
{
    //Doesn't handle invalid input
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()),i,j;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < i; j++)
                    Console.Write("$");
                Console.WriteLine("$");
            }
            Console.ReadLine();
        }
    }
}
