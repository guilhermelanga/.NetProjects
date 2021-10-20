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

            modelBuilder.Entity<Cinema>().HasData(
                new Cinema { Id =1, Name = "Cinema City Alvalade", Address = "Av. de Roma, nº 100, 1049-15, Lisboa", CinemaLogoURL = "https://www.cinemacity.pt/images/logo.png" },
                new Cinema { Id =2, Name = "Cinema City Campo Pequeno", Address = "Centro de Lazer, 1000-83, Lisboa", CinemaLogoURL = "https://www.cinemacity.pt/images/logo.png" },
                new Cinema { Id =3, Name = "Cinema Ideal", Address = "Rua do Loreto, 15/17, 1200-10, Lisboa", CinemaLogoURL = "http://www.cinemaideal.pt/wp-content/uploads/2014/08/logo1.png" },
                new Cinema { Id =4, Name = "Cinemas Nos Alvaláxia", Address = "Estádio José Alvalade, 1069-7, Lisboa", CinemaLogoURL = "https://cdn.nos.pt/common/img/nos_opengraph.png" },
                new Cinema { Id =5, Name = "Cinemas Nos Amoreiras", Address = "Av. Eng. Duarte Pacheco, 1070-103, Lisboa", CinemaLogoURL = "https://cdn.nos.pt/common/img/nos_opengraph.png" },
                new Cinema { Id =6, Name = "UCI Cinemas - El Corte Inglés", Address = "Av. Ant. Aug. Aguiar, 31, 1050-8, Lisboa", CinemaLogoURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTVeshPgbj3H8kfSAaY1qhw92ltAhF8nbx_9g&usqp=CAU" }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
