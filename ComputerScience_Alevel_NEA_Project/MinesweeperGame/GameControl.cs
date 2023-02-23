using MinesweeperGame.SupportComponents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MinesweeperGame
{
    namespace GameControl
    {
        public interface IGameControl
        {
            bool GetFlaggingMode();
            void ToggleFlaggingMode();
            int GetMinesLeft();
            void SetMinesLeft(int mines);
            void DisplayGrid(GridTile[,] grid, bool gameStart);
            void DisplayResultsScreen(GameState endState, long timeTaken, Position lastClear);
            void TakeTurn(Position selectedPosition);
        }
    }
}