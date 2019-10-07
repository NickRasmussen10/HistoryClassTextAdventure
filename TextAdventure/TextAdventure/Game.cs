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
        Classroom classroom;
        public Game()
        {
            player = new Player(new List<string>(), 3, 3);
            player.AddItem("phone");
            Program.ClearScreen();
            bedroom = new Bedroom(player);
            bus = new Bus(player);
            classroom = new Classroom(player);
        }

        public void PlayGame()
        {
            player = bedroom.PlayBedroom();
            player = bus.PlayBus();
            player = classroom.PlayClassroom();
        }
    }
}
