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
        private bool flaggingMode;
        private bool firstTurn;
        private bool moveTaken;
        private int minesLeft;
        private GameParameters gameParameters;
        /*private*/ public AiGridTile[,] internalGrid;
        private MinesweeperGameInstance gameInstance;
        private Random random;

        public GameState GetGameState() { return gameInstance.GetGameState(); }
        public bool GetFlaggingMode() { return flaggingMode; }
        public void ToggleFlaggingMode() { flaggingMode = !flaggingMode; }
        public int GetMinesLeft() { return minesLeft; }
        public void SetMinesLeft(int mines) { minesLeft = mines; }

        public AI(GameParameters gameParameters)
        {
            this.gameParameters = gameParameters;
            gameInstance = new MinesweeperGameInstance(this, gameParameters);
            internalGrid = new AiGridTile[gameInstance.grid.GetLength(0), gameInstance.grid.GetLength(1)];
            random = new Random();
            minesLeft = gameParameters.mineCount;
            firstTurn = true;
            gameInstance.StartGame();
        }

        private void InitialiseInternalGrid()
        {
            for (int y = 0; y < internalGrid.GetLength(1); y++)
            {
                for (int x = 0; x < internalGrid.GetLength(0); x++)
                {
                    internalGrid[x, y] = new AiGridTile();
                }
            }
        }

        #region IGameControl support
        public void DisplayGrid(GridTile[,] grid, bool gameStart)
        {
            //DebugDisplayGrid(grid, gameStart, false);
            // The AI will hook into the DisplayGrid method from the IGameControl interface to update its internal grid
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                for (int x = 0; x < grid.GetLength(0); x++)
                {
                    if (gameStart)
                    {
                        internalGrid[x, y] = new AiGridTile();
                        internalGrid[x, y].location = new Position() { xPosition = (short)x, yPosition = (short)y, };
                    }
                    if (!(grid[x,y].hasChanged || gameStart))
                    {
                        continue;
                    }

                    internalGrid[x, y].isUncovered = grid[x, y].isUncovered;
                    internalGrid[x, y].isFlagged = grid[x, y].isFlagged;
                    if (!grid[x, y].isUncovered)
                    {
                        // An unknown value is set to byte.MaxValue (0xFF/255) to provide a reference for the progam to check to see if it has any information within the property
                        internalGrid[x, y].adjacentMineCount = byte.MaxValue;
                        continue;
                    }
                    internalGrid[x, y].adjacentMineCount = grid[x, y].adjacentMineCount;

                    for (int relativeY = -1; relativeY < 1; relativeY++)
                    {
                        for (int relativeX = -1; relativeX < 1; relativeX++)
                        {
                            if (x + relativeX < 0 || internalGrid.GetLength(0) <= x + relativeX
                            || y + relativeY < 0 || internalGrid.GetLength(1) <= y + relativeY)
                            {
                                continue;
                            }
                            else if (grid[x + relativeX, y + relativeY].isFlagged)
                            {
                                internalGrid[x, y].adjacentFlaggedCount++;
                            }
                        }
                    }
                }
            }
        }

        private void DebugDisplayGrid(GridTile[,] grid, bool gameStart, bool updateGridEachTurn)
        {
            if (gameStart)
            {
                Debug.Write("\n");
                for (int y = 0; y < grid.GetLength(1); y++)
                {
                    for (int x = 0; x < grid.GetLength(0); x++)
                    {
                        Debug.Write((grid[x, y].hasMine ? "*" : grid[x, y].adjacentMineCount.ToString()).PadRight(2));
                    }
                    Debug.Write("\n");
                }
                Debug.Write("\n");
            }
            if (updateGridEachTurn)
            {
                Debug.Write("\n");
                for (int y = 0; y < grid.GetLength(1); y++)
                {
                    for (int x = 0; x < grid.GetLength(0); x++)
                    {
                        if (grid[x, y].isFlagged)
                        {
                            Debug.Write("F ");
                        }
                        else if (grid[x, y].isUncovered)
                        {
                            Debug.Write(grid[x, y].adjacentMineCount + " ");
                        }
                        else
                        {
                            Debug.Write("X ");
                        }
                    }
                    Debug.Write("\n");
                }
            }
        }


        public void DisplayResultsScreen(GameState endState, long timeTaken, Position lastClear)
        {
            //throw new NotImplementedException();
            Debug.Write($"\nGame over, AI has " + (endState == GameState.Won ? "Won" : "lost") + " the game\n");
        }
        public void TakeTurn(Position selectedPosition)
        {
            ///<Summary>
            /// Dont use this overload
            ///</Summary>
            ///<param name="selectedPosition"> Calling this overload will not work, please call the parameterless overload </param>
            
            // Im aware that this should be private if it shouldnt be called from out side of this class however 
            // it is required to be public due to the implementation of the IGameControl Interface, cry about it.
            gameInstance.TakeTurn(selectedPosition);

            if (gameInstance.GetGameState() != GameState.Running)
            {
                // Game Ober
                Debug.Assert(true, "Game Over");
            }
        }
        #endregion

        public void TakeTurn()
        {
            Debug.Write("AI Taking turn\n");
            LogicalSearch();
            if (moveTaken == true)
            {
                moveTaken = false;
                return;
            }
            else
            {
                Debug.Write("no simple move");
                TakeTurn(RandomGuess());
            }
        }
        private void FlagTile(Position selectedPosition)
        {
            flaggingMode = true;
            TakeTurn(selectedPosition);
            flaggingMode = false;
        }
        private void ClearTile(Position selectedPosition)
        {
            flaggingMode = false;
            TakeTurn(selectedPosition);
        }

        private void LogicalSearch()
        {
            List<AiGridTile> numberTiles = new List<AiGridTile>();
            foreach (AiGridTile tile in internalGrid)
            {
                if (tile.isUncovered && tile.adjacentMineCount > 0)
                {
                    numberTiles.Add(tile);
                }
            }

            foreach (AiGridTile tile in numberTiles)
            {
                AiGridTile[] neigbours = GetNeighbouringTiles(tile);
                int hiddenNeighbours = 0;
                int flaggedNeigbours = 0;
                foreach (AiGridTile neighbourTile in neigbours)
                {
                    if (!neighbourTile.isUncovered && !neighbourTile.isFlagged)
                    {
                        hiddenNeighbours++;
                    }
                    else if (neighbourTile.isFlagged)
                    {
                        flaggedNeigbours++;
                    }
                }

                if (hiddenNeighbours + flaggedNeigbours == tile.adjacentMineCount && hiddenNeighbours > 0)
                {
                    foreach(AiGridTile neighbourTile in neigbours)
                    {
                        if (!neighbourTile.isUncovered && !neighbourTile.isFlagged)
                        {
                            FlagTile(neighbourTile.location);
                        }
                    }
                    moveTaken = true;
                    return;
                }
                else if (flaggedNeigbours == tile.adjacentMineCount && hiddenNeighbours > 0)
                {
                    foreach (AiGridTile neighbourTile in neigbours)
                    {
                        if (!neighbourTile.isUncovered && !neighbourTile.isFlagged)
                        {
                            ClearTile(neighbourTile.location);
                        }
                    }
                    moveTaken = true;
                    return;
                }
            }
        }
        private Position RandomGuess()
        {
            // First guess is not actually random, the first click will never be a mine and the corners
            // are statistically less likely to contain mines, so we check the corners first
            Debug.Write("AI Guessing Tile:");
            int hiddenCorners = 0;
            hiddenCorners += (internalGrid[0, 0].isUncovered 
                            || internalGrid[0, 0].isFlagged ? 0 : 1);
            hiddenCorners += (internalGrid[internalGrid.GetLength(0) - 1, 0].isUncovered 
                            || internalGrid[internalGrid.GetLength(0) - 1, 0].isFlagged ? 0 : 1);
            hiddenCorners += (internalGrid[0, internalGrid.GetLength(1) - 1].isUncovered 
                            || internalGrid[0, internalGrid.GetLength(1) - 1].isFlagged ? 0 : 1);
            hiddenCorners += (internalGrid[internalGrid.GetLength(0) - 1, internalGrid.GetLength(1) - 1].isUncovered 
                            || internalGrid[internalGrid.GetLength(0) - 1, internalGrid.GetLength(1) - 1].isFlagged ? 0 : 1);
            if (hiddenCorners == 0) // If no corners are uncovered guess randomly
            {
                bool foundHiddenTile = false;
                Position randomPosition = new Position();
                do
                {
                    randomPosition.xPosition = (short)random.Next(0, internalGrid.GetLength(0));
                    randomPosition.yPosition = (short)random.Next(0, internalGrid.GetLength(1));
                    if (!internalGrid[randomPosition.xPosition, randomPosition.yPosition].isUncovered && !internalGrid[randomPosition.xPosition,randomPosition.yPosition].isFlagged)
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
                        randomCorner.xPosition = (short)(internalGrid.GetLength(0) - 1);
                        randomCorner.yPosition = 0;
                        break;
                    case 2:
                        randomCorner.xPosition = 0;
                        randomCorner.yPosition = (short)(internalGrid.GetLength(1) - 1);
                        break;
                    case 3:
                        randomCorner.xPosition = (short)(internalGrid.GetLength(0) - 1);
                        randomCorner.yPosition = (short)(internalGrid.GetLength(1) - 1);
                        break;
                }
                if (!internalGrid[randomCorner.xPosition, randomCorner.yPosition].isUncovered)
                {
                    foundHiddenCorner = true;
                }
            } while (!foundHiddenCorner);
            Debug.Write($"Corner at:{randomCorner.xPosition},{randomCorner.yPosition}\n");
            return randomCorner;
        }

        private void Solver()
        {
            List<AiGridTile> hiddenTiles = new List<AiGridTile>();
            List<AiGridTile> boundaryTiles = new List<AiGridTile>();
            for (int y = 0; y < internalGrid.GetLength(1); y++)
            {
                for (int x = 0; x < internalGrid.GetLength(0); x++)
                {
                    if (!internalGrid[x,y].isUncovered && !internalGrid[x,y].isFlagged)
                    {
                        hiddenTiles.Add(internalGrid[x, y]);
                    }
                    
                    if (IsBoundaryTile(x,y) && !internalGrid[x,y].isFlagged)
                    {
                        boundaryTiles.Add(internalGrid[x, y]);
                    }
                }
            }

            List<List<AiGridTile>> sections = GetSections(boundaryTiles);

            for (int i = 0; i < sections.Count; i++)
            {
                List<bool[]> Solutions = new List<bool[]>();
                bool[,] knownMines = new bool[internalGrid.GetLength(0), internalGrid.GetLength(1)];
                bool[,] knownSafe = new bool[internalGrid.GetLength(0), internalGrid.GetLength(1)];
                for (int y = 0; y < internalGrid.GetLength(1); y++) // The amount of 2D array itterators in this project is insane
                {
                    for (int x = 0; x < internalGrid.GetLength(0); x++)
                    {
                        if (internalGrid[x,y].isFlagged)
                        {
                            knownMines[x, y] = true;
                        }
                        else if (internalGrid[x,y].isUncovered)
                        {
                            knownSafe[x, y] = true;
                        }
                    }
                }

                SolverRecurse(boundaryTiles, 0);

                for (int j = 0; j < sections[i].Count; j++)
                {
                    bool allMine = true;
                    bool allSafe = true;

                    foreach (bool[] solution in Solutions)
                    {
                        // Check to see if tile j is the same in every solution
                        // if there are any solutions where j isnt in it then it isnt a mine in all solutions
                        // if there are any solutions where j is in the solution then it isnt safe in all solutions
                        if (!solution[j])
                        {
                            allMine = false;
                        }
                        else
                        {
                            allSafe = false;
                        }
                    }

                    AiGridTile tile = (sections[i])[j];
                    if (allMine)
                    {
                        FlagTile()
                    }
                }

                void SolverRecurse(List<AiGridTile> borderTiles, int depth)
                {

                }
            }
        }

        private bool IsBoundaryTile(int x, int y)
        {
            if (internalGrid[x,y].isUncovered) // If tile isnt hidden it cant be a boundary tile
            {
                return false;
            }
            for (int yOffset = -1; yOffset <= 1; yOffset++)
            {
                for (int xOffset = -1; xOffset <= 1; xOffset++)
                {
                    if (x + xOffset < 0 || internalGrid.GetLength(0) <= x + xOffset
                        || y + yOffset < 0 || internalGrid.GetLength(1) <= y + yOffset
                        || x == 0 && y == 0)
                    {
                        continue;
                    }

                    if (internalGrid[x + xOffset, y + yOffset].isUncovered) // If any of the neighboring tiles are uncovered it is a boundary
                    {
                        return true;
                    }
                }
            }
            return false; // If no neighbours are uncoverd it is not a boundary
        }
        public List<List<AiGridTile>> GetSections(List<AiGridTile> boundaryTiles)
        {
            List<List<AiGridTile>> sections = new List<List<AiGridTile>>();
            List<AiGridTile> checkedTiles = new List<AiGridTile>();

            while (true)
            {
                List<AiGridTile> section = new List<AiGridTile>();
                AiGridTile startingTile = null;

                foreach (AiGridTile tile in boundaryTiles)
                {
                    if (!checkedTiles.Contains(tile))
                    {
                        startingTile = tile;
                        break;
                    }
                }

                if (startingTile == null)
                {
                    break;
                }
                else
                {
                    AddConnectedRecursive(startingTile);
                }

                sections.Add(section);

                void AddConnectedRecursive(AiGridTile currentTile)
                {
                    section.Add(currentTile);
                    checkedTiles.Add(currentTile);
                    foreach (AiGridTile tile in boundaryTiles)
                    {
                        if (IsConnected(currentTile, tile) && !section.Contains(tile))
                        {
                            AddConnectedRecursive(tile);
                        }
                    }
                    return;
                }
            }

            return sections;
        }
        public bool IsConnected(AiGridTile tile1, AiGridTile tile2)
        {
            if (Math.Abs(tile1.location.xPosition - tile2.location.xPosition) <= 1
                && Math.Abs(tile1.location.yPosition - tile2.location.yPosition) <= 1)
            {
                return true;
            }
            return false;
        }

        public AiGridTile[] GetNeighbouringTiles(AiGridTile tile)
        {
            byte numberOfExpectedNeigbours = 8;
            List<AiGridTile> neighbours = new List<AiGridTile>();
            for (int yOffset = -1; yOffset <= 1; yOffset++)
            {
                for (int xOffset = -1; xOffset <= 1; xOffset++)
                {
                    if (tile.location.xPosition + xOffset < 0 || internalGrid.GetLength(0) <= tile.location.xPosition + xOffset
                        || tile.location.yPosition + yOffset < 0 || internalGrid.GetLength(1) <= tile.location.yPosition + yOffset
                        || xOffset == 0 && yOffset == 0)
                    {
                        numberOfExpectedNeigbours--;
                        continue;
                    }
                    neighbours.Add(internalGrid[tile.location.xPosition + xOffset, tile.location.yPosition + yOffset]);
                }
            }
            Debug.Assert(neighbours.Count != numberOfExpectedNeigbours, "Error");
            return neighbours.ToArray();
        }
        public class AiGridTile
        {
            public bool isUncovered;
            public bool isFlagged;
            public byte adjacentFlaggedCount;
            public byte adjacentMineCount;
            public Position location;
        }
    }
}