using MinesweeperGame.SupportComponents;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinesweeperGame
{
    namespace MinesweeperGridGenerator
    {
        public class GridGenerator
        {
            static public GridTile[,] GenerateGrid(GameParameters gameParameters)
            {
                short width = gameParameters.width;
                short height = gameParameters.height;
                int mineCount = gameParameters.mineCount;
                string gameSeed = gameParameters.gameSeed;

                // Test to ensure all entered parameters are valid, if they arent throw an error explaining the issue
                if (width <= 0 || height <= 0)
                {
                    throw new ArgumentException($"Grid dimensions {width} by {height} are invalid, both values must be greater than zero");
                }
                if (mineCount <= 0)
                {
                    throw new ArgumentException($"invalid mineCount:{mineCount}, must be greater than zero");
                }
                if (mineCount > (width - 1) * (height - 1))
                {
                    throw new ArgumentException($"invalid mineCount:{mineCount}, must be less than {(width - 1) * (height - 1)} for the selected grid size");
                }

                // Check if a game seed is provided to the generator, if the input property is null then generate a new random game seed
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
                GenerateTiles();
                AddMines();
                return grid;

                void GenerateTiles()
                {
                    // 2D array itterator that instantiates a grid tile 
                    // object at every location within the grid
                    for (int y = 0; y < grid.GetLength(1); y++)
                    {
                        for (int x = 0; x < grid.GetLength(0); x++)
                        {
                            grid[x, y] = new GridTile();
                        }
                    }
                }

                void AddMines()
                {
                    // Add mines to the grid
                    for (int i = 0; i < mineCount; i++)
                    {
                        bool validPosition = false;
                        Position pos;
                        do
                        {
                            // Generate random position, if the position does not already contain
                            // a mine then place the mine and increment the adjacentMineCount
                            // variable of the surrounding tiles
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
                    // 2D array itterator that visits every tile in a 3 by 3 
                    // area centred on the input position and increments their
                    // adjacentMineCount variables
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
}