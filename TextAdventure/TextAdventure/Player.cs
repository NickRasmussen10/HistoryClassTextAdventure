using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{

    class Player
    {
        List<string> inventory;
        public int hunger;
        int maxHunger = 6;
        public int confidence;
        int maxConfidence = 6;
        public float timeLeft = 1200;
        //public bool isDead;

        public Player(List<string> inv, int h, int c)
        {
            inventory = inv;
            hunger = h;
            confidence = c;
        }

        public void PrintPlayer()
        {
            ClampStats();


            string printStr = "\n";
            Console.WriteLine();
            printStr += "Inventory: ";
            for (int i = 0; i < inventory.Count; i++)
            {
                printStr += inventory[i];
                if (i != inventory.Count - 1)
                {
                    printStr += ", ";
                }
            }
            Console.Write(printStr);

            Console.Write("    Hunger: ");
            printStr = "";
            for (int i = 0; i < hunger; i++)
            {
                printStr += "<> ";
            }
            if (hunger < 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (hunger <= 4)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.Write(printStr);
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("    Confidence: ");
            printStr = "";
            for (int i = 0; i < confidence; i++)
            {
                printStr += "<> ";
            }
            if (confidence < 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (confidence <= 4)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.Write(printStr);
            Console.ForegroundColor = ConsoleColor.White;

            TimeSpan time = TimeSpan.FromSeconds(timeLeft);
            Console.Write("    Time until class: ");
            if (timeLeft <= 5)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (timeLeft <= 10)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.Write(time.ToString("mm':'ss"));
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();
        }

        void ClampStats()
        {
            if (hunger < 1)
            {
                hunger = 1;
            }
            else if (hunger > maxHunger)
            {
                hunger = maxHunger;
            }

            if (confidence < 1)
            {
                confidence = 1;
            }
            else if (confidence > maxConfidence)
            {
                confidence = maxConfidence;
            }
        }

        public void AddItem(string item)
        {
            inventory.Add(item);
        }
    }
}
