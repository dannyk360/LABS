using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    //The convention for method in C# is to start with a capital letter
    public class Program
    {
        public bool CheckIfStringEmpty(string str)
        {
            //Nice.
            return string.IsNullOrEmpty(str);
        }

        public string[] reverseAndWrite(string[] str)
        {
            Array.Reverse(str);
            for (int i = 0; i < str.Length; i++)
            {
                //Console.Write("{0} ", str[i]);
                Console.Write(str[i] + " ");
            }
            return str;
        }

        public string[] sortAndWrite(string[] str)
        {
            Array.Sort(str);
            for (int i = 0; i < str.Length; i++)
            {
                //Console.Write($"{str[i]} ");
                Console.Write(str[i] + " ");
            }
            return str;
        }
        static void Main(string[] args)
        {
            string str;
            Program p = new Program();
            do
            {
                str = Console.ReadLine();
                if (p.CheckIfStringEmpty(str))
                    Environment.Exit(1);
                string[] strs;
                strs = str.Split(null);
                Console.WriteLine(strs.Length);
                p.reverseAndWrite(strs);
                Console.WriteLine();
                p.sortAndWrite(strs);
                Console.WriteLine();
            } while (true);
        }
    }
}
