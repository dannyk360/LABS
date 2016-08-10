using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon
{
    public class Color
    {
        public enum color {white,black,empty}
        public color currentColor { get; private set; }
        public Color()
        {
            currentColor = (color)(new Random().Next(2));

        }

        public void ChangeColor()
        {
            currentColor = (color)(((int)currentColor) ^ 1);
        }

        public static color returnOpposite(color current)
        {
            return  (color)((int)current ^ 1);
        }


    }
}
