using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    public abstract class Food
    {
        protected Food(string symbol, int points, Position pos)
        {
            this.symbol = symbol;
            this.points = points;
            this.foodPos = pos;
        }

        public string symbol { get; set; }
        public int points { get; set; }
        public Position foodPos { get; set; }
    }
}
