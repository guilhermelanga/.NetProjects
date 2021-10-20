using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using eTickets.Models;

namespace eTickets.Data
{
    public class eTicketsContext : DbContext
    {
        public eTicketsContext (DbContextOptions<eTicketsContext> options)
            : base(options)
        {
        }

        public DbSet<Actor> Actor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
               new Category { Id = 1, Type = "Action" },
               new Category { Id = 2, Type = "Comedy" },
               new Category { Id = 3, Type = "Drama" },
               new Category { Id = 4, Type = "Fantasy" },
               new Category { Id = 5, Type = "Horror" },
               new Category { Id = 6, Type = "Mystery" },
               new Category { Id = 7, Type = "Romance" },
               new Category { Id = 8, Type = "Thriller" }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
