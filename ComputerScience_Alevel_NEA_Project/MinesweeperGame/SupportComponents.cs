using System;
using System.Collections.Generic;
using System.Text;

namespace MinesweeperGame
{
    namespace SupportComponents
    {
        public class GridTile
        {
            public bool isUncovered;
            public bool isFlagged;
            public bool hasMine;
            public bool hasChanged;
            public byte adjacentMineCount;
        }
        public struct GameParameters
        {
            public short width;
            public short height;
            public int mineCount;
            public string gameSeed;
            public Difficulty gameDifficulty;
            public GameParameters(short width, short height, int mineCount, string gameSeed, Difficulty gameDifficulty)
            {
                this.width = width;
                this.height = height;
                this.mineCount = mineCount;
                this.gameSeed = gameSeed;
                this.gameDifficulty = gameDifficulty;
            }
        }
        public struct Position
        {
            public short xPosition;
            public short yPosition;
        }
        public enum GameState
        {
            Running = 0,
            Lost = 1,
            Won = 2
        }
        public enum Difficulty
        {
            Custom = 0,
            Beginner = 1,
            Intermediate = 2,
            Expert = 3
        }
    }
}