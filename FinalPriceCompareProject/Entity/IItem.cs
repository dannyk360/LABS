namespace Entity
{
    public interface IItem
    {
        string Name { get; }
        void ReplaceCapcity(double subcapacity);
        double GetCapacity();
    }
}