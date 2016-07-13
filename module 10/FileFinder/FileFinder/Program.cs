using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("not enought arguments");
                Console.ReadLine();
                return;
            }
            try
            {
                var namesF = Directory.GetFiles(args[0], "*" + args[1] + "*");
                var namesD = Directory.GetDirectories(args[0], "*" + args[1] + "*");
                foreach (var name in namesF)
                {
                    Console.WriteLine(name);
                }
                foreach (var name in namesD)
                {
                    Console.WriteLine(name);
                }
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("directory not found");
            }
            Console.ReadLine();
        }
    }
}
