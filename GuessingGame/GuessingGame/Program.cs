using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    class Program
    {
        public static int parseNumber(string str)
        {
            int i;
            if(int.TryParse(str,out i) == false)
                throw new ArgumentException("not an int");
            return i;
        }

        static void Main(string[] args)
        {
            string str;
            int secret = new Random().Next(1, 101),i,j = 0;
            while (j++ < 7)
            {
                str = Console.ReadLine();
                i = parseNumber(str);
                if (i < secret)
                    Console.WriteLine("too small");
                else if (i > secret)
                    Console.WriteLine("too big");
                else {
                    Console.WriteLine("you right");
                    break;
                   }
            }
            if (j == 8)
                Console.WriteLine("you have failed");
            Console.ReadLine();
        }
    }
}
