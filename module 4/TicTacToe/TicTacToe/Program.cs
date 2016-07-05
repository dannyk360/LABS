using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToeGame game = new TicTacToeGame();
            int i, j;
            TicTacToeGame.Cell c = TicTacToeGame.Cell.X;
            while (game.IsGameOver == TicTacToeGame.Cell.empty)
            {
                i = int.Parse(Console.ReadLine());
                j = int.Parse(Console.ReadLine());
                if (!game.setMove(i, j, c)) ;
                else if (c == TicTacToeGame.Cell.X)
                    c = TicTacToeGame.Cell.O;
                else
                    c = TicTacToeGame.Cell.X;
                game.display();
            }
            if (game.IsGameOver == TicTacToeGame.Cell.draw)
                Console.WriteLine("DRAW");
            else
            {
                Console.WriteLine(game.IsGameOver + " WON");
            }
            Console.ReadLine();
        }
    }
}
