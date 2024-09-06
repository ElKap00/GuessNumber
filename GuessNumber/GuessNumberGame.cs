using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber
{
    public class GuessNumberGame
    {
        private bool runGame;
        private Score gameScore;
        private HandleHighScore saveScoreList;

        public GuessNumberGame() { }

        public void PlayGame(string name)
        {


        }

        private bool WillPlay(string name)
        {
            return runGame;
        }
    }
}
