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

namespace MinesweeperOutput
{
    public partial class MinesweeperWindow : Form, Minesweeper.IGameControl
    {
        // Temp variables
        const short width = 16;
        const short height = 16;
        const int mineCount = 1;
        const int buttonSize = 25;

        private bool flaggingMode;
        private MinesweeperGameInstance gameInstance;
        private int minesLeft;
        private Timer timer;

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
            if (this.Height < 175) { this.Height = 175; }

            Debug.Write($"{Width}{Height}\n");

            gridControls.Location = new Point(50, 100);
            gridControls.ColumnCount = width;
            gridControls.RowCount = height;
            gridControls.Width = width * buttonSize;
            gridControls.Height = height * buttonSize;
            gridControls.Padding = new Padding(0);
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
                    var button = new Button
                    {
                        Name = ($"Tile_{j}{i}"),
                        Dock = DockStyle.Fill,
                        Width = buttonSize,
                        Height = buttonSize,
                        Margin = new Padding(0),
                        FlatStyle = FlatStyle.Flat
                    };
                    gridControls.Controls.Add(button, j, i);
                }
            }
            foreach (Control c in gridControls.Controls)
            {
                c.Click += new EventHandler(this.GridTile_Click);
            }

            minesLeft = mineCount;
            mineCounter.Text = minesLeft.ToString();

            clockDisplay.Text = 0.ToString();
            timer = new Timer
            {
                Interval = 500
            };
            timer.Tick += new EventHandler(Timer_Tick);

            gameInstance = new MinesweeperGameInstance(this, new GameParameters(width, height, mineCount, ""));
            timer.Start();
            this.Show();
            DebugDisplayGrid(gameInstance.grid);
            gameInstance.StartGame();
        }

        public bool GetFlaggingMode() { return flaggingMode; }
        public void ToggleFlaggingMode() { flaggingMode = !flaggingMode; }
        public int GetMinesLeft() { return minesLeft; }
        public void SetMinesLeft(int mines) { minesLeft = mines; }

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
            mineCounter.Text = minesLeft.ToString();
        }
        private void SetButtonImage(int column, int row, Image image)
        {
            gridControls.GetControlFromPosition(column, row).BackgroundImage = image;
        }
        private void DebugDisplayGrid(GridTile[,] grid)
        {
            Debug.Write($"Size:{Width} by {height}\nNumber of mines:{mineCount}\nGrid seed:{gameInstance.gameParameters.gameSeed}\n");
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
        public void DisplayResultsScreen(GameState endState, long timeTaken, Position lastClear)
        {
            new GameOverDialogue(endState, timeTaken, lastClear).ShowDialog();
            this.Close();
        }
        private void SendInput(Position selectedPosition)
        {
            gameInstance.TakeTurn(selectedPosition);

            if (gameInstance.GetGameState() != GameState.Running)
            {
                DisplayResultsScreen(gameInstance.GetGameState(), gameInstance.GetClockMs(), gameInstance.GetLastSelectedTile());
            }
        }
        private void GridTile_Click(object sender, EventArgs e)
        {
            Position clickedPosition = new Position()
            {
                xPosition = (short)gridControls.GetColumn((Control)sender),
                yPosition = (short)gridControls.GetRow((Control)sender)
            };
            SendInput(clickedPosition);
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            clockDisplay.Text = (gameInstance.GetClockMs() / 1000).ToString();
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