﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Due_Date
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.PlayGame();
            Console.Read();
        }

        public static void ClearScreen()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine();
            }
        }
    }
}
