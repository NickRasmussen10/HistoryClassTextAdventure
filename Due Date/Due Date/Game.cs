using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Due_Date
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
            bedroom = new Bedroom(player);
            bus = new Bus(player);
            classroom = new Classroom(player);
        }

        public void PlayGame()
        {
            BigText();
            Console.ReadLine();
            Program.ClearScreen();
            player = bedroom.PlayBedroom();
            player = bus.PlayBus();
            player = classroom.PlayClassroom();
        }

        void BigText()
        {
            Console.WriteLine(
"                                                                                                                         dddddddd\n" +
"TTTTTTTTTTTTTTTTTTTTTTT                                           tttt                        AAA                        d::::::d                                                                    tttt\n" +
"T:::::::::::::::::::::T                                        ttt:::t                       A:::A                       d::::::d                                                                 ttt:::t\n" +
"T:::::::::::::::::::::T                                        t:::::t                      A:::::A                      d::::::d                                                                 t:::::t\n" +
"T:::::TT:::::::TT:::::T                                        t:::::t                     A:::::::A                     d:::::d                                                                  t:::::t\n" +
"TTTTTT  T:::::T  TTTTTTeeeeeeeeeeee  xxxxxxx      xxxxxxxttttttt:::::ttttttt              A:::::::::A            ddddddddd:::::dvvvvvvv           vvvvvvv eeeeeeeeeeee    nnnn  nnnnnnnn    ttttttt:::::ttttttt    uuuuuu    uuuuuu rrrrr   rrrrrrrrr       eeeeeeeeeeee                eeeeeeeeeeee  xxxxxxx      xxxxxxx eeeeeeeeeeee\n" +
"        T:::::T      ee::::::::::::ee x:::::x    x:::::x t:::::::::::::::::t             A:::::A:::::A         dd::::::::::::::d v:::::v         v:::::vee::::::::::::ee  n:::nn::::::::nn  t:::::::::::::::::t    u::::u    u::::u r::::rrr:::::::::r    ee::::::::::::ee            ee::::::::::::ee x:::::x    x:::::xee::::::::::::ee\n" +
"        T:::::T     e::::::eeeee:::::eex:::::x  x:::::x  t:::::::::::::::::t            A:::::A A:::::A       d::::::::::::::::d  v:::::v       v:::::ve::::::eeeee:::::een::::::::::::::nn t:::::::::::::::::t    u::::u    u::::u r:::::::::::::::::r  e::::::eeeee:::::ee         e::::::eeeee:::::eex:::::x  x:::::xe::::::eeeee:::::ee\n" +
"        T:::::T    e::::::e     e:::::e x:::::xx:::::x   tttttt:::::::tttttt           A:::::A   A:::::A     d:::::::ddddd:::::d   v:::::v     v:::::ve::::::e     e:::::enn:::::::::::::::ntttttt:::::::tttttt    u::::u    u::::u rr::::::rrrrr::::::re::::::e     e:::::e        e::::::e     e:::::e x:::::xx:::::xe::::::e     e:::::e\n" +
"        T:::::T    e:::::::eeeee::::::e  x::::::::::x          t:::::t                A:::::A     A:::::A    d::::::d    d:::::d    v:::::v   v:::::v e:::::::eeeee::::::e  n:::::nnnn:::::n      t:::::t          u::::u    u::::u  r:::::r     r:::::re:::::::eeeee::::::e        e:::::::eeeee::::::e  x::::::::::x e:::::::eeeee::::::e\n" +
"        T:::::T    e:::::::::::::::::e    x::::::::x           t:::::t               A:::::AAAAAAAAA:::::A   d:::::d     d:::::d     v:::::v v:::::v  e:::::::::::::::::e   n::::n    n::::n      t:::::t          u::::u    u::::u  r:::::r     rrrrrrre:::::::::::::::::e         e:::::::::::::::::e    x::::::::x  e:::::::::::::::::e\n" +
"        T:::::T    e::::::eeeeeeeeeee     x::::::::x           t:::::t              A:::::::::::::::::::::A  d:::::d     d:::::d      v:::::v:::::v   e::::::eeeeeeeeeee    n::::n    n::::n      t:::::t          u::::u    u::::u  r:::::r            e::::::eeeeeeeeeee          e::::::eeeeeeeeeee     x::::::::x  e::::::eeeeeeeeeee\n" +
"        T:::::T    e:::::::e             x::::::::::x          t:::::t    tttttt   A:::::AAAAAAAAAAAAA:::::A d:::::d     d:::::d       v:::::::::v    e:::::::e             n::::n    n::::n      t:::::t    ttttttu:::::uuuu:::::u  r:::::r            e:::::::e                   e:::::::e             x::::::::::x e:::::::e\n" +
"      TT:::::::TT  e::::::::e           x:::::xx:::::x         t::::::tttt:::::t  A:::::A             A:::::Ad::::::ddddd::::::dd       v:::::::v     e::::::::e            n::::n    n::::n      t::::::tttt:::::tu:::::::::::::::uur:::::r            e::::::::e                  e::::::::e           x:::::xx:::::xe::::::::e\n" +
"      T:::::::::T   e::::::::eeeeeeee  x:::::x  x:::::x        tt::::::::::::::t A:::::A               A:::::Ad:::::::::::::::::d        v:::::v       e::::::::eeeeeeee    n::::n    n::::n      tt::::::::::::::t u:::::::::::::::ur:::::r             e::::::::eeeeeeee   ......  e::::::::eeeeeeee  x:::::x  x:::::xe::::::::eeeeeeee\n" +
"      T:::::::::T    ee::::::::::::::ex:::::x    x:::::x         tt:::::::::::ttA:::::A                 A:::::Ad:::::::::ddd::::d         v:::v         ee::::::::::::::e   n::::n    n::::n        tt:::::::::::tt  uu::::::::uu:::ur:::::r              ee::::::::::::::e  .::::.   ee::::::::::::::ex:::::x    x:::::xee::::::::::::::e\n" +
"      TTTTTTTTTTT      eeeeeeeeeeeeeexxxxxxx      xxxxxxx          ttttttttttt AAAAAAA                   AAAAAAAddddddddd   ddddd          vvv            eeeeeeeeeeeeee    nnnnnn    nnnnnn          ttttttttttt      uuuuuuuu  uuuurrrrrrr                eeeeeeeeeeeeee   ......     eeeeeeeeeeeeeexxxxxxx      xxxxxxx eeeeeeeeeeeeee\n");
        }
    }
}
