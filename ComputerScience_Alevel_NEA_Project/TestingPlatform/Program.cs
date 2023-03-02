using MinesweeperGame.GameControl;
using MinesweeperGame.MinesweeperGameLogic;
using MinesweeperGame.MinesweeperGridGenerator;
using MinesweeperGame.SupportComponents;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingPlatform
{
    class Program
    {
        static void Main(string[] args)
        {
            Play();
            Console.Read(); }
        static void Play()
        {
            CommandLineInterface cli = new CommandLineInterface();
            MinesweeperGameInstance game = new MinesweeperGameInstance(cli, new GameParameters()
            { width = 9, height = 9, mineCount = 10, gameSeed = "57", gameDifficulty = Difficulty.Custom });
            game.StartGame();
            int[] selection;

            do
            {
                Console.Write("Enter tile:");
                selection = GetInput();
                Debug.Write($"Selecting tile:({selection[0]},{selection[1]})\n");
                game.TakeTurn(new Position() { xPosition = (short)selection[0], yPosition = (short)selection[1] });
            } while (game.GetGameState() == GameState.Running);
        }
        static int[] GetInput()
        {
            string input = Console.ReadLine();
            int[] output = new int[2];
            output[0] = Convert.ToInt32(input[0]) - 48;
            output[1] = Convert.ToInt32(input[1]) - 48;
            return output;
        }
    }
    class CommandLineInterface : IGameControl
    {
        private bool flaggingMode;
        private int minesLeft;

        public bool GetFlaggingMode() { return flaggingMode; }
        public void ToggleFlaggingMode() { flaggingMode = !flaggingMode; }
        public int GetMinesLeft() { return minesLeft; }
        public void SetMinesLeft(int mines) { minesLeft = mines; }

        public void DisplayGrid(GridTile[,] grid, bool gameStart)
        {
            Console.Clear();
            Console.Write("\n ");
            if (gameStart)
            {
                DebugDisplayGrid(grid);
            }
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                for (int x = 0; x < grid.GetLength(0); x++)
                {
                    if (!grid[x,y].isUncovered)
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
                Console.Write("\n ");
            }
        }

        public void DebugDisplayGrid(GridTile[,] grid)
        {
            Debug.Write($"Game grid:\n");
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                for (int x = 0; x < grid.GetLength(0); x++)
                {
                    Debug.Write(grid[x, y].hasMine ? "*" : grid[x, y].adjacentMineCount.ToString());
                }
                Debug.Write("\n");
            }
        }

        public void DisplayResultsScreen(GameState endState, long timeTaken, Position lastClear)
        {
            throw new NotImplementedException();
        }
        public void TakeTurn(Position selectedPosition)
        {
            throw new NotImplementedException();
        }
    }
}