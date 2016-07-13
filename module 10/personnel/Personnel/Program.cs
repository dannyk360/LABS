using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personnel
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> strlist = ReadFromTxt();
            foreach (string str in strlist)
            {
                Console.WriteLine(str);
            }

            Console.ReadLine();
        }

        public static List<string> ReadFromTxt()
        {
            List<string> strList = new List<string>();
            StreamReader Sr = new StreamReader(@"C:\Users\danny_000\Documents\Visual Studio 2015\Projects\Personnel\Personnel\Names.txt");
            while(!Sr.EndOfStream)
                strList.Add(Sr.ReadLine());
            return strList;
        }
    }
}
