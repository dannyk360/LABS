using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon
{
    class regularExecuteTurn : IExectuteTurn
    {
        public List<OneStep> excuteTurn(OneStep thisTurn, List<OneStep> Possabilitiesleft, Color color, Player currentPlayer, Player opponent, Board board)
        {
            int i;
            int colorGoTo = (color.currentColor == Color.color.black) ? 1 : -1;
            Action<OneStep, List<OneStep>> removeFromPossabilities = (x, y) => { };
            for (i = 0; i < Turn.currentRoll.Count && thisTurn._to != 26; i++)
            {
                if (Turn.currentRoll[i] == (thisTurn._to - thisTurn._from) * colorGoTo)
                {
                    Turn.currentRoll.RemoveAt(i);
                    break;
                }
            }

            if (board.getNumberOfTiles(color.currentColor) == 0)
            {
                foreach (var cube in Turn.currentRoll)
                {
                    if (cube * colorGoTo + thisTurn._to < 24 && cube * colorGoTo + thisTurn._to > 0 && (board.SpotsOnBoard[cube * colorGoTo + thisTurn._to].numberOfTiles < 2 || board.SpotsOnBoard[cube * colorGoTo + thisTurn._to].color == currentPlayer.color))
                        Possabilitiesleft.Add(new OneStep(thisTurn._to, cube * colorGoTo + thisTurn._to));
                }
            }

            board.StepInATurn(thisTurn, opponent, currentPlayer);

            if (thisTurn._from < 23)
            {

                if (board.SpotsOnBoard[thisTurn._from].numberOfTiles == 0)
                {
                    removeFromPossabilities += (turn, Possabilitieslist) =>
                    {
                        Possabilitiesleft = (from step in Possabilitiesleft
                                             where (turn._from != step._from)
                                             select step).ToList();
                    };
                }
            }

            if (!Turn.currentRoll.Contains((thisTurn._to - thisTurn._from) * colorGoTo))
            {
                removeFromPossabilities += (turn, Possabilitieslist) =>
                {
                    Possabilitiesleft = (from step in Possabilitiesleft
                                         where (turn._to - turn._from != step._to - step._from)
                                         select step).ToList();
                };
            }

            var finishValue = (colorGoTo < 0) ? 24 : 18;

            for (i = finishValue - 18; i < finishValue; i++)
            {
                if (board.SpotsOnBoard[i].color == color.currentColor)
                    break;
            }

            if (i == finishValue && currentPlayer.isInTheLastZone != true)
            {
                currentPlayer.isInTheLastZone = true;
                if (Turn.currentRoll.Count == 0)
                    return new List<OneStep>();
                Possabilitiesleft = returnPossabilities(board, color.currentColor, currentPlayer);

                return Possabilitiesleft;
            }

            removeFromPossabilities.Invoke(thisTurn, Possabilitiesleft);
            return Possabilitiesleft;
        }
        protected static List<OneStep> returnPossabilities(Board board, Color.color currentColor, Player currentPlayer)
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
    }
}
