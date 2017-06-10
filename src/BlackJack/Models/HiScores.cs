using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    public class HiScores
    {
        public int Id { get; set; }

        public string PlayerName { get; set; }

        public bool Bool { get; set; }
        
       
        public HiScores()
        {}
    }
}
