using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber
{
    internal class HandleHighScore
    {
        private FileStream fStream;
        private StreamWriter sWriter;
        private StreamReader sReader;

        public HandleHighScore()
        {

        }

        public bool SaveHighScore(List<Score> highScoreList)
        {
            return false;
        }

        public List<Score> FetchHighScore()
        {
            return new List<Score>();
        }
    }
}
