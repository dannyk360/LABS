using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon
{
    class ExecuteLastZoneTurn : regularExecuteTurn
    {
        public List<OneStep> excuteTurn(OneStep thisTurn, List<OneStep> Possabilitiesleft, Color color, Player currentPlayer, Player opponent, Board board)
        {
            int startPoint = (currentPlayer.color == Color.color.white) ? (thisTurn._from + 1) : (24 - thisTurn._from);
            int i;
            bool isRemoved = false;
            var colorGoTo = (color.currentColor == Color.color.black) ? 1 : -1;
            for (i = 0; i < Turn.currentRoll.Count && thisTurn._to != 26; i++)
            {
                if (Turn.currentRoll[i] == (thisTurn._to - thisTurn._from) * colorGoTo)
                {
                    Turn.currentRoll.RemoveAt(i);
                    isRemoved = true;
                    break;
                }
            } 

            if (Turn.currentRoll.Count > 0 && isRemoved == false)
            {

                if (Turn.currentRoll[0] >= startPoint)
                    Turn.currentRoll.RemoveAt(0);
                else
                {
                    for ( i = 1; i < Turn.currentRoll.Count; i++)
                    {

                        if (Turn.currentRoll[i] >= startPoint)
                        {
                            Turn.currentRoll.RemoveAt(i);
                            break;
                        }

                    }
                }
            }

            board.StepInATurn(thisTurn, opponent, currentPlayer);
            if (Turn.currentRoll.Count == 0)
                return new List<OneStep>();
            Possabilitiesleft = returnPossabilities(board, color.currentColor, currentPlayer);
            return Possabilitiesleft;
        }
    }
}
