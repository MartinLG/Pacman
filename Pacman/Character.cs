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
        public string name;

        public void setPlace(Labyrinthe level) {
            level.laby[x,y].setStatement(name);
        }

        public virtual void move(ConsoleKey key, Labyrinthe laby) {
            switch (key) {
                case ConsoleKey.UpArrow:
                    {
                        if (laby.allowToGo(x - 1, y)) {
                            
                            x--;
                        }
                    }
                    break;
                case ConsoleKey.DownArrow:
                    {
                        if (laby.allowToGo(x + 1, y))
                        {
                            x++;
                            
                        }
                    }
                    break;
                case ConsoleKey.RightArrow:
                    {
                        if (x == 10 && y == 18) 
                        {
                            y = 0;
                            laby.laby[10, 18].setStatement("eated");
                        }else if (laby.allowToGo(x, y + 1))
                        {
                            y++;
                            
                        }
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    {
                        if (x == 10 && y == 0)
                        {
                            y = 18;
                            laby.laby[10, 0].setStatement("eated");
                        }else if (laby.allowToGo(x, y - 1))
                        {
                            y--;
                            
                        }
                    }
                    break;
                default: { } break;
            }

            setPlace(laby);
        }
    }
}
