using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo cki;
            Console.TreatControlCAsInput = true;

            Levels level1 = new Levels();
            Labyrinthe laby = new Labyrinthe(level1.level1);
            Pacman pacman = new Pacman();
            Ghost ghost1 = new Ghost();
            Ghost ghost2 = new Ghost(10);
            Ghost ghost3 = new Ghost(20);
            Ghost ghost4 = new Ghost(30);
            pacman.setPlace(laby);
            ghost1.setPlace(laby);
            laby.printLaby(pacman);

            do
            {
                cki = Console.ReadKey();
                pacman.move(cki.Key, laby);
                ghost1.move(laby, pacman);
                ghost2.move(laby, pacman);
                ghost3.move(laby, pacman);
                ghost4.move(laby, pacman);
                laby.printLaby(pacman);
                
            } while (cki.Key != ConsoleKey.Escape);
        }
    }
}
