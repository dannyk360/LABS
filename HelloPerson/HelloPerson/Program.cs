using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloPerson
{
    class Program
    {
        public static void PrintN(int k)
        {
            for(int i = 0;i < k;i++)
                Console.Write(" ");
        }
        static void Main(string[] args)
        {
            int i;
            string str;
            Console.WriteLine("Whats your name");
            str = Console.ReadLine();
            Console.WriteLine("Hello "+ str);
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
