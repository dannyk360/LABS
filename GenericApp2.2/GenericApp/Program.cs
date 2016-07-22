using System;
using System.Text;

namespace GenericApp
{
    class Program
    {
        private static void Main()
        {
            var multiDictionary = new MultiDictionary<numberWithAttribute, StringBuilder>();

            numberWithAttribute number;
            number.num = 1;

            
            multiDictionary.CreateNewValue(number);

            Display(multiDictionary);
            multiDictionary.Remove(number);
            Display(multiDictionary);
            Console.Read();

        }

        private static void Display(MultiDictionary<numberWithAttribute, StringBuilder> multiDictionary)
        {
            if (multiDictionary.Count != 0)
                foreach (var key in multiDictionary)
                    foreach (var value in key.Value)
                        Console.WriteLine($"Key: {key.Key.num}, Value: {value}");
            else
                Console.WriteLine("The Dictionary has been cleared and is now Empty.");
        }
    }
    [Key]
    public struct numberWithAttribute
    {
        public int num;
    }
}
