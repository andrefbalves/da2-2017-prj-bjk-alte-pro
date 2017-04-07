using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlackJack.Models
{
    public class Player 
    {
        [Required(ErrorMessage = "Por favor introduz o teu nome")]        
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor introduz a tua idade")]
        [Range(18, 200, ErrorMessage = "Deves ser maior de Idade para jogar este jogo") ]
        public int Idade { get; set; }

        [Required(ErrorMessage = "Por favor introduz o número de créditos")]
        public double Creditos { get; set; }       

        public Player()
        { }
    }
}
