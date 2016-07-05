using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    public class Circle : Ellipse
    {
        public Circle(int r) : base(r, r) { }
        public Circle(int r,ConsoleColor c) : base( r, r, c){}

        public override void Display()
        {
            Console.BackgroundColor = Color;
            Console.WriteLine("the radius is " + littleR );
        }

    }
}
