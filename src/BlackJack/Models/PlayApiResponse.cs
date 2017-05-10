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

        public string ConverterCard(string face)
        {
            if (face.Equals("Ace"))
                return face.First().ToString();
            else if (face.Equals("Jack"))
                return face.First().ToString();
            else if (face.Equals("Queen"))
                return face.First().ToString();
            else if (face.Equals("King"))
                return face.First().ToString();
            else
                return face;
        }

        public int PlayerDecisionResult { get; set; }

        public enum RoundFinalResult { Vitória, Derrota, Empate }

    }
}
