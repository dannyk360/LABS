using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimesCalculator
{
    static class intExtentions
    {
        public static bool isPrime(this int number)
        {
            if (number % 2 == 0)
                return false;
            for (int i = 3; i <= number / 2; i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
    }
}
