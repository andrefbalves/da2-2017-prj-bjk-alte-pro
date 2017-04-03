using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlackJack.Models
{
    public class Player
    {
        [Required(ErrorMessage = "Por favor introduza o seu nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor introduza a sua idade")]  //datanotations
        public int Idade { get; set; }

        public Player()
        { }
    }
}
