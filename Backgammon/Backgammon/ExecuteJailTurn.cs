using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon
{
    class ExecuteJailTurn : regularExecuteTurn
    {
        public List<OneStep> excuteTurn(OneStep thisTurn, List<OneStep> Possabilitiesleft, Color color, Player currentPlayer, Player opponent, Board board)
        {
            board.StepInATurn(thisTurn, opponent, currentPlayer);
            for (int i = 0; i < Turn.currentRoll.Count; i++)
            {
                if (thisTurn._to < 6)
                {
                    if (Turn.currentRoll[i] == thisTurn._to + 1)
                    {
                        Turn.currentRoll.RemoveAt(i);
                        break;
                    }
                }
                if (Turn.currentRoll[i] == 24 - thisTurn._to)
                {
                    Turn.currentRoll.RemoveAt(i);
                    break;
                }
            }
            return returnPossabilities(board, color.currentColor, currentPlayer);
        }
    }
}
