using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public interface IChain
    {
        void AddItem(string itemName, Task<double> price);
        double getItemPrice(string itemName);
        bool checkIfThereIsAnItem(string itemName);
        void changeValue();

        string name { get; }
        bool isWanted { get;}
    }
}
