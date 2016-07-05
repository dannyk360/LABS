using System;

namespace GenericApp
{
    internal class Program
    {
        private static void Main()
        {
            var multiDictionary = new MultiDictionary<int, string>
            {
                {1, "one"},
                {2, "two"},
                {3, "three"},
                {1, "ich"},
                {2, "nee"},
                {3, "sun"}
            };

            Display(multiDictionary);

            multiDictionary.Remove(1);
            Display(multiDictionary);

            multiDictionary.Remove(3, "three");
            Display(multiDictionary);

            multiDictionary.Remove(1, "one");
            Display(multiDictionary);

            multiDictionary.Add(1, "ich");
            Display(multiDictionary);

            multiDictionary.Clear();
            Display(multiDictionary);

        }

        private static void Display(MultiDictionary<int, string> multiDictionary)
        {
            if (multiDictionary.Count != 0)
                foreach (var key in multiDictionary)
                    foreach (var value in key.Value)
                        Console.WriteLine($"Key: {key.Key}, Value: {value}");
            else
                Console.WriteLine("The Dictionary has been cleared and is now Empty.");
        }
    }
}
