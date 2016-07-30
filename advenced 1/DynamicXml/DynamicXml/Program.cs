using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DynamicXml
{
    class Program
    {
        static void Main(string[] args)
        {
            //Absolute file paths are rarely a good idea
            dynamic planets = DynamicXElement.Create(XElement.Load(@"C:\Users\danny_000\Documents\Visual Studio 2015\Projects\DynamicXml\DynamicXml\planets.xml"));
            var mercury = planets.Planet;       // first planet
            Console.WriteLine(mercury);
            var venus = planets["Planet", 1];   // second planet 
            Console.WriteLine(venus);
            var ourMoon = planets["Planet", 2].Moons.Moon;
            Console.WriteLine(ourMoon);
            var marsMoon = planets["Planet", 3]["Moons", 0].Moon; // mars second moon
            Console.WriteLine(marsMoon);

        }
    }
}
