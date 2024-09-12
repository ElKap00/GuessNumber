using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber
{
    public class HandleHighScore
    {
        private const string HIGH_SCORE_DIRECTORY = "HighScores";
        private const string HIGH_SCORE_FILE = "high_scores.txt";
        private string highScoreFilePath;
        private FileStream fStream;
        private StreamWriter sWriter;
        private StreamReader sReader;

        public HandleHighScore() 
        {
            string projectRootDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            highScoreFilePath = Path.Combine(projectRootDirectory, HIGH_SCORE_DIRECTORY, HIGH_SCORE_FILE);
        }

        /* 
         * This method will save the high scores to a file.
         * 
         * @param highScoreList - The list of high scores to save.
         * @return True if the high scores were saved successfully, false otherwise.
         */
        public bool SaveHighScore(List<Score> highScoreList)
        {
            try
            {
                // Create the directory if it doesn't exist
                string directoryPath = Path.GetDirectoryName(highScoreFilePath);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                // Save the high scores to the file
                using (fStream = new FileStream(highScoreFilePath, FileMode.Append, FileAccess.Write))
                {
                    using (sWriter = new StreamWriter(fStream))
                    {
                        foreach (Score score in highScoreList)
                        {
                            sWriter.WriteLine($"{score.Name}:{score.Guess}");
                        }
                    }
                    return true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving high scores: " + ex.Message);
                return false;
            }
        }

        /* 
         * This method will fetch the high scores from a file.
         * 
         * @return The list of high scores.
         */
        public List<Score> FetchHighScore()
        {
            try
            {
                List<Score> highScoreList = new List<Score>();
                if (File.Exists(highScoreFilePath))
                {
                    using (fStream = new FileStream(highScoreFilePath, FileMode.Open, FileAccess.Read))
                    {
                        using (sReader = new StreamReader(fStream))
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
                }
                // Return the high scores sorted by the number of guesses
                highScoreList.Sort();
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
