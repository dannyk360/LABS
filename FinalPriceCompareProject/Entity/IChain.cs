using System.Threading.Tasks;

namespace Entity
{
    /*Very good @ abstracting the data by an interface.
     * Consider 
    */
    public interface IChain
    {
        string Name { get; }

        //Is it wanted for murder? Make sure your code is understandable not only to yourself, but to others as well
        bool IsWanted { get; }
        void AddItem(string itemName, Task<double> price);
        double GetItemPrice(string itemName);
        bool CheckIfThereIsAnItem(string itemName);

        //It is unclear which value you are refering to, and what purpose does this method serve.
        void ChangeValue();
    }
}