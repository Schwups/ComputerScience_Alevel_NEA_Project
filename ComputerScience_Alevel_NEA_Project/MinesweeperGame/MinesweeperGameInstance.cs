using MinesweeperGame.SupportComponents;
using MinesweeperGame.GameControl;
using MinesweeperGame.MinesweeperGridGenerator;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MinesweeperGame
{
    namespace MinesweeperGameLogic
    {
        public class MinesweeperGameInstance
        {
            private bool hitMine;
            private bool gridClear;
            private bool firstTurn;
            private GameState gameState;
            private GameParameters gameParameters;
            private Position lastSelectedTile;
            private IGameControl gameController;
            private GridTile[,] grid;
            private Stopwatch stopwatch;
            private List<GridTile> changedTiles;
            public MinesweeperGameInstance(IGameControl gameController, GameParameters gameParameters)
            {
                this.gameController = gameController;
                this.gameParameters = gameParameters;
                stopwatch = new Stopwatch();
                try
                {
                    grid = GridGenerator.GenerateGrid(gameParameters);
                }
                catch (ArgumentException ex)
                {
                    throw ex;
                }
            }

            public GameState GetGameState() { return gameState; }
            public long GetClockMs() { return stopwatch.ElapsedMilliseconds; }
            public Position GetLastSelectedTile() { return lastSelectedTile; }

            public void StartGame()
            {
                hitMine = false;
                firstTurn = true;
                changedTiles = new List<GridTile>();
                gameState = GameState.Running;
                stopwatch.Start();
                gameController.DisplayGrid(grid, true);
            }

            public void TakeTurn(Position selectedTile)
            {
                foreach (GridTile tile in changedTiles)
                {
                    tile.hasChanged = false;
                }
                changedTiles.Clear();
                lastSelectedTile = selectedTile;
                if (selectedTile.xPosition < 0 || selectedTile.xPosition >= grid.GetLength(0)
                || selectedTile.yPosition < 0 || selectedTile.yPosition >= grid.GetLength(1))
                {
                    throw new ArgumentException($"Invalid location, position ({selectedTile.xPosition},{selectedTile.yPosition} is not on grid)");
                }
                if (gameController.GetFlaggingMode())
                {
                    grid[selectedTile.xPosition, selectedTile.yPosition].hasChanged = true;
                    changedTiles.Add(grid[selectedTile.xPosition, selectedTile.yPosition]);
                    if (grid[selectedTile.xPosition, selectedTile.yPosition].isFlagged)
                    {
                        grid[selectedTile.xPosition, selectedTile.yPosition].isFlagged = false;
                        gameController.SetMinesLeft(gameController.GetMinesLeft() + 1);
                    }
                    else
                    {
                        grid[selectedTile.xPosition, selectedTile.yPosition].isFlagged = true;
                        gameController.SetMinesLeft(gameController.GetMinesLeft() - 1);
                    }
                }
                else
                {
                    ClearTile(selectedTile);
                    gridClear = CheckIfGridClear();
                }

                if (hitMine)
                {
                    gameState = GameState.Lost;
                }
                else if (gridClear)
                {
                    gameState = GameState.Won;
                }

                if (gameState != GameState.Running)
                {
                    stopwatch.Stop();
                }
                firstTurn = false;
                gameController.DisplayGrid(grid, false);
            }

            void ClearTile(Position position)
            {
                if (position.xPosition < 0 || grid.GetLength(0) <= position.xPosition ||
                    position.yPosition < 0 || grid.GetLength(1) <= position.yPosition)
                {
                    return;
                }

                if (grid[position.xPosition, position.yPosition].isUncovered)
                {
                    return;
                }
                grid[position.xPosition, position.yPosition].isUncovered = true;
                grid[position.xPosition, position.yPosition].hasChanged = true;
                changedTiles.Add(grid[position.xPosition, position.yPosition]);

                if (grid[position.xPosition, position.yPosition].hasMine)
                {
                    if (!firstTurn)
                    {
                        hitMine = true;
                        return;
                    }
                    grid[position.xPosition, position.yPosition].hasMine = false;
                    MoveMineToTopLeft();
                    return;
                }

                if (grid[position.xPosition, position.yPosition].adjacentMineCount == 0)
                {
                    for (int y = -1; y <= 1; y++)
                    {
                        for (int x = -1; x <= 1; x++)
                        {
                            ClearTile(new Position()
                            {
                                xPosition = (short)(position.xPosition + x),
                                yPosition = (short)(position.yPosition + y)
                            });
                        }
                    }
                }
            }

            void MoveMineToTopLeft()
            {
                int xcount = 0;
                int ycount = 0;
                bool success = false;
                do
                {
                    if (!grid[xcount,ycount].hasMine)
                    {
                        grid[xcount, ycount].hasMine = true;
                        success = true;
                    }
                    xcount++;
                    if (xcount > grid.GetLength(0) - 1)
                    {
                        xcount = 0;
                        ycount++;
                    }
                    Debug.Assert(ycount < grid.GetLength(1), "Error when moving mine to top left corner, no valid placement found");
                } while (!success);
            }

            bool CheckIfGridClear()
            {
                int unclearedTiles = 0;
                foreach (GridTile T in grid)
                {
                    if (T.isUncovered)
                    {
                        continue;
                    }
                    unclearedTiles++;

                    if (gameParameters.mineCount < unclearedTiles)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}