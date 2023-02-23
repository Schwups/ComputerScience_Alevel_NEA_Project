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
            CommandLineInterface cli = new CommandLineInterface();
            GameParameters parameters = new GameParameters() { width = 9, height = 9, mineCount = 10, gameDifficulty = Difficulty.Custom, gameSeed = "16318" };

            GridTile[,] grid = GridGenerator.GenerateGrid(parameters);
            cli.DisplayGrid(grid, false);
            Console.Read(); }
        static void Play()
        {
            CommandLineInterface cli = new CommandLineInterface();
            MinesweeperGameInstance game = new MinesweeperGameInstance(cli, new GameParameters()
            { width = 9, height = 9, mineCount = 10, gameSeed = null, gameDifficulty = Difficulty.Custom });
            game.StartGame();
            int[] selection;

            do
            {
                Console.Write("Enter tile:");
                selection = GetInput();
                Debug.Write($"Selecting tile ({selection[0]},{selection[1]})\n");
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
        private bool cheatMode = true;
        private bool flaggingMode;
        private int minesLeft;

        public bool GetFlaggingMode() { return flaggingMode; }
        public void ToggleFlaggingMode() { flaggingMode = !flaggingMode; }
        public int GetMinesLeft() { return minesLeft; }
        public void SetMinesLeft(int mines) { minesLeft = mines; }

        public void DisplayGrid(GridTile[,] grid, bool gameStart)
        {
            Console.Clear();
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                for (int x = 0; x < grid.GetLength(0); x++)
                {
                    if (!grid[x,y].isUncovered && !cheatMode)
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