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
        protected string previous_statement;

        public PCase() {
            this.statement = "toeat";
            this.eatable = true;
        }

        public PCase(string statement) {
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

                case "supercandy":
                    {
                        return '*';
                    }

                case "vertical":
                    {
                        return '|';
                    }

                case "horizontal":
                    {
                        return '_';
                    }

                case "small-horizontal":
                    {
                        return '-';
                    }

                case "biais1":
                    {
                        return '/';
                    }

                case "biais2":
                    {
                        return '\\';
                    }

                case "pacman":
                    {
                        return 'C';
                    }

                case "ghost":
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
            previous_statement = this.statement;
            this.statement = statement;
            if (statement == "toeat" || statement == "supercandy")
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
                    

                case "horizontal":
                    {
                        return false;
                    }
                    

                case "small-horizontal":
                    {
                        return false;
                    }
                    

                case "biais1":
                    {
                        return false;
                    }
                    

                case "biais2":
                    {
                        return false;
                    }
                    

                default:
                    {
                        return true;
                    }
                    
            }
        }

        public void setStatementFromChar(char statechar)
        {
            switch (statechar) {
                case '_': {
                    statement = "horizontal";
                } break;
                case '-': {
                    statement = "small-horizontal";
                } break;
                case '|': {
                    statement = "vertical";
                } break;
                case '.': {
                    statement = "toeat";
                    eatable = true;
                } break;
                case '*': {
                    statement = "supercandy";
                    eatable = true;
                } break;
                case '/': {
                    statement = "biais1";
                } break;
                case '\\': {
                    statement = "biais2";
                } break;
                default: {
                    statement = "eated";
                } break;
            }
        }

        public void rollbackStatement() {
            statement = previous_statement;
        }
    }
}
