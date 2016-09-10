using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BULogic
{
    public class ProgramLogic
    {
        private static Chains _chains;
        private static Groceries _items;
        private static int _lockNumber = 0;
        private static ICollection<Task> _tasksToWait;

        public static void InitChains()
        {
            _chains = new Chains();
            _items = new Groceries();
            _tasksToWait = new List<Task>();
        }

        public static List<string> GetGroceries(string typeProducts)
        {
            return _items.GetGroceries(typeProducts);
        }


        public static void AddGrociery(string itemName, double itemCapacity)
        {
            _tasksToWait.Add(Task.Run(() =>
                {
                    _items.AddItem(itemName, itemCapacity);
                    _chains.AddItem(itemName);
                }
            ));
        }

        public static Task<string[]> GetChainsName()
        {
            return Task.Run(() => _chains.GetChainsName());
        }

        public static Task<ItemsInChain> GetChainInfo(string chain)
        {
            return Task.Run(() =>
            {
                Task.WaitAll(_tasksToWait.ToArray());
                _tasksToWait.Clear();
                var result = new ItemsInChain();
                var items = _items.GetAllItems();
                var chainInfo = _chains.GetChainInfo(chain, items);
                for (var i = 0; (i < 3) && (i < chainInfo.Count); i++)
                    result.CheapestList.Add(chainInfo[i]);

                Parallel.For(3, chainInfo.Count, i => result.ExpensiveList.Add(chainInfo[i]));
                return result;
            });
        }

        public static void ChangeGrocieryCount(string itemName, double capacity)
        {
            _items.ChangeCapcity(itemName, capacity);
        }

        public static void ClearGrocieries()
        {
            _items.Clear();
        }

        public static Task<Dictionary<string, bool>> GetAllChains()
        {
            return Task.Run(() => _chains.GetChainNamesAndAvailability());
        }

        public static void ChangeChainsBool(Dictionary<string, bool> chainsDictonary)
        {
            _chains.SetChains(chainsDictonary);
        }

        public static Task<double> GetItemCapacity(string itemName)
        {
            return Task.Run(() => _items.GetGroceryCapacity(itemName));
        }

        public static Task<string[]> GetCategoriesOfItems()
        {
            return Task.Run(() => _items.GetCategories());
        }

        public static Task<List<double>> GetSumsOfChains()
        {
            return Task.Run(() =>
            {
                Task.WaitAll(_tasksToWait.ToArray());
                _tasksToWait.Clear();
                var items = _items.GetAllItems();
                return _chains.GetSum(items);
            });
        }
    }
}