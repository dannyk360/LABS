using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class TicTacToeGame
    {
        public enum Cell
        {
            X= 'x',O = 'o',empty = ' ',draw
        }
         public Cell[,] mat;
        public int num = 0;
        public Cell IsGameOver = Cell.empty;
        public TicTacToeGame()
        {
            mat = new Cell[3, 3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    mat[i, j] = Cell.empty;
        }

        public void display()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(mat[i, 0] + "\t|" + mat[i, 1] + "\t|" + mat[i, 2]);
                Console.WriteLine("_______________________");
            }
        }

        public bool setMove(int i, int j, Cell c)
        {
            if ( i > 2 || j > 2 || mat[i, j] != Cell.empty)
                return false;
            mat[i, j] = c;
            if (mat[i, 0] == c && mat[i, 1] == c && mat[i, 2] == c)
            {
                IsGameOver = c;
                return true;
            }
            if (mat[0, j] == c && mat[1, j] == c && mat[2, j] == c)
            {
                IsGameOver = c;
                return true;
            }
            if ((i == j) && mat[0, 0] == c && mat[1, 1] == c && mat[2, 2] == c)
            {
                IsGameOver = c;
                return true;
            }
            if ((i + j == 2) && mat[2, 0] == c && mat[1, 1] == c && mat[0, 2] == c)
            {
                IsGameOver = c;
                return true;
            }
            num++;
            if (num == 9)
                IsGameOver = Cell.draw;
            return true;
        }



    }
}
