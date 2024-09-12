using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber
{
    public class GuessNumberGame
    {
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
         * It will generate a random number between 1-10 and ask the user to guess it.
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
            int numberToGuess = random.Next(1, 11);
            int userGuess = 0;
            List<Score> scores = new List<Score>();

            if (runGame)
            {
                Console.WriteLine("Awesome! Guess a number between 1-10.");
            }

            // Core game loop
            while (runGame)
            {
                userGuess = int.Parse(Console.ReadLine());
                if (userGuess == numberToGuess)
                {
                    gameScore.Guess++;
                    Console.WriteLine("You are correct!");
                    Console.WriteLine($"You guessed {gameScore.Guess} time(s).");
                    // Add the score to the list
                    Console.WriteLine("Enter your name: ");
                    gameScore.Name = Console.ReadLine();
                    scores.Add(gameScore);
                    // Reset the game
                    gameScore = new Score("Player", 0);
                    Console.WriteLine("Do you want to play again? (y/n)");
                    WillPlay(Console.ReadLine());
                    numberToGuess = random.Next(1, 11);
                    Console.WriteLine("Guess a number between 1-10.");
                }
                else if (userGuess < 1 && userGuess > 10)
                {
                    gameScore.Guess++;
                    Console.WriteLine("Please guess between 1 and 10.");
                }
                else if (userGuess < numberToGuess)
                {
                    gameScore.Guess++;
                    Console.WriteLine("Your guess is too low! Try again!");
                }
                else if (userGuess > numberToGuess)
                {
                    gameScore.Guess++;
                    Console.WriteLine("Your guess is too high! Try again!");
                }
            }
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