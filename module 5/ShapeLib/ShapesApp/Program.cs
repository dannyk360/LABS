using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeLib;

namespace ShapesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Ellipse elli = new Ellipse(5, 3, ConsoleColor.Green);
            Rectangle recta = new Rectangle(5, 3);
            ShapeManager shapeManager = new ShapeManager();
            shapeManager.Add(elli);
            shapeManager.Add(recta);
            shapeManager.Add(new Circle(5,ConsoleColor.Blue));

            StringBuilder c = new StringBuilder();
            shapeManager.Save(c);

            Console.WriteLine("the area of the rectangle is " + recta.CompareTo(elli) + " than the area of the ellipse");
            shapeManager.DisplayAll();
        }
    }
}
