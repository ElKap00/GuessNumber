using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber
{
    public class Score
    {
        public string Name { get; set; }
        public int Guess { get; set; }

        public int CompareTo(Score score)
        {
            return 0;
        }
    }
}
