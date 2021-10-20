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

            modelBuilder.Entity<Producer>().HasData(
                new Producer { Id = 1, FullName = "Cary Joji Fukunaga", Bio = "Cary Joji Fukunaga was born on July 10, 1977 in Oakland, California, USA. He is a producer and director, known for Beasts of No Nation (2015), Sem Nome (2009) and 007: Sem Tempo Para Morrer (2021).", ProfilePictureURL = "https://m.media-amazon.com/images/M/MV5BMTU4MTY2ODExMV5BMl5BanBnXkFtZTcwMzEwNzY2NA@@._V1_UY98_CR4,0,67,98_AL_.jpg" }
                );

            modelBuilder.Entity<Actor>().HasData(
                new Actor { Id = 1, FullName = "Daniel Craig", Bio = "One of the British theatre's most famous faces, Daniel Craig, who waited tables as a struggling teenage actor with the National Youth Theatre, has gone on to star as James Bond in 007: Casino Royale (2006), 007: Quantum of Solace (2008), 007: Skyfall (2012), 007 Spectre (2015), and 007: Sem Tempo Para Morrer (2021).", ProfilePictureURL= "https://m.media-amazon.com/images/M/MV5BMjEzMjk4NDU4MF5BMl5BanBnXkFtZTcwMDMyNjQzMg@@._V1_UX214_CR0,0,214,317_AL_.jpg" }
                );

            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Name = "007: Sem Tempo Para Morrer", Description = "James Bond has left active service. His peace is short-lived when Felix Leiter, an old friend from the CIA, turns up asking for help, leading Bond onto the trail of a mysterious villain armed with dangerous new technology.", ProducerId = 1, StartDate = DateTime.Parse("2021-10-18"), EndDate = DateTime.Parse("2021-10-30"), CategoryId = 1, Price = 7.05, CinemaId = 4, MovieImageURL= "https://upload.wikimedia.org/wikipedia/pt/5/52/No_Time_to_Die.jpg" }
                );

            

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<eTickets.Models.Movie> Movie { get; set; }
    }
}
