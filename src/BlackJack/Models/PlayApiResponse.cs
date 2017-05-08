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

        public double AtualCredits()
        {
            double resultado = PlayerCredits - Bet;
            return resultado;
        }

        public bool PlayingRound { get; set; }

        public int RoundCount { get; set; }

        public bool IsNewShoe { get; set; }

        [Required(ErrorMessage = "Por favor faz a tua aposta!")]
        [Range(10, 100, ErrorMessage = "A aposta deve ser de 10 a 100 créditos.")]
        public double Bet { get; set; }

        public int PlayerDecisionResult { get; set;}

        public enum RoundFinalResult { Vitória, Derrota, Empate }

        public double CalcularResultado(RoundFinalResult resultado)
        {
            if (resultado == RoundFinalResult.Vitória)
                return Bet * 2;
            else if (resultado == RoundFinalResult.Empate)
                return Bet;
            else
                return 0; //acrescentar quando acontecer BlackJack

        }
         
   


       

    }
}
