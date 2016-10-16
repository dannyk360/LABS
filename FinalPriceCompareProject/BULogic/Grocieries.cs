using System.Collections.Generic;
using System.Linq;
using DBA;
using Entity;

namespace BULogic
{
    public class Groceries
    {
        private readonly Dictionary<string, IItem> _groceries = new Dictionary<string, IItem>();
        private readonly Dictionary<string, List<string>> _groceriesByCategory = new Dictionary<string, List<string>>();

        public List<string> GetGroceries(string typeName)
        {
            /*
               Consider that call chaining ( passing the result of some call as a parameter to another is not such a good practice
             * If such code throws an exception, you will have a hard time understanding what happened.
             */
            if (!_groceriesByCategory.ContainsKey(typeName))
                _groceriesByCategory.Add(typeName, ReadFromXml.GetGroceriesFromAdb(typeName));
            return _groceriesByCategory[typeName];
        }


        public void AddItem(string itemName, double itemCapacity)
        {
            //How about _grocieries.TryGetValue ? it is more efficient and achieves the same outcome.
            if (_groceries.ContainsKey(itemName))
            {
                _groceries[itemName].ReplaceCapcity(itemCapacity);
                return;
            }
            _groceries.Add(itemName, new Item(itemName, itemCapacity));
        }


        public List<IItem> GetAllItems()
        {
            return _groceries.Values.Where(item => item.GetCapacity() > 0).AsParallel().ToList();
        }

        public void Clear()
        {
            foreach (var item in _groceries.Values)
                item.ReplaceCapcity(0);
        }

        public void ChangeCapcity(string itemName, double capacity)
        {
            //This code can throw an exception
            _groceries[itemName].ReplaceCapcity(capacity);
        }

        public double GetGroceryCapacity(string itemName)
        {
            //This code can throw an exception
            return _groceries[itemName].GetCapacity();
        }

        public string[] GetCategories()
        {
            return ReadFromXml.GetCategories();
        }
    }
}