using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FunctionsAssignments
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var randomNumberGenerator = new RandomNumberGenerator();
            var inputReader = new InputReader();
            var inputValidator = new InputValidator();
            var game = new GuessingGame(randomNumberGenerator, inputReader, inputValidator);

            game.Play();
        }
    }

    class RandomNumberGenerator
    {
        private readonly Random random = new Random();

        public int GenerateRandomNumber(int min, int max)
        {
            return random.Next(min, max + 1);
        }
    }

    class InputReader
    {
        public string GetUserInput(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }
    }

    class InputValidator
    {
        public bool IsValidGuess(string input)
        {
            return int.TryParse(input, out int number)
                   && number >= 1
                   && number <= 100;
        }
    }

    class GuessingGame
    {
        private readonly RandomNumberGenerator numberGenerator;
        private readonly InputReader inputReader;
        private readonly InputValidator inputValidator;

        public GuessingGame(RandomNumberGenerator numberGenerator, InputReader inputReader, InputValidator inputValidator)
        {
            this.numberGenerator = numberGenerator;
            this.inputReader = inputReader;
            this.inputValidator = inputValidator;
        }

        public void Play()
        {
            int targetNumber = numberGenerator.GenerateRandomNumber(1, 100);
            int numberOfGuesses = 0;
            bool hasGuessedCorrectly = false;

            string userInput = inputReader.GetUserInput("Guess a number between 1 and 100: ");

            while (!hasGuessedCorrectly)
            {
                if (!inputValidator.IsValidGuess(userInput))
                {
                    userInput = inputReader.GetUserInput("I won’t count this one. Please enter a number between 1 and 100: ");
                    continue;
                }

                numberOfGuesses++;
                int guess = int.Parse(userInput);

                if (guess < targetNumber)
                {
                    userInput = inputReader.GetUserInput("Too low. Guess again: ");
                }
                else if (guess > targetNumber)
                {
                    userInput = inputReader.GetUserInput("Too high. Guess again: ");
                }
                else
                {
                    Console.WriteLine($"You guessed it in {numberOfGuesses} guesses!");
                    hasGuessedCorrectly = true;
                }
            }
        }
    }
}
