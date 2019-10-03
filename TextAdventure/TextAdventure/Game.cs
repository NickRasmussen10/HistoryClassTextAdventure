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
        public Game()
        {
            player = new Player(new List<string>(), 3, 3);
            player.AddItem("phone");
            bedroom = new Bedroom(player);
        }

        public void PlayGame()
        {
            player = bedroom.PlayBedroom();
        }
    }
}
