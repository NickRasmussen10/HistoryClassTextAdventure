using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    class Bus : Room
    {
        string storeResponse;

        public Bus(Player p)
        {
            player = p;
        }

        public Player PlayBus()
        {
            bool isStanding;
            isStanding = SitOrStand();
            Entertain();
            BusStart(isStanding);
            CandyBar(isStanding);
            Console.WriteLine("The bus eventually reaches it's next stop, and you run as fast as you can to class.");
            return player;
        }



        bool SitOrStand()
        {
            if(player.timeLeft >= 5)
            {
                Console.Write("You make it to the bus stop just in time.\n");
            }
            else
            {
                Console.Write("You make it to the bus stop on time.\n");
            }
            Console.Write("Looking around, you notice that the only available seat is next to a man who looks violently ill.\n" +
                "You look up to see a vacant section of the railing.");
            player.PrintPlayer();

            do
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                response = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                switch (response)
                {
                    case "sit":
                        Program.ClearScreen();
                        Console.WriteLine("You take the seat and lean as far away from the sickly man as you can.");
                        Random r = new Random();
                        int sick = r.Next(0, 1);
                        player.isSick = sick == 0 ? true : false;
                        player.timeLeft -= 15;
                        return false;
                    case "grab railing":
                        Program.ClearScreen();
                        Console.WriteLine("You wrap your fingers around the railing and prepare for the bus to start moving.");
                        player.timeLeft -= 15;
                        return true;
                    default:
                        Console.WriteLine(error);
                        break;
                }

            } while (response != "sit" && response != "grab railing");
            return false;
        }

        void Entertain(){
            Console.WriteLine("As you wait for everyone else to get on the bus, you start getting bored.");
            player.PrintPlayer();
            bool entertained = false;

            do
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                response = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                switch (response)
                {
                    case "use bowl":
                        Program.ClearScreen();
                        if (player.CheckInventory("bowl")){
                            Console.WriteLine("You take out the bowl and start playing with it.\n" +
                                "As you spin the bowl around in your fingers, the other passengers look at you in confusion.");
                            entertained = true;
                            player.timeLeft -= 45;
                            storeResponse = "bowl";
                        }
                        else {
                            Console.WriteLine("You left the bowl at home.");
                        }
                        break;
                    case "study notes":
                        Program.ClearScreen();
                        if (player.CheckInventory("notes")){
                            Console.WriteLine("You take out your notes and try to memorize what you need to say for your presentation.\n" +
                                "Your notes are starting to make sense.");
                            player.confidence += 2;
                            player.timeLeft -= 45;
                            storeResponse = "notes";
                            entertained = true;
                        }
                        else{
                            Console.WriteLine("You left your notes at home.");
                        }
                        break;
                    case "use phone":
                        Program.ClearScreen();
                        Console.WriteLine("You take out your phone and start scrolling through Twitter.\n" + 
                            "A few of your friends have posted inpirational quotes about working hard.");
                        player.confidence --;
                        player.timeLeft -= 45;
                        storeResponse = "phone";
                        break;
                    default:
                        Console.WriteLine(error);
                        break;
                }
            } while (!entertained); //ARE YOU NOT ENTERTAINED?
        }

        void BusStart(bool isStanding){
            Console.Write("As you ");
            switch (storeResponse)
	        {
                case "bowl":
                    Console.Write("play with the bowl, ");
                    break;
                case "notes":
                    Console.Write("study your notes, ");
                    break;
                case "phone":
                    Console.Write("browse Twitter, ");
                    break;
		        default:
                    break;
	        }
            Console.Write(" you barely notice the doors close and the bus suddnely jerks forward.\n");
            if(isStanding && storeResponse != "phone"){
                Console.Write("The change in momentum throws you to the ground and ");
                if(storeResponse == "bowl"){
                    Console.Write(" you lose your grip on the bowl. It shatters on the floor.\n");
                    player.RemoveItem("bowl");
                }
                else{
                    Console.Write(" your notes scatter across the bus floor.\n");
                    player.RemoveItem("notes");
                }
                player.confidence -= 2;
                player.timeLeft -= 10;
            }
        }

        void CandyBar(bool isStanding){
            if(isStanding && storeResponse != "phone"){
                Console.WriteLine("As you lie among the mess you've made, you notice an old candy bar underneath one of the seats.\n" + 
                    "It looks like it's been stepped on, and one end of the wrapper is ripped apart.");
            }
            else{
                Console.WriteLine("As you wait for the bus to get to campus, you notice an old candy bar underneath one of the seats.\n" + 
                    "It looks like it's been stepped on, and one end of the wrapper is ripped apart.");
            }

            player.PrintPlayer();

            bool keepGoing = false;
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                response = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                switch (response)
	            {
                    case "eat candy bar":
                        Program.ClearScreen();
                        Console.WriteLine("As you grab the candy bar, a bit of melted choclate lightly adheres it to the floor.\n" + 
                            "The candy bar finally gives, and you eat it. It tastes like it's been there for a long time.\n" +
                            "You look up and see that a few passengers have been filming you, most with a disgusted look on their face.\n" + 
                            "Toward the back of the bus, you think you can hear someone dry heaving.");
                        player.hunger += 2;
                        player.timeLeft -= 120;
                        player.isSick = true;
                        keepGoing = true;
                        break;
                    case "do nothing":
                        Program.ClearScreen();
                        if (isStanding && storeResponse != "phone"){
                            Console.WriteLine("You silently lay among the mess you've made until the bus gets to campus.");
                            player.timeLeft -= 120;
                            keepGoing = true;
                        }
                        else{
                            Console.Write("You make a disgusted face at the candy bar, and go back to ");
                            switch (storeResponse)
	                        {
                                case "bowl":
                                    Console.Write("playing with the bowl.\n");
                                    break;
                                case "notes":
                                    Console.Write("studying.\n");
                                    break;
                                case "phone":
                                    Console.Write("browsing Twitter.\n");
                                    break;
		                        default:
                                    break;
	                        }
                            player.timeLeft -= 120;
                            keepGoing = true;
                        }
                        break;
                    case "pick up notes":
                        Program.ClearScreen();
                        if (isStanding && storeResponse == "notes"){
                            Console.WriteLine("You sit up, disgusted by the candy bar, and begin to gather your notes.\n" + 
                                "They've gone everywhere, and most have gotten damp and dirty from the bus floor.\n" + 
                                "By the time you've gathered them all, the bus has reached campus.");
                            if (player.CheckInventory("notes"))
                            {
                                player.AddItem("notes");
                            }
                            player.timeLeft -= 120;
                            keepGoing = true;
                        }
                        else{
                            Console.WriteLine(error);
                        }
                        break;
		            default:
                        Console.WriteLine(error);
                        break;
	            }
            }while(!keepGoing);
        }
    }
}
