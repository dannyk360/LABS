using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    public class Rectangle : Shape , IPersist , IComparable
    {
        private readonly int _width;
        private readonly int _height;

        public Rectangle(int wid,int heig) : base()
        {
            _width = wid;
            _height = heig;
        }
        public Rectangle(int wid, int heig,ConsoleColor c) : base(c)
        {
            _width = wid;
            _height = heig;
        }

        public int Width
        {
            get { return _width; }
        }

        public int Height
        {
            get { return _height; }
        }

        public override double Area => Width*Height;

        public override void Display() 
        {
            Console.BackgroundColor = Color;
            Console.WriteLine("the width is " + Width + " the height is " + Height );
        }

        public void Write(StringBuilder sb)
        {
            sb.AppendLine("the width is " + Width + " the height is " + Height);
        }

        public int CompareTo(object obj)
        {
            dynamic shape = obj;
            if (this.Area > shape.Area)
                return 1;
            else if (this.Area == shape.Area)
                return 0;
            return -1;
        }
    }
}
