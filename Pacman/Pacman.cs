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
        public int super_time;

        public Pacman() {
            life = 2;
            points = 0;
            name = "pacman";
            x = 12;
            y = 9;
            super = false;
        }

        public override void move(ConsoleKey key, Labyrinthe laby)
        {
            if (super) {
                super_time--;
            }

            if (super_time == 0) {
                super = false;
            }

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    {
                        if (laby.allowToGo(x - 1, y))
                        {

                            x--;
                            
                            if (laby.toEat(x, y))
                            {
                                
                                points += 100;
                                laby.nbGums--;
                                if (laby.laby[x, y].getStatement().CompareTo("supercandy") == 0) {
                                    super = true;
                                    super_time = 15;
                                }
                            }
                            laby.eatGum(x + 1, y);
                        }
                    }
                    break;
                case ConsoleKey.DownArrow:
                    {
                        if (laby.allowToGo(x + 1, y))
                        {
                            x++;
                            
                            if (laby.toEat(x, y))
                            {
                                
                                points += 100;
                                laby.nbGums--;
                                if (laby.laby[x, y].getStatement().CompareTo("supercandy") == 0)
                                {
                                    super = true;
                                    super_time = 15;
                                }
                            }
                            laby.eatGum(x - 1, y);
                        }
                    }
                    break;
                case ConsoleKey.RightArrow:
                    {
                        if (x == 10 && y == 18)
                        {
                            y = 0;
                            laby.laby[10, 18].setStatement("eated");
                        }
                        else if (laby.allowToGo(x, y + 1))
                        {
                            y++;
                            
                            if (laby.toEat(x, y))
                            {
                                
                                points += 100;
                                laby.nbGums--;
                                if (laby.laby[x, y].getStatement().CompareTo("supercandy") == 0)
                                {
                                    super = true;
                                    super_time = 15;
                                }
                            }
                            laby.eatGum(x, y - 1);
                        }
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    {
                        if (x == 10 && y == 0)
                        {
                            y = 18;
                            laby.laby[10, 0].setStatement("eated");
                        }
                        else if (laby.allowToGo(x, y - 1))
                        {
                            y--;
                            
                            if (laby.toEat(x, y))
                            {
                                
                                points += 100;
                                laby.nbGums--;
                                if (laby.laby[x, y].getStatement().CompareTo("supercandy") == 0)
                                {
                                    super = true;
                                    super_time = 15;
                                }
                            }
                            laby.eatGum(x, y + 1);
                        }
                    }
                    break;
                default: { } break;
            }

            if (laby.nbGums == 0)
            {
                laby.endGame();
            }

            setPlace(laby);
        }

        public void death(Labyrinthe laby) {
            if (life > 0)
            {
                life--;
                laby.laby[x, y].setStatement("eated");
                x = 12;
                y = 9;
            }
            else if (life == 0) {
                laby.gameOver();
            }
        }

        public override void setPlace(Labyrinthe level)
        {
            if(super)
            {
                level.laby[x, y].setStatement("superhero");
            }else{
                base.setPlace(level);
            }
        }

    }
}
