using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.Text;

namespace MineSweeperGame
{
    class TestClass
    {
        public static void GridGenerationSpeedTest()
        {
            short noOfRuns = 100;
            Stopwatch sw = new Stopwatch();
            long fastest = -1;
            long slowest = -1;
            long total = 0;
            long timeTaken = 0;
            IGameControl gc = new CommandLineInterface();
            GridTile[,] grid;

            for (int i = 0; i < noOfRuns; i++)
            {
                sw.Reset();
                timeTaken = 0;
                grid = null;
                sw.Start();
                grid = GridGenerator.GenerateGrid(16, 16, 40, null);
                Thread.Sleep(100);
                sw.Stop();

                gc.DisplayGrid(grid);
                timeTaken = sw.ElapsedMilliseconds - 100;
                Console.Write($"grid generation {i + 1} completed with time: {timeTaken}ms\n\n");
                if (fastest == -1 || timeTaken < fastest)
                {
                    fastest = timeTaken;
                }
                if (slowest == -1 || slowest < timeTaken)
                {
                    slowest = timeTaken;
                }
                total = total + timeTaken;
            }
            long mean = total / noOfRuns;
            Console.Write($"Fastest:{fastest}ms\nSlowest:{slowest}ms\naverage:{mean}ms");
        }
    }
}
