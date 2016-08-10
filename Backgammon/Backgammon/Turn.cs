using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon
{
    static class Turn
    {

        public  static List<int> currentRoll;
        internal static List<OneStep> StartNextTurn(Cubes cubes, Color color, Player currentPlayer, Board board)
        {
            currentRoll = new List<int>();
            currentRoll.Add(cubes.cube1);
            currentRoll.Add(cubes.cube2);
            if (cubes.cube2 == cubes.cube1)
            {
                currentRoll.Add(cubes.cube1);
                currentRoll.Add(cubes.cube1);
            }
            return returnPossabilities(board,  color.currentColor, currentPlayer);
        }
        private static List<OneStep> returnPossabilities(Board board, Color.color currentColor, Player currentPlayer)
        {
            if (Jail.checkIfThereIsSomeOneInJail(currentColor, board))
            {
                return Jail.giveAllTheSteps(board, currentColor, Turn.currentRoll);
            }
            if (currentPlayer.isInTheLastZone)
            {
                return LastZone.giveAllTheSteps(board, currentColor, Turn.currentRoll);
            }
            return RegularZone.giveAllTheSteps(board, currentColor, Turn.currentRoll);
        }

        internal static List<OneStep> excecuteTheTurn(OneStep thisTurn, List<OneStep> possabilitiesleft, Color color, Player currentPlayer, Player opponent, Board board)
        {
            if (thisTurn._from > 23)
                return (new ExecuteJailTurn().excuteTurn(thisTurn, possabilitiesleft, color, currentPlayer, opponent, board));
            if(currentPlayer.isInTheLastZone == true)
                return (new ExecuteLastZoneTurn ().excuteTurn(thisTurn, possabilitiesleft, color, currentPlayer, opponent, board));
            return (new regularExecuteTurn().excuteTurn(thisTurn, possabilitiesleft, color, currentPlayer, opponent, board));
        }
    }
}
