using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    class Classroom : Room
    {
        Random rng;
        bool lastWasGood = false;

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
                Console.WriteLine("You enter the classroom late, and Professor Kahn glares at you as you set up for your presentation.");
                player.confidence--;
            }
            PlayPresentation();
            return player;
        }

        void PlayPresentation()
        {
            Console.WriteLine("You stand at the front of the class and try to figure out how to get through this presentation.\n" +
                "First things first - you need to grab the class's attention.");
            Console.WriteLine("Start option: \n" +
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
                    case "fun fact":
                    case "fact":
                        lastWasGood = FunFact();
                        nextQ = true;
                        break;
                    case "tell a topical joke":
                    case "tell topical joke":
                    case "tell a joke":
                    case "tell joke":
                    case "joke":
                        lastWasGood = TopicalJoke();
                        nextQ = true;
                        break;
                    default:
                        Console.WriteLine(error);
                        break;
                }
            } while (!nextQ);

            nextQ = false;
            Console.WriteLine("Info option: \n" +
                "Talk about technical details\n" +
                "Show pictures");
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
                        lastWasGood = TechnicalDetails();
                        nextQ = true;
                        break;
                    case "show pictures":
                    case "show":
                    case "pictures":
                        lastWasGood = Pictures();
                        nextQ = true;
                        break;
                    default:
                        Console.WriteLine(error);
                        break;
                }
            } while (!nextQ);

            nextQ = false;
            Console.WriteLine("Bored option:\n" +
                "Demonstration\n" +
                "Class poll");
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                response = Console.ReadLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                switch (response)
                {
                    case "demonstration":
                        lastWasGood = Demonstration();
                        nextQ = true;
                        break;
                    case "class poll":
                    case "poll":
                        lastWasGood = Poll();
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
                Console.WriteLine("Hungry option:\n" +
                    "Ignore your stomach\n" +
                    "Make a joke about your stomach");
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
                            lastWasGood = IgnoreStomach();
                            nextQ = true;
                            break;
                        case "make a joke about your stomach":
                        case "make a joke about stomach":
                        case "make joke about your stomach":
                        case "make joke about stomach":
                        case "make a joke":
                        case "make joke":
                        case "joke":
                            lastWasGood = JokeStomach();
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
                Console.WriteLine("Sick option:\n" +
                    "Resist the urge to puke\n" +
                    "Puke in a trash can");
                do
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    response = Console.ReadLine();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    switch (response)
                    {
                        case "resist the urge to puke":
                        case "resist urge to puke":
                        case "resist urge":
                        case "resist puke":
                        case "resist":
                            lastWasGood = RepressSneeze();
                            nextQ = true;
                            break;
                        case "puke in trash can":
                        case "puke in trash":
                        case "puke in can":
                        case "puke":
                            lastWasGood = Sneeze();
                            nextQ = true;
                            break;
                        default:
                            Console.WriteLine(error);
                            break;
                    }
                } while (!nextQ);
                nextQ = false;
            }

            Console.WriteLine("End option\n" +
                "Improvise a song and dance\n" +
                "Other option");
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
                    case "song and dance":
                    case "song":
                    case "dance":
                        lastWasGood = ImproviseSong();
                        nextQ = true;
                        break;
                    case "other option":
                        lastWasGood = OtherThing();
                        nextQ = true;
                        break;
                    default:
                        Console.WriteLine(error);
                        break;
                }
            } while (!nextQ);
        }







        //confident
        bool FunFact()
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
                return true;
            }
            else
            {
                //bad outcome
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\"Did you know that...uh...computers existed in the '80s?\"");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Yikes.");
                player.grade -= 3;
                return false;
            }
        }

        //not confident
        bool TopicalJoke()
        {

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\"What would you call a World War 2 game released for the best selling computer of all time?\"\n\n\n\n" +
                "\"The Great War Encore for Commodore 64.\"");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("You get a few laughs.");
            player.grade += 3;
            return true;

        }

        //confident
        bool TechnicalDetails()
        {
            int outcome = rng.Next(0, 11) * player.confidence;
            if (outcome > 20)
            {
                //good outcome
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\"'80s computers were limited by their low memory and slow processing speeds.\"");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("You professor silently jots down a note. It seems like it's positive");
                player.grade += 5;
                return true;
            }
            else
            {
                //bad outcome
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("So yeah computers were like pretty crappy back then.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("You professor jots down notes. Like a lot of notes. Theres no way that many notes could be positive feedback.");
                player.grade -= 3;
                return false;
            }
        }

        //not confident
        bool Pictures()
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
                return false;
            }
            else
            {
                //good outcome
                Console.WriteLine("You pull up a few pictures of the Apple II and Tandy TRS-80. \n" +
                    "At least, you think that's the Apple II and the Tandy TRS-80. All of these 80s computers look exactly the same." +
                    "Regardless, no one seems to be able to tell the difference.");
                player.grade += 3;
                return true;
            }
        }

        //confident
        bool Demonstration()
        {
            int outcome = rng.Next(0, 11) * player.confidence;
            if (outcome > 20)
            {
                //good outcome
                Console.WriteLine("You bring up an emulator of Zork and start polling the class for actions.\n" +
                    "Hopefully they're engaged, because this part of our presentation will be pretty awkward if they aren't.");
                player.grade += 5;
                return true;
            }
            else
            {
                //bad outcome
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\"I will now demonstrate what games sounded like in the '80s...beep boop zing bop swoosh...\"");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\"In what parallel universe would that have been a good idea?\" you think to yourself as your classmates hold back laughter.");
                player.grade -= 3;
                return false;
            }
        }

        //not confident
        bool Poll()
        {
            int outcome = rng.Next(0, 11) * player.confidence;
            if(outcome < 10)
            {
                //bad outcome
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\"Who here has seen a video before...uh, video game before. Who plays video games?\"");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("A few people half-heartedly raise they're hands while avoiding eye contact.");
                player.grade -= 3;
                return false;
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
                return true;
            }
        }

        bool IgnoreStomach()
        {
            int outcome = rng.Next(0, 11) * player.confidence;
            if (outcome > 20)
            {
                //good outcome
                Console.WriteLine("Without skipping a beat, you power through the abdominal protest and carry on.\n" +
                    "A few classmates in the front row seem to have noticed, but all in all it didn't create much distraction.");
                player.grade += 5;
                return true;
            }
            else
            {
                //bad outcome
                Console.WriteLine("You stare blankly ahead for a full 15 seconds while trying to decide what to do.\n" +
                    "It only gets weirder when you continue talking as if nothing happened.");
                player.grade -= 3;
                player.confidence -= 2;
                return false;
            }
        }

        bool JokeStomach()
        {
            int outcome = rng.Next(0, 11) * player.confidence;
            if(outcome < 10)
            {
                //bad outcome
                return false;
            }
            else
            {
                //good outcome
                return true;
            }
        }

        bool RepressSneeze()
        {
            int outcome = rng.Next(0, 11) * player.confidence;
            if (outcome > 20)
            {
                //good outcome
                Console.WriteLine("Your presentation stops dead for a few moments as your face contorts into the beginnings of a sneeze, but you manage to stop it.");
                return true;
            }
            else
            {
                //bad outcome
                Console.WriteLine("You presentation stops dead as your face contorts into the pre-sneeze expression. You try to fight it, but it only makes it worse.\n" +
                    "As the sneeze forces it's way through, you instictively jerk your head forward and slam into your keyboard. \n" +
                    "The presentation closes, and it takes several minutes to get it back up, and some of the next has become jibberish.");
                player.confidence--;
                player.grade -= 3;
                return false;
            }
        }


        bool Sneeze()
        {
            int outcome = rng.Next() * player.confidence;
            if(outcome < 10)
            {
                //bad outcome
                Console.WriteLine("You let yourself sneeze a little too freely, and end up smashing your head into you keyboard. \n" +
                    "You get the presentation back up within a few minutes, but a lot of the text has become jibberish.");
                player.grade -= 3;
                return false;
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
                return true;
            }
        }

        //confident
        bool ImproviseSong()
        {
            int outcome = rng.Next(0, 11) * player.confidence;
            if (outcome > 20)
            {
                //good outcome
                Console.ForegroundColor = ConsoleColor.Magenta;

                Console.ForegroundColor = ConsoleColor.White;
                player.grade += 5;
                return true;
            }
            else
            {
                //bad outcome
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\"Old McGygax made a game, D and D...and D\"");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("That didn't go anywhere close to as well as you thought it would.");
                player.grade -= 3;
                return false;
            }
        }

        //not confident
        bool OtherThing()
        {
            return false;
        }

    }
}
