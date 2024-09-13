using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber
{
    public class GuessNumberGame
    {
        private static int MAX_GUESS = 10;
        private static int MIN_GUESS = 1;
        private bool runGame = false;
        private Score gameScore;
        private HandleHighScore saveScoreList;
        private Random random = new Random();

        public GuessNumberGame() 
        {
            saveScoreList = new HandleHighScore();
            gameScore = new Score("Player", 0);
        }

        /* 
         * This method will start the game. 
         * It will generate a random number between MIN_GUESS and MAX_GUESS and ask the user to guess it.
         * The user will keep guessing until they get the correct number.
         * The game will keep track of the number of guesses the user makes.
         * The game will also save the user's score to a list of scores.
         * 
         * @param playerResponse - The player's response to whether they want to play the game or not.
         */
        public void PlayGame(string playerResponse)
        {
            WillPlay(playerResponse);

            // Initialize the game variables
            int numberToGuess = random.Next(MIN_GUESS, MAX_GUESS + 1);
            int userGuess = 0;
            List<Score> scores = new List<Score>();

            if (runGame)
            {
                Console.WriteLine($"Awesome! Guess a number between {MIN_GUESS}-{MAX_GUESS}.");
            }

            // Core game loop
            while (runGame)
            {
                string? input = Console.ReadLine();
                if (input == null)
                {
                    Console.WriteLine("Input cannot be null. Please enter a valid number.");
                    continue;
                }

                if (!int.TryParse(input, out userGuess))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue;
                }

                //correct guess
                if (userGuess == numberToGuess)
                {
                    gameScore.Guess++;
                    Console.WriteLine("You are correct!");
                    Console.WriteLine($"You guessed {gameScore.Guess} time(s).");
                    // Add the score to the list
                    Console.WriteLine("Enter your name: ");
                    string? playerName = Console.ReadLine();
                    gameScore.Name = playerName ?? "Unknown";
                    scores.Add(gameScore);
                    // Reset the game
                    Console.WriteLine("Do you want to play again? (y/n)");
                    WillPlay(Console.ReadLine());
                    if (runGame)
                    {
                        gameScore = new Score("Player", 0);
                        numberToGuess = random.Next(MIN_GUESS, MAX_GUESS + 1);
                        Console.WriteLine($"Guess a number between {MIN_GUESS}-{MAX_GUESS}.");
                    }

                }
                //guess outside of range
                else if (userGuess < MIN_GUESS || userGuess > MAX_GUESS)
                {
                    gameScore.Guess++;
                    Console.WriteLine($"Please guess a number between {MIN_GUESS}-{MAX_GUESS}.");
                }
                //guess too low
                else if (userGuess < numberToGuess)
                {
                    gameScore.Guess++;
                    Console.WriteLine("Your guess is too low! Try again!");
                }
                //guess too high
                else if (userGuess > numberToGuess)
                {
                    gameScore.Guess++;
                    Console.WriteLine("Your guess is too high! Try again!");
                }
            }
            // Save the high scores
            if (saveScoreList.SaveHighScore(scores))
                Console.WriteLine("Score saved");
        }

        /* 
         * This method will check if the player wants to play the game.
         * 
         * @param playerResponse - The player's response to whether they want to play the game or not.
         * @return runGame - A boolean value that determines if the game will run or not.
         */
        private bool WillPlay(string playerResponse)
        {
            if (playerResponse.ToLower() == "y")
                runGame = true;
            else
                runGame = false;

            return runGame;
        }
    }
}