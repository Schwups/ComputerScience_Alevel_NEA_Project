using MinesweeperGame.SupportComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Output
{
    namespace MinesweeperOutput
    {
        // Class handling the display of the game over window
        // Has a label telling the player the result of the game, 
        // a label displaying the time taken and a button to return to the main menu
        public partial class GameOverDialogue : Form
        {
            private GameState endState;
            private long timeTaken;
            private Position lastTileSelected;
            public GameOverDialogue(GameState endState, long timeTaken, Position lastTileSelected)
            {
                InitializeComponent();
                this.endState = endState;
                this.timeTaken = timeTaken;
                this.lastTileSelected = lastTileSelected;
            }
            protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);

                // Sets the result text depending on the ending result of the game
                if (endState == GameState.Won)
                {
                    endMessage.Text = "Congratulations!\nYou cleared all the mines!";
                }
                else
                {
                    endMessage.Text = $"Oh no!\nYou hit a mine at tile ({lastTileSelected.xPosition + 1},{lastTileSelected.yPosition + 1})";
                }

                endTime.Text = (timeTaken / 1000).ToString() + " Seconds.";
            }

            private void contineButton_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void GameOverDialogue_Load(object sender, EventArgs e)
            {

            }
        }
    }
}