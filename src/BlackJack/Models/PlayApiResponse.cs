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

        public int Bet { get; set; }               

        public int ValueCards(Card card)
        {
            if (card.Value == 1)
                return 11;
            else if (card.Value <= 10)
                return card.Value;
            else
                return 10;
        }

        public int ValueHands(List<Card> cards)
        {
            int total = 0;
            foreach (BlackJack.Models.Card c in cards)
            {
                total = ValueCards(c) + total;
            }
            bool temAs = MaoComAs(cards);

            if (total > 21 && temAs == true)
                total = total - 10;

            return total;
        }

        private bool MaoComAs(List<Card> cards)
        {
            foreach (Card c in cards)
            {
                if (c.Value == 1)
                    return true;
            }

            return false;
        }

        public int PlayerDecisionResult { get; set; }

        public int RoundFinalResult { get; set; }



    }
}
