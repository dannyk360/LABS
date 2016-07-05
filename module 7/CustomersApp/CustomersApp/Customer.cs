using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersApp
{
    public class Customer : IComparable<Customer> , IEquatable<Customer>
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public string Address { get; set; }

        public int CompareTo(Customer other)
        {
            return string.CompareOrdinal(Name.ToLower(), other.Name.ToLower());
        }

        public bool Equals(Customer other)
        {
            if (Name.Equals(other.Name) && ID == other.ID)
                return true;
            return false;
        }
    }
}
