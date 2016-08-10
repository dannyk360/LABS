using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon
{
    public interface IExectuteTurn
    {
         List<OneStep> excuteTurn(OneStep thisTurn, List<OneStep> Possabilitiesleft, Color color, Player currentPlayer, Player opponent, Board board);
    }
}
