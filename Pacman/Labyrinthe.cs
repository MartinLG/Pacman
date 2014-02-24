using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class Labyrinthe
    {
        private PCase[,] laby = new PCase[20,20];

        Labyrinthe(){
            for(int i=0; i<20; i++){
                for(int j=0; j<20; j++){
                    if(i==0 && j!=0){
                        laby[i,j].setStatement("horizontal");
                    }else if(i!=0 && j==0){
                        laby[i,j].setStatement("vertical");
                    }else{
                        laby[i,j].setStatement("toeat");
                    }
                }
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
    }
}
