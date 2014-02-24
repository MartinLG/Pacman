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
            Labyrinthe laby = new Labyrinthe();
            laby.printLaby();
            Console.ReadKey(true);
        }
    }
}
