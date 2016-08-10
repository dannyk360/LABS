using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon
{
    public static class RegularZone
    {
        public static List<OneStep> giveAllTheSteps(Board board, Color.color currentColor, List<int> currentRoll)
        {
            List<OneStep> stepList = new List<OneStep>();
            bool isWhite = currentColor == Color.color.white; 

            int goToFactor = isWhite ? -1 : 1;
            
            for (int i = 0; i < 24; i++)
            {
                if (board.SpotsOnBoard[i].color == currentColor)
                {
                    foreach (var cube in currentRoll)
                    {
                        if ((isWhite)?(i - cube > -1) : (i + cube < 24))
                        {
                            if ((board.SpotsOnBoard[i + cube * goToFactor].color != Color.returnOpposite(currentColor) || board.SpotsOnBoard[i + cube * goToFactor].numberOfTiles == 1))
                            {
                                stepList.Add(new OneStep(i, i + cube * goToFactor));
                            }
                        }
                    }
                }
            }
            
            return stepList;
        }

        internal static void putTheTiles(OneStep chose, Player currentPlayer,Player Opponent, Board board)
        {
            if (currentPlayer.color == Color.returnOpposite(board.SpotsOnBoard[chose._to].color) )
            { 
                board.addJailNumber(currentPlayer.color);
                Opponent.isInTheLastZone = false;
            }
            
            if (board.SpotsOnBoard[chose._to].color != board.SpotsOnBoard[chose._from].color)
            {
                board.SpotsOnBoard[chose._to].color = currentPlayer.color;
                board.SpotsOnBoard[chose._to].numberOfTiles = 1;
            }
            else
            {
                board.SpotsOnBoard[chose._to].numberOfTiles++;
            }

            if (--(board.SpotsOnBoard[chose._from].numberOfTiles) == 0)
            {
                board.SpotsOnBoard[chose._from].color = Color.color.empty;
            }
        }
    }
}
