using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    public class Game : PlayApiResponse
    {
        public int Bet { get; set; }

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
            {
                if (ValueHands(Dealerhand) > 21 || ValueHands(PlayerHand) > 21)
                    return 1;
                else
                    return 11;
            }
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
                //if (total > 21 && ValueCards(c) == 11)   //serviria se o AS tivesse sido a ultima carta adicionada
                //    total = total - 10;
            }
            return total;
        }

        public Game(PlayApiResponse r)
        {
            
        }
    }
}
