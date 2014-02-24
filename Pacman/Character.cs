using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class Character
    {
        protected int x;
        protected int y;

        public bool move(string dir, Labyrinthe laby) { 
            
            switch (dir){
                case "top":
                {
                    if(0 == dir.CompareTo("top") && laby.allowToGo(x, y-1)){
                        y--;
                        return true;
                    }
                }
                break;
                case "bottom":
                {
                    if (0 == dir.CompareTo("bottom") && laby.allowToGo(x, y + 1))
                    {
                        y++;
                        return true;
                    }
                }
                break;
                case "right":
                {
                    if (0 == dir.CompareTo("right") && laby.allowToGo(x + 1, y))
                    {
                        x++;
                        return true;
                    }
                }
                break;
                case "left":
                {
                    if (0 == dir.CompareTo("bottom") && laby.allowToGo(x - 1, y))
                    {
                        x--;
                        return true;
                    }
                }
                break;
                default:
                {
                    return false;
                }
            }
            return false;
        }
    }
}
