using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlackJack.Models
{
    public enum PlayerAction { Hit, Stand, Double, Surrender, NotUse, NewRound }    

    public class PlayApiRequest
    {
        public int Id { get; set; }

        public string Key { get; set; }

        public int PlayerAction { get; set; }
               
        public int InitialBet { get; set; }        

        public PlayApiRequest(int id, int playerAction, int initialBet)
        {
            Id = id;
            Key = "rGAUUmCfk3vUgfSF";
            PlayerAction = playerAction;
            InitialBet = initialBet;
        }

        public PlayApiRequest(int id)
        {
            Id = id;
            Key = "rGAUUmCfk3vUgfSF";
        }
    }
}
