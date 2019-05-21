using System;
using System.Collections.Generic;
using System.Text;
using SimpleSnake.GameObjects;

namespace SimpleSnake.Core
{
    public class DrawManager
    {
        private List<Position> snakeBodyElements;
        private const string snakeSymbol = "\u25cf";

        public DrawManager()
        {
            this.snakeBodyElements = new List<Position>();
        }

        public void Draw(string symbol, IEnumerable<Position> positions)
        {
            foreach (var pos in positions)
            {
                if (symbol == snakeSymbol)
                {
                    snakeBodyElements.Add(pos);
                }
                Console.SetCursorPosition(pos.positionX, pos.positionY);
                Console.Write(symbol);
            }
        }

        public void DrawLevel(string[] lines)
        {
            foreach (string line in lines)
            {
                Console.Write(line);
                Console.WriteLine();
            }
        }

        public void UndoDraw()
        {
            Position lastElement = this.snakeBodyElements[0];

            Console.SetCursorPosition(lastElement.positionX, lastElement.positionY);
            Console.Write(" ");
            snakeBodyElements.Clear();
        }
    }
}
