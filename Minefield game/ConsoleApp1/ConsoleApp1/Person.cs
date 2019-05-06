using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Person
    {
        int x;
        int y;
        int life;

        //constructor
        public Person(int lives)
        {
            x = 0;
            y = 0;
            life = lives;
        }
        public int GetLife()
        {
            return life;
        }
        public int GetX()
        {
            return x;
        }
        public int GetY()
        {
            return y;
        }

        public bool Move(string input, Level minefield) //will always get w, s, a, d through checking in the game
        {
            bool moved = false;
            if (input == "w")
                moved = MoveUp(minefield);
            else if (input == "s")
                moved = MoveDown(minefield);
            else if (input == "a")
                moved = MoveLeft(minefield);
            else if (input == "d")
                moved = MoveRight(minefield);
            return moved;
        }
        bool MoveLeft(Level minefield)
        {
            bool moved = false;
            if (y - 1 < 0) // if out of range
            {
                Console.WriteLine("Out of bounds. Try another direction.");
                Console.WriteLine();
            }
            else
            {
                minefield.SetSpace(x, y, 0); // left current position
                y--; //move person left
                minefield.SetSpace(x, y, 1); // enter new position
                moved = true;
            }
            return moved;
        }
        bool MoveRight(Level minefield)
        {
            bool moved = false;
            if (y + 1 >= minefield.GetSize()) // if out of range
            {
                Console.WriteLine("Out of bounds. Try another direction.");
                Console.WriteLine();
            }
            else
            {
                minefield.SetSpace(x, y, 0); // left current position
                y++; //move person right
                minefield.SetSpace(x, y, 1); // enter new position
                moved = true;
            }
            return moved;
        }
        bool MoveUp(Level minefield)
        {
            bool moved = false;
            if (x - 1 < 0) // if out of range
            {
                Console.WriteLine("Out of bounds. Try another direction.");
                Console.WriteLine();
            }
            else
            {
                minefield.SetSpace(x, y, 0); // left current position
                x--; //move person up
                minefield.SetSpace(x, y, 1); // enter new position
                moved = true;
            }
            return moved;
        }
        bool MoveDown(Level minefield)
        {
            bool moved = false;
            if (x + 1 >= minefield.GetSize()) // if out of range
            {
                Console.WriteLine("Out of bounds. Try another direction.");
                Console.WriteLine();
            }
            else
            {
                minefield.SetSpace(x, y, 0); // left current position
                x++; //move person down
                minefield.SetSpace(x, y, 1); // enter new position
                moved = true;
            }
            return moved;
        }
        public void TakeDamage()
        {
            life--;
        }
    }
}
