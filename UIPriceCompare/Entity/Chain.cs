using System.Collections.Generic;
using System.Threading.Tasks;

namespace Entity
{
    public class Chain : IChain
    {
        private readonly Dictionary<string, Task<double>> _itemPrices;
        public readonly string Id;

        public Chain(string id, string name)
        {
            _itemPrices = new Dictionary<string, Task<double>>();
            Id = id;
            Name = name;
            IsWanted = true;
        }

        public string Name { get; private set; }
        public bool IsWanted { get; private set; }

        public void AddItem(string itemName, Task<double> price)
        {
            _itemPrices.Add(itemName, price);
        }

        public double GetItemPrice(string itemName)
        {
            if (!_itemPrices[itemName].IsCompleted)
                _itemPrices[itemName].Wait();

            return _itemPrices[itemName].Result;
        }

        public bool CheckIfThereIsAnItem(string itemName)
        {
            return _itemPrices.ContainsKey(itemName);
        }

        public void ChangeValue()
        {
            IsWanted ^= true;
        }
    }
}