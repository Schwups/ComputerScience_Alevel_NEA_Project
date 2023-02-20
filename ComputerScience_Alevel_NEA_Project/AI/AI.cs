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
            internalGrid = new AiGridTile[gameParameters.width, gameParameters.height];
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
            // The AI will hook into the DisplayGrid method from the IGameControl interface to update its internal grid
            for (int y = 0; y < internalGrid.GetLength(1); y++)
            {
                for (int x = 0; x < internalGrid.GetLength(0); x++)
                {
                    if (gameStart)
                    {
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
                        internalGrid[x, y].adjacentHiddenCount = byte.MaxValue;
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
                            else if (!grid[x + relativeX, y + relativeY].isUncovered)
                            {
                                internalGrid[x, y].adjacentHiddenCount++;
                            }
                        }
                    }

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
        public void DisplayResultsScreen(GameState endState, long timeTaken, Position lastClear)
        {
            throw new NotImplementedException();
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
            Debug.Write("Taking turn\n");
        }

        /*
        private bool CheckForSimpleMove()
        {
            for (int y = 0; y < internalGrid.GetLength(1); y++)
            {
                for (int x = 0; x < internalGrid.GetLength(0); x++)
                {
                    if (internalGrid[x,y].isUncovered || internalGrid[x,y].adjacentHiddenCount == byte.MaxValue)
                    {
                        continue;
                    }
                    if (internalGrid[x,y].adjacentMineCount == 0)
                    {
                        Debug.Write($"Simple move at:{x},{y}\n");
                        ClearAllNear(new Position()
                        {
                            xPosition = (short)x,
                            yPosition = (short)y,
                        }, false);
                    }
                    if (internalGrid[x,y].adjacentHiddenCount == internalGrid[x,y].adjacentMineCount)
                    {
                        Debug.Write($"Simple move at:{x},{y}\n");
                        ClearAllNear(new Position()
                        {
                            xPosition = (short)x,
                            yPosition = (short)y,
                        } , true);
                        return true;
                    }
                    else if (internalGrid[x,y].adjacentFlaggedCount == internalGrid[x,y].adjacentMineCount)
                    {
                        Debug.Write($"Simple move at:{x},{y}\n");
                        ClearAllNear(new Position()
                        {
                            xPosition = (short)x,
                            yPosition = (short)y,
                        }, false);
                    }
                }
            }
            return false;
        }

        private void ClearAllNear(Position position, bool flagging)
        {
            flaggingMode = flagging;
            for (int relativeY = -1; relativeY < 1; relativeY++)
            {
                for (int relativeX = -1; relativeX < 1; relativeX++)
                {
                    if (position.xPosition + relativeX < 0 || internalGrid.GetLength(0) <= position.xPosition + relativeX
                    || position.yPosition + relativeY < 0 || internalGrid.GetLength(1) <= position.yPosition + relativeY)
                    {
                        continue;
                    }
                    if (!internalGrid[position.xPosition + relativeX, position.yPosition + relativeY].isUncovered)
                    {
                        TakeTurn(new Position()
                        {
                            xPosition = (short)(position.xPosition + relativeX),
                            yPosition = (short)(position.yPosition + relativeY),
                        });
                    }
                }
            }
            flaggingMode = false;
        }
        */

        private Position RandomGuess(bool firstGuess)
        {
            // First guess is not actually random, the first click will never be a mine and the corners
            // are statistically less likely to contain mines, so we check the corners first
            Debug.Write("AI Guessing Tile:");
            int hiddenCorners = 0;
            if (firstGuess)
            {
                hiddenCorners += (internalGrid[0, 0].isUncovered 
                                || internalGrid[0, 0].isFlagged ? 0 : 1);
                hiddenCorners += (internalGrid[internalGrid.GetLength(0) - 1, 0].isUncovered 
                                || internalGrid[internalGrid.GetLength(0) - 1, 0].isFlagged ? 0 : 1);
                hiddenCorners += (internalGrid[0, internalGrid.GetLength(1) - 1].isUncovered 
                                || internalGrid[0, internalGrid.GetLength(1) - 1].isFlagged ? 0 : 1);
                hiddenCorners += (internalGrid[internalGrid.GetLength(0) - 1, internalGrid.GetLength(1) - 1].isUncovered 
                                || internalGrid[internalGrid.GetLength(0) - 1, internalGrid.GetLength(1) - 1].isFlagged ? 0 : 1);
            }
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

        private void SetProbablilites()
        {
            // Get unknown tiles
            int unknownCount = 0;
            for (int y = 0; y < internalGrid.GetLength(1); y++)
            {
                for (int x = 0; x < internalGrid.GetLength(0); x++)
                {
                    if (internalGrid[x,y].isUncovered)
                    {
                        continue;
                    }

                    bool unknownTile = true;
                    for (int relativeY = -1; relativeY < 1; relativeY++)
                    {
                        for (int relativeX = -1; relativeX < 1; relativeX++)
                        {
                            if (x + relativeX < 0 || internalGrid.GetLength(0) <= x + relativeX
                            || y + relativeY < 0 || internalGrid.GetLength(1) <= y + relativeY
                            || (relativeX == 0 && relativeY == 0))
                            {
                                continue;
                            }
                            if (internalGrid[x + relativeX, y + relativeY].isUncovered)
                            {
                                unknownTile = false;
                            }
                        }
                    }
                    if (unknownTile)
                    {
                        internalGrid[x, y].isUnknown = true;
                        unknownCount++;
                    }
                }
            }

            // Split grid into sections
            List<List<AiGridTile>> sections = new List<List<AiGridTile>>(); // This is dumb as fuck
            // List of sections, section (A "section" is a list of AiGridTile)

            for (int y = 0; y < internalGrid.GetLength(1); y++)
            {
                for (int x = 0; x < internalGrid.GetLength(0); x++)
                {
                    if (internalGrid[x,y].isUncovered 
                        && internalGrid[x,y].adjacentHiddenCount - internalGrid[x,y].adjacentFlaggedCount > 0)
                    {
                        bool alreadyInSection = false;
                        foreach (List<AiGridTile> section in sections)
                        {
                            if (section.Contains(internalGrid[x,y]))
                            {
                                alreadyInSection = true;
                                break;
                            }
                        }
                        if (!alreadyInSection)
                        {
                            List<AiGridTile> newSection = new List<AiGridTile>();
                            AddConnectedTiles(newSection, new Position() { xPosition = (short)x, yPosition = (short)y});
                            sections.Add(newSection);
                        }
                    }
                }
            }

            List<List<List<AiGridTile>>> sectionSolutions = new List<List<List<AiGridTile>>>(); // This is even more dumb as fuck
            // List of all solutions for all sections, list of solutions for a section, section

            // Get all possible bomb locations for each section
            foreach (List<AiGridTile> section in sections)
            {
                sectionSolutions.Add(GetSolutions(section));
            }
        }

        void AddConnectedTiles(List<AiGridTile> section, Position startingPosition)
        {
            // Use recursion to visit all connected tiles

            AddTile(startingPosition);

            void AddTile(Position position)
            {
                if (section.Contains(internalGrid[position.xPosition,position.yPosition]))
                {
                    return;
                }
                section.Add(internalGrid[position.xPosition, position.yPosition]);
                if (!internalGrid[position.xPosition, position.yPosition].isUncovered)
                {
                    for (int relativeY = -1; relativeY < 1; relativeY++)
                    {
                        for (int relativeX = -1; relativeX < 1; relativeX++)
                        {
                            if (position.xPosition + relativeX < 0 || internalGrid.GetLength(0) <= position.xPosition + relativeX
                            || position.yPosition + relativeY < 0 || internalGrid.GetLength(1) <= position.yPosition + relativeY
                            || (relativeX == 0 && relativeY == 0))
                            {
                                continue;
                            }
                            AddTile(new Position() { xPosition = (short)(position.xPosition + relativeX), yPosition = (short)(position.yPosition + relativeY) });
                        }
                    }
                }
            }
        }
        List<List<AiGridTile>> GetSolutions(List<AiGridTile> section)
        {
            /*
            List<AiGridTile> hiddenTilesInSection = new List<AiGridTile>();
            foreach (AiGridTile tile in section)
            {
                if (!tile.isUncovered)
                {
                    hiddenTilesInSection.Add(tile);
                }
            }

            List<List<AiGridTile>> solutions = new List<List<AiGridTile>>();
            List<AiGridTile> possibleMineLocations = new List<AiGridTile>();
            Queue<int> possibleNumberOfMines = new Queue<int>();

            for (int i = 0; i < hiddenTilesInSection.Count(); i++)
            {
                possibleNumberOfMines.Enqueue(i);
            }

            long hiddenTilesLeft = hiddenTilesInSection.Count();
            while (possibleNumberOfMines.Count > 0)
            {
                int checkingNumberOfMines = possibleNumberOfMines.Dequeue();
                for (int i = 0; i < hiddenTilesInSection.Count() - checkingNumberOfMines; i++)
                possibleMineLocations.Clear();
                possibleMineLocations
            }
            */
            List<AiGridTile> edgeTiles = new List<AiGridTile>();
            foreach (AiGridTile tile in section)
            {
                if (!tile.isUncovered && !tile.isUnknown)
                {
                    edgeTiles.Add(tile);
                }
            }

            int maxNumberOfMines = edgeTiles.Count();

        }

        public class AiGridTile
        {
            public bool isUncovered;
            public bool isFlagged;
            public bool isUnknown;
            public byte adjacentFlaggedCount;
            public byte adjacentMineCount;
            public byte adjacentHiddenCount;
            public Position location;
        }
    }
}