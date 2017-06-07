using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    public  class CardMethods : Card
    {
        public  int ValueCards(Card card)
        {
            if (card.Value == 1)
                return 11;
            else if (card.Value <= 10)
                return card.Value;
            else
                return 10;
        }

        public  int ValueHands(List<Card> cards)
        {
            bool AceInHands = AceHands(cards);
            int total = 0;
            foreach (BlackJack.Models.Card c in cards)
            {
                total = ValueCards(c) + total;

                if (total > 21 && AceInHands == true)
                    total = total - 10;
            }                

            return total;
        }

        private  bool AceHands(List<Card> cards)
        {
            foreach (Card c in cards)
            {
                if (c.Value == 1)
                    return true;
            }

            return false;
        }
    }
}
