using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class Pacman : Character
    {
        public int life;
        public int points;
        public bool super;

        public Pacman() {
            life = 3;
            points = 0;
            x = 10;
            y = 10;
            name = "pacman";
            super = false;
        }

    }
}
