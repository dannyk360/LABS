using System.Collections.Generic;
using System.Threading.Tasks;

namespace Entity
{
    /**
     You have created a relatively poor domain model.
     It is poor in the sense that it does not fully depict the domain entities, limiting what you can do with your code.
         
     Instead of entities, such as "An item with a price sold at some store"- you have a logical layer which imitates them.
     This limits your software in what it can achieve and in how well it can be tested.

     This may be "good enough" for the excercise (also arguable), but would not be robust and scalable for an actual application.
     I strongly advise you to look into Domain Driven Design (https://en.wikipedia.org/wiki/Domain-driven_design)
     Specifically in the section about Entities.

     */
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