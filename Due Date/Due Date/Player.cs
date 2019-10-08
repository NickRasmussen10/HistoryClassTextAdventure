using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Due_Date
{
    class Player
    {
        List<string> inventory;
        public int hunger;
        int maxHunger = 6;
        public int confidence;
        int maxConfidence = 6;
        public float timeLeft = 600;
        public bool isSick = false;

        public int grade = 80;
        public bool inPresentation = false;

        public Player(List<string> inv, int h, int c)
        {
            inventory = inv;
            hunger = h;
            confidence = c;
        }

        public void PrintPlayer()
        {
            ClampStats();

            string printStr = "";
            if (!inPresentation)
            {
                Console.WriteLine();
                Console.Write("Inventory: ");
                if (inventory.Count == 0)
                {
                    printStr += "EMPTY";
                }
                else
                {
                    for (int i = 0; i < inventory.Count; i++)
                    {
                        printStr += inventory[i];
                        if (i != inventory.Count - 1)
                        {
                            printStr += ", ";
                        }
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(printStr);
            Console.ForegroundColor = ConsoleColor.White;

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

            if (!inPresentation)
            {
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
            }

            if (inPresentation)
            {
                Console.Write("\nGrade: ");
                if (grade > 90)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (grade > 80)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
                else if (grade > 70)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write(grade);
            }

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

            if (grade < 0)
            {
                grade = 0;
            }
            else if (grade > 100)
            {
                grade = 100;
            }
        }

        public void AddItem(string item)
        {
            inventory.Add(item);
        }

        public void RemoveItem(string item)
        {
            if (CheckInventory(item))
            {
                inventory.Remove(item);
            }
        }

        public bool CheckInventory(string item)
        {
            foreach (string i in inventory)
            {
                if (i == item) { return true; }
            }
            return false;
        }
    }
}
