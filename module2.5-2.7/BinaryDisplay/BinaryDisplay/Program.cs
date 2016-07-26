using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryDisplay
{
    //Input is not validated.
    //Doesn't print correct result for negative values.
    public class Program
    {
        //Nice recursion
        public  int CalcRec(int i)
        {
            if (i == 0)
                return 0;
            if (i == -1)
            {
                return 1;
            } 
            int j = CalcRec(i >> 1);
            j += i & 1;
            Console.Write("{0}", (i % 2));
            return j;
        }
        static void Main(string[] args)
        {
            int i;
            Program c = new Program();
            i = int.Parse(Console.ReadLine());
            Console.WriteLine("\n{0}",c.CalcRec(i));
            Console.ReadLine();
        }
    }
}
