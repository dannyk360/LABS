using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon
{
    public class Game
    {
        public Board board { get; set; }
        private Player player1, player2;
        private Color color;
        private Color.color isThereAWinner;
        private List<OneStep> Possabilitiesleft;
        private Cubes cubes;
        public Game()
        {
            player1 = new Player(Color.color.white);
            player2 = new Player(Color.color.black);
            board = new Board();
            color = new Color();
            isThereAWinner = Color.color.empty;
        }
        public Cubes getCubes()
        {
            cubes = new Cubes();
            cubes.getNewCubes();
            return cubes;
        }
        public string getCurrentColorString()
        {
            return (color.currentColor == Color.color.white) ? "white" : "black"; 
        }
        public string getWinnerColorString()
        {
            return (color.currentColor == Color.color.white) ? "black" : "white";
        }

        public bool getAllThePossabilities()
        {
            return callStartNextTurn((color.currentColor == Color.color.white) ? player1 : player2);
 

        }

        private bool callStartNextTurn(Player player)
        {
            Possabilitiesleft = (Turn.StartNextTurn(cubes, color, player, board));
            return Possabilitiesleft.Count != 0;
        }
        
        public bool doTheTurn(OneStep thisTurn)
        {
            var currentPlayer = (color.currentColor == Color.color.white) ? player1 : player2;
            var Opponent = (currentPlayer == player1) ? player2 : player1;
            Possabilitiesleft = Turn.excecuteTheTurn(thisTurn, Possabilitiesleft, color, currentPlayer, Opponent, board);
            if (Possabilitiesleft.Count == 0)
                return false;
            return true;
        }

        public Color.color getWinner()
        {
            var currentPlayer = (color.currentColor == Color.color.white) ? player1 : player2;
            color.ChangeColor(); 
            return (currentPlayer.NumberOfTilesGotOut == 15) ? color.currentColor : Color.color.empty;
            }

        public List<int> getAllStartPoints()
        {
            List<int> startPossabilities = new List<int>();
            foreach (var possability in Possabilitiesleft)
            {
                startPossabilities.Add(possability._from);
            }
            return startPossabilities;
            

        }

        public List<int> getAllEndPoints(int choice)
        {
            var startPossabilities = (from possability in Possabilitiesleft
                                 where possability._from == choice
                                 select possability._to).ToList();
            startPossabilities.Add(choice);
            return startPossabilities;
        }

        public int getNumberOfBlackJailTiles()
        {
            return board.getNumberOfTiles(Color.color.black);
        }

        public int getNumberOfWhiteJailTiles()
        {
            return board.getNumberOfTiles(Color.color.white);
        }
    }
}
