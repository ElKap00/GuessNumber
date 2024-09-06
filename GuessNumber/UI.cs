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

        public string DrawUI() 
        {
            string mainMenu = "Hello Player!\n\n";

            scores = scoreList.FetchHighScore();

            if (scores.Any())
            {
                mainMenu += "---- HIGHSCORES ----\n";
                foreach (Score score in scores)
                    mainMenu += score.Name + ":" + score.Guess + "\n";
            }
            else
            {
                mainMenu += "There seems to be no highscores yet. You can be the first!\n";
            }

            return mainMenu;
        }
    }
}
