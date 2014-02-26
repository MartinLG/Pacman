using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pacman
{
    class Labyrinthe
    {
        public PCase[,] laby = new PCase[22,20];

        public Labyrinthe(){
            for(int i=0; i<22; i++){
                for(int j=0; j<19; j++){
                    if(i==0 || i==21){
                        laby[i,j] = new PCase();
                        laby[i,j].setStatement("horizontal");
                    }else if(j==0 || j == 18){
                        laby[i,j] = new PCase();
                        laby[i,j].setStatement("vertical");
                    }else{
                        laby[i,j] = new PCase();
                        laby[i,j].setStatement("toeat");
                        laby[i, j].eatable = true;
                    }
                }
                laby[i, 19] = new PCase();
                laby[i, 19].setStatement("nextLine");
            }
        }

        public Labyrinthe(char[,] level)
        {
            for (int i = 0; i < 22; i++)
            {
                for (int j = 0; j < 19; j++)
                {
                    laby[i, j] = new PCase();
                    laby[i, j].setStatementFromChar(level[i, j]);
                }
                laby[i, 19] = new PCase();
                laby[i, 19].setStatement("nextLine");
            }
        }

        public bool allowToGo(int x, int y) {
            if (laby[x, y].allowToGo())
            {
                return true;
            }
            else {
                return false;
            }
        }

        public void printLaby() {
            Console.Clear();
            for (int i = 0; i < 22; i++)
            {
                for (int j = 0; j < 20; j++) {
                    Console.Write(laby[i, j].getCharCase());
                }
            }
        }

        public void setCharacterPlace(Character character) {
            laby[character.x, character.y].setStatement(character.name);
        }

        public void eatGum(int x, int y) { 
            laby[x,y].setStatement("eated");
        }

        public bool toEat(int x, int y) {
            return(laby[x, y].eatable);
        }
    }
}
