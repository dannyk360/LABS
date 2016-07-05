using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersApp
{
    class AnotherCustomerComparer : IComparer<Customer>
    {
        public int Compare(Customer x, Customer y)
        {
            if (x.ID > y.ID)
                return 1;
            if (x.ID == y.ID)
                return 0;
            return -1;
        }
    }
}
