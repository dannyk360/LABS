using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    public abstract class Shape
    {
        public ConsoleColor Color { get; set; }
        public abstract Double Area { get;}
        protected Shape(ConsoleColor c)
        {
            Color = c;
        }

        public Shape()
        {
            Color = ConsoleColor.White;
        }

        public virtual void Display()
        {
            Console.BackgroundColor = Color;
        }


    }
}
