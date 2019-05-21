using SimpleSnake.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    public class DollarFood : Food
    {
        private const string foodSymbol = "$";
        private const int foodPoints = 2;

        public DollarFood(Position pos) : base(GameData.Food.DollarSymbol, GameData.Food.DollarPoints, pos)
        {

        }
    }
}
