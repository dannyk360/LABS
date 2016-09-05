using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using DBAccess;
using Entity;
namespace BULogic
{
    public class Groceries
    {
        private static Dictionary<string,IItem> groceries = new Dictionary<string, IItem>();
        private static Dictionary<string, List<string>> groceriesByCategory = new Dictionary<string, List<string>>();
        public static List<string> GetGroceries(string typeName)
        {
            if (!groceriesByCategory.ContainsKey(typeName)) { 
                groceriesByCategory.Add(typeName, DBAccess.readFromXml.GetGroceriesFromAdb(typeName));
            }
            return groceriesByCategory[typeName];
        }

        public static int ReplaceItemCapcity(string itemName, int itemCapacity)
        {
            return groceries[itemName].ReplaceCapcity(itemCapacity);
        }

        public static int AddItemCapcity(string itemName, int addCapacity)
        {
            return groceries[itemName].AddCapcity(addCapacity);
        }

        public static void AddItem(string itemName, int itemCapacity)
        {
            if(!groceries.ContainsKey(itemName))
                groceries.Add(itemName,new Item(itemName,itemCapacity) as IItem);
            else
            {
                AddItemCapcity(itemName, itemCapacity);
            }
        }


        public static List<IItem> getAllItems()
        {
            return (groceries.Values.Where((item) => item.GetCapacity() > 0)).ToList();
        }

        public static void Clear()
        {
            foreach (var item in groceries.Values)
            {
                item.ReplaceCapcity(item.GetCapacity());
            }
        }
    }
}
