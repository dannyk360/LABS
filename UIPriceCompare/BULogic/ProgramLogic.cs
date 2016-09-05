using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Entity;

namespace BULogic
{
    public class ProgramLogic
    {
        private static Chains chains;
        private static int lockNumber = 0;
        private static ICollection<Task> tasksToWait;

        public static void InitChains()
        {
            chains = new Chains();
            tasksToWait = new List<Task>();
        }

        public static List<string> GetGroceries(string typeProducts)
        {
            return Groceries.GetGroceries(typeProducts);
        }

        public static Task<int> ReplaceGrocieryCount(string itemName,int subCapacity)
        {

            return Task.Run(() =>
            {
                return Groceries.ReplaceItemCapcity(itemName, subCapacity);
            });
        }

        public static void AddGrociery(string itemName, int itemCapacity)
        {
            tasksToWait.Add(Task.Run(()=>
            {
                  Groceries.AddItem(itemName, itemCapacity);
                 Chains.AddItem(itemName);
            }
            ));
            
            
        }

        public static string[] getChainsName()
        {
            return Chains.getChainsName();
        }

        public static Task<ItemsInChain> getChainInfo(string chain)
        {
            return Task.Run(() =>
            {
                Task.WaitAll(tasksToWait.ToArray());
                tasksToWait.Clear();
                ItemsInChain result = new ItemsInChain();
                var items = Groceries.getAllItems();
                result.sum = Chains.getSum(chain, items);
                var chainInfo = Chains.getChainInfo(chain,items);
                for (int i = 0; i < 3 && i < chainInfo.Count; i++)
                {
                    result.cheapestList.Add(chainInfo[i]);
                }
                for (int i = 3; i < chainInfo.Count; i++)
                {
                    result.expensiveList.Add(chainInfo[i]);
                }
                return result;
            });

        }

        public static Task<int> AddGrocieryCount(string itemName,int addCapcity)
        {
            return Task.Run(() =>
            {
                return Groceries.AddItemCapcity(itemName, addCapcity);
            });

        }

        public static void ClearGrocieries()
        {
            Groceries.Clear();
        }

        public static Task<Dictionary<string, bool>> getAllChains()
        {
            return Task.Run(() =>{
                return  chains.getChainNamesAndAvailability();
            });
        }

        public static void ChangeChainsBool(Dictionary<string, bool> chainsDictonary)
        {
            chains.SetChains(chainsDictonary);
        }
    }
}

