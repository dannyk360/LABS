using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    public class Rectangle : Shape, IPersist, IComparable
    {
        //+1 for using readonly :)
        private readonly int _width;
        private readonly int _height;

        /*
        No input validation for 'width' nor 'height'
        */
        public Rectangle(int wid, int heig) : base()
        {
            _width = wid;
            _height = heig;
        }

        /*
        Consider the following DRY implementation:

       public Rectangle(ConsoleColor color,int width, int height):base(color)
       {
         Initialize(width,height);
       }

       public Rectangle(int width, int height):base(color)
       {
          Initialize(width,height);
       }

       private void Initialize(int width, int height)
       {
            _width = width;
           _height = height;
           _area = _width*_height;
       }

       */
        public Rectangle(int wid, int heig, ConsoleColor c) : base(c)
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

        //Consider computing this at construct time.
        public override double Area => Width * Height;

        public override void Display()
        {
            Console.BackgroundColor = Color;//Replace this with 'base.Display();'
            Console.WriteLine("the width is " + Width + " the height is " + Height);
        }

        public void Write(StringBuilder sb)
        {
            sb.AppendLine("the width is " + Width + " the height is " + Height);
        }

        public int CompareTo(object obj)
        {
            /**
             The compiler exists for your own good.
             Shutting it up is rarely a good solution to anything.

             Consider using Rectangle as a reference, check for null and if it is indeed a rectangle
             */
            dynamic shape = obj;
            if (this.Area > shape.Area)
                return 1;
            else if (this.Area == shape.Area)
                return 0;
            return -1;
        }
    }
}
