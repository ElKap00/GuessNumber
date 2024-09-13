using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber
{
    public class UI
    {
        private HandleHighScore scoreList = new HandleHighScore();
        private List<Score> scores;

        public UI() { scoreList = new HandleHighScore(); }

        /* 
         * This method will draw the main menu of the game.
         * It will display the highscores if there are any.
         * 
         * @return The player's response to whether they want to play the game or not.
         */
        public string DrawUI()
        {
            string mainMenu = "Hello Player!\n\n";

            scores = scoreList.FetchHighScore();

            if (scores.Any())
            {
                mainMenu += "---- HIGHSCORES ----\n";
                mainMenu += "| Name          | Guess |\n";
                mainMenu += "|---------------|-------|\n";
                foreach (Score score in scores)
                    mainMenu += $"| {score.Name,-13} | {score.Guess,5} |\n";
            }
            else
            {
                mainMenu += "There seems to be no highscores yet. You can be the first!\n";
            }

            mainMenu += "\nDo you want to play? (y/n)\n";

            Console.Write(mainMenu);

            //return the player's response or an empty string if the input is null
            string? input = Console.ReadLine();
            return input ?? string.Empty;
        }
    }
}
