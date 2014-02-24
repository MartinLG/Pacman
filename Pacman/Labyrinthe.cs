using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class Labyrinthe
    {
        private PCase[,] laby = new PCase[20,21];

        public Labyrinthe(){
            for(int i=0; i<20; i++){
                for(int j=0; j<20; j++){
                    if(i==0 || i==19){
                        laby[i,j] = new PCase();
                        laby[i,j].setStatement("horizontal");
                    }else if(j==0 || j == 19){
                        laby[i,j] = new PCase();
                        laby[i,j].setStatement("vertical");
                    }else{
                        laby[i,j] = new PCase();
                        laby[i,j].setStatement("toeat");
                    }
                }
                laby[i,20] = new PCase();
                laby[i, 20].setStatement("nextLine");
            }
            //laby[10, 10].setStatement("pacman");
        }

        public void checkCollision(int x, int y){
            laby[x,y].eatGum();
            laby[x,y].allowToGo();

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

        public void setCharacterOnCase(Character character, int x, int y) { 
            
        }

        public void printLaby() {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 21; j++) {
                    Console.Write(laby[i, j].getCharCase());
                }
            }
        }
    }
}
