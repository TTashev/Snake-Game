using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using SimpleSnake.GameObjects;
using SimpleSnake.GameObjects.Foods;
using SimpleSnake.Enums;
using SimpleSnake.Factories;
using SimpleSnake.Utilities;

namespace SimpleSnake.Core
{
    public class Engine
    {
        private DrawManager drawManager;
        private Position boardPos;
        private Snake snake;
        private Food food;
        private LevelManager levels;
        private int gameScore;

        public Engine(DrawManager drawManager, Snake snake, Position boardPosition)
        {
            this.drawManager = drawManager;
            this.boardPos = boardPosition;
            this.snake = snake;
            this.levels = new LevelManager();
            this.InitializeFood();
            //this.InitializeBoarders();
            this.drawManager.DrawLevel(levels.getLevel());
        }

        public void Run()
        {
            while (true)
            {
                this.PlayInfo();

                // check for input
                if (Console.KeyAvailable)
                {
                    // set direction for the snake
                    this.SetCurrectDirection(Console.ReadKey());
                }

                this.drawManager.Draw(food.symbol, new List<Position>() { food.foodPos });

                // draw the snake
                this.drawManager.Draw(GameData.Snake.snakeSymbol, this.snake.body);

                this.snake.Move();

                this.drawManager.UndoDraw();

                if (HasFoodCollision())
                {
                    this.snake.Eat(this.food);
                    this.gameScore += this.food.points;
                    this.InitializeFood();
                }

                if (HasBorderCollision() || snake.checkSnakeCollision() || HasLevelCollision())
                {
                    this.RestartGame();
                }

                Thread.Sleep(100);
            }
        }

        private void PlayInfo()
        {
            int x = GameData.LevelBoarder.defaultBoarderWidth + GameData.Player.playerScoreOffsetX;
            int y = GameData.Player.playerScoreOffsetY;

            Console.SetCursorPosition(x, y);
            Console.Write(string.Format(GameData.Player.playerScore, gameScore));
        }

        private void RestartGame()
        {
            Console.SetCursorPosition(GameData.Config.endMessageX, GameData.Config.endMessageY);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(GameData.Config.endMessage);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Y/N");

            var input = Console.ReadKey();

            if (input.Key == ConsoleKey.Y)
            {
                Console.Clear();
                StartUp.Main();
            }

            Environment.Exit(0);
        }

        private void InitializeBoarders()
        {
            List<Position> allPositions = new List<Position>();

            this.InitilizeHorizontalBoarder(0, allPositions);
            this.InitilizeHorizontalBoarder(this.boardPos.positionY, allPositions);

            this.InitilizeVerticalBoarder(0, allPositions);
            this.InitilizeVerticalBoarder(this.boardPos.positionX - 1, allPositions);

            this.drawManager.Draw(GameData.LevelBoarder.boarderSymbol, allPositions);
        }

        private void InitilizeVerticalBoarder(int posX, List<Position> allPositions)
        {
            for (int posY = 0; posY < this.boardPos.positionY; posY++)
            {
                allPositions.Add(new Position(posX, posY));
            }
        }

        private void InitilizeHorizontalBoarder(int posY, List<Position> allPositions)
        {
            for (int posX = 0; posX < this.boardPos.positionX; posX++)
            {
                allPositions.Add(new Position(posX, posY));
            }
        }

        private void InitializeFood()
        {
            this.food = FoodFactory.GetRandomFood(this.boardPos.positionX, this.boardPos.positionY);
        }

        private bool HasFoodCollision()
        {
            int snakeHeadPosX = this.snake.Head.positionX;
            int snakeHeadPosY = this.snake.Head.positionY;

            int foodPosX = this.food.foodPos.positionX;
            int foodPosY = this.food.foodPos.positionY;

            return snakeHeadPosX == foodPosX && snakeHeadPosY == foodPosY;
        }

        private bool HasBorderCollision()
        {
            int snakeHeadPosX = this.snake.Head.positionX;
            int snakeHeadPosY = this.snake.Head.positionY;

            int boarderPosX = this.boardPos.positionX;
            int boarderPosY = this.boardPos.positionY;

            return snakeHeadPosX == boarderPosX - 1
                || snakeHeadPosX == 0
                || snakeHeadPosY == boarderPosY
                || snakeHeadPosY == 0;
        }

        private bool HasLevelCollision()
        {
            int snakeHeadPosX = this.snake.Head.positionX;
            int snakeHeadPosY = this.snake.Head.positionY;

            for (int i = 0; i < levels.getLevel().Length; i++)
            {
                for (int j = 0; j < levels.getLevel()[i].Length; j++)
                {
                    // clumsy way to check for level colision, couldn't figured out somenthing better
                    if (levels.getLevel()[i][j] == '\u2588' && snakeHeadPosX == j && snakeHeadPosY == i)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void SetCurrectDirection(ConsoleKeyInfo input)
        {
            Direction currentSnakeDirection = this.snake.Direction;

            switch (input.Key)
            {
                case ConsoleKey.DownArrow:
                    if (currentSnakeDirection != Direction.Up)
                    {
                        currentSnakeDirection = Direction.Down;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (currentSnakeDirection != Direction.Right)
                    {
                        currentSnakeDirection = Direction.Left;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (currentSnakeDirection != Direction.Left)
                    {
                        currentSnakeDirection = Direction.Right;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (currentSnakeDirection != Direction.Down)
                    {
                        currentSnakeDirection = Direction.Up;
                    }
                    break;
                default:
                    break;
            }

            this.snake.Direction = currentSnakeDirection;
        }
    }
}
