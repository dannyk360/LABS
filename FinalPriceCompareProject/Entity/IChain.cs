using System.Threading.Tasks;

namespace Entity
{
    public interface IChain
    {
        string Name { get; }
        bool IsWanted { get; }
        void AddItem(string itemName, Task<double> price);
        double GetItemPrice(string itemName);
        bool CheckIfThereIsAnItem(string itemName);
        void ChangeValue();
    }
}