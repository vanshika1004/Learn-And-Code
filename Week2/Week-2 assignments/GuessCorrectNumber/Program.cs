using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessCorrectNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GuessingGame game = new GuessingGame();
            game.Start();

            Console.ReadLine();
        }
    }

    class GuessingGame
    {
        private int numberToGuess;
        private int guessCount;

        public GuessingGame()
        {
            numberToGuess = NumberGenerator.Generate();
            guessCount = 0;
        }

        public void Start()
        {
            bool isGuessed = false;

            while (!isGuessed)
            {
                Console.Write("Guess a number between 1 and 100: ");
                string input = Console.ReadLine();

                if (!InputValidator.IsValid(input))
                {
                    Console.WriteLine("I won't count this one. Please enter a number between 1 and 100.");
                    continue;
                }

                int guess = int.Parse(input);
                guessCount++;

                if (guess < numberToGuess)
                {
                    Console.WriteLine("Too low. Guess again.");
                }
                else if (guess > numberToGuess)
                {
                    Console.WriteLine("Too high. Guess again.");
                }
                else
                {
                    Console.WriteLine("You guessed it in " + guessCount + " guesses!");
                    isGuessed = true;
                }
            }
        }
    }

    class NumberGenerator
    {
        public static int Generate()
        {
            Random random = new Random();
            return random.Next(1, 101);
        }
    }

    class InputValidator
    {
        public static bool IsValid(string input)
        {
            int number;
            return int.TryParse(input, out number) && number >= 1 && number <= 100;
        }
    }

}
