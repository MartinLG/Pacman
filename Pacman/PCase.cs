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
        public bool eatable;

        public PCase() {
            this.statement = "toeat";
            this.eatable = true;
        }

        PCase(string statement) {
            this.statement = statement;
            if (statement == "toeat") {
                this.eatable = true;
            }
        }

        public char getCharCase() {
            switch (statement)
            {
                case "eated":
                    {
                        return ' ';
                    }

                case "toeat":
                    {
                        return '.';
                    }

                case "vertical":
                    {
                        return '|';
                    }

                case "horizontal":
                    {
                        return '_';
                    }

                case "pacman":
                    {
                        return 'C';
                    }

                case "Ghost":
                    {
                        return 'G';
                    }

                case "nextLine":
                    {
                        return '\n';
                    }

                default:
                    {
                        return ' ';
                    }
            }
        }

        public void setStatement(string statement){
            this.statement = statement;
            if (statement == "toeat")
            {
                eatable = true;
            }
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
    }
}
