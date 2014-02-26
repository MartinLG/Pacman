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
        public int nbGums = 189;

        public Labyrinthe(){
            for(int i=0; i<22; i++){
                for(int j=0; j<19; j++){
                    if(i==0 || i==21){
                        laby[i,j] = new PCase("horizontal");
                    }else if(j==0 || j == 18){
                        laby[i,j] = new PCase("vertical");
                    }else{
                        laby[i,j] = new PCase("toeat");
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
                laby[i, 19] = new PCase("nextLine");
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

        public void printLaby(Pacman pacman) {
            Console.Clear();
            for (int i = 0; i < 22; i++)
            {
                for (int j = 0; j < 20; j++) {
                    Console.Write(laby[i, j].getCharCase());
                }
            }
            Console.WriteLine("Points = " + pacman.points);
            Console.WriteLine("Lifes = " + pacman.life);
        }

        public void setCharacterPlace(Character character) {
            laby[character.x, character.y].setStatement(character.name);
        }

        public void eatGum(int x, int y) { 
            laby[x,y].setStatement("eated");
            laby[x, y].eatable = false;
        }

        public bool toEat(int x, int y) {
            return(laby[x, y].eatable);
        }

        public void endGame() {
            Console.Clear();
            Console.WriteLine("  YOU WIN !!!!   ");
            Console.ReadLine();
        }
    }
}
