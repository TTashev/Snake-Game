using SimpleSnake.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    public class AsteriskFood : Food
    {
        private const int foodPoints = 1;

        public AsteriskFood(Position pos) : base(GameData.Food.AsteriskSymbol, GameData.Food.AsteriskPoints, pos)
        {

        }
    }
}
