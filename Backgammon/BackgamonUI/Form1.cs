using Backgammon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackgamonUI
{
    public partial class Form1 : Form
    {
        Game game;
        int choice = -1;
        theGameDetails gameDetails;
        public Form1()
        {
            InitializeComponent();
            addNewGame();


        }
        internal void addNewGame()
        {
            game = new Game();
            gameDetails = new theGameDetails(game);
            drawButtons();
            DisableButtons();

        }

        private void drawButtons()
        {
            for (int i = 0; i < 24; i++)
            {
                if (game.board.SpotsOnBoard[i].color == Backgammon.Color.color.white)
                {
                    buttons[i].BackColor = System.Drawing.Color.White;
                    buttons[i].Text = $"{game.board.SpotsOnBoard[i].numberOfTiles}";
                }
                if (game.board.SpotsOnBoard[i].color == Backgammon.Color.color.black)
                {
                    buttons[i].BackColor = System.Drawing.Color.Brown;
                    buttons[i].Text = $"{game.board.SpotsOnBoard[i].numberOfTiles}";
                }

            }
        }


        private void clickToRoll(object sender, EventArgs e)
        {
            Cubes currentCubes = game.getCubes();
            labels[3].Text = $"{currentCubes.cube1},{currentCubes.cube2}";
            ((Button)sender).Enabled = false;
            labels[1].Text = game.getCurrentColorString();
            if(game.getAllThePossabilities() == false)
            {
                buttons[27].Enabled = true;
                game.getWinner();
                return;
            }
            enableAllTheStartOptions();

        }

        private void enableAllTheStartOptions()
        {
            List<int> startButtons = game.getAllStartPoints();
            DisableButtons();
            for (int i = 0; i < 27; i++)
            {
                if (startButtons.Contains(i))
                    buttons[i].Enabled = true;
            }
        }

        private void DisableButtons()
        {
            for (int i = 0; i< 27; i++)
                buttons[i].Enabled = false;
        }


    public void button_Click(Object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if(choice == -1)
            {
                choice = button.TabIndex;
                List<int> startButtons = game.getAllEndPoints(choice);
                DisableButtons();
                for (int i = 0; i < 27; i++)
                {
                    if (startButtons.Contains(i))
                        buttons[i].Enabled = true;
                }
                return;
            }
            if (choice != button.TabIndex)
            {
                if(!gameDetails.makeAPlay(choice, button.TabIndex))
                    buttons[27].Enabled = true;
            }
            drawFromToButtons(choice, button.TabIndex);
            choice = -1;
            DisableButtons();
            enableAllTheStartOptions();
            
        }

        private void drawFromToButtons(int start, int finish)
        {
            if (start<24)
            {
                if (game.board.SpotsOnBoard[start].color == Backgammon.Color.color.empty)
                {
                    buttons[start].BackColor = default(System.Drawing.Color);
                    buttons[start].UseVisualStyleBackColor = true;
                    buttons[start].Text = "";
                }
                else
                {
                    buttons[start].Text = game.board.SpotsOnBoard[start].numberOfTiles != 0 ? $"{game.board.SpotsOnBoard[start].numberOfTiles}" : "";
                }
            }
            buttons[24].Text = $"black jail = {game.getNumberOfBlackJailTiles()}";
            buttons[25].Text = $"white jail = {game.getNumberOfWhiteJailTiles()}";
            if (finish != 26)
            {
                buttons[finish].BackColor = (((int)game.board.SpotsOnBoard[finish].color == 0) ? System.Drawing.Color.White : System.Drawing.Color.Brown);

                buttons[finish].Text = $"{game.board.SpotsOnBoard[finish].numberOfTiles}";
            }
        }
    }
}
