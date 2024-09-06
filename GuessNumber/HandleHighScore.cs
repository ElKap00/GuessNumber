using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber
{
    public class HandleHighScore
    {
        private const string HIGH_SCORE_FILE = "high_scores.txt";
        private FileStream fStream;
        private StreamWriter sWriter;
        private StreamReader sReader;

        public HandleHighScore(){}

        public bool SaveHighScore(List<Score> highScoreList)
        {
            try
            {
                using (sWriter = new StreamWriter(HIGH_SCORE_FILE))
                {
                    foreach (Score score in highScoreList)
                    {
                        sWriter.WriteLine($"{score.Name}:{score.Guess}");
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving high scores: " + ex.Message);
                return false;
            }
        }

        public List<Score> FetchHighScore()
        {
            try
            {
                List<Score> highScoreList = new List<Score>();
                if (File.Exists(HIGH_SCORE_FILE))
                {
                    using (sReader = new StreamReader(HIGH_SCORE_FILE))
                    {
                        string line;
                        while ((line = sReader.ReadLine()) != null)
                        {
                            string[] parts = line.Split(':');
                            Score score = new Score(parts[0], int.Parse(parts[1]));
                            highScoreList.Add(score);
                        }
                    }
                }
                return highScoreList;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading high scores: " + ex.Message);
                return new List<Score>();
            }
        }
    }
}
