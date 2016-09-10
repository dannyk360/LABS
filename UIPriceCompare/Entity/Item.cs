namespace Entity
{
    public class Item : IItem
    {
        public Item(string name, double capacity)
        {
            Name = name;
            Capacity = capacity;
        }

        private double Capacity { get; set; }
        public string Name { get; private set; }

        public void ReplaceCapcity(double subcapacity)
        {
            Capacity = subcapacity;
        }

        public double GetCapacity()
        {
            return Capacity;
        }
    }
}