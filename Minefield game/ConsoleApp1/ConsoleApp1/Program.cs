using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool succeed = false; //to tell whether game was won.

            Console.WriteLine("Welcome to the minefield!");
            Console.WriteLine();
            Console.WriteLine("Walk to the exit without triggering a mine to win!");
            Console.WriteLine();

            //first prompt and input
            Console.Write("Please input a difficulty from 1-10: ");
            string input = Console.ReadLine();
            Console.WriteLine();
            
            //Get correct input
            int diff = -1, count=1;
            while(int.TryParse(input, out diff) != true || diff <=0 || diff >10){
                if (count > 2 )
                {
                    Console.WriteLine("It seems you have no intention of playing the game. Goodbye!");
                    Console.WriteLine();
                    break;
                }
                Console.Write("Invalid input. Please enter 1-10: ");
                input = Console.ReadLine();
                count++;
                Console.WriteLine();
            }

            if (count < 3) // run the game
            {
                Game newGame = new Game(diff);
                succeed = newGame.Play();
                //end game based on success of game
                if (succeed == true)
                {
                    newGame.PrintEnd();
                    Console.WriteLine("Congratulations! You succeeded in exiting the minefield!");
                    Console.WriteLine($"You took {newGame.Score()} steps to succeed.");
                    Console.WriteLine();
                }
                else
                {
                    newGame.PrintDeath();
                    Console.WriteLine("Sorry, you stepped on a mine and died :(");
                    Console.WriteLine("Better luck next time!");
                    Console.WriteLine();
                }
            }

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }
    }
}
