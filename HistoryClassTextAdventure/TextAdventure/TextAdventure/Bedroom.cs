using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    class Bedroom
    {
        Player player;
        string response = "";

        public Bedroom(Player p)
        {
            player = p;
        }

        public Player PlayBedroom()
        {
            StartText();
            do
            {
                response = Console.ReadLine();
                if(response != "go to notes" && response != "go to kitchen")
                {
                    Console.WriteLine("Whoops! Looks like I have no clue what you mean!");
                }
            }
            while (response != "go to notes" && response != "go to kitchen");

            switch (response)
            {
                case "go to notes":
                    ClearScreen();
                    Notes();
                    break;
                case "go to kitchen":
                    ClearScreen();
                    Kitchen();
                    break;
                default:
                    break;
            }

            ClearScreen();
            ClassNotification();

            return player;
        }


        void StartText()
        {
            Console.WriteLine("You wake up to find out you're running late. \n" +
                "You see your notes across the room and suddenly remember; your History of Digital Graphics presentation is today!. \n" +
                "You glace over at the kitchen, and your stomach grumbles. ");
            player.PrintPlayer();
        }

        void Notes()
        {
            player.AddItem("notes");
            Console.WriteLine("You stammer over to your notes and start frantically reading them over. \n" +
                "To your dismay, it seems like most are at the halfway point between incomplete and illegible.\n" +
                "You also notice that the presentation open on your laptop is only half done.");
            player.PrintPlayer();

            do
            {
                response = Console.ReadLine();
            } while (response != "study notes" && response != "finish presentation");

            switch (response)
            {
                case "study notes":
                    ClearScreen();
                    Study();
                    break;
                case "finish presentation":
                    ClearScreen();
                    Presentation();
                    break;
                default:
                    break;
            }
        }

        void Study()
        {
            Console.WriteLine("Like a cryptographer cracking a code, you attempt to decipher the scribblings of your past self");
            player.SetConfidence(5);
            player.SetHunger(2);
        }

        void Presentation()
        {
            Console.WriteLine("Glancing at your notes, you attempt to assemble a few coherent slides");
            player.SetConfidence(4);
            player.SetHunger(2);
        }

        void Kitchen()
        {

        }

        void ClassNotification()
        {
            Console.WriteLine("Vrrrrr...vrrrrr...\n" +
                "Your phone lights up in your pocket. You take it out and see a notification. \n" +
                "HISTORY OF DIGITAL GRAPHICS: 15 MINUTES");
            player.PrintPlayer();
        }




        void ClearScreen()
        {
            for(int i = 0; i < 100; i++)
            {
                Console.WriteLine();
            }
        }
    }
}
