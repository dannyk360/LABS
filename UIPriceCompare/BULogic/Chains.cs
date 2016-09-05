using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace BULogic
{

    public class Chains
    {
        
        private static List<IChain> chains;
        
        public Chains()
        {
            var chainsData = DBAccess.readFromXml.getChains();
            chains = new List<IChain>();
            chains = chainsData.Select((chain) => new Chain(chain.id, chain.name) as IChain).ToList();

        }

        public static void AddItem(string itemName)
        {
            if(!chains[0].checkIfThereIsAnItem(itemName))
                chains.ForEach( (chain) => chain.AddItem(itemName, DBAccess.readFromXml.getPrice(chain.name,DBAccess.readFromXml.getItemId(itemName, chain.name))));
        }

        public static string[] getChainsName()
        {
            return chains.Where((chain) => chain.isWanted == true).Select((chain) => chain.name).ToArray();
        }

        public static List<string> getChainInfo(string chainName,List<IItem> items)
        {
            List<string> result = new List<string>();
            var relleventChain = chains.Where((chain) => (chain.name == chainName)).ElementAt(0);
            var itemPrices = items.Select((item) => relleventChain.getItemPrice(item.name)).ToList();
            for (int i = 0; i < 3 && 0 < itemPrices.Count; i++)
            {
                result.Add(lineToShow(itemPrices, items));
            }

            while (3 < itemPrices.Count)
            {
                lineToShow(itemPrices, items);
            }

            while (0 < itemPrices.Count)
            {
                result.Add(lineToShow(itemPrices,items));
            }
            return result;


        }

        private static string lineToShow(List<double> itemPrices,List<IItem> items)
        {
            int index = itemPrices.IndexOf(itemPrices.Min());
            string result = items[index].name + "=" + itemPrices[index];
            itemPrices.RemoveAt(index);
            items.RemoveAt(index);
            return result;
        }

        public static double getSum(string chainName, List<IItem> items)
        {
            List<string> result = new List<string>();
            var relleventChain = chains.Where((chain) => (chain.name == chainName)).ElementAt(0);
            var itemPrices = items.Select((item) => (relleventChain.getItemPrice(item.name))*(item.GetCapacity())).ToList();
            return itemPrices.Sum();
        }

        public Dictionary<string, bool> getChainNamesAndAvailability()
        {
            Dictionary<string, bool> chainsDictionary = new Dictionary<string, bool>();
            chains.ForEach((chain) =>
            {
                 chainsDictionary.Add(chain.name,chain.isWanted);
            });
            return chainsDictionary;
        }

        public void SetChains(Dictionary<string, bool> chainsDictonary)
        {
            chains.ForEach((chain) =>
            {
                if (chain.isWanted != chainsDictonary[chain.name])
                    chain.changeValue();
            });
        }
    }
}
