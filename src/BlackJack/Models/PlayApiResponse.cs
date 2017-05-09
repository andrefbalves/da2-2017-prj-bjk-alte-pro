using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlackJack.Models
{
    public class PlayApiResponse
    {
        public int GameId { get; set; }

        public string PlayerName { get; set; }

        public double PlayerCredits { get; set; }

        public List<Card> Dealerhand { get; set; }

        public List<Card> PlayerHand { get; set; }

        public bool PlayingRound { get; set; }

        public int RoundCount { get; set; }

        public bool IsNewShoe { get; set; }

        public double Bet { get; set; }

        public int PlayerDecisionResult { get; set; }

        public enum RoundFinalResult { Vitória, Derrota, Empate }

    }
}
