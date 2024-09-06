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
        private HandleHighScore saveScoreList = new HandleHighScore();
        private Random random = new Random();

        public GuessNumberGame() { }

        public void PlayGame(string name)
        {
            int numberToGuess = random.Next(1, 11);
            int userGuess = 0;

            gameScore = new Score(name, 0);

            WillPlay(name);
            if (runGame)
            {
                Console.WriteLine("Awesome! Guess a number between 1-10.");
                userGuess = int.Parse(Console.ReadLine());
            }

            while (runGame)
            {
                if (userGuess == numberToGuess)
                {
                    gameScore.Guess++;
                    Console.WriteLine("You are correct!");
                    List<Score> scores = new List<Score>();
                    scores.Add(gameScore);
                    if(saveScoreList.SaveHighScore(scores))
                        Console.WriteLine("Score saved");
                    PlayGame(name);
                }
                else if (userGuess < 1 && userGuess > 20)
                {
                    gameScore.Guess++;
                    Console.WriteLine("Please guess between 1 and 10.");
                    userGuess = int.Parse(Console.ReadLine());
                }
                else if (userGuess < numberToGuess)
                {
                    gameScore.Guess++;
                    Console.WriteLine("Your guess is too low! Try again!");
                    userGuess = int.Parse(Console.ReadLine());
                }
                else if (userGuess > numberToGuess)
                {
                    gameScore.Guess++;
                    Console.WriteLine("Your guess is too high! Try again!");
                    userGuess = int.Parse(Console.ReadLine());
                }
            }
        }

        private bool WillPlay(string name)
        {
            Console.WriteLine($"Hey {name}! Do you want to play a game? (y/n)");
            string userAnswer = Console.ReadLine();

            if (userAnswer == "y")
                runGame = true;
            else
                runGame = false;

            return runGame;
        }
    }
}