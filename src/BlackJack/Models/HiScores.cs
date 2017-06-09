using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    public class HiScores :  Controller
    {
        public int Numero { get; set; }

        public string NomeJogador { get; set; }

        public bool Bool { get; set; }


        public HiScores()
        {}
    }
}
