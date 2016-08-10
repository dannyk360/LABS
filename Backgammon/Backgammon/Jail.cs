using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon
{
    public static class Jail
    {
        public static bool checkIfThereIsSomeOneInJail(Color.color color,Board board)
        {
            
           return (board.getNumberOfTiles(color) > 0);
            
        }

        public static List<OneStep> giveAllTheSteps(Board board, Color.color currentColor,List<int> roll)
        {
            List<OneStep> jailStep = new List<OneStep>();
            bool colorIsWhite = (currentColor == Color.color.white);
 

            foreach (int cube in roll)
            {
                int whichSpotFromJail = colorIsWhite ? (24 - cube) : cube - 1;
                if (board.SpotsOnBoard[whichSpotFromJail].color != ((colorIsWhite)?Color.color.black : Color.color.white)  || board.SpotsOnBoard[whichSpotFromJail].numberOfTiles == 1)
                    jailStep.Add(new OneStep(colorIsWhite? 25 : 24, whichSpotFromJail));
            }
            return jailStep;
        }

        internal static void putTheTiles(int _to, Player currentPlayer, Board board)
        {
            if (board.SpotsOnBoard[_to].color == Color.returnOpposite(currentPlayer.color))
            {
                board.addJailNumber(currentPlayer.color);
                board.SpotsOnBoard[_to].numberOfTiles--;
            }
            board.SpotsOnBoard[_to].color = currentPlayer.color;
            board.subJailNumber(currentPlayer.color);
            board.SpotsOnBoard[_to].numberOfTiles++;
        }
    }
}
