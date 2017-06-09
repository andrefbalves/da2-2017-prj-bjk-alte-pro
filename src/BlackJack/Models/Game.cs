using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    public class Game : IComparable
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public string PlayerName { get; set; }
        public int Rounds { get; set; }
        public int Wins { get; set; }
        public int Loses { get; set; }
        public int Ties { get; set; }
        public int BlackJack { get; set; }
        public double Credits { get; set; }

        public Game()
        { }             

        int IComparable.CompareTo(object obj)
        {
            Game g = (Game)obj;
            return Credits.CompareTo(g.Credits);
        }
    }
}
