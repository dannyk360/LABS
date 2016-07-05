using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    public class Ellipse : Shape , IComparable
    {
        public readonly int littleR;
        public readonly int bigR;

        public Ellipse(int lR, int bR) : base()
        {
            littleR = lR;
            bigR = bR;
        }

        public Ellipse(int lR,int bR,ConsoleColor c) : base(c)
        {
            littleR = lR;
            bigR = bR;
        }

        public override double Area {
            get { return Math.Pow((double) (littleR + bigR) /2, 2) * Math.PI; } 
        }
        public override void Display()
        {
            Console.BackgroundColor = Color;
            Console.WriteLine("the little radius is " + littleR + " the big radius is " + bigR);
        }
        public void Write(StringBuilder sb)
        {
            sb.AppendLine("the little radius is " + littleR + " the big radius is " + bigR);
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
