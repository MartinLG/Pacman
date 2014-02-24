using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class Character
    {
        public int x;
        public int y;
        public String name;

        public void setPlace(Labyrinthe level) {
            level.laby[x,y].setStatement(name);
        }

        public void move(ConsoleKey key, Labyrinthe laby) {
            switch (key) {
                case ConsoleKey.UpArrow:
                    {
                        if (laby.allowToGo(x - 1, y)) {
                            
                            x--;
                            if (name == "pacman" && laby.toEat(x + 1, y))
                            {
                                laby.eatGum(x + 1, y);
                            }
                        }
                    }
                    break;
                case ConsoleKey.DownArrow:
                    {
                        if (laby.allowToGo(x + 1, y))
                        {
                            x++;
                            if (name == "pacman" && laby.toEat(x - 1, y))
                            {
                                laby.eatGum(x - 1, y);
                            }
                        }
                    }
                    break;
                case ConsoleKey.RightArrow:
                    {
                        if (laby.allowToGo(x, y + 1))
                        {
                            y++;
                            if (name == "pacman" && laby.toEat(x, y - 1))
                            {
                                laby.eatGum(x, y - 1);
                            }
                        }
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    {
                        if (laby.allowToGo(x, y - 1))
                        {
                            y--;
                            if (name == "pacman" && laby.toEat(x, y + 1))
                            {
                                laby.eatGum(x, y + 1);
                            }
                        }
                    }
                    break;
                default: { } break;
            }

            setPlace(laby);
        }
    }
}
