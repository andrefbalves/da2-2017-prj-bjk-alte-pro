using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    public static class Repository
    {

        private static List<Game> games
        {
            get
            {
                BlackJackDbContext context = new BlackJackDbContext();
                List<Game> games = context.Games.ToList();
                return games;
            }
        }
        public static List<Game> Games
        {
            get
            {
                return games;
            }
        }

        public static void AddGame(Game game)
        {
            BlackJackDbContext context = new BlackJackDbContext();
            context.Games.Add(game);
            context.SaveChanges();
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
            BlackJackDbContext context = new BlackJackDbContext();
            context.Games.Update(game);
            context.SaveChanges();
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

        private static List<TeamMember> members = new List<TeamMember>();
        public static List<TeamMember> Members
        {
            get { return members; }
        }

        public static void AddMember(TeamMember newmember)
        {
            members.Add(newmember);
        }

        static Repository()
        {
            TeamMember a = new TeamMember();
            TeamMember d = new TeamMember();

            a.NomeEquipa = "Alte.pro";
            d.NomeEquipa = "Alte.pro";
            a.NomeMembro = "André Filipe Barrela Alves";
            d.NomeMembro = "Diogo Filipe Teles de Carvalho";
            a.NumeroMembro = 150323014;
            d.NumeroMembro = 150323035;

            AddMember(a);
            AddMember(d);
        }

        private static List<HighScores> highscores = new List<HighScores>();
        public static List<HighScores> Highscores
        {
            get { return highscores; }
        }

        public static void AddHighScore(HighScores newhighscore)
        {
            highscores.Add(newhighscore);
        }               
    }
}
