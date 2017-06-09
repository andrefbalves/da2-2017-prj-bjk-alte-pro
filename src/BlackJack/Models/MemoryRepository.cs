using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    public static class MemoryRepository
    {

        private static List<Game> games = new List<Game>();
        public static List<Game> Games
        {
            get
            {
                return games;
            }
        }

        public static void AddGame(Game game)
        {
            games.Add(game);
        }

        public static Game GetGame(int id)
        {
            foreach (Game g in Games)
            {
                if (id == g.GameId)
                    return g;
            }
            return null;
        }

        public static void UpdateGame(Game game)
        {
            Game g = GetGame(game.GameId);
            g.PlayerName = game.PlayerName;
            g.BlackJack = game.BlackJack;
            g.Credits = game.Credits;
            g.Id = game.Id;
            g.Loses = game.Loses;
            g.Rounds = game.Rounds;
            g.Ties = game.Ties;
            g.Wins = game.Wins;                      
        }

        private static List<RoundSummary> rounds = new List<RoundSummary>();
        public static List<RoundSummary> Rounds
        {
            get
            {
                return rounds;
            }
        }

        public static void AddRound(RoundSummary newround)
        {
            rounds.Add(newround);
        }

        public static void ClearRounds()
        {
            rounds.Clear();
        }

        public static int Wins { get; set; }

        public static int Loses { get; set; }

        public static int Ties { get; set; }

        public static int BlackJack { get; set; }

        private static List<TeamMember> identificacao = new List<TeamMember>();
        public static List<TeamMember> Identificacao
        {
            get { return identificacao; }
        }

        static MemoryRepository()
        {
            TeamMember a = new TeamMember();
            TeamMember d = new TeamMember();

            a.NomeEquipa = "Alte.pro";
            d.NomeEquipa = "Alte.pro";
            a.NomeMembro = "André Filipe Barrela Alves";
            d.NomeMembro = "Diogo Filipe Teles de Carvalho";
            a.NumeroMembro = 150323014;
            d.NumeroMembro = 150323035;

        }
        public static List<Game> HiScores(HiScores p)
        {

            return Games;
        }

    }
}
