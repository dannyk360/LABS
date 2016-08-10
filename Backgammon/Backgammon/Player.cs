using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon
{
    public class Player
    {
        public  Color.color color { get; }
        public bool isInTheLastZone { get; set; }
        public int NumberOfTilesGotOut { get; set; }
        public Player(Color.color color)
        {
            this.color = color;
            isInTheLastZone = false;
        }

        
    }
}
