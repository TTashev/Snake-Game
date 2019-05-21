using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Position
    {
        public Position(int positionX, int positionY)
        {
            this.positionX = positionX;
            this.positionY = positionY;
        }

        public int positionX { get; set; }
        public int positionY { get; set; }


    }
}
