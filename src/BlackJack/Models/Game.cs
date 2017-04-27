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

        public int NumeroRonda { get; set; }

        public bool EmRonda { get; set; }

        [Required(ErrorMessage = "Por favor faz a tua aposta!")]
        [Range(10,100, ErrorMessage = "A aposta deve ser de 10 a 100 créditos.")]
        public double Aposta { get; set; }   //double? causa problemas no metodo creditosatuais

        public double CreditosAtuais()
        {
            double resultado = CreditosJogador - Aposta;
            return resultado;
        }

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
