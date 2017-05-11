using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    public static class Repository
    {

        private static List<Player> players = new List<Player>();
        public static List<Player> Players
        {
            get
            {
                return players;
            }
        }

        public static void AddPlayer (Player newPlayer)
        {
            players.Add(newPlayer);
        }





    }
}
