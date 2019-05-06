using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Level
    {
        int size;
        int height;
        int[,] space;
        Mine[] mines; // Mines in the level
        Random rnd = new Random(); // to use random functions in level generation

        public Level(int n) // has to create size for dungeon (dungeon difficulty). Person is always at
        {                   // (0,0) and E at (n,n) to start. Generate mines in minefield
            size = n;
            height = 2 * n + 1;
            space = new int[n,n];
            space[0, 0] = 1; //set highest and left most to person starting position
            space[n-1, n-1] = 2; // set lower and right most to exit position
            mines = new Mine[n]; //generate no. of mines according to difficulty (no. = difficulty)

            //Place mines in the level randomly
            for(int i=0; i < size; i++)
            {
                if (space[i, n - 1] != 2 && space[i,i] != 1) //so that exit and starting pos won't be blocked
                {
                    mines[i] = new Mine(i, rnd.Next(size)); // one mine every row. May block exit totally
                }
            }
        }

        public void DrawLevel()
        {
            Console.WriteLine("P = Your Character , E = Exit , To Move: w = up, s = down, a = left, d = right");
            Console.WriteLine();

            for (int i = 0; i<height; i++)
            {

                for (int j = 0; j < size; j++)
                {
                    if (i % 2 != 0)
                    {
                        switch (space[(i-1)/2, j]) //(position [n,x], n is (i-1)/2 as height is 2*n + 1
                        {
                            //if 0, empty block, print empty block
                            case 0:
                                Console.Write("|   ");
                                break;
                            //if 1, person block
                            case 1:
                                Console.Write("| P ");
                                break;
                            // if 2, last block, game exit
                            case 2:
                                Console.Write("| E ");
                                break;
                            case 3:
                                Console.Write("| X "); //died in the position
                                break;
                            case 4:
                                Console.Write("| O "); //in death, reveal position of mine
                                break;
                        }
                    }
                    else
                        Console.Write("****");
                }
                if (i % 2 == 0)
                    Console.WriteLine("*");
                else
                    Console.WriteLine("|");
            }
            Console.WriteLine();
        }
        public void SetSpace(int x, int y, int z)
        {
            space[x, y] = z;
        }
        public int GetSpace(int x, int y)
        {
            return space[x, y];
        }
        public int GetSize()
        {
            return size;
        }
        public Mine[] GetMines()
        {
            return mines;
        }

    }
}
