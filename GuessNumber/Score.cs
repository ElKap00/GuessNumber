using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber
{
    public class Score : IComparable<Score>
    {
        public string Name { get; set; }
        public int Guess { get; set; }

        public Score(string name, int guess)
        {
            Name = name;
            Guess = guess;
        }

        // Compare the scores based on the number of guesses
        public int CompareTo(Score other)
        {
            return this.Guess.CompareTo(other.Guess);
        }
    }
}
