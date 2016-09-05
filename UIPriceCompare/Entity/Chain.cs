using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Chain : IChain
    {
        public readonly string id;
        public string name { get; private set; }
        private Dictionary<string,Task<double>> itemPrices;
        public bool isWanted { get; private set ;}

        public Chain(string _id, string _name )
        {
            itemPrices = new Dictionary<string, Task<double>>();
            id = _id;
            name = _name;
            isWanted = true;
        }

        public void AddItem(string itemName, Task<double> price)
        {
            itemPrices.Add(itemName, price);
        }

        public double getItemPrice(string itemName)
        {
            if (!itemPrices[itemName].IsCompleted)
            {
                itemPrices[itemName].Wait();
            }

            return itemPrices[itemName].Result;

        }
        public bool checkIfThereIsAnItem(string itemName)
        {
            return itemPrices.ContainsKey(itemName);
        }

        public void changeValue()
        {
            isWanted ^= true;
        }
    }
}
