using SupportComponents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minesweeper
{
    public struct GridTile
    {
        public bool isUncovered;
        public bool isFlagged;
        public bool hasMine;
        public byte adjacentMineCount;
    }
    public class GridGenerator
    {
        static public GridTile[,] GenerateGrid(GameParameters gameParameters)
        {
            short width = gameParameters.width;
            short height = gameParameters.height;
            int mineCount = gameParameters.mineCount;
            string gameSeed = gameParameters.gameSeed;
            // Ensure valid size and mine number parameters are entered
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentException($"Grid dimensions {width} by {height} are invalid, both values must be greater than zero");
            }
            if (mineCount <= 0)
            {
                throw new ArgumentException($"invalid mineCount:{mineCount}, must be greater than zero");
            }
            if (mineCount > width*height)
            {
                throw new ArgumentException($"invalid mineCount:{mineCount}, must be less than total tile count");
            }

            // Set generator seed if entered or create random seed if none is supplied
            int generatorSeed;
            if (!string.IsNullOrEmpty(gameSeed))
            {
                try
                {
                    generatorSeed = Convert.ToInt32(gameSeed);
                }
                catch (FormatException fe)
                {
                    throw new ArgumentException("Invalid gameSeed entered", fe);
                }
            }
            else
            {
                Random _rnd = new Random();
                generatorSeed = _rnd.Next(int.MaxValue);
            }

            Random rnd = new Random(generatorSeed);
            GridTile[,] grid = new GridTile[width, height];
            HideGrid();
            AddMines();
            return grid;

            void HideGrid()
            {
                // Sets all tiles in grid to hidden
                for (int y = 0; y < grid.GetLength(1); y++)
                {
                    for (int x = 0; x < grid.GetLength(0); x++)
                    {
                        grid[x, y].isUncovered = false;
                    }
                }
            }
            void AddMines()
            {
                // Add all mines to grid
                for (int i = 0; i < mineCount; i++)
                {
                    bool validPosition = false;
                    Position pos;
                    do
                    {
                        pos.xPosition = (short)rnd.Next(grid.GetLength(0));
                        pos.yPosition = (short)rnd.Next(grid.GetLength(1));
                        if (grid[pos.xPosition, pos.yPosition].hasMine)
                        {
                            continue;
                        }

                        grid[pos.xPosition, pos.yPosition].hasMine = true;
                        IncrementAdjacentMineCount(pos);
                        validPosition = true;
                    } while (!validPosition);
                }
            }
            void IncrementAdjacentMineCount(Position pos)
            {
                // Itterates through all tiles within a 3x3 grid centered on the entered position and increments the adjacentMineCount variable
                for (int yOffset = -1; yOffset <= 1; yOffset++)
                {
                    for (int xOffset = -1; xOffset <= 1; xOffset++)
                    {
                        int xNew = pos.xPosition + xOffset;
                        int yNew = pos.yPosition + yOffset;
                        if (xNew >= 0 && xNew < grid.GetLength(0) && 
                            yNew >= 0 && yNew < grid.GetLength(1))
                        {
                            grid[xNew, yNew].adjacentMineCount++;
                        }
                    }
                }
            }
        }
    }
}