using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon
{
    public class Board
    {
        public Spot[] SpotsOnBoard; 
        private int NumberOfWhiteTilesInJail { get; set; }
        private int NumberOfBlackTilesInJail { get; set; }

        public Board()
        {
                  SpotsOnBoard = new Spot[24];
            /*SpotsOnBoard[0] = new Spot(Color.color.black, 2);
            SpotsOnBoard[23] = new Spot(Color.color.white, 2);
            for (int i = 1; i < 5; i++)
            {
                SpotsOnBoard[i] = new Spot();
                SpotsOnBoard[23-i] = new Spot();
            }
            SpotsOnBoard[5] = new Spot(Color.color.white, 5);
            SpotsOnBoard[18] = new Spot(Color.color.black, 5);
            SpotsOnBoard[6] = new Spot();
            SpotsOnBoard[17] = new Spot();
            SpotsOnBoard[7] = new Spot(Color.color.white, 3);
            SpotsOnBoard[16] = new Spot(Color.color.black, 3);
            for (int i = 8; i < 11; i++)
            {
                SpotsOnBoard[i] = new Spot();
                SpotsOnBoard[23 - i] = new Spot();
            }
            SpotsOnBoard[11] = new Spot(Color.color.black, 5);
            SpotsOnBoard[12] = new Spot(Color.color.white, 5);*/
            for (int i = 0; i < 12; i++)
            {
                SpotsOnBoard[i] = new Spot();
                SpotsOnBoard[23 - i] = new Spot();
            }
            SpotsOnBoard[5] = new Spot(Color.color.white, 14);
            SpotsOnBoard[18] = new Spot(Color.color.black, 14);
            SpotsOnBoard[11] = new Spot(Color.color.black, 1);
            SpotsOnBoard[12] = new Spot(Color.color.white, 1);
        }

        public void addJailNumber(Color.color color)
        {
            if (color == Color.color.black)
                NumberOfWhiteTilesInJail++;
            else
                NumberOfBlackTilesInJail++;
        }
        public void subJailNumber(Color.color color)
        {
            if (color == Color.color.black)
                NumberOfBlackTilesInJail--;
            else
                NumberOfWhiteTilesInJail--;
        }
        internal void StepInATurn(OneStep ChoseOfUser, Player opponent, Player currentPlayer)
        {
            if (ChoseOfUser._from > 23)
            {
                Jail.putTheTiles(ChoseOfUser._to,  currentPlayer, this);
                return;
            }
            if (ChoseOfUser._to > 23)
            {
                LastZone.putTheTiles(ChoseOfUser._from, currentPlayer, this);
                return;
            }
            RegularZone.putTheTiles(ChoseOfUser, currentPlayer,opponent, this);

        }
        public int getNumberOfTiles(Color.color color)
        {
            return (color == Color.color.white) ? NumberOfWhiteTilesInJail : NumberOfBlackTilesInJail;
        }
    }
}
