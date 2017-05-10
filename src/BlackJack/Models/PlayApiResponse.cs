using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlackJack.Models
{
    public enum RoundFinalResult { NewRound, Lose, Win, Empate, Surrender, BlackJack }

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

        public int ValueCards(Card card)
        {
            if (card.Value == 1)
                return 1;      //valor do as!!
            else if (card.Value <= 10)
                return card.Value;
            else
                return 10;
        }

        public int CalcularCartas(List<Card> cards)
        {
            int total = 0;
            foreach (BlackJack.Models.Card c in cards)
            {
                total = ValueCards(c) + total;
            }
            return total;
        }

        public int PlayerDecisionResult { get; set; }

        public int RoundFinalResult { get; set; }



    }
}
