using MinesweeperGame.GameControl;
using MinesweeperGame.SupportComponents;
using MinesweeperGame.MinesweeperGameLogic;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperAI
{
    public class AI : IGameControl
    {
        private GameParameters gameParameters;
        private MinesweeperGameInstance gameInstance;
        private Random random;
        private SimpleGridTile[,] internalGrid;

        public GameState GetGameState() { return gameInstance.GetGameState(); }

        public AI(GameParameters gameParameters)
        {
            this.gameParameters = gameParameters;
            gameInstance = new MinesweeperGameInstance(this, gameParameters);
            random = new Random();
            gameInstance.StartGame();
        }
        #region IGameControl support
        public void DisplayGrid(GridTile[,] grid)
        {
            //throw new NotImplementedException();
            internalGrid = new SimpleGridTile[grid.GetLength(0),grid.GetLength(1)];
            for (int y = 0; y < internalGrid.GetLength(1); y++)
            {
                for (int x = 0; x < internalGrid.GetLength(0); x++)
                {
                    internalGrid[x, y].isUncovered = grid[x, y].isUncovered;
                    if (grid[x, y].isUncovered)
                    {
                        internalGrid[x, y].adjacentMineCount = grid[x, y].adjacentMineCount;
                    }
                    else
                    {
                        internalGrid[x, y].adjacentMineCount = byte.MaxValue;
                    }
                }
            }
        }
        public void DisplayResultsScreen(GameState endState, long timeTaken, Position lastClear)
        {
            throw new NotImplementedException();
        }
        public bool GetFlaggingMode() // The AI has no need to flag tiles so this method always returns false
        {
            return false;
        }
        public int GetMinesLeft()
        {
            throw new NotImplementedException();
        }
        public void SetMinesLeft(int mines)
        {
            throw new NotImplementedException();
        }
        public void TakeTurn(Position selectedPosition)
        {
            throw new NotImplementedException();
        }
        public void ToggleFlaggingMode()
        {
            //throw new NotImplementedException();
        }
        #endregion

        public void TakeTurn()
        {
            gameInstance.TakeTurn(RandomGuess(false));
        }

        private Position RandomGuess(bool firstGuess)
        {
            // Guess corners first
            Debug.Write("AI Guessing Tile:");
            int hiddenCorners = 0;
            if (firstGuess)
            {
                if (!internalGrid[0, 0].isUncovered)
                {
                    hiddenCorners += (internalGrid[0, 0].isUncovered ? 1 : 0);
                }
                if (!internalGrid[internalGrid.GetLength(0) - 1, 0].isUncovered)
                {
                    hiddenCorners += (internalGrid[internalGrid.GetLength(0) - 1, 0].isUncovered ? 1 : 0);
                }
                if (!internalGrid[0, internalGrid.GetLength(1) - 1].isUncovered)
                {
                    hiddenCorners += (internalGrid[0, internalGrid.GetLength(1) - 1].isUncovered ? 1 : 0);
                }
                if (!internalGrid[internalGrid.GetLength(0) - 1, internalGrid.GetLength(1) - 1].isUncovered)
                {
                    hiddenCorners += (internalGrid[internalGrid.GetLength(0) - 1, internalGrid.GetLength(1) - 1].isUncovered ? 1 : 0);
                }
            }
            if (hiddenCorners == 0) // If no corners are uncovered guess randomly
            {
                bool foundHiddenTile = false;
                Position randomPosition = new Position();
                do
                {
                    randomPosition.xPosition = (short)random.Next(0, internalGrid.GetLength(0));
                    randomPosition.yPosition = (short)random.Next(0, internalGrid.GetLength(1));
                    if (!internalGrid[randomPosition.xPosition, randomPosition.yPosition].isUncovered)
                    {
                        foundHiddenTile = true;
                    }
                } while (!foundHiddenTile);
                Debug.Write($"Complete guess:{randomPosition.xPosition},{randomPosition.yPosition}\n");
                return randomPosition;
            }
            bool foundHiddenCorner = false;
            Position randomCorner = new Position();
            do
            {
                switch (random.Next(0, 4))
                {
                    case 0:
                        randomCorner.xPosition = 0;
                        randomCorner.yPosition = 0;
                        break;
                    case 1:
                        randomCorner.xPosition = (short)internalGrid.GetLength(0);
                        randomCorner.yPosition = 0;
                        break;
                    case 2:
                        randomCorner.xPosition = 0;
                        randomCorner.yPosition = (short)internalGrid.GetLength(1);
                        break;
                    case 3:
                        randomCorner.xPosition = (short)internalGrid.GetLength(0);
                        randomCorner.yPosition = (short)internalGrid.GetLength(1);
                        break;
                }
                if (internalGrid[randomCorner.xPosition, randomCorner.yPosition].isUncovered)
                {
                    foundHiddenCorner = true;
                }
            } while (!foundHiddenCorner);
            Debug.Write($"Corner at:{randomCorner.xPosition},{randomCorner.yPosition}\n");
            return randomCorner;
        }

        private struct SimpleGridTile
        {
            public bool isUncovered;
            public byte adjacentMineCount;
        }
    }

}