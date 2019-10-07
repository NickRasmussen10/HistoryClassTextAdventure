using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    class Bedroom : Room
    {
        bool hasStudied = false;
        bool hasEaten = false;
        public Bedroom(Player p)
        {
            player = p;
        }

        public Player PlayBedroom()
        {
            StartText();
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                response = Console.ReadLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;

                switch (response)
                {
                    case "go to notes":
                        if (!hasStudied)
                        {
                            Program.ClearScreen();
                            Notes();
                        }
                        else { Console.WriteLine("You've already checked your notes."); }
                        if (!hasEaten)
                        {
                            ClassNotification();
                        }
                        break;
                    case "go to kitchen":
                        if (!hasEaten)
                        {
                            Program.ClearScreen();
                            Kitchen();
                        }
                        else { Console.WriteLine("You've already eaten breakfast."); }
                        if (!hasStudied)
                        {
                            ClassNotification();
                        }
                        break;
                    case "go to bus":
                        if(!hasStudied && !hasEaten)
                        {
                            if (!hasEaten && !hasStudied)
                            {
                                Console.WriteLine("You skip breakfast and leave your notes as you head to the bus stop.");
                                player.confidence -= 2;
                                player.hunger -= 2;
                            }
                            else if (!hasEaten)
                            {
                                Console.WriteLine("Skipping breakfast, you leave your apartment and head for the bus stop.");
                            }
                            else if (!hasStudied)
                            {
                                Console.WriteLine("Without looking at your notes, you leave your apartment and head for the bus stop.");
                            }
                            else
                            {
                                Console.WriteLine("You head for the bus stop.");
                            }
                        }
                        player.timeLeft -= 30;
                        break;
                    default:
                        Console.WriteLine(error);
                        break;
                }
            }
            while (response != "go to bus");

           
            return player;
        }


        void StartText()
        {
            Console.WriteLine("You awaken to a blaring alarm and the realization that you're running late to History of Digital Graphics. \n" +
                "You see your notes across the room and suddenly remember; your History of Digital Graphics presentation is today! \n" +
                "You glace over at the kitchen, and your stomach grumbles. \n" +
                "You check the time on your phone: 6:20. Your bus leaves soon.");
            player.PrintPlayer();
        }

        void Notes()
        {
            if (!player.CheckInventory("notes"))
            {
                player.AddItem("notes");
            }
            Console.WriteLine("You stammer over to your notes and start frantically reading them over. \n" +
                "To your dismay, it seems like most are at the halfway point between incomplete and illegible.\n" +
                "You also notice that the presentation open on your laptop is only half done.");
            player.timeLeft -= 15;
            player.PrintPlayer();

            do
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                response = Console.ReadLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;

                switch (response)
                {
                    case "study notes":
                        Program.ClearScreen();
                        Study();
                        break;
                    case "finish presentation":
                        Program.ClearScreen();
                        Presentation();
                        break;
                    case "take notes":
                        Program.ClearScreen();
                        Console.WriteLine("Without even attempting to read them, you gather your notes.");
                        break;
                    default:
                        Console.WriteLine(error);
                        break;
                }
            } while (response != "study notes" && response != "finish presentation" && response != "take notes");
            if (!player.CheckInventory("notes"))
            {
                player.AddItem("notes");
            }

        }

        void Study()
        {
            Console.WriteLine("Like a cryptographer cracking a code, you attempt to decipher the scribblings you left yourself");
            player.confidence++;
            if (!hasEaten)
            {
                player.hunger -= 2;
            }
            player.timeLeft -= 120;
            hasStudied = true;
        }

        void Presentation()
        {
            Console.WriteLine("Glancing at your notes, you attempt to assemble a few coherent slides");
            player.confidence += 2;
            if (!hasEaten)
            {
                player.hunger -= 2;
            }
            player.timeLeft -= 180;
            hasStudied = true;
        }

        void Kitchen()
        {
            player.timeLeft -= 15;

            bool hasPeeledOrange = false;
            bool milkInBowl = false;
            bool cerealInBowl = false;

            Console.WriteLine("Clutching your abdomen, you head to the kitchen and peruse your options.\n" +
                "In the cabinets, you find a box of Lucky Charms, an orange, and a bowl\n" +
                "In the refrigerator, you see a carton of milk.");
            player.PrintPlayer();
            do
            {
                while (!hasEaten)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    response = Console.ReadLine();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    response = response.ToLower();

                    switch (response)
                    {
                        case "eat bowl":
                            Console.WriteLine("You pick up the ceramic bowl and attempt to take a bite.\n" +
                                "It tastes like low IQ. Were those cracks always there?");
                            player.timeLeft -= 15;
                            break;
                        case "take bowl":
                            if (!player.CheckInventory("bowl"))
                            {
                                player.AddItem("bowl");
                            }
                            Console.WriteLine("You pick up the bowl.");
                            player.timeLeft -= 10;
                            break;
                        case "eat orange":
                            Program.ClearScreen();
                            if (hasPeeledOrange)
                            {
                                Console.WriteLine("You eat the orange.");
                                player.timeLeft -= 60;
                            }
                            else
                            {
                                Console.WriteLine("You struggle to eat the orange. It tastes bitter and it's hard to chew.\n" +
                                    "Eventually you manage, and as you eat you passively wonder if maybe you should have peeled it first.");
                                player.timeLeft -= 90;
                            }
                            hasEaten = true;
                            if (!hasStudied)
                            {
                                player.confidence -= 2;
                            }
                            player.hunger++;
                            break;
                        case "peel orange":
                            Console.WriteLine("You dig into the orange's skin. It sprays acidic juices at you.");
                            player.timeLeft -= 30;
                            hasPeeledOrange = true;
                            break;
                        case "eat lucky charms":
                            Program.ClearScreen();
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
                            if (!hasStudied)
                            {
                                player.confidence -= 2;
                            }
                            break;
                        case "pour lucky charms":
                            Console.WriteLine("You grab the box and begin to tilt it.\n" +
                                "A series of hundreds of tiny clinking sounds erupts as the cereal hits the floor and disperses.\n" +
                                "You stare blankly at the mess you've made.");
                            player.timeLeft -= 15;
                            break;
                        case "pour lucky charms in bowl":
                            Console.WriteLine("You pour a healthy portion of Lucky Charms in the bowl.");
                            cerealInBowl = true;
                            player.timeLeft -= 15;
                            break;
                        case "drink milk":
                            Program.ClearScreen();
                            Console.WriteLine("You open the milk carton and start chugging like the monster you are.\n" +
                                "Your roommate walks in and begins to verbally berate you.");
                            player.hunger++;
                            player.timeLeft -= 15;
                            hasEaten = true;
                            if (!hasStudied)
                            {
                                player.confidence -= 2;
                            }
                            break;
                        case "pour milk":
                            Console.WriteLine("You pick up the milk carton and start pouring it out into the fridge.\n" +
                                "Milk splashes and sloshes across every shelf and drawer of the fridge.\n" +
                                "In your head, you silently nickname the disaster \"Calcium Falls\".");
                            player.timeLeft -= 15;
                            break;
                        case "pour milk in bowl":
                            Console.WriteLine("You grab the milk and pour it in the bowl.");
                            milkInBowl = true;
                            player.timeLeft -= 15;
                            break;
                        default:
                            Console.WriteLine(error);
                            break;
                    }

                }

            } while (!hasEaten);

            if (response == "drink milk")
            {
                player.PrintPlayer();
                bool fightOver = false;
                do
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    response = Console.ReadLine();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    switch (response)
                    {
                        case "fight roommate":
                            Program.ClearScreen();
                            Console.WriteLine("You slam the milk into the ground and let out a war cry before charging at your roommate. \n" +
                                "They look shocked and begin to cower back, but it's too late. You jump forward and tackle them into a table with your full body weight.\n" +
                                "You both crash through the table. In your blood-curdling rage, you hardly even notice. ");
                            fightOver = true;
                            player.timeLeft -= 15;
                            break;
                        case "yell back":
                            Program.ClearScreen();
                            Console.WriteLine("You return the verbal barrage until both of you are simply screaming incoherent noises at each other.\n" +
                                "You make wild hand gestures, paying no attention to the fact that you are still holding the milk. \n" +
                                "By the end of the argument, milk has splattered across the entire apartment.");
                            player.timeLeft -= 45;
                            fightOver = true;
                            break;
                        case "throw milk at roommate":
                            Program.ClearScreen();
                            Console.WriteLine("You chuck the carton of milk at your roommate as hard as you can.\n" +
                                "The milk makes perfect contact with their temple and spills all over them and the floor. \n" +
                                "They slip and fall in the milk puddle.");
                            player.timeLeft -= 30;
                            fightOver = true;
                            break;
                        case "run away":
                            Program.ClearScreen();
                            Console.WriteLine("You hiss at them and run back into your bedroom.");
                            fightOver = true;
                            player.timeLeft -= 10; 
                            break;
                        default:
                            Console.WriteLine(error);
                            break;
                    }
                } while (!fightOver);
            }
        }

        void ClassNotification()
        {
            string printStr = "Vrrrrr...vrrrrr...\n" +
                "Your phone lights up in your pocket. You take it out and see a notification. \n\n" +
                "HISTORY OF DIGITAL GRAPHICS: ";
            if (!hasStudied)
            {
                printStr += "PRESENTATION DUE TODAY";
            }
            else if (!hasEaten)
            {
                printStr += "6:00 PM";
            }

            printStr += "\n\nYou need to get to the bus pronto ";
            Console.Write(printStr);
            if (!hasEaten)
            {
                Console.Write("but your stomach lets out a wretched grrrrRRRRRRR as you pack up your notes.");
            }
            else if (!hasStudied)
            {
                Console.Write("but you glace over your notes and realize you can't even decipher even half of them.");
            }


            player.PrintPlayer();
        }
    }
}
