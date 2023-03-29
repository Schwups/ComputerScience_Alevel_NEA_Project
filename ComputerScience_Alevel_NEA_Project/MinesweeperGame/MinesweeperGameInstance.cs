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
            // Class properties
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

            // Constructor
            public MinesweeperGameInstance(IGameControl gameController, GameParameters gameParameters)
            {
                // Sets all local properties and generates a new 
                // minesweeper grid using the input game parameters
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

            // Property getters
            public GameState GetGameState() { return gameState; }
            public long GetClockMs() { return stopwatch.ElapsedMilliseconds; }
            public Position GetLastSelectedTile() { return lastSelectedTile; }

            public void StartGame()
            {
                // Initialised properties to the game start state, 
                // starts the stop watch and displays the grid
                hitMine = false;
                firstTurn = true;
                changedTiles = new List<GridTile>();
                gameState = GameState.Running;
                stopwatch.Start();
                gameController.DisplayGrid(grid, true);
            }

            public void TakeTurn(Position selectedTile)
            {
                // Recieves player input and if valid updates the selected tile accordingly
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
                UpdateTile(selectedTile);

                // Checks game over conditions and sets game state accordingly
                if (hitMine)
                {
                    gameState = GameState.Lost;
                }
                else if (gridClear)
                {
                    gameState = GameState.Won;
                }

                // Checks if game is still running, if not then display game over, if yes then update grid display
                if (gameState != GameState.Running)
                {
                    stopwatch.Stop();
                    gameController.DisplayResultsScreen(gameState, stopwatch.ElapsedMilliseconds, lastSelectedTile);
                }
                firstTurn = false;
                gameController.DisplayGrid(grid, false);
            }


            void UpdateTile(Position position)
            {
                if (grid[position.xPosition,position.yPosition].isUncovered)
                {
                    return;
                }

                // If flagging mode is set then flag selected tile else clear it
                if (gameController.GetFlaggingMode())
                {
                    Debug.Write($"Flagging tile:({position.xPosition},{position.yPosition})\n");
                    FlagTile(position);
                }
                else
                {
                    Debug.Write($"Clearing tile:({position.xPosition},{position.yPosition})\n");
                    ClearTile(position);
                    gridClear = CheckIfGridClear();
                }
            }
            void FlagTile(Position position)
            {
                // Flags tile as changed and adds it to changed tiles list.
                grid[position.xPosition, position.yPosition].hasChanged = true;
                changedTiles.Add(grid[position.xPosition, position.yPosition]);

                // Toggles the selected tiles isFlagged property and 
                // updates the number of mines thought to be left
                if (grid[position.xPosition, position.yPosition].isFlagged)
                {
                    grid[position.xPosition, position.yPosition].isFlagged = false;
                    gameController.SetMinesLeft(gameController.GetMinesLeft() + 1);
                }
                else
                {
                    grid[position.xPosition, position.yPosition].isFlagged = true;
                    gameController.SetMinesLeft(gameController.GetMinesLeft() - 1);
                }
            }
            void ClearTile(Position position)
            {
                // Checks to ensure tile is on grid and not already uncovered
                if (position.xPosition < 0 || grid.GetLength(0) <= position.xPosition ||
                    position.yPosition < 0 || grid.GetLength(1) <= position.yPosition)
                {
                    return;
                }
                if (grid[position.xPosition, position.yPosition].isUncovered)
                {
                    return;
                }

                // Updates all relevent tile properties
                grid[position.xPosition, position.yPosition].isUncovered = true;
                grid[position.xPosition, position.yPosition].isFlagged = false;
                grid[position.xPosition, position.yPosition].hasChanged = true;
                changedTiles.Add(grid[position.xPosition, position.yPosition]);

                // Checks to see if selected tile was a mine, if it is and its 
                // the first turn move the mine to the top left, else if it 
                // isnt the first turn set the hitMine flag to true
                if (grid[position.xPosition, position.yPosition].hasMine)
                {
                    if (!firstTurn)
                    {
                        hitMine = true;
                        return;
                    }
                    MoveMineToTopLeft(position);
                    return;
                }

                // If the selected tile has 0 mines surrounding it, itterate through all tiles in a 
                // 3 by 3 area centred around the tile and recursivley call the ClearTile method
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

            void MoveMineToTopLeft(Position mineLocation)
            {
                int xCount = 0;
                int yCount = 0;
                bool success = false;
                // Checks tiles starting at the top left until an empty tile is found
                do
                {
                    if (!grid[xCount,yCount].hasMine)
                    {
                        grid[xCount, yCount].hasMine = true;
                        grid[mineLocation.xPosition, mineLocation.yPosition].hasMine = false;
                        success = true;
                    }
                    else
                    {
                        xCount++;
                    }

                    if (xCount > grid.GetLength(0) - 1)
                    {
                        xCount = 0;
                        yCount++;
                    }
                    Debug.Assert(yCount < grid.GetLength(1), "Error when moving mine to top left corner, no valid placement found");
                } while (!success);

                // 2D array itterator that visits every tile in a 3 by 3 
                // area centred on the new location of the mine and 
                // increments their adjacentMineCount variables
                for (int yOffset = -1; yOffset <= 1; yOffset++)
                {
                    for (int xOffset = -1; xOffset <= 1; xOffset++)
                    {
                        if (xCount + xOffset < 0 || grid.GetLength(0) <= xCount + xOffset
                            || yCount + yOffset < 0 || grid.GetLength(1) <= yCount + yOffset)
                        {
                            continue;
                        }
                        grid[xCount + xOffset, yCount + yOffset].adjacentMineCount++;
                        grid[xCount + xOffset, yCount + yOffset].hasChanged = true;
                    }
                }

                // 2D array itterator that visits every tile in a 3 by 3 
                // area centred on the old location of the mine and 
                // decrements their adjacentMineCount variables
                for (int yOffset = -1; yOffset <= 1; yOffset++)
                {
                    for (int xOffset = -1; xOffset <= 1; xOffset++)
                    {
                        if (mineLocation.xPosition + xOffset < 0 || mineLocation.xPosition + xOffset >= grid.GetLength(0)
                            || mineLocation.yPosition + yOffset < 0 || mineLocation.yPosition + yOffset >= grid.GetLength(1))
                        {
                            continue;
                        }
                        grid[mineLocation.xPosition + xOffset, mineLocation.yPosition + yOffset].adjacentMineCount--;
                        grid[mineLocation.xPosition + xOffset, mineLocation.yPosition + yOffset].hasChanged = true;
                    }
                }
            }

            bool CheckIfGridClear()
            {
                // Itterate through all tiles on the game grid, if it is hidden increment the number of 
                // uncleared tiles. If the number of uncleared tiles is greater than the number of mines 
                // then the grid is not clear and return false.
                int unclearedTiles = 0;
                foreach (GridTile tile in grid)
                {
                    if (tile.isUncovered)
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