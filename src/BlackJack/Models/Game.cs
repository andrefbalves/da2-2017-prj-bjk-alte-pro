using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    public class Game
    {
        public string PlayerName { get; set; }
        public int Rounds { get; set; }
        public int Wins { get; set; }
        public int Loses { get; set; }
        public int Ties { get; set; }
        public int BlackJack { get; set; }
        public double Credits { get; set; }

        public Game()
        { }



    }
}
