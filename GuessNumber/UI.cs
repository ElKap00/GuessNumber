using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber
{
    public class UI
    {
        private HandleHighScore scoreList;
        private List<Score> scores;

        public UI() { scoreList = new HandleHighScore(); }

        public string DrawUI() { return ""; }
    }
}
