using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Due_Date
{
    class Classroom : Room
    {
        Random rng;

        public Classroom(Player p)
        {
            player = p;
            rng = new Random();
        }

        public Player PlayClassroom()
        {
            if (player.timeLeft > 0)
            {
                Console.WriteLine("You enter the classroom just in time, and immediately set up for your presentation.");
            }
            else
            {
                Console.WriteLine("You enter the classroom late, and Rose glares at you as you set up for your presentation.");
                player.confidence--;
            }
            PlayPresentation();

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Final Grade: ");
            if(player.grade == 101)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("A+");
            }
            else if (player.grade >= 90)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Grade: A");
            }
            else if (player.grade >= 80)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Grade: B");
            }
            else if (player.grade >= 70)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Grade: C");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Grade: F");
            }
            return player;
        }

        void PlayPresentation()
        {
            player.inPresentation = true;
            Console.WriteLine("You stand at the front of the class and try to figure out how to get through this presentation.\n" +
                "First things first - you need to grab the class's attention.");
            Console.WriteLine(" - Tell a fun fact \n" +
                " - Tell a topical joke");
            bool nextQ = false;
            player.PrintPlayer();
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
                    case "fun fact":
                    case "fact":
                        Program.ClearScreen();
                        FunFact();
                        nextQ = true;
                        break;
                    case "tell a topical joke":
                    case "tell topical joke":
                    case "tell a joke":
                    case "tell joke":
                    case "joke":
                        Program.ClearScreen();
                        TopicalJoke();
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
                Console.WriteLine("Just as your presentation is kicking off, you feel a starved grumbling from deep within your gut.\n" +
                    "Glancing around, you notice half a sandwich relatively intact lays near the top of the garbage can.");
                Console.WriteLine(" - Ignore your stomach\n" +
                    " - Eat sandwich");
                player.PrintPlayer();
                do
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    response = Console.ReadLine();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    switch (response)
                    {
                        case "ignore your stomach":
                        case "ignore stomach":
                        case "ignore":
                            Program.ClearScreen();
                            IgnoreStomach();
                            nextQ = true;
                            break;
                        case "eat sandwich":
                        case "eat":
                        case "sandwich":
                            Program.ClearScreen();
                            EatSandwich();
                            nextQ = true;
                            break;
                        default:
                            Console.WriteLine(error);
                            break;
                    }
                } while (!nextQ);

                nextQ = false;
            }

            Console.WriteLine("With the introduction out of the way, it's time to get some substance into the presentation.");
            Console.WriteLine(" - Talk about technical details\n" +
                " - Show pictures");
            player.PrintPlayer();
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                response = Console.ReadLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                switch (response)
                {
                    case "talk about technical details":
                    case "talk about details":
                    case "talk details":
                    case "talk":
                        Program.ClearScreen();
                        TechnicalDetails();
                        nextQ = true;
                        break;
                    case "show pictures":
                    case "show":
                    case "pictures":
                        Program.ClearScreen();
                        Pictures();
                        nextQ = true;
                        break;
                    default:
                        Console.WriteLine(error);
                        break;
                }
            } while (!nextQ);

            nextQ = false;

            Console.WriteLine("It seems like you're losing the class's attention. You decide you need some audience interaction.");

            Console.WriteLine(" - Demonstration\n" +
                " - Class poll");
            player.PrintPlayer();
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                response = Console.ReadLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                switch (response)
                {
                    case "demonstration":
                        Program.ClearScreen();
                        Demonstration();
                        nextQ = true;
                        break;
                    case "class poll":
                    case "poll":
                        Program.ClearScreen();
                        Poll();
                        nextQ = true;
                        break;
                    default:
                        Console.WriteLine(error);
                        break;
                }
            } while (!nextQ);


            nextQ = false;

            if (player.isSick)
            {
                Console.WriteLine("You're in the middle of an important talking point when you feel an unmistakable sensation. A sneeze is brewing.");
                Console.WriteLine(" - Sneeze\n" +
                    " - Resist the urge to sneeze\n");
                player.PrintPlayer();
                do
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    response = Console.ReadLine();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    switch (response)
                    {
                        case "resist the urge to sneeze":
                        case "resist urge to sneeze":
                        case "resist urge":
                        case "resist seeze":
                        case "resist":
                            Program.ClearScreen();
                            RepressSneeze();
                            nextQ = true;
                            break;
                        case "sneeze":
                            Program.ClearScreen();
                            Sneeze();
                            nextQ = true;
                            break;
                        default:
                            Console.WriteLine(error);
                            break;
                    }
                } while (!nextQ);
                nextQ = false;
            }

            Console.WriteLine("You're finally nearing the finish line, time to end it with a bang.");

            Console.WriteLine(" - Improvise a song and dance\n" +
                " - Play a custom text adventure");
            player.PrintPlayer();
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                response = Console.ReadLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                switch (response)
                {
                    case "improvise a song and dance":
                    case "improvise song and dance":
                    case "improvise song":
                    case "improvise dance":
                    case "improvise":
                    case "song and dance":
                    case "song":
                    case "dance":
                        Program.ClearScreen();
                        ImproviseSong();
                        nextQ = true;
                        break;
                    case "play a custom text adventure":
                    case "play custom text adventure":
                    case "play text adventure":
                    case "play":
                        Program.ClearScreen();
                        TextAdventure();
                        nextQ = true;
                        break;
                    default:
                        Console.WriteLine(error);
                        break;
                }
            } while (!nextQ);
        }







        //confident
        void FunFact()
        {
            int outcome = rng.Next(0, 11) * player.confidence;
            if (outcome > 20)
            {
                //good outcome
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\"Did you know that a parody of Zork: The Great Underground Empire titled Pork: The Great Underground Sewer System released in 1988?\"");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("A few of your classmates lean forward with interested looks.");
                player.grade += 5;
            }
            else
            {
                //bad outcome
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\"Did you know that...uh...computers existed in the '80s?\"");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Yikes.");
                player.grade -= 3;
            }
        }

        //not confident
        void TopicalJoke()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\"What would you call a World War 2 game released for the best selling computer of all time?\"\n\n\n\n" +
                "\"The Great War Encore for Commodore 64.\"");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("You get a few laughs.");
            player.grade += 3;

        }

        //confident
        void TechnicalDetails()
        {
            int outcome = rng.Next(0, 11) * player.confidence;
            if (outcome > 20)
            {
                //good outcome
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\"'80s computers were limited by their low memory and slow processing speeds.\"");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Rose silently jots down a note. It seems like it's positive");
                player.grade += 5;
            }
            else
            {
                //bad outcome
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("So yeah computers were like pretty bad back then.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Rose jots down notes. Like a lot of notes. There's no way that many notes could be positive feedback.");
                player.grade -= 3;
            }
        }

        //not confident
        void Pictures()
        {
            int outcome = rng.Next(0, 11) * player.confidence;
            if (outcome < 30)
            {
                //bad outcome
                Console.WriteLine("You try to pull up a picture of Ultima, but accidentally click on one of the video links. Your computer was left on max volume.\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\"WHAT'S UP GUYS! IT'S YA BOI, EPICGAMER420 HERE COMIN' AT YA LIVE WITH ANOTHER ULTIMA VIDEO!\"");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("EpicGamer420 refuses to shut up as you panic click around the web browser. Eventually you just close the page and continue with the slides.");
                player.grade -= 3;
            }
            else
            {
                //good outcome
                Console.WriteLine("You pull up a few pictures of the Apple II and Tandy TRS-80. \n" +
                    "At least, you think that's the Apple II and the Tandy TRS-80. All of these 80s computers look exactly the same.\n" +
                    "Regardless, no one seems to be able to tell the difference.");
                player.grade += 3;
            }
        }

        //confident
        void Demonstration()
        {
            int outcome = rng.Next(0, 11) * player.confidence;
            if (outcome > 20)
            {
                //good outcome
                Console.WriteLine("You bring up a video of Dungeons of Daggorath and try to explain what's going on.\n" +
                    "The class loves it, because Dungeons of Daggorath is a very good game.");
                player.grade += 5;
            }
            else
            {
                //bad outcome
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\"I will now demonstrate what games sounded like in the '80s...beep boop zing bop swoosh...\"");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\"In what parallel universe would that have been a good idea?\" you think to yourself as your classmates hold back laughter.");
                player.grade -= 3;
            }
        }

        //not confident
        void Poll()
        {
            int outcome = rng.Next(0, 11) * player.confidence;
            if (outcome < 10)
            {
                //bad outcome
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\"Who here has seen a video before...uh, video game before. Who plays video games?\"");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("A few people half-heartedly raise their hands while avoiding eye contact.");
                player.grade -= 3;
            }
            else
            {
                //good outcome
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\"Who here has ever played Zork?\"");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("About a third of the class raises their hands.");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\"Well Zork is actually one of the earlier and most popular among a long line of text-based adventures.\"");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Hey, that wasn't too bad!");
                player.grade += 3;
            }
        }

        void IgnoreStomach()
        {
            int outcome = rng.Next(0, 11) * player.confidence;
            if (outcome > 20)
            {
                //good outcome
                Console.WriteLine("Without skipping a beat, you power through the abdominal protest and carry on.\n" +
                    "A few classmates in the front row seem to have noticed, but all in all it didn't create much distraction.");
                player.grade += 5;
                player.confidence++;
            }
            else
            {
                //bad outcome
                Console.WriteLine("You stare blankly ahead for a full 15 seconds while trying to decide what to do.\n" +
                    "It only gets weirder when you continue talking as if nothing happened.");
                player.grade -= 3;
                player.confidence--;
            }
        }

        void EatSandwich()
        {
            int outcome = rng.Next(0, 11) * player.confidence;
            if (outcome < 10)
            {
                //bad outcome
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\"no no no NO NO NO NO NO\"");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("There are audible protests as you reach into the garbage and fish out the sandwich.\n" +
                    "Unphased, you chomp down.");
                player.hunger += 3;
                player.confidence--;
            }
            else
            {
                //good outcome
                Console.WriteLine("An ungodly silence falls over the room as you grab the trash sandwich.\n" +
                    "Your presentation grinds to a halt and over 30 people watch you chow down on actual garbage.");
                player.hunger += 3;
                player.confidence += 2;
            }
        }

        void RepressSneeze()
        {
            int outcome = rng.Next(0, 11) * player.confidence;
            if (outcome > 20)
            {
                //good outcome
                Console.WriteLine("Your presentation stops dead for a few moments as your face contorts into the beginnings of a sneeze, but you manage to stop it.");
            }
            else
            {
                //bad outcome
                Console.WriteLine("Your presentation stops dead as your face contorts into the pre-sneeze expression. You try to fight it, but it only makes it worse.\n" +
                    "As the sneeze forces its way through, you instinctively jerk your head forward and slam into your keyboard. \n" +
                    "The presentation closes, and it takes several minutes to get it back up, and some of the text has become gibberish.");
                player.confidence--;
                player.grade -= 3;
            }
        }


        void Sneeze()
        {
            int outcome = rng.Next() * player.confidence;
            if (outcome < 10)
            {
                //bad outcome
                Console.WriteLine("You let yourself sneeze a little too freely, and end up smashing your head into your keyboard. \n" +
                    "You get the presentation back up within a few minutes, but a lot of the text has become gibberish.");
                player.grade -= 3;
            }
            else
            {
                //good outcome
                Console.WriteLine("You let out a booming");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n\"ACHOOOO\"\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("The sudden noise seems to have drawn the attention of a few classmates who had drifted off.");
                player.confidence++;
            }
        }

        //confident
        void ImproviseSong()
        {
            int outcome = rng.Next(0, 11) * player.confidence;
            if (outcome > 20)
            {
                //good outcome
                Console.WriteLine("You belt out a few references to 80s games in a way that somewhat rhymes while flailing your arms around.\n" + 
                    "It's monumentally awkward, but most of the class at least appreciates the effort.");
                player.grade += 5;
            }
            else
            {
                //bad outcome
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\"Old McGygax made a game, D and D...and D\"");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("That didn't go anywhere close to as well as you thought it would.");
                player.grade -= 3;
            }
        }

        //not confident
        void TextAdventure()
        {
            Console.WriteLine("You poll the class for actions as you play through a text adventure about the presentation you're currently giving.\n" +
                "The professor loves the text adventure so much that she gives you an A+");
            player.grade = 101;
        }
    }
}
