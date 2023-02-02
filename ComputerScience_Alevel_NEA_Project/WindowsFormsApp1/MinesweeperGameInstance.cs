using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Minesweeper
{
    class MinesweeperGameInstance
    {
        private IGameControl gameController;
        /*private*/ public GridTile[,] grid;
        private GameState gameState;
        /*private*/ public GameParameters gameParameters;
        private Stopwatch stopwatch;
        private bool hitMine;
        private bool gridClear;

        public MinesweeperGameInstance(IGameControl gameController, GameParameters gameParameters)
        {
            this.gameController = gameController;
            this.gameParameters = gameParameters;
            stopwatch = new Stopwatch();
            grid = GridGenerator.GenerateGrid(gameParameters);
        }

        public GameState GetGameState() { return gameState; }
        public long GetClockMs() { return stopwatch.ElapsedMilliseconds; }

        public void StartGame()
        {
            stopwatch.Start();
            hitMine = false;
            gameState = GameState.Running;
            gameController.DisplayGrid(grid);
        }

        public void TakeTurn(Position selectedTile)
        {
            if (gameController.GetFlaggingMode())
            {
                grid[selectedTile.xPosition, selectedTile.yPosition].isFlagged = !grid[selectedTile.xPosition, selectedTile.yPosition].isFlagged;
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
            gameController.DisplayGrid(grid);
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

            if (grid[position.xPosition, position.yPosition].hasMine)
            {
                hitMine = true;
                return; 
            }

            if (grid[position.xPosition, position.yPosition].adjacentMineCount == 0)
            {
                for (int y = -1; y <= 1; y++)
                {
                    for (int x = -1; x <= 1; x++)
                    {
                        ClearTile(new Position(){ 
                                        xPosition = (short)(position.xPosition + x), 
                                        yPosition = (short)(position.yPosition + y)});
                    }
                }
            }
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