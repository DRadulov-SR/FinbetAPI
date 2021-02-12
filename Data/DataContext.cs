using FinBet.Models;
using FinBet_Web_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinBet_Web_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Lexicon> Lexicons { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lexicon>().Property(l => l.Rating).HasPrecision(2, 1);

            modelBuilder.Entity<Lexicon>().HasIndex(l => l.Name).IsUnique();

            modelBuilder.Entity<Lexicon>().HasData(
                new Lexicon
                {
                    Id = 1,
                    Name = "nice",
                    Rating = 0.4m
                },
               new Lexicon
               {
                   Id = 2,
                   Name = "excellent",
                   Rating = 0.8m
               },
                new Lexicon
                {
                    Id = 3,
                    Name = "modest",
                    Rating = 0m
                },
                 new Lexicon
                 {
                     Id = 4,
                     Name = "horrible",
                     Rating = -0.8m
                 },
                  new Lexicon
                  {
                      Id = 5,
                      Name = "ugly",
                      Rating = -0.5m
                  }
            );
        }
    }
}
