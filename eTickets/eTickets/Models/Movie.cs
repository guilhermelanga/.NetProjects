using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Movie Name")]
        [Required(ErrorMessage ="The movie name is required.")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "The description is required.")]
        public string Description { get; set; }

        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "The start date is required.")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [Required(ErrorMessage = "The end date is required.")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "The price is required.")]
        public double Price { get; set; }

        [Display(Name = "Movie Image URL")]
        [Required(ErrorMessage = "The movie image URL is required.")]
        public string MovieImageURL { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [ForeignKey("Cinema")]
        public int? CinemaId { get; set; }
        public virtual Cinema Cinema { get; set; }

        [ForeignKey("Producer")]
        public int? ProducerId { get; set; }
        public virtual Producer Producer { get; set; }

        public virtual ICollection<Actor> Actors { get; set; }
    }
}
