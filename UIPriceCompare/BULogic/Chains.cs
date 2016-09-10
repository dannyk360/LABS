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
            if (!_chains[0].CheckIfThereIsAnItem(itemName))
                _chains.ForEach(
                    chain =>
                        chain.AddItem(itemName,
                            ReadFromXml.GetPrice(chain.Name, ReadFromXml.GetItemId(itemName, chain.Name))));
        }

        public string[] GetChainsName()
        {
            return _chains.Where(chain => chain.IsWanted).Select(chain => chain.Name).ToArray();
        }

        public List<string> GetChainInfo(string chainName, List<IItem> items)
        {
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
            _chains.ForEach(chain =>
            {
                if (chain.IsWanted != chainsDictonary[chain.Name])
                    chain.ChangeValue();
            });
        }
    }
}