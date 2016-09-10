using System.Collections.Generic;

namespace BULogic
{
    public class ItemsInChain
    {
        public List<string> CheapestList;
        public List<string> ExpensiveList;

        public ItemsInChain()
        {
            CheapestList = new List<string>();
            ExpensiveList = new List<string>();
        }
    }
}