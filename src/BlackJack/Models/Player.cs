using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    public class Player 
    {        
        public string NomeJogador { get; set; }
        public int Rondas { get; set; }
        public int Vitorias { get; set; }
        public int Derrotas { get; set; }
        public int Empates { get; set; }
        public int BlackJack { get; set; }
        public double Creditos { get; set; }

        public Player (PlayApiResponse r)
        {
            NomeJogador = r.PlayerName;
            Rondas = r.RoundCount;
            Creditos = r.PlayerCredits;
        }

      
    }
}
