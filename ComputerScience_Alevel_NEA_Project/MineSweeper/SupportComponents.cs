using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeperGame
{
    struct Position
    {
        public short xPosition;
        public short yPosition;
    }
    
    enum GameState
    {
        Running = 0,
        Lost = 1,
        Won = 2
    }
}

// 2d array itterator
//for (int y = 0; y < array.GetLength(1); y++)
//{
//    for (int x = 0; x < array.GetLength(0); x++)
//    {
//
//    }
//
//}