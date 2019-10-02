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
            player.timeLeft -= 15;
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
            Console.WriteLine("Like a cryptographer cracking a code, you attempt to decipher the scribblings you left yourself");
            player.confidence++;
            player.hunger--;
            player.timeLeft -= 120;
        }

        void Presentation()
        {
            Console.WriteLine("Glancing at your notes, you attempt to assemble a few coherent slides");
            player.confidence += 2;
            player.hunger--;
            player.timeLeft -= 180;
        }

        void Kitchen()
        {
            player.timeLeft -= 15;

            bool hasEaten = false;
            bool hasPeeledOrange = false;
            bool milkInBowl = false;
            bool cerealInBowl = false;

            Console.WriteLine("Clutching your abdomen, you head to the kitchen.\n" +
                "Perusing your options, you check through the kitchen.\n" +
                "In the cabinets, you find a box of Lucky Charms, an orange, and a bowl\n" +
                "In the refrigerator, you see a carton of milk.");
            player.PrintPlayer();
            do
            {
                while (!hasEaten)
                {
                    response = Console.ReadLine();
                    switch (response)
                    {
                        case "eat bowl":
                            Console.WriteLine("You pick up the ceramic bowl and attempt to take a bite.\n" +
                                "It tastes like low IQ. Were those cracks always there?");
                            player.timeLeft -= 15;
                            break;
                        case "take bowl":
                            player.AddItem("bowl");
                            Console.WriteLine("You pick up the bowl.");
                            player.timeLeft -= 10;
                            break;
                        case "eat orange":
                            if (hasPeeledOrange)
                            {
                                Console.WriteLine("You eat the orange.");
                                player.timeLeft -= 60;
                            }
                            else
                            {
                                Console.WriteLine("You struggle to eat the orange. It tastes bitter and it's hard to chew.\n" +
                                    "Eventually you manage, and as you eat you passively wonder if maybe you should have peeled it first.");
                            }
                            hasEaten = true;
                            player.hunger++;
                            break;
                        case "peel orange":
                            Console.WriteLine("You dig into the orange's skin. It sprays acidic juices at you.");
                            hasPeeledOrange = true;
                            break;
                        case "eat Lucky Charms":
                            if (!cerealInBowl)
                            {
                                Console.WriteLine("You open the box of Lucky Charms and pour them straight into your mouth like a savage animal.\n" +
                                    "Your roommate walks in, sees you, and quietly leaves.");
                                player.hunger += 2;
                                player.timeLeft -= 60;
                            }
                            else if (!milkInBowl)
                            {
                                Console.WriteLine("You crunch down on the Lucky Charms and wish you had remembered the milk.");
                                player.hunger += 2;
                                player.timeLeft -= 90;
                            }
                            else
                            {
                                Console.WriteLine("You eat the Lucky Charms.");
                                player.hunger += 3;
                                player.timeLeft -= 90;
                            }
                            hasEaten = true;
                            break;
                        case "pour Lucky Charms":
                            Console.WriteLine("You grab the box and begin to tilt it.\n" +
                                "A series of hundreds of tiny clinking sounds erupts as the cereal hits the floor and disperses.\n" +
                                "You stare blankly at the mess you've made.");
                            break;
                        case "pour Lucky Charms in bowl":
                            Console.WriteLine("You pour a healthy portion of Lucky Charms in the bowl.");
                            cerealInBowl = true;
                            break;
                        case "drink milk":
                            Console.WriteLine("You open the milk carton and start chugging like the monster that you are.\n" +
                                "Your roommate walks in and begins to verbally berate you.");
                            hasEaten = true;
                            break;
                        case "pour milk":
                            Console.WriteLine("You pick up the milk carton and start pouring it out into the fridge.\n" +
                                "Milk splashes and sloshes across every shelf and drawer of the fridge.\n" +
                                "In your head, you silently nickname the disaster \"Calcium Falls\".");
                            break;
                        case "pour milk in bowl":
                            Console.WriteLine("You grab the milk and pour it in the bowl.");
                            milkInBowl = true;
                            break;
                        default:
                            break;
                    }
                }

            } while (response != "eat bowl" && response != "take bowl" && 
                    response != "eat orange" && response != "peel orange" &&
                    response != "eat Lucky Charms" && response != "pour Lucky Charms" && response != "pur Lucky Charms in bowl" &&
                    response != "drink milk" && response != "pour milk" && response != "pour milk in bowl" &&
                    !hasEaten);


            player.confidence--;
        }

        void ClassNotification()
        {
            Console.WriteLine("Vrrrrr...vrrrrr...\n" +
                "Your phone lights up in your pocket. You take it out and see a notification. \n" +
                "HISTORY OF DIGITAL GRAPHICS: PRESENTATION DUE TODAY");
            Console.Write("You need to get to the bus pronto");
            if(player.hunger < 3)
            {
                Console.Write(", but your stomach lets out a wretched grrrrRRRRRRR as you pack up your notes.");
            }
            else if(player.confidence < 3)
            {
                Console.Write(", but you glace over your notes and realize you can't even decipher about half of them.");
            }


            player.PrintPlayer();
        }




        void ClearScreen()
        {
            for(int i = 0; i < 7; i++)
            {
                Console.WriteLine();
            }
        }
    }
}
