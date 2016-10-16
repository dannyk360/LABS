using System.Collections.Generic;
using System.Linq;
using DBA;
using Entity;

namespace BULogic
{
    public class Chains
    {
        private readonly List<IChain> _chains;

        public Chains()
        {
            var chainsData = ReadFromXml.GetChains();
            _chains = new List<IChain>();
            _chains = chainsData.Select(chain => new Chain(chain.Id, chain.Name) as IChain).ToList();
        }

        public void AddItem(string itemName)
        {
            /*It is unclear why you're so certain that the first index will hold a value
             * Why you're sure that value will not be null
             * And why you only do this for the first index's value.
             * 
             * Also, consider that call chaining ( passing the result of some call as a parameter to another is not such a good practice
             * If such code throws an exception, you will have a hard time understanding what happened.
             */
            if (!_chains[0].CheckIfThereIsAnItem(itemName))
                _chains.ForEach(
                    chain =>
                        chain.AddItem(itemName,
                            ReadFromXml.GetPrice(chain.Name, ReadFromXml.GetItemId(itemName, chain.Name))));
        }

        //Prefer IEnumerable<T> over arrays
        public string[] GetChainsName()
        {
            return _chains.Where(chain => chain.IsWanted).Select(chain => chain.Name).ToArray();
        }

        /*It is unclear what is the info which you attempt to obtain - the name is vague and the type returned is a list of strings
         * Consider giving more precise names to methods or returning some kind of data type which helps readers understand your code.
         */
        public List<string> GetChainInfo(string chainName, List<IItem> items)
        {
            //Try and avoid magic numbers, they make your code harder to understand and mantain
            var result = new List<string>();
            var relleventChain = _chains.Where(chain => chain.Name == chainName).ElementAt(0);
            var itemPrices = items.Select(item => relleventChain.GetItemPrice(item.Name)).ToList();
            for (var i = 0; (i < 3) && (0 < itemPrices.Count); i++)
                result.Add(lineToShow(itemPrices, items));

            
            while (3 < itemPrices.Count)
                lineToShow(itemPrices, items);

            while (0 < itemPrices.Count)
                result.Add(lineToShow(itemPrices, items));
            return result;
        }

        private string lineToShow(List<double> itemPrices, List<IItem> items)
        {
            //What does this even do?
            var index = itemPrices.IndexOf(itemPrices.Min());
            var result = items[index].Name + "=" + itemPrices[index];
            itemPrices.RemoveAt(index);
            items.RemoveAt(index);
            return result;
        }

        public List<double> GetSum(List<IItem> items)
        {
            var chainPrices =
                _chains.Where(chain => chain.IsWanted)
                    .Select(chain => items.Select(item => chain.GetItemPrice(item.Name)*item.GetCapacity()).ToList())
                    .ToList();
            return chainPrices.Select(chainPrice => chainPrice.Sum()).ToList();
        }

        public Dictionary<string, bool> GetChainNamesAndAvailability()
        {
            var chainsDictionary = new Dictionary<string, bool>();
            _chains.ForEach(chain => { chainsDictionary.Add(chain.Name, chain.IsWanted); });
            return chainsDictionary;
        }

        public void SetChains(Dictionary<string, bool> chainsDictonary)
        {
            /* What you did here is mix the model and business logic
             * The "Wanted" property does not belong in the model.
             * This is because it does not describe the properties of a domain object (i.e. the chain)
             * It describes a business concern - whether or not it was selected for price comparison.
             * It would therefore be the business layer's responsibility to maintain a collection of wanted items
             * It is not the model's role to know about business constraints.
             */
            _chains.ForEach(chain =>
            {
                if (chain.IsWanted != chainsDictonary[chain.Name])
                    chain.ChangeValue();
            });
        }
    }
}