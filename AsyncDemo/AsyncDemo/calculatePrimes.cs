using AsyncDemo.newExtentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDemo
{
    public class calculatePrimes
    {
        // Very good
        public IEnumerable<int> CalcPrimes(int firstNumber, int secondNumber)
        {
            List<int> collection = new List<int>();
            for (int i = firstNumber+1; i < secondNumber; i++)
            {
                collection.Add(i);
            }

            return from number in collection
                   where number.isPrime() == true 
                   select number; 
            
        }

    }
}
