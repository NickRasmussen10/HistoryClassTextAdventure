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
        int hunger;
        public void SetHunger(int h) { hunger = h; }
        int confidence;
        public void SetConfidence(int c) { confidence = c; }

        public bool isDead;

        public Player(List<string> inv, int h, int c)
        {
            inventory = inv;
            hunger = h;
            confidence = c;
        }

        public void PrintPlayer()
        {
            string printStr = "\n";
            Console.WriteLine();
            printStr += "Inventory: ";
            for(int i = 0; i < inventory.Count; i++)
            {
                printStr += inventory[i];
                if(i != inventory.Count - 1)
                {
                    printStr += ", ";
                }
            }
            Console.Write(printStr);

            Console.Write("    Hunger: ");
            printStr = "";
            for(int i = 0; i < hunger; i++)
            {
                printStr += "<> ";
            }
            if(hunger < 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if(hunger == 3)
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
            for(int i = 0; i < confidence; i++)
            {
                printStr += "<> ";
            }
            if (confidence < 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (confidence == 3)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.Write(printStr);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        public void AddItem(string item)
        {
            inventory.Add(item);
        }
    }
}
