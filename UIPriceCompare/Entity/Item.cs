using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Item : IItem
    {
        public string name { get; private set; }
        private int capacity { get; set; }
        
        public Item(string _name,int _capacity)
        {
            name = _name;
            capacity = _capacity;
        }

        public int ReplaceCapcity(int subcapacity)
        {
            if (capacity < subcapacity)
                return -1;
            capacity -= subcapacity;
            return capacity;
        }

        public int GetCapacity()
        {
            return capacity;
            
        }

        public int AddCapcity(int addCapacity)
        {
            capacity += addCapacity;
            return capacity;
        }
    }
}
