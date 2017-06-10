using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    public class GameSummary 
    {
        public int Rounds { get; set; }
        public double Credits { get; set; }
        public int MinBet { get; set; }
        public int MaxBet { get; set; }
        public int AvgBet { get; set; }
        public int PlayerBlackjack { get; set; }
        public int DealerBlackjack { get; set; }
             
        public GameSummary()
        { }
    }
}
