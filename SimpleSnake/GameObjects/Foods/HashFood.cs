using SimpleSnake.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    public class HashFood : Food
    {
        private const string foodSymbol = "#";
        private const int foodPoints = 3;
        public HashFood(Position pos) : base(GameData.Food.HashSymbol, GameData.Food.HashPoints, pos)
        {

        }
    }
}
