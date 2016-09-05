using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BULogic
{
    public class ItemsInChain
    {
        public double sum { get; set; }
        public List<string> cheapestList;
        public List<string> expensiveList;

        public ItemsInChain()
        {
            cheapestList = new List<string>();
            expensiveList = new List<string>();
        }

    }
}
