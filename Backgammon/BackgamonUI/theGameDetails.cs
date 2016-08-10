using Backgammon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackgamonUI
{
    public class theGameDetails
    {
        private Game game;

        public theGameDetails(Game game)
        {
            this.game = game;
        }

        internal bool makeAPlay(int start,int finish)
        {
            if (!game.doTheTurn(new OneStep(start, finish)))
            {
                endTurn();
                return false;
            }
            return true;
        }

        private void endTurn()
        {
            if (game.getWinner() != Color.color.empty)
            {
                MessageBox.Show($"the winner is {game.getWinnerColorString()}");
                Application.Exit();
            }
            
        }
    }
}
