using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.Utilities
{
    public static class GameData
    {
        public static class Snake
        {
            public static readonly string snakeSymbol = "\u25cf";
            public static readonly int defaultLength = 6;
            public static readonly int defaultPosX = 8;
            public static readonly int defaultPosY = 7;
        }

        public static class Food
        {
            public static readonly string AsteriskSymbol = "*";
            public static readonly int AsteriskPoints = 1;

            public static readonly string DollarSymbol = "$";
            public static readonly int DollarPoints = 2;

            public static readonly string HashSymbol = "#";
            public static readonly int HashPoints = 3;
        }

        public static class LevelBoarder
        {
            public static readonly string boarderSymbol = "\u2588";

            public static readonly int defaultBoarderWidth = 120;
            public static readonly int defaultBoarderHeight = 40;
        }

        public static class Player
        {
            public static readonly string boarderSymbol = "\u2588";
            public static readonly string playerScore = "Game score: {0}";

            public static readonly int playerScoreOffsetX = 10;
            public static readonly int playerScoreOffsetY = 10;
        }

        public static class Config
        {
            public static readonly string endMessage = "Press to restart the game ";

            public static readonly int endMessageX = 45;
            public static readonly int endMessageY = 15;
        }
    }
}
