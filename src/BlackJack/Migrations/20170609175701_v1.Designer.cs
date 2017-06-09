using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BlackJack.Models;

namespace BlackJack.Migrations
{
    [DbContext(typeof(BlackJackDbContext))]
    [Migration("20170609175701_v1")]
    partial class v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlackJack.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BlackJack");

                    b.Property<double>("Credits");

                    b.Property<int>("GameId");

                    b.Property<int>("Loses");

                    b.Property<string>("PlayerName");

                    b.Property<int>("Rounds");

                    b.Property<int>("Ties");

                    b.Property<int>("Wins");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });
        }
    }
}
