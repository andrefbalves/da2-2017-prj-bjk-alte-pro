using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlackJack.Models
{
    public class Player : Game
    {
        [Required(ErrorMessage = "Por favor introduza o seu nome")]        
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor introduza a sua idade")]
        [Range(18, 200, ErrorMessage = "Deve ser maior de Idade para jogar este jogo.") ]
        public int Idade { get; set; }

        [Required(ErrorMessage = "Por favor introduza o numero de créditos")]
        public int Creditos { get; set; }       

        public Player()
        { }
    }
}
