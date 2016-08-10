using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon
{
    public class Spot
    {
        public int numberOfTiles { get; set; }
        public Color.color color { get; set; }

        public Spot()
        {
            color = Color.color.empty;
            numberOfTiles = 0;
        }

        public Spot(Color.color player,int numberOfTiles)
        {
            color = player;
            this.numberOfTiles = numberOfTiles;
        }

    }


}
