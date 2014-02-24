using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class PCase
    {
        protected string statement;

        PCase() {
            this.statement = "toeat";
        }

        PCase(string statement) {
            this.statement = statement;
        }

        public char getCharCase() {
            switch (statement)
            {
                case "eated":
                    {
                        return ' ';
                    }
                    break;

                case "toeat":
                    {
                        return '.';
                    }
                    break;

                case "vertical":
                    {
                        return '|';
                    }
                    break;

                case "horizontal":
                    {
                        return '_';
                    }
                    break;

                case "pacman":
                    {
                        return 'C';
                    }
                    break;

                case "Ghost":
                    {
                        return 'G';
                    }
                    break;

                default:
                    {
                        return ' ';
                    }
                    break;
            }
        }

        public void setStatement(string statement){
            this.statement = statement;
        }
        
        public string getStatement() {
            return statement;
        }

        public bool allowToGo(){
            switch (statement)
            {
                case "vertical":
                    {
                        return false;
                    }
                    break;

                case "horizontal":
                    {
                        return false;
                    }
                    break;

                default:
                    {
                        return true;
                    }
                    break;
            }
        }

        public bool eatGum() {
            if(statement.CompareTo("toeat") == 0){
                setStatement("eated");
                // increase score
                return true;
            }
            return false;
        }

        
    }
}
