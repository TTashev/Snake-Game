using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.Core
{
    class LevelLoader
    {
        private string[] lines;

        public string[] getLevel()
        {
            return lines;
        }

        public LevelLoader()
        {
            Random rnd = new Random();
            int randomLevel = rnd.Next(3);

            switch (randomLevel)
            {
                case 0:
                    lines = System.IO.File.ReadAllLines(@"C:\Users\Redeemer\Desktop\08. CSharp-OOP-Workshop-SimpleSnake\SimpleSnake\Levels\snake_level_0.txt");
                    break;
                case 1:
                    lines = System.IO.File.ReadAllLines(@"C:\Users\Redeemer\Desktop\08. CSharp-OOP-Workshop-SimpleSnake\SimpleSnake\Levels\snake_level_1.txt");
                    break;
                case 2:
                    lines = System.IO.File.ReadAllLines(@"C:\Users\Redeemer\Desktop\08. CSharp-OOP-Workshop-SimpleSnake\SimpleSnake\Levels\snake_level_2.txt");
                    break;
                default:
                    break;
            }
        }
    
    }
}
