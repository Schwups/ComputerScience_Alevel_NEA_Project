using MinesweeperGame.SupportComponents;
using MinesweeperGame.MinesweeperGameLogic;
using MinesweeperGame.GameControl;
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

namespace Output
{
    namespace MinesweeperOutput
    {
        // Class that handles the control of a minesweeper game instance
        public partial class MinesweeperWindow : Form, IGameControl
        {
            // Class properties
            private int minesLeft;
            private bool flaggingMode;
            private Timer timer;
            private TileImages tileImages = new TileImages();
            private MinesweeperGameInstance gameInstance;
            public long endTime { get; private set; }
            public Difficulty gameDifficulty { get; private set; }
            public GameState endState { get; private set; }
            public GameParameters gameParameters { get; private set; }

            // Property getters and setters
            public bool GetFlaggingMode() { return flaggingMode; }
            public void ToggleFlaggingMode() { flaggingMode = !flaggingMode; }
            public int GetMinesLeft() { return minesLeft; }
            public void SetMinesLeft(int mines) { minesLeft = mines; }

            // Constructor
            public MinesweeperWindow(GameParameters gameParameters)
            {
                // Initialises window and instantiates a MineSweeperGameInstance object
                Debug.IndentSize = 2;
                InitializeComponent();
                this.gameParameters = gameParameters;
                try
                {
                    gameInstance = new MinesweeperGameInstance(this, gameParameters);
                }
                catch (ArgumentException ex)
                {
                    throw ex;
                }
            }
            protected override void OnLoad(EventArgs e)
            {
                // Initialisation code for the game controls
                base.OnLoad(e);
                const int buttonSize = 25;

                // Sets form width and height
                this.Width = (gameParameters.width * (buttonSize + 1)) + 100;
                if (this.Width < 300) { this.Width = 300; }
                this.Height = (gameParameters.height * (buttonSize + 1)) + 175;
                if (this.Height < 175) { this.Height = 175; }

                // Initialisation code for the clickable grid
                #region gameGrid Setup
                // Set up of the grid button table layout panel 
                gridControls.Location = new Point(50, 100);
                gridControls.ColumnCount = gameParameters.width;
                gridControls.RowCount = gameParameters.height;
                gridControls.Height = gameParameters.height * buttonSize;
                gridControls.Width = gameParameters.width * buttonSize;
                if (gridControls.Width < 350)
                {
                    gridControls.Location = new Point((this.Width - gridControls.Width) / 2 - gridControls.Margin.Left, 100); ;
                }
                gridControls.Padding = new Padding(0);
                gridControls.ColumnStyles.Clear();
                for (int i = 0; i < gameParameters.width; i++)
                {
                    gridControls.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, gameParameters.width / 100));
                }
                gridControls.RowStyles.Clear();
                for (int i = 0; i < gameParameters.height; i++)
                {
                    gridControls.RowStyles.Add(new RowStyle(SizeType.Percent, gameParameters.height / 100));
                }

                // Itterates through each tile on the grid and creates a new button
                for (int i = 0; i < gameParameters.height; i++)
                {
                    for (int j = 0; j < gameParameters.width; j++)
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
                // Adds a mouse click event handler for each of the grid buttons
                foreach (Control c in gridControls.Controls)
                {
                    c.MouseDown += new MouseEventHandler(this.GridTile_Click);
                }
                // I dont like using windows forms
                #endregion

                minesLeft = gameParameters.mineCount;
                mineCounter.Text = minesLeft.ToString();

                // Initialisation of the timer
                clockDisplay.Text = 0.ToString();
                timer = new Timer
                {
                    Interval = 500 // 500ms to ensure the clock dosent miss a second due to rounding from ms to seconds
                };
                timer.Tick += new EventHandler(Timer_Tick);

                // Starts timer and game
                timer.Start();
                gameInstance.StartGame();
            }

            // Code handling the updating of the display grid
            public void DisplayGrid(GridTile[,] grid, bool gameStart)
            {
                Debug.WriteIf(gameStart, $"\nGrid with seed {gameParameters.gameSeed}\n  ");
                Debug.Indent();

                // 2D array itterator that visits every tile on the game grid 
                // and updates the display grid to match the tiles state
                for (int y = 0; y < grid.GetLength(1); y++)
                {
                    for (int x = 0; x < grid.GetLength(0); x++)
                    {
                        Debug.WriteIf(gameStart, (grid[x, y].hasMine ? "*" : grid[x, y].adjacentMineCount.ToString()).PadRight(2));
                        if (!(grid[x,y].hasChanged || gameStart))
                        {
                            continue;
                        }
                        if (!grid[x, y].isUncovered)
                        {
                            if (grid[x, y].isFlagged)
                            {
                                SetButtonImage(x, y, tileImages.flaggedTile);
                            }
                            else
                            {
                                SetButtonImage(x, y, tileImages.hiddenTile);
                            }
                        }
                        else if (grid[x, y].hasMine)
                        {
                            SetButtonImage(x, y, tileImages.mineTile);
                        }
                        else
                        {
                            switch (grid[x, y].adjacentMineCount)
                            {
                                case 0:
                                    SetButtonImage(x, y, tileImages.tile0);
                                    break;
                                case 1:
                                    SetButtonImage(x, y, tileImages.tile1);
                                    break;
                                case 2:
                                    SetButtonImage(x, y, tileImages.tile2);
                                    break;
                                case 3:
                                    SetButtonImage(x, y, tileImages.tile3);
                                    break;
                                case 4:
                                    SetButtonImage(x, y, tileImages.tile4);
                                    break;
                                case 5:
                                    SetButtonImage(x, y, tileImages.tile5);
                                    break;
                                case 6:
                                    SetButtonImage(x, y, tileImages.tile6);
                                    break;
                                case 7:
                                    SetButtonImage(x, y, tileImages.tile7);
                                    break;
                                case 8:
                                    SetButtonImage(x, y, tileImages.tile8);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    Debug.WriteIf(gameStart, "\n  ");
                }
                Debug.Unindent();
                Debug.WriteIf(gameStart, "\n");
                mineCounter.Text = minesLeft.ToString();
            }
            private void SetButtonImage(int column, int row, Image image)
            {
                // Sets the image of the specified grid button to the input image
                gridControls.GetControlFromPosition(column, row).BackgroundImage = image;
            }
            public void DisplayResultsScreen(GameState endState, long timeTaken, Position lastClear)
            {
                // Creates and opens a game over screen
                endTime = timeTaken;
                this.endState = endState;
                GameOverDialogue gameOver = new GameOverDialogue(this.endState, endTime, lastClear);
                gameOver.ShowDialog();
                gameOver.Dispose();
                this.Close();
            }
            public void TakeTurn(Position selectedPosition)
            {
                gameInstance.TakeTurn(selectedPosition);
            }
            private void GridTile_Click(object sender, MouseEventArgs e)
            {
                // Event handler for mouse click events on the game grid
                switch (e.Button)
                {
                    // Sets the flagging mode based on which mouse button is pressed
                    case MouseButtons.Left:
                        flaggingMode = false;
                        break;
                    case MouseButtons.Right:
                        flaggingMode = true;
                        break;
                    default:
                        return;
                }
                Position clickedPosition = new Position()
                {
                    xPosition = (short)gridControls.GetColumn((Control)sender),
                    yPosition = (short)gridControls.GetRow((Control)sender)
                };
                TakeTurn(clickedPosition);
            }
            private void Timer_Tick(object sender, EventArgs e) 
            {
                // Event handler for timer to update the clock display every timer tick
                clockDisplay.Text = (gameInstance.GetClockMs() / 1000).ToString();
            }
            protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
            {
                // Event handler for keyboard keypress events
                return base.ProcessCmdKey(ref msg, keyData);
            }

            protected override void OnClosed(EventArgs e) 
            {
                // Runs on closing of game window, 
                // sets all grid images to null and disposes all controls
                base.OnClosed(e);
                for (int y = 0; y < gridControls.RowCount; y++)
                {
                    for (int x = 0; x < gridControls.ColumnCount; x++)
                    {
                        gridControls.GetControlFromPosition(x, y).BackgroundImage = null;
                    }
                }
                tileImages.Dispose();
                foreach (Control control in this.Controls)
                {
                    control.Dispose();
                };
            }

            // Class to hold all of the required tile images
            private class TileImages : IDisposable
            {
                public readonly Image emptyTile = Resources.EmptyTile;
                public readonly Image flaggedTile = Resources.FlaggedTile;
                public readonly Image hiddenTile = Resources.HiddenTile;
                public readonly Image mineTile = Resources.MineTile;
                public readonly Image tile0 = Resources.Tile0;
                public readonly Image tile1 = Resources.Tile1;
                public readonly Image tile2 = Resources.Tile2;
                public readonly Image tile3 = Resources.Tile3;
                public readonly Image tile4 = Resources.Tile4;
                public readonly Image tile5 = Resources.Tile5;
                public readonly Image tile6 = Resources.Tile6;
                public readonly Image tile7 = Resources.Tile7;
                public readonly Image tile8 = Resources.Tile8;

                #region IDisposable Support
                private bool disposedValue = false; // To detect redundant calls

                protected virtual void Dispose(bool disposing)
                {
                    if (!disposedValue)
                    {
                        if (disposing)
                        {
                            emptyTile.Dispose();
                            flaggedTile.Dispose();
                            mineTile.Dispose();
                            tile0.Dispose();
                            tile1.Dispose();
                            tile2.Dispose();
                            tile3.Dispose();
                            tile4.Dispose();
                            tile5.Dispose();
                            tile6.Dispose();
                            tile7.Dispose();
                            tile8.Dispose();
                        }

                        // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                        // TODO: set large fields to null.

                        disposedValue = true;
                    }
                }

                // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
                // ~TileImages()
                // {
                //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
                //   Dispose(false);
                // }

                // This code added to correctly implement the disposable pattern.
                public void Dispose()
                {
                    // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
                    Dispose(true);
                    // TODO: uncomment the following line if the finalizer is overridden above.
                    // GC.SuppressFinalize(this);
                }
                #endregion
            };
        }
    }
}