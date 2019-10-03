using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    class Bus : Room
    {
        public Bus(Player p)
        {
            player = p;
        }

        public Player PlayBus()
        {
            bool isStanding;
            isStanding = SitOrStand();

            return player;
        }

        bool SitOrStand()
        {
            Console.WriteLine("You make it to the bus just as the doors are closing.\n" +
                "Looking around, you notice that the only available seat is next to a man who looks violently ill.\n" +
                "You look up to see a vacant section of the railing.");

            do
            {
                response = Console.ReadLine();
                switch (response)
                {
                    case "sit":
                        Console.WriteLine("You take the seat and lean as far away from the sickly man as you can.");
                        break;
                    case "stand":
                        Console.WriteLine("You wrap your fingers around the railing and prepare for the bus to start moving.");
                        break;
                    default:
                        Console.WriteLine(error);
                        break;
                }

            } while (response != "sit" && response != "stand");
            return false;
        }
    }
}
