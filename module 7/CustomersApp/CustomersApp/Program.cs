using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer[] customerArr = new Customer[10];

            for (int i = 0; i < 5; i++)
            {
                customerArr[i] = new Customer();
                customerArr[i].Name = "danny" + ((2*i)%5).ToString();
                customerArr[i].ID = i % 5;
            }
            for (int i = 5; i < 9; i++)
            {
                customerArr[i] = new Customer();
                customerArr[i].Name = "Danny" + ((2 * i) % 5).ToString();
                customerArr[i].ID = i % 5;
            }

            customerArr[9] = new Customer();
            customerArr[9].Name = "danny" + ((2 * 9) % 5).ToString();
            customerArr[9].ID = 9 % 5;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Name:" + customerArr[i].Name + " ID:" + customerArr[i].ID);
            }
            Console.WriteLine();
            Array.Sort(customerArr);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Name:" + customerArr[i].Name + " ID:" + customerArr[i].ID);
            }

            Console.WriteLine("\nsecond compare:");
            AnotherCustomerComparer otherComp = new AnotherCustomerComparer();
            Array.Sort(customerArr, otherComp);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Name:" + customerArr[i].Name + " ID:" + customerArr[i].ID);
            }
        }
    }
}
