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

        public string convertDir(string relativeDir) {
            switch (previous_dir) {
                case "top": 
                    { 
                        switch (relativeDir)
                        {
                            case "forward": 
                                {
                                    return "top";
                                }
                            case "backward":
                                {
                                    return "bottom";
                                }
                            case "turnsright":
                                {
                                    return "right";
                                }
                            case "turnsleft":
                                {
                                    return "left";
                                }
                            default: return "top";
                        }
                    }
                case "bottom":
                    {
                        switch (relativeDir)
                        {
                            case "forward":
                                {
                                    return "bottom";
                                }
                            case "backward":
                                {
                                    return "top";
                                }
                            case "turnsright":
                                {
                                    return "left";
                                }
                            case "turnsleft":
                                {
                                    return "right";
                                }
                            default: return "bottom";
                        }
                    }
                case "right":
                    {
                        switch (relativeDir)
                        {
                            case "forward":
                                {
                                    return "right";
                                }
                            case "backward":
                                {
                                    return "left";
                                }
                            case "turnsright":
                                {
                                    return "bottom";
                                }
                            case "turnsleft":
                                {
                                    return "top";
                                }
                            default: return "right";
                        }
                    }
                case "left":
                    {
                        switch (relativeDir)
                        {
                            case "forward":
                                {
                                    return "left";
                                }
                            case "backward":
                                {
                                    return "right";
                                }
                            case "turnsright":
                                {
                                    return "top";
                                }
                            case "turnsleft":
                                {
                                    return "bottom";
                                }
                            default: return "left";
                        }
                    }
                default: return "top";
            }
        }

        private bool allowedDir(Labyrinthe laby ,string dir) 
        {
            switch (dir) 
            { 
                case "top": return (laby.allowToGo(x - 1, y));
                case "bottom": return (laby.allowToGo(x + 1, y));
                case "right": { if (x == 10 && y == 18) return true; else return (laby.allowToGo(x, y + 1)); }
                case "left": { if (x == 10 && y == 0) return true; else return (laby.allowToGo(x, y - 1)); }
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

        private string[] dirToCheck() {
            switch (previous_dir) { 
                case "top": return (new string[3] { "top", "right", "left" });
                case "bottom": return (new string[3] { "bottom", "right", "left" });
                case "right": return (new string[3] { "bottom", "top", "right" });
                case "left": return (new string[3] { "bottom", "left", "top" });
                default: return (new string[3] { "top", "right", "left" });
            }
        }

        public void move(Labyrinthe laby) {
            int num_dir;
            int indexRandom = 0;
            bool forwardPossible = false;
            bool turnsrightPossible = false;
            bool turnsleftPossible = false;
            foreach (string dirtocheck in dirToCheck()) {
                if (allowedDir(laby, dirtocheck))
                {
                    if (0 == dirtocheck.CompareTo(convertDir("forward")))
                    {
                        indexRandom += 2;
                        forwardPossible = true;
                    }
                    else if (0 == dirtocheck.CompareTo(convertDir("turnsright")))
                    {
                        indexRandom += 1;
                        turnsrightPossible = true;
                    }
                    else if (0 == dirtocheck.CompareTo(convertDir("turnsleft")))
                    {
                        indexRandom += 1;
                        turnsleftPossible = true;
                    } 
                }
            }

            num_dir = randomNumber(indexRandom);
            if (forwardPossible && num_dir <= 1) {
                takeDirection(laby, convertDir("forward"));
            }
            else if (forwardPossible && turnsleftPossible && turnsrightPossible) {
                if (num_dir == 2) takeDirection(laby, convertDir("turnsright"));
                if (num_dir == 3) takeDirection(laby, convertDir("turnsleft"));
            }
            else if (!forwardPossible && turnsrightPossible && turnsleftPossible) {
                if (num_dir == 0) takeDirection(laby, convertDir("turnsright"));
                if (num_dir == 1) takeDirection(laby, convertDir("turnsleft"));
            }
            else if (!forwardPossible && !turnsleftPossible) {
                takeDirection(laby, convertDir("turnsright"));
            }
            else if (!forwardPossible && !turnsrightPossible)
            {
                takeDirection(laby, convertDir("turnsleft"));
            }

            setPlace(laby);
        }


        public int randomNumber(int limit)
        {
            int n = random_number.Next(limit);
            return n;
        }

    }
}
