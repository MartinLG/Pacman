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
            pacman.setPlace(laby);
            laby.printLaby();

            do
            {
                cki = Console.ReadKey();
                pacman.move(cki.Key, laby);
                laby.printLaby();
            } while (cki.Key != ConsoleKey.Escape);
        }
    }
}
