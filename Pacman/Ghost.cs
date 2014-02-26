using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class Ghost : Character
    {
        public bool alive;
        public int respawn_time;
        private string previous_dir;

        static Random random_number = new Random();

        public Ghost() {
            alive = true;
            name = "ghost";
            previous_dir = "top";
            x = 10;
            y = 9;
        }

        public Ghost(int resp) {
            alive = false;
            respawn_time = resp;
            previous_dir = "top";
            name = "ghost";
            x = 10;
            y = 9;
        }

        public string GetDirection()
        {
            string dir;
            int n = random_number.Next(10);
            switch (n) {
                case 0: dir = "continue"; break;
                case 1: dir = "continue"; break;
                case 2: dir = "continue"; break;
                case 3: dir = "continue"; break;
                case 4: dir = "continue"; break;
                case 5: dir = "back"; break;
                case 6: dir = "turnsright"; break;
                case 7: dir = "turnsright"; break;
                case 8: dir = "turnsleft"; break;
                case 9: dir = "turnsleft"; break;
                default: dir = "continue"; break;
            }
            return(dir);
        }


        public void move(Labyrinthe laby) {
            switch (GetDirection()) {
                case "continue":
                    {
                        tryContinue(laby);
                    }break;
                case "back":
                    {
                        tryBack(laby);
                    }break;
                case "turnsright":
                    {
                        tryTurnsRight(laby);
                    } break;
                case "turnsleft":
                    {
                        tryTurnsLeft(laby);
                    } break;
            }
            setPlace(laby);
        }

        private void tryContinue(Labyrinthe laby) 
        {
            if (allowedDir(laby, previous_dir))
            {
                takeDirection(laby, previous_dir);
            }
            else tryTurnsRight(laby);
        }

        private void tryBack(Labyrinthe laby)
        {
            if (allowedDir(laby, "bottom"))
            {
                takeDirection(laby, "bottom");
            }
            else tryContinue(laby);
        }

        private void tryTurnsRight(Labyrinthe laby)
        {
            if (allowedDir(laby, "right"))
            {
                takeDirection(laby, "right");
            }
            else tryTurnsLeft(laby);
        }

        private void tryTurnsLeft(Labyrinthe laby)
        {
            if (allowedDir(laby, "left"))
            {
                takeDirection(laby, "left");
            }
            else tryContinue(laby);
        }

        private bool allowedDir(Labyrinthe laby ,string dir) 
        {
            switch (dir) 
            { 
                case "top": return (laby.allowToGo(x - 1, y));
                case "bottom": return (laby.allowToGo(x + 1, y));
                case "right": return (laby.allowToGo(x, y + 1));
                case "left": return (laby.allowToGo(x, y - 1));
                default: return false;
            }
        }

        private void takeDirection(Labyrinthe laby, string dir) {
            laby.laby[x, y].rollbackStatement();
            switch (dir)
            {
                case "top": {
                    x--;
                }break;
                case "bottom": {
                    x++;
                }break;
                case "right": {
                    if (x == 10 && y == 18)
                    {
                        y = 0;
                    }
                    else
                    {
                        y++;
                    }
                }break;
                case "left": {
                    if (x == 10 && y == 0)
                    {
                        y = 18;
                    }
                    else
                    {
                        y--;
                    }
                }break;
            }
            previous_dir = dir;
        }

    }
}
