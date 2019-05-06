using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Game
    {
        Person player;
        Level minefield;
        int steps;
        string input;

        public Game(int diff)
        {
            minefield = new Level(diff + 1);
            player = new Person(1);
            steps = 0;
            input = null;
        }

        public bool Play() // play the game
        {
            bool valid = false; //check validty of inputs
            bool moved = false; //check if moved. Print only when moved
            
            minefield.DrawLevel(); //first instance of minefield
            //Continue game as long as player still has life or has not reached exit
            while (player.GetLife()>0 && minefield.GetSpace(minefield.GetSize()-1, minefield.GetSize()-1) != 1) 
            {
                Console.Write("Make your move: ");
                valid = GetValidInput(Console.ReadLine(), out input);
                if (valid == false)
                    break;
                else
                {
                    moved = player.Move(input, minefield);
                    //print current state of minefield only if player was able to move
                    if (moved)
                    {
                        steps++;
                        if (StepOnMine(player.GetX(), player.GetY(), minefield.GetMines()))
                        {
                            player.TakeDamage();
                            if (player.GetLife() < 1)
                                return false; //died
                        }
                        else if (player.GetX() == minefield.GetSize() - 1 && player.GetY() == minefield.GetSize() - 1)
                            return true;
                        else
                            minefield.DrawLevel();
                    }
                }
            }
            //below if condition is failsafe incase Play() does not work as intended
            if (player.GetLife() > 0)
                return true; //success!
            else
                return false; //died :(
        }
        public int Score() // return number of steps taken to complete the game
        {
            return steps;
        }
        bool GetValidInput(string input, out string movement) //used to ensure input is one of w, s, a, d, and if too many errors, exit the game
        {
            movement = input; //already created so no need to create again (as in no need int movement =)
            int count = 1;

            while (movement != "w" && movement != "s" && movement != "a" && movement != "d") // not anything
            {
                if (count > 2)
                {
                    Console.WriteLine("It seems you have no intention of playing the game. Goodbye!");
                    Console.WriteLine();
                    break; //stop getting too much inputs if its all invalid
                }
                Console.Write("Invalid input. Please enter w, s, a or d: ");
                movement = Console.ReadLine();
                count++;
                Console.WriteLine();
            }
            if (count > 2)
                return false;
            else
                return true;
        }
        bool StepOnMine(int x, int y, Mine[] mines)
        {
            for (int i = 0; i < mines.Length; i++)
            {
                if (mines[i] != null) //due to my limited skills, some are null
                {
                    if (mines[i].GetX() == x && mines[i].GetY() == y)
                        return true;
                }
            }
            return false;
        }
        public void PrintDeath() //uses printend but mark death
        {
            //setting current person position as "X" to mark death, X is case 3
            minefield.SetSpace(player.GetX(), player.GetY(), 3);
            PrintEnd();
        }
        public void PrintEnd()
        {
            //reveal all mine locations
            for (int i = 0; i < minefield.GetMines().Length; i++)
            {
                if (minefield.GetMines()[i] != null)
                {
                    int x = minefield.GetMines()[i].GetX();
                    int y = minefield.GetMines()[i].GetY();
                    if (minefield.GetSpace(x, y) != 3) //if death occurred
                        minefield.SetSpace(x, y, 4);
                }
            }
            minefield.DrawLevel();
        }
    }
}
