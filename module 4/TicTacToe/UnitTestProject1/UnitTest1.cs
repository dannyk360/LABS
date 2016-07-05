using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTicTacToeTest1
    {
        [TestMethod]
        public void Test_IsMovePossible_Failed()
        {
            TicTacToe.TicTacToeGame game = new TicTacToe.TicTacToeGame();

            Assert.AreEqual(false, game.setMove(3,3,TicTacToe.TicTacToeGame.Cell.X));
        }

        [TestMethod]
        public void Test_XRowWin_Success()
        {
            TicTacToe.TicTacToeGame game = new TicTacToe.TicTacToeGame();
            TicTacToe.TicTacToeGame.Cell[,] mat = new TicTacToe.TicTacToeGame.Cell[3, 3];
            game.mat[0, 0] = TicTacToe.TicTacToeGame.Cell.X;
            game.mat[0, 1] = TicTacToe.TicTacToeGame.Cell.X;

            Assert.AreEqual(true, game.setMove(0, 2, TicTacToe.TicTacToeGame.Cell.X));
            Assert.AreEqual(TicTacToe.TicTacToeGame.Cell.X, game.IsGameOver);
        }
        [TestMethod]
        public void Test_OWin_Success()
        {
            TicTacToe.TicTacToeGame game = new TicTacToe.TicTacToeGame();
            TicTacToe.TicTacToeGame.Cell[,] mat = new TicTacToe.TicTacToeGame.Cell[3, 3];
            game.mat[0, 0] = TicTacToe.TicTacToeGame.Cell.O;
            game.mat[1, 0] = TicTacToe.TicTacToeGame.Cell.O;

            Assert.AreEqual(true, game.setMove(2, 0, TicTacToe.TicTacToeGame.Cell.O));
            Assert.AreEqual(TicTacToe.TicTacToeGame.Cell.O, game.IsGameOver);
        }

        [TestMethod]
        public void Test_XDiagonalWin_Success()
        {
            TicTacToe.TicTacToeGame game = new TicTacToe.TicTacToeGame();
            game.mat[0, 0] = TicTacToe.TicTacToeGame.Cell.X;
            game.mat[1, 1] = TicTacToe.TicTacToeGame.Cell.X;

            Assert.AreEqual(true, game.setMove(2, 2, TicTacToe.TicTacToeGame.Cell.X));
            Assert.AreEqual(TicTacToe.TicTacToeGame.Cell.X, game.IsGameOver);
        }

        [TestMethod]
        public void Test_ODiagonalWin_Success()
        {
            TicTacToe.TicTacToeGame game = new TicTacToe.TicTacToeGame();
            TicTacToe.TicTacToeGame.Cell[,] mat = new TicTacToe.TicTacToeGame.Cell[3, 3];
            game.mat[2, 0] = TicTacToe.TicTacToeGame.Cell.O;
            game.mat[1, 1] = TicTacToe.TicTacToeGame.Cell.O;

            Assert.AreEqual(true, game.setMove(0, 2, TicTacToe.TicTacToeGame.Cell.O));
            Assert.AreEqual(TicTacToe.TicTacToeGame.Cell.O, game.IsGameOver);
        }

        [TestMethod]
        public void Test_Tie_Success()
        {
            TicTacToe.TicTacToeGame game = new TicTacToe.TicTacToeGame();
            TicTacToe.TicTacToeGame.Cell[,] mat = new TicTacToe.TicTacToeGame.Cell[3, 3];
            game.mat[0, 0] = TicTacToe.TicTacToeGame.Cell.O;
            game.mat[1, 0] = TicTacToe.TicTacToeGame.Cell.O;
            game.mat[2, 0] = TicTacToe.TicTacToeGame.Cell.X;
            game.mat[0, 1] = TicTacToe.TicTacToeGame.Cell.X;
            game.mat[1, 1] = TicTacToe.TicTacToeGame.Cell.X;
            game.mat[2, 1] = TicTacToe.TicTacToeGame.Cell.O;
            game.mat[0, 0] = TicTacToe.TicTacToeGame.Cell.O;
            game.mat[1, 0] = TicTacToe.TicTacToeGame.Cell.X;
            game.num = 8;
            Assert.AreEqual(true, game.setMove(2, 2, TicTacToe.TicTacToeGame.Cell.X));
            Assert.AreEqual(TicTacToe.TicTacToeGame.Cell.draw, game.IsGameOver);
        }
    }
}
