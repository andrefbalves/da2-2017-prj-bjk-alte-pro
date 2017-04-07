using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlackJack.Models
{
    public class Game
    {
        public string NomeJogador { get; set; }

        public double  CreditosJogador { get; set; }

        public bool EmRonda { get; set; }

        [Required(ErrorMessage = "Por favor faz a tua aposta!")]
        public int Aposta { get; set; }

        public Game(string nomeJogador)
        {
            NomeJogador = nomeJogador;
            CreditosJogador = 1000;
            EmRonda = false;
            Aposta = 0;
        }

        public Game()
        { }

    }
}
