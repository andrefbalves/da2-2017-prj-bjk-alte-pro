using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    public class PlayApiRequest
    {
        public int ID { get; set; }

        public string Key { get; set; }

        public enum PlayerAction { Hit, Stand, Double, Surrender, NotUse , NewRound }
        
        public int InicialBet { get; set; }

        public PlayApiRequest()
        {  }
    }
}
