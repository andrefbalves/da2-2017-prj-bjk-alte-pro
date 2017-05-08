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
        public int PlayerAction { get; set; }
        public int InicialBet { get; set; }

        public PlayApiRequest()
        {  }
    }
}
