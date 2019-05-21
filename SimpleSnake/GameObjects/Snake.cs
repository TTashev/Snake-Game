using System;
using System.Collections.Generic;
using System.Text;
using SimpleSnake.Enums;
using SimpleSnake.GameObjects.Foods;
using SimpleSnake.Utilities;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private readonly List<Position> snakeBody;

        public Snake()
        {
            this.snakeBody = new List<Position>();
            // set default direction as right
            this.Direction = Direction.Right;
            this.InitBody();
        }

        public Direction Direction { get; set; }
        public Position Head => this.snakeBody[snakeBody.Count - 1];

        public IReadOnlyCollection<Position> body => this.snakeBody.AsReadOnly();

        public void Move()
        {
            Position newHead = GetNewHeadPosition();

            this.snakeBody.Add(newHead);
            this.snakeBody.RemoveAt(0);
        }

        public bool checkSnakeCollision()
        {
            for (int snakeSegment = 0; snakeSegment < snakeBody.Count - 1; snakeSegment++)
            {
                if (this.snakeBody[snakeSegment].positionX == Head.positionX && this.snakeBody[snakeSegment].positionY == Head.positionY)
                {
                    return true;
                }
            }

            return false;
        }

        private Position GetNewHeadPosition()
        {
            Position newHeadPos = new Position(this.Head.positionX, this.Head.positionY);

            switch (this.Direction)
            {
                case Direction.Right:
                    newHeadPos.positionX++;
                    break;
                case Direction.Left:
                    newHeadPos.positionX--;
                    break;
                case Direction.Down:
                    newHeadPos.positionY++;
                    break;
                case Direction.Up:
                    newHeadPos.positionY--;
                    break;
                default:
                    break;
            }
            return newHeadPos;
        }

        public void Eat(Food food)
        {
            for (int i = 0; i < food.points; i++)
            {
                Position newHeadPos =  this.GetNewHeadPosition();
                this.snakeBody.Add(newHeadPos);
            }
        }

        private void InitBody()
        {
            int x = GameData.Snake.defaultPosX;
            int y = GameData.Snake.defaultPosY;

            for (int i = 0; i <= GameData.Snake.defaultLength; i++)
            {
                this.snakeBody.Add(new Position(x, y));
                x++;
            }
        }
    }
}
