using Minesweeper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinesweeperOutput
{
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
            if (endState == GameState.Won)
            {
                endMessage.Text = "Congratulations!\nYou cleared all the mines!";
            }
            else
            {
                endMessage.Text = $"You fucking suck\nYou hit a mine at tile ({lastTileSelected.xPosition + 1},{lastTileSelected.yPosition + 1})";
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
