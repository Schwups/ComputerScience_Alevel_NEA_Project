using Minesweeper;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinesweeperWindow
{
    public partial class MinesweeperWindow : Form, Minesweeper.IGameControl
    {
        // Temp variables
        const short width = 30;
        const short height = 16;
        const int mineCount = 40;
        const int buttonSize = 24;

        private bool flaggingMode;
        private MinesweeperGameInstance gameInstance;
        private int minesLeft;

        public MinesweeperWindow()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.Width = (width * (buttonSize + 1)) + 100;
            if (this.Width < 450) { this.Width = 450; }
            this.Height = (height * (buttonSize + 1)) + 175;

            Debug.Write($"{Width}{Height}\n");

            gridControls.Location = new Point(50, 100);
            gridControls.ColumnCount = width;
            gridControls.RowCount = height;
            gridControls.Padding = new Padding(0);
            gridControls.Width = width * buttonSize;
            gridControls.Height = height * buttonSize;
            gridControls.ColumnStyles.Clear();
            for (int i = 0; i < width; i++)
            {
                gridControls.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, width / 100));
            }
            gridControls.RowStyles.Clear();
            for (int i = 0; i < height; i++)
            {
                gridControls.RowStyles.Add(new RowStyle(SizeType.Percent, height / 100));
            }
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    var button = new Button();
                    button.Name = ($"Tile_{j}{i}");
                    button.Dock = DockStyle.Fill;
                    button.Width = buttonSize;
                    button.Height = buttonSize;
                    button.Margin = new Padding(0);
                    gridControls.Controls.Add(button, j, i);
                }
            }
            foreach (Control c in gridControls.Controls)
            {
                c.Click += new EventHandler(this.GridTile_Click);
            }

            minesLeft = mineCount;
            mineCounter.Text = mineCount.ToString();

            this.Show();
            gameInstance = new MinesweeperGameInstance(this, new GameParameters(width, height, mineCount, ""));
            Debug.WriteIf(gameInstance.grid == null, "Grid is null\n");
            DebugDisplayGrid(gameInstance.grid);
            gameInstance.StartGame();
        }

        public void DisplayGrid(GridTile[,] grid)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                for (int x = 0; x < grid.GetLength(0); x++)
                {
                    if (!grid[x, y].isUncovered)
                    {
                        if (grid[x,y].isFlagged)
                        {
                            SetButtonImage(x, y, Resources.FlaggedTile);
                        }
                        else
                        {
                            SetButtonImage(x, y, Resources.HiddenTile);
                        }
                    }
                    else if (grid[x, y].hasMine)
                    {
                        SetButtonImage(x, y, Resources.MineTile);
                    }
                    else
                    {
                        switch (grid[x,y].adjacentMineCount)
                        {
                            case 0:
                                SetButtonImage(x, y, Resources.Tile0);
                                break;
                            case 1:
                                SetButtonImage(x, y, Resources.Tile1);
                                break;
                            case 2:
                                SetButtonImage(x, y, Resources.Tile2);
                                break;
                            case 3:
                                SetButtonImage(x, y, Resources.Tile3);
                                break;
                            case 4:
                                SetButtonImage(x, y, Resources.Tile4);
                                break;
                            case 5:
                                SetButtonImage(x, y, Resources.Tile5);
                                break;
                            case 6:
                                SetButtonImage(x, y, Resources.Tile6);
                                break;
                            case 7:
                                SetButtonImage(x, y, Resources.Tile7);
                                break;
                            case 8:
                                SetButtonImage(x, y, Resources.Tile8);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        private void SetButtonImage(int column, int row, Image image)
        {
            gridControls.GetControlFromPosition(column, row).BackgroundImage = image;
        }

        private void DebugDisplayGrid(GridTile[,] grid)
        {
            Debug.Write($"Grid seed:{gameInstance.gameParameters.gameSeed}\n");
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                for (int x = 0; x < grid.GetLength(0); x++)
                {
                    Debug.Write(grid[x, y].hasMine ? "M" : grid[x, y].adjacentMineCount.ToString());
                }
                Debug.Write("\n");
            }
            Debug.Write("\n");
        }

        public void DisplayResultsScreen(GameState endState, long timeTaken)
        {
            throw new NotImplementedException();
        }

        public bool GetFlaggingMode() { return flaggingMode; }
        public void ToggleFlaggingMode() { flaggingMode = !flaggingMode; }

        private void GridTile_Click(object sender, EventArgs e)
        {
            Position clickedPosition = new Position(){
                                            xPosition = (short)gridControls.GetColumn((Control)sender),
                                            yPosition = (short)gridControls.GetRow((Control)sender) };
            SendInput(clickedPosition);
        }

        private void SendInput(Position selectedPosition)
        {
            gameInstance.TakeTurn(selectedPosition);

            if (gameInstance.GetGameState() != GameState.Running)
            {
                DisplayResultsScreen(gameInstance.GetGameState(), gameInstance.GetClockMs());
                this.Close();
            }
        }

        private void flaggingModeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            flaggingMode = flaggingModeCheckBox.Checked;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Space)
            {
                flaggingModeCheckBox.Checked = !flaggingModeCheckBox.Checked;
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}