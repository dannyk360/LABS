using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public interface IItem
    {
        int ReplaceCapcity(int subcapacity);
        int GetCapacity();
        int AddCapcity(int addCapacity);
        string name { get;}
    }
}
