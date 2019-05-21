using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.Core
{
    class LevelManager
    {
        private string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Redeemer\Desktop\08. CSharp-OOP-Workshop-SimpleSnake\SimpleSnake\Levels\snake_level_1.txt");

        public string[] getLevel()
        {
            return lines;
        }

        public LevelManager()
        {
            
        }
    }
}
