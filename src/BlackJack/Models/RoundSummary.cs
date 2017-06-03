using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    public enum RoundResult { Win, Lose, Tie }

    public class RoundSummary
    {
        public int Rounds { get; set; }

        public double InitialCredits { get; set; }

        public int Bet { get; set; }

        public int RoundResult { get; set; }

        public bool Double { get; set; }

        public bool Blackjack { get; set; }

        public bool DealerBlackjack { get; set; }

        public double FinalCredits { get; set; }

        public RoundSummary()
        {}
    }
}
