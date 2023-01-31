using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeperGame
{
    abstract class GameControl
    {
        public bool flaggingMode { get; protected set; }
        public abstract Position SelectTile();
        public abstract void DisplayGrid(GridTile[,] grid);
        public abstract void DisplayResultsScreen(GameState endState, long timeTaken);
    }

    class CommandLineInterface : GameControl
    {
        public override void DisplayGrid(GridTile[,] grid)
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

        public override void DisplayResultsScreen(GameState endState, long timeTaken)
        {
            throw new NotImplementedException();
        }
        public override Position SelectTile()
        {
            throw new NotImplementedException();
        }
    }
}