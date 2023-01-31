using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeperGame
{
    interface IGameControl
    {
        public bool GetFlaggingMode();
        public bool ToggleFlaggingMode();
        public abstract Position SelectTile();
        public abstract void DisplayGrid(GridTile[,] grid);
        public abstract void DisplayResultsScreen(GameState endState, long timeTaken);
    }

    class CommandLineInterface : IGameControl
    {
        private bool flaggingMode;
        public void DisplayGrid(GridTile[,] grid)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                for (int x = 0; x < grid.GetLength(0); x++)
                {
                    if (!grid[x,y].isUncovered && false)
                    {
                        Console.Write("X");
                    }
                    else if (grid[x,y].hasMine)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(grid[x, y].adjacentMineCount);
                    }
                }
                Console.Write("\n");
            }
            Console.Write("\n");
        }

        public void DisplayResultsScreen(GameState endState, long timeTaken)
        {
            throw new NotImplementedException();
        }

        public bool GetFlaggingMode()
        {
            throw new NotImplementedException();
        }

        public Position SelectTile()
        {
            throw new NotImplementedException();
        }

        public bool ToggleFlaggingMode()
        {
            throw new NotImplementedException();
        }
    }
}