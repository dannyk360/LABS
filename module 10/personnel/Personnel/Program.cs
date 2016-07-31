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
        /**Bug: Application crashes because file is not found (consider not using an absolute path when working with files)
         * Which would have been fine since your code is correct. unfortunately you are not handling exceptions at all, which is expected at this point in the course.
         * Consider this:
         * https://msdn.microsoft.com/en-us/library/ms164917.aspx
         */
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
     
            /**Bug: you are not disposing of the string reader
             * Consider this:
             * https://msdn.microsoft.com/en-us/library/3bwa4xa9(v=vs.110).aspx
             */

            StreamReader Sr = new StreamReader(@"C:\Users\danny_000\Documents\Visual Studio 2015\Projects\Personnel\Personnel\Names.txt");
            while(!Sr.EndOfStream)
                strList.Add(Sr.ReadLine());
            return strList;
        }
    }
}
