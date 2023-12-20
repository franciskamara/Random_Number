using System;
using System.Data;

namespace Random_Number;
class Program
{

    static void Main(string[] args)
    {
        //Game state variables
        const int MIN_INPUT = 1;
        const int MAX_INPUT = 20;
        const int PERMITTED_ATTEMPTS = 5;
        const int CLOSE_GUESS_NUMBER = 5; 
        int attemptsMade;
        int guess = 0;

        //Rndom number draw
        Random rng = new Random();
        int randomNumber = rng.Next(MIN_INPUT, MAX_INPUT +1);
        //Console.WriteLine(randomNumber);

        // Welcome message 
        Console.WriteLine("***********************************************");
        Console.WriteLine(" Hello and welcome to the Number guessing game ");
        Console.WriteLine("***********************************************");

        ///        Attempt count - will exceed x5 as Invalid and Out of range inputs are not added to attemptsMade 
        for (attemptsMade = 0; attemptsMade < PERMITTED_ATTEMPTS; attemptsMade++)
        {
            Console.Write($"Please enter a number between {MIN_INPUT} and {MAX_INPUT}: "); // Request input
            string guessString = Console.ReadLine();

            Console.WriteLine($"Attempts: {attemptsMade+1}");

            //                  Guess results
            bool validInput = int.TryParse(guessString, out guess); // Checks for number input 
            bool restart = false; // Loop restart and reduce made attempts 

            if (!validInput) // Invalid Input
            {
                Console.WriteLine("That's not a number. This try does not count to total attempts.");
                restart = true;
            }
            else if (guess < MIN_INPUT || guess > MAX_INPUT) //Checks if number is Out of range
            {
                Console.WriteLine("Out of range. This try does not count to total attempts.");
                restart = true;
            }

            if (restart) //Reduce attemptsMade count
            {
                attemptsMade--;
                continue;
            }

            if (guess == randomNumber) //Winning scenario breakout
            {
                break;
            }

            if (guess < randomNumber) //Guess lower than random number
            {
                Console.WriteLine("Too low");
            }
            else if (guess > randomNumber) //Guess higher than random number
            {
                Console.WriteLine("Too high");
            }

            //Console.WriteLine(closeGuess);
            if (Math.Abs(guess - randomNumber) <= CLOSE_GUESS_NUMBER) //Checks if the guess is within 5 range on the lower end of the guess
            {
                Console.WriteLine("You are close! Within 5 of the value.");
            }
        }

        if (guess == randomNumber) //Game won response
        {
            Console.Clear();
            Console.WriteLine("CORRECT! You won the game");
            Console.WriteLine("You guessed the correct number. Congratulations you win!\n\nIf you would like to play again press y or n to exit");
        }

        else //Losing scenario. Max attempts reached
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"You lose this time. The number was {randomNumber}");
        }

        //prompts user to Restart or Exit game
        char endGame = Console.ReadKey().KeyChar;
        if (endGame == 'y')
        {
            Console.Clear();
            Main(args);
        }
        else if (endGame == 'n')
        {
            return;
        }
    }
}