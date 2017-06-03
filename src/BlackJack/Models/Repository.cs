using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    public static class Repository 
    {

        private static List<Game> players = new List<Game>();
        public static List<Game> Players
        {
            get
            {
                return players;
            }
        }

        public static void AddPlayer(Game newPlayer)
        {
            players.Add(newPlayer);
        }

        private static List<RoundSummary> rounds = new List<RoundSummary>();
        public static List<RoundSummary> Rounds
        {
            get
            {
                return rounds;
            }
        }

        public static void AddRound(RoundSummary newround)
        {
            rounds.Add(newround);
        }

        public static int Wins { get; set; }

        public static int Loses { get; set; }

        public static int Ties { get; set; }

        public static int BlackJack { get; set; }
    }
}
