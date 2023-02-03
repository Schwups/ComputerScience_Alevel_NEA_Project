using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Minesweeper
{
    public interface IGameControl
    {
        bool GetFlaggingMode();
        void ToggleFlaggingMode();
        void DisplayGrid(GridTile[,] grid);
        void DisplayResultsScreen(GameState endState, long timeTaken, Position lastClear);
        int GetMinesLeft();
        void SetMinesLeft(int mines);
    }

    public class AiControlInterface : IGameControl
    {
        // The purpose of this class is to ensure that the ai isnt able to cheat by looking at where the mines are
        // and instead will just receive an array containing only the information a human player would have
        public void DisplayGrid(GridTile[,] grid)
        {
            //throw new NotImplementedException();
            byte[,] outputGrid = new byte[grid.GetLength(0), grid.GetLength(1)];
            for (int y = 0; y < outputGrid.GetLength(1); y++)
            {
                for (int x = 0; x < outputGrid.GetLength(0); x++)
                {
                    if (grid[x,y].isUncovered)
                    {
                        outputGrid[x, y] = grid[x, y].adjacentMineCount;
                    }
                    else
                    {
                        outputGrid[x, y] = byte.MaxValue;
                    }
                }
            }
        }

        public void DisplayResultsScreen(GameState endState, long timeTaken, Position lastClear)
        {
            throw new NotImplementedException();
        }

        public bool GetFlaggingMode()
        {
            throw new NotImplementedException();
        }

        public int GetMinesLeft()
        {
            throw new NotImplementedException();
        }

        public void SetMinesLeft(int mines)
        {
            throw new NotImplementedException();
        }

        public void ToggleFlaggingMode()
        {
            throw new NotImplementedException();
        }
    }
}