using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlackJack.Models
{
    public class NewGameApiRequest 
    {
        [Required(ErrorMessage = "Por favor introduz o teu nome")]        
        public string PlayerName { get; set; }

        [Required(ErrorMessage = "Por favor introduz a tua idade")]        
        [RegularExpression("True", ErrorMessage = "Deves ser maior de Idade para jogar este jogo")]
        public bool MaiorIdade { get; set; }

        [Required(ErrorMessage = "Por favor introduz o número de créditos")]
        public double Creditos { get; set; }

        public string TeamKey { get; set; }

        public NewGameApiRequest(string playername)
        {
            PlayerName = playername;
            TeamKey = "rGAUUmCfk3vUgfSF";
        }

        public NewGameApiRequest()
        { }
    }
}
