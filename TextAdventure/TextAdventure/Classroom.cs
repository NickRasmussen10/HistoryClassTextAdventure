using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    class Classroom : Room
    {
        public Classroom(Player p)
        {
            player = p;
        }

        public Player PlayClassroom()
        {
            if (player.timeLeft > 0)
            {
                Console.WriteLine("You enter the classroom just in time, and immediately set up for your presentation.");
            }
            else
            {
                Console.WriteLine("You enter the classroom late, and Professor Kahn glares at you as you set up for your presentation.");
                player.confidence--;
            }
            PlayPresentation();
            return player;
        }

        void PlayPresentation()
        {
            Console.WriteLine("Text explaining why you have choices");
            Console.WriteLine("Option 1: \n" +
                "Tell a fun fact \n" +
                "Tell a topical joke");
            bool nextQ = false;
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                response = Console.ReadLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                switch (response)
                {
                    case "tell fun fact":
                    case "tell a fun fact":
                    case "tell fact":
                        FunFact();
                        nextQ = true;
                        break;
                    case "tell a topical joke":
                    case "tell topical joke":
                    case "tell a joke":
                    case "tell joke":
                        TopicalJoke();
                        nextQ = true;
                        break;
                    default:
                        Console.WriteLine(error);
                        break;
                }
            } while (!nextQ);

            nextQ = false;
            Console.WriteLine("Option 2: \n" +
                "Talk about technical details\n" +
                "Show pictures");
            do
            {
                switch (response)
                {
                    case "talk about technical details":
                    case "talk about details":
                    case "talk details":
                        TechnicalDetails();
                        nextQ = true;
                        break;
                    case "show pictures":
                        Pictures();
                        nextQ = true;
                        break;
                    default:
                        Console.WriteLine(error);
                        break;
                }
            } while (!nextQ);

            nextQ = false;
            Console.WriteLine("Option 3:\n" +
                "Demonstration\n" +
                "Class poll");
            do
            {
                switch (response)
                {
                    case "demonstration":
                        Demonstration();
                        nextQ = true;
                        break;
                    case "class poll":
                    case "poll":
                        Poll();
                        nextQ = true;
                        break;
                    default:
                        Console.WriteLine(error);
                        break;
                }
            } while (!nextQ);


            nextQ = false;
            if (player.hunger <= 3)
            {
                Console.WriteLine("Option 4:\n" +
                    "Ignore stomach\n" +
                    "Make a joke about stomach");
                do
                {
                    switch (response)
                    {
                        case "ignore stomach":
                        case "ignore":
                            IgnoreStomach();
                            nextQ = true;
                            break;
                        case "make a joke about stomach":
                        case "make joke about stomach":
                        case "make a joke":
                        case "make joke":
                            JokeStomach();
                            nextQ = true;
                            break;
                        default:
                            Console.WriteLine(error);
                            break;
                    }
                } while (!nextQ);

                nextQ = false;
            }

            if (player.isSick)
            {
                Console.WriteLine("Option 5:\n" +
                    "Resist the urge to puke\n" +
                    "Puke in a trash can");
                do
                {
                    switch (response)
                    {
                        case "resist the urge to puke":
                        case "resist urge to puke":
                        case "resist urge":
                            RepressPuke();
                            nextQ = true;
                            break;
                        case "puke in trash can":
                        case "puke in trash":
                        case "puke":
                            Puke();
                            nextQ = true;
                            break;
                        default:
                            Console.WriteLine(error);
                            break;
                    }
                } while (!nextQ);
            }
        }








        void FunFact()
        {

        }

        void TopicalJoke()
        {

        }

        void TechnicalDetails()
        {

        }

        void Pictures()
        {

        }

        void Demonstration()
        {

        }

        void Poll()
        {

        }

        void IgnoreStomach()
        {

        }

        void JokeStomach()
        {

        }

        void Puke()
        {

        }

        void RepressPuke()
        {

        }

        void ImproviseSong()
        {

        }

        void OtherThing()
        {

        }

    }
}
