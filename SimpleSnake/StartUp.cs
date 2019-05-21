namespace SimpleSnake
{
    using System;
    using Utilities;
    using SimpleSnake.Core;
    using SimpleSnake.GameObjects;
    using Enums;


    public class StartUp
    {
        public static void Main()
        {
            Position pos = new Position(5,5);
            Position pos2 = new Position(5, 5);

            ConsoleWindow.CustomizeConsole();

            Position boardPosition = new Position(GameData.LevelBoarder.defaultBoarderWidth, GameData.LevelBoarder.defaultBoarderHeight);
            DrawManager drawManager = new DrawManager();
            Snake snake = new Snake();


            //string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Redeemer\Desktop\New Text Document (2).txt");

            Engine engine = new Engine(drawManager, snake, boardPosition);

            engine.Run();

        }
    }
}
