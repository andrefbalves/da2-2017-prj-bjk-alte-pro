using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    public class BlackJackDbContext : DbContext
    {
        public DbSet<BlackJack.Models.Game> Games { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = @"Server=(localdb)\mssqllocaldb;Database=AlteProBD;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connection);
        }
    }
}
