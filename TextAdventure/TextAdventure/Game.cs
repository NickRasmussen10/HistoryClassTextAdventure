using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    class Game
    { 
        Player player;
        Bedroom bedroom;
        Bus bus;
        public Game()
        {
            player = new Player(new List<string>(), 3, 3);
            player.AddItem("phone");
            bedroom = new Bedroom(player);
            bus = new Bus(player);
        }

        public void PlayGame()
        {
            player = bedroom.PlayBedroom();
            player = bus.PlayBus();
        }
    }
}
