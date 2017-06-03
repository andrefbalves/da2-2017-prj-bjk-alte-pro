using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackJack.Models;

namespace BlackJack.Models
{
    public enum RoundResult { NewRound, Lose, Win, Empate, Surrender, BlackJack }

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
        { }
    }
}
