using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Primes
{
    class Program
    {

        public static int[] CalcPrimes(int x, int y)
        {
            ArrayList primeArr = new ArrayList();
            bool isPrime;
            for (int i = x; i < y; i++)
            {
                isPrime = true;
                if (i%2 == 0 && i != 2)
                    isPrime = false;
                for (int j = 3; j <= i/2 && isPrime == true; j += 2)
                {
                    if (i%j == 0)
                        isPrime = false;
                }
                if(isPrime == true)
                    primeArr.Add(i);
            }
            int[] returnArr = new int[primeArr.Count];
            primeArr.CopyTo(returnArr);
            return returnArr;
        }
        static void Main(string[] args)
        {
            int[] arr = CalcPrimes(0, 100);
            for(int i = 0;i<arr.Length;i++)
                Console.WriteLine(arr[i]);
        }
    }
}
