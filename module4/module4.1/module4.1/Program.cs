using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace module4._1
{
    class Program
    {
        static void Main(string[] args)
        {

            printAllPublicInterfaces();
            printAllproseess();
            displayNumberOfThreadsInSystem();
            Console.ReadLine();
        }

        private static void displayNumberOfThreadsInSystem()
        {
            var processesObjects = Process.GetProcesses();
            var sum = (from process in processesObjects
                       select process.Threads.Count).Sum();
            
            Console.WriteLine(sum);
        }

        private static void printAllproseess()
        {
            var processesObjects = Process.GetProcesses();
            var processesLessThan5Thread = from process in processesObjects
                                           where process.Threads.Count < 5
                                           orderby process.Id
                                           select process;
            var processesGrouped = from process in processesLessThan5Thread
                                   group process by process.BasePriority;
            foreach (var processGroup in processesGrouped)
            {
                Console.WriteLine("processes group base priority is : " + processGroup.Key);
                foreach (var process in processGroup)
                {
                    try
                    {
                        Console.WriteLine(process.ProcessName + "," + process.Id + "," + process.StartTime);
                    }
                    catch (Win32Exception e)
                    {
                        Console.WriteLine($"Access denied to proc: " + process.ProcessName);
                    }
                }
            }


        }

        private static void printAllPublicInterfaces()
        {
            var asm = Assembly.Load("mscorlib");
            var interfacesNames = (from type in asm.GetTypes()
                                   where type.IsInterface && type.IsPublic
                                   orderby type.Name
                                   select type.Name);
            foreach (var name in interfacesNames)
            {
                Console.WriteLine(name);
            }
        }
    }


}
