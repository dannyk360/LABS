using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersApp
{
    class Program
    {

        public static bool AToKFilter(Customer customer)
        {
            //What is this? I can't understand.
            if (string.Compare(customer.Name, "l") == -1)
                return true;
            return false;
        }

        //didn't use yield or IEnumerable
        public static Collection<Customer> GetCustomers(Collection<Customer> customers, Predicate<Customer> CustomerFilter)
        {
            Collection<Customer> newCustomers = new Collection<Customer>();
            foreach (var customer in customers)
            {
                if(CustomerFilter(customer))
                    newCustomers.Add(customer);
            }
            return newCustomers;
        }

        static void Main(string[] args)
        {
            Customer[] customerArr = new Customer[10];
            Predicate<Customer> CustomerFilter = AToKFilter;

            //Consider extracting this logic to a different method
            for (int i = 0; i < 5; i++)
            {
                customerArr[i] = new Customer();

                //ToString() here is redundant.
                customerArr[i].Name = "danny" + ((2*i)%5).ToString();
                customerArr[i].ID = (80 * i) % 200;
            }
            for (int i = 5; i < 9; i++)
            {
                customerArr[i] = new Customer();
                customerArr[i].Name = "lanny" + ((2 * i) % 5).ToString();
                customerArr[i].ID = (80 * i) % 200;
            }

            customerArr[9] = new Customer();
            customerArr[9].Name = "vanny" + ((2 * 9) % 5).ToString();
            customerArr[9].ID = 9 % 200;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Name:" + customerArr[i].Name + " ID:" + customerArr[i].ID);
            }
            Console.WriteLine();
            var customerArr2 = GetCustomers(new Collection<Customer>(customerArr), CustomerFilter);
            foreach (Customer i in customerArr2)
            {
                Console.WriteLine("Name:" + i.Name + " ID:" + i.ID);
            }
            Console.WriteLine();
            customerArr2 = GetCustomers(new Collection<Customer>(customerArr), delegate (Customer customer){
                //What about capital letters?
                if (string.Compare(customer.Name, "k") == 1 && string.Compare(customer.Name, "z") != 1)
                    return true;
                return false;
            });
            foreach (Customer i in customerArr2)
            {
                //Why didn't you implement ToString.
                Console.WriteLine("Name:" + i.Name + " ID:" + i.ID);
            }
            Console.WriteLine();
            Predicate<Customer> myFunc = x => x.ID < 100;
            customerArr2 = GetCustomers(new Collection<Customer>(customerArr), myFunc);

            //Extract this to another method
            foreach (Customer i in customerArr2)
            {
                Console.WriteLine("Name:" + i.Name + " ID:" + i.ID);
            }
        }
    }
}
